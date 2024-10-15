<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllocateDistrict.aspx.cs" Inherits="Personnel_employee_subadmin_AllocateDistrict" %>

<%@ Register Assembly="GroupingView" Namespace="UNLV.IAP.WebControls" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title> Allocate District   </title>

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
</head>
<body>
    <form id="form1" runat="server">
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
                        <a href="EditProfile.aspx"><i class="fa fa-user "></i>Edit Profile</a>
                    </li>
              <li>
                        <a href="#"><i class="fa fa-plus-circle "></i> Stock<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                                <a href="RecieveStockJalgaon.aspx"><i class="fa fa-share"></i>Recieve Verkhedi Stock</a>
                            </li>
                            <li>
                                <a href="ViewStock.aspx"><i class="fa fa-pencil-square-o"></i>View stock</a>
                            </li>   <li>
                                <a href="Rejection.aspx" ><i class="fa fa-pencil-square-o"></i>Rejection</a>
                            </li>
                            </ul>
                    </li>     
                     <li>
                        <a href="#" ><i class="fa fa-plus-circle "></i> Order<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level">
                          <li>
                                <a href="CreateOrder.aspx" ><i class="fa fa-share"></i>Create Order</a>
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
                           <a  href="AllocateDistrict.aspx" class="active-menu"><i class="fa fa-map-marker "></i>Allocate District</a>
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
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogoutUp_Click"  ><i class="fa fa-sign-out "></i>Logout</asp:LinkButton>   
                    </li>
                </ul>
            </div>

        </nav>
             <!-- /. NAV SIDE  -->

               <div id="page-wrapper">
             <div id="page-inner">
                 
                <div class="row">
            <div class="col-md-12 ">
  <div class="panel panel-info">
                        <div class="panel-heading">
                        Allocate District 
                        <%-- <asp:Label ID="lblOrderNo" runat="server" Text="Order No."></asp:Label>--%>
                    </div>
                   <div class="panel-body"> 
                                <div class="row">   
                                <div class="col-md-12 col-sm-12"> 
                        <div class="panel-body">  
                       <div class="col-md-6 col-sm-6">
                     <div class="form-group">
                        <%-- Select Country--%>
                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control"   
                                             DataSourceID="SqlDataSource2" DataTextField="Country" 
                                                 DataValueField="Country" AppendDataBoundItems="true"
                                            
                                             AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" >
                                              <asp:ListItem Text="-- Select Country --" />
                                        <asp:ListItem>India</asp:ListItem>                                    
                                </asp:DropDownList><br /><asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>"></asp:SqlDataSource>

                      



                         <%-- Select State--%>
                          <asp:DropDownList ID="ddlstate" runat="server" 
                         AutoPostBack="True" 
                         CssClass="form-control" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                        <asp:ListItem>--Select State--</asp:ListItem>
                       <asp:ListItem>Andhra Pradesh</asp:ListItem>
                                    <asp:ListItem>Arunachal Pradesh</asp:ListItem>
                                    <asp:ListItem>Assam</asp:ListItem>
                                    <asp:ListItem>Bihar</asp:ListItem>
                                    <asp:ListItem>Chattisgardh</asp:ListItem>
                                    <asp:ListItem>Goa</asp:ListItem>
                                    <asp:ListItem>Gujarat</asp:ListItem>
                                    <asp:ListItem>Haryana</asp:ListItem>
                                    <asp:ListItem>Himachal Pradesh</asp:ListItem>
                                    <asp:ListItem>Jammu and Kashmir</asp:ListItem>
                                    <asp:ListItem>Jharkhand</asp:ListItem>
                                    <asp:ListItem>Karnataka</asp:ListItem>
                                    <asp:ListItem>Kerala</asp:ListItem>
                                    <asp:ListItem>Madhya Pradesh</asp:ListItem>
                                    <asp:ListItem>Maharashtra</asp:ListItem>
                                    <asp:ListItem>Manipur</asp:ListItem>
                                    <asp:ListItem>Meghalaya</asp:ListItem>
                                    <asp:ListItem>Mizoram</asp:ListItem>
                                    <asp:ListItem>Nagaland</asp:ListItem>
                                    <asp:ListItem>Orissa</asp:ListItem>
                                    <asp:ListItem>Punjab</asp:ListItem>
                                    <asp:ListItem>Rajastan</asp:ListItem>
                                    <asp:ListItem>Sikkim</asp:ListItem>
                                    <asp:ListItem>Tamil Nadu</asp:ListItem>
                                    <asp:ListItem>Tripura</asp:ListItem>
                                    <asp:ListItem>Uttar Pradesh</asp:ListItem>
                                    <asp:ListItem>Uttarakhand</asp:ListItem>
                                    <asp:ListItem>West Bengal</asp:ListItem>
                    </asp:DropDownList><br />

                           <asp:DropDownList ID="ddlDistrict" runat="server" 
                         AutoPostBack="True" 
                         CssClass="form-control">
                                  <asp:ListItem>--Select District--</asp:ListItem>
                           </asp:DropDownList><br />

                         <asp:Button ID="btnAdd"  class="btn btn-warning"  runat="server" Text="Add" OnClick="btnAdd_Click"  OnClientClick="return Confirm();"/>
                       &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Reset" class="btn btn-danger " OnClick="btnCancel_Click"   /><br />
                           </div>
                            </div>

                            <div class="col-md-6 col-sm-6">  
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlRegionalhead" runat="server" CssClass="form-control" AppendDataBoundItems="true"  AutoPostBack="true" 
                                         OnSelectedIndexChanged="ddlRegionalhead_SelectedIndexChanged">   
                                         <asp:ListItem>--Select Regional Head--</asp:ListItem>                                                                                                             
                            </asp:DropDownList><br />

                                <asp:DropDownList ID="ddlStateHead" runat="server" CssClass="form-control"  AppendDataBoundItems="true"  AutoPostBack="true" 
                                           OnSelectedIndexChanged="ddlStateHead_SelectedIndexChanged" >    
                                     <asp:ListItem>--Select State Head--</asp:ListItem>                                                                                                         
                            </asp:DropDownList><br />

                                        <asp:DropDownList ID="ddlDistricthead" runat="server" CssClass="form-control" AppendDataBoundItems="true"    AutoPostBack="true"   >
                                                  <asp:ListItem>--Select District Head--</asp:ListItem>                                                         
                            </asp:DropDownList><br />
                                    </div>
                                </div>

                                    </div>

                                    </div>
                       </div>
                       <div class="row">
                             <div class="col-lg-12">
                                        <cc2:GroupingView ID="GroupingView1" runat="server" GroupingDataField="varEmpName"  >

                                <GroupTemplate>
                                          <div class="col-md-12">
                                              <br />
                                         <h4><asp:Label ID="lblRegion" runat="server" Text='<%# Eval("varEmpName") %>' /></h4>
                                            <div class="bordex"></div>       </div> 
                                                
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />   
                            </GroupTemplate> 
                                     <ItemTemplate>
                                         <div class="col-md-4">
                                        <asp:Label ID="lblDistrictname" runat="server" Text='<%# Eval("varDistrict") %>' />
                                       <div class="bordexs"></div>  </div>
                                     </ItemTemplate>                                                 

                            </cc2:GroupingView>                                             
                                          
                                            
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
    <script src="../../assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="../../assets/js/bootstrap.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="../../assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="../../assets/js/custom.js"></script>
    
</body>
</html>
