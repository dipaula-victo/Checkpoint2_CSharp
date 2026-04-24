using Fiap.Estoque.Contracts;
using Fiap.Estoque.Model;

namespace Fiap.Estoque.BLL;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public void Cadastrar(Produto produto)
    {
        ValidarProduto(produto);
        _produtoRepository.Inserir(produto);
    }

    public List<Produto> Listar()
    {
        // integração com DAL
        return _produtoRepository.Listar();
    }

    public List<Produto> BuscarPorNome(string nome)
    {
        // regra de negócio
        if (string.IsNullOrWhiteSpace(nome))
        {
            return Listar();
        }

        return _produtoRepository.BuscarPorNome(nome);
    }

    public void AtualizarEstoque(int id, int quantidade, char tipo)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Informe um produto válido.");
        }

        if (quantidade <= 0)
        {
            throw new ArgumentException("A quantidade deve ser maior que zero.");
        }

        if (tipo != 'E' && tipo != 'S')
        {
            throw new ArgumentException("O tipo deve ser 'E' para entrada ou 'S' para saída.");
        }

        _produtoRepository.AtualizarEstoque(id, quantidade, tipo);
    }

    public void Remover(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Produto inválido.");
        }

        _produtoRepository.Remover(id);
    }

    private static void ValidarProduto(Produto produto)
    {
        if (produto is null)
        {
            throw new ArgumentNullException(nameof(produto));
        }

        // validações completas (diferencial)

        if (string.IsNullOrWhiteSpace(produto.Nome))
        {
            throw new ArgumentException("Informe o nome do produto.");
        }

        if (produto.Preco <= 0)
        {
            throw new ArgumentException("O preço deve ser maior que zero.");
        }

        if (produto.Quantidade < 0)
        {
            throw new ArgumentException("A quantidade não pode ser negativa.");
        }
    }
}