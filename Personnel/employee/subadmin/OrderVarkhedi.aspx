<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="OrderVarkhedi.aspx.cs" Inherits="Personnel_employee_subadmin_OrderVarkhedi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
 <head id="Head1" runat="server">
    
     <title> Order for Varkhedi</title>

   <!-- BOOTSTRAP STYLES-->
    <link href="../../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />  
    <!-- FONTAWESOME STYLES-->
    <link href="../../assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="../../assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="../../assets/css/custom.css" rel="stylesheet" />
       <link href="../../assets/css/bootstrap-fileupload.min.css" rel="stylesheet" />
   
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
 
       
       <script language="javascript" type="text/javascript">

           function openNewWin(url) {

               var x = window.open(url, 'mynewwin', 'width=600,height=400,left=100, resizable=yes,scrollbars=yes ,menubar=yes');

               x.focus();

           }



           function PrintElem(elem) {
               Popup($(elem).html());
           }
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
                     <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Personnel/employee/subadmin/Notification.aspx" CssClass="btn btn-primary fa fa-2x" ToolTip="Notification" runat="server"> </asp:HyperLink>
     <asp:LinkButton ID="lnkLogoutUp" runat="server"  class="btn btn-danger fa fa-exclamation-circle fa-2x" 
                   ToolTip="Logout" onclick="lnkLogoutUp_Click"   ></asp:LinkButton>      

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
                        <a href="#" class="active-menu"><i class="fa fa-plus-circle "></i> Order<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level collapse in">
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
                                <a href="OrderVarkhedi.aspx" class="active-menu-top"><i class="fa fa-share"></i>Create Varkhedi Order</a>
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
                      <a href="#" ><i class="fa fa-envelope "></i>Consignment<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level  ">
                         <li>
                                <a href="ViewConsignments.aspx"><i class="fa fa-pencil "></i>View/Update Consignments</a>
                            </li>
                          <li>
                                <a href="ViewConsignmentStatus.aspx"><i class="fa fa-comment"></i>Track Consignments</a>
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
            <div class=" col-md-12  col-sm-12 col-xs-12">
               <div class="panel panel-info"> 
                       <div class="panel-heading">
                         Varkhedi Order No. : 
                           <asp:Label ID="lblOrderNo" runat="server" Text="0"></asp:Label>
                        </div>
                        <div class="panel-body">    
                         <div class="row"> 
          <div class="col-md-4 col-sm-4">
           <div class="panel panel-primary">
                        <div class="panel-heading">
                    Create Order for varkhedi
                    </div>                    
               <div class="panel-body" > 
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
                                                 
                                                     <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" placeholder ="Remark" class="form-control"></asp:TextBox>
                                                 </div>     
                                                 <div class="form-group">
                                                     <asp:Button ID="btnAddToOrder" runat="server" Text="Add to Order"  OnClientClick="return Confirm();"
                                                         CssClass="btn btn-info" onclick="btnAddToOrder_Click"/>
                                                     <asp:LinkButton ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-danger" 
                                                         onclick="btnReset_Click"/>
                                                 </div>
                                  </div>
                                  </div>
                                  </div>
                                  </div> 
            <div class="col-md-8 col-sm-8">
               <div class="panel panel-info">
                        <div class="panel-heading">
                     Order for varkhedi
                    </div>                    
               <div class="panel-body" > 
                   <asp:GridView ID="grdOrderDetails" runat="server" 
                       CssClass="table table-bordered table-responsive" 
                        onrowcommand="grdOrderDetails_RowCommand"  >
                        <Columns>
   <asp:TemplateField>
   <ItemTemplate>
   <asp:LinkButton ID="Button2" runat="server" Text="" CommandName="remove" 
   CommandArgument='<%#Container.DataItemIndex+","+ Eval("Sack")+","+Eval("Nag") %>' CssClass="btn btn-xs btn-danger fa fa-times" />
   </ItemTemplate>
   </asp:TemplateField>
   
        </Columns><EmptyDataTemplate>ADD PRODUCTS TO ORDER</EmptyDataTemplate>
                   </asp:GridView>
                   <asp:LinkButton ID="btnAdd" runat="server" Text="Order and Print" 
                       CssClass="btn btn-primary" onclick="btnAdd_Click" />
                         <asp:LinkButton ID="LinkButton1" runat="server" Text="Cancel" 
                       CssClass="btn btn-danger" />
                   <%--   <asp:SqlDataSource ID="SqlDataSourceVarkhediOrder" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                       ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                       SelectCommand="SELECT tblsuvarkhediorder.dtDate AS `Date`, tblsuvarkhediorder.tmTime AS `Time`, tblsuvarkhediorder.varProductName AS ProductName, tblsuvarkhediorder.intSack AS Sack, tblsuvarkhediorder.intNug AS Nug, tblsuvarkhediorder.varRemark AS Remark, tblsuvarkhediorder.intId FROM tblsuvarkhediorder INNER JOIN tblsuproducts ON tblsuvarkhediorder.intProductId = tblsuproducts.intId">
                   </asp:SqlDataSource>--%>
                            
                      </div>
        </div>
        </div>
        </div>
                        </div>
                        </div>
                        
                            </div>
 
        </div>
             <!--/.ROW-->
             
               <div class="row">
                       
                                <div class="col-md-4 col-sm-4">
               <div class="panel panel-info">
                        <div class="panel-heading">
                           Raw Material Stock
                        </div>
                        <div class="panel-body">
                        <div class="table-responsive">
                               <asp:GridView ID="grdRaw" runat="server"  PageSize="10"  
                                 CssClass="table table-striped table-bordered "  AllowPaging="True" 
                                   onpageindexchanging="grdRaw_PageIndexChanging">
                                </asp:GridView>
                        </div>
                        </div>
                        </div>
                            </div>
<div class="col-md-4 col-sm-4">
 <div class="panel panel-danger">
                        <div class="panel-heading">
                        Stock at Jalgaon
                        </div>
                        <div class="panel-body"> 
                             <div class="table-responsive">
                                <asp:GridView ID="gridexp" runat="server"  
                                 CssClass="table table-striped table-bordered " PageSize="10" 
                                     AllowPaging="True" onpageindexchanging="gridexp_PageIndexChanging" 
                                     AutoGenerateColumns="False">
                               <Columns>  
                                        <asp:BoundField DataField="nvarProductName" HeaderText="Product Name" 
                                            SortExpression="nvarProductName" />
                                        <asp:BoundField DataField="intSack" HeaderText="Sack" 
                                            SortExpression="intSack" />
                                      
                                        <asp:BoundField DataField="intNug" HeaderText="Nug" 
                                            SortExpression="intNug" />
                                        <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />
                                      
                                    </Columns>
                                </asp:GridView>
                              </div>
                              </div>
                              
                        </div>
                            </div>
                            <div class="col-md-4 col-sm-4">
 <div class="panel panel-primary">
                        <div class="panel-heading">
                        Stock at Varkhedi
                        </div>
                        <div class="panel-body"> 
                             <div class="table-responsive">
                                <asp:GridView ID="gridvar" runat="server"  PageSize="10"  
                                 CssClass="table table-striped table-bordered "  AllowPaging="True" 
                                     onpageindexchanging="gridvar_PageIndexChanging" 
                                     AutoGenerateColumns="False">
                                <Columns>  
                                        <asp:BoundField DataField="nvarProductName" HeaderText="Product Name" 
                                            SortExpression="nvarProductName" />
                                        <asp:BoundField DataField="intSack" HeaderText="Sack" 
                                            SortExpression="intSack" />
                                      
                                        <asp:BoundField DataField="intNug" HeaderText="Nug" 
                                            SortExpression="intNug" />
                                        <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />
                                      
                                    </Columns> </asp:GridView>
                              </div>
                              </div>
                              
                        </div>
                            </div>
                       </div>
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
