using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_Bank_App.Models;

namespace WebApp_Bank_App.Controllers
{
    public class TransactionController : Controller
    {
        BankingEntities1 db = new BankingEntities1();


        // GET: Transaction
        public ActionResult Transefer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Transefer(Customer_Tb obj, string btn)
        {
            if (btn == "Transefer")
            {
                var data = db.Customer_Tb.Where(obj1 => obj1.Acc_number == obj.Acc_number).FirstOrDefault();
                data.Money += obj.Money;
                int mess = db.SaveChanges();

                if (mess == 1)
                {
                    ViewBag.data = "Transefer Done";

                }
                else
                {
                    ViewBag.data = "Transefer Not Done";
                }
            }
            else if (btn == "Show")
            {

                var data = db.Customer_Tb.Where(obj1 => obj1.Acc_number == obj.Acc_number).FirstOrDefault();

                ViewBag.show = data.Money;
            }


            return View();
        }

        public ActionResult Deposite()
        {
            return View();
        }
       
      
        [HttpPost]
        public ActionResult Deposite(Customer_Tb obj, string btn)
        {
            if (btn == "Deposite")
            {
                var data = db.Customer_Tb.Where(obj1 => obj1.Acc_number == obj.Acc_number).FirstOrDefault();
                data.Money += obj.Money;
                int mess = db.SaveChanges();

                if (mess == 1)
                {
                    ViewBag.data = "Deposite Done";

                }
                else
                {
                    ViewBag.data = "Deposite Not Done";
                }
            }
            else if (btn == "Show")
            {

                var data = db.Customer_Tb.Where(obj1 => obj1.Acc_number == obj.Acc_number).FirstOrDefault();

                ViewBag.show = data.Money;
            }


            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Customer_Tb obj, string btn)
        {
            if (btn == "Withdraw")
            {
                var data = db.Customer_Tb.Where(obj1 => obj1.Acc_number == obj.Acc_number).FirstOrDefault();

                if (obj.Money <= data.Money)
                {
                    data.Money -= obj.Money;
                    int mess = db.SaveChanges();
                    if (mess == 1)
                    {
                        ViewBag.data = "Withdraw Done";

                    }
                    else
                    {
                        ViewBag.data = "Withdraw Not Done";
                    }
                }

                else
                {
                    ViewBag.data = "Insufficient balance";
                }
            }
           else if (btn == "Show")
            {

                var data = db.Customer_Tb.Where(obj1 => obj1.Acc_number == obj.Acc_number).FirstOrDefault();

                ViewBag.show = data.Money;
            }


            return View();
        }
    }
}
