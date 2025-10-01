using SistemaVendas.Dominio.Repositorio;
using SistemaVendas.Dominio.Entities;
using SistemaVendas.Repositorio.Context;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.Dominio.DTOs;

namespace SistemaVendas.Repositorio.Entities
{
    public class RepositorioVendaProduto : DbContext, IRepositorioVendaProduto
    {
        protected DbSet<VendaProduto> VendaProduto;

        public RepositorioVendaProduto (ApplicationDbContext context)
        {
            VendaProduto = context.VendaProduto;
        }

        public IEnumerable<GraficoDTO> ListaGrafico()
        {
            var vendas = VendaProduto.Include(vp => vp.Produto).ToList();
            var lista = vendas.GroupBy(vp => vp.CodigoProduto)
                              .Select(g => new GraficoDTO
                              {
                                  CodigoProduto = g.Key,
                                  Descricao = g.FirstOrDefault()?.Produto?.Descricao ?? $"Produto {g.Key}",
                                  TotalVendido = g.Sum(vp => vp.QuantidadeProduto)
                              })
                              .ToList();
            return lista;
        }
    }
}
