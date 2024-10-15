<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUpLogin.aspx.cs" Inherits="SignUpLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8">
    <title>Sanghavi.org</title>
    <link rel="shortcut icon" href="favicon.ico">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet">
    <!-- bxslider -->
    <link type="text/css" rel='stylesheet' href="js/bxslider/jquery.bxslider.css">
    <!-- End bxslider -->
    <!-- flexslider -->
    <link type="text/css" rel='stylesheet' href="js/flexslider/flexslider.css">
    <!-- End flexslider -->

    <!-- bxslider -->
    <link type="text/css" rel='stylesheet' href="js/radial-progress/style.css">
    <!-- End bxslider -->

    <!-- Animate css -->
    <link type="text/css" rel='stylesheet' href="css/animate.css">
    <!-- End Animate css -->

    <!-- Bootstrap css -->
    <link type="text/css" rel='stylesheet' href="css/bootstrap.min.css">
    <link type="text/css" rel='stylesheet' href="js/bootstrap-progressbar/bootstrap-progressbar-3.2.0.min.css">
    <!-- End Bootstrap css -->

    <!-- Jquery UI css -->
    <link type="text/css" rel='stylesheet' href="js/jqueryui/jquery-ui.css">
    <link type="text/css" rel='stylesheet' href="js/jqueryui/jquery-ui.structure.css">
    <!-- End Jquery UI css -->

    <!-- Fancybox -->
    <link type="text/css" rel='stylesheet' href="js/fancybox/jquery.fancybox.css">
    <!-- End Fancybox -->

    <link type="text/css" rel='stylesheet' href="fonts/fonts.css">
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800&subset=latin,cyrillic-ext' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Merriweather:400,300,300italic,400italic,700,700italic,900,900italic' rel='stylesheet' type='text/css'>

    <link type="text/css" data-themecolor="default" rel='stylesheet' href="css/main-default.css">

    <link type="text/css" rel='stylesheet' href="js/rs-plugin/css/settings.css">
    <link type="text/css" rel='stylesheet' href="js/rs-plugin/css/settings-custom.css">
    <link type="text/css" rel='stylesheet' href="js/rs-plugin/videojs/video-js.css">
</head>
<body>
    <div class="mask-l" style="background-color: #fff; width: 100%; height: 100%; position: fixed; top: 0; left: 0; z-index: 9999999;"></div>
    <!--removed by integration-->
    <header>
        <div class="container-fluid b-header__box b-relative">
            <a href="Default.aspx" class="b-left b-logo ">
                <img class="color-theme" data-retina src="images/Logo/Logo.png" alt="Logo" height="75" width="300" /></a>

            <div class="b-header-r  b-header-r--icon">
                <div class="b-top-nav-show-slide f-top-nav-show-slide  j-top-nav-show-slide"><i class="fa fa-align-justify"></i></div>
                <nav class="b-top-nav f-top-nav  j-top-nav navbar-example" id="myNavbar">
                    <ul class="b-top-nav__1level_wrap">
                        <li class="b-top-nav__1level f-top-nav__1level f-primary-b"  >
                            <a href="Default.aspx#home">Home</a>
                        </li>
                        <li class="b-top-nav__1level f-top-nav__1level f-primary-b" >
                            <a href="Default.aspx#about">About us</a>
                        </li>
                        <li class="b-top-nav__1level f-top-nav__1level f-primary-b">
                            <a href="product.aspx">Products</a>
                        </li>
                        <li class="b-top-nav__1level f-top-nav__1level f-primary-b"  >
                            <a href="Default.aspx#contact">Contact us</a>
                        </li>

                        <li class="b-top-nav__1level f-top-nav__1level f-primary-b" >
                            <a href="SignUpLogin.aspx" style=" -moz-border-radius: 13px;
    -webkit-border-radius: 13px;
    border-radius: 13px;
    background: #253C58;color:#fff">Sign Up / Login</a>
                        </li>
                        <li class="b-top-nav__1level f-top-nav__1level f-primary-b">
                            <a href="Default.aspx" style="margin-top: -30px;">
                                <img class="color-theme" data-retina src="images/Logo/sang-v.png" alt="Logo" height="75" width="300" /></a>

                        </li>
                    </ul>
                </nav>

            </div>

        </div>
    </header>
    <div class="j-menu-container"></div>
    <div class="b-inner-page-header f-inner-page-header b-bg-header-inner-page">
        <div class="b-inner-page-header__content">
            <div class="container">
                <h1 class="f-primary-l c-default">Sign up / Login</h1>
            </div>
        </div>
    </div>
    <div class="l-main-container">
        <div class="b-breadcrumbs f-breadcrumbs">
            <div class="container">
                <ul>
                    <li><a href="page_log_in_page_v2.html#"><i class="fa fa-home"></i>Home</a></li>
                    <li><i class="fa fa-angle-right"></i><span>Sign up / Login</span></li>
                </ul>
            </div>
        </div>
        <div class="container b-container-login-page">
            <div class="row">
                <div class="col-md-6">
                    <div class="b-log-in-form">
                        <div class="f-primary-l f-title-big c-secondary">Login Here</div>

                        <hr class="b-hr" />
                        <form method="post" action="Log.aspx">
                            <div class="b-form-row b-form-inline b-form-horizontal">
                                <div class="col-xs-12">
                                    <div class="b-form-row">
                                        <label class="b-form-horizontal__label" for="create_account_email">Your Email</label>
                                        <div class="b-form-horizontal__input">
                                            <input type="email" placeholder="Email Address" name="uname" class="form-control" required />
                                        </div>
                                    </div>
                                    <div class="b-form-row">
                                        <label class="b-form-horizontal__label" for="create_account_password">Your password</label>
                                        <div class="b-form-horizontal__input">
                                            <input type="password" placeholder="Password" name="pass" class="form-control" required />
                                        </div>
                                    </div>
                                    <div class="b-form-row">
                                        <div class="b-form-horizontal__label"></div>
                                        <label for="contact_form_copy" class="b-contact-form__window-form-row-label">
                                            <input type="checkbox" id="contact_form_copy" class="b-form-checkbox" />
                                            <span>Remember me</span>&nbsp;&nbsp;&nbsp;&nbsp; <a href="RetrievePassword.aspx">Forgot Password?</a>
                                        </label>

                                    </div>
                                    <div class="b-form-row">
                                        <div class="b-form-horizontal__label"></div>
                                        <div class="b-form-horizontal__input">
                                            <button type="submit" class="b-btn f-btn b-btn-md b-btn-default f-primary-b b-btn__w100">Login</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="b-log-in-form">
                        <div class="f-primary-l f-title-big c-secondary">New User Signup!</div>

                        <hr class="b-hr" />
                        <form id="g" runat="server">
                            <div class="b-form-row b-form-inline b-form-horizontal">
                                <div class="col-xs-12">
                                    <div class="b-form-row">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Sign up as"></asp:Label>&nbsp; &nbsp; </td>
                                                <td>
                                                    <input type="radio" id="rdbEmployee" runat="server" name="desig" value="employee" required />&nbsp;<label> Employee</label>
                                                </td>
                                                <td>
                                                    <input type="radio" name="desig" value="customer" id="rdbCustomer" runat="server" required />&nbsp;<label>Customer</label>

                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="b-form-row">
                                        <asp:TextBox ID="txtName" runat="server" placeholder="Name"
                                            required="required" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="b-form-row">
                                        <asp:TextBox ID="txtMail"
                                            pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)"
                                            runat="server" placeholder="Email Address" Required CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="b-form-row">
                                        <asp:TextBox ID="txtPasswd" runat="server" placeholder="Password"
                                            onkeyup="checkPassCol(); return false;" TextMode="Password" required="required" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="b-form-row">
                                        <asp:TextBox ID="txtConfirmPass" runat="server" placeholder="Confirm Password"
                                            onkeyup="checkPassCol(); return false;" TextMode="Password"
                                            required="required" CssClass="form-control "></asp:TextBox>
                                    </div>
                                    <div class="b-form-row">
                                        <asp:TextBox ID="txtMobile" runat="server" placeholder="Mobile No."
                                            pattern="[7-9]{1}[0-9]{9}" required="required"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="b-form-row">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Signup"
                                            OnClick="btnSubmit_Click" class="b-btn f-btn b-btn-md b-btn-default f-primary-b b-btn__w100"></asp:Button>
                                        <br />
                                        <asp:Label ID="lblError" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <footer>
        <div class="b-footer-primary">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4 col-xs-12 f-copyright b-copyright">
                        Copyright © 2017 - All Rights Reserved<br />
                        Designed by : <a target="_blank" href="http://www.anuvaasoft.com">Anuvaa Softech Pvt. Ltd.</a>
                    </div>
                    <div class="col-sm-8 col-xs-12">
                        <div class="b-btn f-btn b-btn-default b-right b-footer__btn_up f-footer__btn_up j-footer__btn_up">
                            <i class="fa fa-chevron-up"></i>
                        </div>
                        <nav class="b-bottom-nav f-bottom-nav b-right hidden-xs">
                            <ul>

                               <li class="b-top-nav__1level f-top-nav__1level f-primary-b"  >
                            <a href="Default.aspx#home">Home</a>
                        </li>
                        <li class="b-top-nav__1level f-top-nav__1level f-primary-b" >
                            <a href="Default.aspx#about">About us</a>
                        </li>
                        <li class="b-top-nav__1level f-top-nav__1level f-primary-b">
                            <a href="product.aspx">Products</a>
                        </li>
                        <li class="b-top-nav__1level f-top-nav__1level f-primary-b"  >
                            <a href="Default.aspx#contact">Contact us</a>
                        </li>
                                         <li class="b-top-nav__1level f-top-nav__1level f-primary-b"  >
                                  <a href="SignUpLogin.aspx"><i class="fa fa-folder-open b-menu-1level-ico"></i>Sign Up / Login</a>
</li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>

    </footer>
    <script src="js/breakpoints.js"></script>
    <script src="js/jquery/jquery-1.11.1.min.js"></script>
    <!-- bootstrap -->
    <script src="js/scrollspy.js"></script>
    <script src="js/bootstrap-progressbar/bootstrap-progressbar.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!-- end bootstrap -->
    <script src="js/masonry.pkgd.min.js"></script>
    <script src='js/imagesloaded.pkgd.min.js'></script>
    <!-- bxslider -->
    <script src="js/bxslider/jquery.bxslider.min.js"></script>
    <!-- end bxslider -->
    <!-- flexslider -->
    <script src="js/flexslider/jquery.flexslider.js"></script>
    <!-- end flexslider -->
    <!-- smooth-scroll -->
    <script src="js/smooth-scroll/SmoothScroll.js"></script>
    <!-- end smooth-scroll -->
    <!-- carousel -->
    <script src="js/jquery.carouFredSel-6.2.1-packed.js"></script>
    <!-- end carousel -->
    <script src="js/rs-plugin/js/jquery.themepunch.plugins.min.js"></script>
    <script src="js/rs-plugin/js/jquery.themepunch.revolution.min.js"></script>
    <script src="js/rs-plugin/videojs/video.js"></script>

    <!-- jquery ui -->
    <script src="js/jqueryui/jquery-ui.js"></script>
    <!-- end jquery ui -->
    <script type="text/javascript" language="javascript"
        src="http://maps.google.com/maps/api/js?sensor=false&key=AIzaSyCfVS1-Dv9bQNOIXsQhTSvj7jaDX7Oocvs"></script>
    <!-- Modules -->
    <script src="js/modules/sliders.js"></script>
    <script src="js/modules/ui.js"></script>
    <script src="js/modules/retina.js"></script>
    <script src="js/modules/animate-numbers.js"></script>
    <script src="js/modules/parallax-effect.js"></script>
    <script src="js/modules/settings.js"></script>
    <script src="js/modules/maps-google.js"></script>
    <script src="js/modules/color-themes.js"></script>
    <!-- End Modules -->

    <!-- Audio player -->
    <script type="text/javascript" src="js/audioplayer/js/jquery.jplayer.min.js"></script>
    <script type="text/javascript" src="js/audioplayer/js/jplayer.playlist.min.js"></script>
    <script src="js/audioplayer.js"></script>
    <!-- end Audio player -->

    <!-- radial Progress -->
    <script src="js/radial-progress/jquery.easing.1.3.js"></script>
    <script src="http://cdnjs.cloudflare.com/ajax/libs/d3/3.4.13/d3.min.js"></script>
    <script src="js/radial-progress/radialProgress.js"></script>
    <script src="js/progressbars.js"></script>
    <!-- end Progress -->

    <!-- Google services -->
    <script type="text/javascript" src="https://www.google.com/jsapi?autoload={'modules':[{'name':'visualization','version':'1','packages':['corechart']}]}"></script>
    <script src="js/google-chart.js"></script>
    <!-- end Google services -->
    <script src="js/j.placeholder.js"></script>

    <!-- Fancybox -->
    <script src="js/fancybox/jquery.fancybox.pack.js"></script>
    <script src="js/fancybox/jquery.mousewheel.pack.js"></script>
    <script src="js/fancybox/jquery.fancybox.custom.js"></script>
    <!-- End Fancybox -->
    <script src="js/user.js"></script>
    <script src="js/timeline.js"></script>
    <script src="js/fontawesome-markers.js"></script>
    <script src="js/markerwithlabel.js"></script>
    <script src="js/cookie.js"></script>
    <script src="js/loader.js"></script>
    <script src="js/scrollIt/scrollIt.min.js"></script>
    <script src="js/modules/navigation-slide.js"></script>

</body>
</html>
