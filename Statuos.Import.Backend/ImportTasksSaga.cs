using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.Saga;
using Statuos.Messages;
using System;
using System.IO;
using System.Threading;

namespace Statuos.Import.Backend
{
    public class ImportTasksSaga : Saga<ImportTaskSagaData>, 
                                    IAmStartedByMessages<ImportTasksMessage>, 
                                    IHandleMessages<ITaskImport>, 
                                    IHandleMessages<ITaskImportFailed>, 
                                    IHandleTimeouts<ImportTaskTimeout>
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ImportTasksSaga));

        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<ITaskImport>(s => s.ImportId, m => m.ImportId);
            ConfigureMapping<ITaskImportFailed>(s => s.ImportId).ToSaga(s => s.ImportId);
        }

        public void Handle(ImportTasksMessage message)
        {
            RequestTimeout(TimeSpan.FromHours(24), new ImportTaskTimeout());
            var lines = File.ReadAllLines(message.FileLocation);
            var csv = from line in lines
                      select (from piece in line
                              select piece.Split(',')).ToArray();

            foreach (var csvLine in csv)
            {
                this.Data.ClientsToBeImported++;
                //Create Client
                //Create Project
                //Create Task
            }
        }

        public void Handle(ITaskImport message)
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
