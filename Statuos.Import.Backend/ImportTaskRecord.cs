﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statuos.Import.Backend
{
    public class ImportTaskRecord
    {
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string ProjectName { get; set; }
        public string TaskName { get; set; }
        public decimal TaskHours { get; set; }
        public string ProjectManager { get; set; }
        public string Employee { get; set; }
        public DateTime DateCharged { get; set; }
    }
}
