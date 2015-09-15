using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_TopMenu : System.Web.UI.UserControl
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        using (DBDataContext db = new DBDataContext())
        {
            var m = (from TM in db.TopMenuItem
                     orderby TM.Order
                    select new
                    {
                        Title = TM.Title,
                        Alt = TM.AlternateText,
                        Link = TM.PageId
                    }).ToList();
            var res = from M in m
                      select new
                      {
                          M.Alt,
                          M.Title,
                          Link = !M.Link.HasValue ? "#" : string.Format(ResolveUrl("~/Page.aspx?id={0}"), M.Link.Value)
                      };
            lvTopMenu.DataSource = res;
            lvTopMenu.DataBind();
        }
    }
}