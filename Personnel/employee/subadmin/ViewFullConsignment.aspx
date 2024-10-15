<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewFullConsignment.aspx.cs" Inherits="Personnel_employee_subadmin_ViewFullConsignment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
 <head id="Head1" runat="server">
    
  <title>View Consignment</title>

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
                     <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Personnel/employee/subadmin/Notification.aspx" CssClass="btn btn-primary fa fa-2x" ToolTip="Notification" runat="server"> </asp:HyperLink>
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
                        <a  href="EditProfile.aspx"><i class="fa fa-user "></i>Edit Profile</a>
                    </li>
                     <li>
                        <a href="#"><i class="fa fa-plus-circle "></i> Stock<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                                <a href="RecieveStockJalgaon.aspx"><i class="fa fa-share"></i>Recieve Verkhedi Stock</a>
                            </li>
                            <li>
                                <a href="ViewStock.aspx"><i class="fa fa-pencil-square-o"></i>View stock</a>
                            </li>   <li>
                                <a href="Rejection.aspx" ><i class="fa fa-pencil-square-o"></i>Rejection</a>
                            </li>
                            </ul>
                    </li>     
                     <li>
                        <a href="#"><i class="fa fa-plus-circle "></i> Order<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                                <a href="CreateOrder.aspx"><i class="fa fa-share"></i>Create Order</a>
                            </li>
                            <li>
                                <a href="ViewOrder.aspx"><i class="fa fa-pencil-square-o"></i>View Pending Orders</a>
                            </li>
                            <li>
                                <a href="ViewApprovedOrders.aspx"><i class="fa fa-pencil-square-o"></i>View Approved Orders</a>
                            </li>
                            <li>
                                <a href="OrderVarkhedi.aspx"><i class="fa fa-share"></i>Create Varkhedi Order</a>
                            </li>
                            <li>
                                <a href="ViewOrderVarkhedi.aspx"><i class="fa fa-pencil-square-o"></i>View Varkhedi Orders</a>
                            </li>
                          <%--  <li>
                                <a href="ViewBill.aspx"><i class="fa fa-share"></i>View Bills</a>
                            </li>--%>
                          
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
                           <a  href="RecievablesStore.aspx"><i class="  fa fa-upload "></i>Upload Recievables File</a>
                    </li>
                                    <li>
                      <a href="#"  class="active-menu"><i class="fa fa-envelope "></i>Consignment<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level collapse in ">
                         <li>
                                <a href="ViewConsignments.aspx"><i class="fa fa-pencil "></i>View/Update Consignments</a>
                            </li>
                          <li>
                                <a href="ViewConsignmentStatus.aspx" class="active-menu-top"><i class="fa fa-comment"></i>Track Consignments</a>
                            </li>
                            
                        </ul>
                    </li> 
                     <li>
                           <a  href="AllocateDistrict.aspx" ><i class="fa fa-map-marker "></i>Allocate District</a>
                    </li>
                       <li>
                        <a  href="CrediteNote.aspx"><i class="fa fa-bell "></i>Credit Note</a>
                    </li>
                         <li>
                        <a  href="DispatchExpenseSheet.aspx"><i class="fa fa-bell "></i>Dispatch Expense Sheet</a>
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
                          Full Consignment details for Consignment Number : 
                                    <asp:Label ID="lblConsNo" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="panel-body"> 
                        <div class="row"> 
                               <div class="col-md-4  col-sm-4"> 
                                <div class="table table-responsive"> 
                                   <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                                        DataKeyNames="ConsNo,OrderNo" DataSourceID="SqlDataSource1"  
                                        CssClass="table table-bordered table responsive" >
                                        <Fields>
                                            <asp:BoundField DataField="ConsNo" HeaderText="ConsNo" 
                                                ReadOnly="True" SortExpression="ConsNo" />
                                            <asp:BoundField DataField="Customer" HeaderText="Customer" 
                                                SortExpression="Customer" /> 
                                            <asp:BoundField DataField="OrderNo" HeaderText="OrderNo" 
                                                SortExpression="OrderNo" ReadOnly="True" />
                                            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                                             <asp:BoundField DataField="Transport" HeaderText="Transport" 
                                                SortExpression="Transport" />
                                            <asp:BoundField DataField="Status" HeaderText="Status" 
                                                SortExpression="Status" />
                                        </Fields>
                                    </asp:DetailsView>                          
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                        ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>"
                                       SelectCommand="SELECT        sanghaviunbreakables.tblsuconsignment.intConsigmentNo AS `ConsNo`, sanghaviunbreakables.tblsucustomer.varCompanyName AS Customer,
                         sanghaviunbreakables.tblsuconsignment.intOrderId AS OrderNo, sanghaviunbreakables.tblsuconsignment.dtDate AS `Date`, sanghaviunbreakables.tblsuconsignment.varStatus AS Status, sanghaviunbreakables.tblsuconsignment.varTransportName as Transport
FROM            sanghaviunbreakables.tblsucustomer, sanghaviunbreakables.tblsuorder, sanghaviunbreakables.tblsuconsignment
WHERE        sanghaviunbreakables.tblsucustomer.intId = sanghaviunbreakables.tblsuorder.intCustId AND sanghaviunbreakables.tblsuorder.intOrderId = sanghaviunbreakables.tblsuconsignment.intOrderId AND (sanghaviunbreakables.tblsuconsignment.intConsigmentNo = @ConsNos) ORDER BY sanghaviunbreakables.tblsuconsignment.varStatus "
                                        
                                       >
                                                                         <SelectParameters>
                                    <asp:SessionParameter Name="ConsNos" SessionField="consno" Type="Int64" />
                                      
                                </SelectParameters>
                                    </asp:SqlDataSource> 
                          
                                        </div>  
                                </div>
                                   <div class="col-md-8 col-sm-8">
                                   <div class="table table-responsive">

                            <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource2">
                                <AlternatingItemTemplate>
                                    <tr style="">
                                         
                                        <td>
                                            <asp:Label ID="SrnoLabel" runat="server" 
                                                Text='<%# Eval("Srno") %>' />
                                        </td>
                                         
                                        <td>
                                            <asp:Label ID="Product_NameLabel" runat="server" 
                                                Text='<%# Eval("[Product Name]") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="SackLabel" runat="server" Text='<%# Eval("Sack") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="NugLabel" runat="server" Text='<%# Eval("Nug") %>' />
                                        </td>
                                          <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("total") %>' />
                                        </td>
                                     <%--   <td>
                                            <asp:Label ID="RateLabel" runat="server" Text='<%# Eval("Rate") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="PERLabel" runat="server" Text='<%# Eval("PER") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="VATLabel" runat="server" Text='<%# Eval("VAT") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="DiscLabel" runat="server" Text='<%# Eval("Disc") %>' />
                                        </td>--%>
                                        <td>
                                            <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
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
                                            <asp:Label ID="SrnoLabel" runat="server" 
                                                Text='<%# Eval("Srno") %>' />
                                        </td>
                                         
                                        <td>
                                            <asp:Label ID="Product_NameLabel" runat="server" 
                                                Text='<%# Eval("[Product Name]") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="SackLabel" runat="server" Text='<%# Eval("Sack") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="NugLabel" runat="server" Text='<%# Eval("Nug") %>' />
                                        </td>
                                         <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("total") %>' />
                                        </td>
                                      <%--   <td>
                                             <asp:Label ID="RateLabel" runat="server" Text='<%# Eval("Rate") %>' />
                                         </td>
                                         <td>
                                             <asp:Label ID="PERLabel" runat="server" Text='<%# Eval("PER") %>' />
                                         </td>
                                         <td>
                                             <asp:Label ID="VATLabel" runat="server" Text='<%# Eval("VAT") %>' />
                                         </td>
                                         <td>
                                             <asp:Label ID="DiscLabel" runat="server" Text='<%# Eval("Disc") %>' />
                                         </td>--%>
                                         <td>
                                             <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                                         </td>
                                    </tr>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <table id="Table2" runat="server">
                                        <tr id="Tr1" runat="server">
                                            <td id="Td1" runat="server">
                                                <table ID="itemPlaceholderContainer" runat="server" border="0" class="table table-bordered table responsive">
                                                    <tr id="Tr2" runat="server" style=""> 
                                                        <th id="Th1" runat="server">
                                                            Sr No</th> 
                                                        <th id="Th2" runat="server">
                                                            Product Name</th>
                                                        <th id="Th3" runat="server">
                                                            Sack</th>
                                                        <th id="Th4" runat="server">
                                                             Nug</th>
                                                             <th id="Th10" runat="server">
                                                            Total Nug</th>
                                                      <%--  <th id="Th5" runat="server">
                                                            Rate</th>
                                                        <th id="Th6" runat="server">
                                                            PER</th>
                                                        <th id="Th7" runat="server">
                                                            VAT</th>
                                                        <th id="Th8" runat="server">
                                                            Disc</th>--%>
                                                        <th id="Th9" runat="server">
                                                            Price</th>
                                                    </tr>
                                                    <tr ID="itemPlaceholder" runat="server">
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="Tr3" runat="server">
                                            <td id="Td2" runat="server" style="">
                                            </td>
                                        </tr>
                                    </table>
                                </LayoutTemplate>
                                 
                                 
                                 
                            </asp:ListView>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server"  
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>"   
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                SelectCommand="SELECT        sanghaviunbreakables.tblsuconsignmentdetails.intSrNo AS Srno, sanghaviunbreakables.tblsuconsignmentdetails.intConsigmentNo, sanghaviunbreakables.tblsuconsignmentdetails.varProductName AS `Product Name`, 
                         sanghaviunbreakables.tblsuconsignmentdetails.varSack AS Sack, sanghaviunbreakables.tblsuconsignmentdetails.varNug AS Nug, 
                         sanghaviunbreakables.tblsuproducts.intPacking * sanghaviunbreakables.tblsuconsignmentdetails.varSack + sanghaviunbreakables.tblsuconsignmentdetails.varNug AS total, sanghaviunbreakables.tblsuconsignmentdetails.varRate AS Rate, 
                         sanghaviunbreakables.tblsuconsignmentdetails.varPer AS PER, sanghaviunbreakables.tblsuconsignmentdetails.varVat AS VAT, sanghaviunbreakables.tblsuconsignmentdetails.varDisc AS Disc, 
                         sanghaviunbreakables.tblsuconsignmentdetails.varPrice AS Price
FROM            sanghaviunbreakables.tblsuconsignmentdetails, sanghaviunbreakables.tblsuproducts
WHERE        sanghaviunbreakables.tblsuconsignmentdetails.intProductId = sanghaviunbreakables.tblsuproducts.intId AND (sanghaviunbreakables.tblsuconsignmentdetails.intConsigmentNo =@ConsNos)"
                                
                               >
                                <SelectParameters>
                                    <asp:SessionParameter Name="ConsNos" SessionField="consno" Type="Int64" />
                                </SelectParameters>
                                
                            </asp:SqlDataSource>
                            <div class="form-group">
                               
                                <asp:LinkButton ID="lnkBack" runat="server" CssClass="btn btn-primary" 
                                        onclick="lnkBack_Click">Back</asp:LinkButton>
                            </div>
                        </div>
                                    </div>
                                  </div>
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
