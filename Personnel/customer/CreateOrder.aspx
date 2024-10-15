<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="CreateOrder.aspx.cs" Inherits="Personnel_customer_CreateOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 <html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>Create Order</title>

    <!-- BOOTSTRAP STYLES-->
    <link href="../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />  
    <!-- FONTAWESOME STYLES-->
    <link href="../assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="../assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="../assets/css/custom.css" rel="stylesheet" />
       
       <script language="javascript" type="text/javascript">

           function openNewWin(url) {

               var x = window.open(url, 'mynewwin', 'width=600,height=400,left=100, resizable=yes,scrollbars=yes ,menubar=yes');

               x.focus();

           }
           function Confirm() {
               var confirm_value = document.createElement("INPUT");
               confirm_value.type = "hidden";
               confirm_value.name = "confirm_value";
               if (confirm("Do you want to Add order?")) {
                   confirm_value.value = "Yes";
               } else {
                   confirm_value.value = "No";
               }
               document.forms[0].appendChild(confirm_value);
           }

</script>
</head>
<body>
    <form id="form1" runat="server"><asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="wrapper">
        <nav class="navbar navbar-default navbar-cls-top " role="navigation" style="margin-bottom: 0">
            <div class="navbar-header">
               <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="Default.aspx">Sanghavi Unbreakables</a>
            </div>

            <div class="header-right">
 <a href="Default.aspx" class="btn btn-info" title="Profile"><i class="fa fa-user fa-2x"></i></a>
                           <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Personnel/customer/Notification.aspx" CssClass="btn btn-primary fa fa-2x" ToolTip="Notification" runat="server"> </asp:HyperLink>
     <asp:LinkButton ID="lnkLogoutUp" runat="server"  class="btn btn-danger fa fa-exclamation-circle fa-2x" 
                   ToolTip="Logout" onclick="lnkLogout_Click"    ></asp:LinkButton>      

            </div>
        </nav>
        <!-- /. NAV TOP  -->
        <nav class="navbar-default navbar-side" role="navigation">
            <div class="sidebar-collapse">
                 <ul class="nav" id="main-menu">
                    <li>
                        <div class="user-img-div">
                        <asp:Image ID="imgProPic"   CssClass=" img-thumbnail"  runat="server"></asp:Image>

                             <div class="inner-text"> 
                               <asp:Label ID="lblCustName" runat="server" Text="lblCustName"></asp:Label>
                             </div>
                        </div>

                    </li>


                    <li>
                        <a  href="EditProfile.aspx"><i class="fa fa-user "></i>Edit Profile</a>
                    </li>
                      <li>
                        <a href="ViewProduct.aspx"><i class="fa fa-user "></i>View Products</a>
                    </li>
                     <li>
                        <a href="#" class="active-menu-top"><i class="fa fa-cubes "></i> Order<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level  collapse in">
                          <li>
                                <a class="active-menu" href="CreateOrder.aspx"><i class="fa fa-share"></i>Create Order</a>
                            </li>
                            <li>
                            <a href="ViewOrder.aspx"><i class="fa fa-eye"></i>View Orders</a>
                            </li>

                            </ul>
                    </li> 
                    <li>
                        <a href="#"><i class="fa fa-envelope "></i>Messages<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level">
                          <li>
                                <a href="AddEnquiry.aspx"><i class="fa fa-pencil"></i>New Message</a>
                            </li>
                            <li>
                                <a href="ViewConversation.aspx"><i class="fa fa-comment"></i>View Messages</a>
                            </li>
                              <li>
                                <a href="ViewSentMessages.aspx"><i class="fa fa-inbox"></i>Sent Messages</a>
                            </li>
                           
                        </ul>
                    </li> 
                   
                    <li>
                           <a  href="TrackOrder.aspx"><i class="fa fa-map-marker "></i>Track Consignment</a>
                    </li>
                     
                    <li>
                        <a  href="Notification.aspx"><i class="fa fa-bell "></i>Notification</a>
                    </li>
                     
                    <li>
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogout_Click"   ><i class="fa fa-sign-out "></i>Logout</asp:LinkButton>   
                    </li>
                </ul>
            </div>

        </nav>
        <!-- /. NAV SIDE  -->
        <div id="page-wrapper">
             <div id="page-inner">
                 
                <div class="row">
                 <div class="col-md-12 ">
              <div class="panel panel-primary">
                        <div class="panel-heading">
                         Create Order No. : 
                         <asp:Label ID="lblOrderNo" runat="server" Text="Order No."></asp:Label>
                    </div>
                   <div class="panel-body"> 
                       
                <div class="row">
                 <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="col-md-4 col-sm-4">
               <div class="panel panel-primary">
                        <div class="panel-heading">
                           ADD TO ORDER 
                        </div>

                        <div class="panel-body">
                            <div role="form">
                                     <div class="form-group">
                               
                                <asp:DropDownList ID="ddlProName" runat="server" CssClass="form-control"   
                                             DataSourceID="SqlDataSource2" DataTextField="ProductName" 
                                                 DataValueField="ProductName" AppendDataBoundItems="true"
                                             onselectedindexchanged="ddlProName_SelectedIndexChanged" 
                                             AutoPostBack="True" >
                                              <asp:ListItem Text="-- Select Product --" />
                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                              ></asp:SqlDataSource>
                                        </div>
                                       
                                    
                  <div class=" form-group input-group">
    <asp:TextBox ID="txtTotalProducts" runat="server" placeholder="Total Nugs" 
                                                    class="form-control"  required onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                                                    ontextchanged="txtSack_TextChanged" AutoPostBack="True" ></asp:TextBox> 
                                                <span class="form-group input-group-btn">
                                                <p class="btn btn-default" >Total Nugs</p>
                                                  </span>
                                                </div> 
                                                <div class="row">
                                                               <div class="col-lg-6 col-sm-6">
                              <div class=" form-group">
                                Sack:<asp:Label ID="lblSack" runat="server" Text="Sack"></asp:Label> 
                                                </div>
                              </div>
                                 <div class="col-lg-6 col-sm-6">
                                 <div class=" form-group">
                                    Nug: <asp:Label ID="lblNug" runat="server" Text="Nug"></asp:Label> 
                                                </div>
                                                </div>
                               </div>
                                           
                                                <div class="form-group"> 
                                                  Price: <asp:Label ID="txtPrice" runat="server"   />
                                        </div>
                                           
                                                 <div class="form-group">
                                                 
                                                     <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" placeholder ="Remark" class="form-control"></asp:TextBox>
                                                 </div>     
                                                 <div class="form-group">
                                                     <asp:Button ID="btnAddToOrder" runat="server" Text="Add to Order" 
                                                         CssClass="btn btn-info" onclick="btnAddToOrder_Click"/>
                                                     <asp:LinkButton ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-danger" 
                                                         onclick="btnReset_Click"/>
                                                 </div>
                                  </div>
                            </div>
                        </div>
                            </div>
<div class="col-md-8 col-sm-8">
               <div class="panel panel-danger">
                        <div class="panel-heading">
                       ORDER DETAILS
                        </div>
                        <div class="panel-body">
                   <div class="table-responsive">
                              
                            <asp:GridView ID="grdOrderDetails" runat="server"  
                                CssClass="table table-striped table-bordered " 
                                onrowcommand="grdOrderDetails_RowCommand"  
                                >  <Columns>
   <asp:TemplateField>
   <ItemTemplate>
   <asp:LinkButton ID="Button2" runat="server" Text="" CommandName="remove" 
   CommandArgument='<%#Container.DataItemIndex+","+ Eval("Sack")+","+Eval("Nag")+","+Eval("Price") %>' CssClass="btn btn-xs btn-danger fa fa-times" />
   </ItemTemplate>
   </asp:TemplateField>
        </Columns>
                            </asp:GridView>
                         </div>
 <div class="panel-body">
   <div class="form-group">
     <asp:TextBox ID="txtModeOfPayment" CssClass="form-control" placeholder="Mode Of Payment" runat="server"></asp:TextBox>
 </div> 
 <div class="form-group">
     <asp:TextBox ID="txtDestination" CssClass="form-control" placeholder="Destination" runat="server"></asp:TextBox>
 </div>
                         Total Sack :<asp:Label ID="lblProductTotalSack" runat="server" Text="Label"></asp:Label>
                         Total Nag : <asp:Label ID="lblProductTotalNag" runat="server" Text="Label"></asp:Label>
                         Total Price : <asp:Label ID="lblProductTotalPrice" runat="server" Text="Label"></asp:Label>
                          <asp:LinkButton ID="btnAdd"  OnClientClick="return Confirm();" runat="server" Text="Create Order" CssClass="btn btn-success" 
                                                         onclick="btnAdd_Click" />&nbsp;
                        <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" class="btn btn-warning" ></asp:LinkButton>
                            </div>             </div>
                       
                        </div>
                            </div>
        </div>
        </div> 
                       
                       </div>

        </div>
             <!--/.ROW--> 

            </div>
        </div>
             <!--/.ROW--> 

            </div>
            <!-- /. PAGE INNER  -->
        </div>
        <!-- /. PAGE WRAPPER  -->
    </div>
    
    </form>
    <div id="footer-sec">
        &copy; 2015 Sanghavi Unbreakables | Design By <a href="http://www.anuvaasoft.com/" target="_blank">Anuvaa Softech Pvt. Ltd.</a>
    </div>
    <!-- /. FOOTER  -->
    <!-- SCRIPTS -AT THE BOTOM TO REDUCE THE LOAD TIME-->
    <!-- JQUERY SCRIPTS -->
    <script src="../assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="../assets/js/bootstrap.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="../assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="../assets/js/custom.js"></script>

</body>
</html>