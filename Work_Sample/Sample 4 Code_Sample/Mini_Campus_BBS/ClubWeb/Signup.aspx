<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>轰隆隆社团-成员注册</title>
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            height: 20px;
            width: 282px;
        }
        .style3
        {
            width: 282px;
        }
        .style4
        {
            width: 281px;
        }
        .style5
        {
            width: 388px;
        }
        .style6
        {
            width: 388px;
            height: 25px;
        }
        .style7
        {
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        注册<br />
        <br />
    
        <table style="width:100%;">
            <tr>
                <td align="right" class="style2">
                    &nbsp;</td>
                <td class="style1">
        身份认证<br />
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    <asp:Label ID="Label1" runat="server" Text="学号"></asp:Label>
                </td>
                <td class="style1">
                    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" 
                        ontextchanged="TextBox1_TextChanged" ToolTip="请输入你的学号" 
                        CausesValidation="True"></asp:TextBox>
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    <asp:Label ID="Label2" runat="server" Text="姓名"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" 
                        ontextchanged="TextBox2_TextChanged" ToolTip="请输入你的姓名" 
                        CausesValidation="True"></asp:TextBox>
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table style="width:100%;">
            <tr>
                <td align="right" class="style4">
                    &nbsp;</td>
                <td>
                    密码设置<br />
                </td>
            </tr>
            <tr>
                <td align="right" class="style4">
                    <asp:Label ID="Label3" runat="server" Text="设置密码"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" 
                        ToolTip="请设置密码，6-16位字母或数字"
                        CausesValidation="True" MaxLength="16"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="TextBox3" ErrorMessage="密码格式错误" 
                        ValidationExpression="\w+([-+.']\w+)*" SetFocusOnError="True" 
                        ToolTip="您输入的密码格式错误，请输入6-16位字母或数字"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style4">
                    <asp:Label ID="Label4" runat="server" Text="重输密码"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" 
                        ToolTip="请再次输入设置的密码"
                        CausesValidation="True" MaxLength="16"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="TextBox3" ControlToValidate="TextBox4" 
                        ErrorMessage="*密码不一致*" BackColor="Red" Font-Bold="True" Font-Names="微软雅黑" 
                        Font-Size="Smaller" ForeColor="White" SetFocusOnError="True" 
                        ToolTip="您在此输入的密码和设置的密码不一致，请注意大小写，重新输入"></asp:CompareValidator>
                </td>
            </tr>
        </table>
        <br />
        <table style="width:100%;">
            <tr>
                <td align="right" class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style6">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Smaller" 
                        NavigateUrl="~/Login.aspx">取消注册</asp:HyperLink>
                </td>
                <td class="style7">
        <asp:Button ID="Button1" runat="server" Text="提交" Enabled="False" onclick="Button1_Click" />
    
                </td>
            </tr>
        </table>
        <br />
        
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
    </div>
    </form>
</body>
</html>
