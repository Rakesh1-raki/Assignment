﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApiMvc1.Models;

namespace WebApiMvc1.Controllers
{
    public class FrontController : Controller
    {
        // GET: Front
        Uri baseAddress = new Uri("https://localhost:44379");
        // GET: Front
        HttpClient client;

        public FrontController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public ActionResult Index()
        {
            List<Employee> modellist = new List<Employee>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/api/Values").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modellist = JsonConvert.DeserializeObject<List<Employee>>(data);
            }
            return View(modellist);
        }
    }
}