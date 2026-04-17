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
        var produtos = new List<Produto>();

        using var connection = new SqlConnection(_connectionStringProvider.GetConnectionString());
        using var command = new SqlCommand("dbo.sp_Produto_Listar", connection);

        command.CommandType = System.Data.CommandType.StoredProcedure;

        connection.Open();

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            produtos.Add(MapearProduto(reader));
        }

        return produtos;
    }

    public List<Produto> BuscarPorNome(string nome)
    {
        var produtos = new List<Produto>();

        using var connection = new SqlConnection(_connectionStringProvider.GetConnectionString());
        using var command = new SqlCommand("dbo.sp_Produto_BuscarPorNome", connection);

        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Nome", nome);

        connection.Open();

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            produtos.Add(MapearProduto(reader));
        }

        return produtos;
    }

    public void AtualizarEstoque(int id, int quantidade, char tipo)
    {
        using var connection = new SqlConnection(_connectionStringProvider.GetConnectionString());
        using var command = new SqlCommand("dbo.sp_Produto_AtualizarEstoque", connection);

        command.CommandType = System.Data.CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@Id", id);
        command.Parameters.AddWithValue("@Quantidade", quantidade);
        command.Parameters.AddWithValue("@Tipo", tipo);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public void Remover(int id)
    {
        using var connection = new SqlConnection(_connectionStringProvider.GetConnectionString());
        using var command = new SqlCommand("dbo.sp_Produto_Remover", connection);

        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Id", id);

        connection.Open();
        command.ExecuteNonQuery();
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