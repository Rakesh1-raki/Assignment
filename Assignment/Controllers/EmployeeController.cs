using Assignment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class EmployeeController : Controller
    {
            Uri baseAddress = new Uri("https://localhost:44379/api");
            // GET: Front
            HttpClient client;

            public EmployeeController()
            {
                client = new HttpClient();
                client.BaseAddress = baseAddress;
            client.DefaultRequestHeaders.Add("X-Apikey", "admin");
        }

       // public NullValueHandling NullValueHandling { get; private set; }

        public ActionResult Index()
        {
                List<Employee> modellist = new List<Employee>();
           
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/get").Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    
                    modellist = JsonConvert.DeserializeObject<List<Employee>>(data);
                }
                return View(modellist);
       }

        public ActionResult Create()
        {
            return View();
        }

    [HttpPost]
        public ActionResult Create(Employee emp)
        {
            string data = JsonConvert.SerializeObject(emp);
            StringContent cont = new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage response =client.PostAsync(client.BaseAddress + "/post", cont).Result;
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(string id)
         {

             Employee model = new Employee();

             HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/getBy/"+id).Result;
             if (response.IsSuccessStatusCode)
             {
                 string data = response.Content.ReadAsStringAsync().Result;
                 model = JsonConvert.DeserializeObject<Employee>(data);
             }
             return View(model);

         }

         [HttpPost]
         public ActionResult update(Employee emp)
         {
             string data = JsonConvert.SerializeObject(emp);
             StringContent cont = new StringContent(data, Encoding.UTF8, "application/json");
             HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/put/"+emp.Id, cont).Result;
             if (response.IsSuccessStatusCode)
             {
                 return RedirectToAction("Index");
             }
             return View("Create",emp);
         }


      /*  public ActionResult Delete(string id)
        {

            Employee model = new Employee();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/getBy/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<Employee>(data);
            }
            return View(model);

        }*/


       
         public ActionResult Delete(string id)
         {
          
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/deletes/" + id).Result;
             if (response.IsSuccessStatusCode)
             {
                 return RedirectToAction("Index");
             }
              return RedirectToAction("Index");
         }
      


    }
} 