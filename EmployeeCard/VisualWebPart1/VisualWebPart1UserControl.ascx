<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1UserControl.ascx.cs" Inherits="EmployeeCard.VisualWebPart1.VisualWebPart1UserControl" %>
<link href="D:\Training Code\NewRepo\NeologixPortal\EmployeeCard\AddEmployeeCard\Stylesheet1.css" rel="stylesheet" />

<div>
  
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

      <br />
    <br />
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        
            <div  style="text-align:center;width:800px" >
            <asp:Label ID="ctl12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Larger" Text="Employee Child Details" ></asp:Label>
             </div>
            <br />
            <br />
              <div >
            <asp:Label ID="lbl_chd" runat="server" Text="Child Name"  Width="164px" ></asp:Label>
        
          
            <asp:Label ID="lbl_age" runat="server" Text="Child Age" Width="164px" ></asp:Label>
            </div> 
            <br />
           <div>
            <asp:TextBox ID="txt_chdname" runat="server"></asp:TextBox>
           
          
          <asp:TextBox ID="txt_chdage" runat="server" ></asp:TextBox>
         

            <asp:Button ID="btn_add" runat="server" OnClick="btn_add_Click" Text="Add"  />
                 </div>
            <br />
            <br />
            <asp:GridView ID="gv_child" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="gv_child_RowCancelingEdit" OnRowDeleting="gv_child_RowDeleting" OnRowEditing="gv_child_RowEditing" OnRowUpdating="gv_child_RowUpdating" Width="961px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                    <asp:BoundField DataField="Child Name" HeaderText="Child Name" />
                    <asp:BoundField DataField="Child Age" HeaderText="Child Age" />
                    <asp:CommandField ItemStyle-ForeColor="Red" ShowEditButton="True" />
                    <asp:CommandField ItemStyle-ForeColor="Red" ShowDeleteButton="True" />
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
        
            <br />
                  <div  style="text-align:center;width:800px" >
            <asp:Label ID="lbl_education" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Larger" Text="Educational Qualification"></asp:Label>
                  </div>
           
            <br />
            <br />
            
             <div >
            <asp:Label ID="lbl_qualif" runat="server" Text="Qualification" Width="164px" ></asp:Label>
           
            <asp:Label ID="lbl_schl" runat="server" Text="School/College" Width="164px" ></asp:Label>
              
           <asp:Label ID="lbl_uni" runat="server" Text="University" Width="166px" ></asp:Label>
         
         
            <asp:Label ID="lbl_yp" runat="server" Text="Year Of Passing" Width="168px"></asp:Label>
            
            
            <asp:Label ID="lbl_marks" runat="server" Text="Marks" Width="170px"></asp:Label>
             </div>  
            <br />
            <div>
            <asp:TextBox ID="txt_quali" runat="server"></asp:TextBox>
         
            <asp:TextBox ID="txt_school" runat="server"></asp:TextBox>
       
            <asp:TextBox ID="txt_uni" runat="server"></asp:TextBox>
        
            <asp:TextBox ID="txt_yop" runat="server"></asp:TextBox>
         
            <asp:TextBox ID="txt_marks" runat="server"></asp:TextBox>
        
            <asp:Button ID="btn_addedu" runat="server"  Text="Add" OnClick="btn_addedu_Click1" />
                </div>
            <br />
            <asp:GridView ID="gv_education" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="gv_education_RowCancelingEdit" OnRowDeleting="gv_education_RowDeleting" OnRowEditing="gv_education_RowEditing" OnRowUpdating="gv_education_RowUpdating" Width="961px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                    <asp:BoundField DataField="Qualification" HeaderText="Qualification" />
                    <asp:BoundField DataField="School/College" HeaderText="School/College" />
                    <asp:BoundField DataField="University" HeaderText="University" />
                    <asp:BoundField DataField="Year Of Passing" HeaderText="Year Of Passing" />
                    <asp:BoundField DataField="Marks" HeaderText="Marks" />
                    <asp:CommandField ItemStyle-ForeColor="Red" ShowEditButton="True" />
                    <asp:CommandField ItemStyle-ForeColor="Red" ShowDeleteButton="True" />
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
            <div>
            <asp:Label ID="Label2" runat="server" Text="Name"  Width="163px"></asp:Label>
        
            <asp:Label ID="lbl_from" runat="server" Text="Validity From"  Width="164px"></asp:Label>
           
            <asp:Label ID="lbl_valto" runat="server" Text="Validity To"  Width="164px"></asp:Label>
                </div>
            <br />
            <div>
            <asp:TextBox ID="txt_certname" runat="server"></asp:TextBox>
          
            <asp:TextBox ID="txt_valfrom" runat="server"></asp:TextBox>
           
            <asp:TextBox ID="txt_valto" runat="server"></asp:TextBox>
           
            <asp:Button ID="btn_certadd" runat="server" OnClick="btn_certadd_Click1" Text="Add" />
                </div>
            <br />
            <br />
            <asp:GridView ID="gv_certifications" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="gv_certifications_RowCancelingEdit" OnRowDeleting="gv_certifications_RowDeleting" OnRowEditing="gv_certifications_RowEditing" OnRowUpdating="gv_certifications_RowUpdating" Width="961px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Validity From" Dataformatstring="{0:d}" HeaderText="Validity From" />
                    <asp:BoundField DataField="Validity To" Dataformatstring="{0:d}" HeaderText="Validity To" />
                    <asp:CommandField ItemStyle-ForeColor="Red" ShowEditButton="True" />
                    <asp:CommandField ItemStyle-ForeColor="Red" ShowDeleteButton="True" />
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
            <div>
            <asp:Label ID="lbl_desig" runat="server" Text="Designation" Width="163px"></asp:Label>
         
            <asp:Label ID="lbl_company" runat="server" Text="Company" Width="163px"></asp:Label>
           <asp:Label ID="lbl_Tenurefrom" runat="server" Text="Tenure From" Width="163px"></asp:Label>
         
            <asp:Label ID="lbl_tenureto" runat="server" Text="Tenure To" Width="163px"></asp:Label>
         
            <asp:Label ID="lbl_tech" runat="server" Text="Technical Skill" Width="163px"></asp:Label>
           
            <asp:Label ID="lbl_fnlsal" runat="server" Text="Final Salary" Width="163px"></asp:Label>
                </div>
            <br />
            <div>
            <asp:TextBox ID="txt_desg" runat="server"></asp:TextBox>
           
            <asp:TextBox ID="txt_comp" runat="server"></asp:TextBox>
           <asp:TextBox ID="txt_tenurefrom" runat="server"></asp:TextBox>
           <asp:TextBox ID="txt_tenureto" runat="server"></asp:TextBox>
            <asp:TextBox ID="txt_skill" runat="server"></asp:TextBox>
            <asp:TextBox ID="txt_sal" runat="server"></asp:TextBox>
            <asp:Button ID="btn_careeradd" runat="server" OnClick="btn_careeradd_Click" Text="Add" />
                </div>
            <asp:GridView ID="gv_careers" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="gv_careers_RowCancelingEdit" OnRowDeleting="gv_careers_RowDeleting" OnRowEditing="gv_careers_RowEditing" OnRowUpdating="gv_careers_RowUpdating" Width="961px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                    <asp:BoundField DataField="Designation" HeaderText="Designation" />
                    <asp:BoundField DataField="Company" HeaderText="Company" />
                    <asp:BoundField DataField="Tenure From" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Tenure From" />
                    <asp:BoundField DataField="Tenure To" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Tenure To" />
                    <asp:BoundField DataField="Technical Skill" HeaderText="Technical Skill" />
                    <asp:BoundField DataField="Final salary" HeaderText="Final salary" />
                    <asp:CommandField ItemStyle-ForeColor="Red" ShowEditButton="True" />
                    <asp:CommandField ItemStyle-ForeColor="Red" ShowDeleteButton="True" />
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
         
            <br />
            <br />
              <div  style="text-align:center;width:800px" >
            <asp:Label ID="lbl_neoexp" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Larger" Text="Neo Experience"></asp:Label>

              </div>
            <br />
            <br />
            <div>
            <asp:Label ID="lbl_neodesg" runat="server" Text="Designation" Width="163px"></asp:Label>
         
            <asp:Label ID="lbl_neofrom" runat="server" Text="From" Width="163px"></asp:Label>
          
            <asp:Label ID="lbl_neoto" runat="server" Text="To" Width="163px"></asp:Label>
           
            <asp:Label ID="lbl_RO" runat="server" Text="Reporting Officer" Width="163px"></asp:Label>
                </div>
           
            <br />
            <div>
            <asp:TextBox ID="txt_neodesg" runat="server"></asp:TextBox>
           <asp:TextBox ID="txt_neofrom" runat="server"></asp:TextBox>
           <asp:TextBox ID="txt_neoto" runat="server"></asp:TextBox>
           <asp:TextBox ID="txt_neoRo" runat="server"></asp:TextBox>
            
            <asp:Button ID="btn_neoadd" runat="server" OnClick="btn_neoadd_Click1" Text="Add" />
                </div>
            <br />
            <asp:GridView ID="gv_neoexp" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="gv_neoexp_RowCancelingEdit" OnRowDeleting="gv_neoexp_RowDeleting" OnRowEditing="gv_neoexp_RowEditing" OnRowUpdating="gv_neoexp_RowUpdating" Width="961px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                    <asp:BoundField DataField="Designation" HeaderText="Designation" />
                    <asp:BoundField DataField="From" HeaderText="From" />
                    <asp:BoundField DataField="To" HeaderText="To" />
                    <asp:BoundField DataField="Reporting Officer" HeaderText="Reporting Officer" />
                    <asp:CommandField ItemStyle-ForeColor="Red" ShowEditButton="True" />
                    <asp:CommandField ItemStyle-ForeColor="Red" ShowDeleteButton="True" />
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
            <div>
            <asp:Label ID="lbl_stren" runat="server" Text="Strength" Width="163px"></asp:Label>
       
            <asp:Label ID="lbl_weak" runat="server" Text="Weakness" Width="163px"></asp:Label>
                </div>
            <br />
            <div>
            <asp:TextBox ID="txt_stren" runat="server"></asp:TextBox>
          <asp:TextBox ID="txt_weak" runat="server"></asp:TextBox>
          
            <asp:Button ID="btn_stenadd" runat="server" OnClick="btn_stenadd_Click" Text="Add" />
                </div>
            <asp:GridView ID="gv_strength" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="gv_strength_RowCancelingEdit" OnRowDeleting="gv_strength_RowDeleting" OnRowEditing="gv_strength_RowEditing" OnRowUpdating="gv_strength_RowUpdating" Width="961px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                    <asp:BoundField DataField="Strength" HeaderText="Strength" />
                    <asp:BoundField DataField="Weakness" HeaderText="Weakness" />
                    <asp:CommandField ItemStyle-ForeColor="Red" ShowEditButton="True" />
                    <asp:CommandField ItemStyle-ForeColor="Red" ShowDeleteButton="True" />
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
            <br />
          <br />
        </ContentTemplate>
    </asp:UpdatePanel>
   
    <br />
  <br />
    <div>
    <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="Save" />
   
    <br />
  <asp:Label ID="lbl_alert" runat="server" Text="Alert"></asp:Label>
        </div>
   <br />
    <br />
</div>
<p>
    &nbsp;
</p>