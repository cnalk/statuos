using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statuos.Web.Areas.Admin.Models
{
    public class BulkTaskImport
    {
        public string FileName { get; set; }
        public string ImportName { get; set; }
        public string MyProperty { get; set; }
    }
}