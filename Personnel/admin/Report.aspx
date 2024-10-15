<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Personnel_admin_Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>Report</title>

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
                      <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Personnel/admin/Notification.aspx" CssClass="btn btn-primary fa fa-2x" ToolTip="Notification" runat="server"> </asp:HyperLink>
     <asp:LinkButton ID="lnkLogoutUp" runat="server"  class="btn btn-danger fa fa-exclamation-circle fa-2x" 
                   ToolTip="Logout" onclick="lnkLogoutUp_Click"    ></asp:LinkButton>      

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
                               <asp:Label ID="lblCustName" runat="server" Text="lblAdminName"></asp:Label>
                             </div>
                        </div>

                    </li>
                <li>
                      <a href="#"><i class="fa fa-asterisk "></i> Product<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level">
                          <li>
                                <a href="AddProduct.aspx" ><i class="fa fa-plus-circle"></i>Add Product</a>
                            </li>
                             <li>
                                <a href="AddType.aspx" ><i class="fa fa-plus-circle"></i>Add Type</a>
                            </li>
                             <li>
                                <a href="AddSubType.aspx" ><i class="fa fa-plus-circle"></i>Add SubType</a>
                            </li>
                            <li>
                                <a href="UpdateProduct.aspx"><i class="fa fa-pencil-square-o"></i>Update Product</a>
                            </li>
                              <li>
                                <a href="ViewStock.aspx"><i class="fa fa-cubes"></i>Stock</a>
                            </li>
                            </ul>
                    </li> 
                    <li>
                       <a href="#"><i class="fa fa-smile-o "></i>Employee<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                             <a href="AddEmp.aspx"><i class="fa fa-user "></i>Add Employee</a>
                            </li>
                            <li>
                                 <a href="ViewEmp.aspx"><i class="fa fa-eye "></i>View Employee</a>
                            </li>
                               <li>
                                <a href="ViewEmpDsr.aspx"><i class="fa fa-pencil "></i>DSR</a>
                            </li>                         
                           
                        </ul>
                    </li> 
                    <li>
                       <a href="#"><i class="fa fa-users "></i>Customer<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                                <a href="AddCustomer.aspx"><i class="fa fa-user "></i>Add Customer</a>
                            </li>
                            <li>
                                <a href="ViewCustomer.aspx"><i class="fa fa-eye"></i>View Customer</a>
                            </li> 
                        </ul>
                    </li> 
                       <li>
                        <a href="#"><i class="fa fa-envelope "></i>Messages<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level"> <li>
                                <a href="CreateMessage.aspx"><i class="fa fa-pencil "></i>New Message</a>
                            </li>
                          <li>
                                  <a href="ViewMessages.aspx"><i class="fa fa-comments"></i>Recieved Messages</a>
                            </li>
                           <li>
                                  <a href="ViewSentMessages.aspx"><i class="fa fa-inbox"></i>Sent Messages</a>
                            </li>
                        </ul>
                    </li> 
                   <li>
                      <a href="Report.aspx" class="active-menu"><i class="fa fa-folder "></i>Report</a>
                      
                    </li> 
                    <li>
                           <a  href="ViewConsignmentStatus.aspx"><i class="fa fa-map-marker "></i>Track Consignment</a>
                    </li>
                      
                    <li>
                        <a  href="Notification.aspx"><i class="fa fa-bell "></i>Notifications</a>
                    </li>
                     
                    <li>
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogoutUp_Click"  ><i class="fa fa-sign-out "></i>Logout</asp:LinkButton>   
                    </li>
                </ul>
            </div>

        </nav>
        <!-- /. NAV SIDE  -->
        <div id="page-wrapper">
            <div id="page-inner"> 
                <!-- /. ROW  -->
                 <div class="row">
                  <div class="col-md-12">                     
         <div class="panel panel-info">
                        <div class="panel-heading">
              Report
                        </div>
             <div class="panel-body">
                              <div class="col-lg-4 col-sm-4">
                              Report 1 : <a href="Reports/SalesReport.aspx">Sales</a>
                              </div>
                              <div class="col-lg-4 col-sm-4">
                              Report 2 : <a href="Reports/CreditNote.aspx">Credit Note</a>
                              </div>  <div class="col-lg-4 col-sm-4">
                              Report 3 : <a href="Reports/ProductionReport.aspx">Production</a>
                              </div>
                              <div class="col-lg-4 col-sm-4">
                              Report 4 : <a href="Reports/StockReport.aspx">Stock</a>
                              </div>
                                   <div class="col-lg-4 col-sm-4">
                              Report 5 : <a href="Reports/Collection.aspx">Collection</a>
                              </div>
                                   <div class="col-lg-4 col-sm-4">
                              Report 6 : <a href="Reports/RawMaterial.aspx">Raw Material</a>
                              </div>
                              <div class="col-lg-4 col-sm-4">
                              Report 7 : <a href="Reports/DispatchExpenseSheet.aspx">Dispatch Expenses</a>
                              </div>
                                <div class="col-lg-4 col-sm-4">
                              Report 8 : <a href="Reports/ExpenseSheetReport.aspx">Employee Expenses</a>
                              </div>
                   <div class="col-lg-4 col-sm-4">
                              Report 9 : <a href="Reports/StockRecievedJalgaon.aspx">  Product History & Current Stock</a>
                              </div>
                                  <div class="col-lg-4 col-sm-4">
                              Report 10 : <a href="Reports/ViewOrder.aspx">Orders</a>
                              </div>
                        <%--<div class="panel-body">
                              <div class="col-lg-4 col-sm-4">
                              Report 1 : <a href="Reports/RawMaterial.aspx">Raw Material</a>
                              </div>
                              <div class="col-lg-4 col-sm-4">
                              Report 2 : <a href="Reports/RawMaterialUsage.aspx">Raw Material Usage</a>
                              </div>  <div class="col-lg-4 col-sm-4">
                              Report 3 : <a href="Reports/Production.aspx">Product wise Production</a>
                              </div>
                              <div class="col-lg-4 col-sm-4">
                              Report 4 : <a href="Reports/StockRecievedJalgaon.aspx">Jalgaon Stock</a>
                              </div>
                                   <div class="col-lg-4 col-sm-4">
                              Report 5 : <a href="Reports/ViewOrder.aspx">Orders</a>
                              </div>
                                   <div class="col-lg-4 col-sm-4">
                              Report 6 : <a href="Reports/ProductSale.aspx">Product Sale</a>
                              </div>
                              <div class="col-lg-4 col-sm-4">
                              Report 7 : <a href="Reports/ViewByCustomerProductSale.aspx">Customer Wise Product Sale</a>
                              </div>
                                <div class="col-lg-4 col-sm-4">
                              Report 8 : <a href="Reports/StockReport.aspx">View Stock</a>
                              </div>
                                <div class="col-lg-4 col-sm-4">
                              Report 9 : <a href="Reports/Transport.aspx">Transport  Report</a>
                              </div>
                                <div class="col-lg-4 col-sm-4">
                              Report 10 :<a href="Reports/DistrictWiseCustomer.aspx">DistrictWise Customer  Report</a>
                              </div>
                            <div class="col-lg-4 col-sm-4">
                              Report 11 : <a href="Reports/AllocateDistrictReport.aspx">Allocate District  Report</a>
                              </div>  
                             <div class="col-lg-4 col-sm-4">
                              Report 12 : <a href="Reports/SalesReport.aspx">Sales Report</a>
                              </div>
                             <div class="col-lg-4 col-sm-4">
                              Report 13 : <a href="Reports/Collection.aspx">Collection Report</a>
                              </div>
                               <div class="col-lg-4 col-sm-4">
                              Report 14 : <a href="Reports/ProductionReport.aspx">Production Report</a>
                              </div>
                                <div class="col-lg-4 col-sm-4">
                              Report 15 : <a href="Reports/CreditNote.aspx">Credit Note Report</a>
                              </div>
                              </div>--%>
                        </div>

                        </div>
                    </div>
                 </div>
                </div>
             <!--/.ROW-->
             

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

