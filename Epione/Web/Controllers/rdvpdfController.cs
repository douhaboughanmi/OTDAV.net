
using Domain;

using Service.Rdv;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class rdvpdfController : Controller
    {
        RdvService us = new RdvService();
       
        rendezvou rdv = new rendezvou();

        // GET: RiskHistory
        public ActionResult Index(string searching)
        {
            IEnumerable<rendezvou> all = us.GetAll();



            if (searching != null)

                all = us.GetMany(x => x.etat.Contains(searching));


            ViewBag.result = all;


            return View();

        }

        // GET: RiskHistory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RiskHistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RiskHistory/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RiskHistory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RiskHistory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RiskHistory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RiskHistory/Delete/5
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


        public ActionResult GenerateReport()
        {
            us.generatePDF();
            return View();
        }
    }
}