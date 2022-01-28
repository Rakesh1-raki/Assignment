using Assignment.Attributes;
using Assignment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment.Controllers
{
    public class EmpController : ApiController
    {
       FirstDbEntities1 db = new FirstDbEntities1();
        // Anyone can Acsses without token acsses
       // SqlConnection sqls = new SqlConnection(@"Data Source=DESKTOP-GD17LGD;Initial Catalog=FirstDb;Integrated Security=True;");
        [ApiKeyValidation]
        [HttpGet]
        [Route("api/server/info")]
        public IHttpActionResult Get()            //  https://localhost:44303/api/server/info Get time and date of the system
        {
            return Ok("Server time is : "+ DateTime.Now.ToString());

        }

        // After token acsses then only acsses the data

    //    [ApiKeyValidation]
        [HttpGet]
        [Route("api/emp/developer")]
        public List<Employee> GetforDeveloper()    // https://localhost:44303/api/emp/Developer Get Data {-using postman}
         {
             // using(var db = new FirstDBEntities())
             // {
             var employees = db.Employees.ToList();
             return employees;
             // }

         }
       
        [ApiKeyValidation]
        [HttpGet]
        [Route("api/emp/{id}")]
        public IHttpActionResult GetForDeveloper(string id) //https://localhost:44303/api/emp/TT434 Get specifi Data {-using postman}
        {
            Employee emp = db.Employees.Find(id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }
        [ApiKeyValidation]
        [HttpPut]
        [Route("api/emp/id")]
        public Employee Put(string id)             //https://localhost:44303/api/emp/TT434 Update Data {-using postman}
        {
            return db.Employees.FirstOrDefault(e => e.Id == id);
        }
        [ApiKeyValidation]
       public IHttpActionResult PutEmployee(Employee emp)
        {
            var existing = db.Employees.Where(e => e.Id == emp.Id).FirstOrDefault<Employee>();
            if (existing != null)
            {
                existing.Id = emp.Id;
                existing.FirstName = emp.FirstName;
                existing.MiddleName = emp.MiddleName;
                existing.LastName = emp.LastName;
                existing.DOB = emp.DOB;
                existing.Desgination = emp.Desgination;
                existing.ManagerID = emp.ManagerID;
                existing.Salary = emp.Salary;
                existing.TeamID = emp.TeamID;
                existing.DOJ = emp.DOJ;
                existing.DOL = emp.DOL;
                db.SaveChanges();
            }
            return BadRequest();
        }
        [ApiKeyValidation]
        [HttpDelete]
        [Route("api/emp/delete/{id}")]
        public IHttpActionResult DeleteEmp(string id)  //https://localhost:44303/api/emp/TT434 Delete Data {-using postman}
        {
            Employee emp = db.Employees.Find(id);
            if (emp == null)
            {
                return NotFound();
            }
            db.Employees.Remove(emp);
            db.SaveChanges();
            return Ok(emp);
        }
        [ApiKeyValidation]
        [HttpPost]
        [Route("api/emp")]
        public IHttpActionResult PostEmp(Employee emp)    //https://localhost:44303/api/emp/TT434 Insert Data {-using postman}
        {
            db.Employees.Add(emp);
            db.SaveChanges();
            return Ok(emp);
        }

    }
}
