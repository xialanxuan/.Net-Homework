using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hw1login
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["Username"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}