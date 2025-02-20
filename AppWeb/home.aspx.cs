using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace AppWeb
{
    public partial class home : System.Web.UI.Page
    {
        public List<articulos> artList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Solo en la carga inicial o si se requiere refrescar (por ejemplo, al volver de agregar un artículo)
            if (!IsPostBack || (Request.QueryString["val"] != null && Request.QueryString["val"] == "1"))
            {
                if (Request.QueryString["val"] != null && Request.QueryString["val"] == "1")
                {
                    // Actualizar la lista
                    NegocioArticulos negocio = new NegocioArticulos();
                    artList = negocio.listar();
                    Session["lista"] = artList;
                }
                else
                {
                    if (Session["lista"] == null)
                    {
                        NegocioArticulos negocio = new NegocioArticulos();
                        artList = negocio.listar();
                        Session["lista"] = artList;
                    }
                    else
                    {
                        artList = (List<articulos>)Session["lista"];
                    }
                }

                dgvHome.DataSource = artList;
                dgvHome.DataBind();
            }
        }


        protected void dgvHome_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvHome.SelectedDataKey.Value.ToString();
            Response.Redirect("verDetalle.aspx?id=" + id);

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("verDetalle.aspx?returnUrl=home.aspx?val=1");

            Response.Redirect("verDetalle.aspx?returnUrl=home.aspx?");

        }
    }
}