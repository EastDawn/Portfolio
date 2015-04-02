<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>轰隆隆社团-展示你的价值</title>
    <style type="text/css">
        .style1
        {
            width: 152px;
        }
        .style3
        {
            width: 47px;
        }
        .style4
        {
            width: 342px;
        }
        .style5
        {
            width: 67px;
        }
        .style6
        {
            width: 47px;
            height: 23px;
        }
        .style7
        {
            width: 152px;
            height: 23px;
        }
        .style8
        {
            width: 67px;
            height: 23px;
        }
        .style9
        {
            width: 273px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width: 100%;">
            <tr>
                <td align="right" class="style9">
&nbsp;
                    <br />
                    <asp:Image ID="Image2" runat="server" Height="89px" Width="197px" />
                    <br />
                    <br />
                    <table style="width: 78%; height: 88px;">
                        <tr>
                            <td align="right" class="style3">
                                <asp:Label ID="Label1" runat="server" Text="学号"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" 
                                    ontextchanged="TextBox1_TextChanged" ToolTip="请输入学号"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style6">
                                <asp:Label ID="Label2" runat="server" Text="密码"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:TextBox ID="TextBox2" runat="server"  
                                    TextMode="Password" ToolTip="请输入密码，6-16位数字和字符，区分大小写"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style3">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" class="style3">
                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" 
                                    NavigateUrl="~/Signup.aspx" ToolTip="新用户注册">注册</asp:HyperLink>
                            </td>
                            <td align="right" class="style1">
                                <asp:Button ID="Button1" runat="server" Enabled="False" onclick="Button1_Click" 
                                    Text="登陆" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
                <td class="style4" align="right">
                    <asp:Image ID="Image1" runat="server" Height="356px" 
                        ImageUrl="~/WebImage/login.jpg" Width="356px" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
