using Model.Cadastro;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Persistencia.DAL.Cadastro
{

    public class ProdutoDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Produto> ObterProdutoClassificadosPorNome()
        {
            return context.Produtos.Include(c => c.Categoria)
                                   .Include(f => f.Fabricante)
                                   .OrderBy(x => x.Nome);
        }

        public Produto ObterProdutoPorId(long? id)
        {
            return context.Produtos.Where(x => x.ProdutoId == id)
                                   .Include(c => c.Categoria)
                                   .Include(f => f.Fabricante)
                                   .First();
        }

        public void GravarProduto(Produto produto)
        {
            if(produto.ProdutoId == null)
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
            else
            {
                context.Entry(produto).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Produto EliminarProdutoPorId(long id)
        {
            var produto = ObterProdutoPorId(id);
            context.Produtos.Remove(produto);
            context.SaveChanges();
            return produto;

        }

    }
}
