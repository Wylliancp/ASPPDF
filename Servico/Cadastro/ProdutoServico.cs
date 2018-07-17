using Model.Cadastro;
using Persistencia.DAL.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastro
{
    public class ProdutoServico
    {
        private ProdutoDAL produtoDAL = new ProdutoDAL();

        public IQueryable<Produto> ObterProdutoClassificadoPorNome()
        {
            return produtoDAL.ObterProdutoClassificadosPorNome();
        }

        public Produto ObterProdutoPorId(long id)
        {
            return produtoDAL.ObterProdutoPorId(id);
        }

        public void GravarProduto(Produto produto)
        {
            produtoDAL.GravarProduto(produto);
        }

        public Produto EliminarProdutoPorId(long id)
        {
            return produtoDAL.EliminarProdutoPorId(id);
        }
    }
}
