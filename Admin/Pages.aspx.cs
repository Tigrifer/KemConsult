using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Admin_Pages : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        InitPageList();
    }

    public void PageChanged(object sender, EventArgs e)
    {
        lblError.Text = "";
        using (DBDataContext db = new DBDataContext())
        {
            int i;
            if (int.TryParse(ddlPages.SelectedValue, out i))
            {
                if (i > 0)
                {
                    var p = (from P in db.Pages
                             where P.id == i
                             select P).FirstOrDefault();
                    if (p != null)
                    {
                        txtLinkText.Text = p.DisplayLinkTitle;
                        txtPageHeader.Text = p.Title;
                        fckEditor.Value = p.Content;
                        btnMakeAsDefault.Visible = true;
                        btnDelete.Visible = true;
                        btnDelete.CommandArgument = p.id.ToString();
                        if (p.LeftMenu.Count() != 0 || p.TopMenuItem.Count() != 0)
                        {
                            StringBuilder pts = new StringBuilder();
                            foreach (LeftMenu lm in p.LeftMenu.ToList())
                            {
                                pts.AppendFormat(" '{0}' слева,", lm.ItemName);
                            }

                            foreach (TopMenuItem tm in p.TopMenuItem.ToList())
                            {
                                pts.AppendFormat(" '{0}' сверху,", tm.Title);
                            }

                            string str = pts.Length > 0 ? pts.ToString().Substring(0, pts.Length - 1) : "";

                            btnDelete.ToolTip = string.Format("Удалить эту страницу (ВНИМАНИЕ! Удаление этой страницы повлечет за собой удаление следующих пунктов меню:{0})", str);
                        }
                        else
                            btnDelete.ToolTip = "Удалить эту страницу";
                    }
                    else
                    {
                        btnMakeAsDefault.Visible = false;
                        btnDelete.Visible = false;
                    }
                    return;
                }
                else
                {
                    btnMakeAsDefault.Visible = false;
                    btnDelete.Visible = false;
                }
            }
            txtLinkText.Text = "";
            txtPageHeader.Text = "";
            fckEditor.Value = "";
        }
    }

    public void OnMakeDefault(object sender, EventArgs e)
    {
        using (DBDataContext db = new DBDataContext())
        {
            var set = (from S in db.Settings
                       where S.Name == "DefaultPageId"
                       select S).FirstOrDefault();
            if (set != null)
            {
                set.Value = ddlPages.SelectedValue;
                db.SubmitChanges();
            }
            else
                lblError.Text = "Ошибка установки начальной страницы.";
        }
    }

    public void SavePage(object sender, EventArgs e)
    {
        int i;
        using (DBDataContext db = new DBDataContext())
        {
            if (int.TryParse(ddlPages.SelectedValue, out i))
            {
                var p = (from P in db.Pages
                         where P.id == i
                         select P).FirstOrDefault();
                if (p != null)
                {
                    p.Content = fckEditor.Value;
                    p.DisplayLinkTitle = txtLinkText.Text;
                    p.Title = txtPageHeader.Text;
                    lblError.Text = "<script>alert('Страница обновлена');</script>";
                    txtLinkText.Text = "";
                    txtPageHeader.Text = "";
                    fckEditor.Value = "";
                }
                else
                {
                    var np = new Pages();
                    np.Content = fckEditor.Value;
                    np.DisplayLinkTitle = txtLinkText.Text;
                    np.Title = txtPageHeader.Text;
                    db.Pages.InsertOnSubmit(np);
                    lblError.Text = "<script>alert('Страница добавлена');</script>";
                    txtLinkText.Text = "";
                    txtPageHeader.Text = "";
                    fckEditor.Value = "";
                }
                db.SubmitChanges();
                InitPageList();
                return;
            }
            var p_ = new Pages();
            p_.Content = fckEditor.Value;
            p_.DisplayLinkTitle = txtLinkText.Text;
            p_.Title = txtPageHeader.Text;
            db.Pages.InsertOnSubmit(p_);
            lblError.Text = "Страница добавлена";
            db.SubmitChanges();

            InitPageList();
        }
    }

    private void InitPageList()
    {
        using (DBDataContext db = new DBDataContext())
        {
            var data = (from P in db.Pages
                        select P);
            ddlPages.DataSource = data;
            ddlPages.DataTextField = "DisplayLinkTitle";
            ddlPages.DataValueField = "id";
            ddlPages.DataBind();
            ddlPages.Items.Insert(0, new ListItem("Добавить новую", "0"));
        }
        btnMakeAsDefault.Visible = false;
        btnDelete.Visible = false;
    }

    public void OnDeletePage(object sender, EventArgs e)
    {
        using (DBDataContext db = new DBDataContext())
        {
            LinkButton btn = (LinkButton)sender;
            int id = 0;
            if (int.TryParse(btn.CommandArgument, out id))
            {
                var del = (from P in db.Pages
                           where P.id == id
                           select P).FirstOrDefault();
                if (del != null)
                {
                    if (del.LeftMenu.Count() == 0 && del.TopMenuItem.Count() == 0)
                    {
                        db.Pages.DeleteOnSubmit(del);
                    }
                    else
                    {
                        db.LeftMenu.DeleteAllOnSubmit(del.LeftMenu);
                        db.TopMenuItem.DeleteAllOnSubmit(del.TopMenuItem);
                        db.Pages.DeleteOnSubmit(del);
                    }
                    db.SubmitChanges();
                    txtLinkText.Text = "";
                    txtPageHeader.Text = "";
                    fckEditor.Value = "";
                    InitPageList();
                    lblError.Text = "<script>alert('Страница удалена.');</script>";
                }
                else
                    lblError.Text = "<script>alert('Ошибка при удалении страницы. Попробуйте еще раз.');</script>";
            }
            else
                lblError.Text = "<script>alert('Ошибка при удалении страницы. Попробуйте еще раз.');</script>";
        }
    }
}