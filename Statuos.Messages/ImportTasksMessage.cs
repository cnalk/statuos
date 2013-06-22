using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statuos.Messages
{
    public class ImportTasksMessage : IMessage
    {
        public Guid Id { get; set; }
        public string FileLocation { get; set; }
        public int UserId { get; set; }
    }
}
