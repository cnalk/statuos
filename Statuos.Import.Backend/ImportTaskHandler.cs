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
        public void Handle(ImportTask message)
        {
            throw new NotImplementedException();
        }
    }
}
