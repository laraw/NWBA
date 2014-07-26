
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

        private StatementView stateview;
        
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
        public ActionResult Statement()
        {
            int? custID = UserManager.FindById(User.Identity.GetUserId()).custID;
            
            if (custID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             
            else
            {
                stateview = new StatementView();
                stateview.transactions = from t in db.transactions
                                         join a in db.accounts on t.accountNum equals a.accountNumber
                                         where a.custID.Equals(custID) && a.accountTypeCode.Equals(stateview.accountTypes.SelectedValue)
            }
            
            return View(stateview);
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

        protected void ViewModelFromModel(string accountType)
        {
            int? custid = UserManager.FindById(User.Identity.GetUserId()).custID;
            
            ICollection<transaction> savingstransactions = 

            StatementView vm = new StatementView();
        }
               
	}
}