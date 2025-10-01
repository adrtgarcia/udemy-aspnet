﻿using Microsoft.EntityFrameworkCore;
using SistemaVendas.Dominio.Entities;

namespace SistemaVendas.Repositorio.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<VendaProduto> VendaProduto { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<VendaProduto>().HasKey(x => new { x.CodigoVenda, x.CodigoProduto });
            builder.Entity<VendaProduto>().HasOne(x => x.Venda).WithMany(y => y.Produtos).HasForeignKey(x => x.CodigoVenda);
            builder.Entity<VendaProduto>().HasOne(x => x.Produto).WithMany(y => y.Vendas).HasForeignKey(x => x.CodigoProduto);
        }
    }
}
