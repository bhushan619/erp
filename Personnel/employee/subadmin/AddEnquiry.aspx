<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="AddEnquiry.aspx.cs" Inherits="Personnel_customer_AddEnquiry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 <html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>Add Enquiry</title>

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
                                <a href="RecieveStockJalgaon.aspx"><i class="fa fa-share"></i>Recieve Verkhedi Stock</a>
                            </li>
                            <li>
                                <a href="ViewStock.aspx"><i class="fa fa-pencil-square-o"></i>View stock</a>
                            </li>
                            <li>
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
                        <a href="#" class="active-menu"><i class="fa fa-envelope "></i>Messages<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level collapse in">
                         <li>
                                <a class="active-menu-top" href="AddEnquiry.aspx"><i class="fa fa-pencil "></i>New Message</a>
                            </li>
                          <li>
                                <a  href="InboxMsg.aspx"><i class="fa fa-comment"></i>Recieved Messages</a>
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
                <!-- /. ROW  -->
                <div class="row">
                 <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="panel panel-info">
                        <div class="panel-heading">
               Create Enquiry Message
                        </div>
                      
                      <div class="panel-body"> <div class="form-group" align="right"> 
                          
                               <asp:Label ID="Label1" runat="server" Text="Date:"></asp:Label> <asp:Label ID="lbldate" runat="server"  ></asp:Label>&nbsp;&nbsp;
                               <asp:Label ID="Label2" runat="server" Text="Time:"></asp:Label> <asp:Label ID="lblTime" runat="server"  ></asp:Label>
                               </div>
                                <div class="form-group">
                                 <asp:Label ID="Label3" runat="server" Text="Select list"></asp:Label>
                          <asp:DropDownList ID="ddlSelectDesig" runat="server"  class="form-control"
                                
                                        onselectedindexchanged="ddlSelectDesig_SelectedIndexChanged" 
                                        AutoPostBack="True">
                                   <asp:ListItem Text="-- Select List --" />
                                   <asp:ListItem Text="Employee" />
                                   <asp:ListItem Text="Customer" />
             </asp:DropDownList>
                      <div class="form-group">
                       <asp:Label ID="Label4" runat="server" Text="Select Member"></asp:Label>
                          <asp:DropDownList ID="ddlDesigs" runat="server"  class="form-control" 
                                  DataSourceID="SqlDataSource1"  AppendDataBoundItems="true" 
                             >
                                   <asp:ListItem Text="-- Select --" />
             </asp:DropDownList>
                              <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                  ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                  ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                  ></asp:SqlDataSource>
                                  </div>
                           
<div class="form-group">
    <asp:Label ID="lblEnqSub" runat="server" Text="Enquiry Subject"></asp:Label>
                <asp:TextBox ID="txtSubject" runat="server" class="form-control" 
                 placeholder="Enter Subject"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubject"
                                ErrorMessage="*"  SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>

 <div class="form-group">
                            <asp:Label ID="lblEnqDesc" runat="server" Text="Enquiry Description"></asp:Label>
                  <asp:TextBox ID="txtMsg" runat="server" class="form-control" 
                                        placeholder="Enter Message" TextMode="MultiLine" ></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMsg"
                                ErrorMessage="*"  SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </div>


  <asp:Button ID="btnSend" runat="server" Text="SEND" class="btn btn-success" onclick="btnSend_Click" OnClientClick="return Confirm();"></asp:Button>
                               &nbsp;&nbsp; &nbsp;&nbsp;
                                     <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                class="btn btn-warning" onclick="btnCancel_Click" CausesValidation="False"></asp:Button>
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