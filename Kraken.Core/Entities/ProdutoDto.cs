namespace Kraken.Core.Entities
{
    public sealed class ProdutoDto : BaseEntity
    {
        public string Nome { get; set; }

        public string Categoria { get; set; }

        public decimal Preco { get; set; }
    }
}