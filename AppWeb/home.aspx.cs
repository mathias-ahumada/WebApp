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

        public bool filtroAvanzado {  get; set; }   
        public List<articulos> artList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {




                if (!(Seguridad.esAdmin(Session["Usuario"])))
                {
                    Session.Add("Error", "tenes que tener perfil admin para entrar aca");
                    Response.Redirect("error.aspx");
                    // valida si el usuario que ingresa es el admin
                }

                filtroAvanzado = cheBoxFiltroAvanzado.Checked;
                NegocioArticulos negocio = new NegocioArticulos();
                // Solo en la carga inicial o si se requiere refrescar (por ejemplo, al volver de agregar un artículo)
                if (!IsPostBack || (Request.QueryString["val"] != null && Request.QueryString["val"] == "1"))
                {
                    if (Request.QueryString["val"] != null && Request.QueryString["val"] == "1")
                    {
                        // Actualizar la lista

                        Session.Add("ListaArticulos", negocio.listar());
                        artList = negocio.listar();
                    }
                    else
                    {



                        if (Session["ListaArticulos"] == null)
                        {

                            artList = negocio.listar();
                            Session["ListaArticulos"] = artList;
                        }
                        else
                        {

                            artList = negocio.listar();
                        }
                    }

                    dgvHome.DataSource = artList;
                    dgvHome.DataBind();
                }

            }
            catch(Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx");
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

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {

            NegocioArticulos negocio= new NegocioArticulos();
            List<articulos> lista = negocio.listar();

            List<articulos> filtrada = lista.FindAll(x => x._nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));

            dgvHome.DataSource= filtrada;
            dgvHome.DataBind();
        }

        protected void cheBoxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            filtroAvanzado=cheBoxFiltroAvanzado.Checked;
            txtFiltro.Enabled = !filtroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();

            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("mayor a");
                ddlCriterio.Items.Add("igual a");
                ddlCriterio.Items.Add("menor a");
            }
            else
            { if (ddlCampo.SelectedItem.ToString() == "Nombre")
                {
                    ddlCriterio.Items.Add("comienza con");
                    ddlCriterio.Items.Add("contiene");
                    ddlCriterio.Items.Add("termina con");
                }
                else
                {
                    ddlCriterio.Items.Add("comienza con");
                    ddlCriterio.Items.Add("contiene");
                    ddlCriterio.Items.Add("termina con");
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores seleccionados
                string campo = ddlCampo.SelectedItem.ToString();
                string criterio = ddlCriterio.SelectedItem.ToString();
                string filtroo = txtFiltroAvanzado.Text;

                // Aplicar el filtro
                NegocioArticulos negocio = new NegocioArticulos();
                List<articulos> listaFiltrada = negocio.filtro(campo, criterio, filtroo);

                // Actualizar el GridView
                dgvHome.DataSource = listaFiltrada;
                dgvHome.DataBind();
            }
            catch (Exception ex)
            {
                // Manejar la excepción (puedes mostrar un mensaje al usuario)
                Session.Add("error", ex.ToString()  );
                Response.Redirect("error.aspx");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}