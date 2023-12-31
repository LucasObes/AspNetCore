﻿using LojaRepositorios.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace LojaRepositorios.DataBase
{
    public class LojaContexto : DbContext
    {
        public LojaContexto()
        {
            
        }
        public LojaContexto(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMapeamento());
            modelBuilder.ApplyConfiguration(new ClienteMapeamento());
        }
    }
}
