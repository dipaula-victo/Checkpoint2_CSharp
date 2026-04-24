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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
        btnRemover = new Button();
        pictureBox1 = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitulo.Location = new Point(197, 19);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(367, 30);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = " Controle de Estoque em Camadas";
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
        // lblPreco
        // 
        lblPreco.AutoSize = true;
        lblPreco.Location = new Point(304, 74);
        lblPreco.Name = "lblPreco";
        lblPreco.Size = new Size(40, 15);
        lblPreco.TabIndex = 3;
        lblPreco.Text = "Preço:";
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
        // lblBusca
        // 
        lblBusca.AutoSize = true;
        lblBusca.Location = new Point(24, 142);
        lblBusca.Name = "lblBusca";
        lblBusca.Size = new Size(146, 15);
        lblBusca.TabIndex = 9;
        lblBusca.Text = "Buscar produto por nome:";
        // 
        // txtNome
        // 
        txtNome.Location = new Point(24, 92);
        txtNome.Name = "txtNome";
        txtNome.Size = new Size(260, 23);
        txtNome.TabIndex = 2;
        // 
        // txtPreco
        // 
        txtPreco.Location = new Point(304, 92);
        txtPreco.Name = "txtPreco";
        txtPreco.Size = new Size(120, 23);
        txtPreco.TabIndex = 4;
        // 
        // txtQuantidade
        // 
        txtQuantidade.Location = new Point(444, 92);
        txtQuantidade.Name = "txtQuantidade";
        txtQuantidade.Size = new Size(120, 23);
        txtQuantidade.TabIndex = 6;
        // 
        // txtBusca
        // 
        txtBusca.Location = new Point(24, 160);
        txtBusca.Name = "txtBusca";
        txtBusca.Size = new Size(400, 23);
        txtBusca.TabIndex = 10;
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
        // dgvProdutos
        // 
        dgvProdutos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvProdutos.Location = new Point(24, 210);
        dgvProdutos.Name = "dgvProdutos";
        dgvProdutos.Size = new Size(978, 328);
        dgvProdutos.TabIndex = 13;
        // 
        // btnRemover
        // 
        btnRemover.Location = new Point(720, 159);
        btnRemover.Name = "btnRemover";
        btnRemover.Size = new Size(120, 25);
        btnRemover.TabIndex = 14;
        btnRemover.Text = "Remover";
        btnRemover.UseVisualStyleBackColor = true;
        btnRemover.Click += btnRemover_Click;
        // 
        // pictureBox1
        // 
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(47, 0);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(144, 71);
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 15;
        pictureBox1.TabStop = false;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1032, 563);
        Controls.Add(pictureBox1);
        Controls.Add(btnRemover);
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
        ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Button btnRemover;
    private PictureBox pictureBox1;
}
