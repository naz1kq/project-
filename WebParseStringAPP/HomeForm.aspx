<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeForm.aspx.cs" Inherits="WebParseStringAPP.HomeForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Hello</title>
    <style type="text/css">
        #form1 {
            height: 446px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:Label ID="Label2" runat="server" Text="Select file :"></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" style="margin-left: 87px" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Enter serching word:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 28px" Width="212px" OnTextChanged="ReadTextFromFile" AutoPostBack = "true"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="ClearDataBase" Text="Clear Database" />
        </p>
        <asp:ListBox ID="ListBox1" runat="server" Height="376px" Width="1124px"></asp:ListBox>
    </form>
</body>
</html>
