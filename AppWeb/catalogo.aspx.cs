using System;
using System.Collections.Generic;
using System.Web.UI;
using dominio;
using negocio;

namespace AppWeb
{
    public partial class catalogo : System.Web.UI.Page
    {
        public List<articulos> artList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                NegocioArticulos nego = new NegocioArticulos();

                if (!IsPostBack) // Solo cargar la lista si no es un postback
                {
                    if (Session["ListaArticulos"] != null)
                    {
                        // Recuperar la lista de la sesión
                        artList = nego.listar();
                    }
                    else
                    {
                        // Si la sesión está vacía, cargar desde la base de datos
                        NegocioArticulos neg = new NegocioArticulos();
                        artList = neg.listar();
                        Session["ListaArticulos"] = artList; // Guardar en sesión
                    }
                }
                else
                {
                    // En PostBack, asegurarse de que artList no sea null
                    artList = (List<articulos>)Session["ListaArticulos"];


                    artList = nego.listar();
                }
            }
            catch(Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx",false);
            }
            
            }
    }
}
