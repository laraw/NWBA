using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NWBA.Models;
using NWBA.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using AutoMapper;

namespace NWBA.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        protected UserManager<ApplicationUser> UserManager { get; set; }
        protected ApplicationDbContext ApplicationDbContext { get; set; }
                
        private NWABEntities db = new NWABEntities();

        public CustomerController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }
   
        public ActionResult Details()
        {
            int? custID = UserManager.FindById(User.Identity.GetUserId()).custID;
            customer cust = new customer();
            if (custID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {                 
                cust = db.customers.Find(custID);
            }
            CustomerView cv = ViewModelFromModel(cust);
            return View(cv);
            
        }

              // GET: /Customer/Edit/5
        public ActionResult Edit()
        {
            
            int? custID = UserManager.FindById(User.Identity.GetUserId()).custID;
            customer cust = new customer();
            if (custID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                cust = db.customers.Find(custID);
            }
            CustomerView cv = ViewModelFromModel(cust);
            return View(cv);

        }


     
        [HttpPost]
        [ValidateAntiForgeryToken]       
        public ActionResult Edit(CustomerView customer)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CustomerView, customer>();
                customer cust = Mapper.Map<customer>(customer);
                db.Entry(cust).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(customer);
        }

        public ActionResult Summary()
        {
            int? custID = UserManager.FindById(User.Identity.GetUserId()).custID;
            
            customer customer = db.customers.Find(custID);
          

            
            return View(customer);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        protected CustomerView ViewModelFromModel(customer customer)
        {
            var vm = new CustomerView
            {
                custID = customer.custID,
                custName = customer.custName,
                TFN = customer.TFN,
                dateCreated = customer.dateCreated,
                addressLine1 = customer.addressLine1,
                addressLine2 = customer.addressLine2,
                suburb = customer.suburb,
                state = customer.state,
                postalCode = customer.postalCode,
                phoneNumber = customer.phoneNumber,
                mobile = customer.mobile,
                email = customer.email,
                accounts = customer.accounts
            };
            return vm;
        }
    }
}
