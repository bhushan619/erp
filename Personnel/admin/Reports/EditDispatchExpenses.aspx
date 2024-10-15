<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditDispatchExpenses.aspx.cs" Inherits="Personnel_admin_Reports_EditDispatchExpenses" %>

<!DOCTYPE html>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>Report</title>

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
                <a class="navbar-brand" href="../Default.aspx">Sanghavi Unbreakables</a>
            </div>

            <div class="header-right">
 <a href="../Default.aspx" class="btn btn-info" title="Profile"><i class="fa fa-user fa-2x"></i></a>
                        <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Personnel/admin/Notification.aspx" CssClass="btn btn-primary fa fa-2x" ToolTip="Notification" runat="server"> </asp:HyperLink>
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
                               <asp:Label ID="lblCustName" runat="server" Text="lblAdminName"></asp:Label>
                             </div>
                        </div>

                    </li>
                <li>
                      <a href="#"><i class="fa fa-asterisk "></i> Product<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level">
                          <li>
                                <a href="../AddProduct.aspx" ><i class="fa fa-plus-circle"></i>Add Product</a>
                            </li>
                            <li>
                                <a href="../UpdateProduct.aspx"><i class="fa fa-pencil-square-o"></i>Update Product</a>
                            </li>
                              <li>
                                <a href="../ViewStock.aspx"><i class="fa fa-cubes"></i>Stock</a>
                            </li>
                            </ul>
                    </li> 
                    <li>
                       <a href="#"><i class="fa fa-smile-o "></i>Employee<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                             <a href="../AddEmp.aspx"><i class="fa fa-user "></i>Add Employee</a>
                            </li>
                            <li>
                                 <a href="../ViewEmp.aspx"><i class="fa fa-eye "></i>View Employee</a>
                            </li>
                               <li>
                                <a href="../ViewEmpDsr.aspx"><i class="fa fa-pencil "></i>DSR</a>
                            </li>                         
                           
                        </ul>
                    </li> 
                    <li>
                       <a href="#"><i class="fa fa-users "></i>Customer<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                                <a href="../AddCustomer.aspx"><i class="fa fa-user "></i>Add Customer</a>
                            </li>
                            <li>
                                <a href="../ViewCustomer.aspx"><i class="fa fa-eye"></i>View Customer</a>
                            </li> 
                        </ul>
                    </li> 
                 <li>
                        <a href="#"><i class="fa fa-envelope "></i>Messages<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level">  <li>
                                <a href="../CreateMessage.aspx"><i class="fa fa-pencil "></i>New Message</a>
                            </li>
                          <li>
                                  <a href="../ViewMessages.aspx"><i class="fa fa-comments"></i>View Messages</a>
                            </li>
                           <li>
                                  <a href="../ViewSentMessages.aspx"><i class="fa fa-inbox"></i>Sent Messages</a>
                            </li>
                        </ul>
                    </li> 
                   <li>
                      <a href="../Report.aspx" class="active-menu"><i class="fa fa-folder "></i>Report</a>
                      
                    </li> 
                    <li>
                           <a  href="../ViewConsignmentStatus.aspx"><i class="fa fa-map-marker "></i>Track Consignment</a>
                    </li>
                      
                    <li>
                        <a  href="../Notification.aspx"><i class="fa fa-bell "></i>Notifications</a>
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
                <!-- /. ROW  -->
                 <div class="row">
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
                                           <asp:LinkButton ID="btnEditUpdate" runat="server" Text="Update" OnClientClick="return Confirm();" CssClass="btn btn-success" Visible="false"
                                                         onclick="btnEditUpdate_Click" />&nbsp;
                        <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" class="btn btn-warning" OnClick="btnCancel_Click"></asp:LinkButton>
     
                         </div>
                                          
                                
                         </div>
                             
                         </div>
                          
                      
                      
                      </div>
                      </div>
                    </div>
                    
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
