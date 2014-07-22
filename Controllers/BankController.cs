using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NWBA.Models;

namespace NWBA.Controllers
{
    public class BankController : Controller
    {
        //
        // GET: /Bank/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Transactions(string accountType)
        {

            NWABEntities ent = new NWABEntities();
            var query = from t in ent.transactions
                        select t;
            return View(query);
        }
	}
}