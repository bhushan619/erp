<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSubType.aspx.cs" Inherits="Personnel_admin_AddSubType" %>

<!DOCTYPE html>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <title>Add SubType </title>

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
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
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
                               <asp:Label ID="lblCustName" runat="server" Text="lbladminName"></asp:Label>
                             </div>
                        </div>

                    </li>
   <li>
                           <a href="#" class="active-menu-top"><i class="fa fa-asterisk "></i> Product<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level collapse in ">
                          <li>
                                <a href="AddProduct.aspx" ><i class="fa fa-plus-circle"></i>Add Product</a>
                            </li>
                             <li>
                                <a href="AddType.aspx" ><i class="fa fa-plus-circle"></i>Add Type</a>
                            </li>
                             <li>
                                <a href="AddSubType.aspx" class="active-menu"><i class="fa fa-plus-circle"></i>Add SubType</a>
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
                       <a href="#"  ><i class="fa fa-smile-o "></i>Employee<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                                <a href="AddEmp.aspx"  ><i class="fa fa-user "></i>Add Employee</a>
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
                       <a href="#"><i class="fa fa-users "></i>Customer<span class="fa arrow"></span></a>
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
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogoutUp_Click"   ><i class="fa fa-sign-out "></i>Logout</asp:LinkButton>   
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
                                <div class="panel-heading">
                                    Add Product SubType
                                </div>
                                <div class="panel-body">
                                    <div class="col-md-4  col-sm-4">
                                        <div class="form-group">
                                            <asp:Label runat="server"> Product Type</asp:Label>
                                           
                                            <asp:DropDownList AppendDataBoundItems="true" ID="dropdownsubtype" runat="server" class="form-control" AutoPostBack="true" DataSourceID="SqlDataSource2" DataTextField="varProductType" DataValueField="varProductType">

                                                <asp:ListItem>--Select SubType--</asp:ListItem>
                                            </asp:DropDownList>

                                       
                                            <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:sanghaviunbreakablesConnectionString3 %>' ProviderName='<%$ ConnectionStrings:sanghaviunbreakablesConnectionString3.ProviderName %>' SelectCommand="SELECT * FROM tblproducttype"></asp:SqlDataSource>
                                        </div>
                                         <div class="form-group">
                                            <asp:Label runat="server">Product SubType</asp:Label>
                                            <asp:TextBox ID="txtProdSubType" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                         <div class="form-group">
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnAdd" runat="server"
                                                Text="Add" class="btn btn-warning" OnClick="btnAdd_Click" OnClientClick="return Confirm();" />
                                            &nbsp;
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                                class="btn btn-danger " OnClick="btnCancel_Click" />
                                               <asp:Button ID="btnupdate" runat="server" Text="Update" 
                                                class="btn btn-success " OnClick="btnupdate_Click"/>
                                        </div>

                                        

                                        
                                        
                                        

                                        
                                    </div>
                                    <div class="col-md-8  col-sm-8">
                                        <asp:TextBox ID="txtid" runat="server" Visible="false"></asp:TextBox>
                                          <div class="table-responsive">
                                              <asp:ListView ID="listprodsubtype" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="ID" OnItemCommand="listprodsubtype_ItemCommand">
                                                  
                                                  
                                                  <EmptyDataTemplate>
                                                      <table runat="server" style="">
                                                          <tr>
                                                              <td>No data was returned.</td>
                                                          </tr>
                                                      </table>
                                                  </EmptyDataTemplate>
                                                  
                                                  <ItemTemplate>
                                                      <tr style="">
                                                          <td>
                                                              <asp:Label Text='<%# Eval("ID") %>' runat="server" ID="IDLabel" /></td>
                                                          <td>
                                                              <asp:Label Text='<%# Eval("varProductType") %>' runat="server" ID="varProductTypeLabel" /></td>
                                                          <td>
                                                              <asp:Label Text='<%# Eval("varProductSubType") %>' runat="server" ID="varProductSubTypeLabel" /></td>
                                                           <td>
                                                            <asp:Button ID="btndelete" runat="server" CommandName="Deletes" CommandArgument='<%#Eval("ID")+","+Eval("varProductType") +","+Eval("varProductSubType")%>' CssClass="btn btn-xs btn-danger" Text="Delete" />
                                                            <asp:Button ID="btnedit" runat="server" CommandName="Edits" Text="Edit" CommandArgument='<%#Eval("ID")+","+Eval("varProductType") +","+Eval("varProductSubType")%>' CssClass="btn btn-xs btn-success" />
                                                        </td>
                                                      </tr>
                                                  </ItemTemplate>
                                                  <LayoutTemplate>
                                                      <table runat="server">
                                                          <tr runat="server">
                                                              <td runat="server">
                                                                  <table runat="server" id="itemPlaceholderContainer" style="" border="0"  class=" table table-striped table-bordered table-hover">
                                                                      <tr runat="server" style="">
                                                                          <th runat="server">ID</th>
                                                                          <th runat="server">ProductType</th>
                                                                          <th runat="server">ProductSubType</th>
                                                                          <th runat="server">Operations</th>
                                                                      </tr>
                                                                      <tr runat="server" id="itemPlaceholder"></tr>
                                                                  </table>
                                                              </td>
                                                          </tr>
                                                          <tr runat="server">
                                                              <td runat="server" style=""></td>
                                                          </tr>
                                                      </table>
                                                  </LayoutTemplate>
                                                  
                                              </asp:ListView>
                                              <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:sanghaviunbreakablesConnectionString2 %>' ProviderName='<%$ ConnectionStrings:sanghaviunbreakablesConnectionString2.ProviderName %>' SelectCommand="SELECT * FROM tblproductsubtype"></asp:SqlDataSource>
                                          </div>

                                       
                                    </div>




                                </div>
                            </div>
                        </div>
                    </div>
                </div>
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
    <script src="../assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="../assets/js/bootstrap.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="../assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="../assets/js/custom.js"></script>

</body>
</html>
