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

        try
        {
            // Connection String centralizada
            IConnectionStringProvider connectionStringProvider = new AppConfigConnectionStringProvider();

            // DAL
            IProdutoRepository produtoRepository = new ProdutoRepositoryADO(connectionStringProvider);

            // BLL
            IProdutoService produtoService = new ProdutoService(produtoRepository);

            // UI
            Application.Run(new MainForm(produtoService));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Erro ao iniciar o sistema: " + ex.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}