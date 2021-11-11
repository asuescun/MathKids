using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mathkids
{
    public partial class juego : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userlogin"] != null)
            {
                lblcuentaID.Text = Convert.ToString((int)Session["userlogin"]);
            }
        }
    }
}