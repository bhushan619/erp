<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillPrint.aspx.cs" Inherits="Personnel_employee_BillPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
     <title>  Bill Print </title>

   <link href="../../assets/css/animate.css" rel="stylesheet" type="text/css" />
    <link href="../../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />  
    <!-- FONTAWESOME STYLES-->
    <link href="../../assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="../../assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="../../assets/css/custom.css" rel="stylesheet" />
     <link href="../../assets/css/pricing.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
   <%-- <link href="../assets/css/animate.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />  
    <!-- FONTAWESOME STYLES-->
    <link href="../assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="../assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="../assets/css/invoice.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/custom.css" rel="stylesheet" />
     <link href="../assets/css/pricing.css" rel="stylesheet" />--%>
     <style type="text/css">
     .tableinvoice { border: none; border-collapse: collapse; }
.tableinvoice th { border-bottom: 1px solid #000; }
.tableinvoice th { border-top: none; }
.tableinvoice th:first-child  { border-left:  none; }
.tableinvoice th  { border-right:1px solid #000; }
.tableinvoice th:last-child  { border-right:  none; }
.tableinvoice th:last-child  { border-left:  none; }
.tableinvoice th:first-child  { border-left:  none; }
.tableinvoice td { border-left: 1px solid #000;border-bottom:none; }
.tableinvoice td:first-child { border-left: none; }    
.tableinvoice td { border-right: none; }      
     </style>
       
       <script language="javascript" type="text/javascript">

           function openNewWin(url) {

               var x = window.open(url, 'mynewwin', 'width=600,height=400,left=100, resizable=yes,scrollbars=yes ,menubar=yes');

               x.focus();

           }
            
</script>
</head>

<body onload="PrintElem('#output');window.close();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    <div class="panel-body " id="output" style=" font-size: 12px;"> 
                      <div class="table-responsive">
                              <table class="table table-bordered  table-responsive"   
                                   border="1" style="border-collapse:collapse">
                                  <tr>
                                      <td style=" font-size: 12px;">
                                     
         <img src="http://sanghavi.anuvaasoft.com/images/Logo/sanghaviWithTortoise.png" height="50px" alt="sanghvi"
                                                       width="150px"  style="padding-bottom:20px;" /> 
         </td>
                                   <td style=" font-size: 12px;">
                                        
               <strong> Sanghavi Polymers</strong>
              <br />
                  <i>Address :</i>  S.N 43\B,Near Girna Bridge,
                  <br /> Jain Foods Compounds,
                  <br />   N.H.No.6,Bhambhori,Jalgaon.
         </td>
                                  </tr>
                                  <tr>
                                      <td colspan="2" align="center"     style=" font-size: 12px;">
                                        
          
             <span>
                 <strong>Email : </strong>         info@sanghavi.org
             </span> &nbsp;&nbsp;
             <span>
                 <strong>Mobile : </strong>            9404048868
             </span>&nbsp;&nbsp;
              <span>
                 <strong>Phone : </strong>             0257-2210091,2272597
             </span>
          
            </td>
                                  </tr>
                                  <tr>
                                      <td    style=" font-size: 12px;">
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
                                              <asp:SessionParameter Name="order" SessionField="orderidprint" />
                                              </SelectParameters>
                                                </asp:SqlDataSource> 
                                                </td>
                                   <td style=" font-size: 12px;"> 
               <h4>  <strong>Payment Details </strong></h4> 
  <asp:ListView ID="listBillDetails" runat="server" 
                                                    DataKeyNames="intBillNO,intOrderId,dtDate" 
                                                    DataSourceID="SqlDataSourceBillDetails" GroupItemCount="3">
                                                  <EmptyDataTemplate>
                                                      <table id="Table3" runat="server" style="">
                                                          <tr>
                                                           <td style=" font-size: 12px;">
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
                                                      <table>
                                                      <tr>
                                                      <td style=" font-size: 12px;">Bill No :
                                                          <asp:Label ID="intBillNOLabel" runat="server" Text='<%# Eval("intBillNO") %>' /> </td>
                                                   <td style=" font-size: 12px;"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dated : <asp:Label ID="dtDateLabel" runat="server" Text='<%# Eval("dtDate") %>' /></td>
                                                      </tr>
                                                      <tr >
                                                      <td style=" font-size: 12px;">Order No : <asp:Label ID="Label1" runat="server" Text='<%# Eval("intOrderId") %>' /></td>
                                                        <td style=" font-size: 12px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dated : <asp:Label ID="Expr2Label" runat="server" Text='<%# Eval("dtDate") %>' /></td>
                                                      </tr>
                                                      <tr >
                                                      <td colspan="2" style=" font-size: 12px;">  Dispatched Through : <asp:Label ID="varDispatchThroughLabel" runat="server" 
                                                              Text='<%# Eval("varDispatchThrough") %>' /></td>
                                                      </tr> 
                                                       <tr >
                                                      <td colspan="2" style=" font-size: 12px;">Terms Of Delivery :  <asp:Label ID="Label2" runat="server" 
                                                              Text='<%# Eval("varTermsOfDelivery") %>' /></td>
                                                      </tr>
                                                      
                                                      </table>  
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
                                                    SelectCommand="SELECT sanghaviunbreakables.tblsubill.intBillNO, sanghaviunbreakables.tblsubill.dtDate, sanghaviunbreakables.tblsuorder.intOrderId ,  sanghaviunbreakables.tblsubill.varDispatchThrough,sanghaviunbreakables.tblsuorder.dtDate ,sanghaviunbreakables.tblsubill.varTermsOfDelivery FROM sanghaviunbreakables.tblsubill INNER JOIN sanghaviunbreakables.tblsuorder ON sanghaviunbreakables.tblsubill.intOrderId = sanghaviunbreakables.tblsuorder.intOrderId where sanghaviunbreakables.tblsubill.intBillNO=@bill">
                                              <SelectParameters>
                                              <asp:SessionParameter Name="bill" SessionField="billnoprint" />
                                              </SelectParameters>
                                                </asp:SqlDataSource> 
             &nbsp;&nbsp;&nbsp;&nbsp;Mode of Payment : <asp:Label ID="lblModeOfPayment" runat="server" Text="NA"></asp:Label><br />
            &nbsp;&nbsp;&nbsp;&nbsp;Destination : <asp:Label ID="lblDestination" runat="server" Text="NA"></asp:Label>

          </td>
                                  </tr>
                                  <tr>
                                      <td colspan="2"  >
                                         <div  class="" > 
              <asp:GridView ID="gridconsignment" runat="server"  CssClass="tableinvoice" style=" font-size: 12px;width:100%;"
                  DataSourceID="SqlDataSourceConsignment"  >
                 
              </asp:GridView>
                                                <asp:SqlDataSource ID="SqlDataSourceConsignment" runat="server" 
                                                    ConnectionString="<%$ ConnectionStrings:sanghaviConnectionString %>" 
                                                    ProviderName="<%$ ConnectionStrings:sanghaviConnectionString.ProviderName %>" 
                                                    SelectCommand="SELECT        tblsuconsignmentdetails.intSrNo AS SrNo, 
                         tblsuconsignmentdetails.varProductName AS `Description of Goods`, tblsuconsignmentdetails.varSack AS `Alt Quantity`, 
                         tblsuconsignmentdetails.varNug AS Quantity, tblsuconsignmentdetails.varRate AS Rate, tblsuconsignmentdetails.varPer AS Per, 
                         tblsuconsignmentdetails.varVat AS `VAT%`, tblsuconsignmentdetails.varDisc AS `Disc %`, tblsuconsignmentdetails.varPrice AS Amount
FROM            tblsubill, tblsuconsignmentdetails, tblsuorder
WHERE        tblsubill.intConsingmentId = tblsuconsignmentdetails.intConsigmentNo AND tblsubill.intOrderId = tblsuorder.intOrderId AND (tblsubill.intOrderId = @order)">
                                                  <SelectParameters>
                                              <asp:SessionParameter Name="order" SessionField="orderidprint" />
                                              </SelectParameters>
                                                </asp:SqlDataSource>
        </div></td>
                                  </tr>
                                  <tr>
                                   <td style=" font-size: 12px;">
                                        
         <span style="font-size: 11px; line-height: 18px"> VAT Amount (In word):</span> <br />  <b> <asp:Label ID="lblvatinword" runat="server" Text="" ></asp:Label></b>
           <br />   <span style="font-size: 11px; line-height: 18px">  Amount Chargeable (In word): </span><br />   <b>  <asp:Label ID="lblAmountChargeword" runat="server" Text="" ></asp:Label></b>
           
     <br />
     <br />
    
           </td>
                                      <td align="right"   style=" font-size: 12px;">
                                          
    
                Total Amount : 
                  <b><asp:Label ID="lblAmt" runat="server" Text=""></asp:Label> </b> 
            <br />
                  VAT : 
                   <b>  <asp:Label ID="lbltotalVat" runat="server" Text=""></asp:Label></b> 
           <br />
                  <h4> <strong>Total : 
                      <asp:Label ID="lblfinaltotamt" runat="server" Text=""></asp:Label></strong> </h4>
            
             <br />
             
            
          </td>
                                  </tr>
                                  <tr>
                                   <td style=" font-size: 12px;">
                                      Company's VAT TIN  &nbsp;&nbsp;: <b>27360296085 V</b><br />
     Company's CST No.   &nbsp;&nbsp;: <b>27360296085 C</b><br />
     Buyer's VAT TIN    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: <b><asp:Label ID="lblvat" runat="server" Text=""></asp:Label></b><br />
     Buyer's CST No.    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: <b><asp:Label ID="lbltin" runat="server" Text=""></asp:Label></b><br />
     Company's PAN      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: <b>ABAFS3847G</b><br />   
                                      </td>
                                      <td align="left"   style=" font-size: 12px;">
                                          Company's Bank Details<br />
              Bank Name   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: <b>State Bank Of India,M.I.D.C. Jalgaon</b><br />
     A/c No.    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: <b>27360296085 C</b><br />
      Branch & IFS Code     &nbsp;: <b>ABAFS3847G</b><br />
                                          </td>
                                  </tr>
                                  <tr>
                                      <td colspan="2"   style=" font-size: 12px;">
                                        
          <span style="font-size: 14px; line-height: 18px; "><u>Declaration:</u> </span> <br /> 
       <p>   <span style="font-size: 11px; line-height: 18px"> I/We hereby certify that my/our registration certificate under the Maharastra Value Added Act, 2002 is in force on the date on which the sale of good specified in this tax invoice is made by me/us and that the transaction of sale covered by this tax invoice has been effected by me/us and it shall be accounted for in the turnover.</span></p>
       </td> 
                                  </tr>
                                  <tr>
                                  <td align="left"   style=" font-size: 12px;">
                                   
           Customer's Seal And Signature 
         <br /><br />  
             </td>
                                  <td align="right"   style=" font-size: 12px;">
           for SANGHAVI POLYMERS 
        <br /><br /> 
              
             </td>
                                  </tr>
                                  <tr>
                                  <td colspan="2" align="center"> 
                                 <span style="font-size: 11px; line-height: 18px "> SUBJECT TO JALGAON JURISDICTION<br />
            This is a computer generated invoice</span>
            </td>
                                  </tr>
                              </table>
                       </div> 
                    </div>
       <script type="text/javascript">
           function Popup(data) {
               var mywindow = window.open('Print', 'my div', 'height=400,width=600');
               mywindow.document.write('<html><head><title>Bill Print </title><link href="../assets/css/bootstrap.css" rel="stylesheet" /><link href="../assets/css/font-awesome.css" rel="stylesheet" /><link href="../assets/css/invoice.css" rel="stylesheet" /><link href="../assets/css/basic.css" rel="stylesheet" /><link href="../assets/css/custom.css" rel="stylesheet" /></head>');

               mywindow.document.write('<body >');
               mywindow.document.write(data);
               mywindow.document.write('</body></html>');
               mywindow.print();
               mywindow.close();

               return true;
           }
           function PrintElem(elem) {
               Popup($(elem).html());
           }
            
       </script>
             
             
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
