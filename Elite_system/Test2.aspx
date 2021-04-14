<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test2.aspx.cs" Inherits="Elite_system.Test2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Why Changan - Changan International</title>
  
</head>
<body >
    <form id="form1" method="post" runat="server">
        <div>
            <asp:Button ID="Button2" runat="server" Text="Save As Contact" OnClick="Button2_Click" />
            
            <br />
            <br />
            <a href="https://api.whatsapp.com/send?phone=962772823209">Click to connect 0772823209</a>
            <br />
            <br />
            <a id="MobileFace" style="display: none"  href="fb://profile/1190403084">FaceBook_Mobile</a>
            <a id="DesktopFace" style="display: none" target="_blank" href="https://www.facebook.com/PRO.RAMI">FaceBook_Labtop</a>
            <br />
             <a id="MobileInsta" style="display: none"  href="https://www.instagram.com/saif_cookery_professional/">Insta_Mobile</a>
            <a id="DesktopInsta" style="display: none" target="_blank" href="https://www.instagram.com/saif_cookery_professional/">Insta_Labtop</a>
            <br />
             <a id="MobileTwitter" style="display: none"  href="https://twitter.com/rami_rousan">Twitter_Mobile</a>
            <a id="DesktopTwitter" style="display: none" target="_blank" href="https://twitter.com/rami_rousan">Twitter_Labtop</a>
            <br />
             <a id="MobileTikTok" style="display: none"  href="https://vm.tiktok.com/ZSJMSTSuE/">TikTok_Mobile</a>
            <a id="DesktopTikTok" style="display: none" target="_blank" href="https://vm.tiktok.com/ZSJMSTSuE/">TikTok_Labtop</a>
            <br />
            <a id="Call" href="tel:00962772823209">Call </a>
            <br />
            <a id="sms" href="sms:00962772823209">SMS </a>
            <br />
                <p><button>Share MDN!</button></p>
            <br />
                 <button id="share-button">Share</button>

            <br />
       

        </div>
    </form>
    <script>
        window.onload = function myFunction() {
           

            var mobface = document.getElementById("MobileFace");
            var deskface = document.getElementById("DesktopFace");
            var mobinsta = document.getElementById("MobileInsta");
            var deskinta = document.getElementById("DesktopInsta");
            var mobtweet = document.getElementById("MobileTwitter");
            var desktweet = document.getElementById("DesktopTwitter");
            var mobtik = document.getElementById("MobileTikTok");
            var desktik = document.getElementById("DesktopTikTok");

            if (/Android|webOS|iPhone|iPad|Mac|Macintosh|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent))
            {
                // true for mobile device
                //document.write("mobile device");
                //window.location.href = 'fb://profile/1190403084';
                mobface.style.display = "block";
                mobinsta.style.display = "block";
               mobtweet.style.display = "block";
               mobtik.style.display = "block";
            }
        else
            {
                // false for not mobile device
                //document.write("not mobile device");
                //window.location.href = 'https://www.facebook.com/PRO.RAMI';
                deskface.style.display = "block";
                deskinta.style.display = "block";
                desktweet.style.display = "block";    
                desktik.style.display = "block";    
            }
        }
    </script>
  

     <script>
         let shareData = {
             title: 'MDN',
             text: 'Learn web development on MDN!',
             url: 'https://developer.mozilla.org',
         }

         const btn = document.querySelector('button');
         const resultPara = document.querySelector('.result');

         btn.addEventListener('click', () => {
             navigator.share(shareData)
                 .then(() =>
                     resultPara.textContent = 'MDN shared successfully'
                 )
                 .catch((e) =>
                     resultPara.textContent = 'Error: ' + e
                 )
         });
     </script>
   
    <script>
        var shareButton = document.getElementById('share-button');

        shareButton.addEventListener('click', function () {

            // Check if navigator.share is supported by the browser
            if (navigator.share) {
                console.log("Congrats! Your browser supports Web Share API")

                // navigator.share accepts objects which must have atleast title, text or
                // url. Any text or title or text is possible
                navigator.share({
                    title: "Bits and pieces: Web Share API article",
                    text: "Web Share API feature is awesome. You must check it",
                    url: window.location.href
                })
                    .then(function () {
                        console.log("Shareing successfull")
                    })
                    .catch(function () {
                        console.log("Sharing failed")
                    })

            } else {
                console.log("Sorry! Your browser does not support Web Share API")
            }
        })
    </script>

   
</body>
</html>


<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript"> var addthis_config = { "data_track_addressbar": true };</script>
    <script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-518a46984fa73489"
        temp_src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-518a46984fa73489"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            hello testin of add this controls  
        </div>
        <div>
            <p>
                Share Buttons
            </p>
            <div class="addthis_toolbox addthis_default_style ">
                <a class="addthis_button_tweet"></a><a class="addthis_button_pinterest_pinit"></a>
                <a class="addthis_counter addthis_pill_style"></a>
            </div>
            <script type="text/javascript"> var addthis_config = { "data_track_addressbar": true };</script>
            <script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-518a46984fa73489"
                temp_src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-518a46984fa73489"></script>
        </div>
        <div>
            <p>
                Follow Us
            </p>
            <div class="addthis_toolbox addthis_32x32_style addthis_default_style">
                <a class="addthis_button_facebook_follow" addthis:userid="YOUR-PROFILE"></a><a class="addthis_button_twitter_follow"
                    addthis:userid="YOUR-USERNAME"></a><a class="addthis_button_linkedin_follow" addthis:userid="ggdfgdf"></a><a class="addthis_button_linkedin_follow" addthis:userid="gdfg" addthis:usertype="company"></a><a class="addthis_button_google_follow" addthis:userid="gdfgd"></a><a class="addthis_button_youtube_follow"
                        addthis:userid="fdgdf"></a><a class="addthis_button_flickr_follow" addthis:userid="dfgdf"></a><a class="addthis_button_vimeo_follow" addthis:userid="dfgdf"></a><a class="addthis_button_pinterest_follow"
                            addthis:userid="gdfg"></a><a class="addthis_button_instagram_follow" addthis:userid="dfgdf"></a><a class="addthis_button_foursquare_follow" addthis:userid="dfgdf"></a><a class="addthis_button_tumblr_follow" addthis:userid="dgfgdf"></a><a class="addthis_button_rss_follow"
                                addthis:userid="gdfgdf"></a>
            </div>
            <script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-518a46984fa73489"
                temp_src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-518a46984fa73489"></script>
        </div>
        <div>
            Trending Content  
            <div id="addthis_trendingcontent">
            </div>
            <script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-518a46984fa73489"
                temp_src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-518a46984fa73489"></script>
            <script type="text/javascript">  
                addthis.box("#addthis_trendingcontent", {
                    feed_title: "fsdfsd",
                    feed_type: "trending",
                    feed_period: "month",
                    num_links: 5,
                    height: "auto",
                    width: "auto"
                });
            </script>
        </div>
        <div>
        </div>
    </form>
</body>
</html>--%>
