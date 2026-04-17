using Fiap.Estoque.Model;

namespace Fiap.Estoque.Contracts;

public interface IProdutoService
{
    void Cadastrar(Produto produto);
    List<Produto> Listar();
    List<Produto> BuscarPorNome(string nome);
    void AtualizarEstoque(int id, int quantidade, char tipo);

    void Remover(int id);
}
