using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Vendas.Models;

namespace Vendas.DAO
{
    public class EntregaDAO
    {
        public static bool CadastrarEntrega(Entrega entrega)
        {
            string query = "INSERT INTO ENTREGA (NUM_PEDIDO,VALOR_ENTREGA,PREVISAO_ENTREGA,COD_CLIENTE,FORMA_PAG,STATUS,COD_CAMINHAO,NUM_PARCIAL,OBSERVACAO,TELEFONE,ENDERECO)" +
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
    }
}