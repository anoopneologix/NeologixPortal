using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Data;
using System.Web.UI.WebControls.WebParts;

namespace EmployeeCard.AddEmployeeCard
{
    [ToolboxItemAttribute(false)]
    public partial class AddEmployeeCard : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public AddEmployeeCard()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

   protected void Page_Load(object sender, EventArgs e)
        {

            string siteURL = SPContext.Current.Site.Url.ToString() + "/HR";
            using (SPSite site = new SPSite(siteURL))
            {

                using (SPWeb web = SPContext.Current.Web)

               
         
                    
                    
                    childgv(web);
                   





            }
          }

    private void childgv(SPWeb web)
         {
              SPList CDlist = web.Lists["Employee Child Details"];
              SPQuery CDquery = new SPQuery();
              CDquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
              //  SPListItemCollection cditems = CDlist.Items;

              SPListItemCollection newcditems = CDlist.GetItems(CDquery);
              DataSet ds = new DataSet();
              DataTable dt = new DataTable();
              dt.Columns.Add("ID");
              dt.Columns.Add("Child Name");
              dt.Columns.Add("Child Age");

              foreach (SPListItem item in newcditems)
              {
                  DataRow dr = dt.NewRow();

                  dr[0] = item["ID"].ToString();
                  dr[1] = item["Child Name"].ToString();
                  dr[2] = item["Child Age"].ToString();


                  dt.Rows.Add(dr);
              }

              ds.Tables.Add(dt);
              gv_child.DataSource = ds;
              gv_child.DataBind();
          }

     
      
        protected void btn_Save_Click(object sender, EventArgs e)
        {

            SPWeb web = SPContext.Current.Web;
            SPList PDlist = web.Lists["Personal Details"];
            SPQuery PDquery = new SPQuery();
            PDquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
            //SPListItemCollection items = PDlist.Items;
            SPListItemCollection newitems = PDlist.GetItems(PDquery);
            SPListItem item = PDlist.Items.Add();
            item["Employee Id"] = txt_id.Text;
            item["Name"] = txt_name.Text;
            item["DOJ"] = dp_doj.SelectedDate;
            item["Blood GP"] = txt_blood.Text;
            item["DOB"] = dtcDoB.SelectedDate;
            item["Pan card"] = txt_pancard.Text;
            item["OfficialEmail"] = txt_officialemail.Text;
            item["PersonalEmail"] = txt_personalemail.Text;
            item["Mobile No"] = txt_mobno.Text;
            item["Permanent Address"] = txt_permantaddr.Text;
            item["Current Address"] = txt_current.Text;
            item["Emergency Contact No"] = txt_emercontactno.Text;
            item["Residence No"] = txt_residenceno.Text;
            item["Father's Name"] = txt_father.Text;
            item["Mother's Name"] = txt_mothernam.Text;
            if (rdbtn_single.Checked == true)
            {
                item["Marital status"] = "Single";
            }
            else
            {
                item["Marital status"] = "Married";
            }

            item["Marriage Anniversary"] = dtc_marriageanniversary.SelectedDate;
            item["Spouse Name"] = txt_spousename.Text;
            item["Spouse DOB"] = dtcspouseDoB.SelectedDate;
            item["Spouse Designation"] = txt_spousedesignation.Text;
            item["Spouse Organisation"] = txt_spousedesignation.Text;
            item.Update();


                }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_id.Text = string.Empty;
            txt_name.Text = string.Empty;

            //   dp_doj.SelectedDate = dp_doj.
            txt_blood.Text = string.Empty;
            //     dtcDoB.SelectedDate = string.Empty;
            txt_pancard.Text = string.Empty;
            txt_officialemail.Text = string.Empty;
            txt_personalemail.Text = string.Empty;
            txt_mobno.Text = string.Empty;
            txt_permantaddr.Text = string.Empty;
            txt_current.Text = string.Empty;
            txt_emercontactno.Text = string.Empty;
            txt_residenceno.Text = string.Empty;
            txt_father.Text = string.Empty;
            txt_mothernam.Text = string.Empty;
            //     rdbtn_single.Checked == string.Empty;


            //  dtc_marriageanniversary.SelectedDate = string.Empty; ;
            txt_spousename.Text = string.Empty; ;
            //   dtcspouseDoB.SelectedDate = string.Empty; ;
            txt_spousedesignation.Text = string.Empty; ;
            txt_spousedesignation.Text = string.Empty; 
        }
           
    
    }
       
}


 