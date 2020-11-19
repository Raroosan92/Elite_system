<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Load.aspx.cs" Inherits="Elite_system.Load" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="containerBlock">
        
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
           
        
    </div>
     <asp:Button ID="Btn_Run" runat="server" Text="Run" OnClick="Btn_Run_Click"  />
           
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

</asp:Content>
