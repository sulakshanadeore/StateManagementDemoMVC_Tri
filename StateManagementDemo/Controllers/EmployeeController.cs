using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StateManagementDemo.Models;

namespace StateManagementDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public static List<EmpModel> emplist;
        static EmployeeController()
        {
            emplist = new List<EmpModel>() {
            new EmpModel(){Empid=1,EmpName="Sunita",Salary=10000 },
            new EmpModel() { Empid = 2, EmpName = "Parag", Salary = 30000 },
            new EmpModel() { Empid = 3, EmpName = "Paresh", Salary = 20000 }
        };  
            
        }
        public ActionResult Index()
        {
            ViewBag.mysessionID = Session.SessionID;


            return View(emplist);
        }
        public ActionResult Select(int id)
        {
            EmpModel emp = emplist.Find(eselect => eselect.Empid == id);
            if (emp != null)
            {
                Session["empid"] = emp.Empid;
                Session["empname"] = emp.EmpName;
                Session["empSalary"] = emp.Salary;
                return RedirectToAction("ShowEmpDetails");
            }
            else
            {
                return View("Error");
            }
                  
        
        }


        public ActionResult ShowSelectedEmployee(int id)
        {
            EmpModel foundEmployeWithID = emplist.Find(emplist => emplist.Empid == id);
            return View(foundEmployeWithID);

        }


        public ActionResult ShowEmpDetails() 
        {
            ViewBag.empid = Session["empid"];
            ViewBag.empname = Session["empname"];
            ViewBag.sal = Session["empSalary"];

            return View();


        }


        public ActionResult ShowEmpList()
        {
            return View(emplist);
        
        
        }


        public ActionResult NewEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewEmployee(EmpModel emp)
        {

            HttpCookie cookie = new HttpCookie("empdetails");
            cookie.Expires = DateTime.Now.AddMinutes(10);
            //cookie.Value=11;

            cookie.Values.Add("empid", emp.Empid.ToString()); 
            cookie.Values.Add("empname", emp.EmpName.ToString());
            cookie.Values.Add("sal", emp.Salary.ToString());
            cookie.Secure = false;
            Response.Cookies.Add(cookie);   

            return RedirectToAction("Saved", new {id=emp.Empid } ) ;
        }

        public ActionResult Saved(int id)
        {
           HttpCookie mycookieValue =Request.Cookies.Get("empdetails");
            if (mycookieValue != null) {

                ViewBag.Employeeid = mycookieValue["empid"].ToString();
                ViewBag.EmployeeName = mycookieValue["empname"].ToString();
                ViewBag.EmployeeSalary = mycookieValue["sal"].ToString();



            }


            //return Content("Created employeed with Empid= " + id);
            return View();
        }



        public ActionResult Edit(int id)
        {
            EmpModel empEdit=emplist.Find(edata => edata.Empid == id);
            return View(empEdit);
        
        }

        [HttpPost]
        public ActionResult Edit(FormCollection values)
        {
            string ename = values["EmpName"];
            int sal = Convert.ToInt32(values["Salary"]);
            int empid =Convert.ToInt32(values["Empid"]);
            EmpModel empEdit = emplist.Find(edata => edata.Empid == empid);
            empEdit.EmpName = ename;
            empEdit.Salary = sal;
            return RedirectToAction("Index");

        }














    }
}