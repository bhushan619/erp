<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="ViewOrder.aspx.cs" Inherits="Personnel_customer_ViewOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 <html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title> View Orders</title>

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
                               <asp:Label ID="lblCustName" runat="server" Text="lblCustName"></asp:Label>
                             </div>
                        </div>

                    </li>


                    <li>
                        <a  href="EditProfile.aspx"><i class="fa fa-user "></i>Edit Profile</a>
                    </li><li>
                        <a   href="ViewProduct.aspx"><i class="fa fa-user "></i>View Products</a>
                    </li>
                     <li>
                        <a href="#" class="active-menu"><i class="fa fa-asterisk"></i> Order<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level collapse in">
                          <li>
                                <a href="CreateOrder.aspx"><i class="fa fa-cubes"></i>Create Order</a>
                            </li>
                            <li>
                                <a href="ViewOrder.aspx" class="active-menu-top"><i class="fa fa-eye"></i>View Orders</a>
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
            <div class="col-md-12 col-sm-12 col-xs-12">
                   <div class="panel panel-primary">
                        <div class="panel-heading">
                           View Orders
                        </div> 
                                 <div class="panel-body"> 
                       
                        <div class="table-responsive center-block">

                     
                            <asp:ListView ID="listorder" runat="server" DataSourceID="SqlDataSource2"  onitemcommand="listorder_ItemCommand"
                                DataKeyNames="intOrderId,intId" GroupPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">
                                <AlternatingItemTemplate>
                                    <tr style="">
                                        <td>
                                            <asp:Label ID="intOrderIdLabel" runat="server" 
                                                Text='<%# Eval("intOrderId") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="comnameLabel" runat="server" Text='<%# Eval("comname") %>' />
                                        </td>
                                           <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("mobile") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="varStatusLabel" runat="server" Text='<%# Eval("varStatus") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="dtDateLabel" runat="server" Text='<%# Eval("dtDate") %>' />
                                        </td> 
                                        <td>
                                            <asp:Label ID="varPriceTotalLabel" runat="server" 
                                                Text='<%# Eval("varPriceTotal") %>' />
                                        </td>
                                      <td>
                                             <asp:LinkButton ID="lnkViewFull" CommandName="View" CommandArgument='<%#Eval("intOrderId")+","+ Eval("intCustId")%>' runat="server" ToolTip="View Order" CssClass="fa fa-eye btn btn-xs btn-info"></asp:LinkButton>
                                <%--   <asp:LinkButton ID="LinkButton2" CommandName="ViewBill" CommandArgument='<%#Eval("intOrderId")+","+ Eval("intCustId")%>'  runat="server" ToolTip="View Bill" CssClass="fa fa-list-alt  btn btn-xs btn-success"></asp:LinkButton>
                                --%>   
                                             <asp:LinkButton ID="LinkButton1" CommandName="CancelOrder"  CommandArgument='<%#Eval("intOrderId")+","+ Eval("intCustId")%>' runat="server" ToolTip="Reject Order" CssClass="fa fa-times btn btn-xs btn-danger"></asp:LinkButton>
                                         </td>
                                    </tr>
                                </AlternatingItemTemplate>
                                 <ItemTemplate>
                                    <tr style="">
                                        <td>
                                            <asp:Label ID="intOrderIdLabel" runat="server" 
                                                Text='<%# Eval("intOrderId") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="comnameLabel" runat="server" Text='<%# Eval("comname") %>' />
                                        </td>
                                         <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("mobile") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="varStatusLabel" runat="server" Text='<%# Eval("varStatus") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="dtDateLabel" runat="server" Text='<%# Eval("dtDate") %>' />
                                        </td>
                                        
                                        <td>
                                            <asp:Label ID="varPriceTotalLabel" runat="server" 
                                                Text='<%# Eval("varPriceTotal") %>' />
                                        </td>
                                         <td>
                                             <asp:LinkButton ID="lnkViewFull" CommandName="View" CommandArgument='<%#Eval("intOrderId")+","+ Eval("intCustId")%>' runat="server" ToolTip="View Order" CssClass="fa fa-eye btn btn-xs btn-info"></asp:LinkButton>
                                         <%--    <asp:LinkButton ID="LinkButton2" CommandName="ViewBill" CommandArgument='<%#Eval("intOrderId")+","+ Eval("intCustId")%>'  runat="server" ToolTip="View Bill" CssClass="fa fa-list-alt btn btn-xs btn-success"></asp:LinkButton>
                                   --%>
                                             <asp:LinkButton ID="LinkButton1" CommandName="CancelOrder"  CommandArgument='<%#Eval("intOrderId")+","+ Eval("intCustId")%>' runat="server" ToolTip="Reject Order" CssClass="fa fa-times btn btn-xs btn-danger"></asp:LinkButton>
                                         </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <table id="Table1" runat="server" style="">
                                        <tr>
                                            <td>
                                                No data was returned.</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                 
                                
                                <LayoutTemplate>
                                    <table id="Table2" runat="server">
                                        <tr id="Tr1" runat="server">
                                            <td id="Td1" runat="server">
                                                <table ID="itemPlaceholderContainer" runat="server" border="0" class="table table-bordered table-responsive">
                                                    <tr id="Tr2" runat="server" style="">
                                                        <th id="Th1" runat="server">
                                                            OrderId</th>
                                                        <th id="Th2" runat="server">
                                                            Company Name</th>
                                                             <th id="Th9" runat="server">
                                                           Contact</th>
                                                        <th id="Th3" runat="server">
                                                            Status</th>
                                                        <th id="Th4" runat="server">
                                                            Date</th>
                                                       
                                                        <th id="Th7" runat="server">
                                                            Total Price</th> 
                                                        <th id="Th8"   runat="server">
                                                           Operation</th> 
                                                    </tr>
                                                    <tr ID="itemPlaceholder" runat="server">
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="Tr3" runat="server">
                                            <td id="Td2" runat="server" style="">
                                                <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
        
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="listorder" PageSize="10">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                            ShowNextPageButton="false" />
                        <asp:NumericPagerField ButtonType="Link" />
                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton = "false" />
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
                                SelectCommand="SELECT intOrderId,(SELECT varCompanyName from tblsucustomer WHERE intId= intCustId)  as comname,(SELECT varMobile from sanghaviunbreakables.tblsucustomer WHERE (intId = intCustId) ) as mobile, intCustId,varStatus, dtDate, varProductTotal, varTotalNag, varPriceTotal, intId FROM tblsuorder WHERE intCustId=@custid  order by CAST( STR_TO_DATE( tblsuorder.dtDate,  '%d-%m-%Y' ) AS DATE )"  
                               >
                                <SelectParameters>
                                <asp:SessionParameter DbType="Int64" Name="custid" SessionField="custid" />
                                </SelectParameters>
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
    <script src="../assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="../assets/js/bootstrap.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="../assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="../assets/js/custom.js"></script>

</body>
</html>
