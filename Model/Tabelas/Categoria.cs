using Model.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Tabelas
{
    public class Categoria
    {

        public long CategoriaId { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

    }
}
