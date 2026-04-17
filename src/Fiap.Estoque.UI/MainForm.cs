using Fiap.Estoque.Contracts;
using Fiap.Estoque.Model;

namespace Fiap.Estoque.UI;

public partial class MainForm : Form
{
    private readonly IProdutoService _produtoService;

    public MainForm(IProdutoService produtoService)
    {
        _produtoService = produtoService;
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        // TODO 06-A:
        // Decidir com a turma se o grid deve carregar automaticamente ao abrir a tela.
        // Sugestão: chamar CarregarGrid();
    }

    private void btnSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            var produto = new Produto
            {
                Nome = txtNome.Text.Trim(),
                Preco = decimal.Parse(txtPreco.Text.Trim()),
                Quantidade = int.Parse(txtQuantidade.Text.Trim())
            };

            _produtoService.Cadastrar(produto);

            LimparCampos();

            // TODO 06-B:
            // Depois de salvar, recarregar o grid para o usuário ver o novo registro.
            // Sugestão: chamar CarregarGrid();

            MessageBox.Show(
                "Produto cadastrado com sucesso.",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            // TODO 06-C:
            // Implementar a busca por nome na interface.
            // Passos sugeridos:
            // 1) ler txtBusca.Text.Trim();
            // 2) chamar _produtoService.BuscarPorNome(termo);
            // 3) atribuir o resultado ao DataGridView.
            //
            // Exemplo esperado ao final:
            // var termo = txtBusca.Text.Trim();
            // dgvProdutos.DataSource = _produtoService.BuscarPorNome(termo);

            MessageBox.Show(
                "TODO 06-C: implementar o botão Buscar.",
                "Atividade",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Erro ao buscar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnRecarregar_Click(object sender, EventArgs e)
    {
        CarregarGrid();
    }

    private void btnLimpar_Click(object sender, EventArgs e)
    {
        LimparCampos();
    }

    private void CarregarGrid()
    {
        // TODO 06-D:
        // Implementar a recarga do grid chamando a BLL.
        // Passos sugeridos:
        // 1) dgvProdutos.AutoGenerateColumns = true;
        // 2) dgvProdutos.DataSource = null;
        // 3) dgvProdutos.DataSource = _produtoService.Listar();

        dgvProdutos.AutoGenerateColumns = true;
        dgvProdutos.DataSource = null;
    }

    private void LimparCampos()
    {
        txtNome.Clear();
        txtPreco.Clear();
        txtQuantidade.Clear();
        txtNome.Focus();
    }
}
