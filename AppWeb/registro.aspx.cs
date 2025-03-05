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
    public partial class registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {

            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            try
            {
                usuario Usuario = new usuario();
                usuarioNegocio usuario_negocio = new usuarioNegocio();
                emailService email = new emailService();

                Usuario.user = txtMail.Text;
                Usuario.pass = txtPassword.Text;

                

                Usuario.id = usuario_negocio.insetarNuevo(Usuario);

                Session.Add("Usuario", Usuario);

                //validar que no se rompa si entra con un mail invalido
                email.armarCorreo(Usuario.user, "Bienvenido", "Bienvenido a el catalogo de productos");

                email.enviar();

                Response.Redirect("catalogo.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx",false);
            }
            


        }
    }
}