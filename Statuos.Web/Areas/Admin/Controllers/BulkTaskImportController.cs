using NServiceBus;
using Statuos.Data;
using Statuos.Domain;
using Statuos.Messages;
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

        public IBus Bus { get; set; }
        private IRepository<User> _userRepository;
        //
        // GET: /Admin/BulkTaskImport/

        public BulkTaskImportController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public ActionResult Index()
        {
            var bulkImports = new List<BulkTaskImportSummaryView>();
            return View(bulkImports);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new BulkTaskImport());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BulkTaskImport bulkTaskImport)
        {
            Bus.Send(new ImportTasksMessage { FileLocation = bulkTaskImport.FileName, Id = Guid.NewGuid(), UserId = _userRepository.All.Where(u => u.UserName == User.Identity.Name).SingleOrDefault().Id });
            return View("Index");
        }
       

    }
}
