<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="CreateStock.aspx.cs" Inherits="Personnel_employee_CreateStock" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>  Create Stock  </title>

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
                           <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Personnel/employee/production/Notification.aspx" CssClass="btn btn-primary fa fa-2x" ToolTip="Notification" runat="server"> </asp:HyperLink>
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
                                 <a href="AddRawMaterial.aspx" ><i class="fa fa-paper-plane"></i>Add New Material </a>
                            </li>   
                           <li>
                                 <a   href="UpdateRawMaterial.aspx" ><i class="fa fa-paper-plane"></i>Inward Raw Material</a>
                            </li>       
                                <li>
                               <a class="active-menu-top" href="CreateStock.aspx"><i class="fa fa-cubes"></i>Create Stock</a>
                            </li>
                                       <li>
                               <a href="InwardStock.aspx"><i class="fa fa-cubes"></i>Inward Stock</a>
                            </li>     <li>
                               <a   href="Scrap.aspx"><i class="fa fa-cubes"></i>Scrap</a>
                            </li>   
                              <li>
                               <a   href="ViewStock.aspx" ><i class="fa fa-cubes"></i>View Stock</a>
                            </li>     
                            </ul>
                    </li>          <li>
                        <a  href="ViewJalgaonOrder.aspx"><i class="fa fa-user "></i>View Jalgaon Order</a>
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
                
            <div class="col-md-8 col-sm-8">
               <div class="panel panel-info">
                        <div class="panel-heading">
                         Add Stock At Varkhedi
                    </div>
                   <div class="panel-body">  
            
                   <div class="row">
                   <div class="col-md-6 col-sm-6">
                     <div class="form-group">
                           <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" required placeholder="Select Date"></asp:TextBox>
                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOb_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDate"  > 
                                </cc1:CalendarExtender>
                           </div>
                   </div>
                      <div class="col-md-6 col-sm-6">
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
     </div>
                    </div>
              <div class="row">
               <div class="col-md-5">
               <div class="form-group" >
                   <asp:DropDownList ID="ddlMaterial" CssClass="form-control" runat="server" 
                       AppendDataBoundItems="True" DataSourceID="SqlDataSourceMaterial" 
                       DataTextField="varName" DataValueField="varName">
                       <asp:ListItem>-- Material Used --</asp:ListItem>
                   </asp:DropDownList>
                   <asp:SqlDataSource ID="SqlDataSourceMaterial" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                       ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                       SelectCommand="SELECT varName FROM tblrawmaterial"></asp:SqlDataSource>
                </div>    
                   
                        <div class="form-group" >
                              Used(KG):<asp:TextBox onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                                  ID="txtQty" placeholder="Quantity" CssClass="form-control" 
                                  runat="server"  >0</asp:TextBox>
                               </div>    
                               <div class="form-group">
                                   <asp:LinkButton ID="btnAddMaterial" runat="server" Text="Add" 
                                       CssClass="btn btn-primary" onclick="btnAddMaterial_Click"/>
                                    <b>Total(KG): <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label> KG</b>
                               </div>
                   </div>
                
                    <div class="col-md-7">
                    List of Materials: 
                        <asp:GridView ID="grdMatDetails" runat="server" 
                          onrowcommand="grdOrderDetails_RowCommand"   CssClass="table table-striped table-bordered " >
                      <Columns>
   <asp:TemplateField>
   <ItemTemplate>
   <asp:LinkButton ID="Button2" runat="server" Text="" CommandName="remove" 
   CommandArgument='<%#Container.DataItemIndex+","+Eval("Qty") %>' CssClass="btn btn-xs btn-danger fa fa-times" />
   </ItemTemplate>
   </asp:TemplateField>
        </Columns>
                        </asp:GridView>
                      
                   </div>
                   </div>
                
                   <div class="row"> 
                      <div role="form">   
                       <div class="col-lg-12 col-sm-12"> 
                        <div class="form-group">
                                 
                                <asp:DropDownList ID="ddlProName" runat="server" CssClass="form-control"   
                                             DataSourceID="SqlDataSource2" DataTextField="ProductName"  
                                               onselectedindexchanged="ddlProName_SelectedIndexChanged" 
                                             AutoPostBack="True"
                                                 DataValueField="ProductName" AppendDataBoundItems="true">
                                              <asp:ListItem Text="-- Select Product --" />
                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                              ></asp:SqlDataSource>
                                        </div>
                            </div>
                             <div class="col-lg-6 col-sm-6">
                                      <div class=" form-group input-group"> 
                                      Total Nug Produced :
     <asp:TextBox ID="txtTotalProduct" runat="server" placeholder="Total Product" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                                                        class="form-control"  required 
                                                          AutoPostBack="True" 
                                              ontextchanged="txtTotalProduct_TextChanged" >0</asp:TextBox>
                                                <span class="form-group input-group-btn">
                                              <br />   <p class="btn btn-default" >Nug</p>
                                                  </span>
                                                </div>
                               </div>
                               <div class="col-lg-3 col-sm-3">
                              <div class=" form-group">
                                Sack:<br /> <asp:Label ID="lblSack" runat="server" Text="Sack"></asp:Label> 
                                                </div>
                              </div>
                                 <div class="col-lg-3 col-sm-3">
                                 <div class=" form-group input-group">
                                    Nug:<br />  <asp:Label ID="lblNug" runat="server" Text="Nug"></asp:Label> 
                                                </div>
                                                </div>
                               
                               
                              </div>      
                                          <div class="col-lg-12 col-sm-12"> 
                          <div class="form-group"> 
                            <asp:TextBox ID="txtReason" required runat="server" placeholder="Reason" class="form-control" ></asp:TextBox>
            </div> </div>
                                          <div class="col-lg-12 col-sm-12">          
                        <div class="form-group">
                            <asp:Button ID="btnAddToOrder" runat="server" Text="Add Stock"  OnClientClick="return Confirm();"
                                CssClass="btn btn-info" onclick="btnAddToOrder_Click"/>
                            &nbsp;<asp:LinkButton ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-danger" 
                                onclick="btnReset_Click"/>
                    </div></div>
                                            </div>
                                          
                                            </div>
                                            </div>
                                            
                                            </div>
                <div class="col-md-4 col-sm-4">
               <div class="panel panel-primary">
                        <div class="panel-heading">
                         Stock At Varkhedi Godown
                    </div>
                   <div class="panel-body">  
                            <div role="form">
                                                    <div class="table-responsive">
                              <asp:GridView ID="grdStockManuf" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-responsive"
                                    DataKeyNames="intId" DataSourceID="SqlDataSourceasdsd" AllowPaging="True">
                                    <Columns> 
                                      
                                     
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" 
                                            SortExpression="ProductName" />
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
                                    SelectCommand="SELECT sanghaviunbreakables.tblsuproducts.intId, CONCAT(tblsuproducts.nvarProductName,' ', tblsuproducts.intSize,' ', tblsuproducts.varUnit) as ProductName, sanghaviunbreakables.tblsustockvarkhedi.intSack, sanghaviunbreakables.tblsustockvarkhedi.intNug, 
                         tblsuproducts.intPacking * tblsustockvarkhedi.intSack + tblsustockvarkhedi.intNug AS total
 FROM sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockvarkhedi ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockvarkhedi.intProductId">
                                </asp:SqlDataSource>
                              </div>
                            </div> 
                       </div>

        </div>
                
                   </div>
                      </div> </div> 
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

