using Model.Tabelas;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Tabelas
{
    public class CategoriaDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Categoria> ObterCategoriaClassificadasPorNome()
        {
            return context.Categorias.OrderBy(x => x.Nome);
        }

        public Categoria ObterCategoriaPorId(long? id)
        {
            return context.Categorias.Find(id);
        }

        public void GravarCategoria(Categoria categoria)
        {
            //if(categoria.CategoriaId == null)
            if(categoria.CategoriaId.Equals(0) || categoria.CategoriaId == null)
            {
                context.Categorias.Add(categoria);
            }
            else
            {
                context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Categoria EliminarCategoriaPorId(long id)
        {
            var categoria = ObterCategoriaPorId(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return categoria;
        }
    }
}
