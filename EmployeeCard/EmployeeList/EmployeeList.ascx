﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeList.ascx.cs" Inherits="EmployeeCard.EmployeeList.EmployeeList" %>




<div>

    <a href='HR/SitePages/AddEmployeeCard.aspx?empid=<%# Eval("Employee_x0020_Id") %>'> 
    <asp:Button ID="btn_add" runat="server" OnClick="btn_add_Click" Text="Add" />
    </a>

</div>
<p>
    <br />
     
</p>
<asp:Repeater ID="rptEmployees" runat="server">
  <HeaderTemplate>
        <table <%--cellspacing="0" rules="all"--%> border="1">
            <tr>
                <th scope="col" style="width: 80px">
                   Employee Id
                </th>
                <th scope="col" style="width: 120px">
                     Name
                </th>
              
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
       
      <tr>
         <td> 
               <a href='/HR/sitepages/Employee%20Card.aspx?empid=<%# Eval("Employee_x0020_Id") %>'>  <asp:Label ID="lblEmployeeId" runat="server" Text='<%# Eval("Employee_x0020_Id") %>' />
           </a>
            </td>
               
            <td>
                <a href='/HR/sitepages/Employee%20Card.aspx?empid=<%# Eval("Employee_x0020_Id") %>'>  <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' /> </a>
            </td>
       </tr>
        
        </ItemTemplate>
       <FooterTemplate>
      </table>
    </FooterTemplate>
 </asp:Repeater>

