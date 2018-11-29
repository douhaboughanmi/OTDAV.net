using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StartChat(string nom)
        {
         
            Session["user"] = nom;
            return View("Chat");
        }

        public ActionResult Chat(string msg)
        {
            Message message = new Message() {nom=Session["user"]as String,
                date = DateTime.Now,
                Content =msg



                            };

            return PartialView("Message",message);

        }

    }
}