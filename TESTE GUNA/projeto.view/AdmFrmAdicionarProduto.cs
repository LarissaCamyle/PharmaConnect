﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TESTE_GUNA.projeto.view
{
    public partial class AdmFrmAdicionarProduto : Form
    {
        public AdmFrmAdicionarProduto()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            //button fechar o programa (X)
            this.Close();
        }

        private void txtNomeCartao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNomeCartao_Click(object sender, EventArgs e)
        {
            
        }

        private void txtPreco_Click(object sender, EventArgs e)
        {
            
        }

        private void txtQuantidade_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCriarProduto_Click(object sender, EventArgs e)
        {

            var precoentrada = Convert.ToDecimal(txtPreco.Text);
            txtPreco.Text = precoentrada.ToString("N2"); 
            
            string nome = txtNomeProduto.Text;
            string desc = txtDescricao.Text;
            int quantidadeEstoque = int.Parse(txtQuantidade.Text);
            decimal precoUnitProduto = decimal.Parse(txtPreco.Text);
            string dep = cbDepartamentos.Text;
            FrmMessageBox mensagem = new FrmMessageBox();
            

            mensagem.Mensagem("PRODUTO CRIADO COM SUCESSO!");
            mensagem.ShowDialog();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TxtKeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar  != 08 && e.KeyChar != 44)
            {
                e.Handled = true;
                return;
            }else if(e.KeyChar == 44)
            {
                TextBox txt = (TextBox)sender;
                if(txt.Text.Contains(","))
                    e.Handled = true;
            }


        }

        private void AdmFrmAdicionarProduto_Load(object sender, EventArgs e)
        {

        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            if (char.IsDigit(e.KeyChar) == false)
            {
                e.Handled = true;
                return;
            }
        }

        private void txtPreco_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
