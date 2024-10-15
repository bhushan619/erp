<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="AddEmp.aspx.cs" Inherits="Personnel_admin_AddEmp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>  Add Employee </title>

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
                               <asp:Label ID="lblCustName" runat="server" Text="lbladminName"></asp:Label>
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
                       <a href="#" class="active-menu-top"><i class="fa fa-smile-o "></i>Employee<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level collapse in ">
                          <li>
                                <a href="AddEmp.aspx" class="active-menu"><i class="fa fa-user "></i>Add Employee</a>
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
                     Add Employee
                        </div>
                        <div class="panel-body">
                               <div class="col-md-6  col-sm-6">
                                <div class="form-group">
                                           <asp:Label runat="server"> Name</asp:Label>
                                           <asp:TextBox ID="txtEmpName" runat="server" class="form-control" 
                                                  ></asp:TextBox>                                           
                                        </div>                                
                                        <div class="form-group">
                                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                           <asp:Label runat="server">Mobile</asp:Label>
                                           <asp:TextBox ID="txtMobile" runat="server" class="form-control" 
                                                pattern="[7-9]{1}[0-9]{9}"  ></asp:TextBox>                                          
                                        </div>

                                      <div class="form-group">
                                           <asp:Label runat="server">Date Of Birth</asp:Label>
                                            <asp:TextBox ID="txtDob" runat="server" class="form-control" ></asp:TextBox>
                                             <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtDOb_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDob"  
                                    PopupPosition="Right" >
                                </cc1:CalendarExtender>
                                            
                                        </div>                    
                            <div class="form-group">
                                  <asp:Label runat="server">Address</asp:Label>
                                     <asp:TextBox ID="txtADD" runat="server" 
                                       class="form-control"    ></asp:TextBox>
                            </div>
                                 <div class="form-group">
                            <asp:Label runat="server">State </asp:Label>
                                <asp:DropDownList ID="cmbstate" runat="server" 
                        onselectedindexchanged="state_SelectedIndexChanged" AutoPostBack="True" 
                         CssClass="form-control">
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
                    </asp:DropDownList>
                                </div>   
                         
                            <div class="form-group">
                                  <asp:Label runat="server">City</asp:Label>
                                <asp:DropDownList ID="cmbcity" runat="server"    class="form-control" >
                                <asp:ListItem>--Select City--</asp:ListItem>
                                </asp:DropDownList> 
                                </div>
                                <div class="form-group">
                                  <asp:Label runat="server"> Designation</asp:Label>
                                <asp:DropDownList ID="cmbSubDesig" runat="server"    class="form-control" >
                                <asp:ListItem>--Select Designation--</asp:ListItem>
                                <asp:ListItem>Sub Admin</asp:ListItem>
                                <asp:ListItem>Marketing Head</asp:ListItem>
                                 <asp:ListItem>Marketing Executive</asp:ListItem> 
                                    <asp:ListItem>Dispatch</asp:ListItem>
                                    <asp:ListItem>Inventory</asp:ListItem> 
                                    <asp:ListItem>Production</asp:ListItem>
                                </asp:DropDownList> 
                                </div>
                          
                                   
                            
                            </div>  
                         <div class="col-md-6  col-sm-6">
                       
                             <div class="form-group">
                                           <asp:Label runat="server">Email</asp:Label>
                                            <asp:TextBox ID="txtMail"  
                             pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)" 
                             runat="server"  Required  class="form-control" 
                           ></asp:TextBox>
                                          
                                        </div>  
                                         
                               <div class="form-group">
                                           <asp:Label runat="server">Password</asp:Label>
                            <asp:TextBox ID="txtPasswd" runat="server"  
                             TextMode="Password"  required="required" class="form-control" 
                           ></asp:TextBox>
                           </div> 
                                <div class="form-group">
                                           <asp:Label runat="server">ID Proof</asp:Label>
                                            <asp:TextBox ID="txtIdproof" runat="server" class="form-control" ></asp:TextBox>
                                            
                                        </div>
                                        <div class="form-group">
                                           <asp:Label runat="server">ID Proof No.</asp:Label>
                                                 <%-- <input class="form-control" type="text">--%>
                                            <asp:TextBox ID="txtIdproofNo" runat="server" class="form-control" 
                                                  ></asp:TextBox>
                                           
                                        </div>
                                          <div class="form-group">
                                           <asp:Label runat="server">Pan No.</asp:Label>
                                            <asp:TextBox ID="txtPAN" runat="server" class="form-control" ></asp:TextBox>
                                            
                                        </div>
                                        <div class="form-group">
                      <asp:Label ID="Label7" runat="server" Text="Image Upload"  ></asp:Label>
                        <div class="">
                            <div class="fileupload fileupload-new" data-provides="fileupload"> 
                                <div>
                                    <span class="btn btn-file btn-success">
                                    <span class="fileupload-new">Select image</span>
                                <input ID="fupProPic" type="file" name="file" onchange="previewFile()"  runat="server" accept='image/*' /></span>
                                     <asp:Image ID="ImgProduct" CssClass="fileupload-preview thumbnail" style="width: 200px; height: 150px;float:none"  runat="server" ImageUrl="~/Personnel/admin/media/NoProfile.png" />
                                <script type="text/javascript">
                                    function previewFile() {

                                        var preview = document.querySelector('#<%=ImgProduct.ClientID %>');
                                        var file = document.querySelector('#<%=fupProPic.ClientID %>').files[0];
                                        var reader = new FileReader();

                                        reader.onloadend = function () {
                                            preview.src = reader.result;
                                        }

                                        if (file) {
                                            reader.readAsDataURL(file);
                                        } else {
                                            preview.src = "";
                                        }
                                    } 
                              </script>  
                                </div>
                            </div>
                        </div>
                    </div>
                                        
    
    <div class="form-group">
                              &nbsp;&nbsp;&nbsp; <asp:Button ID="btnAdd"  runat="server" 
                                                    Text="Add" class="btn btn-warning" onclick="btnAdd_Click"   OnClientClick="return Confirm();"
                                                  />
                                                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                                  class="btn btn-danger " onclick="btnCancel_Click" />
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

