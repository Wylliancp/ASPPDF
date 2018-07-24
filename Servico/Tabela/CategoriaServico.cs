using Model.Tabelas;
using Persistencia.DAL.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Tabela
{
    public class CategoriaServico
    {
        private CategoriaDAL categoriaDAL = new CategoriaDAL();

        public IQueryable<Categoria> ObterCategoriaClassificadosPorNome()
        {
            return categoriaDAL.ObterCategoriaClassificadasPorNome();
        }

        public Categoria ObterCategoriaPorId(long id)
        {
            return categoriaDAL.ObterCategoriaPorId(id);
        }

        public void GravarCategoria(Categoria categoria)
        {
            categoriaDAL.GravarCategoria(categoria);
        }

        public Categoria EliminarCategoriaPorId(long id)
        {
            return categoriaDAL.EliminarCategoriaPorId(id);
        }
    }
}
