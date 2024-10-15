<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="ViewBill.aspx.cs" Inherits="Personnel_employee_ViewBill" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>  View Bills</title>

    <!-- BOOTSTRAP STYLES-->
   
      <!-- BOOTSTRAP STYLES-->
    <link href="../../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />  
    <!-- FONTAWESOME STYLES-->
    <link href="../../assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="../../assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="../../assets/css/custom.css" rel="stylesheet" />
       <link href="../../assets/css/bootstrap-fileupload.min.css" rel="stylesheet" />
       
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
                           <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Personnel/employee/marketing/Notification.aspx" CssClass="btn btn-primary fa fa-2x" ToolTip="Notification" runat="server"> </asp:HyperLink>
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
                        <a href="EditProfile.aspx"><i class="fa fa-user "></i>Edit Profile</a>
                    </li>
                     <li>
                        <a href="ViewCustomer.aspx"><i class="fa fa-user "></i>View/Update Customer</a>
                    </li>
                      <li>
                                <a href="ViewProduct.aspx"><i class="fa fa-eye"></i>View Products</a>
                            </li>
                     <li>
                        <a href="#" class="active-menu"><i class="fa fa-plus-circle "></i> Order<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level collapse in">
                          <li>
                                <a href="CreateOrder.aspx"><i class="fa fa-share"></i>Create Order</a>
                            </li>
                            <li>
                                <a href="ViewOrder.aspx"><i class="fa fa-pencil-square-o"></i>View Orders</a>
                            </li> 
                            <li>
                                <a href="ViewBill.aspx" class="active-menu-top"><i class="fa fa-eye"></i>View Bills</a>
                            </li>
                            </ul>
                    </li>  
                      <li>
                        <a href="#"><i class="fa fa-plus-circle "></i> DSR<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                                <a href="CreateDSR.aspx"><i class="fa fa-share"></i>Create DSR</a>
                            </li>
                            <li>
                                <a href="#"><i class="fa fa-pencil-square-o"></i>View DSR</a>
                            </li>
                            </ul>
                    </li>       
                     <li>
                        <a href="#"><i class="fa fa-plus-circle "></i> Expense Sheet<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                                <a href="ExpenseSheet.aspx"><i class="fa fa-share"></i>Create Expense Sheet</a>
                            </li>
                            <li>
                                <a href="ViewExpenseSheet.aspx"><i class="fa fa-pencil-square-o"></i>View Expense Sheet</a>
                            </li>
                            </ul>
                    </li>       
                     <li>
                      <a href="#" ><i class="fa fa-envelope "></i>Messages<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level  ">
                         <li>
                                <a href="AddEnquiry.aspx"><i class="fa fa-pencil "></i>New Message</a>
                            </li>
                          <li>
                                <a href="InboxMsg.aspx"><i class="fa fa-comment"></i>Recieved Messages</a>
                            </li>
                             <li>
                                <a  href="ViewSentMessages.aspx"><i class="fa fa-inbox"></i>Sent Messages</a>
                            </li>
                        </ul>
                    </li>  
                        <li>
                           <a  href="DownloadReceivablesFile.aspx"><i class="fa  fa-download "></i>Download Receivables File</a>
                    </li>
                    <li>
                           <a  href="ViewConsignmentStatus.aspx"><i class="fa fa-map-marker "></i>Track Consignment</a>
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
            <div class="col-md-12 col-sm-12 col-xs-12">
               <div class="panel panel-info">
                        <div class="panel-heading">
                           View Orders
                        </div>
                        <div class="panel-body"> 
                      
                              <div class="col-md-3  col-sm-3"> 
                                <div class="form-group "> 
                                <label>Search By Company Name</label>
                                </div>
                                </div>
                               <div class="col-md-6  col-sm-6"> 
                                <div class="form-group "> 
                                           <asp:TextBox ID="txtCmpName" runat="server" class="form-control" 
                                                placeholder="Company Name"  ></asp:TextBox>
                                           
                                           <cc1:AutoCompleteExtender ID="txtCmpName_AutoCompleteExtender" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionList" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtCmpName" UseContextKey="True">
                                           </cc1:AutoCompleteExtender>
                                           
                                        </div>  
                                </div>
                                  <div class="col-md-2  col-sm-2">
                                    <div class="form-group">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" 
                                                CssClass="btn btn-primary" onclick="btnSearch_Click" />
                                           
                                        </div> 
                                  </div>
                                   
                                </div>
                                 <div class="panel-body"> 
                       
                        <div class="table-responsive center-block">

                     
                            <asp:ListView ID="listorder" runat="server" DataSourceID="SqlDataSource2"  onitemcommand="listorder_ItemCommand"
                                DataKeyNames="Order ID,Bill Number" GroupPlaceholderID="groupPlaceHolder1" 
                             >
                                <AlternatingItemTemplate>
                                    <tr style="">
                                        <td>
                                            <asp:Label ID="Order_IDLabel" runat="server" 
                                                Text='<%# Eval("[Order ID]") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Bill_NumberLabel" runat="server" 
                                                Text='<%# Eval("[Bill Number]") %>' />
                                        </td>
                                           <td>
                                            <asp:Label ID="CustomerLabel" runat="server" Text='<%# Eval("Customer") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="ContactLabel" runat="server" Text='<%# Eval("Contact") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                                        </td> 
                                        <td>
                                            <asp:Label ID="Bill_AmtLabel" runat="server" 
                                                Text='<%# Eval("[Bill Amt]") %>' />
                                        </td>
                                        <td>
                                             <asp:Label ID="varStatusLabel" runat="server" Text='<%# Eval("varStatus") %>' />
                                         </td>
                                           <td>
                                             <asp:LinkButton ID="lnkViewFull" CommandName="View" CommandArgument='<%#Eval("[Bill Number]")+","+ Eval("[Order ID]")%>' runat="server" ToolTip="View Bill" CssClass="fa fa-eye btn btn-xs btn-info"></asp:LinkButton>
                                              
                                             
                                             <asp:LinkButton ID="LinkButton1" CommandName="Print"  CommandArgument='<%#Eval("[Bill Number]")+","+ Eval("[Order ID]")%>' runat="server" ToolTip="Print Bill" CssClass="fa fa-print btn btn-xs btn-danger"></asp:LinkButton>
                                         </td>
                                    </tr>
                                </AlternatingItemTemplate> 
                                  
                                 <ItemTemplate>
                                    <tr style="">
                                        <td>
                                            <asp:Label ID="Order_IDLabel" runat="server" 
                                                Text='<%# Eval("[Order ID]") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Bill_NumberLabel" runat="server" 
                                                Text='<%# Eval("[Bill Number]") %>' />
                                        </td>
                                         <td>
                                            <asp:Label ID="CustomerLabel" runat="server" Text='<%# Eval("Customer") %>' />
                                        </td>
                                         <td>
                                             <asp:Label ID="ContactLabel" runat="server" Text='<%# Eval("Contact") %>' />
                                         </td>
                                        <td>
                                            <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                                        </td>
                                        
                                        <td>
                                            <asp:Label ID="Bill_AmtLabel" runat="server" 
                                                Text='<%# Eval("[Bill Amt]") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="varStatusLabel" runat="server" Text='<%# Eval("varStatus") %>' />
                                        </td>
                                          <td>
                                             <asp:LinkButton ID="lnkViewFull" CommandName="View" CommandArgument='<%#Eval("[Bill Number]")+","+ Eval("[Order ID]")%>' runat="server" ToolTip="View Bill" CssClass="fa fa-eye btn btn-xs btn-info"></asp:LinkButton>
                                              
                                             
                                             <asp:LinkButton ID="LinkButton1" CommandName="Print"  CommandArgument='<%#Eval("[Bill Number]")+","+ Eval("[Order ID]")%>' runat="server" ToolTip="Print Bill" CssClass="fa fa-print btn btn-xs btn-danger"></asp:LinkButton>
                                         </td>
                                    </tr>
                                </ItemTemplate> 
                                 
                                <EmptyDataTemplate>
                                    <table runat="server" style="">
                                        <tr>
                                            <td>
                                                No data was returned.</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                 
                                
                                <LayoutTemplate>
                                    <table runat="server">
                                        <tr runat="server">
                                            <td runat="server">
                                                <table ID="itemPlaceholderContainer" runat="server" border="0" class="table table-bordered table-responsive">
                                                    <tr runat="server" style="">
                                                        <th runat="server">
                                                            Order ID</th>
                                                        <th runat="server">
                                                            Bill Number</th>
                                                        <th runat="server">
                                                            Customer</th>
                                                        <th runat="server">
                                                            Contact</th>
                                                        <th runat="server">
                                                            Date</th>
                                                        <th runat="server">
                                                            Bill Amt</th>
                                                        <th runat="server">
                                                            Status</th>
                                                    </tr>
                                                    <tr runat="server" ID="itemPlaceholder">
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server">
                                            <td runat="server" style="">
        
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
                                SelectCommand="SELECT        tblsuorder.intOrderId AS `Order ID`, tblsubill.intBillNO AS `Bill Number`, tblsucustomer.varCompanyName AS Customer, tblsucustomer.varMobile AS Contact, 
                         tblsubill.dtDate AS `Date`, tblsubill.varBillTotal AS `Bill Amt`, tblsuconsignment.varStatus
FROM            tblsuorder, tblsucustomer, tblsubill, tblsuconsignment
WHERE        tblsuorder.intCustId = tblsucustomer.intId AND tblsuorder.intOrderId = tblsubill.intOrderId AND tblsubill.intOrderId = tblsuconsignment.intOrderId AND 
                         (tblsuconsignment.varStatus = 'In Transit')"  
                               >
                                
                            </asp:SqlDataSource>
                            
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
    <script src="../../assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="../../assets/js/bootstrap.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="../../assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="../../assets/js/custom.js"></script>
    
</body>
</html>
