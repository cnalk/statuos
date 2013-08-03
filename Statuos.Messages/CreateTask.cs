using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statuos.Messages
{
    public class CreateTask : ICommand
    {
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public string TaskName { get; set; }
        public Guid ImportId { get; set; }
    }
}
