<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu.ascx.cs" Inherits="Controls_LeftMenu" %>

<ul class="menu">
<asp:ListView runat="server" ID="lvLeftMenu">
    <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
    </LayoutTemplate>
    <ItemTemplate>
        <li class="leaf" onmouseover="$(this).children(':first').next().show();" onmouseout="$(this).children(':first').next().hide();">
            <a title='<%#Eval("Alt")%>' href='<%# Eval("Link") %>'><%#Eval("Title")%></a>
            <%#RenderSubmenu((List<LeftMenu>)Eval("SubMenu"))%>
        </li>
    </ItemTemplate>
</asp:ListView>
        <li class="leaf"><a title='Вопрос-ответ' href='<%=ResolveUrl("~/QuestionAnswer.aspx")%>'>Вопрос-ответ</a></li>
        <li class="leaf"><a title='Блог' href='<%=ResolveUrl("~/Blog.aspx")%>'>Блог</a></li>
        <li class="leaf"><a title='Блог' href='<%=ResolveUrl("~/News.aspx")%>'>Новости</a></li>
</ul>