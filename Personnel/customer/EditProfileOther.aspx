<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditProfileOther.aspx.cs" Inherits="Personnel_customer_EditProfileOther" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>Customer Profile</title>

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
                        <a class="active-menu" href="EditProfile.aspx"><i class="fa fa-user "></i>Edit Profile</a>
                    </li>
                      <li>
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
                           <a  href="TrackOrder.aspx"><i class="fa fa-map-marker "></i>Track Consignment</a>
                    </li>
                     
                    <li>
                        <a  href="Notification.aspx"><i class="fa fa-bell "></i>Notification</a>
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
         <div class="panel panel-primary">
                        <div class="panel-heading">
                      Edit Profile
                        </div>
                       <div class="panel-body">
                            <ul class="nav nav-tabs">
                                <li class=""><a href="EditProfile.aspx"  >Edit/Update Main Details</a>
                                </li>
                                <li class="active"><a href="#">Edit/Update Other Details</a>
                                </li> 
                            </ul>

                              <div class="tab-content">
                                <div class="tab-pane fade active in" > 
                                     <div class="col-md-4  col-sm-4">
                                  
                                <div class="form-group">
                                            <label>Representative  Name</label>
                                           <asp:TextBox ID="txtRepName" runat="server" class="form-control" 
                                           required     placeholder="Representative Name"  ></asp:TextBox>
                                          
                                        </div> 
                                         <div class="form-group">
                                            <label>Designation/Relation</label>
                                           <asp:TextBox ID="txtDesig" runat="server" class="form-control" 
                                             required   placeholder="Designation/Relation"  ></asp:TextBox>
                                           
                                        </div>
                                        <div class="form-group">
                                            <label>Contact</label>
                                           <asp:TextBox ID="txtContact" runat="server" class="form-control" 
                                              required  placeholder="Contact"  onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"  ></asp:TextBox>
                                          
                                        </div>
                                         <div class="form-group">
                                          <label>Date of Birth</label>
                                           <asp:TextBox ID="txtDOB" runat="server"  class="form-control" placeholder="Date of Birth"></asp:TextBox>
                                        <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOET_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDOB"  
                                    PopupPosition="Right" >
                                </cc1:CalendarExtender>
                                        </div>
                                         <div class="form-group">
                                            <label>Remark</label>
                                           <asp:TextBox ID="txtRemark" runat="server" class="form-control" 
                                              required  placeholder="Remark"   ></asp:TextBox>
                                          
                                        </div>
                                          <div class="form-group">
                               <asp:Button ID="btnUpdate" OnClientClick="return Confirm();"  runat="server" Text="Update" class="btn btn-warning" onclick="btnUpdate_Click" 
                                                  />
                                                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                                  class="btn btn-danger " onclick="btnCancel_Click" />
                                        </div> 
                                                                 </div>
                           <div class="col-md-8 col-sm-8">
                            <div class="table-responsive">

                                <asp:GridView ID="grdCustomerOtherDetails" runat="server" 
                                    CssClass=" table table-striped table-bordered table-hover" 
                                    DataSourceID="SqlDataSourceCustOther" AllowPaging="True"  onrowcommand="grdOrderDetails_RowCommand" 
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="varRepName" HeaderText="Name" 
                                            SortExpression="varRepName" />
                                        <asp:BoundField DataField="varDesignation" HeaderText="Designation/Relation" 
                                            SortExpression="varDesignation" />
                                        <asp:BoundField DataField="varContact" HeaderText="Contact" 
                                            SortExpression="varContact" />
                                        <asp:BoundField DataField="varDOB" HeaderText="DOB" 
                                            SortExpression="varDOB" />
                                     <asp:TemplateField>
   <ItemTemplate>
   <asp:LinkButton ID="Button2" runat="server" Text="" CommandName="remove" 
   CommandArgument='<%# Eval("intId") %>' CssClass="btn btn-xs btn-danger fa fa-times" />
   </ItemTemplate>
   </asp:TemplateField>
                                           
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceCustOther" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                    ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>"  
                                    SelectCommand="SELECT intId,varRepName, varDesignation, varContact, varDOB FROM tblsucustomerotherdetails WHERE (intCustId = @cust)"> 
                             
                               <SelectParameters>
                               <asp:SessionParameter Name="cust" DbType="Int64" SessionField="custid" />
                               </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
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