<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RamiRami.aspx.cs" Inherits="Elite_system.RamiRami" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <!-- Bootstrap -->
    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
    <link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css' />
    
     <script type="text/javascript">
         function ShowPopup(title, body) {
             $("#MyPopup .modal-title").html(title);
             $("#MyPopup .modal-body").html(body);
             $("#MyPopup").modal("show");
         }
    </script>
    <!-- Bootstrap -->
</head>
<body>
    <form id="form1" runat="server">
        <center>
        <asp:Button ID="btnShowPopup" runat="server" Text="Show Popup" OnClick="ShowPopup"
            CssClass="btn btn-info btn-lg" />
    </center>
 
    <!-- Modal Popup -->
    <div id="MyPopup" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title">
                    </h4>
                </div>
                <div class="modal-body">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Popup -->
   
    </form>
    
</body>
</html>
