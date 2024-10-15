<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="ViewOrderFull.aspx.cs" Inherits="Personnel_employee_View_Order_Full" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>  View Full Order </title>

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

           function checkDec(el) {
               var ex = /^\d*\.?\d{0,2}$/;
               if (ex.test(el.value) == false) {
                   el.value = el.value.substring(0, el.value.length - 1);
               }
           }

           function Confirm() {
               var confirm_value = document.createElement("INPUT");
               confirm_value.type = "hidden";
               confirm_value.name = "confirm_value";
               if (confirm("Do you want to Add order?")) {
                   confirm_value.value = "Yes";
               } else {
                   confirm_value.value = "No";
               }
               document.forms[0].appendChild(confirm_value);
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
                      <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Personnel/employee/subadmin/Notification.aspx" CssClass="btn btn-primary fa fa-2x" ToolTip="Notification" runat="server"> </asp:HyperLink>
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
                                <a href="ViewOrder.aspx" class="active-menu-top"><i class="fa fa-pencil-square-o"></i>View Orders</a>
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
                          Full Order  details for Order ID : 
                                    <asp:Label ID="lblOrderNo" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="panel-body"> 
                        <div class="row"> 
                               <div class="col-md-3  col-sm-3"> 
                                <div class="table-responsive"> 
                                                    <asp:ListView ID="listorder" runat="server"  
                                DataKeyNames="intOrderId" >
                                
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
                                        <%-- <tr>
                                         <td>Date:</td>
                                         <td>   <asp:Label ID="dtDateLabel" runat="server" Text='<%# Eval("dtDate") %>' /></td>
                                         </tr> --%>
                                         <tr>
                                         <td>Sack:</td>
                                         <td>  <asp:Label ID="varProductTotalLabel" runat="server" 
                                         Text='<%# Eval("varProductTotal") %>' /></td>
                                         </tr>
                                         <tr>
                                         <td>Nag:</td>
                                         <td> <asp:Label ID="varTotalNagLabel" runat="server" 
                                         Text='<%# Eval("varTotalNag") %>' /></td>
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
                             
                                  <div class=" form-group input-group">  <span class="form-group input-group-btn">
                                                <p class="btn btn-default" >Booking ID</p>
                                                  </span>
      <asp:TextBox ID="txtBookingId" required
           runat="server"  CssClass="form-control" placeholder="Booking ID"></asp:TextBox>
                                              
                                                </div> 
                                      <div class=" form-group input-group"> <span class="form-group input-group-btn">
                                                <p class="btn btn-default" >Booking Date</p>
                                                  </span>
      <asp:TextBox ID="txtDate" runat="server"  CssClass="form-control" placeholder="Date"></asp:TextBox>
                                      <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOb_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDate"  > 
                                </cc1:CalendarExtender>         
                                                </div> 
                                        <div class=" form-group input-group"> <span class="form-group input-group-btn">
                                                <p class="btn btn-default" >Total Price</p>
                                                  </span>
      <asp:TextBox ID="txtTotalPrice" runat="server"  CssClass="form-control" placeholder="Total Price"></asp:TextBox>
                                               
                                               
                                                </div> 
                                      <div class="form-group">
     <asp:TextBox ID="txtDiscount" CssClass="form-control" placeholder="Discount" runat="server"></asp:TextBox>
 </div> 
  <div class="form-group">
     <asp:TextBox ID="txtTransport" CssClass="form-control" placeholder="Transport Details" runat="server"></asp:TextBox>
 </div>
      <div class="form-group">
     <asp:TextBox ID="txtLRNo" CssClass="form-control" placeholder="LR Number" runat="server"></asp:TextBox>
 </div>
   
                                      <div class="form-group">
                                <asp:LinkButton ID="lnkApprove" runat="server" CssClass="btn btn-success" 
                                       onclick="lnkApprove_Click">Approve</asp:LinkButton>
                                <asp:LinkButton ID="lnkReject" runat="server" CssClass="btn btn-danger" 
                                       onclick="lnkReject_Click">Reject</asp:LinkButton> 
                                        <a href="ViewOrder.aspx" class="btn btn-primary">Back</a>
                            </div>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                        ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>"
                                        >
                                                                         <SelectParameters>
                                    <asp:SessionParameter Name="OrderId" SessionField="orderid" Type="Int64" />
                                     <asp:SessionParameter Name="CustId" SessionField="empcustid" Type="Int64" />
                                </SelectParameters>
                                    </asp:SqlDataSource> 
                                        </div> 
                                </div>
                                   <div class="col-md-6 col-sm-6">
                                   <div class="table-responsive"> 
                                       <asp:ListView ID="lstOrderDetails" runat="server" DataKeyNames="mid" 
                                     onrowcommand="lstOrderDetails_RowCommand"         DataSourceID="SqlDataSource2" 
                                     onitemcommand="lstOrderDetails_ItemCommand" 
                                         >
                                            
                                           <EmptyDataTemplate>
                                               <table runat="server" style="">
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
                                                       <asp:Label ID="varTotalLabel" runat="server" Text='<%# Eval("total") %>' />
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="varPriceLabel" runat="server" Text='<%# Eval("varPrice") %>' />
                                                   </td>
                                                    
                                                     <td> 
   <asp:LinkButton ID="Button2" runat="server" Text="" CommandName="Edita" 
   CommandArgument='<%#Eval("mid") %>' CssClass="btn btn-xs btn-info fa fa-pencil " />
   <br /><br /> <asp:LinkButton ID="LinkButton1" runat="server" Text="" CommandName="Deletea" 
   CommandArgument='<%#Eval("mid") %>' CssClass="btn btn-xs btn-danger fa fa-times " />
                                                       </td>
                                               </tr>
                                           </ItemTemplate>
                                           <LayoutTemplate>
                                               <table runat="server">
                                                   <tr runat="server">
                                                       <td runat="server">
                                                           <table ID="itemPlaceholderContainer" runat="server" border="0" class="table table-bordered table-responsive" >
                                                               <tr runat="server" style="">
                                                                   
                                                                   <th runat="server">
                                                                       Product Name</th>
                                                                   <th runat="server">
                                                                       Sack</th>
                                                                   <th runat="server">
                                                                       Nag</th>
                                                                        <th id="Th1" runat="server">
                                                                       Total</th>
                                                                   <th runat="server">
                                                                       Price</th>
                                                                      
                                                                       <th runat="server">
                                                                       </th> 
                                                               </tr>
                                                               <tr ID="itemPlaceholder" runat="server">
                                                               </tr>
                                                           </table>
                                                       </td>
                                                   </tr> 
                                               </table>
                                           </LayoutTemplate>
                                           
                                       </asp:ListView>
                                         
                                  <asp:SqlDataSource ID="SqlDataSource2" runat="server"  
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>"   
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                SelectCommand="SELECT tblsuorderdetails.intId as mid, tblsuorderdetails.intProductId, tblsuorderdetails.varProductName, tblsuorderdetails.varQuantity, tblsuorderdetails.varNag, tblsuproducts.intPacking * tblsuorderdetails.varQuantity + tblsuorderdetails.varNag AS total
, varPrice, varRemark FROM            tblsuorderdetails, tblsuproducts
WHERE        tblsuorderdetails.intProductId = tblsuproducts.intId  and (intOrderId = @orderid)"
                                
                               >
                                <SelectParameters>
                                    <asp:SessionParameter Name="OrderId" SessionField="orderid" Type="Int64" />
                                </SelectParameters>
                                
                            </asp:SqlDataSource> 
                           <%--  WHERE (intOrderId = @orderid)" --%>
                        </div>
                                    </div>
                            
                            <div class="col-md-3 col-sm-3">
                            <div role="form">
                             <div class="form-group">
                               
                                             <asp:DropDownList ID="lblProductName" runat="server" CssClass="form-control"   
                                          DataTextField="ProductName" 
                                                 DataValueField="ProductName" AppendDataBoundItems="true"
                                             onselectedindexchanged="ddlProName_SelectedIndexChanged" 
                                             AutoPostBack="True" >
                                              <asp:ListItem Text="-- Select Product --" />
                                </asp:DropDownList> 
                                 <asp:Label ID="lblId" Visible="false" runat="server" Text="id"></asp:Label>  </div>
                                     
                                    
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
                                                      <asp:TextBox ID="txtPrice" runat="server" placeholder="Price" class="form-control" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"  required  ></asp:TextBox>
                                        </div>
                                           
                                           <div class="form-group">
                                           <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                                                         CssClass="btn btn-info" onclick="btnUpdate_Click"  />
                                                     <asp:LinkButton ID="btnReset" runat="server" Text="Reset"
                                                      CssClass="btn btn-danger" 
                                                         onclick="btnReset_Click"/>
                                           </div>
                            </div>
                            </div>
                                  </div>
                                </div>
                               
                        
                        </div>
                        </div>
                            </div>
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