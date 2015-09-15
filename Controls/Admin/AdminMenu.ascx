<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminMenu.ascx.cs" Inherits="Controls_Admin_AdminMenu" %>
<ul class="links adminMenu">
    <li><a runat="server" href="~/Admin/Pages.aspx">Страницы</a></li>|
    <li><a runat="server" href="~/Admin/LeftMenu.aspx">Левое меню</a></li>|
    <li><a runat="server" href="~/Admin/TopMenu.aspx">Верхнее меню</a></li>|
    <li><a runat="server" href="~/Admin/News.aspx">Новости</a></li>|
    <li><a runat="server" href="~/Admin/Blog.aspx">Блог</a></li>|
    <li><a runat="server" href="~/Admin/QA.aspx">Вопрос - Ответ</a></li>|
    <li><a id="A2" runat="server" href="~/Admin/QACategory.aspx">Категории вопросов</a></li>|
    <li><a id="A1" runat="server" href="~/Admin/LeftMenuHierarchy.aspx">Иерархия левого меню</a></li>|
    <li><a runat="server" href="~/Admin/Password.aspx">Пароль</a></li>
</ul>
<h2 runat="server" id="header"></h2>