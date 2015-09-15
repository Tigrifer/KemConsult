<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <asp:MultiView ID="mvNewsView" runat="server">
        <asp:View ID="vAll" runat="server">
             <center><h1>Новости</h1></center>
             <asp:ListView ID="lvNews" runat="server">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>
                    <h3><a title='<%#Eval("Header")%>' href='<%# ResolveUrl(string.Format("~/News.aspx?id={0}", Eval("id")))%>'><%#Eval("Header")%></a></h3>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <h3>Нет доступных новостей на данный момент.</h3>
                </EmptyDataTemplate>
             </asp:ListView>
             <center><asp:DataPager ID="dpPager" runat="server" PagedControlID="lvNews" PageSize="12">
                <Fields><asp:NumericPagerField /></Fields>
             </asp:DataPager></center>
        </asp:View>
        <asp:View ID="vSingle" runat="server">
            <asp:HyperLink NavigateUrl="~/News.aspx" runat="server">все новости</asp:HyperLink>
            <center><h2 id="h2NewsHeader" runat="server"></h2></center>
            <asp:Label ID="lblContent" runat="server"></asp:Label>
        </asp:View>
    </asp:MultiView>
</asp:Content>

