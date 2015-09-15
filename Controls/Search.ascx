<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="Controls_Search" %>

<div>
    <div class="container-inline" id="search">
        Поиск по сайту:
        <asp:TextBox runat="server" class="form-text" title="Введите ключевые слова для поиска." Text="" ID="txtText"  MaxLength="128" Width="120"/>
        <asp:Button ID="Button1" class="btnSearch" Text="Найти" runat="server" OnClick="OnSearch"/>
    </div>
</div>