using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class EmployeeRepository : IDisposable
    {
        FirstDbEntities1 _context = new FirstDbEntities1();

        // To Check and validate the user credentials
        public Employee ValidateEmployee(string empname, string password)
        {
            return _context.Employees.FirstOrDefault(Emp => Emp.FirstName.Equals(empname, StringComparison.OrdinalIgnoreCase) &&
            Emp.Id == password);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}