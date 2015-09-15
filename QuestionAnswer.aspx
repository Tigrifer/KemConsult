<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QuestionAnswer.aspx.cs" Inherits="QuestionAnswer" %>
<%@ Register Src="~/Controls/Capcha.ascx" TagPrefix="uc" TagName="Capcha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Задать вопрос юристу оналйн.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <asp:LinkButton runat="server" OnClick="OnNewQuestion" Text="Задать новый вопрос" /> | <asp:LinkButton Text="Ответы на вопросы" runat="server" OnClick="OnViewAnswered" />
    <div>
        <asp:MultiView runat="server" ID="mvQA">
            <asp:View runat="server" ID="vQuestion">
                <h2>Задать вопрос юристу.</h2>
                <h3>Заполните форму ниже.</h3>
                <div>Имя: <asp:TextBox runat="server" ID="txtName" MaxLength="128" /> <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" ForeColor="Red" Text="*" ValidationGroup="addQuestion" /></div>
                <div>Контактный телефон: 
                    <asp:TextBox runat="server" ID="txtPhone" MaxLength="20" title='Ваш контактный телефон НЕ будет использоваться для сторонних целей (реклама, спам и т.п.).'  />
                    <a href="javascript:void(0);" title="Ваш контактный телефон НЕ будет использоваться для сторонних целей (реклама, спам и т.п.).">?</a>
                </div>
                <div>Категория: <asp:DropDownList ID="ddlCategories" runat="server" /></div>
                Вопрос:
                <div><asp:TextBox runat="server" ID="txtQuestion" TextMode="MultiLine" Width="500" Height="150" /></div>
                <uc:Capcha runat="server" ValidationGroup="addQuestion" />
                <div><asp:Button runat="server" OnClick="OnAdd" Text="Отправить" ValidationGroup="addQuestion" /></div>
                <h3 style="color:#007F0D;"><asp:Label ID="lblMessage" runat="server"/></h3>
            </asp:View>
            <asp:View runat="server" ID="vAnswers">
                <div>Категория: <asp:DropDownList ID="ddlCategoryFilter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnFilterChaged"/></div>
                <asp:ListView ID="lvAnswers" runat="server">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div><i>(<%#Eval("Date")%>) <%#Eval("Quester")%></i>: <a href='?id=<%#Eval("id")%>'><%#Eval("Question")%></a></div>
                    </ItemTemplate>
                    <EmptyDataTemplate>Ответов на вопросы пока нет.</EmptyDataTemplate>
                </asp:ListView>
            </asp:View>
            <asp:View runat="server" ID="vSingleAnswer">
                <h3>Вопрос.</h3>
                <div><asp:Label ID="lblQuester" runat="server" />:</div>
                <div class="quote"><asp:Label ID="lblQuestion" runat="server" /></div>
                <h3>Ответ.</h3>
                <div><asp:Label ID="lblAnswerer" runat="server" />:</div>
                <div class="quote"><asp:Label ID="lblAnswer" runat="server" /></div>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>