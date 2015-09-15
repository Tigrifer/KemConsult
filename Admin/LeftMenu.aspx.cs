using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_LeftMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            InitLists();
        lblMessage.Text = "";
    }

    public void OnMenuChanged(object sender, EventArgs e)
    {
        using (DBDataContext db = new DBDataContext())
        {
            int mId = 0;
            int.TryParse(ddlMenu.SelectedValue, out mId);

            var p = (from P in db.Pages
                     join TM in db.LeftMenu on P.id equals TM.PageID
                     where TM.id == mId
                     select P).FirstOrDefault();
            if (p != null)
            {
                ddlPage.SelectedItem.Selected = false;
                ddlPage.Items.FindByValue(p.id.ToString()).Selected = true;
            }
        }
    }

    public void OnLink(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            using (DBDataContext db = new DBDataContext())
            {
                int pid = 0;
                int mid = 0;
                if (int.TryParse(ddlMenu.SelectedValue, out mid) && int.TryParse(ddlPage.SelectedValue, out pid))
                {
                    var p = (from P in db.Pages
                             where P.id == pid
                             select P).FirstOrDefault();
                    var m = (from M in db.LeftMenu
                             where M.id == mid
                             select M).FirstOrDefault();
                    if (p != null && m != null)
                    {
                        m.PageID = p.id;
                        db.SubmitChanges();
                        lblMessage.Text = string.Format("Пункт меню '{0}' был успешно связан со страницей '{1}'", m.ItemName, p.Title);
                    }
                }
            }
        }
    }

    public void OnAdd(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            using (DBDataContext db = new DBDataContext())
            {
                var topmenu = new LeftMenu()
                {
                    PageID = null,
                    ItemName = txtNewMenu.Text.Trim()
                };
                db.LeftMenu.InsertOnSubmit(topmenu);
                db.SubmitChanges();
                topmenu.Order = topmenu.id;
                db.SubmitChanges();
                lblMessage.Text = string.Format("Добавлен новый пункт меню '{0}'", txtNewMenu.Text.Trim());
            }
            InitLists();
        }
    }

    private void InitLists()
    {
        using (DBDataContext db = new DBDataContext())
        {
            var menudata = from LM in db.LeftMenu
                           orderby LM.Order
                           select LM;

            var pagedata = from P in db.Pages
                           select P;

            ddlMenu.Enabled = true;
            ddlPage.Enabled = true;
            if (menudata.Count() == 0 || pagedata.Count() == 0)
            {
                ddlMenu.Enabled = false;
                ddlPage.Enabled = false;
            }

            ddlMenu.DataSource = menudata;
            ddlMenu.DataTextField = "ItemName";
            ddlMenu.DataValueField = "id";
            ddlMenu.DataBind();

            ddlPage.DataSource = pagedata;
            ddlPage.DataTextField = "Title";
            ddlPage.DataValueField = "id";
            ddlPage.DataBind();

            int mId = 0;
            int.TryParse(ddlMenu.SelectedValue, out mId);

            var p = (from P in pagedata
                     join TM in menudata on P.id equals TM.PageID
                     where TM.id == mId
                     select P).FirstOrDefault();
            if (p != null)
                ddlPage.Items.FindByValue(p.id.ToString()).Selected = true;
        }
    }

    public void OnDelete(object sender, EventArgs e)
    {
        int i = 0;
        if (int.TryParse(ddlMenu.SelectedValue, out i))
        {
            using (DBDataContext db = new DBDataContext())
            {
                var m = (from M in db.LeftMenu
                        where M.id == i
                        select M).FirstOrDefault();
                if (m != null)
                {
                    db.LeftMenu.DeleteOnSubmit(m);
                    db.SubmitChanges();
                    lblMessage.Text = string.Format("Пункт меню '{0}' удален.", m.ItemName);
                    InitLists();
                }
            }
        }
    }

    public void OnUpdate(object sender, EventArgs e)
    {
        int i = 0;
        if (int.TryParse(ddlMenu.SelectedValue, out i) && txtNewMenu.Text.Trim().Length > 0)
        {
            using (DBDataContext db = new DBDataContext())
            {
                var m = (from M in db.LeftMenu
                         where M.id == i
                         select M).FirstOrDefault();
                if (m != null)
                {
                    string oldName = m.ItemName;
                    m.ItemName = txtNewMenu.Text.Trim();
                    db.SubmitChanges();
                    lblMessage.Text = string.Format("Пункт меню '{0}' переименован в '{1}'.", oldName, m.ItemName);
                    InitLists();
                }
            }
        }
    }

    public void OnUp(object sender, EventArgs e)
    {
        int i = 0;
        if (int.TryParse(ddlMenu.SelectedValue, out i))
        {
            using (DBDataContext db = new DBDataContext())
            {
                var m = (from M in db.LeftMenu
                         where M.id == i
                         select M).FirstOrDefault();
                if (m != null)
                {
                    var exm = (from EXM in db.LeftMenu
                               where EXM.Order < m.Order
                               orderby EXM.Order descending
                               select EXM).FirstOrDefault();
                    if (exm != null)
                    {
                        int tmp = m.Order.Value;
                        m.Order = exm.Order.Value;
                        exm.Order = tmp;
                        db.SubmitChanges();
                    }
                }
            }
        }
    }

    public void OnDown(object sender, EventArgs e)
    {
        int i = 0;
        if (int.TryParse(ddlMenu.SelectedValue, out i))
        {
            using (DBDataContext db = new DBDataContext())
            {
                var m = (from M in db.LeftMenu
                         where M.id == i
                         select M).FirstOrDefault();
                if (m != null)
                {
                    var exm = (from EXM in db.LeftMenu
                               where EXM.Order > m.Order
                               orderby EXM.Order
                               select EXM).FirstOrDefault();
                    if (exm != null)
                    {
                        int tmp = m.Order.Value;
                        m.Order = exm.Order.Value;
                        exm.Order = tmp;
                        db.SubmitChanges();
                    }
                }
            }
        }
    }
}