<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewConsignments.aspx.cs" Inherits="Personnel_employee_subadmin_ViewConsignments" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>  View Consignments  </title>

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
                         <ul class="nav nav-second-level">
                          <li>
                                <a href="RecieveStockJalgaon.aspx" ><i class="fa fa-share"></i>Recieve Stock</a>
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
                      <a href="#"  class="active-menu"><i class="fa fa-envelope "></i>Consignment<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level collapse in ">
                         <li>
                                <a href="ViewConsignments.aspx" class="active-menu-top"><i class="fa fa-pencil "></i>View/Update Consignments</a>
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
                 
                <div class="row">
                         <div class="col-md-12 col-sm-12 col-xs-12">
               <div class="panel panel-info">
                        <div class="panel-heading">
                           View Consignments
                        </div>
                        <div class="panel-body"> 
                      
                              <div class="col-md-3  col-sm-3"> 
                                <div class="form-group "> 
                                    <asp:DropDownList ID="ddlSearchBy" CssClass="form-control" runat="server" 
                                  AutoPostBack="true"      onselectedindexchanged="ddlSearchBy_SelectedIndexChanged">
                                    <asp:ListItem>-- Search By --</asp:ListItem>
                                    <asp:ListItem>Company Name</asp:ListItem>
                                    <asp:ListItem>Consignment Number</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                </div>
                               <div class="col-md-4  col-sm-4"> 
                                <div class="form-group "> 
                                           <asp:TextBox ID="txtCmpName" runat="server" class="form-control" Visible="false"
                                                placeholder="Company Name"  ></asp:TextBox>
                                           <asp:TextBox ID="txtConsignmentNumber" runat="server" class="form-control" 
                                                placeholder="Consignment Number" Visible="false" ></asp:TextBox> 
                                           <cc1:autocompleteextender ID="txtCmpName_AutoCompleteExtender" runat="server" 
                                            MinimumPrefixLength="1" CompletionInterval="1" 
                                            EnableCaching="true"
                                               DelimiterCharacters=""
                                                Enabled="True" 
                                                ServiceMethod="GetCompletionList" 
                                                CompletionSetCount="1" 
                                                TargetControlID="txtCmpName" UseContextKey="True">
                                           </cc1:autocompleteextender>
                                           
                                        </div>  
                                </div>
                                  <div class="col-md-4  col-sm-4">
                                    <div class="form-group">
                                            <asp:LinkButton ID="btnSearch" runat="server" Text="Search" 
                                                CssClass="btn btn-primary" onclick="btnSearch_Click" />
                                            <asp:LinkButton ID="btnReset" runat="server" Text="Reset" 
                                                CssClass="btn btn-danger" onclick="btnReset_Click"  />
                                        </div> 
                                  </div>
                                   
                                </div> 
                                 <div class="panel-body"> 
                       <div class="col-md-7  col-sm-7"> 
                        <div class="table-responsive center-block">

                     
                            <asp:ListView ID="listorder" runat="server" DataSourceID="SqlDataSource2" 
                             onitemcommand="listorder_ItemCommand" 
                                DataKeyNames="ConsNo,OrderNo" GroupPlaceholderID="groupPlaceHolder1" 
                             >
                                <AlternatingItemTemplate>
                                    <tr style="">
                                        <td>
                                            <asp:Label ID="ConsNoLabel" runat="server" 
                                                Text='<%# Eval("ConsNo") %>' />
                                        </td>
                                       
                                           
                                        <td>
                                            <asp:Label ID="OrderNoLabel" runat="server" Text='<%# Eval("OrderNo") %>' />
                                        </td> <td>
                                            <asp:Label ID="CustomerLabel" runat="server" 
                                                Text='<%# Eval("Customer") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                                        </td> 
                                        <td>
                                            <asp:Label ID="StatusLabel" runat="server" 
                                                Text='<%# Eval("Status") %>' />
                                        </td>
                                         <td>
                                             <asp:LinkButton ID="lnkViewFull" CommandName="View" CommandArgument='<%#Eval("ConsNo") %>' runat="server" ToolTip="View Bill" CssClass="fa fa-eye btn btn-xs btn-info"></asp:LinkButton>
                                               <asp:LinkButton ID="LinkButton1" CommandName="Updates" CommandArgument='<%#Eval("ConsNo") %>' runat="server" ToolTip="Update Consignment" CssClass="fa  fa-sign-in btn btn-xs btn-warning"></asp:LinkButton>
                                       </td>
                                    </tr>
                                </AlternatingItemTemplate>  
                                
                                 <ItemTemplate>
                                    <tr style="">
                                        <td>
                                            <asp:Label ID="ConsNoLabel" runat="server" 
                                                Text='<%# Eval("ConsNo") %>' />
                                        </td>
                                       
                                        
                                         
                                         <td>
                                            <asp:Label ID="OrderNoLabel" runat="server" Text='<%# Eval("OrderNo") %>' />
                                        </td> <td>
                                            <asp:Label ID="CustomerLabel" runat="server" Text='<%# Eval("Customer") %>' />
                                        </td>
                                         <td>
                                             <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                                         </td>
                                        
                                        <td>
                                            <asp:Label ID="StatusLabel" runat="server" 
                                                Text='<%# Eval("Status") %>' />
                                        </td>
                                          <td>
                                             <asp:LinkButton ID="lnkViewFull" CommandName="View" CommandArgument='<%#Eval("ConsNo") %>' runat="server" ToolTip="View Bill" CssClass="fa fa-eye btn btn-xs btn-info"></asp:LinkButton>
                                               <asp:LinkButton ID="LinkButton1" CommandName="Updates" CommandArgument='<%#Eval("ConsNo") %>' runat="server" ToolTip="Update Consignment" CssClass="fa  fa-sign-in btn btn-xs btn-warning"></asp:LinkButton>
                                       </td>
                                    </tr>
                                </ItemTemplate> 
                                 
                                <EmptyDataTemplate>
                                    <table runat="server" style="">
                                        <tr>
                                            <td>
                                                No data was returned.</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                 
                                
                                <LayoutTemplate>
                                    <table runat="server">
                                        <tr runat="server">
                                            <td runat="server">
                                                <table ID="itemPlaceholderContainer" runat="server" border="0" class="table table-bordered table-condensed table-responsive">
                                                    <tr runat="server" style="">
                                                        <th runat="server">
                                                            ConsNo</th>
                                                      
                                                       
                                                        <th runat="server">
                                                            OrderNo</th>  <th runat="server">
                                                            Customer</th>
                                                        <th runat="server">
                                                            Date</th>
                                                        <th runat="server">
                                                            Status</th>
                                                               <th id="Th1" runat="server">
                                                            Operation</th>
                                                    </tr>
                                                    <tr runat="server" ID="itemPlaceholder">
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server">
                                            <td runat="server" style="">
        
                                            </td>
                                        </tr>
                                    </table>
                                </LayoutTemplate> 
                                 
                                
                                 
                            </asp:ListView>
                             
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server"  
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>"  
                                
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                SelectCommand="SELECT distinct tblsuconsignment.intConsigmentNo AS `ConsNo`,tblsuconsignment.intOrderId AS OrderNo, tblsucustomer.varCompanyName AS Customer,  tblsuconsignment.dtDate AS `Date`, tblsuconsignment.varStatus AS Status FROM tblsucustomer, tblsuorder, tblsuconsignment WHERE tblsucustomer.intId = tblsuorder.intCustId AND tblsuconsignment.intOrderId = tblsuorder.intOrderId AND tblsuconsignment.varStatus !='Delivered' " >
                                
                            </asp:SqlDataSource>
                            
                        </div>
                       </div>
                        <div class="col-md-5  col-sm-5"> 
                         <div class="form-group">
                           Consignment Number : 
                             <asp:Label ID="lblConsignmentNo" runat="server" Text="Select From Table"></asp:Label>

                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtStatus" runat="server" placeholder="Status" CssClass="form-control" required></asp:TextBox>

                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnUpdate" CssClass="btn btn-success" runat="server" 
                                Text="Update" onclick="btnUpdate_Click" />
                               <asp:LinkButton ID="btnCamcel" CssClass="btn btn-danger" runat="server" 
                                Text="Cancel" onclick="btnCamcel_Click" />
                        </div>
                        </div>
                       </div> 
                                  </div>
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


