namespace Fiap.Estoque.Model;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
    public bool Ativo { get; set; } = true;

    // Campo útil para exibir no grid vindo da view.
    public string? StatusEstoque { get; set; }

    public DateTime DataCadastro { get; set; }
}
