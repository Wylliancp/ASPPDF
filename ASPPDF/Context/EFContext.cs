using ASPPDF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPPDF.Context
{
    public class EFContext : DbContext
    {

        public EFContext(): base("Connection")
        {
            //Database.SetInitializer<EFContext>( new DropCreateDatabaseIfModelChanges<EFContext>());
            //caso este codigo estiver, burlamos a parte de precisarmos criar as migrations,
            // mas com isso perdemos todos os registros das tabelas, porque esse codígo ira excluir as tabelas juntos com seus registro
            // e recrialas.
        }

        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}