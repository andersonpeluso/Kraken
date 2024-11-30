using Kraken.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kraken.Infrastructure.Persistence
{
    public class KrakenDbContext : DbContext
    {
        public KrakenDbContext(DbContextOptions<KrakenDbContext> options) : base(options)
        {
        }

        public DbSet<ProdutoDto> Produtos { get; set; }

        public DbSet<OrdemItemDto> OrdemItens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configuração da entidade Produto
            builder
                .Entity<ProdutoDto>(entity =>
                {
                    entity.ToTable("Produto"); // Define o nome da tabela

                    entity.HasKey(p => p.Id); // Define a chave primária

                    entity.Property(p => p.Id)
                          .IsRequired()
                          .ValueGeneratedOnAdd(); // Indica que o ID será gerado automaticamente

                    entity.Property(p => p.Nome)
                          .IsRequired()
                          .HasMaxLength(255); // Limite de caracteres para Nome

                    entity.Property(p => p.Categoria)
                          .IsRequired()
                          .HasMaxLength(255); // Limite de caracteres para Categoria

                    entity.Property(p => p.Preco)
                          .IsRequired()
                          .HasColumnType("decimal(18,2)"); // Configuração do tipo decimal
                });

            // Configuração da entidade OrdemItem
            builder
                .Entity<OrdemItemDto>(entity =>
                {
                    entity.ToTable("OrdemItem"); // Define o nome da tabela

                    entity.HasKey(o => o.Id); // Define a chave primária

                    entity.Property(o => o.Id)
                          .IsRequired()
                          .ValueGeneratedOnAdd(); // Indica que o ID será gerado automaticamente

                    entity.Property(o => o.Quantidade)
                          .IsRequired(); // Define que Quantidade é obrigatório

                    entity.HasOne(o => o.Produto) // Configura o relacionamento com Produto
                          .WithMany()
                          .HasForeignKey(o => o.IdProduto) // Chave estrangeira
                          .OnDelete(DeleteBehavior.Restrict); // Impede exclusão em cascata de Produto
                });

            base.OnModelCreating(builder); // Chama a configuração base
        }
    }
}