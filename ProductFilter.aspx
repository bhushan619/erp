<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductFilter.aspx.cs" Inherits="Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="b-infoblock">
        <div class="container">
            <div class="row">

                <div class="col-md-9 ">

                    <div class="row">
                        <div class="b-col-default-indent">

                            <div class="b-col-default-indent">
                                <div class="features_items">
                                    <!--features_items-->
                                    <h1 class="f-primary-l c-default page-header">Sanghavi Unbreakables</h1>
                                    <asp:ListView ID="lstUnbreakables" runat="server" DataSourceID="SqlDataSourceUnb">
                                        <ItemTemplate>
                                            <div class="col-md-4 col-sm-4 col-xs-6 col-mini-12">
                                                <div class="b-product-preview" id="Unbreakables">
                                                    <div id="product" class="b-product-preview__img view view-sixth" runat="server">
                                                        <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# "~/Personnel/admin/media/product/" + Eval("imgImage") %>' /><td>
                                                            <div class="b-item-hover-action f-center mask">
                                                                <div class="b-item-hover-action__inner">
                                                                    <div class="b-item-hover-action__inner-btn_group">
                                                                        <asp:LinkButton ID="lnkView" runat="server" CssClass="btn btn-default add-to-cart" OnClick="View"><i class="fa fa-shopping-cart"></i>Ask Price</asp:LinkButton>
                                                                    </div>

                                                                </div>
                                                            </div>

                                                    </div>
                                                    <div class="b-product-preview__content">
                                                        <div class="b-product-preview__content_col">
                                                            <span class="b-product-preview__content_price f-product-preview__content_price f-primary-b">New</span>
                                                        </div>
                                                        <div class="b-product-preview__content_col">
                                                            <a class="f-product-preview__content_title">
                                                                <asp:Label ID="lblProductName" runat="server"
                                                                    Text='<%# Eval("nvarProductName") %>' /></a>
                                                            <div class="f-product-preview__content_category f-primary-b">
                                                                <a>
                                                                    <asp:Label ID="Label2" runat="server"
                                                                        Text='<%# Eval("nvarProductName") %>' />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                        </ItemTemplate>
                                        <LayoutTemplate>
                                            <div id="itemPlaceholderContainer" runat="server" style="">
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
                                            <asp:QueryStringParameter QueryStringField="type" Name="type"
                                                Type="String" />
                                            <asp:QueryStringParameter QueryStringField="subtype" Name="subtype"
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
                                                <asp:Button ID="btnSaves" runat="server" Text="Ask Price" OnClick="Save" CssClass="btn btn-info" />
                                                <asp:LinkButton ID="btnClose" runat="server" Text="Close" CssClass="btn btn-danger" />
                                            </div>
                                        </div>

                                    </asp:Panel>

                                </div>
                                <!--features_items-->

                            </div>




                        </div>
                    </div>
                </div>
                <br />
                <br />
                <div class="col-md-3">
                    <aside>
                        <div class="row b-col-default-indent">


                            <div class="col-md-12">
                                <div class="b-categories-filter">
                                    <h4 class="f-primary-b b-h4-special f-h4-special c-primary">Categories filter</h4>
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
                                                    <li><a href="ProductFilter.aspx?type=Unbreakables&subtype=Ghamela">Ghamela </a></li>
                                                    <li><a href="ProductFilter.aspx?type=Unbreakables&subtype=Bucket">Bucket </a></li>
                                                    <li><a href="ProductFilter.aspx?type=Unbreakables&subtype=Tagari">Tagari </a></li>
                                                    <li><a href="ProductFilter.aspx?type=Unbreakables&subtype=Ghagar">Ghagar</a></li>
                                                    <li><a href="ProductFilter.aspx?type=Unbreakables&subtype=Tub-Crate">Tub-Crate </a></li>
                                                    <%-- <li><a href="ProductFilter.aspx?type=Unbreakables&subtype=Mug & Home">Mug & Home </a></li>
                                            <li><a href="ProductFilter.aspx?type=Unbreakables&subtype=Milk Cans & Cover">Milk Cans & Cover </a></li> --%>
                                                </ul>
                                            </li>
                                        </ul>

                                        <ul>
                                            <li>
                                                <a data-toggle="collapse" data-parent="#accordian" href="#mens">
                                                    <i class="fa fa-plus"></i>
                                                    PVC
                                                </a>
                                            </li>
                                        </ul>
                                        <ul id="mens" class="panel-collapse collapse">
                                            <li class="panel-body">
                                                <ul>
                                                    <li><a href="#">PVC</a></li>
                                                    <li><a href="#">Coming soon</a></li>
                                                    <li><a href="#">Coming soon</a></li>
                                                    <li><a href="#">Coming soon</a></li>
                                                </ul>
                                            </li>
                                        </ul>
                                    </ul>
                                    <div class="f-carousel-secondary b-portfolio__example-box f-some-examples-tertiary b-carousel-reset b-carousel-arr-square b-carousel-arr-square--big f-carousel-arr-square">

                                        <div class="b-carousel-title f-carousel-title f-carousel-title__color f-secondary-b" id="Div1">

                                            <a class="b-carousel-title  f-carousel-title__color">recommended items</a>

                                        </div>
                                        <!--recommended_items-->

                                        <div class=" b-portfolio-slider-box__items">
                                            <div class="recommended_items">
                                                <div id="recommended-item-carousel " class="carousel slide" data-ride="carousel">


                                                    <div class="carousel-inner">
                                                        <div class="item active">

                                                            <div class="col-md-12">
                                                                <div class="b-product-preview">
                                                                    <div class="b-product-preview__img view view-sixth">
                                                                        <img data-retina src="Personnel/admin/media/product/ALLROUNDER35Ltr.png" alt="" />
                                                                        <div class="b-item-hover-action f-center mask">
                                                                            <div class="b-item-hover-action__inner">
                                                                                <div class="b-item-hover-action__inner-btn_group">

                                                                                    <a href="" class="b-btn f-btn b-btn-light f-btn-light info">Ask Price<i class="fa fa-link"></i></a>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="b-product-preview__content">
                                                                        <div class="b-product-preview__content_col">
                                                                            <span class="b-product-preview__content_price f-product-preview__content_price f-primary-b">Now</span>
                                                                        </div>
                                                                        <div class="b-product-preview__content_col">
                                                                            <a href="#" class="f-product-preview__content_title">All Rounder Tub</a>
                                                                            <div class="f-product-preview__content_category f-primary-b"><a href="#">Unbreakable</a> </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                        </div>
                                                        <div class="item">
                                                            <div class="col-md-12  col-mini-12">
                                                                <div class="b-product-preview">
                                                                    <div class="b-product-preview__img view view-sixth">
                                                                        <img data-retina src="Personnel/admin/media/product/FALHAR13in.png" alt="" />
                                                                        <div class="b-item-hover-action f-center mask">
                                                                            <div class="b-item-hover-action__inner">
                                                                                <div class="b-item-hover-action__inner-btn_group">

                                                                                    <a href="" class="b-btn f-btn b-btn-light f-btn-light info">Ask Price<i class="fa fa-link"></i></a>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="b-product-preview__content">
                                                                        <div class="b-product-preview__content_col">
                                                                            <span class="b-product-preview__content_price f-product-preview__content_price f-primary-b">Now</span>
                                                                        </div>
                                                                        <div class="b-product-preview__content_col">
                                                                            <a href="#" class="f-product-preview__content_title">Falhar Ghamela</a>
                                                                            <div class="f-product-preview__content_category f-primary-b"><a href="#">Unbreakable</a> </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="item">
                                                            <div class="col-md-12 col-mini-12">
                                                                <div class="b-product-preview">
                                                                    <div class="b-product-preview__img view view-sixth">
                                                                        <img data-retina src="Personnel/admin/media/product/FRUITCRATE.png" alt="" />
                                                                        <div class="b-item-hover-action f-center mask">
                                                                            <div class="b-item-hover-action__inner">
                                                                                <div class="b-item-hover-action__inner-btn_group">

                                                                                    <a href="" class="b-btn f-btn b-btn-light f-btn-light info">Ask Price<i class="fa fa-link"></i></a>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="b-product-preview__content">
                                                                        <div class="b-product-preview__content_col">
                                                                            <span class="b-product-preview__content_price f-product-preview__content_price f-primary-b">Now</span>
                                                                        </div>
                                                                        <div class="b-product-preview__content_col">
                                                                            <a href="#" class="f-product-preview__content_title">Fruit Crate</a>
                                                                            <div class="f-product-preview__content_category f-primary-b"><a href="#">Unbreakable</a> </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="item">
                                                            <div class="col-md-12 col-mini-12">
                                                                <div class="b-product-preview">
                                                                    <div class="b-product-preview__img view view-sixth">
                                                                        <img data-retina src="Personnel/admin/media/product/MAHARANI16Ltr.png" alt="" />
                                                                        <div class="b-item-hover-action f-center mask">
                                                                            <div class="b-item-hover-action__inner">
                                                                                <div class="b-item-hover-action__inner-btn_group">

                                                                                    <a href="" class="b-btn f-btn b-btn-light f-btn-light info">Ask Price<i class="fa fa-link"></i></a>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="b-product-preview__content">
                                                                        <div class="b-product-preview__content_col">
                                                                            <span class="b-product-preview__content_price f-product-preview__content_price f-primary-b">Now</span>
                                                                        </div>
                                                                        <div class="b-product-preview__content_col">
                                                                            <a href="#" class="f-product-preview__content_title">Maharani Bucket</a>
                                                                            <div class="f-product-preview__content_category f-primary-b"><a href="#">Unbreakable</a> </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="item">
                                                            <div class="col-md-12 col-mini-12">
                                                                <div class="b-product-preview">
                                                                    <div class="b-product-preview__img view view-sixth">
                                                                        <img data-retina src="Personnel/admin/media/product/NARMADA17Ltr.png" alt="" />
                                                                        <div class="b-item-hover-action f-center mask">
                                                                            <div class="b-item-hover-action__inner">
                                                                                <div class="b-item-hover-action__inner-btn_group">

                                                                                    <a href="" class="b-btn f-btn b-btn-light f-btn-light info">Ask Price<i class="fa fa-link"></i></a>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="b-product-preview__content">
                                                                        <div class="b-product-preview__content_col">
                                                                            <span class="b-product-preview__content_price f-product-preview__content_price f-primary-b">Now</span>
                                                                        </div>
                                                                        <div class="b-product-preview__content_col">
                                                                            <a href="#" class="f-product-preview__content_title">Narmada Ghagar</a>
                                                                            <div class="f-product-preview__content_category f-primary-b"><a href="#">Unbreakable</a> </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>

                                                        </div>


                                                    </div>

                                                    <a class="left recommended-item-control" href="#recommended-item-carousel" data-slide="prev">
                                                        <i class="fa fa-backward"></i>
                                                    </a>
                                                    <a class="right recommended-item-control" href="#recommended-item-carousel" data-slide="next">
                                                        <i class="fa fa-forward "></i>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <!--/recommended_items-->
                                    </div>

                                    </><!--/category-products-->
                                    <!--/shipping-->

                                </div>
                            </div>

                        </div>

                    </aside>

                </div>
            </div>

        </div>

    </section>
    </section>
</asp:Content>

