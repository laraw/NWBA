using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NWBA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NWBA.Controllers
{
    public class BankController : Controller
    {
        //
        

        /// <summary>
        /// User manager - attached to application DB context
        /// </summary>
        protected UserManager<ApplicationUser> UserManager { get; set; }
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        // GET: /Bank/

        public BankController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Statement()
        {
            if(Request.IsAuthenticated) {
                int? custID = UserManager.FindById(User.Identity.GetUserId()).custID;
            }
            return View();
        }

        public ActionResult Transaction()
        {
            return View();
        }

        public ActionResult BillPay()
        {
            return View();
        }
	}
}