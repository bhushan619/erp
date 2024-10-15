<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="product" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
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
     <form id="g" runat="server">
   <header>
  <div class="container-fluid b-header__box b-relative">      
    <a href="Default.aspx" class="b-left b-logo "><img class="color-theme" data-retina src="images/Logo/Logo.png" alt="Logo" height="75" width="300" /></a>

    <div class="b-header-r  b-header-r--icon"> 
          <div class="b-top-nav-show-slide f-top-nav-show-slide  j-top-nav-show-slide"><i class="fa fa-align-justify"></i></div>
                <nav class="b-top-nav f-top-nav  j-top-nav navbar-example" id="myNavbar">
                    <ul class="b-top-nav__1level_wrap">
                        <li class="b-top-nav__1level f-top-nav__1level f-primary-b" >
                            <a href="Default.aspx#home">Home</a>
                        </li>
                        <li class="b-top-nav__1level f-top-nav__1level f-primary-b"  >
                            <a href="Default.aspx#about">About us</a>
                        </li>
                   <li class="b-top-nav__1level f-top-nav__1level f-primary-b">
                            <a href="product.aspx" style=" -moz-border-radius: 13px;
    -webkit-border-radius: 13px;
    border-radius: 13px;
    background: #253C58;color:#fff">Products</a>
                        </li> 
                        <li class="b-top-nav__1level f-top-nav__1level f-primary-b" >
                            <a href="Default.aspx#contact">Contact us</a>
                        </li> 
                         
                           <li class="b-top-nav__1level f-top-nav__1level f-primary-b">
                           <a href="SignUpLogin.aspx">Sign Up / Login</a>
                        </li>
                       <li class="b-top-nav__1level f-top-nav__1level f-primary-b" >
                               <a href="Default.aspx" style="
    margin-top: -30px;
" ><img class="color-theme" data-retina src="images/Logo/sang-v.png" alt="Logo" height="75" width="300" /></a>
 
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
                <h1 class="f-primary-l c-default">OUR PRODUCTS</h1>
            </div>
        </div>
    </div>
    <div class="l-main-container">
       
          
            <section class="b-infoblock">
        <div class="container">
            <div class="row">

                <div class="b-inner-page-header__content">
                    <div class="col-md-3">
                        <aside>
                            <div class="row b-col-default-indent">



                                <div class="b-categories-filter">
                                    <h4 class="f-primary-b b-h4-special f-h4-special c-primary">OUR PRODUCT RANGE</h4>
                                    <ul>
                                        <!--category-productsr-->
                                        <li>
                                            <a data-toggle="collapse" data-parent="#accordian" href="#sportswear">
                                                <i class="fa fa-plus"></i>
                                                Unbreakables
                                            </a>
                                        </li>

                                        <ul id="sportswear" class="panel-collapse collapse">
                                            <li class="panel-body">
                                                <ul>
                                                    <li><a href="#GHAMELA">GHAMELA RANGE</a></li>
                                                    <li><a href="#TAGARI">TAGARI RANGE </a></li>
                                                    <li><a href="#TUB">TUB & DALA RANGE</a></li>
                                                    <li><a href="#MUG">MUG/STOOL/PATLA RANGE</a></li>
                                                    <li><a href="#BUCKET">BUCKET RANGE </a></li>
                                                    <li><a href="#DUSTBIN">DUSTBIN WITH LID RANGE</a></li>
                                                    <li><a href="#OTHER">OTHER UTILITIES </a></li>
                                                    <li><a href="#MILK ">MILK CAN RANGE</a></li>
                                                    <li><a href="#CRATE">CRATE/TRAY RANGE </a></li>
                                                    <li><a href="#GHAGHAR">GHAGHAR RANGE </a></li>
                                                    <li><a href="#MAN">MAN HOLE COVER </a></li>
                                                </ul>
                                            </li>
                                        </ul>
                                        </ul>
                            <ul>
                                            <li>
                                                <a data-toggle="collapse" data-parent="#accordian" href="#mens">
                                                    <i class="fa fa-plus"></i>
                                                     PVC FITTINGS
                                                </a>
                                            </li>

                                        <ul id="mens" class="panel-collapse collapse">
                                            <li class="panel-body">
                                                <ul>
                                                     <li><a href="#AGRI">AGRI</a></li>
                                                      <li><a href="#SANG-V">SANG-V ECO</a></li>
                                                    <li><a href="#SWR">SWR</a></li>
                                                    <li><a href="#UPVC">UPVC</a></li> 
                                                </ul>
                                            </li>
                                        </ul>
                             </ul>


                                    </><!--/category-products-->
                                    <!--/shipping-->

                                </div>


                            </div>


                        </aside>
                    </div>
                    <div class="container">
                        <div class="col-md-9">
                            <h1 id="GHAMELA" class="f-primary-sb f-page-header_title-add c-white text-center" style="background-color: #253C58; height: 50px; padding-top: 10px">Plastic Range </h1>
     <h1 class="f-primary-sb c-DarkBule" style="background-color: #d3cccc; color: #1e2224; padding-left: 20px; margin-top: -10px;">GHAMELA Range</h1>
                            <div class="row" >
                                <div class="b-col-default-indent">
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/MULTY 10inch.PNG" alt="" />
                                            <div class="b-item-hover-action f-center mask">
                                                <div class="b-item-hover-action__inner">
                                                    <div class="b-item-hover-action__inner-btn_group">


                                                        <asp:LinkButton Text="Ask Price" ID="lnkFake" OnClick="View" runat="server" class="b-btn f-btn b-btn-light f-btn-light info fa fa-money" />

                                                    </div>
                                                </div>
                                            </div>



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">MULTY 10"</a>

                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/FALHAR 13 inch.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">FALHAR 13"</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/SADA-BAHAR 16 inch.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">PAHADI 16"</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/SADA-BAHAR 16 inch.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">SADA-BAHAR 16"</a>

                                            </div>

                                        </div>
                                    </div>
                                    <hr class="b-hr" />
                                    <div class="clearfix hidden-xs"></div>
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/CHATTAN  16 inch.jpg" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">CHATTAN  16"</a>

                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/FOULAD 17inch.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">FOULAD 17"</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/SHAKTIMAN 19inch.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">SHAKTIMAN 19"</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/KING 21inch.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">KING 21"</a>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
  <h1 id="TAGARI" class="f-primary-sb c-DarkBule" style="background-color:#d3cccc;color:#1e2224;padding-left:20px;" >TAGARI RANGE</h1>
                            <div class="row">


                                <div class="b-col-default-indent">
                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/HARKAAM 16inch.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">HARKAAM 16"</a>

                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/BHUMI 17inch.jpg" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">BHUMI 17"</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/JAMBO 18inch.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">JAMBO 18"</a>

                                            </div>

                                        </div>
                                    </div>


                                </div>
                            </div>
                             <h1   id="TUB"class="f-primary-sb c-DarkBule" style="background-color:#d3cccc;color:#1e2224;padding-left:20px;">TUB & DALA RANGE</h1>
                            <div class="row">
                                <div class="b-col-default-indent">
                                         <%--   <div class="col-md-2 col-sm-2 col-xs-2 col-mini-12">

                                        <div class="b-product-preview__img view view-eighth">
                                            <img data-retina src="Personnel/admin/media/product/Unbreakable/MULTY PURPOSE 20 Ltr.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">MULTYPURPOSE 20Ltr</a>

                                            </div>

                                        </div>
                                    </div>

                                     <div class="col-md-2 col-sm-2 col-xs-2 col-mini-12">

                                        <div class="b-product-preview__img view view-eighth">
                                            <img data-retina src="Personnel/admin/media/product/ALLROUNDER35Ltr.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">ALL ROUNDER 35 LTR</a>

                                            </div>

                                        </div>
                                    </div>
                        <div class="col-md-2 col-sm-2 col-xs-2 col-mini-12">

                                        <div class="b-product-preview__img view view-eighth">
                                            <img data-retina src="Personnel/admin/media/product/Unbreakable/MULTI-USE TUB 45 L.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">MULTI-USE TUB 45 LTR</a>

                                            </div>

                                        </div>
                                    </div>
                                   <div class="col-md-2 col-sm-2 col-xs-2 col-mini-12">

                                        <div class="b-product-preview__img view view-eighth">
                                            <img data-retina src="Personnel/admin/media/product/Unbreakable/NAKUL 50 L.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">NAKUL 50 LTR</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-2 col-xs-2 col-mini-12 col-lg-pull-0">

                                        <div class="b-product-preview__img view view-eighth">
                                            <img data-retina src="Personnel/admin/media/product/NoProfile.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">SAHADEV 70 LTR</a>

                                            </div>

                                        </div>
                                    </div>--%>
                                    <div class="col-md-12 col-sm-12 col-xs-12 col-mini-12">

                                        <div class="b-product-preview__img view view-eighth">
                                            <img data-retina src="Personnel/admin/media/product/TUB.png" alt="" />
                                            




                                        </div>
                                    </div>
                                    <hr class="b-hr" />
                                    <div class="clearfix hidden-xs"></div>
                                      

                                    <div class="col-md-4 col-sm-4 col-xs-4 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/CHOTA BHIM 35 Ltr_.jpg" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">CHOTA BHIM 35 LTR</a>

                                            </div>

                                        </div>
                                    </div>
                                   <div class="col-md-4 col-sm-4 col-xs-4 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/ARJUN-DALA.jpg" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">ARJUN DALA 50 LTR</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-4 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/BHIM ROUND 65 Ltr_.jpg" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">BHIM ROUND 65 LTR</a>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
  <h1 id="MUG" class="f-primary-sb c-DarkBule" style="background-color:#d3cccc;color:#1e2224;padding-left:20px;" >MUG/STOOL/PATLA RANGE</h1>
                            <div class="row">


                                <div class="b-col-default-indent">
                                    
                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12 ">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/RAJKUMAR MUG 750 ml_.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">RajKumar Mug 750ml</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12 col-lg-push-3">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/SAMRAT MUG 1Ltr_.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">SAMRAT MUG 1Ltr."</a>

                                            </div>

                                        </div>
                                    </div>
                                     <hr class="b-hr" />
                                    <div class="clearfix hidden-xs"></div>
                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12 ">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/GIRIRAJ.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">GIRIRAJ BATH-STOOL</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12 ">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/YUVRAJ PATLA.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">YUVRAJ PATLA</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12 ">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/Round Stool.jpg" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">Round Stool</a>

                                            </div>

                                        </div>
                                    </div>

                                </div>
                            </div>
                            <h1 id="BUCKET" class="f-primary-sb c-DarkBule" style="background-color:#d3cccc;color:#1e2224;padding-left:20px;">BUCKET RANGE</h1>
                            <div class="row" >
                                <div class="b-col-default-indent">
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/MONA 3 Ltr_.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">MONA 3 Ltr.</a>

                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/CHOTU 5 Ltr_.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">CHOTU 5 Ltr."</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/RAJU 7 Ltr_.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">RAJU 7 Ltr.</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/PRINCE 10 Ltr_.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">PRINCE 10 Ltr."</a>

                                            </div>

                                        </div>
                                    </div>
                                    <hr class="b-hr" />
                                    <div class="clearfix hidden-xs"></div>
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/LION 13 Ltr_.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">LION 13 Ltr.</a>

                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/MAHARANI 16 Ltr_.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">MAHARANI 16 Ltr."</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/JAMBO 20 Ltr_.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">JAMBO 20 Ltr."</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/MAHARAJA BUCKET 25 L.JPG" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">MAHARAJA BUCKET 25 Ltr"</a>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>

                               <h1 id="DUSTBIN" class="f-primary-sb c-DarkBule" style="background-color:#d3cccc;color:#1e2224;padding-left:20px;">DUSTBIN WITH LID RANGE</h1>
                            <div class="row">


                                <div class="b-col-default-indent">
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/Dust Bin 15 L.jpg" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">Dustbin 5Ltr</a>

                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/Dust Bin 15 L.jpg" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">Dustbin 7.5 Ltr</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/Dust Bin 15 L.jpg" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">Dustbin 10Ltr</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/Dust Bin 15 L.jpg" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">Dustbin 15Ltr</a>

                                            </div>

                                        </div>
                                    </div>

                                     <hr class="b-hr" />
                                    <div class="clearfix hidden-xs"></div>
                                           
                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12 ">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/DUST BIN 25 L.JPG" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">DUST BIN 25 L</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12 col-lg-push-3">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/DUST BIN 60 L.JPG" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">DUST BIN 60 Ltr</a>

                                            </div>

                                        </div>
                                    </div>

                                </div>
                            </div>
                             <h1 id="OTHER" class="f-primary-sb c-DarkBule" style="background-color:#d3cccc;color:#1e2224;padding-left:20px;">OTHER UTILITIES</h1>
                            <div class="row" >
                                <div class="b-col-default-indent">
                                    <div class="col-md-12 col-sm-12 col-xs-12 col-mini-12">

                                        <div class="b-product-preview__img view view-eighth">
                                            <img data-retina src="Personnel/admin/media/product/Other.png" alt="" />
                                            




                                        </div>
                                    </div>
                                
                                  
                                     <hr class="b-hr" />
                                    <div class="clearfix hidden-xs"></div>
                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/Unbreakable/SPECIAL POT STAND.jpg" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">SPECIAL POT STAND</a>

                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/Gas Cylinder Trolley.jpg" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">GAS CYLINDER TROLLEY.</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/waterjug.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">water jug.</a>

                                            </div>

                                        </div>
                                    </div>
                      
                                </div>
                            </div>
                           <h1 id="MILK" class="f-primary-sb c-DarkBule" style="background-color:#d3cccc;color:#1e2224;padding-left:20px;" >MILK CAN</h1>
                            <div class="row">


                                <div class="b-col-default-indent">
                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/CAN.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title"> Milk CAN 3.5ltr</a>

                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-md-4 col-sm-3  col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/CAN.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">Milk CAN 5 ltr"</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/CAN.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">Milk CAN 7.5 ltr"</a>

                                            </div>

                                        </div>
                                    </div>
                                      <hr class="b-hr" />
                                    <div class="clearfix hidden-xs"></div>
                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/CAN.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">Milk CAN 10 ltr"</a>

                                            </div>

                                        </div>
                                    </div>
                                 <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/CAN.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">Milk CAN 15 ltr"</a>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                             <h1 id="CRATE" class="f-primary-sb c-DarkBule" style="background-color:#d3cccc;color:#1e2224;padding-left:20px;">CRATE/TRAY RANGE</h1>
                            <div class="row" >
                                <div class="b-col-default-indent">
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/FRUITCRATE.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">FRUIT CRATE</a>

                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/MILK CRATE.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">MILK CRATE</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/Hydra Tray.jpg" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">HYDRA-TRAY OR A-ONE CRATE</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/ALUM TRAY.jpg" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">ALUM TRAY</a>

                                            </div>

                                        </div>
                                    </div>
                                    
                                </div>
                            </div>
              <h1 id="GHAGHRA" class="f-primary-sb c-DarkBule" style="background-color:#d3cccc;color:#1e2224;padding-left:20px;" >GHAGHRA RANGE</h1>
                            <div class="row">
                         <div class="b-col-default-indent">
                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/GANESH  10 Ltr_.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">GANESH 10 Ltr"</a>

                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/YAMUNA 15 Ltr_.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">YAMUNA 15 Ltr</a>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-3 col-xs-3 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/NARMADA 17 Ltr_.png" alt="" />
                                            



                                            <div class="b-product-preview__content_col">
                                                <a href="#" class="f-product-preview__content_title">NARMADA 17 Ltr</a>

                                            </div>

                                        </div>
                                    </div>
                                    

                                </div>
                            </div>
              <h1 id="MAN" class="f-primary-sb c-DarkBule" style="background-color:#d3cccc;color:#1e2224;padding-left:20px;" >MAN HOLE COVER</h1>
                            <div class="row">
                     <div class="b-col-default-indent">
                                  <div class="col-md-12 col-sm-12 col-xs-12 col-mini-12">

                                        <div class="b-product-preview__img view view-eighth">
                                            <img data-retina src="Personnel/admin/media/product/MANHOLE.png" alt="" />
                                            




                                        </div>
                                    </div>



                                </div>
                            

                    </div>
                           <h1 class="f-primary-sb f-page-header_title-add c-white " style="background-color: #253C58; height: 50px; padding-top: 10px">AGRI</h1>
 
                               <div class="row" id="AGRI">
                                <div class="b-col-default-indent">
                                    <div class="col-md-12 col-sm-12 col-xs-12 col-mini-12">

                                        <div class="b-product-preview__img view view-eighth">
                                            <img data-retina src="Personnel/admin/media/product/Agri Fitting/4 Kg/New 4 Kg/AGR.png" alt="" />
                                            




                                        </div>
                                    </div>
                             </div>
                         
</div>



 <h1 id="SANG-V" class="f-primary-sb f-page-header_title-add c-white " style="background-color: #253C58; height: 50px; padding-top: 10px">SANG-V ECO</h1>
      <div class="row" >


                                <div class="b-col-default-indent">
                                    <div class="col-md-12 col-sm-12 col-xs-12 col-mini-12">

                                        <div class="b-product-preview__img view view-sixth">
                                            <img data-retina src="Personnel/admin/media/product/Agri Fitting/4 Kg/New 4 Kg/SANG-V.png" alt="" />
                                            



                                            

                                        </div>
                                    </div>
                                  


                                </div>
                            </div>
                       <h1 id="SWR"class="f-primary-sb f-page-header_title-add c-white " style="background-color: #253C58; height: 50px; padding-top: 10px">SWR FITTINGS</h1>
                                     <div class="row">
                                <div class="b-col-default-indent">
                                            <div class="col-md-12 col-sm-12 col-xs-12 col-mini-12">

                                        <div class="b-product-preview__img view view-eighth">
                                            <img data-retina src="Personnel/admin/media/product/Agri Fitting/4 Kg/New 4 Kg/SWR1.png" alt="" />
                                            




                                        </div>
                                    </div>

                     
                                      
                                    <div class="col-md-12 col-sm-12 col-xs-12 col-mini-12">

                                        <div class="b-product-preview__img view view-eighth">
                                            <img data-retina src="Personnel/admin/media/product/Agri Fitting/4 Kg/New 4 Kg/SWR2.png" alt="" />
                                            




                                        </div>
                                    </div>
                                </div>
                            </div>

    <h1 id="UPVC"class="f-primary-sb f-page-header_title-add c-white " style="background-color: #253C58; height: 50px; padding-top: 10px">UPVC FITTINGS</h1>
                                               <div class="row">
                         <div class="b-col-default-indent">
                                    <div class="col-md-12 col-sm-12 col-xs-12 col-mini-12">

                                        <div class="b-product-preview__img view view-eighth">
                                            <img data-retina src="Personnel/admin/media/product/Agri Fitting/4 Kg/New 4 Kg/UPVC.png" alt="" />
                                            




                                        </div>
                                    </div>
                                 

                                </div>
                            </div>
                             </div>
                        
                    </div>





                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

  <cc1:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="lnkFake"
                        CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
                        <div class="header">
                            Enquiry Details
                        </div>
                        <div role="form">
                            <div class="form-group">
                                <h4>Please send me the latest price and details of 
                '<asp:Label ID="lblId" runat="server" />'. </h4>
                            </div>
                            <div class="form-group">
                                Email : 
                <asp:TextBox ID="txtEmail" runat="server" pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)"
                    required CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                Mobile : 
                <asp:TextBox ID="txtMobile" required onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group text-right">
                                <asp:Button ID="btnSaves" runat="server" Text="Ask Price" OnClick="Save" CssClass="btn btn-primary" />
                                <asp:LinkButton ID="btnClose" runat="server" Text="Close" CssClass="btn btn-danger" />
                            </div>
                        </div>

                    </asp:Panel>

                </div>
            </div>
        </div>

    </section>
       
    </div>
         </form>
    <footer>
        <div class="b-footer-primary">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4 col-xs-12 f-copyright b-copyright">Copyright © 2017 - All Rights Reserved<br />
                        Designed by : <a target="_blank" href="http://www.anuvaasoft.com">Anuvaa Softech Pvt. Ltd.</a></div>
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
                            <a href="#product.aspx">Products</a>
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
