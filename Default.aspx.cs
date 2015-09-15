using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (DBDataContext db = new DBDataContext())
        {
            int i = 0;
            var s = (from st in db.Settings
                     where st.Name == "DefaultPageId"
                     select st.Value).FirstOrDefault();
            if (s != null && int.TryParse(s, out i))
            {
                Response.Redirect(ResolveUrl(string.Format("~/Page.aspx?id={0}", i)));
            }
        }
    }
}