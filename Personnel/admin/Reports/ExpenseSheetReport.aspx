<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExpenseSheetReport.aspx.cs" Inherits="Personnel_admin_Reports_ExpenseSheetReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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
               if (confirm("Do you want to add/update/delete Expense Sheet?")) {
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
        <div id="page-wrapper">
            <div id="page-inner"> 
                <!-- /. ROW  -->
                 <div class="row">
                  <div class="col-lg-12 col-sm-12">                     
          <div class="panel panel-info">
                        <div class="panel-heading">
             Expense Sheet Report 
                        </div>
                        <div class="panel-body">
                        <div class="row">   
                            <div role="form"> 
                                  <div class="col-lg-3 col-sm-3">
                           <div class="form-group">
                                  <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control" 
                                      DataSourceID="SqlDataSourceEmp"  DataTextField="varName" AppendDataBoundItems="true"
                                                 DataValueField="varName" >
                                                 <asp:ListItem>-Select Employee-</asp:ListItem>
                                  </asp:DropDownList>
                                  <asp:SqlDataSource ID="SqlDataSourceEmp" runat="server" 
                                      ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                      ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                     > 
                                  </asp:SqlDataSource>
                              </div>
                                      </div>
                                         <div class="col-lg-3 col-sm-3">
                           <div class="form-group">
                              
                               <asp:TextBox ID="txtFromDate" placeholder="From Date" runat="server" required CssClass="form-control"></asp:TextBox>
                                  <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtFromDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtFromDate" >
                                </cc1:CalendarExtender>
                             </div>   </div>
                                 <div class="col-lg-3 col-sm-3">
                               <div class="form-group">
                              
                            <asp:TextBox ID="txtToDate" placeholder="To Date"  runat="server" required CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender  Format="dd-MM-yyyy" ID="txtToDate_CalendarExtender1" runat="server" 
                                    Enabled="True" TargetControlID="txtToDate" >
                                </cc1:CalendarExtender>
                            </div>   </div>
                                <div class="col-lg-3 col-sm-3">
                                   
                            <div class="form-group">
                                <asp:Button ID="btnview" runat="server" Text="View"  OnClick="btnview_Click" CssClass="btn btn-primary"/>
                                <a class="btn btn-danger" href="Collection.aspx" >Reset</a>
                                <a class="btn btn-warning" href="../Report.aspx" >Back</a>
                            </div></div>
                          </div> 
                          </div>
                          <div class="row">
<div class="col-lg-3 col-sm-3 ">  
                           <asp:LinkButton ID="btnExportSale" runat="server" OnClick="btnExportSale_Click" CssClass=" btn btn-success" Text="Export In Excel"  CausesValidation="False" />   
                       
                      

                               <div class="table">
                                  <asp:GridView ID="grdReport" runat="server" 
                                      CssClass="table table-bordered"  AutoGenerateColumns="false" OnRowCommand="grdView_RowCommand"  PageSize="15">
                                       <Columns>
                                     <asp:BoundField HeaderText="intId" DataField="intId" />
                                      <asp:BoundField HeaderText="Start Date" DataField="Start Date" />
                                         <asp:BoundField HeaderText="End Date" DataField="End Date" />
                                         <asp:BoundField HeaderText="Location" DataField="Location" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>Edit</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton CssClass=" fa fa-eye btn btn-sm btn-primary" ID="aa" CommandArgument='<%# Eval("intId") %>' CommandName="view" runat="server"></asp:LinkButton>
                                              <asp:LinkButton CssClass=" fa fa-edit btn btn-sm btn-warning" ID="LinkButton2" CommandArgument='<%# Eval("intId") %>' CommandName="edits" runat="server"></asp:LinkButton>
                                            <asp:LinkButton CssClass=" fa fa-times btn btn-sm btn-danger" ID="LinkButton1" CommandArgument='<%# Eval("intId") %>'  OnClientClick="return Confirm();"  CommandName="deletes" runat="server"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                  <EmptyDataTemplate>No Details Added</EmptyDataTemplate>
                                  </asp:GridView> 
                            </div>
                              
                            <asp:HiddenField ID="hdnMsgAlert" runat="server" Value="Do you want to confirm delete?" />
                        </div>
                              <div class="col-lg-9">
                                  <div class="panel-body">
                
                     
                   <div class="row">
 <div class="col-md-4 col-sm-4">
                        <div class="form-group"> 
                           <asp:TextBox ID="txtFDate" ReadOnly="true" CssClass="form-control" runat="server" required placeholder="Select Date"></asp:TextBox>
                           
                  </div></div>
      <div class="col-md-4 col-sm-4">
                        <div class="form-group"> 
                           <asp:TextBox ID="txtTDate"  ReadOnly="true" CssClass="form-control" runat="server" required placeholder="Select Date"></asp:TextBox>
                            
                  </div></div>
           <div class="col-md-4 col-sm-4">
                   <div class="form-group"> 
                           <asp:TextBox ID="txtLocation"  ReadOnly="true" CssClass="form-control" runat="server" required placeholder="Location"></asp:TextBox>
                           </div>
                            </div> 
                            
                   </div> 
                     <div class="row"> 
                           
                           <div class=" col-lg-12"> 
                              <div style="overflow-y: hidden;">
                                  <asp:GridView ID="grdSheetDetails" AutoGenerateColumns="false"  OnRowDataBound="grdSheetDetails_RowDataBound" ShowFooter="true" runat="server" CssClass="table table-bordered" >
                                     <Columns> 
                                         <asp:BoundField HeaderText="Date" DataField="Date" />
                                         <asp:BoundField HeaderText="Place" DataField="Place" />
                                         <asp:BoundField HeaderText="Details of expenses" DataField="Details" />
                                         <asp:BoundField HeaderText="Transport" DataField="Transport" />
                                         <asp:BoundField HeaderText="Local Exp" DataField="Local" />
                                         <asp:BoundField HeaderText="Lodging" DataField="Lodging" />
                                         <asp:BoundField HeaderText="DA" DataField="DA" />
                                         <asp:BoundField HeaderText="Other" DataField="Other" FooterText="Total:" />
                                         <asp:BoundField HeaderText="Total" DataField="Total" /> 
                                     </Columns>
                                      <EmptyDataTemplate>No Details Added</EmptyDataTemplate>
                                  </asp:GridView>
                                     <asp:GridView ID="GridViewExport"    runat="server" >
                                         </asp:GridView>
                                
                                          </div>
                                <div class="form-group text-right"> 
                               
                                 <asp:LinkButton ID="lbkBack" CssClass="btn btn-danger" runat="server" 
                                    Text="Back" onclick="lbkBack_Click" />
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
