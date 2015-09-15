<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pages.aspx.cs" Inherits="Admin_Pages" %>
<%@ Register Src="~/Controls/Admin/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc" %>
<%@ Register Tagprefix="fckeditorv2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <uc:AdminMenu ID="ucAdminMenu" runat="server" />
    <div>Страницы: <asp:DropDownList runat="server" ID="ddlPages" AutoPostBack="true" OnSelectedIndexChanged="PageChanged" /> 
        <asp:LinkButton Text="Открывать по умолчанию" title="При загрузке сайта эта страница будет показана по умолчанию, если не была выбрана никакая другая." ID="btnMakeAsDefault" runat="server" OnClick="OnMakeDefault" ValidationGroup="none" /> 
        | <asp:LinkButton ID="btnDelete" OnClick="OnDeletePage" Text="Удалить" title="Удалить эту страницу" runat="server" ValidationGroup="none" OnClientClick="return confirm(this.title+'?');" />
        <asp:Label ID="lblError" runat="server" ForeColor="Green" />

    </div>
    <div>Заголовок страницы: <asp:TextBox ID="txtPageHeader" runat="server" Width="600px" /><asp:RequiredFieldValidator runat="server" ForeColor="Red" Text="*" ControlToValidate="txtPageHeader" ValidationGroup="savepage" /></div>
    <div>Текст ссылки: <asp:TextBox ID="txtLinkText" runat="server" Width="650px" /><asp:RequiredFieldValidator runat="server" ForeColor="Red" Text="*" ControlToValidate="txtLinkText" ValidationGroup="savepage" /></div>
    <div>
        <fckeditorv2:FCKeditor ID="fckEditor" runat="server" 
        BasePath="~/fck/" AutoDetectLanguage="false" ContentLangDirection="LeftToRight"
	    Height="700px" ToolbarCanCollapse="false" ToolbarStartExpanded="true"
	    UseBROnCarriageReturn="true"/>
    </div>
    <asp:Button ID="btnSave" runat="server" Text="Сохранить" OnClick="SavePage" ValidationGroup="savepage"/>
</asp:Content>