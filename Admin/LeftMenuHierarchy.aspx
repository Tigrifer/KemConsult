<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LeftMenuHierarchy.aspx.cs" Inherits="Admin_LeftMenuHierarchy" %>
<%@ Register Src="~/Controls/Admin/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <uc:AdminMenu ID="ucAdminMenu" runat="server" />
    <div>Пункт меню: <asp:DropDownList runat="server" ID="ddlMenu" OnSelectedIndexChanged="OnMenuChanged" AutoPostBack="true" /></div>
    <div>Назначить подменю: <asp:CheckBoxList runat="server" ID="cblSubmenu" ></asp:CheckBoxList>

    <asp:Button runat="server" ID="btnLink" OnClick="OnLink" Text="Связать" /></div>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
</asp:Content>

