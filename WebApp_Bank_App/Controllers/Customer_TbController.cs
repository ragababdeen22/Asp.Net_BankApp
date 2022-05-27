using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp_Bank_App.Models;

namespace WebApp_Bank_App.Controllers
{
    public class Customer_TbController : Controller
    {
        private BankingEntities1 db = new BankingEntities1();

        // GET: Customer_Tb
        public ActionResult Index(string SearchBy, string search)
        {
            if (SearchBy == "Name")
            {
                return View(db.Customer_Tb.Where(x => x.Name.StartsWith(search) || search==null).ToList());

            }
            else
            {
                return View(db.Customer_Tb.Where(x => x.Acc_number ==search || search==null).ToList());

            }
        }
            // GET: Customer_Tb/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Tb customer_Tb = db.Customer_Tb.Find(id);
            if (customer_Tb == null)
            {
                return HttpNotFound();
            }
            return View(customer_Tb);
        }

        // GET: Customer_Tb/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer_Tb/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Gender,Date_of_birth,Phone,Address,UserName,Password,Acc_number,Money")] Customer_Tb customer_Tb)
        {
            if (ModelState.IsValid)
            {
                db.Customer_Tb.Add(customer_Tb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer_Tb);
        }

        // GET: Customer_Tb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Tb customer_Tb = db.Customer_Tb.Find(id);
            if (customer_Tb == null)
            {
                return HttpNotFound();
            }
            return View(customer_Tb);
        }

        // POST: Customer_Tb/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Gender,Date_of_birth,Phone,Address,UserName,Password,Acc_number,Money")] Customer_Tb customer_Tb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_Tb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer_Tb);
        }

        // GET: Customer_Tb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Tb customer_Tb = db.Customer_Tb.Find(id);
            if (customer_Tb == null)
            {
                return HttpNotFound();
            }
            return View(customer_Tb);
        }

        // POST: Customer_Tb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer_Tb customer_Tb = db.Customer_Tb.Find(id);
            db.Customer_Tb.Remove(customer_Tb);
            db.SaveChanges();
            return RedirectToAction("Index");
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
