using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statuos.Messages
{
    public interface ITaskImportEvent : IEvent
    {
        Guid ImportId { get; set; }
    }
}
