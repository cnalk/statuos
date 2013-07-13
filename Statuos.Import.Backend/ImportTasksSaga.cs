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
                                    IHandleMessages<ITaskImported>, 
                                    IHandleMessages<ITaskImportFailed>, 
                                    IHandleTimeouts<ImportTaskTimeout>
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ImportTasksSaga));

        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<ITaskImported>(s => s.ImportId, m => m.ImportId);
            ConfigureMapping<ITaskImportFailed>(s => s.ImportId).ToSaga(s => s.ImportId);
        }

        public void Handle(ImportTasksMessage message)
        {
            RequestTimeout(TimeSpan.FromHours(24), new ImportTaskTimeout());

            var csv = new CsvReader(File.OpenText(message.FileLocation));
            var records = csv.GetRecords<ImportTaskRecord>().ToList();

            var customers = records.Select(c => c.CustomerName).Distinct();
            var projects = records.Select(c => new { Customer = c.CustomerName, Project = c.ProjectName }).Distinct();

            foreach (var customer in customers)
            {
                Bus.Send(new ImportCustomer { Name = customer });
            }
            foreach (var project in projects)
            {
                Bus.Send(new ImportProject { CustomerName = project.Customer, ProjectName = project.Project });
            }
            foreach (var task in records)
            {
                Bus.Send(new ImportTask { CustomerName = task.CustomerName, Hours = task.TaskHours, ImportId = this.Data.ImportId, ProjectName = task.ProjectName, TaskName = task.TaskName });
                this.Data.ClientsToBeImported++;
            }            
        }

        public void Handle(ITaskImported message)
        {
            this.Data.ClientsImported++;
        }

        public void Handle(ITaskImportFailed message)
        {
            this.Data.ClientsFailedToImport++;
        }

        public void Timeout(ImportTaskTimeout state)
        {
            //Check status.  If not all tasks finished record to database.
        }


    }
}
