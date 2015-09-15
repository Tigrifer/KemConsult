using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_QACategory : System.Web.UI.Page
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UpdateList();
            lblMessage.Text = "";
        }
    }

    public void btnUpdate_Click(object sender, EventArgs e)
    {
        using (DBDataContext db = new DBDataContext())
        {
            int curCAT = int.Parse(ddlCategories.SelectedValue);
            QACategory cat = (from CAT in db.QACategory
                              where CAT.id == curCAT
                              select CAT).FirstOrDefault();
            cat.Name = txtName.Text;
            db.SubmitChanges();
        }
        UpdateList();
        lblMessage.Text = "Категория обновлена";
    }

    public void btnSave_Click(object sender, EventArgs e)
    {
        using (DBDataContext db = new DBDataContext())
        {
            QACategory cat = new QACategory()
            {
                Name = txtName.Text
            };
            db.QACategory.InsertOnSubmit(cat);
            db.SubmitChanges();
        }
        UpdateList();
        lblMessage.Text = "Добавлена новая категория";
    }

    public void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtName.Text = ddlCategories.Items.FindByValue(ddlCategories.SelectedValue).Text;
    }

    void UpdateList()
    {
        using (DBDataContext db = new DBDataContext())
        {
            ddlCategories.DataTextField = "Name";
            ddlCategories.DataValueField = "id";
            ddlCategories.DataSource = (from QAC in db.QACategory
                                        select QAC).ToList();
            ddlCategories.DataBind();
            txtName.Text = ddlCategories.Items.FindByValue(ddlCategories.SelectedValue).Text;
        }
        lblMessage.Text = "";
    }
}