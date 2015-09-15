using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Blog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        int id;
        // on add 
        if (Request["id"] == "0")
        {
            mvQuestions.SetActiveView(vSingle);
        }
        else
        {
            if (int.TryParse(Request["id"], out id) && !IsPostBack)
            {
                using (DBDataContext db = new DBDataContext())
                {
                    var b = (from B in db.Blog
                             where B.id == id
                             select B).FirstOrDefault();
                    if (b != null)
                    {
                        mvQuestions.SetActiveView(vSingle);
                        txtHeader.Text = b.Header;
                        fckEditor.Value = b.Content;
                    }
                    else
                        mvQuestions.SetActiveView(vAll);
                }
            }
            else
                if (!IsPostBack)
                {
                    mvQuestions.SetActiveView(vAll);
                    using (DBDataContext db = new DBDataContext())
                    {
                        var b = from B in db.Blog
                                select B;
                        lvAll.DataSource = b;
                        lvAll.DataBind();
                    }
                }
        }
    }

    public void OnDelete(object sender, EventArgs e)
    {
        int id;
        LinkButton btn = (LinkButton)sender;
        if (int.TryParse(btn.CommandArgument, out id))
        {
            using (DBDataContext db = new DBDataContext())
            {
                var b = (from B in db.Blog
                        where B.id == id
                        select B).FirstOrDefault();
                db.Blog.DeleteOnSubmit(b);
                db.SubmitChanges();
                Response.Redirect(ResolveUrl("~/Admin/Blog.aspx"));
            }
        }
    }

    public void OnSave(object sender, EventArgs e)
    {
        int id;
        if (int.TryParse(Request["id"], out id))
        {
            using (DBDataContext db = new DBDataContext())
            {
                if (id != 0)
                {
                    var b = (from B in db.Blog
                             where B.id == id
                             select B).FirstOrDefault();
                    if (b != null)
                    {
                        b.Content = fckEditor.Value;
                        b.Header = txtHeader.Text.Trim();
                        db.SubmitChanges();
                        lblMessage.Text = "Сохранено.";
                        mvQuestions.SetActiveView(vAll);
                    }
                    else
                        lblMessage.Text = "Ошибка при сохранении.";
                }
                else
                {
                    var b = new Blog()
                    {
                        Content = fckEditor.Value,
                        Header = txtHeader.Text.Trim()
                    };
                    db.Blog.InsertOnSubmit(b);
                    db.SubmitChanges();
                    Response.Redirect(ResolveUrl("~/Admin/Blog.aspx"));
                }
            }
            
        }
        else
        {
            lblMessage.Text = "Ошибка при сохранении.";
        }
    }
}