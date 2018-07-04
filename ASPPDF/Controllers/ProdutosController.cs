using ASPPDF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ASPPDF.Models;

namespace ASPPDF.Controllers
{
    public class ProdutosController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = context.Produtos.Include(c => c.Categoria)
                                           .Include(f => f.Fabricante)
                                           .OrderBy(p => p.Nome);
            return View(produtos);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produto = context.Produtos.Where(x => x.ProdutoId == id)
                                          .Include(c => c.Categoria)
                                          .Include(f => f.Fabricante).
                                          OrderBy(p => p.Nome).FirstOrDefault();
            if(produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(c => c.Nome), "CategoriaId", "Nome");
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(f => f.Nome), "FabricanteId", "Nome");
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Produtos.Add(produto);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var produto = context.Produtos.Find(id);//retorno ruim//Where(p => p.ProdutoId == id);

            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(c => c.Nome), "CategoriaId", "Nome");
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(f => f.Nome), "FabricanteId", "Nome");
            return View(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(produto != null)
                    {
                        context.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }

                return View(produto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var produto = context.Produtos.Where(p => p.ProdutoId == id)
                                          .Include(c => c.Categoria)
                                          .Include(f => f.Fabricante).First();

            if(produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                var produto = context.Produtos.Find(id);
                context.Produtos.Remove(produto);
                context.SaveChanges();
                TempData["Message"] = "Produto " + produto.Nome.ToUpper() + " Foi Removido!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
