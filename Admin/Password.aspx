<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Password.aspx.cs" Inherits="Admin_Password" %>
<%@ Register Src="~/Controls/Admin/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <uc:AdminMenu ID="ucAdminMenu" runat="server" />
    <div>Старый пароль: <asp:TextBox ID="txtOldPass" runat="server" TextMode="Password" ValidationGroup="changepass" /> <asp:RequiredFieldValidator runat="server" ValidationGroup="changepass" ForeColor="DarkRed" Text="*" ControlToValidate="txtOldPass" /></div>
    <div>Новый пароль: <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" ValidationGroup="changepass" /> <asp:RequiredFieldValidator runat="server" ValidationGroup="changepass" ForeColor="DarkRed" Text="*" ControlToValidate="txtNewPass" /></div>
    <div>Новый пароль еще раз: <asp:TextBox ID="txtNewPassRepeat" runat="server" TextMode="Password" ValidationGroup="changepass" /> <asp:RequiredFieldValidator runat="server" ValidationGroup="changepass" ForeColor="DarkRed" Text="*" ControlToValidate="txtNewPassRepeat" /><asp:CompareValidator runat="server" Text="*" ValidationGroup="changepass" ControlToValidate="txtNewPassRepeat" ControlToCompare="txtNewPass"/></div>
    <div><asp:Button runat="server" Text="Сохранить" OnClick="OnChange" /></div>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
</asp:Content>