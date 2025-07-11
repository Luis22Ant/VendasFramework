using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using Vendas.ConfigProjeto.Tabelas;
using Vendas.Models;

namespace Vendas.DAO
{
    public class EntregaDAO
    {
        public static bool CadastrarEntrega(Entrega entrega)
        {
            string query = "INSERT INTO " + Tabelas_Projeto.ENTREGA + " (NUM_PEDIDO,VALOR_ENTREGA,PREVISAO_ENTREGA,COD_CLIENTE,FORMA_PAG,STATUS,COD_CAMINHAO,NUM_PARCIAL,OBSERVACAO,TELEFONE,ENDERECO)" +
                "VALUES" +
                "('" + entrega.NumPedido +
                "','" + entrega.ValorEntrega +
                "','" + entrega.PrevisaoEntrega +
                "','" + entrega.CodCliente +
                "','" + entrega.FormaPagamento +
                "','" + entrega.StatusEntrega +
                "','" + entrega.CodCaminhao +
                "','" + entrega.NumParcial +
                "','" + entrega.Observacao +
                "','" + entrega.Telefone +
                "','" + entrega.Endereco + "')";

            try
            {
                using (SqlConnection connection = new SqlConnection(Data.Conexao.ConexaoBanco()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }


            return true;
        }


        public static bool ExcluirEntrega(string id)
        {
            string query = "DELETE FROM " + Tabelas_Projeto.ENTREGA + " WHERE ID = '" + id + "'";

            try
            {
                using (SqlConnection connection = new SqlConnection(Data.Conexao.ConexaoBanco()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }


        public static Entrega BuscarEntrega(string id)
        {
            Entrega Entrega = new Entrega();
            string query = "SELECT NUM_PEDIDO,STATUS,FORMA_PAG,PREVISAO_ENTREGA,COD_CLIENTE,VALOR_ENTREGA,COD_CAMINHAO,NUM_PARCIAL,OBSERVACAO,TELEFONE,ENDERECO FROM " + Tabelas_Projeto.ENTREGA + " WHERE ID = '" + id + "'";

            try
            {
                using (SqlConnection connection = new SqlConnection(Data.Conexao.ConexaoBanco()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Entrega.NumPedido = reader["NUM_PEDIDO"].ToString();
                                Entrega.StatusEntrega = reader["STATUS"].ToString();
                                Entrega.FormaPagamento = reader["FORMA_PAG"].ToString();
                                Entrega.PrevisaoEntrega = reader["PREVISAO_ENTREGA"].ToString();
                                Entrega.ValorEntrega = reader["VALOR_ENTREGA"].ToString();
                                Entrega.CodCaminhao = reader["COD_CAMINHAO"].ToString();
                                Entrega.NumParcial = reader["NUM_PARCIAL"].ToString();
                                Entrega.Observacao = reader["OBSERVACAO"].ToString();
                                Entrega.Telefone = reader["TELEFONE"].ToString();
                                Entrega.Endereco = reader["ENDERECO"].ToString();
                                Entrega.CodCliente = reader["COD_CLIENTE"].ToString();
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

            }

            return Entrega;
        }
    }
}