<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="ViewMessages.aspx.cs" Inherits="Personnel_admin_ViewMessages" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>View Messages</title>

    <!-- BOOTSTRAP STYLES-->
    <link href="../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />  
    <!-- FONTAWESOME STYLES-->
    <link href="../assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="../assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="../assets/css/custom.css" rel="stylesheet" />
       <link href="../assets/css/bootstrap-fileupload.min.css" rel="stylesheet" />
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
     <asp:LinkButton ID="LinkButton1" runat="server"  class="btn btn-danger fa fa-exclamation-circle fa-2x" 
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
                               <asp:Label ID="lblCustName" runat="server" Text="lblAdminName"></asp:Label>
                             </div>
                        </div>
                    </li>
                     <li>
                      <a href="#"><i class="fa fa-asterisk "></i> Product<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level  ">
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
                        <a href="#"  class="active-menu-top"><i class="fa fa-envelope "></i>Messages<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level  collapse in"> <li>
                                <a href="CreateMessage.aspx"><i class="fa fa-pencil "></i>New Message</a>
                            </li>
                          <li>
                                  <a href="ViewMessages.aspx"   class="active-menu"><i class="fa fa-comments"></i>Recieved Messages</a>
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
            <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="col-md-6 col-sm-6">
                 <div class="panel panel-info">

   <div class="panel-heading">
                           View & Reply Messages
                        </div>                      
                        <div class="panel-body">   
                        <div class="table-responsive">
                            <asp:ListView ID="lstMessages" runat="server"    onitemcommand="lstFullMessage_ItemCommand"
                                DataSourceID="SqlDataSourceMessages" DataKeyNames="intId" 
                                onpagepropertieschanging="lstMessages_PagePropertiesChanging"> 
                                 
                                <EmptyDataTemplate>
                                    <table runat="server" style="">
                                        <tr>
                                            <td>
                                                No Messages.</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate> 
                                <ItemTemplate>
                                    <tr style=""> 
                                       <td>
                                            <asp:Label ID="dtDateLabel" runat="server" Text='<%# Eval("dtDate") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="tmTimeLabel" runat="server" Text='<%# Eval("tmTime") %>' />
                                        </td>
                                          <td>
                                            <asp:Label ID="Label1" runat="server" 
                                                Text='<%# Eval("varMessageByName") %>' />
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="varEnquirySubjectLabel" runat="server"  CommandName="Views" CommandArgument='<%#Eval("intId")+","+Eval("varEnquirySubject")%>'
                                                Text='<%# Eval("varEnquirySubject") %>' />
                                        </td>
                                       
                                      <td>
                                           <asp:LinkButton ID="DeleteButton"   CssClass="btn btn-xs btn-danger fa fa-times" runat="server" CommandName="Deletes" CommandArgument='<%#Eval("intId")%>'
                                                ToolTip="Delete" />
                                              <asp:LinkButton ID="EditButton"   CssClass="btn btn-xs btn-success fa fa-reply" runat="server" CommandName="Edits" ToolTip="Reply" CommandArgument='<%#Eval("intId")%>'/>
                                </td>
                                    </tr>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <table runat="server">
                                        <tr runat="server">
                                            <td runat="server">
                                                <table ID="itemPlaceholderContainer" runat="server" border="0"    class=" table table-striped table-bordered table-hover">
                                                    <tr runat="server" style=""> 
                                                        <th runat="server">
                                                            Date</th>
                                                        <th runat="server">
                                                            Time</th> 
                                                           
                                                                <th runat="server">
                                                            Message From</th>
                                                        <th runat="server">
                                                            Subject</th>
                                                         <th runat="server">   
                                                        </th>
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
                           
                            <asp:SqlDataSource ID="SqlDataSourceMessages" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>"   >
                               
                            </asp:SqlDataSource>
                           
                            </div> 
                       
                        </div>
                        </div>
                    </div>
                      <div class="col-md-6 col-sm-6">
                     <div class="panel panel-primary"> 
   <div class="panel-heading">
                           View Full Message
                        </div>  
                          <div class="panel-body">   
                        <div class="table-responsive">
                        <div  >
                        <label> Subject:</label>  <asp:Label ID="lblSubject" runat="server" Text="Message Subject"></asp:Label>
                        
                        </div>
     <asp:ListView ID="lstFullMessage" runat="server" 
                                DataSourceID="SqlDataSourceFull" DataKeyNames="intId" 
                             > 
                                <AlternatingItemTemplate>
                                    <tr style="">
                                        
                                        <td align="left">
                                            <asp:Label ID="nvarMsgFromLabel" runat="server" 
                                                Text='<%# Eval("nvarMsgFrom") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="nvarMsgToLabel" runat="server" Text='<%# Eval("nvarMsgTo") %>' />
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                                 
                                <EmptyDataTemplate>
                                    <table runat="server" style="">
                                        <tr>
                                            <td>
                                                Please Click Message Subject To View</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate> 
                                <ItemTemplate>
                                    <tr style="">
                                         
                                        <td align="left">
                                            <asp:Label ID="nvarMsgFromLabel" runat="server" 
                                                Text='<%# Eval("nvarMsgFrom") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="nvarMsgToLabel" runat="server" Text='<%# Eval("nvarMsgTo") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate> 
                                <LayoutTemplate>
                                    <table runat="server">
                                        <tr runat="server">
                                            <td runat="server">
                                                <table ID="itemPlaceholderContainer" runat="server" border="0"  class=" table table-striped table-bordered table-hover">
                                                    <tr runat="server" style="">
                                                        
                                                        <th runat="server">
                                                         Recieved   </th>
                                                        <th runat="server">
                                                         Sent   </th>
                                                    </tr>
                                                    <tr ID="itemPlaceholder" runat="server">
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
                            <asp:SqlDataSource ID="SqlDataSourceFull" runat="server" 
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

        </div>
             <!--/.ROW--> 
            </div>
            <!-- /. PAGE INNER  --> 
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
