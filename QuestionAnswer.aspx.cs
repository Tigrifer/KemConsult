using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QuestionAnswer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id;
        if (int.TryParse(Request["id"], out id))
        {
            using (DBDataContext db = new DBDataContext())
            {
                var qa = (from a in db.QA
                         where a.Answered && a.id == id
                         select a).FirstOrDefault();
                if (qa != null)
                {
                    mvQA.SetActiveView(vSingleAnswer);
                    lblAnswer.Text = qa.Answer.Replace("\n", "<br>");
                    lblAnswerer.Text = qa.Answerer;
                    lblQuester.Text = qa.Quester;
                    lblQuestion.Text = qa.Question.Replace("\n", "<br>");
                }
                else
                    mvQA.SetActiveView(vAnswers);
            }
        }
        else
            if (!IsPostBack)
                mvQA.SetActiveView(vQuestion);
        lblMessage.Text = "";
        if (!IsPostBack)
        {
            using (DBDataContext db = new DBDataContext())
            {
                ddlCategories.DataTextField = "Name";
                ddlCategories.DataValueField = "id";
                ddlCategories.DataSource = (from QAC in db.QACategory
                                            select QAC).ToList();
                ddlCategoryFilter.DataTextField = "Name";
                ddlCategoryFilter.DataValueField = "id";
                ddlCategoryFilter.DataSource = (from QAC in db.QACategory
                                                select QAC).ToList();
            }
            ddlCategories.DataBind();
            ddlCategoryFilter.DataBind();
            ddlCategoryFilter.Items.Insert(0, new ListItem("Все", "0"));
        }
    }

    public void OnFilterChaged(object sender, EventArgs e)
    {
        OnViewAnswered(null, null);
    }

    public void OnNewQuestion(object sender, EventArgs e)
    {
        mvQA.SetActiveView(vQuestion);
        txtName.Text = "";
        txtQuestion.Text = "";
    }

    public void OnViewAnswered(object sender, EventArgs e)
    {
        mvQA.SetActiveView(vAnswers);
        using (DBDataContext db = new DBDataContext())
        {
            if (ddlCategoryFilter.SelectedValue == "0")
            {
                var qa = from a in db.QA
                         where a.Answered
                         select a;
                lvAnswers.DataSource = qa;
            }
            else
            {
                int cat = int.Parse(ddlCategoryFilter.SelectedValue);
                var qa = from a in db.QA
                         where a.Answered && a.CategoryId == cat
                         select a;
                lvAnswers.DataSource = qa;
            }
            lvAnswers.DataBind();
        }
    }

    public void OnAdd(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            using (DBDataContext db = new DBDataContext())
            {
                int catID = int.Parse(ddlCategories.SelectedValue);
                var qa = new QA()
                {
                    Quester = txtName.Text.Trim(),
                    Question = txtQuestion.Text.Trim(),
                    Header = txtQuestion.Text.Trim(),
                    Phone = string.IsNullOrEmpty(txtPhone.Text.Trim()) ? null : txtPhone.Text.Trim(),
                    Date = DateTime.Now,
                    CategoryId = catID
                };
                db.QA.InsertOnSubmit(qa);
                db.SubmitChanges();

                mvQA.SetActiveView(vQuestion);
                txtName.Text = "";
                txtQuestion.Text = "";
                txtPhone.Text = "";

                lblMessage.Text = "Спасибо за Ваш вопрос. В ближайшее время мы постараемся дать Вам ответ.";
            }
        }
    }
}