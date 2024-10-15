<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DistrictWiseCustomer.aspx.cs" Inherits="Personnel_admin_Reports_DistrictWiseCustomer" %>

<%@ Register Assembly="GroupingView" Namespace="UNLV.IAP.WebControls" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <script src="http://maps.google.com/maps/api/js?sensor=false"
        type="text/javascript"></script>
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
            <div id="page-wrapper" style="height: auto">
                <div id="page-inner">
                    <!-- /. ROW  -->
                  
                    <div class="row">
                        <div class="col-lg-12 col-sm-12">
                            <div class="panel panel-info">
                                <div class="panel-heading">
                                    Report of DistrictWise Customer 

                                </div>
                                <div class="panel-body">
                                    <div class="row">
  <div class="container">
      <div class="col-md-3"></div>
<div class="col-md-6">
                                            Serach Customer DistrictWise<asp:TextBox ID="txtName" runat="server" CssClass="form-control"
                                                placeholder="District" class="form-control"  ></asp:TextBox>
                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" MinimumPrefixLength="1" CompletionInterval="1"
                                                EnableCaching="true"
                                                DelimiterCharacters=""
                                                Enabled="True"
                                                ServiceMethod="GetCompletionList"
                                                CompletionSetCount="1"
                                                TargetControlID="txtName" UseContextKey="True">
                                            </cc1:AutoCompleteExtender>
                                            <br />
                                            <asp:Button ID="btnSearch" CssClass="btn btn-warning" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btnCancel" CssClass=" btn btn-danger" runat="server" Text="Clear" OnClick="btnCancel_Click" />
                                            &nbsp;&nbsp;   &nbsp;     
                                            <asp:Button ID="btnExport" runat="server" CssClass=" btn btn-success" Text="Export In Excel" OnClick="btnExport_Click" />
                                        </div>
      <div class="col-md-12">
                                        <br />
        <cc2:GroupingView ID="GroupingView1" runat="server" GroupingDataField="varCity"
              >

            <GroupTemplate>
                <div class="col-md-12"  >
                     <br />
                    <h4>
                        <asp:Label ID="lblRegion"   runat="server" Text='<%# Eval("varCity") %>' /></h4>
                    <div class="bordex"></div>
                </div>
                
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
              
            </GroupTemplate>
            <ItemTemplate>

                <div class="col-md-4"  >
                    <asp:Label ID="lblcityname" runat="server" Text='<%# Eval("varCompanyName") %>' /> 
                    <div class="bordexs"></div>
               
                </div>
                 
            </ItemTemplate>

        </cc2:GroupingView>

                                    </div>
                    </div>
                                        
                                    </div>

                                    
                                    

                                </div>
                                <div class="row">
                            <%--        <div class="col-md-12">
                                        <br />
                                        <cc2:GroupingView ID="GroupingView2" runat="server" DataSourceID="SqlDataSource1" GroupingDataField="varCity" BorderStyle="Solid" BorderWidth="1px">
                                            <EmptyDataTemplate>
                                                No Data

                                            </EmptyDataTemplate>
                                            <GroupTemplate>
                                                <div class="col-md-4">
                                                    <div class="section-heading">
                                                        <h4>
                                                            <asp:Label ID="lblCity" runat="server" Text='<%# Eval("varCity") %>' /></h4>
                                                    </div>
                                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                                </div>
                                            </GroupTemplate>
                                            <ItemTemplate>
                                                <div class="col-md-4" style="width: 400px; border-left: solid 1px">
                                                    <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("varCompanyName") %>' />
                                                </div>
                                                <hr />
                                            </ItemTemplate>


                                        </cc2:GroupingView>
                                        <br />
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>"
                                            ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>"
                                            SelectCommand="SELECT  intId, varCity,varCompanyName FROM sanghaviunbreakables.tblsucustomer  WHERE varCompanyName!='-- Select Company --'      "></asp:SqlDataSource>
                                    </div>--%>

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
