using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMvc1.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Desgination { get; set; }
        public string ManagerID { get; set; }
        public Nullable<int> Salary { get; set; }
        public string TeamID { get; set; }
        public Nullable<System.DateTime> DOJ { get; set; }
        public string DOL { get; set; }
    }
}