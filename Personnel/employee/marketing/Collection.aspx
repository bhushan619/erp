<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Collection.aspx.cs" Inherits="Personnel_employee_marketing_Collection" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>Collection</title>

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
                       <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Personnel/employee/marketing/Notification.aspx" CssClass="btn btn-primary fa fa-2x" ToolTip="Notification" runat="server"> </asp:HyperLink>
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
                        <a href="ViewCustomer.aspx"><i class="fa fa-user "></i>View/Update Customer</a>
                    </li>
                      <li>
                                <a href="ViewProduct.aspx"><i class="fa fa-eye"></i>View Products</a>
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
                      <li >
                        <a  href="Collection.aspx" class="active-menu-top"><i class="fa fa-file-excel-o"></i>Collection</a>
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
                                     <div class="col-md-4 col-sm-4 ">
               <div class="panel panel-info">
                        <div class="panel-heading">
                           Add Collection From Customers
                        </div>
                        <div class="panel-body">
                        <div class="table-responsive">
                              <div class="panel-body">  
                                      <div class="form-group">    <asp:TextBox ID="txtintId" Visible="false"  runat="server"   ></asp:TextBox>
                           <asp:TextBox Visible="false" ID="txtDate" CssClass="form-control" runat="server" required placeholder="Select Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOb_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDate"  > 
                                </cc1:CalendarExtender>
                           </div>
                                  <div class="form-group">
                                        <asp:TextBox ID="txtCustomerName" runat="server" 
                                                    placeholder="Company/Customer Name" class="form-control" AutoPostBack="True" 
                                                    ontextchanged="txtCustomerName_TextChanged" ></asp:TextBox>
                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionList" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtCustomerName" UseContextKey="True">
                                                </cc1:AutoCompleteExtender>
                                  </div>
                                  <div class="form-group">
                                       <asp:Label ID="lblRepriName" runat="server" Text="Contact person :"  ></asp:Label>
                                  
                                                <asp:Label ID="lblRepresentativeName" runat="server"   ></asp:Label>     <br />  <asp:Label ID="lblMobNo" runat="server" Text="Mobile  Number :"  ></asp:Label>
                                                   <asp:Label ID="lblMob" runat="server"   >                                      </asp:Label>     
                                     
                                  </div>
 <div class="form-group">
                       <asp:DropDownList ID="ddlPayMode" CssClass="form-control" runat="server" > 
                        <asp:ListItem>--Select Payment Mode --</asp:ListItem>
                     <asp:ListItem Value="Cash">Cash</asp:ListItem>
                       <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                           <asp:ListItem Value="DD">DD</asp:ListItem>
                   </asp:DropDownList>
 </div>
  <div class="form-group">
     <asp:TextBox ID="txtCheckNo" CssClass="form-control" placeholder="Cheque Number" runat="server"></asp:TextBox>
 </div>
        <div class="form-group">
                           <asp:TextBox ID="txtCheckDate" CssClass="form-control" runat="server" required placeholder="Select Cheque Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="CalendarExtender1" runat="server" 
                                    Enabled="True" TargetControlID="txtCheckDate"  > 
                                </cc1:CalendarExtender>
                           </div>
         <div class="form-group">
     <asp:TextBox ID="txtAmount" CssClass="form-control" placeholder="Amount" runat="server"></asp:TextBox>
 </div>
                                     <div class="form-group">
     <asp:TextBox ID="txtOtherDetails" CssClass="form-control" placeholder="Other Payment Details" runat="server"></asp:TextBox>
 </div>
         <div class="form-group">
  <asp:LinkButton ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-success"   onclick="btnAdd_Click"  OnClientClick="return Confirm();"/>&nbsp;
             <asp:LinkButton ID="btnEditUpdate" runat="server" Text="Update" OnClientClick="return Confirm();" CssClass="btn btn-success" Visible="false"
                                                         onclick="btnEditUpdate_Click" />&nbsp;
             <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel"     class="btn btn-danger " onclick="btnCancel_Click" /> 
 </div>
</div>
                        </div>
                        </div>
                        </div>
                            </div>
<div class="col-md-8 col-sm-8">
                            <div class="panel panel-warning"> 
                        <div class="panel-heading">
                          Collection From Customers
                        </div>
                        <div class="panel-body">
                        <div class="table-responsive">
                            <div style="overflow-x:auto">
                                <asp:LinkButton ID="btnExportSale" runat="server" OnClick="btnExportSale_Click" CssClass=" btn btn-success" Text="Export In Excel"  CausesValidation="False" />   
                            <asp:GridView ID="grdRaw" runat="server" OnRowCommand="grdReport_RowCommand"
                                CssClass="table table-striped table-bordered " AllowPaging="True"
                                OnPageIndexChanging="grdRaw_PageIndexChanging" AutoGenerateColumns="False"  >
                                <Columns><%--<asp:TemplateField>
                                     <HeaderTemplate></HeaderTemplate>
                                     <ItemTemplate>
                                         <asp:LinkButton ID="aa" runat="server" CssClass="fa fa-edit" CommandName="edits" CommandArgument='<%# Eval("intId") %>'></asp:LinkButton>
                                         <asp:LinkButton ID="LinkButton1" runat="server" CssClass="fa fa-times" CommandName="del"  CommandArgument='<%# Eval("intId") %>' OnClientClick="return Confirm();"></asp:LinkButton>
                                     </ItemTemplate>
                                 </asp:TemplateField>--%>
                                    <asp:BoundField DataField="Party" HeaderText="Party" SortExpression="Party"></asp:BoundField>
                                    <asp:BoundField DataField="Emp Name" HeaderText="Emp Name" SortExpression="Emp Name"></asp:BoundField>
                                    <asp:BoundField DataField="Designation" HeaderText="Designation" SortExpression="Designation"></asp:BoundField>
                                   <%-- <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date"></asp:BoundField>--%>
                                    <asp:BoundField DataField="Pay Mode" HeaderText="Pay Mode" SortExpression="Pay Mode"></asp:BoundField>
                                    <asp:BoundField DataField="Check No" HeaderText="Check No" SortExpression="Check No"></asp:BoundField>
                                    <asp:BoundField DataField="Check Date" HeaderText="Check Date" SortExpression="Check Date"></asp:BoundField>
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"></asp:BoundField>
                                    <asp:BoundField DataField="Other Details" HeaderText="Other Details" SortExpression="Other Details"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
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

