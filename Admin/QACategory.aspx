<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QACategory.aspx.cs" Inherits="Admin_QACategory" %>
<%@ Register Src="~/Controls/Admin/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<uc:AdminMenu ID="ucAdminMenu" runat="server" />
<div>Категория: <asp:DropDownList ID="ddlCategories" runat="server" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged" AutoPostBack="true"/></div>
<div>
    <asp:TextBox ID="txtName" runat="server"/>
    <asp:Button ID="btnSave" runat="server" Text="Добавить новую категорию" OnClick="btnSave_Click" />
    <asp:Button ID="btnUpdate" runat="server" Text="Обновить выбранную категорию" OnClick="btnUpdate_Click" />
</div>
<asp:Label ID="lblMessage" runat="server"/>
</asp:Content>

