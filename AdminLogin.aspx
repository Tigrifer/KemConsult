<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminLogin" %>
<%@ Register Src="~/Controls/Capcha.ascx" TagPrefix="uc" TagName="Capcha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div>Логин:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtLogin" runat="server" ValidationGroup="AdminLogin" /> <asp:RequiredFieldValidator runat="server" ForeColor="DarkRed" Text="*" ControlToValidate="txtLogin" ValidationGroup="AdminLogin" SetFocusOnError="true"/></div>
    <div>Пароль: <asp:TextBox ID="txtPass" runat="server" ValidationGroup="AdminLogin" TextMode="Password" /> <asp:RequiredFieldValidator runat="server" ForeColor="DarkRed" Text="*" ControlToValidate="txtPass" ValidationGroup="AdminLogin" SetFocusOnError="true"/></div>
    <div class="content clear-block"><uc:Capcha ID="ucCapcha" runat="server" ValidationGroup="AdminLogin" /><br />
    <h1><asp:LinkButton runat="server" Text="Войти" ID="btnLogin" ValidationGroup="AdminLogin" /><br /></h1>
    <asp:Label ID="lblError" runat="server"></asp:Label></div>
</asp:Content>

