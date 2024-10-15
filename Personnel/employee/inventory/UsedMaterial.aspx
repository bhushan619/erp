<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsedMaterial.aspx.cs" Inherits="Personnel_employee_inventory_UsedMaterial" %>
 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  
     <title>Used Material</title>


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
                           <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Personnel/employee/inventory/Notification.aspx" CssClass="btn btn-primary fa fa-2x" ToolTip="Notification" runat="server"> </asp:HyperLink>
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
                                <a href="ViewStock.aspx"><i class="fa fa-pencil-square-o"></i>View stock</a>
                            </li>
                              <li>
                                <a href="SendStockAtJalgaon.aspx"><i class="fa fa-paper-plane "></i> Send Stock To Jalgaon</a>
                            </li>                        
                            </ul>
                    </li>     
                        <li>
                        <a href="#" class="active-menu"><i class="fa fa-plus-circle "></i>Material<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level collapse in">
                            <li>
                                <a href="AddMaterial.aspx"><i class="fa fa-pencil-square-o"></i>Add Material</a>
                            </li>
                              <li>
                                <a href="InwardMaterial.aspx"><i class="fa fa-paper-plane "></i> Inward Material</a>
                            </li>      
                               <li>
                                <a href="UsedMaterial.aspx" class=" active-menu-top"><i class="fa fa-paper-plane "></i>Update Used Material</a>
                            </li>                        
                            </ul>
                    </li>                                              
                  <li>
                      <a href="#"  ><i class="fa fa-envelope "></i>Messages<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level  ">
                         <li>
                                <a href="AddEnquiry.aspx"  ><i class="fa fa-pencil "></i>New Message</a>
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
                 <div class="col-md-6 col-sm-6 col-xs-12">
               <div class="panel panel-info">
                        <div class="panel-heading">
                           Used Material    
                         
                        </div>
                        <div class="panel-body">   
                                    <div class="form-group">
                           <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" required placeholder="Select Date"></asp:TextBox>
                             <cc1:CalendarExtender Format="dd-MM-yyyy"   ID="txtDOb_CalendarExtender" runat="server" 
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
                               <asp:DropDownList ID="ddlProduct" runat="server" CssClass="form-control" 
                                   DataSourceID="SqlDataSourcePrd" DataTextField="varMaterialName" 
                                   DataValueField="varMaterialName">
                               </asp:DropDownList> 
                               <asp:SqlDataSource ID="SqlDataSourcePrd" runat="server" 
                                   ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                   ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                   SelectCommand="SELECT varMaterialName FROM tblsumaterials">
                               </asp:SqlDataSource>
                            </div>
                          <div class="form-group">
                              <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" required placeholder="Quantity"></asp:TextBox>
                          </div>
                         <div class="form-group">
                              <asp:TextBox ID="txtReason" runat="server" CssClass="form-control" required placeholder="Reason"></asp:TextBox>
                          </div>
                             <div class="form-group">
                                 <asp:Button ID="btnAdd" CssClass="btn btn-info" runat="server" Text="Update"  OnClientClick="return Confirm();"
                                     onclick="btnAdd_Click" />
                                    <asp:Button ID="btnReset" CssClass="btn btn-danger" runat="server" 
                                     Text="Reset" onclick="btnReset_Click" />
                            </div>
                           
                         
                        </div>
                           
                   
                      
                            </div>
                             </div><div class="col-md-6 col-sm-6 col-xs-12">
               <div class="panel panel-primary">
                        <div class="panel-heading">
                         View Material
                         
                        </div>
                        <div class="panel-body"> 
                          <div class="table table-responsive">
                              <asp:GridView ID="grdMaterial" runat="server" 
                                  CssClass="table table-responsive table-bordered table-condensed" AutoGenerateColumns="False" 
                                  DataSourceID="SqlDataSourceMaterial">
                                  <Columns>
                                      <asp:BoundField DataField="Material" HeaderText="Material" 
                                          SortExpression="Material" />
                                      <asp:BoundField DataField="Unit" HeaderText="Unit" SortExpression="Unit" />
                                      <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty" />
                                  </Columns>
                              </asp:GridView>
                              <asp:SqlDataSource ID="SqlDataSourceMaterial" runat="server" 
                                  ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                  ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                  SelectCommand="SELECT varMaterialName AS Material, varUnit AS Unit, varQty AS Qty FROM tblsumaterials">
                              </asp:SqlDataSource>
                          </div>
                          
                            </div>
                            </div>
                            </div> </div>
                          
 
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