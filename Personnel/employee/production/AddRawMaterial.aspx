<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddRawMaterial.aspx.cs" Inherits="Personnel_employee_production_AddRawMaterial" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 <html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>Add Raw Material</title>

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
                           <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Personnel/employee/production/Notification.aspx" CssClass="btn btn-primary fa fa-2x" ToolTip="Notification" runat="server"> </asp:HyperLink>
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
                    </li>
                   
                      <li>
                        <a href="#" class="active-menu"><i class="fa fa-plus-circle "></i> Stock<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level collapse in">
                             <li>
                                 <a class="active-menu-top" href="AddRawMaterial.aspx" ><i class="fa fa-paper-plane"></i>Add New Material </a>
                            </li>   
                           <li>
                                 <a  href="UpdateRawMaterial.aspx" ><i class="fa fa-paper-plane"></i>Inward Raw Material</a>
                            </li>       
                                <li>
                               <a href="CreateStock.aspx"><i class="fa fa-cubes"></i>Create Stock</a>
                            </li>
                                     <li>
                               <a href="InwardStock.aspx"><i class="fa fa-cubes"></i>Inward Stock</a>
                            </li>      <li>
                               <a   href="Scrap.aspx"><i class="fa fa-cubes"></i>Scrap</a>
                            </li>         
                              <li>
                               <a   href="ViewStock.aspx" ><i class="fa fa-cubes"></i>View Stock</a>
                            </li>             
                            </ul>
                    </li>      <li>
                        <a  href="ViewJalgaonOrder.aspx"><i class="fa fa-user "></i>View Jalgaon Order</a>
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
                        <a  href="Notification.aspx" ><i class="fa fa-bell "></i>Notification</a>
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
                 <div class="col-md-4 col-sm-4 ">
               <div class="panel panel-info">
                        <div class="panel-heading">
                        Add Raw Material  
                    </div>
                   <div class="panel-body"> 
                     <div role="form">
                       <div class="form-group" align="right">    <asp:Label ID="Label1" runat="server" Text="Date:"></asp:Label>  <asp:Label ID="lbldate" runat="server" ></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text="Time:"></asp:Label> <asp:Label ID="lbltime"   runat="server" ></asp:Label></div>
                          <div class="form-group" >
                               <asp:TextBox ID="txtname" required runat="server" placeholder="Raw Material Name" class="form-control"    ></asp:TextBox> 
                               </div>    
                            <div class="form-group">  
                               <asp:TextBox ID="txtWarningTon" required runat="server" 
                                    placeholder="Warning Ton"    class="form-control" AutoPostBack="True" 
                                    ontextchanged="txtWarningTon_TextChanged" ></asp:TextBox>
                          </div>   
                              <div class="form-group">  
                               <asp:TextBox ID="txtWarningKg" required runat="server" 
                                      placeholder="Warning Kilo"    class="form-control" AutoPostBack="True" 
                                      ontextchanged="txtWarningKg_TextChanged" ></asp:TextBox>
                          </div>   
                            <div class="form-group"> 
                             <asp:TextBox ID="txtremark" required runat="server" placeholder="Remark" class="form-control" ></asp:TextBox>
                              </div> 
                                                
                                                 <div class="form-group">
                                                     <asp:Button ID="btnAddToOrder" runat="server" Text="Add"     OnClientClick="return Confirm();" 
                                                         CssClass="btn btn-info" onclick="btnAddToOrder_Click" />
                                                     &nbsp;<asp:LinkButton ID="btnReset" runat="server" Text="Reset" 
                                                         CssClass="btn btn-danger" onclick="btnReset_Click" 
                                                        />
                                               </div> 
                                </div>

                       </div>

        </div>
             <!--/.ROW--> 

            </div>
             <div class="col-lg-8 col-sm-8">
                                      
                                                    <div class="panel panel-info">
                        <div class="panel-heading">
                         View Raw Material
                        </div>
                        <div class="panel-body">
                          
                                                    <div class="table-responsive">
                                  <asp:GridView ID="grdStockJalgaon" runat="server"
                                                            CssClass="table table-bordered table-responsive" DataSourceID="SqlDatarow" 
                                    AllowPaging="True" AutoGenerateColumns="False"                                      
                                     >
                                         <Columns> 
                                             <asp:BoundField DataField="Name" HeaderText="Name" 
                                            SortExpression="Name" /> 
                                             
                                        <asp:BoundField DataField="WeightKg" HeaderText="Weight(Kg)" 
                                            SortExpression="WeightKg" />
                                        <asp:BoundField DataField="WeightTon" HeaderText="Weight(Ton)" 
                                            SortExpression="WeightTon" />
                                    </Columns>
                                </asp:GridView>                                  
                                                        <asp:SqlDataSource ID="SqlDatarow" runat="server" 
                                                            ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                                            ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                                            
                                                           SelectCommand="SELECT DISTINCT varName AS Name,  CONCAT(varWeightKg, ' ', varUnitKg) AS `WeightKg`, CONCAT(varWeightTon, ' ', varUnitTon) AS `WeightTon` FROM sanghaviunbreakables.tblrawmaterial">
                                                        </asp:SqlDataSource>
                                  
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
    <script src="../../assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="../../assets/js/bootstrap.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="../../assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="../../assets/js/custom.js"></script>

</body>
</html>