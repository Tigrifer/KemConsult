using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Controls_LeftMenu : System.Web.UI.UserControl
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        using (DBDataContext db = new DBDataContext())
        {
            var m = (from TM in db.LeftMenu
                     where TM.ParetnId == null
                     orderby TM.Order
                     select new
                     {
                         Title = TM.ItemName,
                         Alt = "",
                         Link = TM.PageID,
                         SubMenu = TM.LeftMenu2.ToList()
                     }).ToList();
            var res = from M in m
                      select new
                      {
                          M.Alt,
                          M.Title,
                          Link = !M.Link.HasValue ? "#" : string.Format(ResolveUrl("~/Page.aspx?id={0}"), M.Link.Value),
                          Submenu = M.SubMenu
                      };
            lvLeftMenu.DataSource = res;
            lvLeftMenu.DataBind();
        }
    }

    public string RenderSubmenu(List<LeftMenu> list)
    {
        if (list == null || list.Count() == 0)
            return "";
        StringBuilder sb = new StringBuilder();
        sb.Append("<ul class=\"menu\" style=\"display:none;\">");
        foreach(var l in list)
        {
            sb.AppendFormat("<li class=\"leaf\"><a title='{0}' href='{1}' >{2}</a></li>", "", (!l.PageID.HasValue ? "#" : string.Format(ResolveUrl("~/Page.aspx?id={0}"), l.PageID)), l.ItemName);
        }
        sb.Append("</ul>");
        return sb.ToString();
    }
}