using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_QA : System.Web.UI.Page
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (DBDataContext db = new DBDataContext())
            {
                var data = (from QC in db.QACategory
                            select QC).ToArray();
                ddlCategories.DataSource = data;
                ddlFilterNew.DataSource = data;
                ddlFilterOld.DataSource = data;
                ddlCategories.DataTextField = "Name";
                ddlCategories.DataValueField = "id";
                ddlCategories.DataBind();
                ddlFilterNew.DataTextField = "Name";
                ddlFilterNew.DataValueField = "id";
                ddlFilterNew.DataBind();
                ddlFilterOld.DataTextField = "Name";
                ddlFilterOld.DataValueField = "id";
                ddlFilterOld.DataBind();
                ddlFilterNew.Items.Insert(0, new ListItem("Все", "0"));
                ddlFilterOld.Items.Insert(0, new ListItem("Все", "0"));
            }
        }

        lblMessage.Text = "";
        int id;
        if (int.TryParse(Request["id"], out id) && !IsPostBack)
        {
            using (DBDataContext db = new DBDataContext())
            {
                var qa = (from a in db.QA
                          where a.id == id
                          select a).FirstOrDefault();
                if (qa != null)
                {
                    mvQuestions.SetActiveView(vAnswering);
                    lblQuester.Text = qa.Quester;
                    lblPhone.Text = string.IsNullOrEmpty(qa.Phone) ? "" : string.Format(" (тел. <u>{0}</u>) ", qa.Phone);
                    txtQuestion.Text = qa.Question;
                    txtAnswerer.Text = qa.Answerer;
                    txtAnswer.Text = qa.Answer;
                    ddlCategories.SelectedValue = qa.CategoryId.ToString();

                    if (!IsPostBack)
                    {
                        ddlCategories.DataTextField = "Name";
                        ddlCategories.DataValueField = "id";
                        ddlCategories.DataSource = (from QAC in db.QACategory
                                                    select QAC).ToList();
                        ddlCategories.DataBind();
                    }
                    ddlCategories.Items.FindByValue(qa.CategoryId.ToString()).Selected = true;
                }
                else
                    mvQuestions.SetActiveView(vAnswered);
            }
        }
        else
            if (!IsPostBack)
                OnViewAnswered(null, null);
    }

    public void OnViewAnswered(object sender, EventArgs e)
    {
        mvQuestions.SetActiveView(vAnswered);
        int cat = 0;
        int.TryParse(ddlFilterOld.SelectedValue, out cat);
        using (DBDataContext db = new DBDataContext())
        {
            var data = (from Q in db.QA
                        where Q.Answered && (Q.CategoryId == cat || cat == 0)
                        select Q).ToArray();
            lvAnswered.DataSource = data;
            lvAnswered.DataBind();
        }
    }

    public void OnViewNonAnswered(object sender, EventArgs e)
    {
        mvQuestions.SetActiveView(vNotAnswered);
        int cat = 0;
        int.TryParse(ddlFilterNew.SelectedValue, out cat);
        using (DBDataContext db = new DBDataContext())
        {
            var data = (from Q in db.QA
                        where !Q.Answered && (Q.CategoryId == cat || cat == 0)
                        select Q).ToArray();
            lvNotAnswered.DataSource = data;
            lvNotAnswered.DataBind();
        }
    }

    public void OnSavе(object sender, EventArgs e)
    {
        int i = 0;
        int.TryParse(Request["id"], out i);
        if (i != 0)
        {
            using (DBDataContext db = new DBDataContext())
            {
                var q = (from Q in db.QA
                         where Q.id == i
                         select Q).FirstOrDefault();
                if (q != null)
                {
                    int catID = int.Parse(ddlCategories.SelectedValue);
                    q.Answered = true;
                    q.Question = txtQuestion.Text.Trim();
                    q.Answerer = txtAnswerer.Text.Trim();
                    q.Answer = txtAnswer.Text.Trim();
                    q.CategoryId = catID;
                    db.SubmitChanges();

                    lblMessage.Text = "Ответ успешно сохранен.";
                    mvQuestions.SetActiveView(vNotAnswered);
                    var data = (from Q in db.QA
                                where !Q.Answered
                                select Q).ToArray();
                    lvNotAnswered.DataSource = data;
                    lvNotAnswered.DataBind();
                }
                else
                    lblMessage.Text = "Ошибка при сохранении ответа.";
            }
        }
        else
        {
            lblMessage.Text = "Ошибка при сохранении ответа.";
        }
    }

    public void OnDelete(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        int i = 0;
        int.TryParse(btn.CommandArgument, out i);
        if (i != 0)
        {
            using (DBDataContext db = new DBDataContext())
            {
                var q = (from Q in db.QA
                         where Q.id == i
                         select Q).FirstOrDefault();
                if (q != null)
                {
                    db.QA.DeleteOnSubmit(q);
                    db.SubmitChanges();

                    lblMessage.Text = "Ответ успешно удален.";
                    mvQuestions.SetActiveView(vNotAnswered);

                    var data = (from Q in db.QA
                                where !Q.Answered
                                select Q).ToArray();
                    lvNotAnswered.DataSource = data;
                    lvNotAnswered.DataBind();
                }
                else
                    lblMessage.Text = "Ошибка при удалении.";
            }
        }
        else
        {
            lblMessage.Text = "Ошибка при удалении.";
        }
    }

    public void OnCancel(object sender, EventArgs e)
    {
        OnViewNonAnswered(null, null);
    }

    public void OnFilterChagedNew(object sender, EventArgs e)
    {
        mvQuestions.SetActiveView(vNotAnswered);
        DropDownList ddl = sender as DropDownList;
        int cat = 0;
        int.TryParse(ddl.SelectedValue, out cat);
        using (DBDataContext db = new DBDataContext())
        {
            var data = (from Q in db.QA
                        where !Q.Answered && (Q.CategoryId == cat || cat == 0)
                        select Q).ToArray();
            lvNotAnswered.DataSource = data;
            lvNotAnswered.DataBind();
        }
    }

    public void OnFilterChagedOld(object sender, EventArgs e)
    {
        mvQuestions.SetActiveView(vAnswered);
        DropDownList ddl = sender as DropDownList;
        int cat = 0;
        int.TryParse(ddl.SelectedValue, out cat);
        using (DBDataContext db = new DBDataContext())
        {
            var data = (from Q in db.QA
                        where Q.Answered && (Q.CategoryId == cat || cat == 0)
                        select Q).ToArray();
            lvAnswered.DataSource = data;
            lvAnswered.DataBind();
        }
    }
}