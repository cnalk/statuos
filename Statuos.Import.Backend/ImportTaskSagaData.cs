using NServiceBus.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statuos.Import.Backend
{
    public class ImportTaskSagaData : ContainSagaData
    {
        [Unique]
        public Guid ImportId { get; set; }
        public int ClientsToBeImported { get; set; }
        public int ClientsImported { get; set; }
        public int ClientsFailedToImport { get; set; }
    }
}
