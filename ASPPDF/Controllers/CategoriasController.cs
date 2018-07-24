//using ASPPDF.Context;
using Model.Tabelas;
using Servico.Tabela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ASPPDF.Controllers
{
    public class CategoriasController : Controller
    {

        private CategoriaServico categoriaServico = new CategoriaServico();

        public ActionResult Index()
        {
            return View(categoriaServico.ObterCategoriaClassificadosPorNome());
        }

        public ActionResult Details(long id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        public ActionResult Edit(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                var categoria = categoriaServico.EliminarCategoriaPorId(id);
                TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi Removido";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("index");
                }
                return View(categoria);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private ActionResult ObterVisaoCategoriaPorId(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var categoria = categoriaServico.ObterCategoriaPorId((long)id);
            if (categoria == null)
                return HttpNotFound();
            return View(categoria);
        }

    }
}
        
        // GET: Categorias

//        private static IList<Categoria> categorias = new List<Categoria>
//        {
//            new Categoria()
//            {
//                CategoriaId = 1,
//                Nome = "Notebooks"
//            },
//            new Categoria()
//            {
//                CategoriaId = 2,
//                Nome = "Monitores"
//            },
//            new Categoria()
//            {
//                CategoriaId = 3,
//                Nome = "Impressoras"
//            },
//            new Categoria()
//            {
//                CategoriaId = 4,
//                Nome = "Mouses"
//            },
//            new Categoria()
//            {
//                CategoriaId = 5,
//                Nome = "Desktops"
//            }
//        };
//        //acesso ao banco de dados com entity framework
//        //private EFContext context = new EFContext();

//        //public ActionResult Index()
//        //{
//            //var categoria = context.Categorias.OrderBy(x => x.Nome);
//            //return View(categorias);
//            //return View(categoria);
//        //}

//        public ActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(Categoria categoria)
//        {
//            //categorias.Add(categoria);
//            //categoria.CategoriaId = categorias.Select(x => x.CategoriaId).Max() + 1;
//            //return RedirectToAction("index");
//            //if (ModelState.IsValid)
//            //{
//                //context.Categorias.Add(categoria);
//                //context.SaveChanges();
//                return RedirectToAction("index");
//            //}
//            //return View(categoria);
//        }

//        public ActionResult Edit(long? id)
//        {
//            if (id == null)
//                return HttpNotFound();
//            //var categoria = categorias.Where(x => x.CategoriaId == id).FirstOrDefault();
//            //var categoria1 = context.Categorias.Find(id);
//            //if (categoria1 == null)
//                return HttpNotFound();
//            //return View(categoria1);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(Categoria categoria)
//        {
//            //categorias.Remove(categorias.Where(x => x.CategoriaId == categoria.CategoriaId).FirstOrDefault());
//            //categorias.Add(categoria);
//            //return RedirectToAction("index");
//            if (ModelState.IsValid)
//            {
//                //context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
//                //context.SaveChanges();
//                return RedirectToAction("index");
//            }
//            return View(categoria);
//        }

//        //public ActionResult Details(long id)
//        //{
//            //return View(categorias.Where(x => x.CategoriaId == id).FirstOrDefault());
//            //-//return View(context.Categorias.Where(x => x.CategoriaId == id).FirstOrDefault());
//        //}

//        //public ActionResult Delete(long? id)
//        //{
//            //return View(categorias.Where(x => x.CategoriaId == id).FirstOrDefault());
//            //if (id == null)
//                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            //var categoria = context.Categorias.Find(id);
//            //return View(categoria);
//        //}

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(Categoria categoria)
//        {
//            //categorias.Remove(categorias.Where(x => x.CategoriaId == categoria.CategoriaId).FirstOrDefault());
//            //context.Entry(categoria).State = System.Data.Entity.EntityState.Deleted;
//            //context.SaveChanges();
//            return RedirectToAction("index");
//        }
//    }
//}