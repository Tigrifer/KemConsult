<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopMenu.ascx.cs" Inherits="Controls_TopMenu" %>

<asp:ListView runat="server" ID="lvTopMenu">
    <LayoutTemplate>
        <ul class="links primary-links">
            <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
        </ul>
    </LayoutTemplate>
    <ItemTemplate>
        <li><a title='<%#Eval("Alt")%>' href='<%# Eval("Link") %>' ><%#Eval("Title")%></a></li>
    </ItemTemplate>
</asp:ListView>