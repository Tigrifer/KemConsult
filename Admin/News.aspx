<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="Admin_News" %>
<%@ Register Src="~/Controls/Admin/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc" %>
<%@ Register Tagprefix="fckeditorv2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <uc:AdminMenu ID="ucAdminMenu" runat="server" />
    <div><asp:DropDownList runat="server" OnSelectedIndexChanged="OnNewsChanged" ID="ddlNews" AutoPostBack="true" /><asp:Button runat="server" ID="btnDelete" OnClick="OnDelete" Text="Удалить" OnClientClick="return confirm('Удалить эту новость?');" Enabled="false" /></div>
    <div>
        <div>Заголовок: <asp:TextBox runat="server" ID="txtHeader" ValidationGroup="add" Width="467" /><asp:RequiredFieldValidator runat="server" ControlToValidate="txtHeader" ForeColor="Red" Text="*" ValidationGroup="add"/></div>
        <div>Заголовок страницы: <asp:TextBox runat="server" ID="txtPageTitle" ValidationGroup="add" Width="400" /></div>
        <div>
            <fckeditorv2:FCKeditor ID="fckEditor" runat="server" 
            BasePath="~/fck/" AutoDetectLanguage="false" ContentLangDirection="LeftToRight"
	        Height="700px" ToolbarCanCollapse="false" ToolbarStartExpanded="true"
	        UseBROnCarriageReturn="true"/>
        </div>
        <asp:Button runat="server" ID="btnSave" Text="Добавить новость" OnClick="OnAdd" ValidationGroup="add"/>
    </div>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
</asp:Content>