<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Setting.aspx.cs" Inherits="Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 100%;
            height: 304px;
        }
        .style8
        {
            height: 38px;
        }
        .style9
        {
            height: 38px;
            width: 174px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Text="账户设置"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table class="style6">
        <tr>
            <td align="right" class="style9">
                <asp:Label ID="Label4" runat="server" Text="学号"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                <asp:Label ID="Label5" runat="server" Text="用户名"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style9">
                <asp:Label ID="Label6" runat="server" Text="原密码"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" ToolTip="请输入原有密码"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                <asp:Label ID="Label7" runat="server" Text="新密码"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" ToolTip="请设置新密码"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                <asp:Label ID="Label8" runat="server" Text="密码确认"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="TextBox5" runat="server" TextMode="Password" 
                    ToolTip="请再次输入新密码"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style9">
                &nbsp;</td>
            <td align="left" class="style8">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="确认修改" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

