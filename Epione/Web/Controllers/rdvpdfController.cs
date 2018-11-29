
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
            ViewBag.result = all;

            if (searching != null)
            { 
              all = us.GetMany(x => x.etat.Equals(searching));

            }
            else
            {
        //   if (riskMin == null)
              all = us.GetAll();

            //else
            //{
                //int taux = Int32.Parse(riskMin);

              //  all = rs.GetMany(x => x.tauxRisk < taux);
            //}
            }

            return View(all);
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


        public ActionResult GenerateReport(int id)
        {
            us.generatePDF(id);
            return View();
        }
    }
}