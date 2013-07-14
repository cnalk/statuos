using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statuos.Messages
{
    public class ImportProject : ICommand
    {
        public string ProjectName { get; set; }
        public string CustomerName { get; set; }
        public string ProjectManager { get; set; }
    }
}
