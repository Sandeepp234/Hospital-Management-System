<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master"  CodeBehind="Patient Prescription.aspx.cs" Inherits="Wellness_Hospital.Patient_Prescription" %>

   <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="main_container" style=" width:400px; float:left; height: 884px; margin-left: 0px;">
        <h2 style="text-align:center; font-family:Aharoni; font-style:oblique; font-size:30px"> Patient Prescription Details </h2>
            <div class="container-body col-md-12" style="left: -36px; top: 6px; height: 810px; width: 393px;"  >
              <div class="col-md-6 col-lg-6 col-sm-6" style="left: -1px; top: 9px; height: 806px">
            <table class="auto-style1" style="width: 316px; height: 503px">
                 <tr>
                    <td class="auto-style2" style="width: 140px; height: 16px;">
                        <asp:Label ID="lbppid" runat="server" Text=" P.P Id" CssClass="text"></asp:Label>
                    </td>
                    <td style="width: 173px; height: 16px;">
                        <asp:TextBox ID="txtPPid" runat="server" CssClass="txtbox"></asp:TextBox>
                    </td>
                </tr>


                  <tr>
                    <td class="auto-style2" style="width: 140px; height: 16px;">
                        <asp:Label ID="lbPPpatientid" runat="server" Text=" Patient Id" CssClass="text"></asp:Label>
                    </td>
                    <td style="width: 173px; height: 16px;">
                        <asp:TextBox ID="txtPPpatientid" runat="server" CssClass="txtbox" AutoPostBack="true" OnTextChanged="txtPPpatientid_TextChanged"></asp:TextBox>
                    </td>
                </tr>
          
                  <tr>
                    <td class="auto-style2" style="width: 140px; height: 15px;">
                        <asp:Label ID="lbPPpatientname" runat="server" Text=" Patient Name" CssClass="text" Width="118px"></asp:Label>
                    </td>
                    <td style="width: 173px; height: 15px;">
                        <asp:TextBox ID="txtPPpatientname" runat="server" CssClass="txtbox"></asp:TextBox>
                    </td>
                </tr>
          
                  <tr>
                    <td class="auto-style2" style="width: 140px; height: 15px;">
                        <asp:Label ID="lbPPdoctorId" runat="server" Text="Doctor Id" CssClass="text" Width="118px"></asp:Label>
                    </td>
                    <td style="width: 173px; height: 15px;">
                        <asp:TextBox ID="txtPPdoctorId" runat="server" CssClass="txtbox" AutoPostBack="true" OnTextChanged="txtPPdoctorId_TextChanged"></asp:TextBox>
                    </td>
                </tr>
          
                  <tr>
                    <td class="auto-style2" style="width: 140px; height: 15px;">
                        <asp:Label ID="lbPPdoctorName" runat="server" Text="Doctor  Name" CssClass="text" Width="118px"></asp:Label>
                    </td>
                    <td style="width: 173px; height: 15px;">
                        <asp:TextBox ID="txtPPdoctorName" runat="server" CssClass="txtbox"></asp:TextBox>
                    </td>
                </tr>
          
                  <tr>
                    <td class="auto-style2" style="width: 140px; height: 15px;">
                        <asp:Label ID="lbPPtestId" runat="server" Text="Test Id" CssClass="text" Width="118px"></asp:Label>
                    </td>
                    <td style="width: 173px; height: 15px;">
                        <asp:TextBox ID="txtPPtestId" runat="server" CssClass="txtbox" AutoPostBack="true" OnTextChanged="txtPPtestId_TextChanged"></asp:TextBox>
                    </td>
                </tr>
          
                  <tr>
                    <td class="auto-style2" style="width: 140px; height: 15px;">
                        <asp:Label ID="lbPPtestName" runat="server" Text="Test Name" CssClass="text" Width="118px"></asp:Label>
                    </td>
                    <td style="width: 173px; height: 15px;">
                        <asp:TextBox ID="txtPPtestName" runat="server" CssClass="txtbox"></asp:TextBox>
                    </td>
                </tr>
          
                <tr>
                    <td class="auto-style2" style="width: 140px; height: 43px;">
                        <asp:Label ID="lbPPobservation" runat="server" Text="Observation" CssClass="text"></asp:Label>
                    </td>
                    <td style="width: 173px; height: 43px;">
                        <asp:TextBox ID="txtPPobservation" runat="server" CssClass="txtbox"></asp:TextBox>
                    </td>
                </tr>
          
                <tr>
                    <td class="auto-style2" style="width: 140px; height: 46px;">
                        <asp:Label ID="lbPPgender" runat="server" Text=" Gender " CssClass="text"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="txtgender" runat="server" CssClass="txtbox" style="width:170px">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                </tr>
                <tr>
                    <td class="auto-style2" style="width: 140px; height: 30px;">
                        <asp:Label ID="lbPPage" runat="server" Text=" Age " CssClass="text"></asp:Label>
                    </td>
                    <td style="width: 173px; height: 30px;">
                        <asp:TextBox ID="txtPPage" runat="server" CssClass="txtbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="width: 140px; height: 68px;">
                        <asp:Label ID="lbPPmedicine" runat="server" Text="Medicine Described" CssClass="text" Width="160px"></asp:Label>
                    </td>
                    <td style="width: 173px; height: 68px;">
                        <asp:TextBox ID="txtPPmedicine" runat="server" Height="50px" TextMode="MultiLine" CssClass="txtbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="width: 140px; height: 44px;">
                        <asp:Label ID="lbPPdate" runat="server" Text="Appoiment Date" CssClass="text" Width="153px"></asp:Label>
                    </td>
                    <td style="width: 173px; height: 44px;">
                        <asp:TextBox ID="txtPPdatee" runat="server" CssClass="txtbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="width: 140px; height: 15px;">
                        <asp:Button ID="btnPPsubmit" runat="server" Text="Submit" CssClass="btn btn-warning" OnClick="btnPPsubmit_Click"/>
                    </td>
                    <td style="width: 173px; height: 15px;">
                        <asp:Button ID="btnPPcancle" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="btnPPcancle_Click"/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="width: 140px; height: 16px;">
                        <asp:Button ID="btnPPUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnPPUpdate_Click"/>
                    </td>
                    <td style="width: 173px; height: 16px;">
                        <asp:Button ID="btnPPdelete" runat="server" Text="Delete" CssClass="btn btn-primary" OnClick="btnPPdelete_Click"/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="width: 140px; height: 15px;">
                        <asp:Button ID="searchbtn" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="searchbtn_Click"/>
                    </td>
                    <td style="width: 173px; height: 15px;">
                        <asp:TextBox ID="searchtxt" runat="server" CssClass="txtbox"></asp:TextBox>
                    </td>
                </tr>
                 </table>
                                  </div>
                     </div>
            </div>

    <!--data grid view-->
<div class="col-lg-6 col-md-6" style=" float:left; width:600px; left: -2px; top: 42px; height: 499px;">
        <p>
            <asp:GridView ID="GridViewPrescription" runat="server" OnSelectedIndexChanged="GridViewPrescription_SelectedIndexChanged" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateSelectButton="True" OnRowDeleting="GridViewPrescription_RowDeleting" OnRowEditing="GridViewPrescription_RowEditing">
            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>
        <asp:GridView ID="GridViewsearch" runat="server">
        </asp:GridView>
        <br />
</div>
   </asp:Content>