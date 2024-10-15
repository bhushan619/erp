<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DispatchExpenseSheet.aspx.cs" Inherits="Personnel_employee_subadmin_DispatchExpenseSheet" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 <head id="Head1" runat="server">
    
     <title>Sub Admin Home</title>

 <!-- BOOTSTRAP STYLES-->
    <link href="../../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />  
    <!-- FONTAWESOME STYLES-->
    <link href="../../assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="../../assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="../../assets/css/custom.css" rel="stylesheet" />
       <link href="../../assets/css/bootstrap-fileupload.min.css" rel="stylesheet" />
     <script>
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
     <asp:LinkButton ID="LinkButton1" runat="server"  class="btn btn-danger fa fa-exclamation-circle fa-2x" 
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
                        <a  href="CrediteNote.aspx"><i class="fa fa-bell "></i>Credit Note</a>
                    </li>
                         <li>
                        <a  href="DispatchExpenseSheet.aspx"  class="active-menu"><i class="fa fa-bell "></i>Dispatch Expense Sheet</a>
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
                    <div class="col-md-12 col-sm-12">
     <div class="panel panel-danger">
                        <div class="panel-heading">
                      Dispatch Expense Sheet
                        </div>
                        <div class="panel-body">     
<div class="col-md-4 col-sm-4">

                       
                     <div class="form-group">
                             <asp:TextBox ID="txtintId" Visible="false"  runat="server"   ></asp:TextBox>
                      
                         <asp:TextBox ID="txtNo" required="required"  placeholder="Enter No." runat="server" CssClass="form-control"  ></asp:TextBox>
                         </div>
                                   
                     <div class="form-group">
                           <asp:TextBox ID="txtDate" required="required" CssClass="form-control" runat="server"   placeholder="Select Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOb_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDate"  > 
                                </cc1:CalendarExtender>
                            </div>
                             
                              <div class="form-group">
                         <asp:TextBox ID="txtInvoiceNo" required="required" placeholder="Invoice No." runat="server" CssClass="form-control"  ></asp:TextBox>
                         </div>

                              <div class="form-group">
                         <asp:TextBox ID="txtLRNo" required="required" placeholder="L.R. No." runat="server" CssClass="form-control" ></asp:TextBox>
                         </div>
                              <div class="form-group">
                         <asp:TextBox ID="txtTransport" required="required" placeholder="Transport" runat="server" CssClass="form-control" ></asp:TextBox>
                         </div>

                              <div class="form-group">
                         <asp:TextBox ID="txtParty" required="required"  placeholder="Select Party" runat="server" CssClass="form-control"  ></asp:TextBox>
                                   <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionList" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtParty" UseContextKey="True">
                                                </cc1:AutoCompleteExtender> </div>
                                    <div class="form-group">
                         <asp:TextBox ID="txtSack" required="required"  placeholder="Sack"  runat="server" CssClass="form-control" ></asp:TextBox>
                         </div>
                                          
                                    <div class="form-group">
  <asp:TextBox ID="txtAuto" runat="server"   placeholder="Auto" class="form-control"   
                                                   ></asp:TextBox>
                                               
                         </div>
     <div class="form-group">
  <asp:TextBox ID="txtLorry" runat="server"   placeholder="Lorry" class="form-control"   
                                                   ></asp:TextBox>
                                               
                         </div>
     <div class="form-group">
  <asp:TextBox ID="txtGoodsReturn" runat="server" placeholder="Goods Return" class="form-control"   
                                                   ></asp:TextBox>
                                               
                         </div>
                                          
                                    <div class="form-group">
                         <asp:TextBox ID="txtHamali"  placeholder="Hamali"  onkeyup="checkDec(this);" runat="server" CssClass="form-control" ></asp:TextBox>
                         </div>
                                     <div class="form-group">
                         <asp:TextBox ID="txtTotal" required="required" placeholder="Total"  onkeyup="checkDec(this);" runat="server" CssClass="form-control" ></asp:TextBox>
                         </div>      
     <div class="form-group">
  <asp:TextBox ID="txtRemark" runat="server"  required="required" placeholder="Remark" class="form-control"   
                                                   ></asp:TextBox>
                                               
                         </div>   
                                    <div class="form-group">
                      <asp:LinkButton ID="lnkSubmit" runat="server" Text="Submit" CssClass="btn btn-success"  OnClientClick="return Confirm();"
                                                         onclick="lnkSubmit_Click" />&nbsp;
                                         <asp:LinkButton ID="btnEditUpdate" runat="server" Text="Update" OnClientClick="return Confirm();" CssClass="btn btn-success" Visible="false"
                                                         onclick="btnEditUpdate_Click" />&nbsp;
                        <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" class="btn btn-warning" OnClick="btnCancel_Click"></asp:LinkButton>
     
                         </div>
                                          
                                
                         </div>
                            <div class="col-md-8 col-sm-8">
 <div class="table-responsive">   <div style="overflow-y: hidden;">
     <asp:GridView ID="grdRaw" runat="server" OnRowCommand="grdReport_RowCommand"
         CssClass="table table-striped table-bordered " AllowPaging="True"
         OnPageIndexChanging="grdRaw_PageIndexChanging" AutoGenerateColumns="False" >
         <Columns>
            <%-- <asp:TemplateField>
                                     <HeaderTemplate></HeaderTemplate>
                                     <ItemTemplate>
                                         <asp:LinkButton ID="aa" runat="server" CssClass="fa fa-edit" CommandName="edits" CommandArgument='<%# Eval("intId") %>'></asp:LinkButton>
                                         <asp:LinkButton ID="LinkButton1" runat="server" CssClass="fa fa-times" CommandName="del"  CommandArgument='<%# Eval("intId") %>' OnClientClick="return Confirm();"></asp:LinkButton>
                                     </ItemTemplate>
                                 </asp:TemplateField>--%>
             <asp:BoundField DataField="No" HeaderText="No" SortExpression="No"></asp:BoundField>
             <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date"></asp:BoundField>
             <asp:BoundField DataField="Invoice No" HeaderText="Invoice No" SortExpression="Invoice No"></asp:BoundField>
             <asp:BoundField DataField="LRNo" HeaderText="LRNo" SortExpression="LRNo"></asp:BoundField>
             <asp:BoundField DataField="Transport" HeaderText="Transport" SortExpression="Transport"></asp:BoundField>
             <asp:BoundField DataField="Party" HeaderText="Party" SortExpression="Party"></asp:BoundField>
             <asp:BoundField DataField="Sack" HeaderText="Sack" SortExpression="Sack"></asp:BoundField>
             <asp:BoundField DataField="Hamali" HeaderText="Hamali" SortExpression="Hamali"></asp:BoundField>
             <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total"></asp:BoundField>
         </Columns>
     </asp:GridView>
     <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:sanghaviConnectionString %>' ProviderName='<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>' SelectCommand="SELECT  varNo as No, varDate as Date, varInvoiceNo AS 'Invoice No' , varLRNo as LRNo, varTransporter as Transport, varParty as Party, varSack as Sack, varHamali as Hamali, varTotal as Total FROM tblsudispatchexpensesheet"></asp:SqlDataSource>
 </div>
 </div>
                    </div>
                         </div>
    </div>   
                   
        </div>
             <!--/.ROW-->
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
