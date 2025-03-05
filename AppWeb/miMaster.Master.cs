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
    public partial class miMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";

                if (!(Page is login || Page is catalogo || Page is registro || Page is error || Page is verDetalle||Page is detalles))
                {

                    if (!Seguridad.sessionActiva(Session["Usuario"]))
                        Response.Redirect("login.aspx", false);

                    else
                    {
                        usuario User = (usuario)Session["Usuario"];


                        if (!string.IsNullOrEmpty(User.imagen))
                        {

                            imgAvatar.ImageUrl = "~/imagenes/" + ((usuario)Session["Usuario"]).imagen;
                        }
                    }
                }

            
                        
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("login.aspx");
        }
    }
}