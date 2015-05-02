<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeedList.aspx.cs" Inherits="FeedList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="社团墙"></asp:Label>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Button ID="Button1" runat="server" Text="发布新贴子" 
    onclick="Button1_Click" Visible="False" />
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <asp:Table ID = "FeedListTable" runat = "server" Height="16px" 
    Width="348px">
    </asp:Table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <asp:Button ID="Button2" runat="server" Text="发布新贴子" 
    onclick="Button2_Click" Visible="False" />
    </asp:Content>

