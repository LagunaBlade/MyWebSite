<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWebSite.View.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>首页</title>
    <link href="CSS/DefaultPage.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <%--图片轮播JS和CSS引用--%>
    <link href="CSS/PicSlide/style.css" rel="stylesheet" type="text/css" />
    <link href="CSS/PicSlide/prettyPhoto.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/PicSlide/jquery.js" type="text/javascript"></script>
    <script src="Scripts/PicSlide/jquery.prettyPhoto.js" type="text/javascript"></script>
    <script src="Scripts/PicSlide/jquery.aviaSlider.min.js" type="text/javascript"></script>
    <script src="Scripts/PicSlide/custom.min.js" type="text/javascript"></script>
    <%--菜单CSS引用--%>
    <link href="CSS/Menu/menu.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Menu/style.css" rel="stylesheet" type="text/css" />
</head>
<body style="background: #00FF00 url(Images/background.jpg) no-repeat fixed top;">
    <div class="mainDiv">
        <%-- logo--%>
        <div class="logoDiv" style="background-color: Blue;">
        </div>
        <%-- menu--%>
        <div class="menuDiv">
            <div class="menu style-1">
                <ul class="menu">
                    <li><a href="http://js.itivy.com/?">Home</a></li>
                    <li><a href="http://js.itivy.com/?categories-archives/" class="arrow">Categories</a>
                        <div class="mega-menu full-width" style="z-index:999;">
                            <div class="col-1">
                                <h4>
                                    <a href="http://js.itivy.com/?category/graphics-design/">Graphic Design</a></h4>
                                <ol>
                                    <li><a href="http://js.itivy.com/?category/graphics-design/">Design</a></li>
                                    <li><a href="http://js.itivy.com/?category/logos/">Logo Design</a></li>
                                    <li><a href="http://js.itivy.com/?category/tutorials/">Tutorials</a></li>
                                    <li><a href="http://js.itivy.com/?category/mehndi-designs/">Mehndi Designs</a></li>
                                    <li><a href="http://js.itivy.com/?tag/vector-graphics/">Vector Graphics</a></li>
                                    <li><a href="http://js.itivy.com/?category/wallpapers/">Wallpapers</a></li>
                                </ol>
                            </div>
                            <div class="col-1">
                                <h4>
                                    <a href="http://js.itivy.com/?category/website-designing/">Web Design</a></h4>
                                <ol>
                                    <li><a href="http://js.itivy.com/?category/website-designing/">Website Design</a></li>
                                    <li><a href="http://js.itivy.com/?category/html5-css3/">HTML5 &amp; CSS3</a></li>
                                    <li><a href="http://js.itivy.com/?category/jquery/">jQuery</a></li>
                                    <li><a href="http://js.itivy.com/?category/javascript-2/">Javascript</a></li>
                                    <li><a href="http://js.itivy.com/?category/code/">Coding</a></li>
                                </ol>
                            </div>
                            <div class="col-1">
                                <h4>
                                    <a href="http://js.itivy.com/?tag/freebie/">Freebies</a></h4>
                                <ol>
                                    <li><a href="http://js.itivy.com/?category/fonts/">Free Fonts</a></li>
                                    <li><a href="http://js.itivy.com/?category/icons/">Icons</a></li>
                                    <li><a href="http://js.itivy.com/?category/psd-files/">Free PSD Files</a></li>
                                    <li><a href="http://js.itivy.com/?tag/free-templates/">PSD Templats</a></li>
                                    <li><a href="http://js.itivy.com/?category/software-utilities/">Software &amp; Utilities</a></li>
                                </ol>
                            </div>
                            <div class="col-1">
                                <h4>
                                    <a href="http://js.itivy.com/?tag/inspiration/">Inspiration</a></h4>
                                <ol>
                                    <li><a href="http://js.itivy.com/?tag/business-cards/">Business Cards</a></li>
                                    <li><a href="http://js.itivy.com/?category/photography-2/">Photography</a></li>
                                    <li><a href="http://js.itivy.com/?tag/poster-design/">Poster Design</a></li>
                                    <li><a href="http://js.itivy.com/?tag/typography/">Typography</a></li>
                                    <li><a href="http://js.itivy.com/?tag/illustration-art/">Illustration Art</a></li>
                                </ol>
                            </div>
                            <div class="col-1">
                                <h4>
                                    <a href="http://js.itivy.com/?category/wordpress/">Wordpress</a></h4>
                                <ol>
                                    <li><a href="http://js.itivy.com/?category/wordpress-themes/">Wordpress Themes</a></li>
                                    <li><a href="http://js.itivy.com/?tag/wordpress-plugins/">Wordpress Plugins</a></li>
                                </ol>
                            </div>
                            <div class="col-1">
                                <h4>
                                    <a href="http://js.itivy.com/?category/technology/">Technology</a></h4>
                                <ol>
                                    <li><a href="http://js.itivy.com/?category/apple/">Apple</a></li>
                                    <li><a href="http://js.itivy.com/?category/google/">Google</a></li>
                                    <li><a href="http://js.itivy.com/?category/facebook/">Facebook</a></li>
                                    <li><a href="http://js.itivy.com/?category/iphone-games/">iPhone Games</a></li>
                                    <li><a href="http://js.itivy.com/?category/mobile-app-software/">iPhone Apps</a></li>
                                </ol>
                            </div>
                        </div>
                    </li>
                    <li><a href="http://js.itivy.com/?advertise/">Advertise</a></li>
                    <li><a href="http://js.itivy.com/?write-for-us/">Write For Us</a></li>
                    <li><a href="http://js.itivy.com/?contactus/">Contact Us</a></li>
                    <li>
                        <div id="sidesearch">
                            <form id="sitesearchform" style="display: inline" method="get" action="http://js.itivy.com/?">
                            <fieldset>
                                <input class="sidesearch_input" type="text" value="e.g: Web Design" onfocus="if (this.value == 'e.g: Web Design') {this.value = '';}"
                                    x-webkit-speech="" onwebkitspeechchange="transcribe(this.value)" onblur="if (this.value == '') {this.value = 'e.g: Web Design';}"
                                    name="s" id="s">
                                <input type="image" class="sidesearch_submit" src="Images/Menu/sidesearchsubmit.png" />
                            </fieldset>
                            </form>
                        </div>
                    </li>
                    <li class="right"><a href="http://js.itivy.com/?social-share/" class="arrow">Follow
                        Us</a>
                        <ul style="z-index:999;">
                            <li><a href="http://js.itivy.com/?karachicorner" class="rss" title="Subscribe to RSS">
                                RSS</a></li>
                            <li><a href="http://sc.chinaz.com" class="twitter" title="Follow us on Twitter">Twitter</a></li>
                            <li><a href="http://sc.chinaz.com" class="facebook" title="Follow us on Facebook">Facebook</a></li>
                            <li><a href="https://sc.chinaz.com" class="googleplus" title="Follow us on Google+">
                                Google+</a></li>
                            <li><a href="http://js.itivy.com/" class="pinterest" title="Follow us on Pinterest">
                                Pinterest</a></li>
                            <li><a href="http://sc.chinaz.com" class="stumbleupon" title="Follow us on Stumbleupon">
                                Stumbleupon</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
        <%-- slidepic--%>
        <div class="slidePicDiv">
            <div class="center">
                <ul class='aviaslider' id="droping-curtain">
                    <li><a href="" title="">
                        <img src="Images/PicSlide/1.jpg" alt="AAAAAAAAAAAAAAAAAAAAAAAA" /></a></li>
                    <li><a href="" title="">
                        <img src="Images/PicSlide/2.jpg" alt="A heading of your choice :: This is the image description defined in your alt tag" /></a></li>
                    <li><a href="" title="">
                        <img src="Images/PicSlide/3.jpg" alt="Another heading :: Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor" /></a></li>
                    <li><a href="" title="">
                        <img src="Images/PicSlide/4.jpg" alt="No Heading, just a line of content" /></a></li>
                    <li><a href="" title="">
                        <img src="Images/PicSlide/5.jpg" alt="fdsghsdfgdsh" /></a></li>
                </ul>
            </div>
        </div>
        <%--content--%>
        <div class="contentDiv" style="background-color: Gray;">
        </div>
        <%--footer--%>
        <div class="footerDiv">
            <div class="footer-bg">
                <div class="container_12">
                    <div class="wrapper">
                        <div class="grid_12">
                            <div class="footer-padding">
                                <div class="wrapper">
                                    <span class="footer-link"><span>www.laguna-balde.com &copy; 2015</span> <a rel="nofollow"
                                        target="_blank" class="link" href="http://www.laguna-blade.com/" style="color:#93ceee; outline:none;">Website </a>
                                        by Sweet_Nail</span>
                                    <ul class="list-services">
                                        <li><a class="tooltips n-1" title="Twitter" href="#"></a></li>
                                        <li><a class="tooltips n-2" title="Facebook" href="#"></a></li>
                                        <li class="last"><a class="tooltips n-3" title="Youtube" href="#"></a></li>
                                    </ul>
                                </div>
                                <div class="aligncenter">
                                    <!-- {%FOOTER_LINK} -->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
