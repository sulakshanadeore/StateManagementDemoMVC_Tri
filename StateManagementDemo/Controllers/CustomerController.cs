using StateManagementDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateManagementDemo.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult CustDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustDetails(CustModel cust) 
        {

            ViewBag.customerid = cust.Custid;
            ViewBag.customername = cust.CustName;
            ViewBag.addressCity = cust.City;

            //return Content("Recevied cust details.." + ViewBag.customerid + " " + ViewBag.customername + " " + ViewBag.addressCity);
            return View();
                   
        }

        public ActionResult Index() 
        {
            CustModel model = new CustModel() {Custid=11,CustName="Shruti",City="Bangalore" };
            ViewBag.customerData = model;
            ViewBag.greetings = "Hello";
            return View();  
               
        }

        public ActionResult AcceptData()
        {

            return View();
        
        }

        [HttpPost]
        public ActionResult AcceptData(CustModel model)
        {

            TempData["temp_cu_id"] = model.Custid;
            TempData["temp_cu_name"] = model.CustName;
            TempData["temp_cu_city"] = model.City;


            return RedirectToAction("DisplayData");

        }
        public ActionResult DisplayData()
        {
            //Display in the display data using ViewBag,ViewData or Tempdata

            //TempData["tmpCID"] = TempData["temp_cu_id"];
            //TempData["tmpCName"] = TempData["temp_cu_name"];
            //TempData["tmpCCity"] = TempData["temp_cu_city"];


            ViewData["vdCID"] = TempData["temp_cu_id"];
            ViewData["vdCName"] = TempData["temp_cu_name"];
            ViewData["vdCCity"] = TempData["temp_cu_city"];
            TempData.Keep();//restoration of the data


            return RedirectToAction("RecieveItHere");
        
        }

        public ActionResult RecieveItHere()
        { 
        
            ViewBag.custidData= TempData["temp_cu_id"];
            ViewBag.custnameData = TempData["temp_cu_name"];
            ViewBag.custcityData = TempData["temp_cu_city"];
           // int custidValue=Convert.ToInt32(TempData.Peek("temp_cu_id"));

            //ViewBag.custidPeekValue = custidValue;
            //ViewBag.custidValue= TempData["temp_cu_name"];
            return RedirectToAction("SendData","Admin");

        }
        public ActionResult SomeAction() 
        {
            int custidValue = Convert.ToInt32(TempData.Peek("temp_cu_id"));

            ViewBag.custidPeekValue = custidValue;

            ViewBag.custidValue = TempData["temp_cu_name"];
            return View();



        }




    }
}