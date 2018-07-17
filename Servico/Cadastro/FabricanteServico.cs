using Model.Cadastro;
using Persistencia.DAL.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastro
{
    public class FabricanteServico
    {
        private FabricanteDAL fabricanteDAL = new FabricanteDAL();

        public IQueryable<Fabricante> ObterFabricanteClassificadosPorNome()
        {
            return fabricanteDAL.ObterFabricantesClassificadosPorNome();
        }
    }
}
