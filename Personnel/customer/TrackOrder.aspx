<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="TrackOrder.aspx.cs" Inherits="Personnel_TrackOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 <html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>Track Order</title>

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
                          <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Personnel/customer/Notification.aspx" CssClass="btn btn-primary fa fa-2x" ToolTip="Notification" runat="server"> </asp:HyperLink>
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
                    </li>   <li>
                        <a href="ViewProduct.aspx"><i class="fa fa-user "></i>View Products</a>
                    </li>
                     <li>
                       <a href="#"><i class="fa fa-asterisk"></i> Order<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level">
                          <li>
                                 <a href="CreateOrder.aspx"><i class="fa fa-cubes"></i>Create Order</a>
                            </li>
                            <li>
                            <a href="ViewOrder.aspx"><i class="fa fa-eye"></i>View Orders</a>
                            </li>
                            </ul>
                    </li> 
                    <li>
                        <a href="#"><i class="fa fa-envelope "></i>Messages<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level">
                          <li>
                                <a href="AddEnquiry.aspx"><i class="fa fa-pencil"></i>New Message</a>
                            </li>
                            <li>
                                <a href="ViewConversation.aspx"><i class="fa fa-comment"></i>View Messages</a>
                            </li>
                              <li>
                                <a href="ViewSentMessages.aspx"><i class="fa fa-inbox"></i>Sent Messages</a>
                            </li>
                           
                        </ul>
                    </li> 
                   
                    <li>
                           <a class="active-menu" href="TrackOrder.aspx"><i class="fa fa-map-marker "></i>Track Consignment</a>
                    </li>
                     
                    <li>
                        <a  href="Notification.aspx"><i class="fa fa-bell "></i>Notification</a>
                    </li>
                     
                    <li>
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogout_Click"   ><i class="fa fa-sign-out "></i>Logout</asp:LinkButton>   
                    </li>
                </ul>
            </div>

        </nav>
        <!-- /. NAV SIDE  -->
        <div id="page-wrapper">
            <div id="page-inner"> 
                <!-- /. ROW  -->
                <div class="row">
             <div class="col-md-12 col-sm-12 col-xs-12">
               <div class="panel panel-info">
                        <div class="panel-heading">
                      Track Consignment
                        </div>
                        <div class="panel-body">
                           
                                   <div class="form-group"> 
                   <asp:Label ID="lblEnqBy" runat="server" Text="Enter Consignment No."></asp:Label>   
                <asp:TextBox ID="txtConsignmentNo" runat="server" class="form-control" 
                 placeholder="Consignment No."></asp:TextBox>
                    </div> 
 
   <div class="form-group"> 
  <asp:Button ID="btnTrack" runat="server" Text="TRACK" class="btn btn-success"   
           onclick="btnTrack_Click"></asp:Button>
                               &nbsp;&nbsp; &nbsp;&nbsp;
                                     <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-warning"></asp:Button>
   </div> 
                            
                          <div class="col-md-10 col-sm-10">
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
                                        </td> <td>
                                            <asp:Label ID="OrderNoLabel" runat="server" Text='<%# Eval("OrderNo") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="CustomerLabel" runat="server" 
                                                Text='<%# Eval("Customer") %>' />
                                        </td>
                                          
                                       
                                        <td>
                                            <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                                        </td> 
                                              <td>
                                             <asp:Label ID="Label1" runat="server" Text='<%# Eval("Transport") %>' />
                                         </td>
                                        <td>
                                            <asp:Label ID="StatusLabel" runat="server" 
                                                Text='<%# Eval("Status") %>' />
                                        </td>
                                         <td>
                                             <asp:LinkButton ID="lnkViewFull" CommandName="View" CommandArgument='<%#Eval("ConsNo") %>' runat="server" ToolTip="View Bill" CssClass="fa fa-eye btn btn-xs btn-info"></asp:LinkButton>
                                             
                                       </td>
                                    </tr>
                                </AlternatingItemTemplate>  
                                
                                 <ItemTemplate>
                                    <tr style="">
                                        <td>
                                            <asp:Label ID="ConsNoLabel" runat="server" 
                                                Text='<%# Eval("ConsNo") %>' />
                                        </td><td>
                                            <asp:Label ID="OrderNoLabel" runat="server" Text='<%# Eval("OrderNo") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="CustomerLabel" runat="server" Text='<%# Eval("Customer") %>' />
                                        </td> 
                                         
                                         
                                         <td>
                                             <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                                         </td>
                                         <td>
                                             <asp:Label ID="Label1" runat="server" Text='<%# Eval("Transport") %>' />
                                         </td>
                                        <td>
                                            <asp:Label ID="StatusLabel" runat="server" 
                                                Text='<%# Eval("Status") %>' />
                                        </td>
                                          <td>
                                             <asp:LinkButton ID="lnkViewFull" CommandName="View" CommandArgument='<%#Eval("ConsNo") %>' runat="server" ToolTip="View Bill" CssClass="fa fa-eye btn btn-xs btn-info"></asp:LinkButton>
                                          
                                       </td>
                                    </tr>
                                </ItemTemplate> 
                                 
                                <EmptyDataTemplate>
                                    <table id="Table1" runat="server" style="">
                                        <tr>
                                            <td>
                                                No data was returned.</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                 
                                
                                <LayoutTemplate>
                                    <table id="Table2" runat="server">
                                        <tr id="Tr1" runat="server">
                                            <td id="Td1" runat="server">
                                                <table ID="itemPlaceholderContainer" runat="server" border="0" class="table table-bordered table-condensed table-responsive">
                                                    <tr id="Tr2" runat="server" style="">
                                                        <th id="Th1" runat="server">
                                                            ConsNo</th>
                                                                <th id="Th4" runat="server">
                                                            OrderNo</th>
                                                        <th id="Th2" runat="server">
                                                            Customer</th>
                                                      
                                                    
                                                        <th id="Th5" runat="server">
                                                            Date</th>
                                                             <th id="Th3" runat="server">
                                                            Transport</th>
                                                        <th id="Th6" runat="server">
                                                            Status</th>
                                                               <th id="Th7" runat="server">
                                                            Operation</th>
                                                    </tr>
                                                    <tr runat="server" ID="itemPlaceholder">
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="Tr3" runat="server">
                                            <td id="Td2" runat="server" style="">
        
                                            </td>
                                        </tr>
                                    </table>
                                </LayoutTemplate> 
                                 
                                
                                 
                            </asp:ListView>
                             
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server"  
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>"  
                                
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                  >
                                
                            </asp:SqlDataSource>
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