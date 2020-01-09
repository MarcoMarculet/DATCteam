using BOB.Commons;
using Microsoft.AspNet.SignalR.Client.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PulsWebPage.Models;
using Newtonsoft.Json;

namespace PulsWebPage.Controllers
{
    public class HomeController : Controller
    {
        //static HttpClient client = new HttpClient();

           

        public async Task<ActionResult> Index()
        {
            /*client.BaseAddress = new Uri("https://datcpulsapi.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("https://datcpulsapi.azurewebsites.net/api/raport");
            response.EnsureSuccessStatusCode();
            DefaultHttpClient client = new DefaultHttpClient();
            HTTPGet httpGet = new HTTPGet("https://datcpulsapi.azurewebsites.net/api/raport");
            HttpResponse resp = client.(httpGet);*/

            HttpClient client = new HttpClient();
            List<Raport> rapoarte = new List<Raport>();
            HttpResponseMessage response = await client.GetAsync("https://datcpulsapi.azurewebsites.net/api/raport");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                rapoarte = JsonConvert.DeserializeObject<List<Raport>>(result);
            }

            return View(rapoarte);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}