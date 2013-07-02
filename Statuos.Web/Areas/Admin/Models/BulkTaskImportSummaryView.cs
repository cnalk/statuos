using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statuos.Web.Areas.Admin.Models
{
    public class BulkTaskImportSummaryView
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime UploadedDate { get; set; }
        public string UserName { get; set; }

    }
}