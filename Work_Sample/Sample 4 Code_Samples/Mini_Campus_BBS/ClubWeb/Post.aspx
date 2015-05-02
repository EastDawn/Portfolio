<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #TextArea1
        {
            height: 298px;
            width: 225px;
        }
        .style7
        {
            width: 50px;
        }
        .style8
        {
            width: 227px;
        }
    .style9
    {
        width: 65px;
        height: 29px;
    }
    .style10
    {
        width: 65px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:550px;">
        <tr>
            <td align="right" class="style9">
                <asp:Label ID="Label1" runat="server" Text="标题"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="205px" 
                    ontextchanged="TextBox1_TextChanged" AutoPostBack="True"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table style="width: 550px; height: 63px;">
    <tr>
        <td class="style10" width="65px">
            &nbsp;</td>
        <td rowspan="3">
            <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" Height="263px" 
                ontextchanged="TextBox2_TextChanged" TextMode="MultiLine" Width="214px"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style10" width="65px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style10" width="65px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <table style="width:550px;">
        <tr>
            <td class="style9" width="65px">
                &nbsp;</td>
            <td class="style8">
                <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="你可以选择一张图片上传" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9" width="65px">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9" width="65px">
                &nbsp;</td>
            <td align="right" class="style8">
                <asp:Button ID="Button1" runat="server" style="margin-left: 0px" Text="发布" 
                    onclick="Button1_Click" Enabled="False" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


