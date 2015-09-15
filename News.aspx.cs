using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id;
        if (int.TryParse(Request["id"], out id))
        {
            mvNewsView.SetActiveView(vSingle);
            using (DBDataContext db = new DBDataContext())
            {
                var n = (from N in db.News
                         where N.id == id
                         select N).FirstOrDefault();
                if (n != null)
                {
                    Page.Title = n.PageHeader;
                    lblContent.Text = n.Content;
                    h2NewsHeader.InnerText = n.Header;
                }
                else
                    lblContent.Text = "Новость была удалена с сервера.";
            }
        }
        else
        {
            mvNewsView.SetActiveView(vAll);
            using (DBDataContext db = new DBDataContext())
            {
                var res = (from N in db.News
                           select N).ToList();
                lvNews.DataSource = res;
                lvNews.DataBind();
                if (res.Count() <= dpPager.PageSize)
                    dpPager.Visible = false;
            }
        }
    }
}