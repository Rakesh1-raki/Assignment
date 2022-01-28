using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace Assignment.Controllers
{
    public class ValuesController : ApiController
    { 
        [HttpGet]
        [Route("api/get")]
        //[ApiKeyVadliate]
     //   [Authorize]
        public List<Employee> Get()
        {
            using (SqlConnection con = new SqlConnection(@"server=DESKTOP-GD17LGD; database=FirstDb; Integrated Security=true;"))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employee", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    List<Employee> employees = new List<Employee>();
                    foreach (DataRow row in dt.Rows)
                    {
                        Employee employee = new Employee();
                        employee.Id = Convert.ToString(row["Id"]);
                        employee.FirstName = Convert.ToString(row["FirstName"]);
                        employee.MiddleName = Convert.ToString(row["MiddleName"]);
                        employee.LastName = Convert.ToString(row["LastName"]);
                        employee.DOB = (DateTime?)row["DOB"];
                        employee.Desgination = Convert.ToString(row["Desgination"]);
                        employee.ManagerID = Convert.ToString(row["ManagerID"]);
                        employee.Salary = Convert.ToInt32(row["Salary"]);
                        employee.TeamID = Convert.ToString(row["TeamID"]);
                        employee.DOJ = (DateTime?)row["DOJ"];
                        employee.DOL = Convert.ToString(row["DOL"]);
                        employees.Add(employee);

                    }
                    return employees;
                }
                else
                {
                    return new List<Employee>();
                }
            }
        }

        [HttpGet]
        [Route("api/getBy/{id}")]
        public Employee Get(string id)
        {
            using (SqlConnection con = new SqlConnection(@"server=DESKTOP-GD17LGD; database=FirstDb; Integrated Security=true;"))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employee WHERE ID = '" + id + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                   
                    Employee employee = new Employee();
                    foreach (DataRow row in dt.Rows)
                    {
                        Employee employees = new Employee();
                        employee.Id = Convert.ToString(row["Id"]);
                        employee.FirstName = Convert.ToString(row["FirstName"]);
                        employee.MiddleName = Convert.ToString(row["MiddleName"]);
                        employee.LastName = Convert.ToString(row["LastName"]);
                        employee.DOB = (DateTime?)row["DOB"];
                        employee.Desgination = Convert.ToString(row["Desgination"]);
                        employee.ManagerID = Convert.ToString(row["ManagerID"]);
                        employee.Salary = Convert.ToInt32(row["Salary"]);
                        employee.TeamID = Convert.ToString(row["TeamID"]);
                        employee.DOJ = (DateTime?)row["DOJ"];
                        employee.DOL = Convert.ToString(row["DOL"]);

                    }
                    return employee;
                }
                else
                {
                    return new Employee();
                }
            }
        }

        

        [HttpPost]
         [Route("api/post")]
         
         public string Post([FromBody]Employee obj)
         {
            using (SqlConnection con = new SqlConnection(@"server=DESKTOP-GD17LGD; database=FirstDb; Integrated Security=true;"))
            {
                SqlCommand cmd = new SqlCommand("Insert into Employee Values('" + obj.Id + "','" + obj.FirstName + "','" + obj.MiddleName + "','"
                 + obj.LastName + "','" + obj.DOB.ToString() + "','" + obj.Desgination + "','" + obj.ManagerID + "','" + obj.Salary.ToString() + "','" + obj.TeamID + "','" + obj.DOJ.ToString() + "','" + obj.DOL + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "succesfully";
            }

         }
       
          [HttpPut]
          
          [Route("api/put/{id}")]
          public Employee Put(string id, [FromBody] Employee obj)
          {
            using (SqlConnection con = new SqlConnection(@"server=DESKTOP-GD17LGD; database=FirstDb; Integrated Security=true;"))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Employee SET FirstName = '" + obj.FirstName + "',MiddleName='" + obj.MiddleName + "',LastName ='" + obj.LastName + "',DOB='" + obj.DOB.ToString() + "',Desgination='" + obj.Desgination + "', ManagerID='" + obj.ManagerID + "',Salary='" + obj.Salary.ToString() + "',TeamID='" + obj.TeamID + "',DOJ='" + obj.DOJ.ToString() + "',DOL='" + obj.DOL + "' WHERE ID ='" + id + "' ", con);
                con.Open();
                 cmd.ExecuteNonQuery();

                con.Close();
               
                DataTable dt = new DataTable();
               
                if (dt.Rows.Count > 0)
                {
                    
                    Employee employee = new Employee();
                    foreach (DataRow row in dt.Rows)
                    {
                        Employee employees = new Employee();
                        employee.Id = Convert.ToString(row["Id"]);
                        employee.FirstName = Convert.ToString(row["FirstName"]);
                        employee.MiddleName = Convert.ToString(row["MiddleName"]);
                        employee.LastName = Convert.ToString(row["LastName"]);
                        employee.DOB = (DateTime?)row["DOB"];
                        employee.Desgination = Convert.ToString(row["Desgination"]);
                        employee.ManagerID = Convert.ToString(row["ManagerID"]);
                        employee.Salary = Convert.ToInt32(row["Salary"]);
                        employee.TeamID = Convert.ToString(row["TeamID"]);
                        employee.DOJ = (DateTime?)row["DOJ"];
                        employee.DOL = Convert.ToString(row["DOL"]);

                    }
                    return employee;
                }
                else
                {
                    return new Employee();
                }
            }
          }
        [HttpDelete]
        [Route("api/deletes/{id}")]
        public string Delete(string id)
        {
            using (SqlConnection con = new SqlConnection(@"server=DESKTOP-GD17LGD; database=FirstDb; Integrated Security=true;"))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Employee WHERE Id = '" + id + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return "success";
            }
        }  
    }
}


