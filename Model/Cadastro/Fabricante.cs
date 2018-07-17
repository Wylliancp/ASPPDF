using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cadastro
{
    public class Fabricante 
    {

        public long FabricanteId { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

    }
}
