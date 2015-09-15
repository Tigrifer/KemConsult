using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchResults : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["searchString"] != null)
        {
            string s = Session["searchString"].ToString();
            using (DBDataContext db = new DBDataContext())
            {
                var q = from Q in db.QA
                        where Q.Answer.Contains(s) || Q.Header.Contains(s) || Q.Question.Contains(s)
                        select new
                        {
                            Link = ResolveUrl(string.Format("~/QuestionAnswer.aspx?id={0}", Q.id)),
                            Header = Q.Header
                        };
                var p = from P in db.Pages
                        where P.Content.Contains(s) || P.DisplayLinkTitle.Contains(s) || P.Title.Contains(s)
                        select new
                        {
                            Link = ResolveUrl(string.Format("~/Page.aspx?id={0}", P.id)),
                            Header = P.Title
                        };

                var b = from B in db.Blog
                        where B.Content.Contains(s) || B.Header.Contains(s)
                        select new
                        {
                            Link = ResolveUrl(string.Format("~/Blog.aspx?id={0}", B.id)),
                            Header = B.Header
                        };

                lvSearchResults.DataSource = q.Union(p).Union(b);
                lvSearchResults.DataBind();
            }
        }
    }
}