<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="home" class="home" data-scroll-index="0"></div>

    <div class="b-slidercontainer"  >
        <div class="b-slider j-fullscreenslider">
            <ul>
               <%-- <li data-transition="3dcurtain-vertical" data-slotamount="7">
                    <div class="tp-bannertimer"></div>
                    <img data-retina src="img/slider/bnr1.png">
                </li>--%>
                <li data-transition="" data-slotamount="7">
                    <div class="tp-bannertimer"></div>
                    <img data-retina src="img/slider/bnr3.png">
                </li>
                <li data-transition="" data-slotamount="7">
                    <div class="tp-bannertimer"></div>
                    <img data-retina src="img/slider/bnr2.png">
                </li>
                <li data-transition="" data-slotamount="7">
                    <div class="tp-bannertimer"></div>
                    <img data-retina src="img/slider/bnr4.png">
                </li>

            </ul>
        </div>
    </div>


    <div class="b-page-over">

        <section class="b-remaining" id="about" data-scroll-index="1">
            <div class="b-inner-page-header f-inner-page-header b-bg-header-inner-page">
                <div class="b-inner-page-header__content">
                    <div class="container">
                        <h1 class="f-primary-l c-default">About Us</h1>
                    </div>
                </div>
            </div>
            <div class="container-fluid" style="border-bottom: 10px solid #253C58;">

                <div class="container b-infoblock--without-border">
                    <div class="row">
                        <p>Sanghavi Unbreakable is India’s leading manufacturing company of Unbreakable Plastic Articles and many more plastic environment friendly products with its presence across nation. Our Head office situated at Jalgaon (Maharashtra) which runs all the major operations to achieve and practice highest International standards of manufacturing and quality assurance. With innovative techniques and well managed processes our Marketing Officers & Sales teams are constantly engaged in running this marketing network effectively to achieve new milestones for company.</p>

                    </div>
                    <div class="row b-shortcode-example">
                        <div data-active="1" class="b-tabs-vertical b-tabs-vertical--default f-tabs-vertical j-tabs-vertical b-tabs-reset row">
                            <div class="col-md-3 col-sm-4 b-tabs-vertical__nav">
                                <ul>
                                    <li><a class="f-primary-l" href="#tabs-1"><i class="fa fa-suitcase"></i>About us</a></li>
                                    <li><a class="f-primary-l" href="#tabs-2"><i class="fa fa-flask"></i>Our history</a></li>
                                    <li><a class="f-primary-l" href="#tabs-3"><i class="fa fa-flag"></i>Our Vision</a></li>
                                    <li><a class="f-primary-l" href="#tabs-4"><i class="fa fa-users"></i>Our Mission</a></li>
                                    <li><a class="f-primary-l" href="#tabs-5"><i class="fa fa-file-pdf-o"></i>Our Brochure</a></li>
                                </ul>
                            </div>
                            <div class="col-md-9 col-sm-8 b-tabs-vertical__content">
                                <div id="tabs-1">
                                    <div class="b-tabs-vertical__content-text">
                                        <h3 class="f-tabs-vertical__title f-primary-b">About Us</h3>
                                        <p>Sanghavi Unbreakable is a leading ISO 9001-2008 Certified Company manufacturing an excellent range of Unbreakable Plastic Products and injection molded articles with an experience of over 18 years. We are also manufacturing wide range of PVC Fittings (AGRI, SWR, ASTM). The company is currently working in 7 states and more than 500 distributors and looking forward to capture more market of remaining region. </p>

                                    </div>
                                </div>
                                <div id="tabs-2">
                                    <div class="b-tabs-vertical__content-text">
                                        <h3 class="f-tabs-vertical__title f-primary-b">Our History</h3>
                                        <p>Established in 1923 under a parent company named The Chunilal Motiram Ginning Factory And Oil Mill ,the group today comprises operating companies in 5 business sectors namely, Ginning & Pressing ,Polymer Products ,Construction & Infrastructure ,Packing & Forwarding and Agro -products.</p>
                                    </div>
                                </div>
                                <div id="tabs-3">
                                    <div class="b-tabs-vertical__content-text">
                                        <h3 class="f-tabs-vertical__title f-primary-b">Our Vision</h3>
                                        <p>"To become Market leader with excellence in services for profitable growth with the help of Technology, Commitment ,Loyalty to clients, Employees and Society."</p>
                                    </div>
                                </div>
                                <div id="tabs-4">
                                    <div class="b-tabs-vertical__content-text">
                                        <h3 class="f-tabs-vertical__title f-primary-b">Our Mission</h3>
                                        <p>"We are committed to build a quality organization with customer as our primary focus. We shall continuously improve our quality, management systems and improve effectiveness."</p>

                                    </div>
                                </div>
                                <div id="tabs-5">
                                    <div class="b-tabs-vertical__content-text">
                                        <h3 class="f-tabs-vertical__title f-primary-b">Our Brochure</h3>
                                        <p>Download our brochure <a href="img/SANGHAVI UNBREAKABLE BROUCHER.pdf" target="_blank">here</a>.</p>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="b-inner-page-header f-inner-page-header b-bg-header-inner-page">
                <div class="b-inner-page-header__content">
                    <div class="container">
                        <h1 class="f-primary-l c-default">About Our Products</h1>
                    </div>
                </div>
            </div>
            <section class="b-infoblock ">
                <div class="container">
                    <div class="b-null-bottom-indent b-infoblock-with-icon-group clearfix b-infoblock-with-icon--sm f-infoblock-with-icon--sm b-infoblock-with-icon--colored-bg b-info-container">
                        <h3 class="f-legacy-h3 c-white f-primary-b f-center">PVC Fittings</h3>

                        <div class="col-md-4 col-sm-6 col-xs-12">
                            <div class="b-infoblock-with-icon">
                                <a href="#" class="b-infoblock-with-icon__icon f-infoblock-with-icon__icon fade-in-animate visible">
                                    <i class="fa fa-tint"></i>
                                </a>
                                <div class="b-infoblock-with-icon__info f-infoblock-with-icon__info">
                                    <a href="#" class="f-infoblock-with-icon__info_title b-infoblock-with-icon__info_title f-primary-sb">AGRIculture Pipe Fittings
                                        <br />
                                        <br />
                                    </a>
                                    <div class="f-infoblock-with-icon__info_text b-infoblock-with-icon__info_text">
                                        We offer AGRIculture Pipe Fittings, which is developed in conformation with international quality standard. Our PVC made fitting is extensively used in rural as well as urban sector for AGRIculture purpose. These are light in weight and economical in handling transportation and installation.
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                            <div class="b-infoblock-with-icon">
                                <a href="#" class="b-infoblock-with-icon__icon f-infoblock-with-icon__icon fade-in-animate visible">
                                    <i class="fa fa-spinner"></i>
                                </a>
                                <div class="b-infoblock-with-icon__info f-infoblock-with-icon__info">
                                    <a href="#" class="f-infoblock-with-icon__info_title b-infoblock-with-icon__info_title f-primary-sb">Unique features of molded AGRIculture fittings:
                                        <br />
                                    </a>
                                    <div class="f-infoblock-with-icon__info_text b-infoblock-with-icon__info_text">
                                        Measure up to the most stringent demands of quality control.
         Made from the superior quality raw materials.
         As per IS-7834-1975 specifications.
        Designed to fit snugly any type of standard sized pipes.
         Reliable dealer network.
         Widest range.
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix visible-sm-block"></div>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                            <div class="b-infoblock-with-icon">
                                <a href="#" class="b-infoblock-with-icon__icon f-infoblock-with-icon__icon fade-in-animate visible">
                                    <i class="fa fa-th-large"></i>
                                </a>
                                <div class="b-infoblock-with-icon__info f-infoblock-with-icon__info">
                                    <a href="#" class="f-infoblock-with-icon__info_title b-infoblock-with-icon__info_title f-primary-sb">Applications:
                                        <br />
                                        <br />
                                    </a>
                                    <div class="f-infoblock-with-icon__info_text b-infoblock-with-icon__info_text">
                                        AGRI
         Irrigation and village water distribution system
         Industrial
         In Chemical, Sugar and Dairy 
     Industries for transporting the liquids.
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix visible-md-block visible-lg-block"></div> 
                    </div>

                </div>
                <br />
                <br />
                <div class="container">
                    <div class="b-null-bottom-indent b-infoblock-with-icon-group clearfix b-infoblock-with-icon--sm f-infoblock-with-icon--sm b-infoblock-with-icon--colored-bg b-info-container">
                        <h3 class="f-legacy-h3 c-white f-primary-b f-center">SWR Fittings</h3>

                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="b-infoblock-with-icon">
                                <a href="#" class="b-infoblock-with-icon__icon f-infoblock-with-icon__icon fade-in-animate visible">
                                    <i class="fa fa-tint"></i>
                                </a>
                                <div class="b-infoblock-with-icon__info f-infoblock-with-icon__info">

                                    <div class="f-infoblock-with-icon__info_text b-infoblock-with-icon__info_text">
                                        These are Injection Moulded Fittings available in 75mm, 110mm sizes and are strictly manufactured as per quality standard. SWR moulded fittings are unique in which a selffit fitting is converted into ring fit fitting by simply adding a rubberring adaptor over the socket. SWR Fittings have several advantages like Strong & Unbreakable, Leak Proof, Fire Resistant, Rust Proof, maintenance free and economical etc.
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="clearfix visible-md-block visible-lg-block"></div>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <div class="b-infoblock-with-icon">
                                <a href="#" class="b-infoblock-with-icon__icon f-infoblock-with-icon__icon fade-in-animate visible">
                                    <i class="fa fa-shopping-cart"></i>
                                </a>
                                <div class="b-infoblock-with-icon__info f-infoblock-with-icon__info">
                                    <a href="#" class="f-infoblock-with-icon__info_title b-infoblock-with-icon__info_title f-primary-sb">FEATURES & BENEFITS :</a>
                                    <div class="f-infoblock-with-icon__info_text b-infoblock-with-icon__info_text">

                                        <ul class="fa-ul">

                                            <li>• Odourless and hygienic</li>
                                            <li>• Excellent Corrosion & Chemical Resistance</li>
                                            <li>• Easy to install & light weight</li>
                                            <li>• Mirror smooth inside surface and hence optimum flow rates</li>
                                           
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix visible-sm-block"></div>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <div class="b-infoblock-with-icon">
                                 
                                <div class="b-infoblock-with-icon__info f-infoblock-with-icon__info">
                                     <div class="f-infoblock-with-icon__info_text b-infoblock-with-icon__info_text">
                                         <br />
                                            <ul class="fa-ul">
                                         <li>• Immunity to galvanic or electrolytic attack.</li>
                                            <li>• High opaque wall resistance to formation of algae & fungus.</li>
                                            <li>• High tensile & high impact strength.</li>
                                            <li>• Excellent Environmental stress cracking resistance.</li>
                                            <li>• No Incrustation and low maintenance cost  	
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
            </section>
            <div class="container">
                <div class="f-primary-b b-title-b-hr f-title-b-hr">OUR PRODUCT RANGE</div>

                <section class="b-infoblock-with-icon-group ">
                    <div class="b-infoblock">
                        <div class="b-slider">
                            <div class="flexslider flexslider-zoom">
                                <ul class="slides">
                                    <li>
                                        <img data-retina src="img/slider/slider2.png">
                                    </li>
                                    <li>
                                        <img data-retina src="img/slider/slider1.png">
                                    </li>

                                </ul>
                            </div>
                            <div class="flexslider flexslider-thumbnail b-product-card__visual-thumb carousel-sm">
                                <ul class="slides">
                                    <li>
                                        <img data-retina src="img/slider/slider2.png">
                                    </li>
                                    <li>
                                        <img data-retina src="img/slider/slider1.png">
                                    </li>

                                </ul>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </section>
        <section class="b-google-map map-theme" id="contact" data-scroll-index="2">
            <div class="b-inner-page-header f-inner-page-header b-bg-header-inner-page">
                <div class="b-inner-page-header__content">
                    <div class="container">
                        <h1 class="f-primary-l c-default">Contact Us</h1>
                    </div>
                </div>
            </div>
            <div class="b-google-map__map-view b-google-map__map-height">
                <!-- Google map load -->
            </div>
            <img data-retina src="img/google-map-marker-default.png" data-label="" class="marker-template hidden" />
            <div class="b-google-map__info-window-template hidden"
                data-selected-marker="0"
                data-width="526">
                <div class="b-google-map__info-window col-xs-12 col-lg-offset-3">
                    <div class="col-lg-7 col-xs-12 b-google-map__info-window-address">
                        <ul class="list-unstyled">
                            <li class="col-xs-12">
                                <div class="b-google-map__info-window-address-icon f-center pull-left">
                                    <i class="fa fa-home"></i>
                                </div>
                                <div>
                                    <div class="b-google-map__info-window-address-title f-google-map__info-window-address-title">
                                        SANGHAVI GROUP.
                                    </div>
                                    <div class="desc">
                                        36,Sureshdada Jain Market, 
Ajanta Road, Jalgaon-425001
                                    </div>
                                </div>
                            </li>

                            <li class="col-xs-12">
                                <div class="b-google-map__info-window-address-icon f-center pull-left">
                                    <i class="fa fa-skype"></i>
                                </div>
                                <div>
                                    <div class="b-google-map__info-window-address-title f-google-map__info-window-address-title">
                                        Phone
                                    </div>
                                    <div class="desc">0257 2210091</div>
                                </div>
                            </li>
                            <li class="col-xs-12">
                                <div class="b-google-map__info-window-address-icon f-center pull-left">
                                    <i class="fa fa-envelope"></i>
                                </div>
                                <div>
                                    <div class="b-google-map__info-window-address-title f-google-map__info-window-address-title">
                                        email
                                    </div>
                                    <div class="desc">info@sanghavi.org</div>
                                </div>
                            </li>
                        </ul>

                    </div>
                    <%-- <div class="col-lg-5 b-google-map__info-window-image hidden-xs hidden-sm hidden-md">
        <img data-retina src="img/google-map-skyscrapper.png" style="width: 218px; height: 243px;" alt=""/>
    </div>--%>
                </div>
            </div>
            <div class="b-contact-form container">
                <div class="b-contact-form__window c-primary">
                    <div class="col-xs-12 b-contact-form__window-title f-contact-form__window-title text-uppercase f-primary-b">
                        drop a line
            <hr />
                    </div>
                    <div class="col-xs-12 col-sm-6">
                        <div class="b-contact-form__window-form-row">
                            <label for="contact_form_name" class="b-contact-form__window-form-row-label">Your name</label>
                            <input type="text" class="form-control" id="contact_form_name" />
                        </div>
                        <div class="b-contact-form__window-form-row">
                            <label for="contact_form_email" class="b-contact-form__window-form-row-label">Your email</label>
                            <input type="text" class="form-control" id="contact_form_email" />
                        </div>
                        <div class="b-contact-form__window-form-row">
                            <label for="contact_form_website" class="b-contact-form__window-form-row-label">Your website</label>
                            <input type="text" class="form-control" id="contact_form_website" />
                        </div>
                        <div class="b-contact-form__window-form-row">
                            <label for="contact_form_title" class="b-contact-form__window-form-row-label">Your title</label>
                            <input type="text" class="form-control" id="contact_form_title" />
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6">
                        <div class="b-contact-form__window-form-row">
                            <label for="contact_form_message" class="b-contact-form__window-form-row-label">Your message</label>
                            <textarea id="contact_form_message" rows="7" class="b-contact-form__window-form-textarea form-control"></textarea>
                        </div>
                        <div class="b-contact-form__window-form-row">
                            <label for="contact_form_copy" class="b-contact-form__window-form-row-label">
                                <input type="checkbox" id="contact_form_copy" class="b-form-checkbox" />
                                <span><span class="f-primary">Send me a copy</span></span>
                            </label>
                        </div>
                        <div class="b-contact-form__window-form-row">
                            <a href="#" class="b-btn f-btn b-btn-md b-btn-default f-primary-b b-contact-form__window-form-row-button">send message</a>
                        </div>
                    </div>
                </div>
            </div>
        </section>


    </div>
</asp:Content>

