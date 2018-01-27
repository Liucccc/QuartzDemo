<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button runat="server" Text="5秒后写一条日志" OnClick="Second5_Click"/>
            <asp:Button runat="server" Text="今天17:15写一条日志" OnClick="time_Click"/>

        </div>
    </form>
</body>
</html>
