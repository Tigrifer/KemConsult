<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Capcha.ascx.cs" Inherits="Controls_Capcha" %>
<script language="javascript" type="text/javascript">
    function Reload(obj)
    {
        var src = '<%=ResolveUrl("~/Controls/Capcha.ashx")%>?' + Math.random();
        obj.src=src;
    }
</script>
<div style="cursor:pointer;" ><img alt="���" id="imgCapcha" onclick="Reload(this);" src="<%=ResolveUrl("~/Controls/Capcha.ashx")%>?<%=Guid.NewGuid().ToString().Replace("-","")%>" /></div>
����������, ������� ���(5 ����):<br />
<asp:TextBox ID="txtCapcha" runat="server" MaxLength="5" autocomplete="off" />
<asp:Label ForeColor="red" ID="lblErr" runat="server" />
<asp:RequiredFieldValidator ID="valCapcha" ControlToValidate="txtCapcha" ForeColor="DarkRed" runat="server" Text="*" SetFocusOnError="true"/>
<br />
���� ����� ����� ����� - ������� �� ��������, ��� ���� ���� ��������� �����.