<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchResults.aspx.cs" Inherits="SearchResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <h1>Результаты поиска</h1>
    <div>
        <asp:ListView ID="lvSearchResults" runat="server">
            <LayoutTemplate>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
            </LayoutTemplate>
            <ItemTemplate>
                <div><a href='<%#Eval("Link")%>'><%#Eval("Header")%></a></div>
            </ItemTemplate>
            <EmptyDataTemplate>Поиск не дал результатов.</EmptyDataTemplate>
        </asp:ListView>
    </div>
</asp:Content>