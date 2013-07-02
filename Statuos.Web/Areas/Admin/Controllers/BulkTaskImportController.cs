using Statuos.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Statuos.Web.Areas.Admin.Controllers
{
    public class BulkTaskImportController : Controller
    {
        //
        // GET: /Admin/BulkTaskImport/

        public ActionResult Index()
        {
            var bulkImports = new List<BulkTaskImportSummaryView>();
            return View(bulkImports);
        }

       

    }
}
