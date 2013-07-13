using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statuos.Import.Backend
{
    public class ImportTaskRecord
    {
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public string TaskName { get; set; }
        public decimal TaskHours { get; set; }
    }
}
