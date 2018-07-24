//using ASPPDF.Context;
using Model.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Servico.Cadastro;

namespace ASPPDF.Controllers
{
    public class FabricantesController : Controller
    {
        private FabricanteServico fabricanteServico = new FabricanteServico();

        public ActionResult Index()
        {
            return View(fabricanteServico.ObterFabricanteClassificadosPorNome());
        }

        public ActionResult Details(long id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        public ActionResult Edit(long id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                var fabricante = fabricanteServico.EliminarFabricantePorId(id);
                TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi Removido!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        private ActionResult GravarFabricante(Fabricante fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fabricanteServico.GravarFabricante(fabricante);
                    return RedirectToAction("index");
                }
                return View(fabricante);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private ActionResult ObterVisaoFabricantePorId(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var fabricante = fabricanteServico.ObterFabricantePorId((long)id);
            if (fabricante == null)
                return HttpNotFound();
            return View(fabricante);
        }
    }
}


//        private EFContext context = new EFContext();
//        // GET: Fabricantes
//        public ActionResult Index()
//        {
//            var fabricantes = context.Fabricantes.OrderBy(x => x.Nome);
//            return View(fabricantes);
//        }

//        public ActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(Fabricante fabricante)
//        {
//            if (ModelState.IsValid)
//            {
//                context.Fabricantes.Add(fabricante);
//                context.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(fabricante);
//        }

//        public ActionResult Edit(long? id)
//        {
//            if (id == null)
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            var fabricante = context.Fabricantes.Find(id);
//            if (fabricante == null)
//                return HttpNotFound();
//            return View(fabricante);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(Fabricante fabricante)
//        {
//            if (ModelState.IsValid)
//            {
//                context.Entry(fabricante).State = System.Data.Entity.EntityState.Modified;
//                context.SaveChanges();
//                return RedirectToAction("index");
//            }
//            return View(fabricante);
//        }

//        public ActionResult Details(long? id)
//        {
//            if (id == null)
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            var fabricante =  context.Fabricantes.Where(x => x.FabricanteId == id)
//                                                 .Include("Produtos.Categoria").FirstOrDefault();
//            if (fabricante == null)
//            {
//                return HttpNotFound();
//            }
//            return View(fabricante);
//        }

//        public ActionResult Delete(long? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            var fabricante = context.Fabricantes.Find(id);
//            if (fabricante == null)
//            {
//                return HttpNotFound();
//            }
//            return View(fabricante);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(long id)
//        {
//            Fabricante fabricante = context.Fabricantes.Find(id);
//            context.Fabricantes.Remove(fabricante);
//            context.SaveChanges();
//            TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi remobido"; 
//            return RedirectToAction("index");
//        }



//    }
//}