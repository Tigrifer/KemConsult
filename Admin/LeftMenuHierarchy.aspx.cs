using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_LeftMenuHierarchy : System.Web.UI.Page
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
            var menudata = from LM in db.LeftMenu
                           orderby LM.Order
                           select LM;
            int i;
            if (int.TryParse(ddlMenu.SelectedValue, out i))
            {
                cblSubmenu.Items.Clear();
                foreach (var sd in menudata)
                {
                    if (sd.id != i && (sd.ParetnId == i || sd.ParetnId == null))
                    {
                        ListItem l = new ListItem();
                        l.Selected = sd.ParetnId == i;
                        l.Text = sd.ItemName;
                        l.Value = sd.id.ToString();
                        cblSubmenu.Items.Add(l);
                    }
                }
            }
        }
    }

    public void OnLink(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            using (DBDataContext db = new DBDataContext())
            {
                int mid = 0;
                if (int.TryParse(ddlMenu.SelectedValue, out mid))
                {
                    var m = from M in db.LeftMenu
                             select M;
                    foreach (ListItem I in cblSubmenu.Items)
                    {
                        foreach (var M in m)
                        {
                            if (M.id.ToString() == I.Value)
                            {
                                if (I.Selected)
                                    M.ParetnId = mid;
                                else
                                    M.ParetnId = null;
                            }
                        }
                    }
                    db.SubmitChanges();
                    lblMessage.Text = "Сохранено";
                }
            }
        }
    }

    private void InitLists()
    {
        using (DBDataContext db = new DBDataContext())
        {
            var menudata = from LM in db.LeftMenu
                           orderby LM.Order
                           select LM;

            ddlMenu.DataSource = menudata;
            ddlMenu.DataTextField = "ItemName";
            ddlMenu.DataValueField = "id";
            ddlMenu.DataBind();
            int i;
            if (int.TryParse(ddlMenu.SelectedValue, out i))
            {
                cblSubmenu.Items.Clear();
                foreach (var sd in menudata)
                {
                    if (sd.id != i && (sd.ParetnId == i || sd.ParetnId == null))
                    {
                        ListItem l = new ListItem();
                        l.Selected = sd.ParetnId == i;
                        l.Text = sd.ItemName;
                        l.Value = sd.id.ToString();
                        cblSubmenu.Items.Add(l);
                    }
                }
            }
        }
    }
}