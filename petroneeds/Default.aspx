<%@ Page Title="Petroneeds Services International :: Home" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="userControll/scrolling_news.ascx" tagname="scrolling_news" tagprefix="uc1" %>

<%@ Register src="userControll/scrolling_emp.ascx" tagname="scrolling_emp" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
   
.Accordion {
	border-left: solid 0px #B00000;
	border-right: solid 0px #B00000;
	border-bottom: solid 5px white;
	overflow: hidden;
}

.AccordionPanel {
	margin: 0px;
	padding: 0px;
}

.AccordionPanelTab {
	background-color: #B00000;
	border-top: solid 5px white;
	border-bottom: solid 5px white;
	margin: 0px;
	padding: 0px;
	cursor: pointer;
	-moz-user-select: none;
	-khtml-user-select: none;
}

.AccordionPanelContent {
	overflow: auto;
	margin: 0px;
	padding: 0px;
	height: 40px;
}
        .style16
        {
            height: 17px;
            text-align: justify;
            font-family:Tahoma; font-size:13px;
        }

        .style17
        {
            height: 170px;
        }

        .style18
    {
        height: 20px;
    }
        .style6 {font-size: 11px}

        .style19
        {
            height: 15px;
        }

        </style>
    <script src="SpryAssets/SpryAccordion.js" type="text/javascript"></script>
<script type="text/javascript">
<!--
    function MM_preloadImages() { //v3.0
        var d = document; if (d.images) {
            if (!d.MM_p) d.MM_p = new Array();
            var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; } 
        }
    }
    function MM_findObj(n, d) { //v4.01
        var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
            d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
        }
        if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
        for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
        if (!x && d.getElementById) x = d.getElementById(n); return x;
    }
    function MM_swapImgRestore() { //v3.0
        var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
    }
    function MM_swapImage() { //v3.0
        var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
            if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
    }
//-->
</script>
<link href="SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css" />
</asp:Content>


<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <div align="center">
  <table width="995" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="250"><img src="images/upline.png" width="250" height="4" /></td>
      <td><img src="images/upline.png" width="495" height="4" /></td>
      <td width="250"><img src="images/upline.png" width="250" height="4" /></td>
    </tr>
    <tr>
      <td height="80" colspan="2" valign="bottom" bgcolor="#FFFFFF"><div align="left">
        <table width="745" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="90"><div align="right" style="width: 113px"><img src="images/PSI.bmp" 
                    height="73" style="width: 94px" /></div></td>
            <td width="632"><img src="images/coName2.gif" width="632" height="80" /></td>
          </tr>
        </table>
        </div></td>
      <td width="250" height="80" valign="top" bgcolor="#FFFFFF"><table width="250" border="0" cellspacing="0" cellpadding="0">
        
        <tr>
          <td width="94" height="42" valign="bottom">&nbsp;</td>
          <td width="52" height="42" valign="bottom"><div align="center"><a href="default.aspx" target="_blank" onmouseover="MM_swapImage('Image1','','images/ico_1.png',1)" onmouseout="MM_swapImgRestore()"><img src="images/ico_1.png" alt="Home" name="Image1" width="52" height="40" border="0" id="Image1" title="Home" /></a></div></td>
          <td width="52" height="42" valign="bottom"><div align="center"><a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image2','','images/ico_2.png',1)"><img src="images/ico_2.png" alt="E-mail" name="Image2" width="52" height="40" border="0" id="Image2" title="E-mail" /></a></div></td>
          <td width="52" height="42" valign="bottom"><div align="center"><a href="Login.aspx" target="_blank" onmouseover="MM_swapImage('Image3','','images/icon_3.png',1)" onmouseout="MM_swapImgRestore()">
              <img src="images/icon_3.png" alt="Login" name="Image3" width="52" height="40" 
                  border="0" id="Image3" title="Staff Login" /></a></div></td>
        </tr>
      </table></td>
    </tr>
    <tr>
      <td height="150" colspan="3" bgcolor="#FFFFFF"><table width="995" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="150"><object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="995" height="150">
            <param name="movie" value="images/head.swf" />
            <param name="quality" value="high" />
            <embed src="images/head.swf" quality="high" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" width="995" height="150"></embed>
          </object></td>
        </tr>
      </table></td>
    </tr>
    <tr>
      <td colspan="3" bgcolor="#FFFFFF">
                    <table width="995" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="124" height="25"><a href="default.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image10','','images/li_01.jpg',1)"><img src="images/li_01.jpg" name="Image10" width="124" height="25" border="0" id="Image10" title="Home" /></a></td>
          <td width="124" height="25"><a href="welcom.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image30','','images/li_09.jpg',1)"><img src="images/li_9.jpg" name="Image30" width="124" height="25" border="0" id="Image30" /></a></td>
          <td width="124" height="25"><a href="polices.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image31','','images/li_010.jpg',1)"><img src="images/li_10.jpg" name="Image31" width="124" height="25" border="0" id="Image31" /></a></td>
          <td width="124" height="25"><a href="Events.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image32','','images/li_011.jpg',1)"><img src="images/li_11.jpg" name="Image32" width="124" height="25" border="0" id="Image32" /></a></td>
          <td width="124" height="25"><a href="staff.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image33','','images/li_012.jpg',1)"><img src="images/li_12.jpg" name="Image33" width="124" height="25" border="0" id="Image33" /></a></td>
          <td width="124" height="25"><a href="e_services.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image34','','images/li_013.jpg',1)"><img src="images/li_13.jpg" name="Image34" width="124" height="25" border="0" id="Img1" /></a></td>
          <td width="124" height="25"><a href="vacancy.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image35','','images/li_014.jpg',1)"><img src="images/li_14.jpg" name="Image35" width="124" height="25" border="0" id="Img2" /></a></td>
          
          <td width="124" height="25" bgcolor="#B00000" style="width: 248px"><a href="Login.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Img3','','images/li_020.jpg',1)">
              <img src="images/li_20.jpg" name="Image44" width="124" height="25" border="0" 
                  id="Img3" /></a></td>
        </tr>
      </table>
                </td>
    </tr>
    <tr>
      <td width="250" bgcolor="#FFFFFF">&nbsp;</td>
      <td width="495" bgcolor="#FFFFFF">&nbsp;</td>
      <td width="250" bgcolor="#FFFFFF">&nbsp;</td>
    </tr>
    <tr>
      <td width="250" bgcolor="#FFFFFF">&nbsp;</td>
      <td width="495" bgcolor="#FFFFFF">&nbsp;</td>
      <td width="250" bgcolor="#FFFFFF">&nbsp;</td>
    </tr>
    <tr>
      <td width="250" valign="top" bgcolor="#FFFFFF"><table width="250" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="5" height="17">&nbsp;</td>
          <td bgcolor="#B00000"><div align="center"><img src="images/link_titel.png" width="230" height="40" /></div></td>
          <td width="5">&nbsp;</td>
        </tr>
        
        
        
        
        <tr>
          <td height="368">&nbsp;</td>
          <td valign="top"><div id="Accordion1" class="Accordion" tabindex="0">
            <div class="AccordionPanel">
              <div class="AccordionPanelTab">
                <div align="center"><img src="images/l_2.png" name="Image43" width="230" height="40" border="0" id="Image43" /></div>
              </div>
              <div class="AccordionPanelContent">
                
                  <div align="right">
                    <table width="230" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="10">&nbsp;</td>
                          <td width="218"><div align="left"><a href="PublicData\SUPPLY CHAIN\CO\PSI-QP-SC-CO.pdf" target="_blank">  - Contracting Procdure </a></div></td>
                          
                         

                        
                        </tr>
                        <tr>
                        <td width="10">&nbsp;</td>
                          <td width="218"><div align="left"><a href="PublicData\SUPPLY CHAIN\LO\PSI-QP-SC-LO.pdf" target="_blank">  - Logistic Procedure </a></div></td>

                          <td width="10">&nbsp;</td>
                        </tr>
                         <tr>
                        <td width="10">&nbsp;</td>
                          <td width="218"><div align="left"><a href="PublicData\SUPPLY CHAIN\PR\PSI-QP-SC-PR.pdf" target="_blank">  - Procurement Procedure </a></div></td>
                          <td width="10">&nbsp;</td>
                        </tr>
                         <tr>
                        <td width="10">&nbsp;</td>
                          <td width="218"><div align="left"><a href="PublicData\SUPPLY CHAIN\VR\PSI-QP-SC-VR.pdf" target="_blank"> - Vendor Registration Procedure</a></div></td>
                          <td width="10">&nbsp;</td>
                        </tr>
                        <tr>
                        <td width="10">&nbsp;</td>
                          <td width="218"><div align="left"><a href="PublicData\SUPPLY CHAIN\WH\PSI-QP-SC-WH.pdf" target="_blank"> - Warehouse Operation Procedure </a></div></td>
                          <td width="10">&nbsp;</td>
                        </tr>

                    </table>
                  </div>
              </div>
            </div>
            <div class="AccordionPanel">
              <div class="AccordionPanelTab">
                <div align="center"><img src="images/l_1.png" name="Image42" width="230" height="40" border="0" id="Image42" /></div>
              </div>
              <div class="AccordionPanelContent">
                <table width="230" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="10">&nbsp;</td>
                    <td width="218"><div align="left" class="style9"><a href="PublicData\HR\BE\PSI-QP-HR-BE.pdf" target="_blank">  - Benefits Procedure </a></div></td>
                    <td width="10">&nbsp;</td>
 
                  </tr>
                  <tr>
                    <td width="10">&nbsp;</td>
                    <td width="218"><div align="left" class="style9"><a href="PublicData\HR\BT\PSI-QP-HR-BT.pdf" target="_blank">  - Business Trips Procedure </a></div></td>
                    <td width="10">&nbsp;</td>
                  </tr>
                  <tr>
                    <td width="10">&nbsp;</td>
                    <td width="218"><div align="left" class="style9"><a href="PublicData\HR\ES\PSI-QP-HR-ES.pdf" target="_blank">  - End Of Services Benefits Procedure </a></div></td>
                    <td width="10">&nbsp;</td>
                  </tr>
                 <tr>
                    <td width="10">&nbsp;</td>
                    <td width="218"><div align="left" class="style9"><a href="PublicData\HR\LE\PSI-QP-HR-LE.pdf" target="_blank">  - Leaves Procedure </a></div></td>
                    <td width="10">&nbsp;</td>
                  </tr>
                  <tr>
                    <td width="10">&nbsp;</td>
                    <td width="218"><div align="left" class="style9"><a href="PublicData\HR\PH\PSI-QP-HR-PH.pdf" target="_blank">  - Public Holidays Procedure </a></div></td>
                    <td width="10">&nbsp;</td>
                  </tr>
                  <tr>
                    <td width="10">&nbsp;</td>
                    <td width="218"><div align="left" class="style9"><a href="PublicData\HR\PU\PSI-QP-HR-PU.pdf" target="_blank">  - Promotion& Uprading Procedure</a></div></td>

                    <td width="10">&nbsp;</td>
                  </tr>
                  <tr>
                    <td width="10">&nbsp;</td>
                    <td width="218"><div align="left" class="style9"><a href="PublicData\HR\RS\PSI-QP-HR-RS.pdf" target="_blank">  - Recruitment & Selection Procedure</a></div></td>

                    <td width="10">&nbsp;</td>
                  </tr>
                  <tr>
                    <td width="10">&nbsp;</td>
                    <td width="218"><div align="left" class="style9"><a href="PublicData\HR\SA\PSI-QP-HR-SA.pdf" target="_blank">  - Salary Administration Procedure </a></div></td>
                    <td width="10">&nbsp;</td>
                  </tr>
                  <tr>
                    <td width="10">&nbsp;</td>
                    <td width="218"><div align="left" class="style9"><a href="PublicData\HR\TR\PSI-QP-HR-TR.pdf" target="_blank">  - Identifying & Implementing of Training
                    </a></div></td>
                    <td width="10">&nbsp;</td>
                  </tr>
                  
                 
                  </table>
              </div>
            </div>
            <div class="AccordionPanel">
              <div class="AccordionPanelTab">
                <div align="center"><img src="images/l_3.png" name="Image41" width="230" height="40" border="0" id="Image41" /></div>
              </div>
              <div class="AccordionPanelContent">
                
                  <div align="right">
                    <table width="230" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="8">&nbsp;</td>
                          <td class="style6"><div align="left" class="style6"><a href="PublicData/Administration_and_ICT_Department_Policy_and_Procedure_(3).pdf" target="_blank"> - <span class="style6"><b>Policey &amp; Procedure</b></span></a></div></td>
                        </tr>
                      <tr>
                        <td>&nbsp;</td>
                        <td class="style6"><div align="left" class="style6"> <a href="PublicData/Administration and ICT Procedures -Forms.pdf" target="_blank" class="style6"> - Procedures Forms</a></div></td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                        <td class="style6"><div align="left" class="style6">- <a href="PublicData/ict-ICT Procedures.doc" class="style6">ICT Procedures</a></div></td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                        <td class="style6"><div align="left" class="style6">- <a href="PublicData/ict-Administration Forms.doc" class="style6">Administration Forms</a></div></td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                        <td class="style6"><div align="left" class="style6">- <a href="PublicData/ict-IT Equipments Request Form.doc" class="style6">IT Equipments Request Form</a></div></td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                        <td class="style6"><div align="left" class="style6">- <a href="PublicData/ict-Request for Access to Information Technology Systems.doc" class="style6">Access to IT Systems</a></div></td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                        <td class="style6"><div align="left" class="style6">- <a href="PublicData/ict-Request to Move Information Technology Equipment.doc" class="style6">Move IT Equipment</a></div></td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                        <td class="style6"><div align="left" class="style6">- <a href="PublicData/ict-Function or Process Modification Request (S-ICT-02).doc" class="style6">Function or Process Modification</a></div></td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                        <td class="style6"><div align="left" class="style6">- <a href="PublicData/ict-New Application Software or Module Request(AS-01).doc" class="style6">New Application Software or Module</a></div></td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                          <td class="style6"><div align="left" class="style6">- <a href="PublicData/Request for ict-Remove or Modify Access to  Information Technology Systems.doc" class="style6">Request for Remove or Modify Access to  IT Systems</a></div></td>
                        </tr>
                         <tr>
                        <td>&nbsp;</td>
                          <td class="style6"><div align="left" class="style6">- <a href="PublicData/User Guide.pdf" class="style6">VoIP User Guide</a></div></td>
                        </tr>
                         <tr>
                        <td>&nbsp;</td>
                          <td class="style6"><div align="left" class="style6">- <a href="PublicData/VoIP Directory Extensions Numbers List.doc" class="style6">VoIP Directory Extensions Numbers List</a></div></td>
                        </tr>
                        </table>
                  </div>
                  <div align="right"></div></div>
            </div>
            <div class="AccordionPanel">
              <div class="AccordionPanelTab">
                <div align="center"><img src="images/l_6.png" width="230" height="40" /></div>
              </div>
              <div class="AccordionPanelContent">
                <div align="right">
                  <table width="230" border="0" cellspacing="0" cellpadding="0">

                   <tr>
                    <td width="10">&nbsp;</td>
                    <td width="218"><div align="left" class="style9"><a href="PublicData\BUSINESS DEVLOPMENT\CS\PSI-QP-BD-CS.pdf" target="_blank"> - Customer Satisfaction Procdure
             
                    </a></div></td>
                    <td width="10">&nbsp;</td>
                  </tr>
                  <tr>
                    <td width="10">&nbsp;</td>
                    <td width="218"><div align="left" class="style9"><a href="PublicData\BUSINESS DEVLOPMENT\TD\PSI-QP-BD-TD.pdf" target="_blank">  -Tendering Procdure </a></div></td>
                    <td width="10">&nbsp;</td>
                  </tr>
                 
                    <tr>
                      <td>&nbsp;</td>
                      <td><div align="left"></div></td>
                    </tr>
                  </table>
                </div>
              </div>
            </div>
            <div class="AccordionPanel">
              <div class="AccordionPanelTab">
                <div align="center"><img src="images/l_7.png" width="230" height="40" /></div>
              </div>
              <div class="AccordionPanelContent">
                <div align="right">
                  <table width="230" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="8">&nbsp;</td>
                      <td><div align="left"></div></td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td><div align="left"></div></td>
                    </tr>
                  </table>
                </div>
              </div>
            </div>
            <div class="AccordionPanel">
              <div class="AccordionPanelTab">
                <div align="center"><img src="images/l_8.png" width="230" height="40" /></div>
              </div>
              <div class="AccordionPanelContent">
                <div align="right">
                  <table width="230" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="8">&nbsp;</td>
                      <td><div align="left"></div></td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td><div align="left"></div></td>
                    </tr>
                  </table>
                </div>
              </div>
            </div>
            <div class="AccordionPanel">
              <div class="AccordionPanelTab">
                <div align="center"><img src="images/l_9.png" width="230" height="40" /></div>
              </div>
              <div class="AccordionPanelContent">
               <table width="230" border="0" cellspacing="0" cellpadding="0">
                   <tr>
                    <td width="10">&nbsp;</td>
                    <td width="218"><div align="left" class="style9"><a href="PublicData\DRILLING\DO\PSI-QP-DM-DO.pdf" target="_blank"> - Drilling Operation Procdure </a></div></td>
                    <td width="10">&nbsp;</td>
                  </tr>
                  <tr>
                    <td width="10">&nbsp;</td>
                    <td width="218"><div align="left" class="style9"><a href="PublicData\DRILLING\NI\PSI-QP-DM-NI.pdf" target="_blank">  - Nitrogen Injection Procedure </a></div></td>
                    <td width="10">&nbsp;</td>
                  </tr>
                 <tr>
                    <td width="10">&nbsp;</td>
                    <td width="218"><div align="left" class="style9"><a href="PublicData\DRILLING\SO\PSI - QP-DM-SO.pdf" target="_blank">  - Service Rig Operation Procedure</a></div></td>
                    <td width="10">&nbsp;</td>
                  </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td><div align="left"></div></td>
                    </tr>
                  </table>

              
              
              </div>
            </div>
            <div class="AccordionPanel">
              <div class="AccordionPanelTab">
                <div align="center"><img src="images/l_10.png" width="230" height="40" /></div>
              </div>
              <div class="AccordionPanelContent">
                <table width="230" border="0" cellspacing="0" cellpadding="0">
                   <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\CPA\PSI-QHSE-CPA.pdf" target="_blank"> - Corrective & Preventive Action Procdure</a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\CR\PSI-QHSE-CR.pdf" target="_blank"> - Control Of Records Procdure </a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\DC\PSI-QHSE-DC.pdf" target="_blank"> - Document Control Procdure </a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\HSE\PSI-QP-HSE-AR\PSI-QP-HSE-AR.pdf" target="_blank"> - Accident Reporting & Investigation
</a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\HSE\PSI-QP-HSE-CC\PSI-QP-HSE-CC.pdf" target="_blank"> - Communication & Consultation Proecdure </a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                   <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\HSE\PSI-QP-HSE-EA\PSI-QP-HSE-EA.pdf" target="_blank"> - Enviromental Impacts & Risk Assessment Proecdure
 </a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\HSE\PSI-QP-HSE-EP\PSI-QP-HSE-EP.pdf" target="_blank"> - Emergency Predapredness& Response Proecdure</a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                    <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\HSE\PSI-QP-HSE-FF\PSI-QP-HSE-FF.pdf" target="_blank"> - Fire Fighting Response Proecdure</a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                   <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\HSE\PSI-QP-HSE-GD\PSI-QP-HSE-GD.pdf" target="_blank"> - Gas Detector Calibation Proecdure </a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\HSE\PSI-QP-HSE-IP\PSI-QP-HSE-IP.pdf" target="_blank"> - Inspection Proecdure </a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                 <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\HSE\PSI-QP-HSE-LO\PSI-QP-LO.pdf" target="_blank"> - Legal & Other Requirements Proecdure</a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\HSE\PSI-QP-HSE-MC\PSI-QP-HSE-MC.pdf" target="_blank"> - Management Of Change Proecdure </div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\HSE\PSI-QP-HSE-MME\PSI-QP-HSE-MME.pdf" target="_blank"> - Environmental & Montoring Procdure </div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\HSE\PSI-QP-HSE-OP\PSI-QP-HSE-OP.pdf" target="_blank"> - Operational Control Proecdure </div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                   <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\HSE\PSI-QP-HSE-RT\PSI-QP-HSE-RT.pdf" target="_blank"> <b>- PSI-QP-HSE-RT</b></a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                   <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\HSE\PSI-QP-HSE-WM\PSI-QP-HSE-WM.pdf" target="_blank"> <b>- PSI-QP-HSE-WM</b></a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\IA\PSI-QHSE-IA.pdf" target="_blank"> <b>- PSI-QHSE-IA</b></a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\MR\PSI-QHSE-MR.pdf" target="_blank"> <b>- PSI-QHSE-MR</b></a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\NC\PSI-QHSE-NC.pdf" target="_blank"> <b>- PSI-QHSE-NC</b></a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\QHSE\OP\PSI-QHSE-OP.pdf" target="_blank"> <b>- PSI-QHSE-OP</b></a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                 
                 
                 
              
                    
                 







                  <tr>
                    <td>&nbsp;</td>
                    <td><div align="left"></div></td>
                  </tr>
                </table>
              </div>
            </div>
            <div class="AccordionPanel">
              <div class="AccordionPanelTab">
                <div align="center"><img src="images/l_11.png" width="230" height="40" /></div>
              </div>
              <div class="AccordionPanelContent">
                <table width="230" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="8">&nbsp;</td>
                    <td><tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\PROJECTS\CC\PSI-QP-PM-CC.pdf" target="_blank"> <b>- PSI-QP-PM-CC</b></a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\PROJECTS\CI\PSI-QP-PM-CI.pdf" target="_blank"> <b>- PSI-QP-PM-CI</b></a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\PROJECTS\EP\PSI- QP- PM- EP.pdf" target="_blank"> <b>- PSI-QP-PM-EP</b></a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\PROJECTS\IC\PSI-QP-PM-IC.pdf" target="_blank"> <b>- PSI-QP-PM-IC</b></a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\PROJECTS\IT\PSI-QP-PM-IT.pdf" target="_blank"> <b>- PSI-QP-PM-IT</b></a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                 <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\PROJECTS\MA\PSI-QP-PM-MA.pdf" target="_blank"> <b>- PSI-QP-PM-MA</b></a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\PROJECTS\PC\PSI-QP-PM-PC.pdf" target="_blank"> <b>- PSI-QP-PM-PC</b></a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                  <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\PROJECTS\PF\PSI-QP-PM-PF.pdf" target="_blank"> <b>- PSI-QP-PM-PF</b></a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>

                   <tr>
                    <td width="10" class="style19"></td>
                    <td width="218" class="style19"><div align="left" class="style9"><a href="PublicData\PROJECTS\PS\PSI-QP-PM-PS.pdf" target="_blank"> <b>- PSI-QP-PM-PS</b></a></div></td>
                    <td width="10" class="style19"></td>
                  </tr>
                 
                 
                 
                    </div></td>
                  </tr>
                  
                  


                  <tr>
                    <td>&nbsp;</td>
                    <td><div align="left"></div> </td>
                  </tr>
                </table>
              </div>
            </div>
            </div></td>
          <td>&nbsp;</td>
        </tr>
        
        
        
        
        
        
        <tr>
          <td height="368">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        
        
        
        
        
        
        <tr>
          <td height="368">&nbsp;</td>
          <td valign="top">&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        
        
        
        
        
        
      </table></td>
      <td width="495" valign="top" bgcolor="#FFFFFF"><table width="495" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="5">&nbsp;</td>
          <td><img src="images/titel_3.png" width="485" height="40" /></td>
          <td width="5">&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td class="style16">&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td style="text-align: justify">
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                DataSourceID="SqlDataSource1" Width="485px" CellPadding="5" 
                CellSpacing="2" GridLines="None" HorizontalAlign="Justify" Height="155px">
                <Fields>
                    <asp:BoundField DataField="MngTitle" HeaderText="MngTitle" 
                        ShowHeader="False" SortExpression="MngTitle" >
                    <ItemStyle HorizontalAlign="Justify" />
                    </asp:BoundField>
                </Fields>
            </asp:DetailsView>
            </td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td class="style16">
              <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/welcom.aspx">read more...</asp:LinkButton>
            </td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td class="style16">&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td class="style16">
              <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Staff Login" 
                  ImageUrl="~/images/staff_login.png" PostBackUrl="~/login.aspx" />
            </td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td class="style16">&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td class="style16">&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td class="style16">
              <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                  ConnectionString="<%$ ConnectionStrings:petroneedsConnectionString2 %>" 
                  SelectCommand="SELECT [MngTitle] FROM [Mng_Word]"></asp:SqlDataSource>
            </td>
          <td>&nbsp;</td>
        </tr>
        
        
        
        
        
        
        
      </table>
          <br />
          <asp:Image ID="Image44" runat="server" 
              ImageUrl="~/images/IMG-20140223-WA0005[1].jpg" />
          <br />
          <br />
          With great pleasure Petroneeds Service International (PSI) is honored to welcome 
          <strong>Mr. Isam Eddin Mukhtar Ahmed </strong>in the position of deputy General Manager. PSI 
          staff is very pleased to have Mr. Isam Eddin at the cabinet crew of the company, 
          wishing him to be of a real addition to the company through his wealth of 
          experience and to exciting a new and ambitious energy to PSI.<br />
          <br />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <strong>
          <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</strong></td>
      <td width="250" valign="top" bgcolor="#FFFFFF"><table width="250" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td><img src="images/titel_1.png" width="250" height="40" /></td>
          </tr>
        <tr>
          <td>&nbsp;</td>
          </tr>
        <tr>
          <td>&nbsp;</td>
          </tr>
        <tr>
          <td class="style17">
              <uc1:scrolling_news ID="scrolling_news1" runat="server" />
            </td>
          </tr>
        
        <tr>
          <td class="style18"></td>
        </tr>
        
        <tr>
          <td><a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image26','','images/titel_2.png',1)"><img src="images/titel_2.png" name="Image26" width="250" height="40" border="0" id="Image26" /></a></td>
        </tr>
        <tr>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td height="170">
              <uc2:scrolling_emp ID="scrolling_emp1" runat="server" />
            </td>
        </tr>
        
        <tr>
          <td>&nbsp;</td>
          </tr>
        
        <tr>
          <td>&nbsp;</td>
          </tr>
      </table></td>
    </tr>
    
    <tr>
      <td width="250" bgcolor="#FFFFFF">&nbsp;</td>
      <td width="495" bgcolor="#FFFFFF">&nbsp;</td>
      <td width="250" bgcolor="#FFFFFF">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="3" bgcolor="#FFFFFF"><img src="images/line.jpg" width="995" 
              style="height: 5px" /></td>
    </tr>
    <tr>
      <td height="130" colspan="3" bgcolor="#F4F2EF"><table width="995" border="0" 
              cellspacing="0" cellpadding="0" style="height: 57px">
        <tr>
          <td>&nbsp;</td>
          <td><div align="left"><span class="style5"><a href="Default.aspx">Home</a></span></div></td>
          <td>&nbsp;</td>
          <td class="style5"><div align="left"><a href="welcom.aspx">Welcome</a></div></td>
          <td>&nbsp;</td>
          <td class="style5"><div align="left"><a href="polices.aspx">Policies</a></div></td>
          <td>&nbsp;</td>
          <td class="style5"><div align="left"><a href="Events.aspx">News &amp; Events</a></div></td>
          <td>&nbsp;</td>
          <td class="style5"><div align="left"><a href="staff.aspx">Staff Zone</a></div></td>
          <td>&nbsp;</td>
          <td class="style5"> <div align="left"><a href="e_services.aspx">E-Services</a></div></td>
        </tr>
        <tr>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
        </tr>
        <tr>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
        </tr>
        <tr>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
        </tr>
        <tr>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
        </tr>
        <tr>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="150" style="text-align: right">
              <img src="images/logo.png" width="22" height="26" title="Petroneeds Services International" /></td>
        </tr>
        <tr>
          <td colspan="12"><div align="center" class="style1">Copyright © 1997 - 2013 Petroneeds Services International. All Rights Reserved. </div></td>
          </tr>
      </table></td>
    </tr>
  </table>
</div>
<script type="text/javascript">
<!--
var Accordion1 = new Spry.Widget.Accordion("Accordion1");
//-->
</script>
</asp:Content>




