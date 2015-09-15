using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            InitLists();
        lblMessage.Text = "";
    }

    public void OnNewsChanged(object sender, EventArgs e)
    {
        using (DBDataContext db = new DBDataContext())
        {
            int mId = 0;
            int.TryParse(ddlNews.SelectedValue, out mId);

            var p = (from N in db.News
                     where N.id == mId
                     select N).FirstOrDefault();
            if (p != null)
            {
                txtHeader.Text = p.Header;
                txtPageTitle.Text = p.PageHeader;
                fckEditor.Value = p.Content;
                btnSave.Text = "Обновить новость";
                btnDelete.Enabled = true;
            }
            else
            {
                btnSave.Text = "Добавить новость";
                btnDelete.Enabled = false;
            }
        }
    }

    public void OnAdd(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (ddlNews.SelectedValue == "-1")
            {
                using (DBDataContext db = new DBDataContext())
                {
                    var news = new News()
                    {
                        Header = txtHeader.Text.Trim(),
                        PageHeader = txtPageTitle.Text.Trim(),
                        Content = fckEditor.Value
                    };
                    db.News.InsertOnSubmit(news);
                    db.SubmitChanges();
                    lblMessage.Text = string.Format("Добавлена новая новость '{0}'", txtHeader.Text.Trim());
                }
            }
            else
            {
                Update();
            }
            InitLists();
        }
    }

    private void InitLists()
    {
        using (DBDataContext db = new DBDataContext())
        {
            var newsdata = from N in db.News
                           select N;

            ddlNews.DataSource = newsdata;
            ddlNews.DataTextField = "Header";
            ddlNews.DataValueField = "id";
            ddlNews.DataBind();
            ddlNews.Items.Insert(0, new ListItem("Добавить новость", "-1"));
            btnDelete.Enabled = false;
        }
    }

    public void OnDelete(object sender, EventArgs e)
    {
        int i = 0;
        if (int.TryParse(ddlNews.SelectedValue, out i))
        {
            using (DBDataContext db = new DBDataContext())
            {
                var n = (from N in db.News
                         where N.id == i
                         select N).FirstOrDefault();
                if (n != null)
                {
                    db.News.DeleteOnSubmit(n);
                    db.SubmitChanges();
                    lblMessage.Text = string.Format("Новость '{0}' удалена.", n.Header);
                    InitLists();
                }
            }
        }
    }

    public void Update()
    {
        int i = 0;
        if (int.TryParse(ddlNews.SelectedValue, out i) && txtHeader.Text.Trim().Length > 0)
        {
            using (DBDataContext db = new DBDataContext())
            {
                var n = (from N in db.News
                         where N.id == i
                         select N).FirstOrDefault();
                if (n != null)
                {
                    n.Header = txtHeader.Text.Trim();
                    n.PageHeader = txtPageTitle.Text.Trim();
                    n.Content = fckEditor.Value;
                    db.SubmitChanges();
                    lblMessage.Text = string.Format("Новость обновлена.");
                }
            }
        }
    }
}