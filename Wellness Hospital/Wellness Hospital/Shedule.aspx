<%@  Page Language="C#" Title="Shedule" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="Shedule.aspx.cs" Inherits="Wellness_Hospital.Shedule" %>


   <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="main_container" style=" width:400px; float:left;">
       
            <h2 style="text-align:center; font-family:Aharoni; font-style:oblique; font-size:30px"> Doctor And Patient Shedule Details </h2>
       
     
       <div class="container-body col-md-12"  style="left: -5px; top: 5px">

          <div class="col-md-6 col-lg-6 col-sm-6">
            <table class="auto-style1" style="width: 370px" >

                 <tr>
                    <td class="auto-style2" style="width: 122px;">
                        <asp:Label ID="lbSheduleid" runat="server"  Text="Shedule Id"  CssClass="text" Width="114px"></asp:Label>
                    </td>
                    <td style="width: 141px">
                        <asp:TextBox ID="txtsheduleid" runat="server" CssClass="txtbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="width: 122px;">
                        <asp:Label ID="lbSdoctorid" runat="server"  Text="Doctor Id"  CssClass="text" Width="114px"></asp:Label>
                    </td>
                    <td style="width: 141px">
                        <asp:TextBox ID="txtSdoctorid" runat="server" CssClass="txtbox"  AutoPostBack ="true" OnTextChanged="txtSdoctorid_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="width: 122px;">
                        <asp:Label ID="lbSdoctorname" runat="server" Text="Doctor Name" CssClass="text" Width="114px"></asp:Label>
                    </td>
                    <td style="width: 141px">
                        <asp:TextBox ID="txtSdoctorname" runat="server" CssClass="txtbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="width: 122px">
                        <asp:Label ID="lbSpatientid" runat="server" Text="Patient Id" CssClass="text" Width="114px"></asp:Label>
                    </td>
                    <td style="width: 141px">
                        <asp:TextBox ID="txtSpatientid" runat="server" CssClass="txtbox"  AutoPostBack ="true" OnTextChanged="txtSpatientid_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="width: 122px;">
                        <asp:Label ID="lbSpatientname" runat="server" Text="Patient Name" CssClass="text" Width="114px"></asp:Label>
                    </td>
                    <td style="width: 141px">
                        <asp:TextBox ID="txtSpatientname" runat="server" CssClass="txtbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="height: 24px; width: 122px">
                        <asp:Label ID="lbStime" runat="server" Text="Time" CssClass="text"></asp:Label>
                    </td>
                    <td style="height: 24px; width: 141px">
                        <asp:TextBox ID="txtStime" runat="server" CssClass="txtbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="height: 24px; width: 122px">
                        <asp:Label ID="lbSdate" runat="server" Text="Date" CssClass="text"></asp:Label>
                    </td>
                    <td style="height: 24px; width: 141px;">
                        <asp:TextBox ID="txtSdate" runat="server" CssClass="txtbox"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td style="width: 122px"><asp:Button ID="btnSsubmit" runat="server" Text="Submit" CssClass="btn btn-warning" OnClick="btnSsubmit_Click"/></td>
                    <td style="width: 141px">
                        <asp:Button ID="btnScancel" runat="server" Text="Cancel" CssClass="btn btn-primary"/></td>
                </tr>
                 <tr>
                    <td style="width: 122px">
                        <asp:Button ID="btnSupdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnSupdate_Click"/></td>
                    <td style="width: 141px">
                        <asp:Button ID="btnSdelete" runat="server" Text="Delete" CssClass="btn btn-primary" OnClick="btnSdelete_Click"/></td>
                </tr>
                 <tr>
                    <td style="width: 122px">
                        <asp:Button ID="btnSsearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSsearch_Click"/></td>
                    <td style="width: 141px">
                        <asp:TextBox ID="txtSsearch" runat="server" CssClass="txtbox"></asp:TextBox>
                     </td>
                </tr>
            </table>
                                    </div>
                     </div>
            </div>

    <!--data grid view-->
<div class="col-lg-6 col-md-6"  style="left:-2px; top:9px"">
    <p style="height: 57px">
        <asp:GridView ID="GridViewSchedule" runat="server" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateSelectButton="True" OnRowEditing="GridViewSchedule_RowEditing" OnSelectedIndexChanged="GridViewSchedule_SelectedIndexChanged" style="margin-top: 5px">
            </asp:GridView>
        <asp:GridView ID="GridViewSearch" runat="server">
        </asp:GridView>
    </p>
            
          

       
   
             
      

       
           
</div>
   
      
</asp:Content>
   