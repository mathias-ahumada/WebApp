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
    public partial class verDetalle : System.Web.UI.Page
    {
        public bool confirmaEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            confirmaEliminacion = false;
            txtId.Enabled = false;
            if (!IsPostBack) // Solo carga inicial
            {
                try
                {
                    // Cargar marcas y artículos (solo primera vez)
                    categoriaNegocio categoria = new categoriaNegocio();
                    marcaNegocio marcaNegocio = new marcaNegocio();

                    List<Marca> listaMarca = marcaNegocio.listar();
                    Session["listaMarca"] = listaMarca;

                    ddMarca.DataSource = listaMarca;
                    ddMarca.DataValueField = "_idMarca";
                    ddMarca.DataTextField = "_nombreMarca";
                    ddMarca.DataBind();

                    List<Categoria> listaCategorias = categoria.listar();

                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataValueField = "_idCategoria";
                    ddlCategoria.DataTextField = "_nombreCategoria";
                    ddlCategoria.DataBind();

                    if (Request.QueryString["id"] != null)
                    {
                        NegocioArticulos nego= new NegocioArticulos();
                        List<articulos> lista = nego.listar(Request.QueryString["id"].ToString());
                        articulos seleccionado = lista[0];

                        txtId.Text = seleccionado._idArticulo.ToString();
                        TxtNombre.Text = seleccionado._nombre;
                        txtCodigo.Text = seleccionado._CodigoArticulo;
                        txtImagen.Text = seleccionado.UrlImagen;
                        txtPrecio.Text = seleccionado._precio.ToString();

                        ddlCategoria.SelectedValue= seleccionado.DescripcionCategoria._idCategoria.ToString();
                        ddMarca.SelectedValue = seleccionado.DescripcionMarca._idMarca.ToString();

                       


                    }

                    // Opcional: Cargar ddlArticulo inicial si hay una marca seleccionada por defecto
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public void cargarImagen()
        {
            Img.ImageUrl = txtImagen.Text;
        }
        protected void ddlArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            


        }
    
        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {


            Img.ImageUrl=txtImagen.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                articulos articulos = new articulos();
                
                NegocioArticulos negocio = new NegocioArticulos();

                articulos._nombre = TxtNombre.Text;
                articulos._descripArticulo = txtArea.Text;
                articulos._CodigoArticulo = txtCodigo.Text;
                articulos._precio = decimal.Parse(txtPrecio.Text);
                articulos.UrlImagen = txtImagen.Text;

                articulos.DescripcionMarca = new Marca();
                articulos.DescripcionCategoria = new Categoria();   

                articulos.DescripcionMarca._idMarca = int.Parse(ddMarca.SelectedValue);
                articulos.DescripcionCategoria._idCategoria= int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    articulos._idArticulo=int.Parse(txtId.Text);
                    negocio.modificar(articulos);
                }
                else
                {
                    negocio.agregarArt(articulos);
                }
                Response.Redirect("home.aspx?val=1");




            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            confirmaEliminacion = true;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (confirmarEliminar.Checked) {

                        NegocioArticulos articulos = new NegocioArticulos();
                        articulos.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("home.aspx?val=1");
                    //recordar siempre pasar val=1 para que se refresque la lista
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}