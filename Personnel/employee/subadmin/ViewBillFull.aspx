<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="ViewBillFull.aspx.cs" Inherits="Personnel_employee_ViewBillFull" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>  View Full Bill </title>

   <!-- BOOTSTRAP STYLES-->
    <link href="../../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />  
    <!-- FONTAWESOME STYLES-->
    <link href="../../assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="../../assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="../../assets/css/custom.css" rel="stylesheet" />
       <link href="../../assets/css/bootstrap-fileupload.min.css" rel="stylesheet" />
   
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
 
       
       <script language="javascript" type="text/javascript">

           function openNewWin(url) {

               var x = window.open(url, 'mynewwin', 'width=600,height=400,left=100, resizable=yes,scrollbars=yes ,menubar=yes');

               x.focus();

           }
  
 
    
    function PrintElem(elem) {
        Popup($(elem).html());
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
                    <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Personnel/employee/subadmin/Notification.aspx" CssClass="btn btn-primary fa fa-2x" ToolTip="Notification" runat="server"> </asp:HyperLink>
     <asp:LinkButton ID="lnkLogoutUp" runat="server"  class="btn btn-danger fa fa-exclamation-circle fa-2x" 
                   ToolTip="Logout" onclick="lnkLogout_Click"    ></asp:LinkButton>      

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
                        <a href="#"><i class="fa fa-plus-circle "></i> Stock<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                                <a href="RecieveStockJalgaon.aspx"><i class="fa fa-share"></i>Recieve Verkhedi Stock</a>
                            </li>
                            <li>
                                <a href="ViewStock.aspx"><i class="fa fa-pencil-square-o"></i>View stock</a>
                            </li>
                            </ul>
                    </li>     
                     <li>
                        <a href="#"><i class="fa fa-plus-circle "></i> Order<span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level ">
                          <li>
                                <a href="CreateOrder.aspx"><i class="fa fa-share"></i>Create Order</a>
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
                           <a  href="ViewConsignmentStatus.aspx"><i class="fa fa-map-marker "></i>Track Consignment</a>
                    </li>
                     <li>
                           <a  href="AllocateDistrict.aspx" ><i class="fa fa-map-marker "></i>Allocate District</a>
                    </li>
                    <li>
                        <a  href="Notification.aspx"><i class="fa fa-bell "></i>Notification</a>
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
                 
                <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
               <div class="panel panel-info">
                        <div class="panel-heading">
                         View Bill 
                    </div>                    
               <div class="panel-body " id="output"> 
                      
                              <div class="col-md-12  col-sm-12 table-bordered"> 
                             <div class="row">
                              
      <div class="row pad-top-botm ">
         <div class="col-lg-6 col-md-6 col-sm-6 ">
         <img src="../../../images/Logo/sanghaviWithTortoise.png" height="90px" 
                                                       width="270px"  style="padding-bottom:20px;" /> 
         </div>
          <div class="col-lg-6 col-md-6 col-sm-6 ">
            
               <strong> Sanghavi Polymers</strong>
              <br />
                  <i>Address :</i>  S.N 43\B,Near Girna Bridge,
                  <br /> Jain Foods Compounds,
                  <br />   N.H.No.6,Bhambhori,Jalgaon.
         </div>
     </div>
     <div  class="row text-center contact-info">
         <div class="col-lg-12 col-md-12 col-sm-12">
             <hr />
             <span>
                 <strong>Email : </strong>         info@sanghavi.org
             </span>
             <span>
                 <strong>Mobile : </strong>            9404048868
             </span>
              <span>
                 <strong>Phone : </strong>             0257-2210091,2272597
             </span>
             <hr />
         </div>
     </div>
     <div  class="row pad-top-botm client-info">
         <div class="col-lg-6 col-md-6 col-sm-6">

         <h4>  <strong>Buyer's Information</strong></h4>
      
              <asp:ListView ID="ListView1" runat="server" DataKeyNames="intOrderId" 
                                                    DataSourceID="SqlDataSource1"> 
                                                    <EmptyDataTemplate>
                                                        <span>No data was returned.</span>
                                                    </EmptyDataTemplate>
                                                    
                                                    <ItemTemplate>
                                                      
                                                   <b>  <asp:Label ID="varCompanyNameLabel" runat="server" 
                                                            Text='<%# Eval("varCompanyName") %>' /></b>
                                                        <br />                                                       
                                                     Address : <asp:Label ID="varAddressLabel" runat="server" 
                                                            Text='<%# Eval("varAddress") %>' />,<br />
                                                      <asp:Label ID="varCityLabel" runat="server" Text='<%# Eval("varCity") %>' />  ,<asp:Label ID="varStateLabel" runat="server" Text='<%# Eval("varState") %>' />
                                                     <br />  Contact Person:
                                                        <asp:Label ID="varRepresentativeNameLabel" runat="server" 
                                                            Text='<%# Eval("varRepresentativeName") %>' />
                                                        <br />
                                                      Call :
                                                        <asp:Label ID="varMobileLabel" runat="server" Text='<%# Eval("varMobile") %>' />
                                                        <br />
                                                     E-mail :
                                                        <asp:Label ID="varEmailLabel" runat="server" Text='<%# Eval("varEmail") %>' />
                                                        <br /></span>
                                                  
                                                    
<br /></span>
                                                    </ItemTemplate>
                                                    <LayoutTemplate>
                                                        <div ID="itemPlaceholderContainer" runat="server" style="">
                                                            <span runat="server" id="itemPlaceholder" />
                                                        </div>
                                                        <div style="">
                                                        </div>
                                                    </LayoutTemplate>
                                                    
                                                </asp:ListView>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                    ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                                    ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                                    SelectCommand="SELECT tblsucustomer.varCompanyName,tblsucustomer.varAddress, tblsucustomer.varCity, tblsucustomer.varState, tblsucustomer.varRepresentativeName, tblsucustomer.varMobile, tblsucustomer.varEmail,  tblsuorder.intOrderId FROM tblsucustomer INNER JOIN tblsuorder ON tblsucustomer.intId = tblsuorder.intCustId where tblsuorder.intOrderId = @order ">
                                              <SelectParameters>
                                              <asp:SessionParameter Name="order" SessionField="orderid" />
                                              </SelectParameters>
                                                </asp:SqlDataSource> 
                                                </div>
          <div class="col-lg-6 col-md-6 col-sm-6">
            
               <h4>  <strong>Payment Details </strong></h4>
       
  <asp:ListView ID="listBillDetails" runat="server" 
                    DataKeyNames="intBillNO,intOrderId,dtDate" 
                    DataSourceID="SqlDataSourceBillDetails" GroupItemCount="3">
                    <EmptyDataTemplate>
                        <table id="Table3" runat="server" style="">
                            <tr>
                                <td>
                                    No data was returned.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <EmptyItemTemplate>
<td id="Td3" runat="server" />
                    </EmptyItemTemplate>
                    <GroupTemplate>
                        <tr ID="itemPlaceholderContainer" runat="server">
                            <td ID="itemPlaceholder" runat="server">
                            </td>
                        </tr>
                    </GroupTemplate>
                                                  
                    <ItemTemplate>
                        <td id="Td4" runat="server" style="">
                            Bill No:
                            <asp:Label ID="intBillNOLabel" runat="server" Text='<%# Eval("intBillNO") %>' />
                                                        
&nbsp;   &nbsp; &nbsp; &nbsp;  &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp;   Dated:
                            &nbsp;  <asp:Label ID="dtDateLabel" runat="server" Text='<%# Eval("dtDate") %>' />
                        <br />  
                        Order No: <asp:Label ID="Label1" runat="server" Text='<%# Eval("intOrderId") %>' />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp;  &nbsp;   Dated:  &nbsp;  <asp:Label ID="Expr2Label" runat="server" Text='<%# Eval("dtDate") %>' />
                            <br />
                                                       
                            Dispatched Through: <asp:Label ID="varDispatchThroughLabel" runat="server" 
                                Text='<%# Eval("varDispatchThrough") %>' />  
                            <br />
                            Terms Of Delivery:  <asp:Label ID="Label2" runat="server" 
                                Text='<%# Eval("varTermsOfDelivery") %>' />
                            <br />
                        </td>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table id="Table4" runat="server">
                            <tr id="Tr4" runat="server">
                                <td id="Td5" runat="server">
                                    <table ID="groupPlaceholderContainer" runat="server" border="0" style="">
                                        <tr ID="groupPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr5" runat="server">
                                <td id="Td6" runat="server" style="">
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                                                  
                </asp:ListView>
                <asp:SqlDataSource ID="SqlDataSourceBillDetails" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                    SelectCommand="SELECT sanghaviunbreakables.tblsubill.intBillNO, sanghaviunbreakables.tblsubill.dtDate, sanghaviunbreakables.tblsuorder.intOrderId , sanghaviunbreakables.tblsubill.varDispatchThrough, sanghaviunbreakables.tblsuorder.dtDate ,sanghaviunbreakables.tblsubill.varTermsOfDelivery FROM sanghaviunbreakables.tblsubill INNER JOIN sanghaviunbreakables.tblsuorder ON sanghaviunbreakables.tblsubill.intOrderId = sanghaviunbreakables.tblsuorder.intOrderId where sanghaviunbreakables.tblsubill.intBillNO=@bill">
                <SelectParameters>
                <asp:SessionParameter Name="bill" SessionField="billno" />
                </SelectParameters>
                </asp:SqlDataSource>
              Mode of Payment : <asp:Label ID="lblModeOfPayment" runat="server" Text="NA"></asp:Label><br />
              Destination : <asp:Label ID="lblDestination" runat="server" Text="NA"></asp:Label>
         </div>
     </div>
     <div class="row">
         <div class="col-lg-12 col-md-12 col-sm-12">
          <div  class=" table table-responsive " >
             
              <asp:GridView ID="gridconsignment" runat="server"  CssClass=" table table-bordered  table-responsive  "
                  DataSourceID="SqlDataSourceConsignment">
                 
              </asp:GridView>
                                                <asp:SqlDataSource ID="SqlDataSourceConsignment" runat="server" 
                                                    ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                                    ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                                    SelectCommand="SELECT        tblsuconsignmentdetails.intSrNo AS SrNo, tblsuconsignmentdetails.varProductName AS `Description of Goods`, CONCAT(tblsuconsignmentdetails.varSack, ' ', 'sack') 
                         AS `Alt Quantity`, CONCAT(tblsuconsignmentdetails.varNug, ' ', 'ng') AS Quantity, 
                         CONCAT(tblsuproducts.intPacking * tblsuorderdetails.varQuantity + tblsuorderdetails.varNag, ' ', 'ng') AS TotalNug, tblsuconsignmentdetails.varRate AS Rate, 
                         tblsuconsignmentdetails.varPer AS Per, tblsuconsignmentdetails.varVat AS `VAT%`, tblsuconsignmentdetails.varDisc AS `Disc %`, 
                         tblsuconsignmentdetails.varPrice AS Amount
FROM            tblsuorderdetails, tblsuproducts, tblsubill, tblsuconsignmentdetails, tblsuorder
WHERE        tblsuorderdetails.intProductId = tblsuproducts.intId AND tblsuorderdetails.intOrderId = tblsuorder.intOrderId AND 
                         tblsubill.intConsingmentId = tblsuconsignmentdetails.intConsigmentNo AND tblsubill.intOrderId = tblsuorder.intOrderId AND (tblsubill.intOrderId = @order)">
                                                  <SelectParameters>
                                              <asp:SessionParameter Name="order" SessionField="orderid" />
                                              </SelectParameters>
                                                </asp:SqlDataSource>
        </div>
           
         </div>
     </div>   
                    <div class="row">
         <div class="col-lg-12 col-md-12 col-sm-12">  
         
         <div class="col-lg-6 col-md-6 col-sm-6">   
         <span style="font-size: 11px; line-height: 18px"> VAT Amount (In word):</span> <br />  <b> <asp:Label ID="lblvatinword" runat="server" Text="" ></asp:Label></b>
           <br />   <span style="font-size: 11px; line-height: 18px">  Amount Chargeable (In word): </span><br />   <b>  <asp:Label ID="lblAmountChargeword" runat="server" Text="" ></asp:Label></b>
           
     <br />
     <br />
     Company's VAT TIN  &nbsp;&nbsp;: <b>27360296085 V</b><br />
     Company's CST No.   &nbsp;&nbsp;: <b>27360296085 C</b><br />
     Buyer's VAT TIN    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: <b><asp:Label ID="lblvat" runat="server" Text=""></asp:Label></b><br />
     Buyer's CST No.    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: <b><asp:Label ID="lbltin" runat="server" Text=""></asp:Label></b><br />
     Company's PAN      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: <b>ABAFS3847G</b><br />
            </div>
      <div class="col-lg-6 col-md-6 col-sm-6"> 
      <div class="ttl-amts text-right">
                Total Amount : 
                  <b><asp:Label ID="lblAmt" runat="server" Text=""></asp:Label> </b> 
             </div>
           
              <div class="ttl-amts text-right">
                  VAT : 
                   <b>  <asp:Label ID="lbltotalVat" runat="server" Text=""></asp:Label></b> 
             </div>
           
              <div class="ttl-amts text-right">
                  <h4> <strong>Total : 
                      <asp:Label ID="lblfinaltotamt" runat="server" Text=""></asp:Label></strong> </h4>
             </div> 
             <br />
             Company's Bank Details<br />
              Bank Name   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: <b>State Bank Of India,M.I.D.C. Jalgaon</b><br />
     A/c No.    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: <b>27360296085 C</b><br />
      Branch & IFS Code     &nbsp;: <b>ABAFS3847G</b><br />
            
          </div> 
             </div>
         </div>
        
         <div class="col-lg-12 col-md-12 col-sm-12">  
       <br />
          <span style="font-size: 14px; line-height: 18px; "><u>Declaration:</u> </span> <br /> 
       <p>   <span style="font-size: 11px; line-height: 18px"> I/We hereby certify that my/our registration certificate under the Maharastra Value Added Act, 2002 is in force on the date on which the sale of good specified in this tax invoice is made by me/us and that the transaction of sale covered by this tax invoice has been effected by me/us and it shall be accounted for in the turnover.</span></p>
           </div>
  <div class="col-lg-12 col-md-12 col-sm-12 table-bordered">
             <div class="col-md-6 col-sm-6 " 
                 style="border-right-style: solid; border-color: #C0C0C0">
         <div style="float:left">   Customer's Seal And Signature</div>
         <br /><br /> 
             </div>    
                <div class="col-md-6 col-sm-6 ">
          <div style="float:right"> for SANGHAVI POLYMERS</div> 
        <br /><br /> 
             </div>    

             </div>    
               <div class="col-lg-12 col-md-12 col-sm-12 text-center">
            <span style="font-size: 11px; line-height: 18px "> SUBJECT TO JALGAON JURISDICTION<br />
            This is a computer generated invoice</span>
           
             </div>          
         
                               </div>
                               </div>
                               </div>
                    
                    <div class="col-lg-12 col-md-12 col-sm-12">
            <br /><asp:Button  class="btn btn-primary"      ID="btnprint" runat="server" 
                            Text="Print Invoice " onclick="btnprint_Click" />
       
              &nbsp;</div>          
                      </div>
        </div></div>
        </div>
        </div>
        
            <!-- /. PAGE INNER  -->
        </div>
            <!-- /. PAGE INNER  -->
      
        
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