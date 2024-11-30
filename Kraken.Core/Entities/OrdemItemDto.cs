namespace Kraken.Core.Entities
{
    public sealed class OrdemItemDto : BaseEntity
    {
        public Guid IdProduto { get; set; }

        public int Quantidade { get; set; }

        public ProdutoDto Produto { get; set; }
    }
}