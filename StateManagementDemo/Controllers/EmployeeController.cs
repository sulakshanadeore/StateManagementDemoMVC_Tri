using System;
using System.Collections.Generic;
using System.Linq;
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
        

        











    }
}