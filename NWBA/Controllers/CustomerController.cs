using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NWBA.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NWBA.Controllers
{
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

            if (Request.IsAuthenticated)
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
                ICollection<customerAddress> custaddress = cust.customerAddresses;
                ICollection<customerPhoneNumber> custPhoneNumber = cust.customerPhoneNumbers;
                ViewBag.CustomerAddresses = custaddress;
                ViewBag.CustomerPhoneNumbers = custPhoneNumber;
                
                return View(cust);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
        }
        

              // GET: /Customer/Edit/5
        public ActionResult Edit()
        {

            int? custID = UserManager.FindById(User.Identity.GetUserId()).custID;
            if (custID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer customer = db.customers.Find(custID);
            customerAddress custaddress = db.customerAddresses.Find(custID);

            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.custID = new SelectList(db.logins, "custID", "userid", customer.custID);
            return View(customer);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="custID,custName,TFN")] customer customer)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.custID = new SelectList(db.logins, "custID", "userid", customer.custID);
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
    }
}
