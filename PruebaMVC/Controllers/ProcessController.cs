using PruebaMVC.filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaMVC.Controllers
{
    public class ProcessController : Controller
    {
        // GET: Process
        public ActionResult Index()
        {
            return View();
        }

        [Log]
        public ViewResult List(string name)
        {
            if(name == null)
            {
                ViewBag.List = Process.GetProcesses();

                return View();
            }

            var lista = new List<Process>();
            foreach(var p in Process.GetProcesses())
            {
                if (p.ProcessName.Contains(name))
                {
                    lista.Add(p);
                }
            }
            ViewBag.List = lista;

            return View();
        }

        // GET: Process/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Process/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Process/Create
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

        // GET: Process/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Process/Edit/5
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

        // GET: Process/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Process/Delete/5
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
