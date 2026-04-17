using Fiap.Estoque.Contracts;
using Fiap.Estoque.Model;
using Microsoft.Data.SqlClient;

namespace Fiap.Estoque.DAL;

public class ProdutoRepositoryADO : IProdutoRepository
{
    private readonly IConnectionStringProvider _connectionStringProvider;

    public ProdutoRepositoryADO(IConnectionStringProvider connectionStringProvider)
    {
        _connectionStringProvider = connectionStringProvider;
    }

    public void Inserir(Produto produto)
    {
        using var connection = new SqlConnection(_connectionStringProvider.GetConnectionString());
        using var command = new SqlCommand("dbo.sp_Produto_Inserir", connection);

        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Nome", produto.Nome);
        command.Parameters.AddWithValue("@Preco", produto.Preco);
        command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public List<Produto> Listar()
    {
        // TODO 01:
        // Implementar a listagem completa de produtos usando ADO.NET.
        // Requisitos esperados para os alunos:
        // 1) abrir SqlConnection com a connection string centralizada;
        // 2) criar SqlCommand apontando para dbo.sp_Produto_Listar;
        // 3) definir CommandType como StoredProcedure;
        // 4) executar ExecuteReader();
        // 5) percorrer os registros com while (reader.Read());
        // 6) mapear cada linha com o método MapearProduto(reader);
        // 7) retornar a lista preenchida.
        //
        // Dica do professor:
        // este método pode ser montado com a turma amanhã.

        var produtos = new List<Produto>();
        return produtos;
    }

    public List<Produto> BuscarPorNome(string nome)
    {
        // TODO 02:
        // Implementar a busca por nome usando a stored procedure
        // dbo.sp_Produto_BuscarPorNome.
        // Requisitos esperados para os alunos:
        // 1) criar conexão;
        // 2) criar SqlCommand da procedure;
        // 3) adicionar o parâmetro @Nome;
        // 4) abrir conexão;
        // 5) executar ExecuteReader();
        // 6) mapear resultados para List<Produto>.
        //
        // Observação:
        // caso não haja resultados, retornar lista vazia.

        var produtos = new List<Produto>();
        return produtos;
    }

    public void AtualizarEstoque(int id, int quantidade, char tipo)
    {
        // TODO 05 (continuação / lição de casa / próxima semana):
        // Implementar a atualização de estoque usando
        // dbo.sp_Produto_AtualizarEstoque.
        //
        // Passos esperados:
        // 1) receber id, quantidade e tipo;
        // 2) montar SqlCommand da procedure;
        // 3) adicionar parâmetros @Id, @Quantidade e @Tipo;
        // 4) executar ExecuteNonQuery().
        //
        // Este item foi deixado para evolução posterior propositalmente.

        throw new NotImplementedException("TODO 05: implementar AtualizarEstoque na próxima etapa.");
    }

    private static Produto MapearProduto(SqlDataReader reader)
    {
        return new Produto
        {
            Id = Convert.ToInt32(reader["Id"]),
            Nome = Convert.ToString(reader["Nome"]) ?? string.Empty,
            Preco = Convert.ToDecimal(reader["Preco"]),
            Quantidade = Convert.ToInt32(reader["Quantidade"]),
            Ativo = reader["Ativo"] != DBNull.Value && Convert.ToBoolean(reader["Ativo"]),
            StatusEstoque = reader["StatusEstoque"]?.ToString(),
            DataCadastro = Convert.ToDateTime(reader["DataCadastro"])
        };
    }
}
