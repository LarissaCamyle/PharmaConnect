using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TESTE_GUNA.projeto.dao;

using TESTE_GUNA.projeto.window;

namespace TESTE_GUNA.projeto.window
{
    public partial class AdmTelaProdutos : Form
    {
        private AdmTelaHome admHome;

        public AdmTelaProdutos(AdmTelaHome home)
        {
            InitializeComponent();
            this.admHome = home;
            this.DoubleBuffered = true;//parar de travar a tela

        }


        #region COLUNAS EDITAR E EXCLUIR NO DATA GRID
        private void AdicionandoColunaExcluir(DataGridView dataGridView)
        {
            // Adicionar coluna de botão para Ação
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            buttonColumn.Name = "Excluir";
            buttonColumn.HeaderText = "Excluir";
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.Width = 90;
            dataGridView.Columns.Add(buttonColumn);

            // Configurar eventos para desenhar o botão e lidar com o clique
            dataGridView.CellPainting += btnExcluirColuna;
        }

        // Desenhar o botão na célula
        private void btnExcluirColuna(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == DataGridViewProdutos.Columns["Excluir"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Guna2Button btn = new Guna2Button();


                btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
                btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
                btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
                btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
                btn.FillColor = System.Drawing.Color.White;
                btn.Font = new System.Drawing.Font("Segoe UI", 9F);
                btn.ForeColor = System.Drawing.Color.White;
                btn.Image = global::TESTE_GUNA.Properties.Resources.Produtos__7_;
                btn.ImageSize = new System.Drawing.Size(35, 35);
                btn.Location = new System.Drawing.Point(432, 12);
                btn.Name = "btnExcluir";
                btn.Size = new System.Drawing.Size(42, 38);
                btn.TabIndex = 4;


                // Renderizar o botão na célula
                Bitmap bmp = new Bitmap(btn.Width, btn.Height);
                btn.DrawToBitmap(bmp, new Rectangle(0, 0, btn.Width, btn.Height));
                e.Graphics.DrawImage(bmp, e.CellBounds.Left + (e.CellBounds.Width - btn.Width) / 2, e.CellBounds.Top + (e.CellBounds.Height - btn.Height) / 2);

                e.Handled = true;
            }
        }


        private void AdicionandoColunaEditar(DataGridView dataGridView)
        {
            // Adicionar coluna de botão para Ação
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            buttonColumn.Name = "Editar";
            buttonColumn.HeaderText = "Editar";
            buttonColumn.Width = 90;
            dataGridView.Columns.Add(buttonColumn);
            buttonColumn.UseColumnTextForButtonValue = true;

            // Configurar eventos para desenhar o botão e lidar com o clique
            dataGridView.CellPainting += btnEditarColuna;
        }

        // Desenhar o botão na célula
        private void btnEditarColuna(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == DataGridViewProdutos.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Guna2Button btn = new Guna2Button();


                btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
                btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
                btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
                btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
                btn.FillColor = System.Drawing.Color.White;
                btn.Font = new System.Drawing.Font("Segoe UI", 9F);
                btn.ForeColor = System.Drawing.Color.White;
                btn.Image = global::TESTE_GUNA.Properties.Resources.Produtos__8_;
                btn.ImageSize = new System.Drawing.Size(32, 32);
                btn.Location = new System.Drawing.Point(493, 12);
                btn.Name = "btnEditar";
                btn.Size = new System.Drawing.Size(38, 38);
                btn.TabIndex = 5;

                // Renderizar o botão na célula
                Bitmap bmp = new Bitmap(btn.Width, btn.Height);
                btn.DrawToBitmap(bmp, new Rectangle(0, 0, btn.Width, btn.Height));
                e.Graphics.DrawImage(bmp, e.CellBounds.Left + (e.CellBounds.Width - btn.Width) / 2, e.CellBounds.Top + (e.CellBounds.Height - btn.Height) / 2);

                e.Handled = true;
            }
        }
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdmTelaProdutos_Load(object sender, EventArgs e)
        {
            ProdutoDAO dao = new ProdutoDAO();
            DataGridViewProdutos.DataSource = dao.ListarProdutos();

            AdicionandoColunaExcluir(DataGridViewProdutos);
            AdicionandoColunaEditar(DataGridViewProdutos);

            DataGridViewProdutos.CellContentClick += DataGridViewProdutos_CellContentClick;


        }

      

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            ProdutoDAO d = new ProdutoDAO();
            DataGridViewProdutos.DataSource = d.PerformSearch(txtPesquisa.Text);

        }

        private AdmTelaEditarProduto telaEdicao;

        private void AbrirTelaEdicao(int idProduto, string nomeProduto, string descricaoProduto, decimal precoProduto, int quantidadeProduto, string departamentoProduto)
        {
            if (telaEdicao == null || telaEdicao.IsDisposed)
            {
                telaEdicao = new AdmTelaEditarProduto(idProduto, nomeProduto, descricaoProduto, precoProduto, quantidadeProduto, departamentoProduto, this.admHome);
                telaEdicao.ShowDialog();
            }
            else
            {
                telaEdicao.BringToFront(); // Traz a tela para frente se ela já estiver aberta
            }
        }


        public static int idProduto;
        private void DataGridViewProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DataGridViewProdutos.Rows.Count &&
                 e.ColumnIndex >= 0 && e.ColumnIndex < DataGridViewProdutos.Columns.Count)
            {
                // Verificar o nome da coluna clicada
                string columnName = DataGridViewProdutos.Columns[e.ColumnIndex].Name;

                if (columnName == "Excluir")
                {
                    TelaMessageBox messageBox = new TelaMessageBox();
                    messageBox.RetornaSimNao("DESEJA EXCLUIR O PRODUTO?");
                    messageBox.ShowDialog();

                    int qtd_estoque, qtdComprada, estoqueAtualizado;

                    if (messageBox.btnSimClick == true)
                    {
                        // Obtém o id do produto a partir da linha selecionada
                        idProduto = Convert.ToInt32(DataGridViewProdutos.Rows[e.RowIndex].Cells["ID"].Value);

                        // Remove a linha do DataGridView
                        DataGridViewProdutos.Rows.RemoveAt(e.RowIndex);

                        // Remove a linha do banco de dados
                        ProdutoDAO dao = new ProdutoDAO();
                        dao.excluirProduto(idProduto);

                        //MessageBox.Show("Produto excluído com sucesso.");
                        ProdutoDAO d = new ProdutoDAO();
                        DataGridViewProdutos.DataSource = d.ListarProdutos();



                        TelaMessageBoxSucess mensagem = new TelaMessageBoxSucess();
                        mensagem.Mensagem("PRODUTO EXCLUÍDO COM SUCESSO!");
                        mensagem.ShowDialog();

                        AdmTelaProdutos telaProdutos = new AdmTelaProdutos(this.admHome);
                        this.admHome.PrintarTela(telaProdutos);

                    }
                    else if (messageBox.btnNaoClick == true)
                    {
                        TelaMessageBox.FecharTodasInstancias();
                        messageBox.Close();
                    }
                    else
                    {
                        messageBox.Close();

                    }


                }

                else if (columnName == "Editar")
                {
                    if (DataGridViewProdutos.Columns[e.ColumnIndex].Name == "Editar")
                    {
                        // Obtém o id do produto a partir da linha selecionada
                        idProduto = Convert.ToInt32(DataGridViewProdutos.Rows[e.RowIndex].Cells["ID"].Value);
                        string nomeProduto = DataGridViewProdutos.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
                        string descricaoProduto = DataGridViewProdutos.Rows[e.RowIndex].Cells["Descrição"].Value.ToString();
                        decimal precoProduto = Convert.ToDecimal(DataGridViewProdutos.Rows[e.RowIndex].Cells["Preço"].Value);
                        int quantidadeProduto = Convert.ToInt32(DataGridViewProdutos.Rows[e.RowIndex].Cells["Quantidade"].Value);
                        string departamentoProduto = DataGridViewProdutos.Rows[e.RowIndex].Cells["Departamento"].Value.ToString();

                        AbrirTelaEdicao(idProduto, nomeProduto, descricaoProduto, precoProduto, quantidadeProduto, departamentoProduto);

                    }
                }
            }
        }
        private void DataGridViewProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void DataGridViewProdutos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    } 
}
