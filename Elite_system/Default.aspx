<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Elite_system.Default" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc1" TagName="OpenAuthProviders" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    


    <script>function display_ct7() {
    var x = new Date()
    var ampm = x.getHours() >= 12 ? ' PM' : ' AM';
    hours = x.getHours() % 12;
    hours = hours ? hours : 12;
    hours = hours.toString().length == 1 ? 0 + hours.toString() : hours;

    var minutes = x.getMinutes().toString()
    minutes = minutes.length == 1 ? 0 + minutes : minutes;

    var seconds = x.getSeconds().toString()
    seconds = seconds.length == 1 ? 0 + seconds : seconds;

    var month = (x.getMonth() + 1).toString();
    month = month.length == 1 ? 0 + month : month;

    var dt = x.getDate().toString();
    dt = dt.length == 1 ? 0 + dt : dt;

    var x1 = dt + "/" + month + "/" + x.getFullYear();
    x1 = x1 + " - " + hours + ":" + minutes + ":" + seconds + " " + ampm;
    document.getElementById('ct7').innerHTML = x1;
    display_c7();
}
        function display_c7() {
            var refresh = 1000; // Refresh rate in milli seconds
            mytime = setTimeout('display_ct7()', refresh)
        }
        display_c7()
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-10" style="text-align:-webkit-center">
        <img src="img/EliteSystem.png" / class="img-responsive Image_Mobile" style="width:57%;margin-top: 15px;">
        <h3 style="direction:ltr;font-size: xx-large;font-weight: bold;">Tel:    07  9966  1154  /  06  5065  454  /  07  7506  5454</h3>
        <h3 style="direction:ltr;font-size: xx-large;font-weight: bold;">Amman  /  Taberbour</h3>
        <h3 style="direction:ltr;font-size: xx-large;font-weight: bold;">Shams Trading Complex  -  3d Floor  -  Office(304)</h3>
        <br />
        <span id='ct7' style="background-color: #FFFF00"></span>
        <br />
        <asp:Label ID="ServerTime" runat="server" Text="Label"></asp:Label>
    </div>

</asp:Content>

