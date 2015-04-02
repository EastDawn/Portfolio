<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            height: 262px;
        }
    .style9
    {
        height: 255px;
        width: 93px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Text="社团主页"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table style="width: 100%; height: 294px;">
        <tr>
            <td align="center" bgcolor="#3399FF" class="style9" colspan="2">
                </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="Button1" runat="server" Height="25px" onclick="Button1_Click" 
                    Text="社团成员管理" Width="120px" />
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Height="25px" onclick="Button2_Click" 
                    Text="社团墙管理" Width="120px" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

