<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="CreateMessage.aspx.cs" Inherits="Personnel_admin_CreateMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>Create Message</title>

    <!-- BOOTSTRAP STYLES-->
    <link href="../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />  
    <!-- FONTAWESOME STYLES-->
    <link href="../assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
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
     <asp:LinkButton ID="lnkLogoutUp" runat="server"  class="btn btn-danger fa fa-exclamation-circle fa-2x"  CausesValidation="False"
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
                      <a href="#" class="active-menu-top"><i class="fa fa-envelope "></i>Messages<span class="fa arrow"></span></a>
                       
                         <ul class="nav nav-second-level collapse in"> <li>
                                <a href="CreateMessage.aspx" class="active-menu"><i class="fa fa-pencil "></i>New Message</a>
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
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogoutUp_Click"   CausesValidation="False"><i class="fa fa-sign-out "></i>Logout</asp:LinkButton>   
                    </li>
                </ul>
            </div>

        </nav>
        <!-- /. NAV SIDE  -->
        <div id="page-wrapper">
            <div id="page-inner"> 
                <!-- /. ROW  -->
                 <div class="row">
                  <div class="col-md-6">                     
         <div class="panel panel-info">
                        <div class="panel-heading">
               Create Message
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


  <asp:Button ID="btnSend" runat="server" Text="SEND" class="btn btn-success"  OnClientClick="return Confirm();" onclick="btnSend_Click"></asp:Button>
                               &nbsp;&nbsp; &nbsp;&nbsp;
                                     <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                class="btn btn-warning" onclick="btnCancel_Click" CausesValidation="False"></asp:Button>
                            </div>
                        </div>
                    </div>
                 </div>
             
             <div class="col-md-6">                     
         <div class="panel panel-info">
                <div class="panel-heading">
                Today's Birthdays
                </div> 
                      <div class="panel-body"> 
                      <div class="table-responsive">
                          <asp:ListView ID="lstBirthdays" runat="server" 
                              DataSourceID="SqlDataSourceBirthdays"> 
                              <EmptyDataTemplate>
                                  <table runat="server" style="">
                                      <tr>
                                          <td>
                                              No data was returned.</td>
                                      </tr>
                                  </table>
                              </EmptyDataTemplate>
                                
                              <ItemTemplate>
                                  <tr style="">
                                      <td>
                                          <asp:Label ID="Company_NameLabel" runat="server" 
                                              Text='<%# Eval("[Company Name]") %>' />
                                      </td>
                                      <td>
                                          <asp:Label ID="Representative_NameLabel" runat="server" 
                                              Text='<%# Eval("[Representative Name]") %>' />
                                      </td>
                                      <td>
                                          <asp:Label ID="DesignationLabel" runat="server" 
                                              Text='<%# Eval("Designation") %>' />
                                      </td>
                                      <td>
                                          <asp:Label ID="ContactLabel" runat="server" Text='<%# Eval("Contact") %>' />
                                      </td>
                                     
                                  </tr>
                              </ItemTemplate>
                              <LayoutTemplate>
                                  <table runat="server">
                                      <tr runat="server">
                                          <td runat="server">
                                              <table ID="itemPlaceholderContainer" runat="server" border="0" class="table table-striped table-bordered table-hover">
                                                  <tr runat="server" style="">
                                                      <th runat="server">
                                                          Company Name</th>
                                                      <th runat="server">
                                                          Representative Name</th>
                                                      <th runat="server">
                                                          Designation</th>
                                                      <th runat="server">
                                                          Contact</th>                                                     
                                                  </tr>
                                                  <tr ID="itemPlaceholder" runat="server">
                                                  </tr>
                                              </table>
                                          </td>
                                      </tr>
                                      <tr runat="server">
                                          <td runat="server" style="">
                                              <asp:DataPager ID="DataPager1" runat="server">
                                                  <Fields>
                                                      <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                                          ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                      <asp:NumericPagerField />
                                                      <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                                          ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                  </Fields>
                                              </asp:DataPager>
                                          </td>
                                      </tr>
                                  </table>
                              </LayoutTemplate>
                               
                          </asp:ListView>
                          <asp:SqlDataSource ID="SqlDataSourceBirthdays" runat="server" 
                              ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                              ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                              SelectCommand="SELECT tblsucustomer.varCompanyName AS `Company Name`, tblsucustomerotherdetails.varRepName AS `Representative Name`, tblsucustomerotherdetails.varDesignation AS Designation, tblsucustomerotherdetails.varContact AS Contact, tblsucustomerotherdetails.varDOB FROM tblsucustomer INNER JOIN tblsucustomerotherdetails ON tblsucustomer.intId = tblsucustomerotherdetails.intCustId  WHERE SUBSTRING(tblsucustomerotherdetails.varDOB,1,5) = SUBSTRING(DATE_FORMAT(CURRENT_DATE(),'%d-%m-%Y'),1,5)">
                          </asp:SqlDataSource>
                      </div>
                      </div>
                </div></div>
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
    <script src="../assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="../assets/js/bootstrap.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="../assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="../assets/js/custom.js"></script>

</body>
</html>
