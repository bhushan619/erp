<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExpenseSheet.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="Personnel_employee_marketing_ExpenseSheet" %>

<!DOCTYPE html>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 <html xmlns="http://www.w3.org/1999/xhtml">
 <head id="Head1" runat="server">
    
     <title>Create Expense Sheet</title>

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
                        <a href="#"><i class="fa fa-plus-circle "></i> DSR<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level">
                          <li>
                                <a href="CreateDSR.aspx" ><i class="fa fa-share"></i>Create DSR</a>
                            </li>
                             
                            </ul>
                    </li>       
                     <li>
                        <a href="#" class="active-menu"><i class="fa fa-plus-circle "></i> Expense Sheet<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level   collapse in">
                          <li>
                                <a class="active-menu-top" href="ExpenseSheet.aspx"><i class="fa fa-share"></i>Create Expense Sheet</a>
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
                        New Expense Sheet
                        </div>
               <div class="panel-body">  
                   <div class="row">
 <div class="col-md-4 col-sm-4">
                        <div class="form-group"> 
                           <asp:TextBox ID="txtFDate" CssClass="form-control" runat="server" required placeholder="Select Start Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOb_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtFDate"  > 
                                </cc1:CalendarExtender> 
                  </div></div>
      <div class="col-md-4 col-sm-4">
                        <div class="form-group"> 
                           <asp:TextBox ID="txtTDate" CssClass="form-control" runat="server" required placeholder="Select End Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="CalendarExtender1" runat="server" 
                                    Enabled="True" TargetControlID="txtTDate"  > 
                                </cc1:CalendarExtender> 
                  </div></div>
           <div class="col-md-4 col-sm-4">
                   <div class="form-group"> 
                           <asp:TextBox ID="txtLocation" CssClass="form-control" runat="server" required placeholder="Location"></asp:TextBox>
                           </div>
                            </div> 
                            
                   </div> 
                     <div class="row">
                           
                         <div class="col-md-4 col-sm-4">
                           <div class="form-group"> <asp:TextBox ID="txtintId" Visible="false"  runat="server"   ></asp:TextBox>
                           <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" required placeholder="Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="CalendarExtender2" runat="server" 
                                    Enabled="True" TargetControlID="txtDate"  > 
                                </cc1:CalendarExtender> </div>
                                <div class="form-group"> 
                           <asp:TextBox ID="txtPlace" CssClass="form-control" runat="server" required placeholder="Place"></asp:TextBox>
                           </div>
                                <div class="form-group"> 
                           <asp:TextBox ID="txtDetails" TextMode="MultiLine" CssClass="form-control" runat="server"  placeholder="Details of expenses"></asp:TextBox>
                           </div>
                                <div class="form-group"> 
                           <asp:TextBox ID="txtModeOfTransport" CssClass="form-control" runat="server"  placeholder="Train or Bus or Travel"></asp:TextBox>
                           </div>
                                <div class="form-group"> 
                           <asp:TextBox ID="txtLocalExp" onkeyup="checkDec(this);" CssClass="form-control" runat="server"  placeholder="Local Exp.(Auto/other)"></asp:TextBox>
                           </div>
                              <div class="form-group"> 
                           <asp:TextBox ID="txtLodging" onkeyup="checkDec(this);" CssClass="form-control" runat="server"  placeholder="Lodging"></asp:TextBox>
                           </div>
                                  <div class="form-group"> 
                           <asp:TextBox ID="txtDA" onkeyup="checkDec(this);" CssClass="form-control" runat="server"  placeholder="D.A"></asp:TextBox>
                           </div>
                                  <div class="form-group"> 
                           <asp:TextBox ID="txtOther" onkeyup="checkDec(this);" CssClass="form-control" runat="server"  placeholder="Other"></asp:TextBox>
                           </div>
                                  <div class="form-group"> 
                           <asp:TextBox ID="txtTotal" onkeyup="checkDec(this);" CssClass="form-control" runat="server" required placeholder="Total"></asp:TextBox>
                           </div>
                              <div class="form-group"> 
                                <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" 
                                    Text="Add to sheet" onclick="btnSubmit_Click" />
                                  
                                 <asp:LinkButton ID="btnReset" CssClass="btn btn-warning" runat="server" 
                                    Text="Cancel" onclick="btnReset_Click" />
                           </div>
                         </div> 
                           <div class=" col-lg-8">
                          
                              <div style="overflow-y: hidden;">
                                  <asp:GridView ID="grdSheetDetails" AutoGenerateColumns="false" OnRowCommand="grdSheetDetails_RowCommand" OnRowDataBound="grdSheetDetails_RowDataBound" ShowFooter="true" runat="server" CssClass="table table-bordered" >
                                     <Columns>
                                          <asp:TemplateField>
                                        <HeaderTemplate>Edit</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton CssClass=" fa fa-times btn btn-danger" ID="aa" CommandArgument='<%# Container.DataItemIndex %>' CommandName="remove" runat="server"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                         <asp:BoundField HeaderText="Date" DataField="Date" />
                                         <asp:BoundField HeaderText="Place" DataField="Place" />
                                         <asp:BoundField HeaderText="Details of expenses" DataField="Details of expenses" />
                                         <asp:BoundField HeaderText="Transport" DataField="Transport" />
                                         <asp:BoundField HeaderText="Local Exp" DataField="Local Exp" />
                                         <asp:BoundField HeaderText="Lodging" DataField="Lodging" />
                                         <asp:BoundField HeaderText="DA" DataField="DA" />
                                         <asp:BoundField HeaderText="Other" DataField="Other" FooterText="Total:" />
                                         <asp:BoundField HeaderText="Total" DataField="Total" />
                                          
                                     </Columns>
                                      <EmptyDataTemplate>No Details Added</EmptyDataTemplate>
                                  </asp:GridView>
                                          </div>
                                <div class="form-group text-right"> 
                                <asp:LinkButton ID="btnSubmitSheet" CssClass="btn btn-primary" runat="server"  OnClientClick="return Confirm();"
                                    Text="Submit" onclick="btnSubmitSheet_Click" />
                                    <asp:LinkButton ID="btnEditUpdate" runat="server" Text="Update" OnClientClick="return Confirm();" CssClass="btn btn-success" Visible="false"
                                                         onclick="btnEditUpdate_Click" /> 
                                 <asp:LinkButton ID="LinkButton1" CssClass="btn btn-danger" runat="server" 
                                    Text="Cancel" onclick="btnReset_Click" />
                           </div>
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
                          View/Update Expense Sheet
                        </div>
                        <div class="panel-body"> 
                        <div class="table-responsive">
                            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="false" OnRowCommand="grdView_RowCommand" CssClass="table table-bordered" >
                                <Columns>
                                     <asp:BoundField HeaderText="intId" DataField="intId" />
                                      <asp:BoundField HeaderText="Start Date" DataField="Start Date" />
                                         <asp:BoundField HeaderText="End Date" DataField="End Date" />
                                         <asp:BoundField HeaderText="Location" DataField="Location" />
                                      <asp:BoundField HeaderText="Total Expenses" DataField="Total Expenses" />
                                   <%-- <asp:TemplateField>
                                        <HeaderTemplate>View</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton CssClass=" fa fa-eye btn btn-danger" ID="aa" CommandArgument='<%# Eval("intId") %>' CommandName="views" runat="server"></asp:LinkButton>
                                            <asp:LinkButton CssClass=" fa fa-edit btn btn-warning" ID="LinkButton2" CommandArgument='<%# Eval("intId") %>' CommandName="edits" runat="server"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                                  <EmptyDataTemplate>No Details Added</EmptyDataTemplate>
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
