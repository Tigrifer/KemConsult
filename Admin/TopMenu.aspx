<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TopMenu.aspx.cs" Inherits="Admin_TopMenu" %>
<%@ Register Src="~/Controls/Admin/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<uc:AdminMenu ID="ucAdminMenu" runat="server" />
<div>Пункт меню: <asp:DropDownList runat="server" ID="ddlMenu" OnSelectedIndexChanged="OnMenuChanged" AutoPostBack="true" /><asp:Button runat="server" ID="btnDelete" OnClick="OnDelete" Text="Удалить" OnClientClick="return confirm('Удалить этот пункт?');" /> <asp:Button Text="←" ID="btnLeft" OnClick="OnLeft" runat="server" title="Переместить пункт левее в списке"/> <asp:Button Text="→" ID="btnRight" OnClick="OnRight" runat="server" title="Переместить пункт правее в списке"/></div>
<div>Связать со страницей: <asp:DropDownList runat="server" ID="ddlPage" /> <asp:Button runat="server" ID="btnLink" OnClick="OnLink" Text="Связать" /></div>
<div>
    <asp:TextBox runat="server" ID="txtNewMenu" ValidationGroup="add" /><asp:RequiredFieldValidator runat="server" ControlToValidate="txtNewMenu" ForeColor="Red" Text="*" ValidationGroup="add"/>
    <asp:Button runat="server" Text="Добавить новый пункт меню" OnClick="OnAdd" ValidationGroup="add" title="Заполните поле слева и нажмите здесь, чтоб добавить новый пункт меню." />
    <asp:Button runat="server" Text="Переименовать" OnClick="OnUpdate" ValidationGroup="add" title="Заполните поле слева и нажмите здесь, чтоб переименовать выбранный на данный момент пункт меню."/>
</div>
<asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
</asp:Content>