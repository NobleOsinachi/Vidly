using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using System.Collections.Generic;

namespace Vidly.Controllers
{
    public class RentalsController : Controller
    {
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
    }
}