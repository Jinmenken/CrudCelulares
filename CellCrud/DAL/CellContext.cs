using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CellCrud.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CellCrud.DAL
{
    public class CellContext : DbContext
    {
        public CellContext() : base("CellContext")
        {
        }
        
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<OS> OpSys { get; set; }
        public DbSet<Celular> Celulares { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}