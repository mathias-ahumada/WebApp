using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWeb
{
    public partial class error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgError.ImageUrl = "https://www.seoptimer.com/storage/images/2015/07/Destacada.jpg";

            lblError.Text= Session["error"].ToString();

        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}