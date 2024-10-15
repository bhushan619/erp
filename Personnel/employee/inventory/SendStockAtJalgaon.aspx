<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="SendStockAtJalgaon.aspx.cs" Inherits="Personnel_employee_SendStockAtJalgaon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>  Send Stock To Jalgaon </title>

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
                        <a  href="EditProfile.aspx"><i class="fa fa-user "></i>Edit Profile</a>
                    </li>
                   
                      <li>
                        <a href="#" class="active-menu"><i class="fa fa-plus-circle "></i> Stock<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level collapse in">
                        
                            <li>
                                <a href="ViewStock.aspx"><i class="fa fa-pencil-square-o"></i>View stock</a>
                            </li>
                              <li>
                                <a href="SendStockAtJalgaon.aspx" class=" active-menu-top"><i class="fa fa-paper-plane "></i> Send Stock To Jalgaon</a>
                            </li>                        
                            </ul>
                    </li>    
                       <li>
                        <a href="#"><i class="fa fa-plus-circle "></i>Material<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                            <li>
                                <a href="AddMaterial.aspx"><i class="fa fa-pencil-square-o"></i>Add Material</a>
                            </li>
                              <li>
                                <a href="InwardMaterial.aspx"><i class="fa fa-paper-plane "></i> Inward Material</a>
                            </li>      
                               <li>
                                <a href="UsedMaterial.aspx"><i class="fa fa-paper-plane "></i>Update Used Material</a>
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
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogoutUp_Click"  ><i class="fa fa-sign-out "></i>Logout</asp:LinkButton>   
                    </li>
                </ul>
            </div>

        </nav>
        <!-- /. NAV SIDE  -->
        <div id="page-wrapper">
             <div id="page-inner">
                 
                <div class="row">
                
            <div class="col-md-4 col-sm-4">
               <div class="panel panel-info">
                        <div class="panel-heading">
                        Stock at Varkhedi
                    </div>
                   <div class="panel-body"> 
                      <div role="form">
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
	</div>          <div class="form-group">
                               
                                <asp:DropDownList ID="ddlprodj" runat="server" CssClass="form-control"   
                                         AppendDataBoundItems="True"                                        
                                             AutoPostBack="True" DataSourceID="SqlDataSource1"                                     
                                    DataTextField="ProName" DataValueField="intId" 
                                    onselectedindexchanged="ddlprodj_SelectedIndexChanged" >
                                              <asp:ListItem Text="-- Select Product --" />
                                </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                    ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 

                                   SelectCommand="SELECT intId, (SELECT distinct CONCAT(nvarProductName,' ',nvarProductSubType ,' ', intSize,' ', varUnit) FROM tblsuproducts WHERE intId = intProductId) as ProName FROM sanghaviunbreakables.tblsustockvarkhedi where intSack != 0 OR intNug !=0">
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
                                        
                                                 <div class="form-group">
                                                     <asp:LinkButton ID="SendStockJ" runat="server" Text="Send Stock" 
                                                         CssClass="btn btn-info" onclick="SendStockJ_Click"/>
                                                     &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" Text="Reset" 
                                                         CssClass="btn btn-danger" onclick="LinkButton1_Click" 
                                                        />

                                                 </div>
                           </div>

                       </div>

        </div>
             <!--/.ROW--> 

            </div>
              <div class="col-md-8 col-sm-8 ">
               <div class="panel panel-info">
                        <div class="panel-heading">
                         Send Stock at Jalgaon
                    </div>
                    <div class="panel-body">
                   <div class="table-responsive">
                              
                            <asp:GridView ID="grdOrderDetails" runat="server"  
                                CssClass="table table-striped table-bordered " 
                                onrowcommand="grdOrderDetails_RowCommand"  
                                >  <Columns>
   <asp:TemplateField>
   <ItemTemplate>
   <asp:LinkButton ID="Button2" runat="server" Text="" CommandName="remove"  CommandArgument='<%#Container.DataItemIndex+","+ Eval("Sack")+","+Eval("Nag") %>' CssClass="btn btn-xs btn-danger fa fa-times" />
   </ItemTemplate>
   </asp:TemplateField>
        </Columns>
                            </asp:GridView>
                         </div>
 <div class="panel-body">
     <div class="form-group"> 
                                                      <asp:TextBox ID="txtChallnoNo" runat="server" placeholder="Challno Number" class="form-control" required="required"></asp:TextBox>
                                        </div>
     <div class="form-group"> 
                                                      <asp:TextBox ID="txtreasonj" runat="server" placeholder="Reason" class="form-control" ></asp:TextBox>
                                        </div>
    <div class="form-group"> 
                                                      <asp:TextBox ID="txttransj" runat="server" placeholder="Vehical Number" class="form-control"   ></asp:TextBox>
                                        </div>
                         Total Sack :<asp:Label ID="lblProductTotalSack" runat="server" Text="Label"></asp:Label>
                         Total Nag : <asp:Label ID="lblProductTotalNag" runat="server" Text="Label"></asp:Label> 
                          <asp:LinkButton ID="btnAdd" runat="server" Text="Send to Jalgaon" CssClass="btn btn-success"  OnClientClick="return Confirm();"
                                                         onclick="btnAdd_Click" />&nbsp;
                        <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" class="btn btn-warning" ></asp:LinkButton>
                            </div>             </div>
                    </div></div>
            <div class="col-md-12 col-sm-12 col-xs-12 ">
               <div class="panel panel-info">
                        <div class="panel-heading">
                         Stock At Varkhedi Godown
                    </div>
                   <div class="panel-body"> 
                          <div class="panel-body">
                            <div role="form">
                           <div class="table-responsive">
                              <asp:GridView ID="grdStockManuf" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-responsive"
                                    DataKeyNames="intId" DataSourceID="SqlDataSourceasdsd" AllowPaging="True">
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

                                <asp:SqlDataSource ID="SqlDataSourceasdsd" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                    ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                    SelectCommand="SELECT sanghaviunbreakables.tblsuproducts.intId,CONCAT(tblsuproducts.nvarProductName,' ', tblsuproducts.intSize,' ', tblsuproducts.varUnit) as nvarProductName, sanghaviunbreakables.tblsustockvarkhedi.intSack, sanghaviunbreakables.tblsustockvarkhedi.intNug, 
                         tblsuproducts.intPacking * tblsustockvarkhedi.intSack + tblsustockvarkhedi.intNug AS total
 FROM sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockvarkhedi ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockvarkhedi.intProductId">
                                </asp:SqlDataSource>
                              </div>                          
                            </div>
                            </div>
                       </div>

        </div>
             <!--/.ROW--> 
              
            </div>
            <!-- /. PAGE INNER  -->
        </div>
            <!-- /. PAGE INNER  -->
        </div>
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