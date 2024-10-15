<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="CancelOrder.aspx.cs" Inherits="Personnel_customer_CancelOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>Cancel Order</title>

    <!-- BOOTSTRAP STYLES-->
    <link href="../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />  
    <!-- FONTAWESOME STYLES-->
    <link href="../assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="../assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="../assets/css/custom.css" rel="stylesheet" />
       <link href="../assets/css/bootstrap-fileupload.min.css" rel="stylesheet" />
      <script language="javascript" type="text/javascript">
          function Confirm() {
              var confirm_value = document.createElement("INPUT");
              confirm_value.type = "hidden";
              confirm_value.name = "confirm_value";
              if (confirm("Are you sure.. You want to Add/Update/Delete ?")) {
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
     <asp:LinkButton ID="LinkButton1" runat="server"  class="btn btn-danger fa fa-exclamation-circle fa-2x" 
                   ToolTip="Logout" onclick="lnkLogout_Click"   ></asp:LinkButton>      

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
                        <a href="EditProfile.aspx"><i class="fa fa-user "></i>Edit Profile</a>
                    </li>
                      <li>
                        <a href="ViewProduct.aspx"><i class="fa fa-user "></i>View Products</a>
                    </li>
                     <li>
                        <a  class="active-menu" href="#"><i class="fa fa-plus-circle "></i> Order<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level">
                          <li>
                                 <a href="CreateOrder.aspx"><i class="fa fa-cubes"></i>Create Order</a>
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
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogout_Click"  ><i class="fa fa-sign-out "></i>Logout</asp:LinkButton>   
                    </li>
                </ul>
            </div>

        </nav>
        <!-- /. NAV SIDE  -->
        <div id="page-wrapper">
            <div id="page-inner"> 
                <!-- /. ROW  -->
                <div class="row">
            <div class="col-md-12 col-sm-12">
               <div class="panel panel-primary">
                        <div class="panel-heading">
                           Cancel Order
                        </div>
                        <div class="panel-body">
                          
                         <div class="col-md-6 col-sm-6">
                                   <div class="table-responsive">

                            <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource2" 
                                DataKeyNames="intId">
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
                                            <asp:Label ID="varPriceLabel" runat="server" Text='<%# Eval("varPrice") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="varRemarkLabel" runat="server" Text='<%# Eval("varRemark") %>' />
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                                 
                                <EmptyDataTemplate>
                                    <table id="Table3" runat="server" style="">
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
                                            <asp:Label ID="varPriceLabel" runat="server" Text='<%# Eval("varPrice") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="varRemarkLabel" runat="server" Text='<%# Eval("varRemark") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <table id="Table4" runat="server">
                                        <tr id="Tr4" runat="server">
                                            <td id="Td3" runat="server">
                                                <table ID="itemPlaceholderContainer" runat="server" border="0"  class="table table-bordered table-responsive">
                                                    <tr id="Tr5" runat="server" style=""> 
                                                        <th id="Th8" runat="server">
                                                            Product Name</th>
                                                        <th id="Th9" runat="server">
                                                            Sack</th>
                                                        <th id="Th10" runat="server">
                                                            Nag</th>
                                                        <th id="Th11" runat="server">
                                                            Price</th>
                                                        <th id="Th12" runat="server">
                                                             Remark</th>
                                                    </tr>
                                                    <tr ID="itemPlaceholder" runat="server">
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="Tr6" runat="server">
                                            <td id="Td4" runat="server" style="">
                                                <asp:DataPager ID="DataPager1" runat="server">
                                                    <Fields>
                                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                                            ShowLastPageButton="True" />
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
                                SelectCommand="SELECT intId, intProductId, varProductName, varQuantity, varNag, varPrice, varRemark FROM sanghaviunbreakables.tblsuorderdetails  WHERE (intOrderId = @orderid)" 
                                
                               >
                                <SelectParameters>
                                    <asp:SessionParameter Name="OrderId" SessionField="orderid" Type="Int64" />
                                </SelectParameters>
                                
                            </asp:SqlDataSource>
                           
                        </div>
                                    </div>
                       <div class="col-md-6 col-sm-6">
                          <div class="form-group">
                              <asp:TextBox ID="txtReason" required placeholder="Reason to Cancel Order"  runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                          </div> 
                               <div class="form-group">
                              <asp:Button ID="btnCancel" CssClass="btn btn-danger"
                                  runat="server" Text="Cancel Order" onclick="btnCancel_Click"  OnClientClick="return Confirm();"/>
                                    <asp:LinkButton ID="btnBack" CssClass="btn btn-primary"
                                  runat="server" Text="Back" PostBackUrl="~/Personnel/customer/ViewOrder.aspx"  />
                          </div>
                             </div>   </div>  </div>
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