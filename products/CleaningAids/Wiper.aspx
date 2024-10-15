<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="Wiper.aspx.cs" Inherits="products_CleaningAids_Wiper" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
      <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="" />
    <meta name="author" content="anuvaasoft.com" />
    <title>Wiper | Sanghavi Polymers | Unbreakables, PVC, Solar, Cleaning Aids</title>
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../css/prettyPhoto.css" rel="stylesheet" />
    
    <link href="../../css/price-range.css" rel="stylesheet" />
    <link href="../../css/animate.css" rel="stylesheet" />
	<link href="../../css/main.css" rel="stylesheet" />
	<link href="../../css/responsive.css" rel="stylesheet" />
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->        
</head>
<body>
      <form id="form1" runat="server">
   <header id="header"><!--header-->
		<div class="header_top"><!--header_top-->
			<div class="container">
				<div class="row">
					<div class="col-sm-6">
						<div class="contactinfo">
							<ul class="nav nav-pills">
								<li><a href="#"><i class="fa fa-phone"></i> +91-257-2210091</a></li>
								<li><a href="#"><i class="fa fa-envelope"></i> info@sanghavi.org</a></li>
							</ul>
						</div>
					</div>
					<div class="col-sm-6">
						<div class="social-icons pull-right">
							<ul class="nav navbar-nav">
								<li><a href="#"><i class="fa fa-facebook"></i></a></li>
								<li><a href="#"><i class="fa fa-twitter"></i></a></li>
								<li><a href="#"><i class="fa fa-linkedin"></i></a></li>
								<li><a href="#"><i class="fa fa-dribbble"></i></a></li>
								<li><a href="#"><i class="fa fa-google-plus"></i></a></li>
							</ul>
						</div>
					</div>
				</div>
			</div>
		</div><!--/header_top-->
		
		<div class="header-middle"><!--header-middle-->
			<div class="container">
				<div class="row">
					<div class="col-sm-4">
						<div class="logo pull-left">
							<a href="../../Default.aspx"><img src="../../images/home/logo.png" alt=""   /></a>
						</div> 
					</div>
					<div class="col-sm-8">
						<div class="shop-menu pull-right">
							<ul class="nav navbar-nav">
								<li><a href="../../login.aspx"><i class="fa fa-user"></i> Sign Up</a></li> 
								<li><a href="../../login.aspx"><i class="fa fa-lock"></i> Login</a></li>
							</ul>
						</div>
					</div>
				</div>
			</div>
		</div><!--/header-middle-->
	
		<div class="header-bottom"><!--header-bottom-->
			<div class="container">
				<div class="row">
					<div class="col-sm-9">
						<div class="navbar-header">
							<button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
								<span class="sr-only">Toggle navigation</span>
								<span class="icon-bar"></span>
								<span class="icon-bar"></span>
								<span class="icon-bar"></span>
							</button>
						</div>
						<div class="mainmenu pull-left">
							<ul class="nav navbar-nav collapse navbar-collapse">
								<li><a href="../../Default.aspx" >Home</a></li>
								<li class="dropdown"><a href="#" class="active" >Products<i class="fa fa-angle-down"></i></a>
                                    <ul role="menu" class="sub-menu">
                                        <li><a href="../unbreakables/Unbreakables.aspx">Unbreakables</a></li>
										<li><a href="CleaningAids.aspx">Cleaning Aids</a></li> 
										<li><a href="../Solar/Solar.aspx">Solar</a></li> 
										<li><a href="#">PVC</a></li> 
										<li><a href="#">Extras</a></li> 
                                    </ul>
                                </li> 
								<li ><a href="../../about-us.html">About </a></li>  
								<li><a href="../../contact-us.html">Contact</a></li>
                                <li><a href="../../career.htm">Careers</a></li>
							</ul>
						</div>
					</div>
					<div class="col-sm-3">
						 
					</div>
				</div>
			</div>
		</div><!--/header-bottom-->
	</header><!--/header-->
	
 
	<section>
		<div class="container">
			<div class="row">
				 <div class="col-sm-3">
					<div class="left-sidebar">
						<h2>Category</h2>
						<div class="panel-group category-products" id="accordian"><!--category-productsr-->
							<div class="panel panel-default">
								<div class="panel-heading">
									<h4 class="panel-title">
										<a data-toggle="collapse" data-parent="#accordian" href="#sportswear">
											<span class="badge pull-right"><i class="fa fa-plus"></i></span>
											Unbreakables
										</a>
									</h4>
								</div>
								<div id="sportswear" class="panel-collapse collapse">
									<div class="panel-body">
										<ul>
											<li><a href="../unbreakables/Ghamela.aspx">Ghamela </a></li>
											<li><a href="../unbreakables/Bucket.aspx">Bucket </a></li>
											<li><a href="../unbreakables/Tagari.aspx">Tagari </a></li>
											<li><a href="../unbreakables/Ghagar.aspx">Ghagar</a></li>
											<li><a href="../unbreakables/TubCrate.aspx">Tub-Crate </a></li>
                                            <li><a href="../unbreakables/MugAndHome.aspx">Mug & Home </a></li>
                                            <li><a href="../unbreakables/MilkandCover.aspx">Milk Cans & Cover </a></li> 
										</ul>
									</div>
								</div>
							</div>
							<div class="panel panel-default">
								<div class="panel-heading">
									<h4 class="panel-title">
										<a data-toggle="collapse" data-parent="#accordian" href="#mens">
											<span class="badge pull-right"><i class="fa fa-plus"></i></span>
										Cleaning Aids
										</a>
									</h4>
								</div>
								<div id="mens" class="panel-collapse collapse">
									<div class="panel-body">
										<ul>
											<li><a href="DryDust.aspx">Dry-Dust</a></li>
											<li><a href="WetMop.aspx">Wet Mop</a></li>
											<li><a href="Wiper.aspx">Wiper</a></li>
											<li><a href="ChokerBroomDustar.aspx">Broom, Duster & Choker</a></li> 
										</ul>
									</div>
								</div>
							</div>
							
							<div class="panel panel-default">
								<div class="panel-heading">
									<h4 class="panel-title">
										<a data-toggle="collapse" data-parent="#accordian" href="#womens">
											<span class="badge pull-right"><i class="fa fa-plus"></i></span>
											Solar
										</a>
									</h4>
								</div>
								<div id="womens" class="panel-collapse collapse">
									<div class="panel-body">
										<ul>
											<li><a href="../Solar/Solar.aspx">Solar</a></li>
											 
										</ul>
									</div>
								</div>
							</div> 
						</div><!--/category-products--> 
						<div class="shipping text-center"><!--shipping-->
							<img src="../../images/home/shipping.jpg" alt="" />
						</div><!--/shipping-->
					
					</div>
				</div>
				
				  	 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
				<div class="col-sm-9 padding-right">
					<div class="features_items"><!--features_items-->
						<h2 class="title text-center">Cleaning Aids Items</h2>
					             <asp:ListView ID="lstUnbreakables" runat="server" DataSourceID="SqlDataSourceUnb">
                               <ItemTemplate>
                               	<div id="Div2" class="col-sm-3" runat="server">
									<div class="product-image-wrapper">
										<div class="single-products">
											<div class="productinfo text-center">
											 <asp:Image ID="imgProduct" runat="server"  ImageUrl='<%# "~/Personnel/admin/media/product/" + Eval("imgImage") %>' /><td>
												<h2> <asp:Label ID="lblProductName" runat="server" 
                                        Text='<%# Eval("nvarProductName") %>' /></h2>
											 <asp:LinkButton ID="lnkView" runat="server" CssClass="btn btn-default add-to-cart" OnClick="View"><i class="fa fa-shopping-cart"></i>Ask Price</asp:LinkButton>
                                           </div>
											
										</div>
									</div>
								</div> 
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <div ID="itemPlaceholderContainer" runat="server" style="">
                                        <div runat="server" id="itemPlaceholder" />

                                    </div>
                                    <div style="">
                                    </div>
                                </LayoutTemplate> 
                                </asp:ListView>

						 <asp:SqlDataSource ID="SqlDataSourceUnb" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                    ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                    
                                    SelectCommand="SELECT distinct nvarProductName, imgImage FROM tblsuproducts WHERE (nvarProductType =@type) AND nvarProductSubType =@subtype ORDER BY tblsuproducts.intId ASC">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="Cleaning Aids" Name="type" 
                                            Type="String" />
                                              <asp:Parameter DefaultValue="WIPER" Name="subtype" 
                                            Type="String" />
                                                
                                              
                                    </SelectParameters>
                                </asp:SqlDataSource> 
						
                         <asp:LinkButton Text="" ID="lnkFake" runat="server" />
        <cc1:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="lnkFake"
            CancelControlID="btnClose" BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
               Enquiry Details
            </div>
            <div role="form">
                 <div class="form-group"> 
                <h4> Please send me the latest price and details of 
                '<asp:Label ID="lblId" runat="server" />'. </h4>
                 </div>   
                  <div class="form-group">Email : 
                <asp:TextBox ID="txtEmail" runat="server"  pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)" 
                 required CssClass="form-control"></asp:TextBox></div>
                    <div class="form-group">Mobile : 
                <asp:TextBox ID="txtMobile" required onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" runat="server"  CssClass="form-control"></asp:TextBox></div>
                 
                   <div class="form-group text-right">
              <asp:Button ID="btnSaves" runat="server" Text="Ask Price" OnClick = "Save" CssClass="btn btn-info" />
                <asp:LinkButton ID="btnClose" runat="server" Text="Close" CssClass="btn btn-danger" />
            </div>
            </div>
         
        </asp:Panel>
						
					</div><!--features_items-->
					
				<div class="recommended_items"><!--recommended_items-->
						<h2 class="title text-center">recommended items</h2>
						
						 <div id="recommended-item-carousel" class="carousel slide" data-ride="carousel">
							<div class="carousel-inner">
								<div class="item active">	
									<div class="col-sm-4">
										<div class="product-image-wrapper">
											<div class="single-products">
												<div class="productinfo text-center">
													<img src="../../Personnel/admin/media/product/ALLROUNDER35Ltr.png" alt="" />
													<h2>All Rounder Tub</h2>
												 
													<a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Ask Price</a>
												</div>
												
											</div>
										</div>
									</div>
									<div class="col-sm-4">
										<div class="product-image-wrapper">
											<div class="single-products">
												<div class="productinfo text-center">
													<img src="../../Personnel/admin/media/product/FALHAR13in.png" alt="" />
													<h2>Falhar Ghamela</h2>
													 
													<a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Ask Price</a>
												</div>
												
											</div>
										</div>
									</div>
									<div class="col-sm-4">
										<div class="product-image-wrapper">
											<div class="single-products">
												<div class="productinfo text-center">
													<img src="../../Personnel/admin/media/product/FRUITCRATE.png" alt="" />
													<h2>Fruit Crate</h2>
												 
													<a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Ask Price</a>
												</div>
												
											</div>
										</div>
									</div>
								</div>
								<div class="item">	
									<div class="col-sm-4">
										<div class="product-image-wrapper">
											<div class="single-products">
												<div class="productinfo text-center">
													<img src="../../Personnel/admin/media/product/MAHARANI16Ltr.png" alt="" />
													<h2>Maharani Bucket</h2>
													 
													<a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Ask Price</a>
												</div>
												
											</div>
										</div>
									</div>
									<div class="col-sm-4">
										<div class="product-image-wrapper">
											<div class="single-products">
												<div class="productinfo text-center">
													<img src="../../Personnel/admin/media/product/NARMADA17Ltr.png" alt="" />
													<h2>Narmada Ghagar</h2>
													 
													<a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Ask Price</a>
												</div>
												
											</div>
										</div>
									</div>
									<div class="col-sm-4">
										<div class="product-image-wrapper">
											<div class="single-products">
												<div class="productinfo text-center">
													<img src="../../Personnel/admin/media/product/WIRECLIP.png" alt="" />
													<h2>MOP</h2>
													 
													<a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Ask Price</a>
												</div>
												
											</div>
										</div>
									</div>
								</div>
							</div>
							 <a class="left recommended-item-control" href="#recommended-item-carousel" data-slide="prev">
								<i class="fa fa-angle-left"></i>
							  </a>
							  <a class="right recommended-item-control" href="#recommended-item-carousel" data-slide="next">
								<i class="fa fa-angle-right"></i>
							  </a>			
						</div>
					</div>	<!--/recommended_items-->
					
				</div>
			</div>
		</div>
	</section>
	 </form>
	<footer id="footer"><!--Footer-->
		  
		<div class="footer-widget">
			<div class="container">
				<div class="row">
					<div class="col-sm-2">
						<div class="single-widget">
							<h2>Service</h2>
							<ul class="nav nav-pills nav-stacked">
								<li><a href="#">Online Help</a></li>
								<li><a href="#">Contact Us</a></li>
								<li><a href="#">Order Status</a></li> 
								<li><a href="#">FAQ’s</a></li>
							</ul>
						</div>
					</div>
					<div class="col-sm-2">
						<div class="single-widget">
							<h2>Quick Shop</h2>
							<ul class="nav nav-pills nav-stacked">
								<li><a href="#">Unbreakables</a></li>
								<li><a href="#">Cleaning Aids</a></li>
								<li><a href="#">Solar</a></li>
								<li><a href="#">PVC</a></li> 
							</ul>
						</div>
					</div>
					<div class="col-sm-2">
						<div class="single-widget">
							<h2>Policies</h2>
							<ul class="nav nav-pills nav-stacked">
								<li><a href="#">Terms of Use</a></li>
								<li><a href="#">Privacy Policy</a></li> 
							</ul>
						</div>
					</div>
					<div class="col-sm-2">
						<div class="single-widget">
							<h2>About Us</h2>
							<ul class="nav nav-pills nav-stacked">
								<li><a href="#">About Us</a></li>
								<li><a href="#">Careers</a></li>
								<li><a href="#">Store Location</a></li> 
								<li><a href="#">Copyright</a></li>
							</ul>
						</div>
					</div>
					<div class="col-sm-3 col-sm-offset-1">
						<div class="single-widget">
							<h2>About Site</h2>
							<form action="#" class="searchform">
								<input type="text" placeholder="Your email address" />
								<button type="submit" class="btn btn-default"><i class="fa fa-arrow-circle-o-right"></i></button>
								<p>Get the most recent updates from <br />our site and be updated your self...</p>
							</form>
						</div>
					</div>
					
				</div>
			</div>
		</div>
		
		<div class="footer-bottom">
			<div class="container">
				<div class="row">
					<p class="pull-left">Copyright © 2015 Sanghavi Polymers. All rights reserved.</p>
					<p class="pull-right">Designed by <span><a target="_blank" href="http://www.anuvaasoft.com">Anuvaa Softech Pvt. Ltd.</a></span></p>
				</div>
			</div>
		</div>
		
	</footer><!--/Footer-->
	

    
    <script src="../../js/jquery.js"></script>
	<script src="../../js/bootstrap.min.js"></script>
	<script src="../../js/jquery.scrollUp.min.js"></script>
	<script src="../../js/price-range.js"></script>
    <script src="../../js/jquery.prettyPhoto.js"></script>
    <script src="../../js/main.js"></script>
   
</body>
</body>
</html>


