using Fiap.Estoque.BLL;
using Fiap.Estoque.Config;
using Fiap.Estoque.Contracts;
using Fiap.Estoque.DAL;

namespace Fiap.Estoque.UI;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        IConnectionStringProvider connectionStringProvider = new AppConfigConnectionStringProvider();
        IProdutoRepository produtoRepository = new ProdutoRepositoryADO(connectionStringProvider);
        IProdutoService produtoService = new ProdutoService(produtoRepository);

        Application.Run(new MainForm(produtoService));
    }
}
