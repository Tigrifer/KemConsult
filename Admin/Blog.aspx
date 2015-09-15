<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Blog.aspx.cs" Inherits="Admin_Blog" %>
<%@ Register Src="~/Controls/Admin/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc" %>
<%@ Register Tagprefix="fckeditorv2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<uc:AdminMenu ID="ucAdminMenu" runat="server" />
    <div>
        <div><asp:Label ID="lblMessage" runat="server" ForeColor="Green" /></div>
        <div><a href='<%=ResolveUrl("~/Admin/Blog.aspx?id=0")%>'>Добавить</a></div><br />
        <asp:MultiView ID="mvQuestions" runat="server">
            <asp:View ID="vAll" runat="server">
                <asp:ListView ID="lvAll" runat="server">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div><a href='?id=<%#Eval("id")%>'><%#Eval("Header")%></a> | <asp:LinkButton runat="server" CommandArgument='<%#Eval("id")%>' OnClick="OnDelete" OnClientClick="return confirm('Удалить?')" Text="Удалить" /></div>
                    </ItemTemplate>
                    <EmptyDataTemplate>Блог пуст.</EmptyDataTemplate>
                </asp:ListView>
            </asp:View>
            <asp:View runat="server" ID="vSingle">
                Заголовок: <asp:TextBox ID="txtHeader" runat="server" Width="600" />
                <div>
                    <fckeditorv2:FCKeditor ID="fckEditor" runat="server" 
                    BasePath="~/fck/" AutoDetectLanguage="false" ContentLangDirection="LeftToRight"
	                Height="700px" ToolbarCanCollapse="false" ToolbarStartExpanded="true"
	                UseBROnCarriageReturn="true"/>
                </div>
                <asp:LinkButton Text="Сохранить" runat="server" ID="btnSave" OnClick="OnSave" /> <a href='<%=ResolveUrl("~/Admin/Blog.aspx")%>'>Отмена</a>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>

