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

namespace TESTE_GUNA.projeto.window
{
    public partial class AdmTelaAdicionarProduto : Form
    {
        private AdmTelaHome admHome;

        public AdmTelaAdicionarProduto(AdmTelaHome home)
        {
            InitializeComponent();
            this.admHome = home;
            this.DoubleBuffered = true;//parar de travar a tela
            boxCategoria.Items.Add("Analgesico");
            boxCategoria.Items.Add("Diabeticos");
            boxCategoria.Items.Add("Antinflamatorio");
            boxCategoria.Items.Add("Ginecologicos");
            boxCategoria.Items.Add("Antivirais e Antibioticos");
            boxCategoria.Items.Add("Hipertensao");
            boxCategoria.Items.Add("Dermatologicos");
            boxCategoria.Items.Add("Suplementos e Vitaminas");

            // Associa o evento SelectedIndexChanged
            boxCategoria.SelectedIndexChanged += new EventHandler(boxCategoria_SelectedIndexChanged);
        }

        string categoriaSelecionada;
        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            ProdutoDAO dao = new ProdutoDAO()
            {
                nomeProduto = txtNome.Text,
                descProduto = txtDescricao.Text,
                precoProduto = Convert.ToDecimal(txtPreco.Text),
                qtdEstoque = Convert.ToInt32(txtQtd.Text),
                departamento = categoriaSelecionada


            };

            try
            {
                dao.CadastrarProduto(dao);
                TelaMessageBoxSucess messageBoxSucess = new TelaMessageBoxSucess();
                messageBoxSucess.Mensagem("PRODUTO ADICIONADO COM SUCESSO!");
                messageBoxSucess.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Preencher todos os campos");
                throw;
            }

        }

        private void AdmTelaAdicionarProduto_Load(object sender, EventArgs e)
        {

          

        }

        private void boxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtém o valor selecionado
            categoriaSelecionada = boxCategoria.SelectedItem.ToString();

         
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir somente números, backspace e vírgula
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ',')
            {
                // Permitir apenas uma vírgula no texto
                if (e.KeyChar == ',')
                {
                    // Verificar se já existe uma vírgula no texto atual
                    TextBox textBox = sender as TextBox;
                    if (textBox != null && textBox.Text.Contains(','))
                    {
                        e.Handled = true; // Bloquear a entrada se já houver uma vírgula
                    }
                }
            }
            else
            {
                e.Handled = true; // Bloquear a entrada de outros caracteres
            }
        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir somente números, backspace e vírgula
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ',')
            {
                // Permitir apenas uma vírgula no texto
                if (e.KeyChar == ',')
                {
                    // Verificar se já existe uma vírgula no texto atual
                    TextBox textBox = sender as TextBox;
                    if (textBox != null && textBox.Text.Contains(','))
                    {
                        e.Handled = true; // Bloquear a entrada se já houver uma vírgula
                    }
                }
            }
            else
            {
                e.Handled = true; // Bloquear a entrada de outros caracteres
            }
        }

        private void txtPreco_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
