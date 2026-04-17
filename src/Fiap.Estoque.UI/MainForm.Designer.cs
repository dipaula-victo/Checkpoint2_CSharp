namespace Fiap.Estoque.UI;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitulo;
    private Label lblNome;
    private Label lblPreco;
    private Label lblQuantidade;
    private Label lblBusca;
    private TextBox txtNome;
    private TextBox txtPreco;
    private TextBox txtQuantidade;
    private TextBox txtBusca;
    private Button btnSalvar;
    private Button btnBuscar;
    private Button btnRecarregar;
    private Button btnLimpar;
    private DataGridView dgvProdutos;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();
        lblNome = new Label();
        lblPreco = new Label();
        lblQuantidade = new Label();
        lblBusca = new Label();
        txtNome = new TextBox();
        txtPreco = new TextBox();
        txtQuantidade = new TextBox();
        txtBusca = new TextBox();
        btnSalvar = new Button();
        btnBuscar = new Button();
        btnRecarregar = new Button();
        btnLimpar = new Button();
        dgvProdutos = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitulo.Location = new Point(24, 18);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(411, 30);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "FIAP - Controle de Estoque em Camadas";
        // 
        // lblNome
        // 
        lblNome.AutoSize = true;
        lblNome.Location = new Point(24, 74);
        lblNome.Name = "lblNome";
        lblNome.Size = new Size(43, 15);
        lblNome.TabIndex = 1;
        lblNome.Text = "Nome:";
        // 
        // txtNome
        // 
        txtNome.Location = new Point(24, 92);
        txtNome.Name = "txtNome";
        txtNome.Size = new Size(260, 23);
        txtNome.TabIndex = 2;
        // 
        // lblPreco
        // 
        lblPreco.AutoSize = true;
        lblPreco.Location = new Point(304, 74);
        lblPreco.Name = "lblPreco";
        lblPreco.Size = new Size(40, 15);
        lblPreco.TabIndex = 3;
        lblPreco.Text = "Preço:";
        // 
        // txtPreco
        // 
        txtPreco.Location = new Point(304, 92);
        txtPreco.Name = "txtPreco";
        txtPreco.Size = new Size(120, 23);
        txtPreco.TabIndex = 4;
        // 
        // lblQuantidade
        // 
        lblQuantidade.AutoSize = true;
        lblQuantidade.Location = new Point(444, 74);
        lblQuantidade.Name = "lblQuantidade";
        lblQuantidade.Size = new Size(72, 15);
        lblQuantidade.TabIndex = 5;
        lblQuantidade.Text = "Quantidade:";
        // 
        // txtQuantidade
        // 
        txtQuantidade.Location = new Point(444, 92);
        txtQuantidade.Name = "txtQuantidade";
        txtQuantidade.Size = new Size(120, 23);
        txtQuantidade.TabIndex = 6;
        // 
        // btnSalvar
        // 
        btnSalvar.Location = new Point(584, 91);
        btnSalvar.Name = "btnSalvar";
        btnSalvar.Size = new Size(120, 25);
        btnSalvar.TabIndex = 7;
        btnSalvar.Text = "Salvar";
        btnSalvar.UseVisualStyleBackColor = true;
        btnSalvar.Click += btnSalvar_Click;
        // 
        // btnLimpar
        // 
        btnLimpar.Location = new Point(720, 91);
        btnLimpar.Name = "btnLimpar";
        btnLimpar.Size = new Size(120, 25);
        btnLimpar.TabIndex = 8;
        btnLimpar.Text = "Limpar";
        btnLimpar.UseVisualStyleBackColor = true;
        btnLimpar.Click += btnLimpar_Click;
        // 
        // lblBusca
        // 
        lblBusca.AutoSize = true;
        lblBusca.Location = new Point(24, 142);
        lblBusca.Name = "lblBusca";
        lblBusca.Size = new Size(131, 15);
        lblBusca.TabIndex = 9;
        lblBusca.Text = "Buscar produto por nome:";
        // 
        // txtBusca
        // 
        txtBusca.Location = new Point(24, 160);
        txtBusca.Name = "txtBusca";
        txtBusca.Size = new Size(400, 23);
        txtBusca.TabIndex = 10;
        // 
        // btnBuscar
        // 
        btnBuscar.Location = new Point(444, 159);
        btnBuscar.Name = "btnBuscar";
        btnBuscar.Size = new Size(120, 25);
        btnBuscar.TabIndex = 11;
        btnBuscar.Text = "Buscar";
        btnBuscar.UseVisualStyleBackColor = true;
        btnBuscar.Click += btnBuscar_Click;
        // 
        // btnRecarregar
        // 
        btnRecarregar.Location = new Point(584, 159);
        btnRecarregar.Name = "btnRecarregar";
        btnRecarregar.Size = new Size(120, 25);
        btnRecarregar.TabIndex = 12;
        btnRecarregar.Text = "Recarregar";
        btnRecarregar.UseVisualStyleBackColor = true;
        btnRecarregar.Click += btnRecarregar_Click;
        // 
        // dgvProdutos
        // 
        dgvProdutos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvProdutos.Location = new Point(24, 207);
        dgvProdutos.Name = "dgvProdutos";
        dgvProdutos.Size = new Size(816, 295);
        dgvProdutos.TabIndex = 13;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(870, 530);
        Controls.Add(dgvProdutos);
        Controls.Add(btnRecarregar);
        Controls.Add(btnBuscar);
        Controls.Add(txtBusca);
        Controls.Add(lblBusca);
        Controls.Add(btnLimpar);
        Controls.Add(btnSalvar);
        Controls.Add(txtQuantidade);
        Controls.Add(lblQuantidade);
        Controls.Add(txtPreco);
        Controls.Add(lblPreco);
        Controls.Add(txtNome);
        Controls.Add(lblNome);
        Controls.Add(lblTitulo);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FIAP - C# Software Development";
        Load += MainForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
