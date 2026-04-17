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
        // Carregar grid ao abrir
        CarregarGrid();
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

            // Atualizar grid após salvar
            CarregarGrid();

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
            string termo = txtBusca.Text.Trim();

            dgvProdutos.AutoGenerateColumns = true;
            dgvProdutos.DataSource = null;

            var lista = _produtoService.BuscarPorNome(termo) ?? new List<Produto>();

            // ordenação crescente por ID
            dgvProdutos.DataSource = lista
                .OrderBy(p => p.Id)
                .ToList();
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
        try
        {
            dgvProdutos.AutoGenerateColumns = true;
            dgvProdutos.DataSource = null;

            var lista = _produtoService.Listar() ?? new List<Produto>();

            // ordenação crescente por ID
            dgvProdutos.DataSource = lista
                .OrderBy(p => p.Id)
                .ToList();

            // Ajuste visual (diferencial)
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Erro ao carregar produtos: " + ex.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void LimparCampos()
    {
        txtNome.Clear();
        txtPreco.Clear();
        txtQuantidade.Clear();
        txtNome.Focus();
    }

    private void btnRemover_Click(object sender, EventArgs e)
    {
        try
        {
            if (dgvProdutos.CurrentRow == null)
            {
                MessageBox.Show("Selecione um produto.");
                return;
            }

            int id = Convert.ToInt32(dgvProdutos.CurrentRow.Cells["Id"].Value);

            var confirmacao = MessageBox.Show(
                "Tem certeza que deseja remover este produto?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacao == DialogResult.Yes)
            {
                _produtoService.Remover(id);

                CarregarGrid();

                MessageBox.Show("Produto removido com sucesso.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao remover: " + ex.Message);
        }
    }
}