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
        // TODO 03-A:
        // Chamar o repositório e devolver a listagem completa.
        // Exemplo esperado: return _produtoRepository.Listar();
        //
        // Foi deixado como TODO para que a turma ligue a BLL à DAL.

        return new List<Produto>();
    }

    public List<Produto> BuscarPorNome(string nome)
    {
        // TODO 03-B:
        // Regras esperadas:
        // 1) se nome vier vazio ou só com espaços, retornar Listar();
        // 2) caso contrário, chamar _produtoRepository.BuscarPorNome(nome);
        //
        // Foi deixado como TODO para consolidar o papel da BLL.

        return new List<Produto>();
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

    private static void ValidarProduto(Produto produto)
    {
        if (produto is null)
        {
            throw new ArgumentNullException(nameof(produto));
        }

        // TODO 04:
        // Reforçar as validações abaixo com a turma.
        // Regras mínimas sugeridas:
        // - Nome obrigatório
        // - Preço maior que zero
        // - Quantidade não negativa
        //
        // A versão abaixo está intencionalmente simples para servir de exercício.

        if (string.IsNullOrWhiteSpace(produto.Nome))
        {
            throw new ArgumentException("Informe o nome do produto.");
        }
    }
}
