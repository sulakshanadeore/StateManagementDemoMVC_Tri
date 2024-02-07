using StateManagementDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateManagementDemo.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult SendData()
        {
            int custidValue = Convert.ToInt32(TempData.Peek("temp_cu_id"));

            ViewBag.custidPeekValue = custidValue;

            ViewBag.custidValue = TempData["temp_cu_name"];

                List<CustModel> modelList = new List<CustModel>() 
                {
                new CustModel(){ Custid=1,CustName="amruta",City="Delhi"},
                new CustModel(){Custid=2,CustName="Samruddhi",City="Mumbai" },
                new CustModel(){Custid=3,CustName="Paresh",City="Gurgaon" }

                };

            TempData["custlist"] = modelList;


            return View();
        }
    }
}