<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewJalgaonOrder.aspx.cs" Inherits="Personnel_employee_production_ViewJalgaonOrder" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>  View Orders</title>

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
        <form id="form2" runat="server"><asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="wrapper">
        <nav class="navbar navbar-default navbar-cls-top " role="navigation" style="margin-bottom: 0">
            <div class="navbar-header">
               <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="Default.aspx">Sanghavi Unbreakables</a>
            </div>

            <div class="header-right">
 <a href="Default.aspx" class="btn btn-info" title="Profile"><i class="fa fa-user fa-2x"></i></a>
                           <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Personnel/employee/production/Notification.aspx" CssClass="btn btn-primary fa fa-2x" ToolTip="Notification" runat="server"> </asp:HyperLink>
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
                               <asp:Label ID="lblCustName" runat="server" Text="lblCustName"></asp:Label>
                             </div>
                        </div>

                    </li>


                    <li>
                        <a  href="EditProfile.aspx"><i class="fa fa-user "></i>Edit Profile</a>
                    </li>
                   
                       <li>
                        <a href="#" ><i class="fa fa-plus-circle "></i> Stock<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                             <li>
                                 <a href="AddRawMaterial.aspx" ><i class="fa fa-paper-plane"></i>Add New Material </a>
                            </li>   
                           <li>
                                 <a  href="UpdateRawMaterial.aspx" ><i class="fa fa-paper-plane"></i>Inward Raw Material</a>
                            </li>       
                                <li>
                               <a href="CreateStock.aspx"><i class="fa fa-cubes"></i>Create Stock</a>
                            </li>
                                <li>
                               <a href="InwardStock.aspx"><i class="fa fa-cubes"></i>Inward Stock</a>
                            </li>     <li>
                               <a   href="Scrap.aspx"><i class="fa fa-cubes"></i>Scrap</a>
                            </li>  
                              <li>
                               <a   href="ViewStock.aspx" ><i class="fa fa-cubes"></i>View Stock</a>
                            </li>                         
                            </ul>
                    </li>              
                      <li>
                        <a  href="ViewJalgaonOrder.aspx" class="active-menu"><i class="fa fa-user "></i>View Jalgaon Order</a>
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
                        <a  href="Notification.aspx"><i class="fa fa-bell "></i>Notification</a>
                    </li>
                     
                    <li>
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogoutUp_Click"  ><i class="fa fa-sign-out "></i>Logout</asp:LinkButton>   
                    </li>
                </ul>
            </div>

        </nav>
              <div id="page-wrapper">
              <div id="page-inner"> 
                <!-- /. ROW  -->
                <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
               <div class="panel panel-info">
                        <div class="panel-heading">
                           View Jalgaon Orders
                        </div> 
                                 <div class="panel-body"> 
                          <div class="col-md-5 col-sm-5">
                        <div class="table-responsive center-block">
                            <asp:ListView ID="lstOrderVarkhedi" runat="server" DataKeyNames="intId" 
                                DataSourceID="SqlDataSourceOrderVarkhedi" OnItemCommand="listorder_ItemCommand" >
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
                                            <asp:Label ID="intIdLabel" runat="server" Text='<%# Eval("intId") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="dtDateLabel" runat="server" Text='<%# Eval("dtDate") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="tmTimeLabel" runat="server" Text='<%# Eval("tmTime") %>' />
                                        </td>
                                        <td>
                                          <asp:Label ID="varStatusLabel" runat="server" Text='<%# Eval("varStatus") %>' />
                                        </td>
                                        <td>
                                              <asp:LinkButton ID="lnkViewFull" CommandName="View" CommandArgument='<%#Eval("intId") %>' runat="server" ToolTip="View Order" CssClass="fa fa-eye fa-2x btn btn-xs btn-info"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <table id="Table2" runat="server">
                                        <tr id="Tr1" runat="server">
                                            <td id="Td1" runat="server">
                                                <table ID="itemPlaceholderContainer" runat="server" border="0" class="table table-bordered table-responsive">
                                                    <tr id="Tr2" runat="server" style="">
                                                        <th id="Th1" runat="server">
                                                            OrderId</th>
                                                        <th id="Th2" runat="server">
                                                            Date</th>
                                                        <th id="Th3" runat="server">
                                                            Time</th>
                                                        <th id="Th4" runat="server">
                                                          Status</th>
                                                        <th id="Th5" runat="server">
                                                            </th>
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
                            <asp:SqlDataSource ID="SqlDataSourceOrderVarkhedi" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                SelectCommand="SELECT intId, dtDate, tmTime, varReason, varStatus FROM tblsuvarkhediorder  order by CAST( STR_TO_DATE( dtDate,  '%d-%m-%Y' ) AS DATE )">
                            </asp:SqlDataSource>
                        </div>
                       </div>
                        <div class="col-md-7 col-sm-7">
                            <asp:GridView ID="grdDetails" runat="server" 
                                CssClass="table table-bordered table-responsive" AutoGenerateColumns="False" 
                                DataSourceID="SqlDataSourceOrderVarkhediDetails">
                                <Columns>
                                    <asp:BoundField DataField="varProductName" HeaderText="Product Name" 
                                        SortExpression="varProductName" />
                                    <asp:BoundField DataField="intSack" HeaderText="Sack" 
                                        SortExpression="intSack" />
                                    <asp:BoundField DataField="intNug" HeaderText="Nug" 
                                        SortExpression="intNug" />
                                    <asp:BoundField DataField="total" HeaderText="Total Nug" SortExpression="total" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSourceOrderVarkhediDetails" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
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
