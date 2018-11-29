using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class RdvController : Controller
    {
        // GET: Rdv
        public ActionResult Index( )
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("PI_J2ee-web/rest/RDV/getAll").Result;
            response.EnsureSuccessStatusCode();
            List<Models.RdvViewModel> oeuvres = response.Content.ReadAsAsync<List<Models.RdvViewModel>>().Result;
            ViewBag.Title = "tous les Oeuvres";
            return View(oeuvres);

        }

        // GET: Rdv/Details/5
        public ActionResult Details(int id)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/");
            HttpResponseMessage response = Client.GetAsync("PI_J2ee-web/rest/RDV/getById/" + id.ToString()).Result;
            response.EnsureSuccessStatusCode();
            Models.RdvViewModel products = response.Content.ReadAsAsync<Models.RdvViewModel>().Result;
            ViewBag.Title = "All ProductS";
            return View(products);
        }

        // GET: Rdv/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rdv/Create
        [HttpPost]
        public ActionResult Create(RdvViewModel rdv)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.PostAsJsonAsync<RdvViewModel>("PI_J2ee-web/rest/RDV/ajoutDemande", rdv).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
            return View();

        }

        // GET: Rdv/Edit/5
        public ActionResult Edit(int id)
        {
            RdvViewModel rdv = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18080/");
                var responseTask = client.GetAsync("PI_J2ee-web/rest/RDV/getById/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RdvViewModel>();
                    readTask.Wait();
                    rdv = readTask.Result;
                }
            }
            return View(rdv);
        }

        // POST: Rdv/Edit/5
        [HttpPost]
        public ActionResult Edit(RdvViewModel rdv)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18080/");
                var putTask = client.PutAsJsonAsync("PI_J2ee-web/rest/RDV/UpdateRdv", rdv);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }

        // GET: Rdv/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rdv/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
