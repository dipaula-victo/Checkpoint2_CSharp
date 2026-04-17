using Fiap.Estoque.Model;

namespace Fiap.Estoque.Contracts;

public interface IProdutoRepository
{
    void Inserir(Produto produto);
    List<Produto> Listar();
    List<Produto> BuscarPorNome(string nome);
    void AtualizarEstoque(int id, int quantidade, char tipo);
}
