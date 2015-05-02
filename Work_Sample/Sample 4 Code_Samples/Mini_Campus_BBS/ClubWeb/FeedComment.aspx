<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeedComment.aspx.cs" Inherits="FeedComment" %>
<%@ PreviousPageType VirtualPath="~/FeedList.aspx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server">社团墙贴子</asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Overline="False" 
        Font-Underline="True"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table style="width: 600px;">
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" ToolTip="发布时间"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" ToolTip="作者"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" ToolTip="贴子状态" Visible="False"></asp:Label>
                <asp:Button ID="Button1" runat="server" ToolTip="帖子操作" Visible="False" 
                    onclick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Image ID="Image2" runat="server" Visible="False" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="Label8" runat="server" ToolTip="图片状态" Visible="False"></asp:Label>
                <asp:Button ID="Button2" runat="server" ToolTip="图片操作" Visible="False" 
                    onclick="Button2_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:TextBox ID="TextBox1" runat="server" Height="200px" ReadOnly="True" 
                    TextMode="MultiLine" Width="586px"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <asp:Table ID = "CommentListTable" runat = "server" >
    </asp:Table>
</asp:Content>

