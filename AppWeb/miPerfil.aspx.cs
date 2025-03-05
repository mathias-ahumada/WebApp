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
    public partial class miPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sessionActiva(Session["Usuario"]))
                    {
                        usuario User = (usuario)Session["Usuario"];
                        txtEmail.Text = User.user;
                        txtNombre.Text = User.nombre;
                        txtApellido.Text = User.apellido;


                        if (!string.IsNullOrEmpty(User.imagen))
                        {
                            imgNuevoPerfil.ImageUrl = "~/imagenes/" + User.imagen;
                        }

                       

                        
                            buscaFavorito();
                        

                    }


                }
            }
            catch (Exception ex )
            {

                Session.Add("error.aspx", ex.ToString() );
                Response.Redirect("error.aspx", false);
            }
          
        }


        public void buscaFavorito()
        {
            usuario User = (usuario)Session["Usuario"];
            favoritoNegocio favoritoNegocio = new favoritoNegocio();
            List<dominio.favoritos> listaFavoritos = favoritoNegocio.listar();
            string articulo;
            int id;

            foreach (dominio.favoritos fav in listaFavoritos)
            {
                if (fav.idUser == User.id)
                {
                    id = fav.idArticulo;
                    NegocioArticulos nego = new NegocioArticulos();
                    List<articulos> listaArticulos = nego.listar();

                    foreach (articulos ar in listaArticulos)
                    {

                        if (id == ar._idArticulo)
                        {
                            articulo = ar._nombre;
                            lblFavorito.Text = articulo;

                            imgFavorito.ImageUrl = ar.UrlImagen;
                        }

                    }
                }
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }

                usuario Usuario = (usuario)Session["Usuario"];
                usuarioNegocio negocio = new usuarioNegocio();

                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./imagenes/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + Usuario.id + ".jpg");
                    Usuario.imagen = "perfil-" + Usuario.id + ".jpg";
                }
                Usuario.apellido = txtApellido.Text;
                Usuario.nombre = txtNombre.Text;
                

                negocio.actualizar(Usuario);
               Image img=(Image) Master.FindControl("imgAvatar");
                img.ImageUrl = "~/imagenes/" + Usuario.imagen;

                Response.Redirect("catalogo.aspx",false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString() );
                Response.Redirect("error.aspx", false);
            }

        }
    }
}