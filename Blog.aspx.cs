using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Blog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request["id"], out id))
        {
            mvBlog.SetActiveView(vSingle);
            using (DBDataContext db = new DBDataContext())
            {
                var b = (from B in db.Blog
                         where B.id == id
                         select B).FirstOrDefault();
                if (b != null)
                {
                    phPageContent.InnerHtml = b.Content;
                    header.InnerHtml = b.Header;
                    Page.Title = b.Header;
                }
            }
        }
        else
        {
            mvBlog.SetActiveView(vAll);
            using (DBDataContext db = new DBDataContext())
            {
                var b = from B in db.Blog
                         select B;
                lvBlog.DataSource = b;
                lvBlog.DataBind();
            }
        }
    }
}