using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Page : System.Web.UI.Page
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request["id"], out id))
        {
            using (DBDataContext db = new DBDataContext())
            {
                var p = (from P in db.Pages
                         where P.id == id
                         select P).FirstOrDefault();
                if (p != null)
                {
                    phPageContent.InnerHtml = p.Content;
                    header.InnerHtml = p.Title;
                    Page.Title = p.DisplayLinkTitle;
                }
            }
        }
    }
}