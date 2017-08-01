using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;

namespace EmployeeCard.EmployeeList
{
    [ToolboxItemAttribute(false)]
    public partial class EmployeeList : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public EmployeeList()
        {

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindReapter();
            }


        }

        private void BindReapter()
        {
            string siteURL = SPContext.Current.Site.Url.ToString() + "/HR";
            using (SPSite site = new SPSite(siteURL))
            {
                using (SPWeb web = SPContext.Current.Web)
                {
               
                    SPList PDlist = web.Lists["Personal Details"];
                    SPListItemCollection items =PDlist.GetItems();

                    rptEmployees.DataSource = items.GetDataTable();
                    rptEmployees.DataBind();
                    
                  }
              }
         }
     }
}
