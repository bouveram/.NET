using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormationMVC.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult BookView()
        {
            ViewBag.BookTitle = "Titre de Mon Livre";
            return View();
        }
    }
}