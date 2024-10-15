<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="b-inner-page-header f-inner-page-header b-bg-header-inner-page">
  <div class="b-inner-page-header__content">
    <div class="container">
      <h1 class="f-primary-l c-default">Contact us</h1>
    </div>
  </div>
</div>
     <div class="b-breadcrumbs f-breadcrumbs">
        <div class="container">
            <ul>
                <li><a href="Default.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><i class="fa fa-angle-right"></i><span> Contact us </span></li>
            </ul>
        </div>
    </div>
     
      
			<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d1862.4000714763315!2d75.578027!3d21.000647!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xcf0f4fc7289c012e!2sSuresh+Dada+Jain+Market!5e0!3m2!1sen!2sin!4v1499671116972" width="100%" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>
		 
     
    <div class="b-desc-section-container">
        <section class="container b-welcome-box">
            <div class="row">
                <div class="col-md-offset-2 col-md-8">
                    <h1 class="is-global-title f-center f-legacy-h1">We’d love to hear from you!</h1>
                     
                </div>
            </div>
        </section>
        <section class="container">
            <div class="row">
                <div class="col-sm-6 b-contact-form-box">
                    <h3 class="f-legacy-h3 f-primary-b b-title-description f-title-description">
                        drop a line
                        <div class="b-title-description__comment f-title-description__comment f-primary-l">  </div>
                    </h3>
                    <div class="row">
                        <form action="#" method="post">
                            <div class="col-md-6">
                                <div class="b-form-row">
                                    <label class="b-form-vertical__label" for="name">Your name</label>
                                    <div class="b-form-vertical__input">
                                        <input type="text" id="name" class="form-control" />
                                    </div>
                                </div>
                                <div class="b-form-row">
                                    <label class="b-form-vertical__label" for="email">You email</label>
                                    <div class="b-form-vertical__input">
                                        <input type="text" id="email" class="form-control" />
                                    </div>
                                </div>
                                <div class="b-form-row">
                                    <label class="b-form-vertical__label" for="website">Your website</label>
                                    <div class="b-form-vertical__input">
                                        <input type="text" id="website" class="form-control" />
                                    </div>
                                </div>
                                <div class="b-form-row">
                                    <label class="b-form-vertical__label" for="title">Your title</label>
                                    <div class="b-form-vertical__input">
                                        <input type="text" id="title" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="b-form-row b-form--contact-size">
                                    <label class="b-form-vertical__label">Your message</label>
                                    <textarea class="form-control" rows="5"></textarea>
                                </div>
                                <div class="b-form-row">
                                    <a href="#" class="b-btn f-btn b-btn-md b-btn-default f-primary-b b-btn__w100">send message</a>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <div class="col-sm-6 b-contact-form-box">
                    <h3 class="f-legacy-h3 f-primary-b b-title-description f-title-description">
                        contact info
                        <div class="b-title-description__comment f-title-description__comment f-primary-l">  </div>
                    </h3>
                    <div class="row b-google-map__info-window-address">
                        <ul class="list-unstyled">
    <li class="col-xs-12">
        <div class="b-google-map__info-window-address-icon f-center pull-left">
            <i class="fa fa-home"></i>
        </div>
        <div>
            <div class="b-google-map__info-window-address-title f-google-map__info-window-address-title">
               Sanghavi Group. 
            </div>
            <div class="desc">36/37,Sureshdada Jain Market, <br />Ajanta Road, Jalgaon-425001</div>
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
                </div>
            </div>
        </section>
    </div>
</asp:Content>

