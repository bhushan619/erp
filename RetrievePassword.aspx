<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RetrievePassword.aspx.cs" Inherits="RetrievePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
    <div class="b-inner-page-header f-inner-page-header b-bg-header-inner-page">
  <div class="b-inner-page-header__content">
    <div class="container">
      <h1 class="f-primary-l c-default">Retrieve Password</h1>
    </div>
  </div>
</div>
     <div class="b-breadcrumbs f-breadcrumbs">
        <div class="container">
            <ul>
                <li><a href="Default.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><i class="fa fa-angle-right"></i><span> Retrieve Password </span></li>
            </ul>
        </div>
    </div>
       <section class="container">
            <div class="row">
                <div class="col-sm-6 col-lg-offset-3 b-contact-form-box"> 
                    <div class="row"> <h2 class="title text-center"></h2>    	    				    				
				 
                    <p class="text-center">Please fill details to retrieve password </p>

                        <table class="table table-condensed table-responsive"> 
                            <tr>
                                <td>
                                  <asp:Label ID="Label2" runat="server" Text="Who are you?"></asp:Label>
                                </td>
                                <td>
                                        <asp:RadioButton ID="Employee" runat="server" required Text="Employee" GroupName="type"/>  
                                         <asp:RadioButton ID="Customer" required
                                    runat="server" Text="Customer" GroupName="type" />
                                </td>
                                <td>
                                         &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                      <asp:Label ID="Label1" runat="server" Text="Enter E-mail to retrieve password"></asp:Label>
                                </td>
                                <td>
                                       <asp:TextBox ID="txtEmail" runat="server" required CssClass="form-control" ></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                        <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve Password" 
                                    onclick="btnRetrieve_Click" CssClass="btn btn-info"/>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table> 
				</div>
                    </div>
                </div>
           </section>
</asp:Content>

