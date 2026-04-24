using System.Configuration;
using Fiap.Estoque.Contracts;

namespace Fiap.Estoque.Config;

public class AppConfigConnectionStringProvider : IConnectionStringProvider
{
    public string GetConnectionString()
    {
        var connectionString = ConfigurationManager.ConnectionStrings["EstoqueDb"]?.ConnectionString;

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "A connection string 'EstoqueDb' não foi encontrada. " +
                "Verifique o arquivo App.config do projeto de UI.");
        }

        return connectionString;
    }
}
