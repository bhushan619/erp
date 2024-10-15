<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StockRecievedJalgaon.aspx.cs" Inherits="Personnel_admin_Reports_StockRecievedJalgaon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>Report</title>

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
                <a class="navbar-brand" href="../Default.aspx">Sanghavi Unbreakables</a>
            </div>

            <div class="header-right">
 <a href="../Default.aspx" class="btn btn-info" title="Profile"><i class="fa fa-user fa-2x"></i></a>
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
                                <a href="../AddProduct.aspx" ><i class="fa fa-plus-circle"></i>Add Product</a>
                            </li>
                            <li>
                                <a href="../UpdateProduct.aspx"><i class="fa fa-pencil-square-o"></i>Update Product</a>
                            </li>
                              <li>
                                <a href="../ViewStock.aspx"><i class="fa fa-cubes"></i>Stock</a>
                            </li>
                            </ul>
                    </li> 
                    <li>
                       <a href="#"><i class="fa fa-smile-o "></i>Employee<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                             <a href="../AddEmp.aspx"><i class="fa fa-user "></i>Add Employee</a>
                            </li>
                            <li>
                                 <a href="../ViewEmp.aspx"><i class="fa fa-eye "></i>View Employee</a>
                            </li>
                               <li>
                                <a href="../ViewEmpDsr.aspx"><i class="fa fa-pencil "></i>DSR</a>
                            </li>                         
                           
                        </ul>
                    </li> 
                    <li>
                       <a href="#"><i class="fa fa-users "></i>Customer<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                                <a href="../AddCustomer.aspx"><i class="fa fa-user "></i>Add Customer</a>
                            </li>
                            <li>
                                <a href="../ViewCustomer.aspx"><i class="fa fa-eye"></i>View Customer</a>
                            </li> 
                        </ul>
                    </li> 
                     <li>
                        <a href="#"><i class="fa fa-envelope "></i>Messages<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level">  <li>
                                <a href="../CreateMessage.aspx"><i class="fa fa-pencil "></i>New Message</a>
                            </li>
                          <li>
                                  <a href="../ViewMessages.aspx"><i class="fa fa-comments"></i>View Messages</a>
                            </li>
                          <li>
                                  <a href="../ViewSentMessages.aspx"><i class="fa fa-inbox"></i>Sent Messages</a>
                            </li>
                        </ul>
                    </li> 
                   <li>
                      <a href="../Report.aspx" class="active-menu"><i class="fa fa-folder "></i>Report</a>
                      
                    </li> 
                    <li>
                           <a  href="../ViewConsignmentStatus.aspx"><i class="fa fa-map-marker "></i>Track Consignment</a>
                    </li>
                      
                    <li>
                        <a  href="../Notification.aspx"><i class="fa fa-bell "></i>Notifications</a>
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
                  <div class="col-lg-12 col-sm-12">                     
         <div class="panel panel-info">
                        <div class="panel-heading">
             Product History & Current Stock
                        </div>
                        <div class="panel-body">
                        <div class="row">   
                            <div role="form"> 
                               <div class="col-lg-3 col-sm-3">
                            <div class="form-group"> 
                                <asp:DropDownList ID="ddlProName" runat="server" CssClass="form-control"   
                                             DataSourceID="SqlDataSource2" DataTextField="ProductName" 
                                                 DataValueField="ProductName" AppendDataBoundItems="true"
                                            
                                             AutoPostBack="True" >
                                              <asp:ListItem Text="-- Select Product --" />
                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                              ></asp:SqlDataSource>
                                        </div>   </div>
                                         <div class="col-lg-3 col-sm-3">
                           <div class="form-group">
                              
                               <asp:TextBox ID="txtFromDate" placeholder="From Date" runat="server" required CssClass="form-control"></asp:TextBox>
                                  <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtFromDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtFromDate" >
                                </cc1:CalendarExtender>
                             </div>   </div>
                                 <div class="col-lg-3 col-sm-3">
                               <div class="form-group">
                              
                            <asp:TextBox ID="txtToDate" placeholder="To Date"  runat="server" required CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtToDate_CalendarExtender1" runat="server" 
                                    Enabled="True" TargetControlID="txtToDate" >
                                </cc1:CalendarExtender>
                            </div>   </div>
                                <div class="col-lg-3 col-sm-3">
                                   
                            <div class="form-group">
                                <asp:Button ID="txtView" runat="server" Text="View" onclick="txtView_Click" CssClass="btn btn-primary"/>
                                <a class="btn btn-danger" href="RawMaterialUsage.aspx" >Reset</a>
                                <a class="btn btn-warning" href="../Report.aspx" >Back</a>
                            </div></div>
                          </div> 
                          </div>
                              <div class="col-lg-12"> 
                                   <div class="panel panel-primary">
                        <div class="panel-heading">
                        Jalgaon Stock
                        </div>
                        <div class="panel-body">
                          <div class="row">  
                               
                     
                             
                               <asp:GridView ID="grdStockManuf" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover"
                                    DataKeyNames="intId" DataSourceID="SqlDataSource1" AllowPaging="False">
                                    <Columns>  
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" 
                                            SortExpression="ProductName" />
                                        <asp:BoundField DataField="intSack" HeaderText="Sack" 
                                            SortExpression="intSack" /> 
                                        <asp:BoundField DataField="intNug" HeaderText="Nug" 
                                            SortExpression="intNug" />
                                        <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" /> 
                                    </Columns>
                                   <EmptyDataTemplate>Please select Product</EmptyDataTemplate>
                                </asp:GridView>
                                  <table class="table table-responsive table-bordered">
                                        <tr>
                                           <td>
                                               Recieved/Added/Adjusted  
                                               </td>
                                            <td>
                                                Sale
                                            </td>
                                            <td>
                                                Credit Note
                                            </td>
                                            </tr>
                                       <tr>
                                           <td>
                          Sack  : <asp:Label ID="lblTotalKgUsed" runat="server" Text="0" Font-Bold="True"></asp:Label><br />
                          Nug  : <asp:Label ID="lblTotalTonUsed" runat="server" Text="0" Font-Bold="True"></asp:Label><br />
                          Total Nug  : <asp:Label ID="lblTotalReceived" runat="server" Text="0" Font-Bold="True"></asp:Label>
                                           </td>
                                           <td>  
                            Sack  : <asp:Label ID="lblSack" runat="server" Text="0" Font-Bold="True"></asp:Label><br />
                            Nug  : <asp:Label ID="lblNug" runat="server" Text="0" Font-Bold="True"></asp:Label><br />
                            Total Nug  : <asp:Label ID="lblTotalSale" runat="server" Text="0" Font-Bold="True"></asp:Label>
                                           </td>
                                            <td>  
                            Sack  : <asp:Label ID="lblCreditNoteSack" runat="server" Text="0" Font-Bold="True"></asp:Label><br />
                            Nug  : <asp:Label ID="lblCreditNoteNug" runat="server" Text="0" Font-Bold="True"></asp:Label><br />
                            Total Nug  : <asp:Label ID="lblCreditNoteTotal" runat="server" Text="0" Font-Bold="True"></asp:Label>
                                           </td>
                                       </tr>
                                   </table>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                    ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                    >
                                </asp:SqlDataSource>
                              </div>
                            </div>
                                       </div>
                                  
                              </div>
                       <div class="col-lg-6 col-sm-6 "> 
                            <asp:LinkButton ID="btnRecievedExport" runat="server" CssClass=" btn btn-success" Text="Export In Excel" OnClick="btnRecievedExport_Click"  />
                      
                       <div class="panel panel-primary">
                        <div class="panel-heading">
                        Recieved/Added/Adjusted
                        </div>
                        <div class="panel-body">
                          <div class="row">   
                  
                               <div class="table table-responsive">
                                   <br />
                                  <asp:GridView ID="grdReport" runat="server" 
                                      CssClass="table table-bordered table-responsive" PageSize="15">
                                  </asp:GridView></div>
                            </div>    
                            </div>
                            </div>
                            </div>
                         <div class="col-lg-6 col-sm-6">
                              <asp:LinkButton ID="btnDispatchExport" runat="server" CssClass=" btn btn-success" Text="Export In Excel" OnClick="btnDispatchExport_Click" />
  
                           <div class="panel panel-warning">
                        <div class="panel-heading">
                        Product Sale
                        </div>
                        <div class="panel-body">
                          <div class="row"> 
                           
                             
                           <div class="table table-responsive"> 
                                <br />
                                  <asp:GridView ID="grdDispatch" runat="server" 
                                      CssClass="table table-bordered table-responsive" PageSize="15">
                                  </asp:GridView>
                                  </div>
                            </div>    
                            </div>
                            </div>
                            </div>
                          </div>

         </div>
                          </div>
                          
                      
                      
                      </div>
                      </div>
                    </div>
                    
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
