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
    public class User_TbController : Controller
    {

        private BankingEntities1 db = new BankingEntities1();

        public ActionResult Index()
        {
            ViewData["view Data Result"] = "Testing view Data Result";
            return View(db.Register_Tb.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Transaction()
        {
            return View();
        }
        public ActionResult services()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Portfolio()
        {
            return View();
        }
        public ActionResult Pricing()
        {
            return View();
        }
        public ActionResult Team()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Register_Tb register)
        {
            var lg = db.Register_Tb.Where(a => a.UserName.Equals(register.UserName) && a.Password.Equals(register.Password)).FirstOrDefault();
            if (lg != null)
            {
                return RedirectToAction("Index", "User_Tb");
               
            }
            else
            {
                return RedirectToAction("Login", "User_Tb");
            }


        }

        // GET: User_Tb/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register_Tb register_Tb = db.Register_Tb.Find(id);
            if (register_Tb == null)
            {
                return HttpNotFound();
            }
            return View(register_Tb);
        }

        // GET: User_Tb/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_Tb/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,UserName,Password")] Register_Tb register_Tb)
        {
            if (ModelState.IsValid)
            {
                db.Register_Tb.Add(register_Tb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(register_Tb);
        }

        // GET: User_Tb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register_Tb register_Tb = db.Register_Tb.Find(id);
            if (register_Tb == null)
            {
                return HttpNotFound();
            }
            return View(register_Tb);
        }

        // POST: User_Tb/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,UserName,Password")] Register_Tb register_Tb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(register_Tb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(register_Tb);
        }

        // GET: User_Tb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register_Tb register_Tb = db.Register_Tb.Find(id);
            if (register_Tb == null)
            {
                return HttpNotFound();
            }
            return View(register_Tb);
        }

        // POST: User_Tb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Register_Tb register_Tb = db.Register_Tb.Find(id);
            db.Register_Tb.Remove(register_Tb);
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
