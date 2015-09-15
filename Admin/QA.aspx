<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QA.aspx.cs" Inherits="Admin_QA" %>
<%@ Register Src="~/Controls/Admin/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<uc:AdminMenu ID="ucAdminMenu" runat="server" />
    <asp:LinkButton runat="server" OnClick="OnViewNonAnswered" Text="Неотвеченные вопросы" /> | <asp:LinkButton Text="Отвеченные вопросы" runat="server" OnClick="OnViewAnswered" />
    <div>
        <asp:MultiView ID="mvQuestions" runat="server">
            <asp:View ID="vNotAnswered" runat="server">
                <div>Категория: <asp:DropDownList ID="ddlFilterNew" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnFilterChagedNew"/></div>
                <asp:ListView ID="lvNotAnswered" runat="server">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div><i>(<%#Eval("Date")%>) <%#Eval("Quester")%></i>: <a href='?id=<%#Eval("id")%>'><%#Eval("Question")%></a> | <asp:LinkButton runat="server" CommandArgument='<%#Eval("id")%>' OnClick="OnDelete" OnClientClick="return confirm('Удалить?')" Text="Удалить" /></div>
                    </ItemTemplate>
                    <EmptyDataTemplate>Новых вопросов нет.</EmptyDataTemplate>
                </asp:ListView>
            </asp:View>
            <asp:View ID="vAnswered" runat="server">
                <div>Категория: <asp:DropDownList ID="ddlFilterOld" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnFilterChagedOld"/></div>
                <asp:ListView ID="lvAnswered" runat="server">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div><i>(<%#Eval("Date")%>) <%#Eval("Quester")%></i>: <a href='?id=<%#Eval("id")%>'><%#Eval("Question")%></a> | <asp:LinkButton runat="server" CommandArgument='<%#Eval("id")%>' OnClick="OnDelete" OnClientClick="return confirm('Удалить?')" Text="Удалить" /></div>
                    </ItemTemplate>
                    <EmptyDataTemplate>Список пуст.</EmptyDataTemplate>
                </asp:ListView>
            </asp:View>
            <asp:View runat="server" ID="vAnswering">
                <h3 id="hHeader" runat="server"></h3>
                <asp:Label runat="server" ID="lblQuester" /> <asp:Label ID="lblPhone" runat="server" /> задает вопрос:
                <div><asp:TextBox runat="server" ID="txtQuestion" TextMode="MultiLine" Width="400" Height="120" /></div>
                Ответ:
                <div><asp:TextBox TextMode="MultiLine" runat="server" ID="txtAnswer" Width="400" Height="120" /></div>
                <div>Ответил: <asp:TextBox runat="server" ID="txtAnswerer" /></div>
                <div>Категория: <asp:DropDownList ID="ddlCategories" runat="server" /></div>
                <div>
                    <asp:LinkButton runat="server" Text="Сохранить" OnClick="OnSavе" /> <asp:LinkButton runat="server" Text="Отмена" OnClick="OnCancel" />
                </div>
            </asp:View>
        </asp:MultiView>
        <div><asp:Label ID="lblMessage" runat="server" ForeColor="Green" /></div>
    </div>
</asp:Content>