using NServiceBus;
using Statuos.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statuos.Import.Backend
{
    public class ImportTaskHandler : IHandleMessages<ImportTask>
    {
        public IBus Bus { get; set; }
        public void Handle(ImportTask message)
        {
            Bus.Publish<ITaskImportSucceeded>(m => { m.ImportId = message.ImportId; });
        }
    }
}
