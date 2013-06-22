using NServiceBus;
using Statuos.Data;
using Statuos.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Statuos.Web.Controllers
{
    public class HomeController : Controller
    {
        public IBus Bus { get; set; }

        public ActionResult Index()
        {

            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        public ActionResult About()
        {

            Bus.Send(new ImportTasksMessage
            {
                Id = Guid.NewGuid(),
                FileLocation = "C:/",
                UserId = 1
            });
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
