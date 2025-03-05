using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AppWeb
{
    public partial class detalles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            if (Request.QueryString["id"] != null)
            {
                

                NegocioArticulos nego = new NegocioArticulos();
                List<articulos> lista = nego.listar(Request.QueryString["id"].ToString());
                articulos seleccionado = lista[0];

                txtNombre.Enabled = false;
                txtMarca.Enabled = false;
                txtCategoria.Enabled = false;
                txtDescrip.Enabled = false; 
                txtId.Enabled = false;
                txtPrecio.Enabled = false;

                txtId.Text=seleccionado._idArticulo.ToString();
                txtNombre.Text=seleccionado._nombre;
                txtMarca.Text = seleccionado.DescripcionMarca._nombreMarca.ToString();
                txtCategoria.Text=seleccionado.DescripcionCategoria._nombreCategoria.ToString();
                txtDescrip.Text = seleccionado._descripArticulo.ToString();
                txtPrecio.Text=seleccionado._precio.ToString();
                img.ImageUrl = seleccionado.UrlImagen.ToString();

            }

            }

        protected void btnFav_Click(object sender, EventArgs e)
        {
            //revisar que no se esta guardando nada
            NegocioArticulos nego = new NegocioArticulos();
            List<articulos> lista = nego.listar(Request.QueryString["id"].ToString());
            articulos seleccionado = lista[0];


            dominio.favoritos fav = new dominio.favoritos();

            favoritoNegocio favoritoNegocio = new favoritoNegocio();
            usuario Usuario = (usuario)Session["Usuario"];

            if (Usuario != null)
            {
                fav.idUser = Usuario.id;
            }

            fav.idArticulo = seleccionado._idArticulo;
            fav.idUser = Usuario.id;

            List<dominio.favoritos> listaFavoritos = favoritoNegocio.listar();
            bool bandera = false;
           
            foreach(var comparar in listaFavoritos)
            {
                if (fav.idUser == comparar.idUser)
                {
                   
                    bandera = true;
                    fav.Id = comparar.Id;
                    favoritoNegocio.actualizar(fav);
                }
               
            }
                    


            if (bandera == false)
            {




                favoritoNegocio.insetarNuevo(fav);
            }

            Session.Add("Favorito", fav);

            Response.Redirect("miPerfil.aspx", false);











        }
    }
}