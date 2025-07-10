using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            string query = "SELECT * FROM ENTREGA";
            DataTable dtCarregaDados = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(Data.Conexao.ConexaoBanco()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

        protected void btnCopiar_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnExcluir_ServerClick(object sender, EventArgs e)
        {

        }

        protected void LbtnIncluir_Click(object sender, EventArgs e)
        {
            MultiViewEntrega.ActiveViewIndex = 1;
            NavBarSection.Attributes.Add("style", "display:none");
            FilterSection.Attributes.Add("style", "display:none");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            MultiViewEntrega.ActiveViewIndex = 0;
            NavBarSection.Attributes.Add("style", "display:block");
            FilterSection.Attributes.Add("style", "display:block");
        }
    }
}