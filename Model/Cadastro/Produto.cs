using Model.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cadastro
{
    public class Produto
    {

        public long? ProdutoId { get; set; }

        public string Nome { get; set; }



        public long? CategoriaId { get; set; }

        public long? FabricanteId { get; set; }



        public Categoria Categoria { get; set; }

        public Fabricante Fabricante { get; set; }

    }
}
