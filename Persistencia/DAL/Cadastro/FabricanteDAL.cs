using Model.Cadastro;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Cadastro
{
    public class FabricanteDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Fabricante> ObterFabricanteClassificadosPorNome()
        {
            return context.Fabricantes.OrderBy(x => x.Nome);
        }

        public Fabricante ObterFabricantePorId(long? id)
        {
            var fabricante = context.Fabricantes.Where(x => x.FabricanteId == id)
                                                 .Include("Produtos.Categoria").FirstOrDefault();
            return fabricante;
        }

        public void GravarFabricante(Fabricante fabricante)
        {
            if (fabricante.FabricanteId.Equals(0) || fabricante.FabricanteId == null)
            {
                context.Fabricantes.Add(fabricante);
            }
            else
            {
                context.Entry(fabricante).State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Fabricante EliminarFabricantePorId(long id)
        {
            var fabricante = ObterFabricantePorId(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            return fabricante;
        }

    }
}
