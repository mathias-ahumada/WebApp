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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAceptarLog_Click(object sender, EventArgs e)
        {
            usuario Usuario = new usuario();
            usuarioNegocio negocio = new usuarioNegocio();
            
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }

                Usuario.user=txtMail.Text;
                Usuario.pass=txtPassword.Text;  
              if(negocio.Login(Usuario))
                {
                    Session.Add("Usuario", Usuario);

                    Response.Redirect("catalogo.aspx", false);
                }
               else {
                    Session.Add("error", "pass o email incorrectos");
                    Response.Redirect("error.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx");
            }
        }
    }
}