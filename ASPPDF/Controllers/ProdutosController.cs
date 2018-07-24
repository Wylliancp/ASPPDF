//using ASPPDF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Model.Cadastro;
using Servico.Cadastro;
using Servico.Tabela;

namespace ASPPDF.Controllers
{
    public class ProdutosController : Controller
    {
        //private EFContext context = new EFContext();
        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();
        
        // GET: Produtos
        public ActionResult Index()
        {
            //var produtos = context.Produtos.Include(c => c.Categoria)
            //                               .Include(f => f.Fabricante)
            //                               .OrderBy(p => p.Nome);
            //return View(produtos);
            return View(produtoServico.ObterProdutoClassificadoPorNome());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(long? id)
        {
            //if(id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //var produto = context.Produtos.Where(x => x.ProdutoId == id)
            //                              .Include(c => c.Categoria)
            //                              .Include(f => f.Fabricante).
            //                              OrderBy(p => p.Nome).FirstOrDefault();
            //if(produto == null)
            //{
            //    return HttpNotFound();
            //}

            //return View(produto);
            return ObterVisaoProdutoPorId(id);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            //ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(c => c.Nome), "CategoriaId", "Nome");
            //ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(f => f.Nome), "FabricanteId", "Nome");
            //return View();
            PopularViewBag();
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        context.Produtos.Add(produto);
            //        context.SaveChanges();
            //        return RedirectToAction("Index");
            //    }
            //    return View(produto);
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
            return GravarProduto(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(long? id)
        {
            //if (id == null)
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //var produto = context.Produtos.Find(id);//retorno ruim//Where(p => p.ProdutoId == id);

            //if (produto == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(c => c.Nome), "CategoriaId", "Nome");
            //ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(f => f.Nome), "FabricanteId", "Nome");
            //return View(produto);
            PopularViewBag(produtoServico.ObterProdutoPorId((long)id));
            return ObterVisaoProdutoPorId(id);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        if(produto != null)
            //        {
            //            context.Entry(produto).State = System.Data.Entity.EntityState.Modified;
            //            context.SaveChanges();
            //            return RedirectToAction("Index");
            //        }
            //    }

            //    return View(produto);
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
            return GravarProduto(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(long? id)
        {
            //if (id == null)
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //var produto = context.Produtos.Where(p => p.ProdutoId == id)
            //                              .Include(c => c.Categoria)
            //                              .Include(f => f.Fabricante).First();

            //if(produto == null)
            //{
            //    return HttpNotFound();
            //}

            //return View(produto);
            return ObterVisaoProdutoPorId(id);
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                //var produto = context.Produtos.Find(id);
                //context.Produtos.Remove(produto);
                //context.SaveChanges();
                var produto = produtoServico.EliminarProdutoPorId(id);
                TempData["Message"] = "Produto " + produto.Nome.ToUpper() + " Foi Removido!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private ActionResult ObterVisaoProdutoPorId(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produto = produtoServico.ObterProdutoPorId((long) id);

            if (produto == null)
                return HttpNotFound();
            return View(produto);
        }

        private void PopularViewBag(Produto produto = null)
        {
            if(produto == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriaClassificadosPorNome(), "CategoriaId", "Nome");
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricanteClassificadosPorNome(), "FabricanteId", "Nome");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriaClassificadosPorNome(), "CategoriaId", "Nome", produto.CategoriaId);
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricanteClassificadosPorNome(), "FabricanteId", "Nome", produto.FabricanteId);
            }
        }

        private ActionResult GravarProduto(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produtoServico.GravarProduto(produto);
                    return RedirectToAction("index");
                }
                return View(produto);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
