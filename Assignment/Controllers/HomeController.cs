using Assignment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class HomeController : Controller
    {
        

         FirstDbEntities1 _context = new FirstDbEntities1();
          public ActionResult Index()
          {
              ViewBag.Employee = _context.Employees.ToList();
              var listofData = _context.Employees.ToList();
              return View();
          }
          [HttpPost]
          public ActionResult Create()
          {
              return View();
          }
          [HttpPost]
          public ActionResult CreateEmp(Employee emp)
          {
              _context.Employees.Add(emp);
              _context.SaveChanges();
              return RedirectToAction("Index");
          }
          public ActionResult Delete()
          {
              return View();
          }
          [HttpPost]
          public ActionResult DeleteID(string id)
          {
              List<Employee> emp = _context.Employees.Where(obj => obj.Id == id).ToList();
              if (emp != null)
              {
                  _context.Employees.Remove(emp[0]);
                  _context.SaveChanges();
                  ViewBag.Employee = _context.Employees.ToList();
                  return RedirectToAction("Index");
              }
              return null;
          }
          public ActionResult Edit(string id)
          {
              List<Employee> emp = _context.Employees.Where(obj => obj.Id == id).ToList();
              ViewBag.emp = emp;
              return View();
          }
          [HttpPost]
          public ActionResult Edit(Employee emp)
          {
              List<Employee> employee = _context.Employees.Where(obj => obj.Id == emp.Id).ToList();
              if (employee != null)
              {

                  employee[0].FirstName = emp.FirstName;
                  employee[0].MiddleName = emp.MiddleName;
                  employee[0].LastName = emp.LastName;
                  employee[0].DOB = emp.DOB;
                  employee[0].Desgination = emp.Desgination;
                  employee[0].ManagerID = emp.ManagerID;
                  employee[0].Salary = emp.Salary;
                  employee[0].TeamID = emp.TeamID;
                  employee[0].DOJ = emp.DOJ;
                  employee[0].DOL = emp.DOL;
                  ViewBag.Employee = _context.Employees.ToList();

                  return View("Index");
              }
              else
              {
                  return null;
              }


          }
    }
}
