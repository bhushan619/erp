<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="CreateBill.aspx.cs" Inherits="Personnel_employee_CreateBill" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title> Create Bill </title>

   
     
    <link href="../../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />  
    <!-- FONTAWESOME STYLES-->
    <link href="../../assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="../../assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="../../assets/css/custom.css" rel="stylesheet" />
     <link href="../../assets/css/pricing.css" rel="stylesheet" />
       
       
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
                           Create Invoice No: <asp:Label ID="lblInvoice" runat="server" Text=""></asp:Label> &nbsp; for Order Number : 
                            <asp:Label ID="lblOrderNo" runat="server" Text=""></asp:Label>
                        </div>
                        
                                 <div class="panel-body"> 
                       <div class="col-md-6 col-sm-6">
               <div class="panel panel-warning">
                        <div class="panel-heading">
                       Customer Details :
                            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                        </div>
                    <div class="panel-body">  
                        <div class="table-responsive text-center">

                            <asp:DetailsView ID="DetailsView1" runat="server" 
                                CssClass="table table-bordered table-responsive text-left" 
                                DataSourceID="SqlDataSource2" AutoGenerateRows="False" 
                                DataKeyNames="intOrderId,intId">
                                <Fields>
                                    <asp:BoundField DataField="intOrderId" HeaderText="Order ID" ReadOnly="True" 
                                        SortExpression="intOrderId" />
                                    <asp:BoundField DataField="comname" HeaderText="Customer Name" ReadOnly="True" 
                                        SortExpression="comname" />
                                    <asp:BoundField DataField="mobile" HeaderText="Contact" 
                                        SortExpression="mobile" />      
                                    <asp:BoundField DataField="varStatus" HeaderText="Status" 
                                        SortExpression="varStatus" />
                                    <asp:BoundField DataField="dtDate" HeaderText="Date" 
                                        SortExpression="dtDate" /> 
                                    <asp:BoundField DataField="varProductTotal" HeaderText="Total SAck" 
                                        SortExpression="varProductTotal" />
                                    <asp:BoundField DataField="varTotalNag" HeaderText="Total Nag" 
                                        SortExpression="varTotalNag" />
                                    <asp:BoundField DataField="varPriceTotal" HeaderText="Total Order" 
                                        SortExpression="varPriceTotal" />
                                </Fields>
                            </asp:DetailsView>
                             
                       
                             
                             
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server"  
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>"  
                                
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                SelectCommand="SELECT intOrderId,(SELECT varCompanyName from tblsucustomer WHERE intId= intCustId)  as comname,(SELECT varMobile from sanghaviunbreakables.tblsucustomer WHERE (intId = intCustId) ) as mobile, intCustId,varStatus, dtDate, varProductTotal, varTotalNag, varPriceTotal, intId FROM tblsuorder where tblsuorder.intOrderId=@order"  
                               >
                                <SelectParameters>
                                <asp:SessionParameter  Name="order" SessionField="orderid" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            
                        </div>
                        </div>
                        </div>
                        </div>
                        <div class="col-md-6 col-sm-6">
               <div class="panel panel-warning">
                        <div class="panel-heading">
                       Order Details :
                            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                        </div>
                    <div class="panel-body">  
                       <div class="table-responsive center-block">

                                <asp:ListView ID="lstOrderDetails" runat="server" DataKeyNames="intId" 
                           DataSourceID="SqlDataSource1"  
                                         >
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
                                                       <asp:Label ID="Label2" runat="server" Text='<%# Eval("total") %>' />
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="varPriceLabel" runat="server" Text='<%# Eval("varPrice") %>' />
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
                                                       <asp:Label ID="Label2" runat="server" Text='<%# Eval("total") %>' />
                                                   </td>
                                                   <td>
                                                       <asp:Label ID="varPriceLabel" runat="server" Text='<%# Eval("varPrice") %>' />
                                                   </td> 
                                               </tr>
                                           </ItemTemplate>
                                           <LayoutTemplate>
                                               <table id="Table2" runat="server">
                                                   <tr id="Tr1" runat="server">
                                                       <td id="Td1" runat="server">
                                                           <table ID="itemPlaceholderContainer" runat="server" border="0" class="table table-bordered table-responsive" >
                                                               <tr id="Tr2" runat="server" style="">
                                                                   
                                                                   <th id="Th1" runat="server">
                                                                       Product Name</th>
                                                                   <th id="Th2" runat="server">
                                                                       Sack</th>
                                                                   <th id="Th3" runat="server">
                                                                       Nug</th>
                                                                        <th id="Th4" runat="server">
                                                                       Total Nug</th>
                                                                   <th id="Th5" runat="server">
                                                                       Price</th>
                                                                    
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
                                         
                                  <asp:SqlDataSource ID="SqlDataSource1" runat="server"  
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>"   
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                SelectCommand="SELECT tblsuorderdetails.intId, tblsuorderdetails.intProductId, tblsuorderdetails.varProductName, tblsuorderdetails.varQuantity, tblsuorderdetails.varNag, tblsuproducts.intPacking * tblsuorderdetails.varQuantity + tblsuorderdetails.varNag AS total
, varPrice, varRemark FROM    tblsuorderdetails, tblsuproducts
WHERE        tblsuorderdetails.intProductId = tblsuproducts.intId  and (intOrderId = @orderid)"
                                
                               >
                                <SelectParameters>
                                    <asp:SessionParameter Name="OrderId" SessionField="orderid" Type="Int64" />
                                </SelectParameters>
                                
                            </asp:SqlDataSource> 
                        </div>
                       </div> 
                                  </div>
                        </div>
                   </div>
                       <div class="panel-body"> 
                               <div class="col-md-4 col-sm-4">
               <div class="panel panel-info">
                        <div class="panel-heading">
                           Create Consignment:
                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                        </div>
                        
                                 <div class="panel-body"> 
                       <div role="form">
                                     <div class="form-group">
                               
                                <asp:DropDownList ID="ddlProName" runat="server" CssClass="form-control"   
                                             DataSourceID="SqlDataSource3" DataTextField="varProductName" 
                                                 DataValueField="varProductName" AppendDataBoundItems="true"
                                             onselectedindexchanged="ddlProName_SelectedIndexChanged" 
                                             AutoPostBack="True" >
                                              <asp:ListItem Text="-- Select Product --" />
                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                              SelectCommand="SELECT varProductName FROM sanghaviunbreakables.tblsuorderdetails WHERE intOrderId =@OrderId"
                              >
                                <SelectParameters>
                                    <asp:SessionParameter Name="OrderId" SessionField="orderid" Type="Int64" />
                                </SelectParameters>
                              </asp:SqlDataSource>
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
                                             <div class=" form-group input-group">
      <asp:TextBox ID="txtDiscount" runat="server" placeholder="Discount" class="form-control" onkeyup="checkDec(this);"  
                                                 required AutoPostBack="True" ontextchanged="txtDiscount_TextChanged"  >0</asp:TextBox>
     
                                                <span class="form-group input-group-btn">
                                                <p class="btn btn-default" >%</p>
                                                  </span>
                                                </div>
                                                <div class="form-group"> 
                                                      <asp:TextBox ID="txtPrice" runat="server" placeholder="Price" class="form-control" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"  required  ></asp:TextBox>
                                        </div> 
                                           
                                       
                                                 <div class="form-group">
                                                     <asp:LinkButton ID="btnAddToOrder" runat="server" Text="Add to Consignment" 
                                                         CssClass="btn btn-info" onclick="btnAddToOrder_Click"/>
                                                     <asp:LinkButton ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-danger" 
                                                         onclick="btnReset_Click"/>
                                                 </div>
                                  </div>
                                               
                       </div> 
                       </div>
                        </div>

                         
                        <div class="col-md-8 col-sm-8">
               <div class="panel panel-danger">
                        <div class="panel-heading">
                       Consignment Details For Consignment Id :<asp:Label ID="lblconsi" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="panel-body">
                  <div role="form">
                   <div class="table-responsive">
                              
                            <asp:GridView ID="grdOrderDetails" runat="server"   AllowPaging="true" 
                                CssClass="table table-striped table-bordered "   PageSize="10"
                                onrowcommand="grdOrderDetails_RowCommand" onpageindexchanging="grdOrderDetails_PageIndexChanging"  
                                >  <Columns>
   <asp:TemplateField>
   <ItemTemplate>
   <asp:LinkButton ID="Button2" runat="server" Text="" CommandName="remove" 
   CommandArgument='<%#Container.DataItemIndex+","+ Eval("Sack")+","+Eval("Nag")+","+Eval("Price") %>' CssClass="btn btn-xs btn-danger fa fa-times" />
   </ItemTemplate>
   </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>No Products added to order </EmptyDataTemplate>
                            </asp:GridView>
                         </div></div>
 <div class="panel-body">
 <div class="form-group">
  <asp:TextBox ID="txtRoundup" runat="server" placeholder="Round Up" 
         class="form-control" onkeyup="checkDec(this);"  
                                                 required AutoPostBack="True" 
         ontextchanged="txtRoundup_TextChanged"  ></asp:TextBox>
 </div>
 <div class="form-group">         Total Sack :<asp:Label ID="lblProductTotalSack" runat="server" Text="Label"></asp:Label>
                         Total Nag : <asp:Label ID="lblProductTotalNag" runat="server" Text="Label"></asp:Label>
                         Total Price : <asp:Label ID="lblProductTotalPrice" runat="server" Text="Label"></asp:Label>
                          Total VAT : <asp:Label ID="lblVat" runat="server" Text="Label"></asp:Label>
                          </div>
  <div class="form-group"> 
                    Mode of Payment : <asp:Label ID="txtModePayment" runat="server"  placeholder="Mode of Payment"></asp:Label>
                        </div>
                        <div class="form-group"> 
                         Destination : <asp:Label ID="txtDestination" runat="server"   placeholder="Destination"></asp:Label>
                        </div>
  <div class="form-group"> 
                            <asp:TextBox ID="txtDispatch" runat="server" CssClass="form-control" placeholder="Dispatch Through"></asp:TextBox>
                        </div>
                          
 <div class="form-group"> 
                            <asp:TextBox ID="txtTransport" runat="server" CssClass="form-control" placeholder="Delivery By"></asp:TextBox>
                        </div>
                  <div class="form-group">    
                          <asp:LinkButton ID="btnAdd" runat="server" Text="Create Bill" CssClass="btn btn-success"   OnClientClick="return Confirm();"
                                                         onclick="btnAdd_Click" />&nbsp;
                        <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" class="btn btn-warning" ></asp:LinkButton>
                       </div>   
                        
                         </div>             </div>
                       
                        </div>
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
