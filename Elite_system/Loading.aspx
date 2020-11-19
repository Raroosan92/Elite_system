<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loading.aspx.cs" Inherits="Creating_Loading_Overlay.Loading" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="css/waitMe.css" rel="stylesheet" />
   
</head>
<body>
   
    <div class="containerBlock">
        <form id="form1" runat="server">
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Btn_Run" runat="server" Text="Run" OnClick="Btn_Run_Click"  />
            
        </form>
    </div>

    <br />
    
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />

    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <br />

    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <br />

    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>


    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/waitMe.js"></script>


    <script>              
        $(function () {        
          
            $('#Btn_Run').click(function () {
                run_waitMe();
            });

            function run_waitMe() {               
                var el = $('.containerBlock');
                text = 'يرجى الانتظار';
                fontSize = '';
                maxSize = '';
                textPos = 'vertical';

                el.waitMe({
                    effect: 'roundBounce',
                    text: text,
                    bg: 'rgba(255,255,255,0.7)',
                    //color: '#000',
                    color: '#4ECDC4',
                    maxSize: maxSize,
                    waitTime: -1,
                    source: 'img.svg',
                    textPos: textPos,
                    fontSize: fontSize,
                    onClose: function (el) { }
                });
            }
        });

</script>

</body>

</html>
