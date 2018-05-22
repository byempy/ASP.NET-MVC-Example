
using ConsultaDB.Entities;
using ConsultaDB.Interfaces;
using PruebaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace PruebaMVC.Controllers
{
    public class PersonController : Controller
    {
        IPersonBL bl;
        public PersonController()
        {
            bl = new PersonRepository();
        }        

        public ActionResult Index(string nombre, string apellido, int page = 1)
        {
            var person = new Person()
            {
                FirstName = nombre,
                LastName = apellido
            };

            var model = from p in bl.GetListaPersonas(person) orderby p.Id select p;
            var modelfinal = model.ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Persons", model);
            }
            return View(modelfinal);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            var person = bl.GetPersonaDetallada(id);
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            var model = new Person();
            return View(model);
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new Person();
                
            if (TryUpdateModel(model))
            {
               bl.AddPerson(model);
                return RedirectToAction("Index");
            }

            return View(model);
            
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            var person = bl.GetPersonaDetallada(id);
            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var person = bl.GetPersonaDetallada(id);
            if (TryUpdateModel(person))
            {
                bl.UpdatePerson(person);
                return RedirectToAction("Index");

            }
            return View(person);
            
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            var model = bl.GetPersonaDetallada(id);
            return View(model);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                bl.DelPerson(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            bl.Dispose();
        }
    }
}
