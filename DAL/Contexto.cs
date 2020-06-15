using Microsoft.EntityFrameworkCore;
using Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parcial1.DAL
{
    class Contexto : DbContext 
    {
        public DbSet<Articulos> Articulos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlite(@"Data Source = Data\Articulos.db");
   
        }
    }
}
