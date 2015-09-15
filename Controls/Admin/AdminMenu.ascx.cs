using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Admin_AdminMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = Request.Url.AbsolutePath.ToLower();
        if(url.Contains("pages"))
        {
            header.InnerText = "Страницы";
        }
        if (url.Contains("blog"))
        {
            header.InnerText = "Блог";
        }
        if (url.Contains("leftmenu"))
        {
            header.InnerText = "Левое меню";
        }
        if (url.Contains("news"))
        {
            header.InnerText = "Новости";
        }
        if (url.Contains("qa"))
        {
            header.InnerText = "Вопрос - Ответ";
        }
        if (url.Contains("topmenu"))
        {
            header.InnerText = "Верхнее меню";
        }
        if (url.Contains("password"))
        {
            header.InnerText = "Пароль";
        }
        if (url.Contains("hierarchy"))
        {
            header.InnerText = "Иерархия левого меню";
        }
        if (url.Contains("qacategory"))
        {
            header.InnerText = "Категории вопросов";
        }
    }
}