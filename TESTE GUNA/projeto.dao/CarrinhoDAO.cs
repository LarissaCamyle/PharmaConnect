﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTE_GUNA.projet.conexao;
using TESTE_GUNA.projeto.model;
using TESTE_GUNA.projeto.view;



using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using System.Globalization;
using System.Data;
using Guna.UI2.WinForms;
using System.Data.SqlClient;
using TESTE_GUNA.projeto.window;

namespace TESTE_GUNA.projeto.dao
{
     public class CarrinhoDAO : CarrinhoB
     {

        //Conecta com o Banco de dados
        private MySqlConnection conexao;
        public static List<CarrinhoB> list = new List<CarrinhoB>();


        //Construtor
        public CarrinhoDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }


        #region Cadastro Produtos



        public void CadastrarProdutoCarrinho(CarrinhoDAO obj)
        {
            try
            {

                //Definindo comando SQL
                string sql = @"insert into tb_carrinho (id_produtoCarrinho, qtd_Carrinho,subtotalCarrinho,totalCarrinho,id_cliente)
                            values(@id_produtoCarrinho,@qtd_Carrinho,@subtotalCarrinho,@totalCarrinho,@id_cliente)";


                //Organizando comando SQL
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                //int qtdInicial = 1;
                executacmd.Parameters.AddWithValue("@id_produtoCarrinho", obj.id_produtoCarrinho);
                executacmd.Parameters.AddWithValue("@qtd_Carrinho", obj.qtd_Carrinho);
                executacmd.Parameters.AddWithValue("@subtotalCarrinho", obj.subtotalCarrinho);
                executacmd.Parameters.AddWithValue("@totalCarrinho", obj.totalCarrinho);
                executacmd.Parameters.AddWithValue("id_cliente", obj.id_cliente);




                //Abrindo conexao e aplicando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //fechando conexao
                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro Identificado:" + erro);
            }
        }
        #endregion




        #region Search
        public void Search(int key)
        {

            string sql = "select * from tb_carrinho where  id_cliente = @idCliente;";

            //organizar o comando e executar
            MySqlCommand executacmd = new MySqlCommand(sql, conexao);

            executacmd.Parameters.AddWithValue("@idCliente", key );
            conexao.Open();

            //responsavel por executar o comando e armazenar os dados do PRODUTO
            MySqlDataReader reader = executacmd.ExecuteReader();



            list.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CarrinhoDAO p = new CarrinhoDAO
                    {
                        id_carrinho = reader.GetInt32(0),
                        id_produtoCarrinho = reader.GetInt32(1),
                        
                        qtd_Carrinho = reader.GetInt32(2),
                        subtotalCarrinho = reader.GetDecimal(3),
                        totalCarrinho = reader.GetDecimal(4)


                    };

                    list.Add(p);
                }
            }
            reader.Dispose();
            executacmd.Dispose();
            conexao.Close();



        }



        #endregion

        //#region Update

      
       // public void AlterarProdutoCarrinho(CarrinhoDAO obj)
       // {
       //     try
       //     {

       //         //Definindo comando SQL
       //         string sql = @"UPDATE tb_carrinho 
       //                         SET qtd_carrinho = @qtd_Carrinho 
       //                         WHERE id_cliente = @id_cliente  AND id_produtoCarrinho = @id_produtoCarrinho;";


       //         //Organizando comando SQL
       //         MySqlCommand executacmd = new MySqlCommand(sql, conexao);

       //         //int qtdInicial = 1;
       //         executacmd.Parameters.AddWithValue("@id_produtoCarrinho", obj.id_produtoCarrinho);
       //         executacmd.Parameters.AddWithValue("@qtd_Carrinho", obj.qtd_Carrinho);
       //         int id_conectado = ClienteDAO.id_conectado;
       //         executacmd.Parameters.AddWithValue("id_cliente", id_conectado);




       //         //Abrindo conexao e aplicando sql
       //         conexao.Open();
       //         executacmd.ExecuteNonQuery();

       //         //fechando conexao
       //         conexao.Close();

       //     }
       //     catch (Exception erro)
       //     {

       //         MessageBox.Show("Erro Identificado:" + erro);
       //     }
       // }
       //#endregion




    }
}
