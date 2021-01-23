<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Elite_system.Test1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Btn_Backup" runat="server" Text="Backup" OnClick="Btn_Backup_Click" />
             <asp:Label ID="lblMessage" runat="server" Font-Size="X-Large" ForeColor="Red"></asp:Label>
       <asp:ListBox ID="lstBackupfiles" runat="server" Height="257px" Width="368px" style="margin-left: 21px; text-align: left;"></asp:ListBox>
    
        </div>
    </form>
</body>
</html>
