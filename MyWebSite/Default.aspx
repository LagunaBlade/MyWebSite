<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWebSite.View.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Default Page</title>
    <link rel="stylesheet" type="text/css" href="CSS/DefaultPage.css" />
    <script src="Scripts/Default/cufon-yui.js" type="text/javascript"></script>
    <script src="Scripts/Default/ChunkFive_400.font.js" type="text/javascript"></script>
    <script type="text/javascript" src="Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="Scripts/Default/jquery.easing.1.3.js"></script>
    <script type="text/javascript" src="Scripts/Default/Initialize.js"></script>
    <script type="text/javascript">
        $(function () {
            var $pxs_container = $('#pxs_container');
            $pxs_container.parallaxSlider();
        });
    </script>
    <script type="text/javascript">
        Cufon.replace('h1', { textShadow: '1px 1px #000' });
        Cufon.replace('h2', { textShadow: '1px 1px #000' });
        Cufon.replace('.footer', { textShadow: '1px 1px #000' });
        Cufon.replace('.pxs_loading', { textShadow: '1px 1px #000' });
    </script>
</head>
<body>
    <form runat="server">
    <div class="wrapper">
        <h1>
            Demo Default Page
        </h1>
        <div>
            <asp:LinkButton runat="server" OnClick="Login_Click">登录</asp:LinkButton>
        </div>
    </div>
    <div id="pxs_container" class="pxs_container">
        <div class="pxs_bg">
            <div class="pxs_bg1">
            </div>
            <div class="pxs_bg2">
            </div>
            <div class="pxs_bg3">
            </div>
        </div>
        <div class="pxs_loading">
            Loading images...</div>
        <div class="pxs_slider_wrapper">
            <ul class="pxs_slider">
                <li>
                    <img src="Images/Default/1.jpg" alt="First Image" /></li>
                <li>
                    <img src="Images/Default/2.jpg" alt="Second Image" /></li>
                <li>
                    <img src="Images/Default/3.jpg" alt="Third Image" /></li>
                <li>
                    <img src="Images/Default/4.jpg" alt="Forth Image" /></li>
                <li>
                    <img src="Images/Default/5.jpg" alt="Fifth Image" /></li>
                <li>
                    <img src="Images/Default/6.jpg" alt="Sixth Image" /></li>
            </ul>
            <div class="pxs_navigation">
                <span class="pxs_next"></span><span class="pxs_prev"></span>
            </div>
            <ul class="pxs_thumbnails">
                <li>
                    <img src="Images/Default/thumbs/1.jpg" alt="First Image" /></li>
                <li>
                    <img src="Images/Default/thumbs/2.jpg" alt="Second Image" /></li>
                <li>
                    <img src="Images/Default/thumbs/3.jpg" alt="Third Image" /></li>
                <li>
                    <img src="Images/Default/thumbs/4.jpg" alt="Forth Image" /></li>
                <li>
                    <img src="Images/Default/thumbs/5.jpg" alt="Fifth Image" /></li>
                <li>
                    <img src="Images/Default/thumbs/6.jpg" alt="Sixth Image" /></li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
