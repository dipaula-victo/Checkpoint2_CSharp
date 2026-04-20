using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Fiap.Estoque.Contracts;
using Fiap.Estoque.Model;

namespace Fiap.Estoque.UI;

public partial class MainForm : Form
{
    private readonly IProdutoService _produtoService;

    // --- PALETA DE CORES ---
    private readonly Color RosaFiap = ColorTranslator.FromHtml("#FF007F");
    private readonly Color CinzaEscuro = Color.FromArgb(43, 43, 43);
    private readonly Color PretoFundo = Color.FromArgb(26, 26, 26);
    private readonly Color OffWhite = Color.FromArgb(245, 245, 245);

    public MainForm(IProdutoService produtoService)
    {
        _produtoService = produtoService;
        InitializeComponent();

        AplicarDesignDashboard();
        CarregarGrid();
    }

    #region DESIGN MODERNIZADO

    private void AplicarDesignDashboard()
    {
        this.BackColor = CinzaEscuro;
        this.ForeColor = OffWhite;
        this.Font = new Font("Segoe UI Semibold", 10F);
        this.Text = "FIAP - Estoque";
        this.StartPosition = FormStartPosition.CenterScreen;

        EstilizarHierarquia(this);

        if (Controls.Find("lblTitulo", true).FirstOrDefault() is Label lbl)
        {
            lbl.Font = new Font("Segoe UI Bold", 18F, FontStyle.Bold);
            lbl.ForeColor = RosaFiap;
        }

        ConfigurarGridDashboard();
    }

    private void EstilizarHierarquia(Control pai)
    {
        foreach (Control c in pai.Controls)
        {
            if (c is Panel)
            {
                c.BackColor = PretoFundo;
                EstilizarHierarquia(c);
            }

            EstilizarControleIndividual(c);
        }
    }

    private void EstilizarControleIndividual(Control c)
    {
        if (c is TextBox txt)
        {
            txt.BackColor = Color.FromArgb(35, 35, 35);
            txt.ForeColor = OffWhite;
            txt.BorderStyle = BorderStyle.FixedSingle;
        }

        if (c is Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI Bold", 9.5F);

            if (btn.Name.Contains("Salvar") || btn.Name.Contains("Buscar"))
            {
                btn.BackColor = RosaFiap;
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.FromArgb(60, 60, 60);
                btn.ForeColor = OffWhite;
            }
        }

        if (c is Label lbl && lbl.Name != "lblTitulo")
        {
            lbl.ForeColor = Color.DarkGray;
            lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }
    }

    private void ConfigurarGridDashboard()
    {
        dgvProdutos.BackgroundColor = PretoFundo;
        dgvProdutos.BorderStyle = BorderStyle.None;
        dgvProdutos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgvProdutos.RowHeadersVisible = false;
        dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProdutos.AllowUserToAddRows = false;
        dgvProdutos.EnableHeadersVisualStyles = false;

        dgvProdutos.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
        dgvProdutos.ColumnHeadersDefaultCellStyle.ForeColor = RosaFiap;
        dgvProdutos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Bold", 10.5F);
        dgvProdutos.ColumnHeadersHeight = 35;

        dgvProdutos.DefaultCellStyle.BackColor = PretoFundo;
        dgvProdutos.DefaultCellStyle.ForeColor = OffWhite;
        dgvProdutos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70);
        dgvProdutos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(32, 32, 32);
    }

    #endregion

    #region LÓGICA DE OPERAÇÕES (CRUD)

    private void CarregarGrid()
    {
        try
        {
            var lista = _produtoService.Listar();
            dgvProdutos.DataSource = lista.OrderByDescending(p => p.Id).ToList();
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        catch (Exception ex)
        {
            ExibirErro("Erro ao listar produtos: " + ex.Message);
        }
    }

    private void btnSalvar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtPreco.Text))
        {
            MessageBox.Show("Preencha Nome e Preço.");
            return;
        }

        try
        {
            var prod = new Produto
            {
                Nome = txtNome.Text,
                Preco = decimal.Parse(txtPreco.Text),
                Quantidade = int.TryParse(txtQuantidade.Text, out int qtd) ? qtd : 0,
                Ativo = true
            };

            _produtoService.Cadastrar(prod);
            LimparCampos();
            CarregarGrid();
        }
        catch (Exception ex)
        {
            ExibirErro("Erro ao salvar: " + ex.Message);
        }
    }

    private void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            var termo = txtBusca.Text;
            var resultado = _produtoService.BuscarPorNome(termo);
            dgvProdutos.DataSource = resultado.ToList();
        }
        catch (Exception ex)
        {
            ExibirErro("Erro na busca: " + ex.Message);
        }
    }

    private void btnRemover_Click(object sender, EventArgs e)
    {
        if (dgvProdutos.SelectedRows.Count == 0) return;

        var id = (int)dgvProdutos.SelectedRows[0].Cells["Id"].Value;
        var nome = dgvProdutos.SelectedRows[0].Cells["Nome"].Value.ToString();

        if (MessageBox.Show($"Deseja excluir {nome}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            try
            {
                _produtoService.Remover(id);
                CarregarGrid();
            }
            catch (Exception ex)
            {
                ExibirErro("Erro ao excluir: " + ex.Message);
            }
        }
    }

    private void btnLimpar_Click(object sender, EventArgs e) => LimparCampos();

    private void btnRecarregar_Click(object sender, EventArgs e) => CarregarGrid();

    private void LimparCampos()
    {
        txtNome.Clear();
        txtPreco.Clear();
        txtQuantidade.Clear();
        txtNome.Focus();
    }

    private void ExibirErro(string msg) => MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

    #endregion
}