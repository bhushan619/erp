<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewOrderFull.aspx.cs" Inherits="Personnel_customer_ViewOrderFull" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
 <head id="Head1" runat="server">
    
     <title>  View Full Order </title>

    <!-- BOOTSTRAP STYLES-->
   
    <link href="../assets/css/animate.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />  
    <!-- FONTAWESOME STYLES-->
    <link href="../assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="../assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="../assets/css/custom.css" rel="stylesheet" />
     <link href="../assets/css/pricing.css" rel="stylesheet" />
       
       <script language="javascript" type="text/javascript">

           function openNewWin(url) {

               var x = window.open(url, 'mynewwin', 'width=600,height=400,left=100, resizable=yes,scrollbars=yes ,menubar=yes');

               x.focus();

           }
  
    </script>
</head>
<body>
     <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
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
                               <asp:Label ID="lblCustName" runat="server" Text="lbladminName"></asp:Label>
                             </div>
                        </div>

                    </li>


                    <li>
                        <a  href="EditProfile.aspx"><i class="fa fa-user "></i>Edit Profile</a>
                    </li> <li>
                        <a   href="ViewProduct.aspx"><i class="fa fa-user "></i>View Products</a>
                    </li>
                     <li>
                        <a class="active-menu-top" href="#"><i class="fa fa-plus-circle "></i> Order<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level collapse in">
                          <li>
                                <a href="CreateOrder.aspx"><i class="fa fa-share"></i>Create Order</a>
                            </li>
                            <li>
                                <a class="active-menu" href="ViewOrder.aspx"><i class="fa fa-pencil-square-o"></i>View Orders</a>
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
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogout_Click"    ><i class="fa fa-sign-out "></i>Logout</asp:LinkButton>   
                    </li>
                </ul>
            </div>

        </nav>
        <!-- /. NAV SIDE  -->
        <div id="page-wrapper">
              <div id="page-inner"> 
                <!-- /. ROW  -->
                <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                   <div class="panel panel-primary">
                        <div class="panel-heading">
                          Full Order  details for Order ID : 
                                    <asp:Label ID="lblOrderNo" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="panel-body"> 
                        <div class="row"> 
                               <div class="col-md-6  col-sm-6"> 
                                <div class="table-responsive"> 
                                                    <asp:ListView ID="listorder" runat="server" DataSourceID="SqlDataSource1"   
                                DataKeyNames="intOrderId" >
                                <AlternatingItemTemplate>
                                          <span style="">
                                         <table class="table table-bordered table-responsive">
                                 <tr>
                                 <td>Order Id:</td>
                                  <td> <asp:Label ID="intOrderIdLabel" runat="server" 
                                         Text='<%# Eval("intOrderId") %>' /></td></tr>
                                         <tr>
                                         <td>Company Name:</td>
                                         <td><asp:Label ID="intCustIdLabel" runat="server" Text='<%# Eval("comname") %>' /></td>
                                         </tr>
                                         <tr>
                                         <td>Contact:</td>
                                         <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("mobile") %>' /></td>
                                         </tr>
                                      <tr>
                                         <td>Status:</td>
                                         <td><asp:Label ID="varStatusLabel" runat="server" Text='<%# Eval("varStatus") %>' /></td>
                                         </tr>  
                                         <tr>
                                         <td>Date:</td>
                                         <td>   <asp:Label ID="dtDateLabel" runat="server" Text='<%# Eval("dtDate") %>' /></td>
                                         </tr> 
                                         <tr>
                                         <td>Total Sack:</td>
                                         <td>  <asp:Label ID="varProductTotalLabel" runat="server" 
                                         Text='<%# Eval("varProductTotal") %>' /></td>
                                         </tr>
                                         <tr>
                                         <td>Total Nag:</td>
                                         <td> <asp:Label ID="varTotalNagLabel" runat="server" 
                                         Text='<%# Eval("varTotalNag") %>' /></td>
                                         </tr>

                                         <tr>
                                         <td>Total Price:</td>
                                         <td><asp:Label ID="varPriceTotalLabel" runat="server" 
                                         Text='<%# Eval("varPriceTotal") %>' /></td>
                                         </tr>
                                 </table>
                                  </span>
                                </AlternatingItemTemplate>
 
                                 <ItemTemplate>
                             
                                     <span style="">
                                         <table class="table table-bordered table-responsive">
                                 <tr>
                                 <td>Order Id:</td>
                                  <td> <asp:Label ID="intOrderIdLabel" runat="server" 
                                         Text='<%# Eval("intOrderId") %>' /></td></tr>
                                         <tr>
                                         <td>Company Name:</td>
                                         <td><asp:Label ID="intCustIdLabel" runat="server" Text='<%# Eval("comname") %>' /></td>
                                         </tr>
                                           <tr>
                                         <td>Contact:</td>
                                         <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("mobile") %>' /></td>
                                         </tr>
                                      <tr>
                                         <td>Status:</td>
                                         <td><asp:Label ID="varStatusLabel" runat="server" Text='<%# Eval("varStatus") %>' /></td>
                                         </tr>  
                                         <tr>
                                         <td>Date:</td>
                                         <td>   <asp:Label ID="dtDateLabel" runat="server" Text='<%# Eval("dtDate") %>' /></td>
                                         </tr> 
                                         <tr>
                                         <td>Total Sack:</td>
                                         <td>  <asp:Label ID="varProductTotalLabel" runat="server" 
                                         Text='<%# Eval("varProductTotal") %>' /></td>
                                         </tr>
                                         <tr>
                                         <td>Total Nag:</td>
                                         <td> <asp:Label ID="varTotalNagLabel" runat="server" 
                                         Text='<%# Eval("varTotalNag") %>' /></td>
                                         </tr>

                                         <tr>
                                         <td>Total Price:</td>
                                         <td><asp:Label ID="varPriceTotalLabel" runat="server" 
                                         Text='<%# Eval("varPriceTotal") %>' /></td>
                                         </tr>
                                 </table>
                                  </span>
                                </ItemTemplate>
                                  
                                <EmptyDataTemplate>
                                    <span>No data was returned.</span>
                                </EmptyDataTemplate>
                                 
                                
                                <LayoutTemplate>
                                    <div ID="itemPlaceholderContainer" runat="server" style="">
                                        <span runat="server" id="itemPlaceholder" />
                                    </div>
                                    <div style="">
                                    </div>
                                </LayoutTemplate>
                                  
                            </asp:ListView>
                              
                          
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                        ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>"
                                       SelectCommand="SELECT intOrderId, (SELECT varCompanyName from sanghaviunbreakables.tblsucustomer WHERE (intId = @CustId) ) as comname,(SELECT varMobile from sanghaviunbreakables.tblsucustomer WHERE (intId = @CustId) ) as mobile, varStatus, dtDate, varProductTotal, varTotalNag, varPriceTotal FROM sanghaviunbreakables.tblsuorder WHERE (intOrderId = @OrderId)"
                                        
                                       >
                                                                         <SelectParameters>
                                    <asp:SessionParameter Name="OrderId" SessionField="orderid" Type="Int64" />
                                     <asp:SessionParameter Name="CustId" SessionField="custid" Type="Int64" />
                                </SelectParameters>
                                    </asp:SqlDataSource>
                               <div class="form-group">
                                <asp:LinkButton ID="lnkBack" runat="server" CssClass="btn btn-primary" 
                                        onclick="lnkBack_Click">Back</asp:LinkButton>
                            </div>
                          
                                        </div>  
                                </div>
                                   <div class="col-md-6 col-sm-6">
                                   <div class="table-responsive">

                           <asp:ListView ID="lstOrderDetails" runat="server" DataKeyNames="intId" 
                           DataSourceID="SqlDataSource2"  
                                         >
                                           <AlternatingItemTemplate>
                                               <tr style="">
                                                   <td>
                                                       <asp:Label ID="varProductNameLabel" runat="server" 
                                                           Text='<%# Eval("varProductName") %>' />
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="varQuantityLabel" runat="server" 
                                                           Text='<%# Eval("varQuantity") %>' />
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="varNagLabel" runat="server" Text='<%# Eval("varNag") %>' />
                                                   </td> 
                                                   <td>
                                                       <asp:Label ID="Label2" runat="server" Text='<%# Eval("total") %>' />
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="varPriceLabel" runat="server" Text='<%# Eval("varPrice") %>' />
                                                   </td>
                                                     
                                               </tr>
                                           </AlternatingItemTemplate>
                                           <EmptyDataTemplate>
                                               <table id="Table1" runat="server" style="">
                                                   <tr>
                                                       <td>
                                                           No data was returned.</td>
                                                   </tr>
                                               </table>
                                           </EmptyDataTemplate> 
                                           <ItemTemplate>
                                               <tr style="">
                                                 <td>
                                                       <asp:Label ID="varProductNameLabel" runat="server" 
                                                           Text='<%# Eval("varProductName") %>' />
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="varQuantityLabel" runat="server" 
                                                           Text='<%# Eval("varQuantity") %>' />
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="varNagLabel" runat="server" Text='<%# Eval("varNag") %>' />
                                                   </td>
                                                    <td>
                                                       <asp:Label ID="Label2" runat="server" Text='<%# Eval("total") %>' />
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="varPriceLabel" runat="server" Text='<%# Eval("varPrice") %>' />
                                                   </td>
                                                   
                                               </tr>
                                           </ItemTemplate>
                                           <LayoutTemplate>
                                               <table id="Table2" runat="server">
                                                   <tr id="Tr1" runat="server">
                                                       <td id="Td1" runat="server">
                                                           <table ID="itemPlaceholderContainer" runat="server" border="0" class="table table-bordered table-responsive" >
                                                               <tr id="Tr2" runat="server" style="">
                                                                   
                                                                   <th id="Th1" runat="server">
                                                                       Product Name</th>
                                                                   <th id="Th2" runat="server">
                                                                       Sack</th>
                                                                   <th id="Th3" runat="server">
                                                                       Nag</th>
                                                                        <th id="Th4" runat="server">
                                                                       Total</th>
                                                                   <th id="Th5" runat="server">
                                                                       Price</th>
                                                                      
                                                                      
                                                               </tr>
                                                               <tr ID="itemPlaceholder" runat="server">
                                                               </tr>
                                                           </table>
                                                       </td>
                                                   </tr>
                                                   <tr id="Tr3" runat="server">
                                                       <td id="Td2" runat="server" style="">
                                                           <asp:DataPager ID="DataPager1" runat="server">
                                                               <Fields>
                                                                   <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                                                       ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                                   <asp:NumericPagerField />
                                                                   <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                                                       ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                               </Fields>
                                                           </asp:DataPager>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </LayoutTemplate>
                                           
                                       </asp:ListView>
                                         
                                  <asp:SqlDataSource ID="SqlDataSource2" runat="server"  
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>"   
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                SelectCommand="SELECT tblsuorderdetails.intId, tblsuorderdetails.intProductId, tblsuorderdetails.varProductName, tblsuorderdetails.varQuantity, tblsuorderdetails.varNag, tblsuproducts.intPacking * tblsuorderdetails.varQuantity + tblsuorderdetails.varNag AS total
, varPrice, varRemark FROM            tblsuorderdetails, tblsuproducts
WHERE        tblsuorderdetails.intProductId = tblsuproducts.intId  and (intOrderId = @orderid)"
                                
                               >
                                <SelectParameters>
                                    <asp:SessionParameter Name="OrderId" SessionField="orderid" Type="Int64" />
                                </SelectParameters>
                                
                            </asp:SqlDataSource> 
                        </div>
                                    </div>
                                  </div>
                                </div>
                               
                        
                        </div>
                        </div>
                            </div>

        </div>
        
            <!-- /. PAGE INNER  -->
        </div>
            <!-- /. PAGE INNER  -->
        </div>
        <!-- /. PAGE WRAPPER  --> 
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
