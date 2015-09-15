<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Blog.aspx.cs" Inherits="Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div class="content clear-block">
        <h2 id="content_header">Блог</h2>
        <asp:MultiView ID="mvBlog" runat="server">
            <asp:View ID="vSingle" runat="server">
                <a href='<%=ResolveUrl("~/Blog.aspx")%>'>Назад</a>
                <h3 id="header" runat="server"></h3>
                <div ID="phPageContent" runat="server"></div>
            </asp:View>
            <asp:View ID="vAll" runat="server">
                <asp:ListView ID="lvBlog" runat="server">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div><a href='?id=<%#Eval("id")%>'><%#Eval("Header")%></a></div>
                    </ItemTemplate>
                    <EmptyDataTemplate>Блог пуст.</EmptyDataTemplate>
                </asp:ListView>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>