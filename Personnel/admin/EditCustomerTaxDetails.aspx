<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditCustomerTaxDetails.aspx.cs" Inherits="Personnel_admin_EditCustomerTaxDetails" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>Update Customer </title>

    <!-- BOOTSTRAP STYLES-->
    <link href="../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />  
    <!-- FONTAWESOME STYLES-->
    <link href="../assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="../assets/css/bootstrap-fileupload.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="../assets/css/custom.css" rel="stylesheet" />
       
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
                                <a href="AddProduct.aspx" ><i class="fa fa-plus-circle"></i>Add Product</a>
                            </li>
                             <li>
                                <a href="AddType.aspx" ><i class="fa fa-plus-circle"></i>Add Type</a>
                            </li>
                             <li>
                                <a href="AddSubType.aspx" ><i class="fa fa-plus-circle"></i>Add SubType</a>
                            </li>
                            <li>
                                <a href="UpdateProduct.aspx"><i class="fa fa-pencil-square-o"></i>Update Product</a>
                            </li>
                              <li>
                               <a href="ViewStock.aspx"><i class="fa fa-cubes"></i>Stock</a>
                            </li>
                            </ul>
                    </li> 
                    <li>
                       <a href="#"><i class="fa fa-smile-o "></i>Employee<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                             <a href="AddEmp.aspx"><i class="fa fa-user "></i>Add Employee</a>
                            </li>
                            <li>
                                 <a href="ViewEmp.aspx"><i class="fa fa-eye "></i>View Employee</a>
                            </li>
                               <li>
                                <a href="ViewEmpDsr.aspx"><i class="fa fa-pencil "></i>DSR</a>
                            </li>                         
                           
                        </ul>
                    </li> 
                    <li>
                       <a href="#" class="active-menu-top"><i class="fa fa-users "></i>Customer<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                                  <a href="AddCustomer.aspx"><i class="fa fa-user "></i>Add Customer</a>
                            </li>
                            <li>
                                <a href="ViewCustomer.aspx"><i class="fa fa-eye"></i>View Customer</a>
                            </li> 
                        </ul>
                    </li> 
                      <li>
                        <a href="#"><i class="fa fa-envelope "></i>Messages<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level"> <li>
                                <a href="CreateMessage.aspx"><i class="fa fa-pencil "></i>New Message</a>
                            </li>
                          <li>
                                  <a href="ViewMessages.aspx"><i class="fa fa-comments"></i>Recieved Messages</a>
                            </li>
                           <li>
                                  <a href="ViewSentMessages.aspx"><i class="fa fa-inbox"></i>Sent Messages</a>
                            </li>
                        </ul>
                    </li> 
                   <li>
                      <a href="Report.aspx" ><i class="fa fa-folder "></i>Report</a>
                      
                    </li> 
                    <li>
                           <a  href="ViewConsignmentStatus.aspx"><i class="fa fa-map-marker "></i>Track Consignment</a>
                    </li>
                      
                    <li>
                        <a  href="Notification.aspx"><i class="fa fa-bell "></i>Notifications</a>
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
                  <div class="col-md-12">                     
         <div class="panel panel-info"> 
                        <div class="panel-body">
                            <ul class="nav nav-tabs">
                                <li class=""><a href="EditCustomer.aspx"  >Update Main Details</a>
                                </li>
                                <li class=""><a href="EditCustomerOther.aspx"  >Update Other Details</a>
                                </li> 
                                  <li class="active"><a href="EditCustomerTaxDetails.aspx"  >Update Transaction Details</a>
                                </li> 
                            </ul>

                              <div class="tab-content">
                                <div class="tab-pane fade active in" > 
                                          <br /> 
                                <div class="col-md-4  col-sm-4">
                                  
                                <div class="form-group">
                                    <label>Taxable</label>
                                    <asp:TextBox ID="txtTaxable" runat="server"  class="form-control" required placeholder="Taxable" ></asp:TextBox>
                                    </div>
                                     <div class="form-group">
                                    <label>Taxt Type</label>
                                    <asp:TextBox ID="txtType" runat="server"  class="form-control" required placeholder="Tax Type" ></asp:TextBox>
                                    </div>
                                     <div class="form-group">
                                    <label>CST Number</label>
                                    <asp:TextBox ID="txtCST" runat="server"  class="form-control" required placeholder="CST Number" ></asp:TextBox>
                                    </div>
                                     <div class="form-group">
                                    <label>Tax Group</label>
                                    <asp:TextBox ID="txtTaxgroup" runat="server"  class="form-control" required placeholder="Tax Group" ></asp:TextBox>
                                    </div>
                                       
                                    
                                       <div class="form-group  input-group">
                                    <label>Tax Discount</label>
                                    <asp:TextBox ID="txtTaxDiscount" runat="server"  class="form-control" required placeholder="Tax Discount"  onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                                   <span class="form-group input-group-btn "><br /><p class="btn btn-default" >%</p> </span>
                                               
                                     </div> 
                                   <div class="form-group">
                                    <label>Credit Bills</label>
                                    <asp:TextBox ID="txtCrBills" runat="server"  class="form-control"  required placeholder="Credit Bills"  onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" ></asp:TextBox>
                                     </div>

                                     <div class="form-group">
                                    <label>Credit Limit</label>
                                    <asp:TextBox ID="txtCrLimit" runat="server"  class="form-control" required placeholder="Credit Limit"  onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" ></asp:TextBox>
                                  
                                </div>
                                     <div class="form-group">
                                    <label>Credit Days</label>
                                    <asp:TextBox ID="txtCrDays" runat="server"  class="form-control" required placeholder="Credit Days" ></asp:TextBox>
                                    </div>
                                    <asp:Button ID="btnAdd" runat="server" Text="Insert"  CssClass="btn btn-success" OnClick="btnAdd_Click" OnClientClick="return Confirm();" />
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-warning" OnClick="btnUpdate_Click" />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="btnReset_Click" />
                                  </div>

                                      <div class="col-md-8 col-sm-8">
                            <div class="table-responsive">
                                <br />
                                    <asp:GridView ID="grdCustomerTaxDetails" runat="server" 
                                    CssClass=" table table-striped table-bordered table-hover" 
                                    AllowPaging="True" 
                                    AutoGenerateColumns="False" OnRowCommand="grdCustomerTaxDetails_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="varTaxable" HeaderText="Taxable" 
                                            SortExpression="varTaxable" />
                                        <asp:BoundField DataField="varTaxType" HeaderText="Tax Type" 
                                            SortExpression="varTaxType" />
                                        <asp:BoundField DataField="varCSTnumber" HeaderText="CST Number" 
                                            SortExpression="varCSTnumber" />
                                        <asp:BoundField DataField="varTaxGroup" HeaderText="Tax Group" 
                                            SortExpression="varTaxGroup" />
                                         <asp:BoundField DataField="varTaxDiscount" HeaderText="Tax Discount" 
                                            SortExpression="varTaxDiscount" />
                                     <asp:TemplateField>
                                                 <ItemTemplate>
                                                     <asp:LinkButton ID="Button2" runat="server" Text="" CommandName="removes" 
                                                        CommandArgument='<%# Eval("intId") %>' CssClass="btn btn-xs btn-danger fa fa-times" />
                                                 </ItemTemplate>
                                     </asp:TemplateField>
                                           
                                    </Columns>
                                </asp:GridView>
                                 </div>
                                          </div>
                                    </div>
                                  </div>
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
    <script src="../assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="../assets/js/bootstrap.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="../assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="../assets/js/custom.js"></script>
</body>
</html>
