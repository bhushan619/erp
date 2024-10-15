<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="CreateDSR.aspx.cs" Inherits="Personnel_employee_marketing_CreateDSR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 <html xmlns="http://www.w3.org/1999/xhtml">
 <head id="Head1" runat="server">
    
     <title>Create DSR</title>

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
               confirm_value.value = "Yes";
               if (confirm("Are you sure.. You want to Add/Update/Delete ?")) {
                   confirm_value.value = "Yes";
               } else {
                   confirm_value.value = "No";
               }
               document.forms[0].appendChild(confirm_value);
           }
</script>
 
<link rel="stylesheet" type="text/css" href="dist/bootstrap-clockpicker.min.css">
 
<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
<!--[if lt IE 9]>
  <script src="assets/js/html5shiv.js"></script>
  <script src="assets/js/respond.min.js"></script>
<![endif]-->
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
                        <a href="#" class="active-menu"><i class="fa fa-plus-circle "></i> DSR<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level  collapse in">
                          <li>
                                <a href="CreateDSR.aspx" class="active-menu-top"><i class="fa fa-share"></i>Create DSR</a>
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
                      <li>
                        <a  href="Collection.aspx"><i class="fa fa-file-excel-o"></i>Collection</a>
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
                  <div class="panel panel-primary">
                        <div class="panel-heading">
                          Daily Sales Report 
                        </div>
               <div class="panel-body">   
                  <div class="col-md-6 col-sm-6">
                    <div class="form-group"> 
                               <asp:RadioButton ID="rdbNewCall" Text="New Call" GroupName="call" Checked="true"
                                     runat="server" />  
                               <asp:RadioButton ID="rdbFollowUp" runat="server" GroupName="call" Text="Follow Up Call"/>
                                  <asp:RadioButton ID="rdbVisit" runat="server" GroupName="call" Text="Visit"/>
                           </div> 
                 <div class="form-group"> 
                           <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" required placeholder="Select Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOb_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDate"  > 
                                </cc1:CalendarExtender> 
                  </div>
                 <div class="form-group">	 
		<div class="clearfix">
			<div class="input-group clockpicker pull-center" data-placement="left" data-align="top" data-autoclose="true">			
                <asp:TextBox ID="txtTime" runat="server" placeholder="Select Time" CssClass="form-control" required ></asp:TextBox> 
				            <span class="input-group-addon">
					            <span class="glyphicon glyphicon-time"></span>
				            </span>
			            </div>
		            </div> 
	            </div> 
                      <div class="form-group"> 
                           <asp:TextBox ID="txtLocation" CssClass="form-control" runat="server" required placeholder="Location"></asp:TextBox>
                           </div>
                           
                                <div class="form-group"> 
                           <asp:TextBox ID="txtNextCall" CssClass="form-control" runat="server" placeholder="Next Follow Up Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="CalendarExtender1" runat="server" 
                                    Enabled="True" TargetControlID="txtNextCall"  > 
                                </cc1:CalendarExtender> 
                  </div>
                            <div class="form-group"> 
                                <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server"  OnClientClick="return Confirm();"
                                    Text="Submit" onclick="btnSubmit_Click" />
                                 <asp:LinkButton ID="btnReset" CssClass="btn btn-warning" runat="server" 
                                    Text="Reset" onclick="btnReset_Click" />
                           </div>
                            </div> 
                            
                           
                         <div class="col-md-6 col-sm-6">
                           <div class="form-group"> 
                           <asp:TextBox ID="txtCustomerName" runat="server" 
                                                    placeholder="Company/Customer Name" class="form-control"    AutoPostBack="true"
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
                           <asp:TextBox ID="txtContactPerson"  CssClass="form-control" runat="server" required placeholder="Contact Person"></asp:TextBox>
                           </div>
             <div class="form-group"> 
                           <asp:TextBox ID="txtLandLine" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" CssClass="form-control" runat="server"  placeholder="Landline Number"></asp:TextBox>
                           </div>
                                                       <div class="form-group"> 
                           <asp:TextBox ID="txtMobile" CssClass="form-control" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" runat="server" required placeholder="Mobile Number"></asp:TextBox>
                           </div>
                           <div class="form-group"> 
                           <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server" required placeholder="Remark"></asp:TextBox>
                           </div>
                         </div> 
                         </div>
                         </div>
                        </div>
                        
                        
                            </div>

                            <div class="row">
                            <div class="col-md-12 col-sm-12">
               <div class="panel panel-info">
                        <div class="panel-heading">
                          View Sales Report 
                        </div>
                        <div class="panel-body"> 
                                              <div role="form"> 
                                       <div class="col-lg-4 col-sm-4">
                                <div class="form-group "> 
                                           <asp:TextBox ID="txtCmpName" runat="server" class="form-control" CausesValidation="false"
                                                placeholder="-- Select Customer --"  ></asp:TextBox>
                                           
                                           <cc1:AutoCompleteExtender ID="txtCmpName_AutoCompleteExtender" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionList" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtCmpName"  UseContextKey="True">
                                           </cc1:AutoCompleteExtender>
                                           
                                        </div>
                             </div>
                                         <div class="col-lg-2 col-sm-2">
                           <div class="form-group">
                              
                               <asp:TextBox ID="txtFromDate"  placeholder="From Date" runat="server" CssClass="form-control"></asp:TextBox>
                                  <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtFromDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtFromDate" >
                                </cc1:CalendarExtender>
                             </div>   </div>
                                 <div class="col-lg-2 col-sm-2">
                               <div class="form-group">
                              
                            <asp:TextBox ID="txtToDate" placeholder="To Date"  runat="server"  CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtToDate_CalendarExtender1" runat="server" 
                                    Enabled="True" TargetControlID="txtToDate" >
                                </cc1:CalendarExtender>
                            </div>   </div>
                                <div class="col-lg-4 col-sm-4">
                                   
                            <div class="form-group">
                                <asp:LinkButton ID="btnview" runat="server" Text="View"  OnClick="btnview_Click" CssClass="btn btn-primary"/>                              
                                <a class="btn btn-danger" href="CreateDSR.aspx" >Reset</a>
                                   <asp:LinkButton ID="btnExport" runat="server" Text="Export"  OnClick="btnExport_Click" CssClass="btn btn-warning"/>
                            </div></div>
                          </div> 
                        <div class="table table-responsive">
                         <asp:GridView ID="grdDSR" runat="server"    
                                CssClass="table table-striped table-bordered table-responsive" 
                                DataSourceID="SqlDataSourceDSR" AutoGenerateColumns="False" 
                                DataKeyNames="intId" >
                             <Columns>
                                <asp:BoundField DataField="varDate" HeaderText="Date" 
                                     SortExpression="varDate" />
                                 <asp:BoundField DataField="varLocation" HeaderText="Location" 
                                     SortExpression="varLocation" />
                                 <asp:BoundField DataField="varCallType" HeaderText="CallType" 
                                     SortExpression="varCallType" />
                                 <asp:BoundField DataField="varCustName" HeaderText="CustomerName" 
                                     SortExpression="varCustName" />
                                 <asp:BoundField DataField="varRepersentName" HeaderText="ContactPerson" 
                                     SortExpression="varRepersentName" />
                                 <asp:BoundField DataField="varLandline" HeaderText="Landline" 
                                     SortExpression="varLandline" />
                                 <asp:BoundField DataField="varMobile" HeaderText="Mobile" 
                                     SortExpression="varMobile" />
                                 <asp:BoundField DataField="varRemark" HeaderText="Remark" 
                                     SortExpression="varRemark" />
                                 <asp:BoundField DataField="varNextDate" HeaderText="NextCallDate" 
                                     SortExpression="varNextDate" />  
                             </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSourceDSR" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>"  
                                
                              >       
                            <SelectParameters>
                                    <asp:SessionParameter Name="EmpId" SessionField="empid" Type="Int64" />
                                </SelectParameters>
                            </asp:SqlDataSource>
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
    <script type="text/javascript" src="assets/js/jquery.min.js"></script>
<script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
<script type="text/javascript" src="dist/bootstrap-clockpicker.min.js"></script>
<script type="text/javascript">
    $('.clockpicker').clockpicker()
	.find('input').change(function () {
	    console.log(this.value);
	});
    var input = $('#single-input').clockpicker({
        placement: 'bottom',
        align: 'left',
        autoclose: true,
        'default': 'now'
    });

    $('.clockpicker-with-callbacks').clockpicker({
        donetext: 'Done',
        init: function () {
            console.log("colorpicker initiated");
        },
        beforeShow: function () {
            console.log("before show");
        },
        afterShow: function () {
            console.log("after show");
        },
        beforeHide: function () {
            console.log("before hide");
        },
        afterHide: function () {
            console.log("after hide");
        },
        beforeHourSelect: function () {
            console.log("before hour selected");
        },
        afterHourSelect: function () {
            console.log("after hour selected");
        },
        beforeDone: function () {
            console.log("before done");
        },
        afterDone: function () {
            console.log("after done");
        }
    })
	.find('input').change(function () {
	    console.log(this.value);
	});

    // Manually toggle to the minutes view
    $('#check-minutes').click(function (e) {
        // Have to stop propagation here
        e.stopPropagation();
        input.clockpicker('show')
			.clockpicker('toggleView', 'minutes');
    });
    if (/mobile/i.test(navigator.userAgent)) {
        $('input').prop('readOnly', true);
    }
</script>
 
<script type="text/javascript">
    hljs.configure({ tabReplace: '    ' });
    hljs.initHighlightingOnLoad();
</script>
</body>
</html>
