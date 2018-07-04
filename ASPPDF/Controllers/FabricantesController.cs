using ASPPDF.Context;
using ASPPDF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace ASPPDF.Controllers
{
    public class FabricantesController : Controller
    {

        private EFContext context = new EFContext();
        // GET: Fabricantes
        public ActionResult Index()
        {
            var fabricantes = context.Fabricantes.OrderBy(x => x.Nome);
            return View(fabricantes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                context.Fabricantes.Add(fabricante);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabricante);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var fabricante = context.Fabricantes.Find(id);
            if (fabricante == null)
                return HttpNotFound();
            return View(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                context.Entry(fabricante).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(fabricante);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var fabricante =  context.Fabricantes.Where(x => x.FabricanteId == id)
                                                 .Include("Produtos.Categoria").FirstOrDefault();
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var fabricante = context.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Fabricante fabricante = context.Fabricantes.Find(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi remobido"; 
            return RedirectToAction("index");
        }



    }
}