<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CrediteNote.aspx.cs"  Inherits="Personnel_employee_subadmin_CrediteNote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
     <title>  Credit Note  </title>

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
               if (confirm("Do you want to add/update/delete credit note?")) {
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
                        <a href="#"><i class="fa fa-plus-circle "></i> Order<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level">
                          <li>
                                <a href="CreateOrder.aspx" ><i class="fa fa-share"></i>Create Order</a>
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
                        <a  href="CrediteNote.aspx"  class="active-menu"> <i class="fa fa-bell "></i>Credit Note</a>
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
               
               <div class="panel panel-info">
                        <div class="panel-heading">
                          Credit Note
                        </div>
                   <div class="panel-body"> 
                                <div class="row">   
                                
                                                         <div class="panel-body"> 
                                                                                
                                                         <div class="col-md-2 col-sm-2">
                     <div class="form-group">
                         <asp:TextBox ID="txtCrediteNoteNo"  placeholder="Credite Note No." runat="server" CssClass="form-control" ></asp:TextBox>
                         </div>
                                    </div>   
                                                                <div class="col-md-2 col-sm-2">
                     <div class="form-group">
                           <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" required placeholder="Select Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOb_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDate"  > 
                                </cc1:CalendarExtender>
                           </div>
                   </div>
                                                                  <div class="col-md-4 col-sm-4">        
                                                                        <asp:TextBox ID="txtCustomerName" runat="server" 
                                            AutoPostBack="true"       placeholder="Company/Customer Name" class="form-control"  ontextchanged="txtCustomerName_TextChanged"
                                                   ></asp:TextBox>  <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionList" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtCustomerName" UseContextKey="True">
                                                </cc1:AutoCompleteExtender> 
                                                                  </div>
                              <div class="col-md-4 col-sm-4">    
                                        <asp:Label ID="labeldd" runat="server" Text="Contact person :"  ></asp:Label>
                                  
                                                <asp:Label ID="lblRepresentativeName" runat="server"   ></asp:Label>     <br />
                                                     <asp:Label ID="labelasas" runat="server" Text="Mobile  Number :"  ></asp:Label>
                                                   <asp:Label ID="lblMob" runat="server"   > </asp:Label>     
                                    
                              </div>
                                    <br />
 </div></div>  
                      <div class="row">  
                               
                    
                                           
                                             </div>
                                         
                <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="col-md-6 col-sm-6">
               <div class="panel panel-primary">
                        <div class="panel-heading">
                          Select Products to return 
                        </div>

                        <div class="panel-body">
                           
                                     <div class="table-responsive">
                              
                             <div role="form">
                                     <div class="form-group">
                               
                                <asp:DropDownList ID="ddlProName" runat="server" CssClass="form-control"   
                                              DataTextField="ProductName" DataSourceID="SqlDataSource2"
                                                 DataValueField="ProductName" AppendDataBoundItems="true"
                                             onselectedindexchanged="ddlProName_SelectedIndexChanged" 
                                             AutoPostBack="True" >
                                              <asp:ListItem Text="-- Select Product --" />
                                </asp:DropDownList> <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                              ></asp:SqlDataSource>
                                        </div>
                                       
                                    
                  <div class=" form-group input-group">
    <asp:TextBox ID="txtTotalProducts" runat="server" placeholder="Total Nugs" 
                                                    class="form-control"  required="required" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
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
                                                      <asp:TextBox ID="txtPrice" runat="server" placeholder="Price" class="form-control" onkeyup="checkDec(this);"    required  ></asp:TextBox>
                                        </div>
                                           
                                                 <div class="form-group">
                                                 
                                                     <asp:TextBox ID="txtRemark" runat="server"  placeholder ="Remark" class="form-control"></asp:TextBox>
                                                 </div>     
                                                 <div class="form-group">
                                                     <asp:LinkButton ID="btnAddToOrder" runat="server" Text="Add to Return" 
                                                         CssClass="btn btn-info" onclick="btnAddToOrder_Click"/>
                                                     <asp:LinkButton ID="btnReset1" runat="server" Text="Reset" CssClass="btn btn-danger" 
                                                         onclick="btnReset1_Click"/>
                                                 </div>
                            
                                  </div>
                         </div>
                            </div>
                        </div>
                            </div>
<div class="col-md-6 col-sm-6">
               <div class="panel panel-danger">
                        <div class="panel-heading">
                     Return Order Details
                        </div>
                        <div class="panel-body"> 
                   <div class="table-responsive"> 
                                                          <asp:GridView ID="grdOrderDetails" runat="server"  
                                CssClass="table table-striped table-bordered " 
                                onrowcommand="grdOrderDetails_RowCommand" 
                                >   <EmptyDataTemplate>
                                    Please enter product details..
                                </EmptyDataTemplate>  <Columns>
   <asp:TemplateField>
   <ItemTemplate>
   <asp:LinkButton ID="Button2" runat="server" Text="" CommandName="remove" 
   CommandArgument='<%#Container.DataItemIndex+","+ Eval("Sack")+","+Eval("Nag")+","+Eval("Price") %>' CssClass="btn btn-xs btn-danger fa fa-times" />
   </ItemTemplate>
   </asp:TemplateField>
        </Columns>
                            </asp:GridView>
                         </div>     
                             <div class="form-group">
      <asp:TextBox ID="lblProductTotalPrice" runat="server" CssClass="form-control"  onkeyup="checkDec(this);"  Text="0" /> 
      </div>
                         Total Sack :<asp:Label ID="lblProductTotalSack" runat="server" Text="Label"></asp:Label>
                         Total Nag : <asp:Label ID="lblProductTotalNag" runat="server" Text="Label"></asp:Label>
          
 <div class="panel-body">
      <div class="form-group">
     <asp:TextBox ID="txtNodeType" runat="server"   placeholder="Note Type" class="form-control" 
                                                    ></asp:TextBox>
                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionListNode" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtNodeType" UseContextKey="True">
                                                </cc1:AutoCompleteExtender>
                                
 </div>
   <div class="form-group">
     <asp:TextBox ID="txtCreditNoteAmount" CssClass="form-control" Text="0" onkeyup="checkDec(this);" placeholder="Amount" runat="server"></asp:TextBox>
 </div> 
 <div class="form-group">
     <asp:TextBox ID="txtDiscount" CssClass="form-control"  Text="0"   placeholder="Discount" runat="server"></asp:TextBox>
 </div>
  <div class="form-group">
     <asp:TextBox ID="txtTransportName" CssClass="form-control"    placeholder="Transport Name" runat="server"></asp:TextBox>
 </div>
      <div class="form-group">
     <asp:TextBox ID="txtTransportAmount" CssClass="form-control" onkeyup="checkDec(this);" Text="0" placeholder="Transport Amount" runat="server"></asp:TextBox>
 </div>
         <div class="form-group">
     <asp:TextBox ID="txtWages" CssClass="form-control"  Text="0"  onkeyup="checkDec(this);" placeholder="Wages" runat="server"></asp:TextBox>
 </div>
         <div class="form-group"> 
     <asp:TextBox ID="txtLorry" CssClass="form-control" placeholder="Lorry" onkeyup="checkDec(this);"  Text="0" runat="server"></asp:TextBox>
 </div>
              <div class="form-group" >
                  <asp:DropDownList ID="ddlPlace" runat="server" CssClass="form-control">
                      <asp:ListItem>--Select Stock Added To--</asp:ListItem>
                      <asp:ListItem>Verkhedi</asp:ListItem>
                      <asp:ListItem>Jalgaon</asp:ListItem>
                  </asp:DropDownList>
 </div>

                    
                          <asp:LinkButton ID="btnAdd" runat="server" Text="Return" OnClientClick="return Confirm();" CssClass="btn btn-success" 
                                                         onclick="btnAdd_Click" />&nbsp;
        <asp:LinkButton ID="btnEditUpdate" runat="server" Text="Update" OnClientClick="return Confirm();" CssClass="btn btn-success" Visible="false"
                                                         onclick="btnEditUpdate_Click" />&nbsp;
                        <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" class="btn btn-warning" OnClick="btnCancel_Click"></asp:LinkButton>
      <div class=" " >
                                    <asp:Label ID="lblmsg" runat="server" Text=""  Font-Bold="True" BackColor="#33CC33"></asp:Label>
</div>
                            </div>             </div>
                       
                        </div>
                            </div>
        </div>
        </div> 
                       
                       </div>

        </div>
             <!--/.ROW--> 
                   
        
 <div class="panel panel-danger">
                        <div class="panel-heading">
                          Credit Note Search and Edit
                        </div>
                   <div class="panel-body">   
                        <div class="row">   
                            <div role="form">  
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
                                <div class="col-lg-6 col-sm-6"> 
                            <div class="form-group">
                                <asp:LinkButton ID="btnview" runat="server" Text="View"  OnClick="btnview_Click" CssClass="btn btn-primary"/>
                                
                               
                            </div></div>
                          </div> 
                          </div>
                          
                 
                         
                      
                          <div class="row">  
                             
                     <div class="table-responsive">
                         <div style="overflow-y: hidden;">
                         <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="false" OnRowCommand="grdReport_RowCommand" OnPageIndexChanging="grdReport_PageIndexChanging"
                             CssClass="table table-bordered" PageSize="15"  AllowPaging="True">
                             <Columns>
                               <%--  <asp:TemplateField>
                                     <HeaderTemplate></HeaderTemplate>
                                     <ItemTemplate>
                                         <asp:LinkButton ID="aa" runat="server" CssClass="fa fa-edit" CommandName="edits" CommandArgument='<%# Eval("CNote No") %>'></asp:LinkButton>
                                         <asp:LinkButton ID="LinkButton1" runat="server" CssClass="fa fa-times" CommandName="del" OnClientClick="return Confirm();"></asp:LinkButton>
                                     </ItemTemplate>
                                 </asp:TemplateField>--%>
                                 <asp:BoundField DataField="CNote No" HeaderText="CNote No" SortExpression="CNote No"></asp:BoundField>
                                 <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date"></asp:BoundField>
                                 <asp:BoundField DataField="Note Type" HeaderText="Note Type" SortExpression="Note Type"></asp:BoundField>
                                 <asp:BoundField DataField="Customer" HeaderText="Customer" SortExpression="Customer"></asp:BoundField>
                                 <asp:BoundField DataField="Added to" HeaderText="Added to" SortExpression="Added to"></asp:BoundField>
                                 <asp:BoundField DataField="Product" HeaderText="Product" SortExpression="Product"></asp:BoundField>
                                 <asp:BoundField DataField="Standard Weight" HeaderText="Standard Weight" SortExpression="Standard Weight"></asp:BoundField>
                                 <asp:BoundField DataField="Total Kg" HeaderText="Total Kg" SortExpression="Total Kg"></asp:BoundField>
                                 <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty"></asp:BoundField>
                                 <asp:BoundField DataField="Credit Note Amt" HeaderText="Credit Note Amt" SortExpression="Credit Note Amt"></asp:BoundField>
                                 <asp:BoundField DataField="Disc" HeaderText="Disc" SortExpression="Disc"></asp:BoundField>
                                 <asp:BoundField DataField="Transport" HeaderText="Transport" SortExpression="Transport"></asp:BoundField>
                                 <asp:BoundField DataField="Trans Amt" HeaderText="Trans Amt" SortExpression="Trans Amt"></asp:BoundField>
                                 <asp:BoundField DataField="Wages" HeaderText="Wages" SortExpression="Wages"></asp:BoundField>
                                 <asp:BoundField DataField="Lorry" HeaderText="Lorry" SortExpression="Lorry"></asp:BoundField>
                             </Columns>
                         </asp:GridView>
                        </div>
                     </div>  
                       </div>
                         
                              </div>
                            </div>    
                         
                           
                          </div> 
                       
     </div>
                 
            <!-- /. PAGE INNER  -->
       
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

