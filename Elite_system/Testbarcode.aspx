<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Testbarcode.aspx.cs" Inherits="Elite_system.Testbarcode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <asp:TextBox ID="StringToConvertTextBox" runat="server"></asp:TextBox>
            <br />
            <%--<img id="BarcodePictureBox" runat="server" src="data:image/gif;base64,<YOUR BASE64 DATA>" width="100" height="100"/>--%>


            <%--<div id="BarcodePictureBox" runat="server"></div>--%>
            <asp:PlaceHolder ID="BarcodePictureBox" runat="server"></asp:PlaceHolder>
            <%--<asp:ImageButton ID="BarcodePictureBox" runat=" server" />--%>
            <%--<asp:ImageMap ID="BarcodePictureBox" runat="server"></asp:ImageMap>--%>
            <%--<asp:Image ID="BarcodePictureBox" runat="server" />--%>
        </div>
    </form>
</body>
</html>
