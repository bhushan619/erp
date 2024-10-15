<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewProduct.aspx.cs" Inherits="Personnel_employee_marketing_ViewProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 <html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title> View Product</title>

    <!-- BOOTSTRAP STYLES-->
    <link href="../../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />  
    <!-- FONTAWESOME STYLES-->
    <link href="../../assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="../../assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="../../assets/css/custom.css" rel="stylesheet" />
       
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
                          <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Personnel/employee/marketing/Notification.aspx" CssClass="btn btn-primary fa fa-2x" ToolTip="Notification" runat="server"> </asp:HyperLink>
     <asp:LinkButton ID="lnkLogoutUp" runat="server"  class="btn btn-danger fa fa-exclamation-circle fa-2x" 
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
                        <a href="ViewCustomer.aspx"><i class="fa fa-user "></i>View/Update Customer</a>
                    </li> <li>
                                <a href="ViewProduct.aspx" class="active-menu"><i class="fa fa-eye"></i>View Products</a>
                            </li>
                     <li>
                        <a href="#"><i class="fa fa-plus-circle "></i> Order<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                                <a href="CreateOrder.aspx"><i class="fa fa-share"></i>Create Order</a>
                            </li>
                            <li>
                                <a href="ViewOrder.aspx"><i class="fa fa-pencil-square-o"></i>View Orders</a>
                            </li> 
                      
                             
                            </ul>
                    </li>  
                      <li>
                        <a href="#"><i class="fa fa-plus-circle "></i> DSR<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                                <a href="CreateDSR.aspx"><i class="fa fa-share"></i>Create DSR</a>
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
                        <a  href="Collection.aspx"><i class="fa fa-file-excel-o"></i>Collection</a>
                    </li>
                    <li>
                        <a  href="Notification.aspx" ><i class="fa fa-bell "></i>Notification</a>
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
                           List of Product
                        </div>
                        <div class="panel-body">
                        <div class="row">
                              <div class="col-md-3  col-sm-3"> 
                                <div class="form-group "> 
                                <label>Search By Product Name</label>
                                </div>
                                </div>
                               <div class="col-md-6  col-sm-6"> 
                                <div class="form-group "> 
                                           <asp:TextBox ID="txtProductName" runat="server" class="form-control" 
                                                placeholder="Product Name"  ></asp:TextBox>
                                           
                                           <cc1:AutoCompleteExtender ID="txtProductName_AutoCompleteExtender" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionList" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtProductName" UseContextKey="True">
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
                        <div class="table-responsive">

    <asp:ListView ID="listproduct" runat="server" onitemcommand="listproduct_ItemCommand" GroupPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">  
      <LayoutTemplate>
      <table class=" table table-striped table-bordered table-hover">
      <thead>
        <tr>
         
           <th>Product Type</th>
          <th>Product SubType</th>
          <th>Product Name </th>       
                  <th>Size</th>
                <th>Image</th>   
                 <th>Operation</th>          
        </tr>
      </thead>
      <tbody>
        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
      </tbody>
     
        <tfoot>
           <tr id="Tr1" runat="server">
                                            <td id="Td1" runat="server"   style="" colspan = "7">
                                             <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
        
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="listproduct" PageSize="100">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                            ShowNextPageButton="false" />
                        <asp:NumericPagerField ButtonType="Link" />
                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton = "false" />
                    </Fields>
                </asp:DataPager>
          
                                            </td>
                                        </tr>
        </tfoot>
    </table>
  </LayoutTemplate>
  <ItemTemplate>
    <tr>
    
      <td><%# Eval("nvarProductType")%></td>
      <td><%# Eval("nvarProductSubType")%></td>
       <td><%# Eval("nvarProductName")%></td>
      <td><%# Eval("Size")%></td>
       <td align="center">
            
         <asp:Image ID="imgCollege" runat="server"  ImageUrl='<%# "~/Personnel/admin/media/product/" + Eval("imgImage") %>' Width="50px"  Height="50px"/><td>
              <asp:LinkButton ID="EditButton" runat="Server"  CssClass=" btn btn-info fa fa-eye"  CommandName="Edit"  CommandArgument='<%# Eval("intId") %>' />
            </td>
    </tr>
  </ItemTemplate>
 
      </asp:ListView>                 
         </div>
                        </div>
                        </div>
                            </div>

        </div>
             <!--/.ROW-->
             

            </div>
            <!-- /. PAGE INNER  -->
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
    <script src="../../assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="../../assets/js/bootstrap.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="../../assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="../../assets/js/custom.js"></script>

</body>
</html>
