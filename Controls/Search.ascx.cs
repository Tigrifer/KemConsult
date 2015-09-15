using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Search : System.Web.UI.UserControl
{
    public void OnSearch(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtText.Text.Trim()))
        {
            Session["searchString"] = txtText.Text.Trim();
            Response.Redirect(ResolveUrl("~/SearchResults.aspx"));
        }
    }
}