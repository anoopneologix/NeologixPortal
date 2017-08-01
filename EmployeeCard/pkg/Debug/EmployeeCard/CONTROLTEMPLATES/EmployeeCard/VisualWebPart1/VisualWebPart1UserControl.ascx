<%@ Assembly Name="EmployeeCard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9c4eb3fbf2b0fc9a" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1UserControl.ascx.cs" Inherits="EmployeeCard.VisualWebPart1.VisualWebPart1UserControl" %>
<link href="D:\Training Code\NewRepo\NeologixPortal\EmployeeCard\AddEmployeeCard\Stylesheet1.css" rel="stylesheet" />

<div>
  
    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" style="margin-left: 162px" />
    <br />
    <br />
  <div style="text-align:center;width:800px">
    <asp:Label ID="lbl_PersonalDetails" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="False" Text="Personal Details" Font-Size="Larger"  CssClass="Label"></asp:Label>
 
       </div>
       <table style="width: 100%;">
        <tr>
            <td colspan="2">

                <asp:Label ID="lbl_id" runat="server" Text="Employee Id" CssClass="label"></asp:Label>
               
             <div style="float: right;width:400px">  
                <asp:TextBox ID="txt_id" runat="server" ></asp:TextBox>

              </div>
                <br />
                <br />
                <asp:Label ID="lbl_name" runat="server" Text="Name" CssClass="label"></asp:Label>
             
             <div style="float: right;width:400px">  
                <asp:TextBox ID="txt_name" runat="server" CssClass="textbox"></asp:TextBox>
                    
             </div >  
                <br />
                <br />
                <asp:Label ID="lbl_doj" runat="server" Text="DOJ"></asp:Label>
                  <div style="float: right;width:400px">
              <SharePoint:DateTimeControl ID="dp_doj" runat="server" DateOnly="True"   />
                   </div>
     
                <br />
                <br />
                <asp:Label ID="lbl_bloodgp" runat="server" Text="Blood GP"></asp:Label>
             
                 <div style="float: right;width:400px">
               <asp:TextBox ID="txt_blood" runat="server" Style="text-align: center"></asp:TextBox>
                  </div>
                <br />
                <br />
                <asp:Label ID="lbl_dob" runat="server" Text="DOB"></asp:Label>
                 <div style="float: right;width:400px">
               <SharePoint:DateTimeControl ID="dtcDoB" runat="server" DateOnly="True" />
                   </div>
                <br />
                <br />
                <asp:Label ID="lbl_pancard" runat="server" Text="Pan Card" Style="text-align: center"></asp:Label>
              <div style="float: right;width:400px">
                <asp:TextBox ID="txt_pancard" runat="server"></asp:TextBox>
                     </div>
                <br />
                <br />
                <asp:Label ID="lbl_officialemail" runat="server" Text="OfficialEmail"></asp:Label>
             
                  <div style="float: right;width:400px">
                 <asp:TextBox ID="txt_officialemail" runat="server" Style="text-align: center"></asp:TextBox>
                      </div>
                <br />
              
                <br />
                <asp:Label ID="lbl_personalemail" runat="server" Text="PersonalEmail"></asp:Label>
              <div style="float: right;width:400px">
    <asp:TextBox ID="txt_personalemail" runat="server" Style="text-align: center"></asp:TextBox>
                   </div>
                <br />
                <br />
                <asp:Label ID="lbl_permanentaddr" runat="server" Text="Permanent Address"></asp:Label>
                 
                <div style="float: right;width:400px">
        <asp:TextBox ID="txt_permantaddr" runat="server" TextMode="MultiLine" Width="177px"></asp:TextBox>
                </div>
                <br />
                <br />
                <br/>
                <asp:Label ID="lbl_currentaddr" runat="server" Text="Current Address"></asp:Label>
                 <div style="float: right;width:400px">
                <asp:TextBox ID="txt_current" runat="server" TextMode="MultiLine" Width="179px"></asp:TextBox>
                 </div>
                <br />
                <br />
            </td>
            <td>


                <br />
                <asp:Label ID="lbl_mobno" runat="server" Text="Mobile No"></asp:Label>
              <div style="float: right;width:400px">
    <asp:TextBox ID="txt_mobno" runat="server"  Style="margin-bottom: 0px"></asp:TextBox>
                   </div>
                <br />
                <br />
                <asp:Label ID="lbl_emercontact" runat="server" Text="Emergency Contact No"></asp:Label>
                <div style="float: right;width:400px">
    <asp:TextBox ID="txt_emercontactno" runat="server" Style="text-align: center"></asp:TextBox>
                 </div>
                <br />
                <br />
                <asp:Label ID="lbl_residenceno" runat="server" Text="Residence No"></asp:Label>
                  <div style="float: right;width:400px">
    <asp:TextBox ID="txt_residenceno" runat="server" Style="text-align: center"></asp:TextBox>
                  </div>
                <br />
                <br />


                <asp:Label ID="lbl_father" runat="server" Text="Father's Name"></asp:Label>
                <div style="float: right;width:400px">
    <asp:TextBox ID="txt_father" runat="server" Style="text-align: center"></asp:TextBox>
              </div>
                <br />
          
                <br />
                <asp:Label ID="lbl_mothername" runat="server" Text="Mother's Name"></asp:Label>
                   <div style="float: right;width:400px">
    <asp:TextBox ID="txt_mothernam" runat="server" Style="text-align: center"></asp:TextBox>
                       </div>
                <br />
                <br />
                <asp:Label ID="lbl_maritalstatus" runat="server" Text="Marital Status"></asp:Label>
                  <div style="float: right;width:400px">
    <asp:RadioButton ID="rdbtn_single" runat="server" Text="Single" GroupName="maritalstatus" />
                &nbsp;
    <asp:RadioButton ID="rdbtn_married" runat="server"  Text="Married" GroupName="maritalstatus" />
                    </div>
                <br />
                <br />
                <asp:Label ID="lbl_marriage" runat="server" Text="Marriage Anniversary"></asp:Label>
                   <div style="float: right;width:400px">
                <SharePoint:DateTimeControl ID="dtc_marriageanniversary" runat="server" DateOnly="True" />
                    </div>
                <br />
                <br />
                <asp:Label ID="lbl_spousename" runat="server" Text="Spouse Name"></asp:Label>
                   <div style="float: right;width:400px">
    <asp:TextBox ID="txt_spousename" runat="server" Style="text-align: center"></asp:TextBox>
                         </div>
                <br />
                <br />
                <asp:Label ID="lbl_spousedob" runat="server" Text="Spouse DOB"></asp:Label>
                   <div style="float: right;width:400px">
                <SharePoint:DateTimeControl ID="dtcspouseDoB" runat="server" DateOnly="True" />
                         </div>
                <br />
                <br />
                <asp:Label ID="lbl_spousedesignation" runat="server" Text="Spouse Designation"></asp:Label>
                  <div style="float: right;width:400px">
    <asp:TextBox ID="txt_spousedesignation" runat="server" Style="text-align: center"></asp:TextBox>
                        </div>
                <br />
                <br />
                <asp:Label ID="lbl_spouseorganisation" runat="server" Text="Spouse Organisation"></asp:Label>
                  <div style="float: right;width:400px">
    <asp:TextBox ID="txt_spouseorganisation" runat="server" Style="text-align: center"></asp:TextBox>
                        </div>
                <br />
                <br />
            </td>

        </tr>

    </table>
  
    <br />

    <br />
       <div  style="text-align:center;width:800px" >
    <asp:Label runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Larger" Text="Employee Child Details" ID="ctl12"></asp:Label>
           </div>
    <br />
  
    <br />
   
    <br />
  
     <asp:GridView ID="gv_child" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="961px" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCancelingEdit="gv_child_RowCancelingEdit" OnRowDeleting="gv_child_RowDeleting" OnRowEditing="gv_child_RowEditing" OnRowUpdating="gv_child_RowUpdating" >
       
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
         <Columns>
             <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
             <asp:BoundField DataField="Child Name" HeaderText="Child Name" />
             <asp:BoundField DataField="Child Age" HeaderText="Child Age" />
             <asp:CommandField ShowEditButton="True"   ItemStyle-ForeColor="Red" />
             <asp:CommandField ShowDeleteButton="True"   ItemStyle-ForeColor="Red" />
         </Columns>
        <EditRowStyle BackColor="#FF0000" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <br />
    <br />
 <div  style="text-align:center;width:800px" >
    <asp:Label ID="lbl_education" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Larger" Text="Educational Qualification"></asp:Label>
      </div>
    <br />
    <br />
    <br />
    &nbsp;<asp:GridView ID="gv_education" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="976px" AutoGenerateColumns="False" OnRowCancelingEdit="gv_education_RowCancelingEdit" OnRowDeleting="gv_education_RowDeleting" OnRowEditing="gv_education_RowEditing" OnRowUpdating="gv_education_RowUpdating" DataKeyNames="ID" OnSelectedIndexChanged="gv_education_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
            <asp:BoundField DataField="Qualification" HeaderText="Qualification" />
            <asp:BoundField DataField="School/College" HeaderText="School/College" />
            <asp:BoundField DataField="University" HeaderText="University" />
<asp:BoundField DataField="Year Of Passing" HeaderText="Year Of Passing"></asp:BoundField>
            <asp:BoundField DataField="Marks" HeaderText="Marks" />
            <asp:CommandField ShowEditButton="True"  ItemStyle-ForeColor="Red"/>
            <asp:CommandField ShowDeleteButton="True" ItemStyle-ForeColor="Red"/>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <br />
    <br />
 <div  style="text-align:center;width:800px" >
    <asp:Label ID="lbl_certification" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Larger" Text="Certifications"></asp:Label>
      </div>
    <br />
    <br />
    <br />
   <br />
    <asp:GridView ID="gv_certifications" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="982px" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCancelingEdit="gv_certifications_RowCancelingEdit" OnRowDeleting="gv_certifications_RowDeleting" OnRowEditing="gv_certifications_RowEditing" OnRowUpdating="gv_certifications_RowUpdating">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Validity From" HeaderText="Validity From" Dataformatstring="{0:d}"/>
            <asp:BoundField DataField="Validity To" HeaderText="Validity To"  Dataformatstring="{0:d}" />
            <asp:CommandField ShowEditButton="True" ItemStyle-ForeColor="Red"/>
            <asp:CommandField ShowDeleteButton="True"  ItemStyle-ForeColor="Red"/>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <br />
     <div  style="text-align:center;width:800px" >
    <asp:Label ID="lbl_careers" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Larger" Text="Careers"></asp:Label>
          </div>
    <br />
    <br />
    <br />
  
    <asp:GridView ID="gv_careers" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="986px" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCancelingEdit="gv_careers_RowCancelingEdit" OnRowDeleting="gv_careers_RowDeleting" OnRowEditing="gv_careers_RowEditing" OnRowUpdating="gv_careers_RowUpdating">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
            <asp:BoundField DataField="Designation" HeaderText="Designation" />
            <asp:BoundField DataField="Company" HeaderText="Company" />
            <asp:BoundField DataField="Tenure From" HeaderText="Tenure From"  DataFormatString="{0:MM/dd/yyyy}"/>
            <asp:BoundField DataField="Tenure To" HeaderText="Tenure To"  DataFormatString="{0:MM/dd/yyyy}"/>
            <asp:BoundField DataField="Technical Skill" HeaderText="Technical Skill" />
            <asp:BoundField DataField="Final salary" HeaderText="Final salary" />
            <asp:CommandField ShowEditButton="True"  ItemStyle-ForeColor="Red"/>
            <asp:CommandField ShowDeleteButton="True"  ItemStyle-ForeColor="Red"/>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <br />
 <div  style="text-align:center;width:800px" >
    <asp:Label ID="lbl_neoexp" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Larger" Text="Neo Experience"></asp:Label>
      </div>
    <br />
    <br />
    <asp:GridView ID="gv_neoexp" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" ForeColor="#333333" GridLines="None" Width="985px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
            <asp:BoundField DataField="Designation" HeaderText="Designation" />
            <asp:BoundField DataField="From" HeaderText="From"/>
            <asp:BoundField DataField="To" HeaderText="To" />
            <asp:BoundField DataField="Reporting Officer" HeaderText="Reporting Officer" />
            <asp:CommandField ShowEditButton="True" ItemStyle-ForeColor="Red"/>
            <asp:CommandField ShowDeleteButton="True" ItemStyle-ForeColor="Red"/>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <br />
   <br />
    <br />
      <div  style="text-align:center;width:800px" >
          <asp:Label ID="lbl_streweak" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Larger" Text="Strengths And Weakness"></asp:Label>
      </div>
    <br />
    <br />
    <asp:GridView ID="gv_strength" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="992px" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCancelingEdit="gv_strength_RowCancelingEdit" OnRowDeleting="gv_strength_RowDeleting" OnRowEditing="gv_strength_RowEditing" OnRowUpdating="gv_strength_RowUpdating">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
            <asp:BoundField DataField="Strength" HeaderText="Strength" />
            <asp:BoundField DataField="Weakness" HeaderText="Weakness" />
            <asp:CommandField ShowEditButton="True"  ItemStyle-ForeColor="Red"/>
            <asp:CommandField ShowDeleteButton="True" ItemStyle-ForeColor="Red"/>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <br />
    <br />
</div>
<p>
    &nbsp;
</p>

