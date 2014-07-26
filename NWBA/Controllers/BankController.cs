
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NWBA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using NWBA.ViewModels;
using AutoMapper;
using System.Data.Entity;

namespace NWBA.Controllers
{
    [Authorize]
    public class BankController : Controller
    {
        protected UserManager<ApplicationUser> UserManager { get; set; }
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        protected customer cust { get; set; }

        private NWABEntities db = new NWABEntities();
        
        public BankController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            int? custID = UserManager.FindById(User.Identity.GetUserId()).custID;
            
        }
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult Statement(StatementView statementview, string accountType)
        {
            var transactions = from t in statementview.transactions
                               join a in statementview.accounts on t.accountNum equals a.accountNumber
                               where a.accountTypeCode.Equals(accountType)
                               select t;

            return View(transactions.ToList());
        }

        public ActionResult Transaction()
        {
        
            return View();
        }


        public ActionResult BillPay()
        {
            return View();
        }

        public ActionResult AccountSummary()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        protected StatementView ViewModelFromModel(string accountType)
        {

            NWABEntities ent = new NWABEntities();
            int? custid = UserManager.FindById(User.Identity.GetUserId()).custID;
            customer cust = ent.customers.Find(custid);
            ICollection<account> accounts = cust.accounts;
            

            StatementView vm = new StatementView();
            vm.accounts = accounts;
            vm.custID = cust.custID;
            

            return vm;
            
        }

       
	}
}