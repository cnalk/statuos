using CsvHelper;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.Saga;
using Statuos.Messages;
using System;
using System.IO;
using System.Threading;
using System.Linq;

namespace Statuos.Import.Backend
{
    public class ImportTasksSaga : Saga<ImportTaskSagaData>,
                                    IAmStartedByMessages<ImportTasksMessage>,
                                    IHandleMessages<ITaskImportSucceeded>,
                                    IHandleTimeouts<ImportTaskTimeout>
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ImportTasksSaga));

        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<ITaskImportSucceeded>(s => s.ImportId, m => m.ImportId);
        }

        public void Handle(ImportTasksMessage message)
        {
            Logger.Info(string.Format("Beging Import for {0}", message.FileLocation));

            Data.ImportId = message.Id;

            RequestTimeout(TimeSpan.FromHours(24), new ImportTaskTimeout());

            var csv = new CsvReader(File.OpenText(message.FileLocation));
            var records = csv.GetRecords<ImportTaskRecord>().ToList();

            var customers = records.Select(c => new { Customer = c.CustomerName, Code = c.CustomerCode }).Distinct();
            var projects = records.Select(c => new { Customer = c.CustomerName, Project = c.ProjectName, ProjectManager = c.ProjectManager }).Distinct();

            foreach (var customer in customers)
            {
                Bus.Send(new ImportCustomer { Name = customer.Customer, Code = customer.Code });
            }
            foreach (var project in projects)
            {
                Bus.Send(new ImportProject { CustomerName = project.Customer, ProjectName = project.Project, ProjectManager = project.ProjectManager });
            }
            foreach (var task in records)
            {
                Bus.Send(new CreateTask { CustomerName = task.CustomerName, ImportId = message.Id, ProjectName = task.ProjectName, TaskName = task.TaskName });
                Bus.Send(new ImportTaskHours { CustomerName = task.CustomerName, ImportId = message.Id, ProjectName = task.ProjectName, TaskName = task.TaskName, Hours = task.TaskHours, UserName = task.Employee, DateCharged = task.DateCharged });
                this.Data.ClientsToBeImported++;
            }
        }

        public void Handle(ITaskImportSucceeded message)
        {
            this.Data.ClientsImported++;
            CheckCompleted();
        }


        private void CheckCompleted()
        {
            if (Data.ClientsImported == Data.ClientsToBeImported)
                MarkAsComplete();
        }

        public void Timeout(ImportTaskTimeout state)
        {
            MarkAsComplete();
        }


    }
}
