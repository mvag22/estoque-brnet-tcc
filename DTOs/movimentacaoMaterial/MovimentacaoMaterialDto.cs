namespace ApiBrnetEstoque.DTOs.movimentacaoMaterial
{
    public class MovimentacaoMaterialDto
    {
        public int IdMovMaterial { get; set; }
        public int MovimentacaoEstoqueId { get; set; }
        public int MaterialEstoqueId { get; set; }
        public int Quantidade { get; set; }
    }
}
