using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vendas.ConfigProjeto.Tabelas;
using Vendas.DAO;
using Vendas.Models;

namespace Vendas.View
{
    public partial class Entrega : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now);

                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.Cache.SetNoServerCaching();
                HttpContext.Current.Response.Cache.SetNoStore();
                Response.Cache.AppendCacheExtension("no-cache");
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                Response.Cache.SetNoStore();
                Response.AppendHeader("Pragma", "no-cache");
            }

            if (!IsPostBack)
            {
                MultiViewEntrega.ActiveViewIndex = 0;
                CarregarEntregas();
            }
        }

        public void CarregarEntregas()
        {
            string query = "";
            string filtro = " WHERE 1=1";


            if (!string.IsNullOrEmpty(txtDataDe.Text) && !string.IsNullOrEmpty(txtDataAte.Text))
            {
                filtro += " AND PREVISAO_ENTREGA BETWEEN @dataDe AND @dataAte";

            }

            else if (!string.IsNullOrEmpty(txtDataDe.Text))
            {
                filtro += " AND PREVISAO_ENTREGA >= @dataDe";
            }

            else if (!string.IsNullOrEmpty(txtDataAte.Text))
            {
                filtro += " AND PREVISAO_ENTREGA <= @dataAte";
            }

            if (!string.IsNullOrEmpty(txtNumeroPedido.Text))
            {
                filtro += " AND NUM_PEDIDO = @num_pedido";
            }

            query = "SELECT * FROM " + Tabelas_Projeto.ENTREGA + filtro + " ORDER BY PREVISAO_ENTREGA ASC";
            DataTable dtCarregaDados = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(Data.Conexao.ConexaoBanco()))

                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dataDe", txtDataDe.Text);
                        command.Parameters.AddWithValue("@dataAte", txtDataAte.Text);
                        command.Parameters.AddWithValue("@num_pedido", txtNumeroPedido.Text);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtCarregaDados.Load(reader);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

            }

            try
            {
                if (dtCarregaDados.Rows.Count > 0)
                {
                    Session["dtDados"] = dtCarregaDados;
                    GdvEntrega.DataSource = dtCarregaDados;
                    GdvEntrega.DataBind();
                    GdvEntrega.UseAccessibleHeader = true;
                    GdvEntrega.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    Session["dtDados"] = null;
                    GdvEntrega.DataSource = null;
                    GdvEntrega.DataBind();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();

            }
        }

        protected void GdvEntrega_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GdvEntrega_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnVisualizar_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnEditar_ServerClick(object sender, EventArgs e)
        {

        }
        protected void btnExcluir_ServerClick(object sender, EventArgs e)
        {
            hddAcao.Value = "EXCLUIR";
            Models.Entrega entrega = new Models.Entrega();
            GridViewRow row = (GridViewRow)(sender as Control).Parent.Parent;

            hddId.Value = row.Cells[3].Text;
            entrega = EntregaDAO.BuscarEntrega(hddId.Value);

            txtNumPedido.Text = entrega.NumPedido;
            txtNumParcial.Text = entrega.NumParcial;
            txtObservacao.Text = entrega.Observacao;
            txtEndereco.Text = entrega.Endereco;
            txtDataPrevisao.Text = entrega.PrevisaoEntrega;
            txtValorEntrega.Text = entrega.ValorEntrega;
            MultiViewEntrega.ActiveViewIndex = 1;
            Hidden();
        }

        public void Hidden()
        {
            NavBarSection.Attributes.Add("style", "display:none");
            FilterSection.Attributes.Add("style", "display:none");
        }

        public void View()
        {
            NavBarSection.Attributes.Add("style", "display:block");
            FilterSection.Attributes.Add("style", "display:block");
        }

        protected void LbtnIncluir_Click(object sender, EventArgs e)
        {
            MultiViewEntrega.ActiveViewIndex = 1;
            hddAcao.Value = "INCLUIR";
            Hidden();
        }


        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            MultiViewEntrega.ActiveViewIndex = 0;
            View();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

            if (hddAcao.Value.Equals("INCLUIR"))
            {
                Models.Entrega entrega = new Models.Entrega();

                entrega.StatusEntrega = ddlStatus.SelectedValue;
                entrega.CodCliente = ddlCliente.SelectedValue;
                entrega.CodCaminhao = ddlCaminhao.SelectedValue;
                entrega.Telefone = txtTelefone.Text;
                entrega.FormaPagamento = ddlFormPag.SelectedValue;
                entrega.NumParcial = txtNumParcial.Text;
                entrega.NumPedido = txtNumPedido.Text;
                entrega.Endereco = txtEndereco.Text;
                entrega.ValorEntrega = txtValorEntrega.Text;
                entrega.Observacao = txtObservacao.Text;
                entrega.PrevisaoEntrega = txtDataPrevisao.Text;

                if (EntregaDAO.CadastrarEntrega(entrega))
                {
                    MultiViewEntrega.ActiveViewIndex = 0;
                    View();
                    CarregarEntregas();
                }
                else
                {

                }
            }
            else if (hddAcao.Value.Equals("EXCLUIR"))
            {
                if (EntregaDAO.ExcluirEntrega(hddId.Value))
                {
                    MultiViewEntrega.ActiveViewIndex = 0;
                    View();
                    CarregarEntregas();
                }
                else
                {

                }
            }

        }

        protected void btnConfirmarExcluir_Click(object sender, EventArgs e)
        {
            if (EntregaDAO.ExcluirEntrega(hddId.Value))
            {

            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarEntregas();
        }
    }
}