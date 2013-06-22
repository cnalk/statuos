using NServiceBus;
using NServiceBus.Logging;
using Statuos.Messages;
using System;
using System.Threading;

namespace Statuos.Import.Backend
{
    public class ImportTasksMessageHandler : IHandleMessages<ImportTasksMessage>
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ImportTasksMessageHandler));
        public void Handle(ImportTasksMessage message)
        {
            Logger.Warn("something happened");


            throw new NotImplementedException();
        }
    }
}
