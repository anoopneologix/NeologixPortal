using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Data;
using System.Web.UI.WebControls;
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

            //string siteURL = SPContext.Current.Site.Url.ToString() + "/HR";
            //using (SPSite site = new SPSite(siteURL))
            //{

            //    using (SPWeb web = SPContext.Current.Web)

               
         
            //   }

            
                 if (!Page.IsPostBack)
                   {
                        SetInitialRow();
                         EducationGv();
                         CertificationGv();
                         CareerGv();
                         NeoGv();
                         StrenGv();
                    }
               

          }

     
        protected void btn_Save_Click(object sender, EventArgs e)
        {   
            int flag=0;
            SPWeb web = SPContext.Current.Web;
            SPQuery PDquery = new SPQuery();
            SPList PDlist = web.Lists["Personal Details"];
            PDquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
            SPListItemCollection newitems = PDlist.GetItems(PDquery);
            //  SPListItem items = PDlist.Items.Add();
            foreach (SPListItem item in newitems)
             {

                string id = item["Employee Id"].ToString();

                if(string.Compare(id,txt_id.Text)==0)
                 {
                  flag=1;
                 }
             }

            if (flag == 1)
              {

               lbl_alert.Text="The item already exist in the list";
              
              }
            else
            {
                SavePersonalDetails();
                SaveChildDetails();
                SaveEducationQualif();
                SaveCertifications();
                SaveCareers();
                SaveNeoExp();
                SavePersonality();

                lbl_alert.Text = "Saved Succefully";

                ClearDetails();
            }
        }

        private void ClearDetails()
        {
            txt_id.Text = "";
            txt_name.Text = "";
    

            dp_doj.SelectedDate = new DateTime();
            txt_blood.Text = "";
            dtcDoB.SelectedDate = new DateTime();
            txt_pancard.Text = "";
            txt_officialemail.Text = "";
            txt_personalemail.Text = "";
            txt_officialemail.Text = "";
            txt_mobno.Text = "";
            txt_permantaddr.Text = "";
            txt_current.Text = "";
            txt_emercontactno.Text = "";
            txt_residenceno.Text = "";
            txt_father.Text = "";
            txt_mothernam.Text = "";
            txt_residenceno.Text = "";
          
          //  rdbtn_single.Checked = "";
           // rdbtn_married.Checked = "";
           dtc_marriageanniversary.SelectedDate = new DateTime();
            txt_spousename.Text = "";
            dtcspouseDoB.SelectedDate = new DateTime();
            txt_spousedesignation.Text = "";
            txt_spouseorganisation.Text = "";

            
            
            gv_child.Columns.Clear();
            gv_education.Columns.Clear();
            gv_certifications.Columns.Clear();
            gv_careers.Columns.Clear();
            gv_neoexp.Columns.Clear();
            gv_strength.Columns.Clear();
            
        }

        private void SavePersonalDetails()
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


      
        private void SavePersonality()
        {
            SPWeb web = SPContext.Current.Web;
            SPList SWlist = web.Lists["Strengths And Weakness"];
            SPListItemCollection switems = SWlist.Items;
            SPListItem item7 = SWlist.Items.Add();
            for (int i = 0; i < gv_strength.Rows.Count; i++)
            {
                item7["Employee Id"] = txt_id.Text;
                GridViewRow row = gv_strength.Rows[i];
                item7["Strength"] = row.Cells[1].Text;
                item7["Weakness"] = row.Cells[2].Text;

            }

            item7.Update();

        }

        private void SaveNeoExp()
        {
            SPWeb web = SPContext.Current.Web;
            SPList NEOlist = web.Lists["Neo Experience"];
            SPListItemCollection neoitems = NEOlist.Items;
            SPListItem item6 = NEOlist.Items.Add();
            for (int i = 0; i < gv_neoexp.Rows.Count; i++)
            {
                item6["Employee Id"] = txt_id.Text;
                GridViewRow row = gv_neoexp.Rows[i];
                item6["Designation"] = row.Cells[1].Text;
              //  item6["From"] = row.Cells[2].Text;

                DateTime valFrom = Convert.ToDateTime(row.Cells[2].Text);
                //item4["Validity From"] = valFrom.ToShortDateString();
                item6["From"] = valFrom.Date;


               // item6["To"] = row.Cells[3].Text;
                DateTime valFrom2 = Convert.ToDateTime(row.Cells[3].Text);
               
                item6["To"] = valFrom2.Date;
                item6["Reporting Officer"] = row.Cells[4].Text;

            }

            item6.Update();
        }

        private void SaveCareers()
        {
            SPWeb web = SPContext.Current.Web;
            SPList CRlist = web.Lists["Careers"];
            SPListItemCollection critems = CRlist.Items;
            SPListItem item5 = CRlist.Items.Add();
            for (int i = 0; i < gv_careers.Rows.Count; i++)
              {
                item5["Employee Id"] = txt_id.Text;
                GridViewRow row = gv_careers.Rows[i];
                item5["Designation"] = row.Cells[1].Text;
                item5["Company"] = row.Cells[2].Text;
                //DateTime valFrom = Convert.ToDateTime(row.Cells[3].ToString());
                //item5["Tenure From"] = valFrom.ToShortDateString();

                DateTime valFrom = Convert.ToDateTime(row.Cells[3].Text);
                //item4["Validity From"] = valFrom.ToShortDateString();
                item5["Tenure From"] = valFrom.Date;
                
                //item5["Tenure From"] = row.Cells[3].Text;

              //   DateTime valFrom2 = Convert.ToDateTime(row.Cells[4].ToString());
                   
                  DateTime valFrom2 = Convert.ToDateTime(row.Cells[4].Text);
                // item5["Tenure To"] = valFrom2.ToShortDateString();
                item5["Tenure To"] = valFrom2.Date;
                //item5["Tenure To"] = row.Cells[4].Text;
                item5["Technical Skill"] = row.Cells[5].Text;
                item5["Final salary"] = row.Cells[6].Text;

               }
            item5.Update();
         }

        private void SaveCertifications()
        {
            SPWeb web = SPContext.Current.Web;
            SPList CTlist = web.Lists["Certifications"];
            SPListItemCollection ctitems = CTlist.Items;
            SPListItem item4 = CTlist.Items.Add();
            for (int i = 0; i < gv_certifications.Rows.Count; i++)
            {
                item4["Employee Id"] = txt_id.Text;
                GridViewRow row = gv_certifications.Rows[i];
                item4["Name"] = row.Cells[1].Text;

           
                //DateTime valFrom = Convert.ToDateTime(row.Cells[2].ToString());
                
                DateTime valFrom = Convert.ToDateTime(row.Cells[2].Text);
                //item4["Validity From"] = valFrom.ToShortDateString();
                item4["Validity From"] = valFrom.Date;
                

               //  item4["Validity From"] = row.Cells[2].Text;

               // DateTime valFrom2 = Convert.ToDateTime(row.Cells[3].ToString());

                DateTime valFrom2 = Convert.ToDateTime(row.Cells[3].Text);
               //item4["Validity To"] = valFrom2.ToShortDateString();
                item4["Validity To"] = valFrom2.Date;
              //item4["Validity To"] = row.Cells[3].Text;
               
            }
            item4.Update();
        }

        private void SaveEducationQualif()
        {
            SPWeb web = SPContext.Current.Web;
            SPList EQlist = web.Lists["Educational Qualifications"];
            SPListItemCollection eqitems = EQlist.Items;
            SPListItem item3 = EQlist.Items.Add();

            for (int i = 0; i < gv_education.Rows.Count; i++)
            {
                item3["Employee Id"] = txt_id.Text;
                GridViewRow row = gv_education.Rows[i];
                item3["Qualification"] = row.Cells[1].Text;
                item3["School/College"] = row.Cells[2].Text;
                item3["University"] = row.Cells[3].Text;
                item3["Year Of Passing"] = row.Cells[4].Text;
                item3["Marks"] = row.Cells[5].Text;

            }
            item3.Update();
        }

        private void SaveChildDetails()
        {
            SPWeb web = SPContext.Current.Web;
            SPList CDlist = web.Lists["Employee Child Details"];
            SPListItemCollection newcditems = CDlist.Items;
            SPListItem item2 = CDlist.Items.Add();


            for (int i = 0; i < gv_child.Rows.Count; i++)
            {
                item2["Employee Id"] = txt_id.Text;
                GridViewRow row = gv_child.Rows[i];
                item2["Child Name"] = row.Cells[1].Text;
                item2["Child Age"] = row.Cells[2].Text;
            }
            item2.Update();
           
        }


        private void SetInitialRow()
        {

            SPWeb web = SPContext.Current.Web;
            SPList CDlist = web.Lists["Employee Child Details"];

            DataTable dtSource1 = new DataTable();

            // DataRow dr = dtSource.NewRow();
            //   DataRow dr =null;
            dtSource1.Columns.Add("ID");
            dtSource1.Columns.Add("Child Name");
            dtSource1.Columns.Add("Child Age");

            //   dtSource.Rows.Add(dr);

            ViewState["dtSource1"] = dtSource1;


            gv_child.DataSource = dtSource1;
            gv_child.DataBind();

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {

            DataTable dtSource1 = ViewState["dtSource1"] as DataTable;
            DataRow dr = dtSource1.NewRow();

            dr["ID"] = txt_id.Text;
            dr["Child Name"] = txt_chdname.Text;
            dr["Child Age"] = txt_chdage.Text;
            dtSource1.Rows.Add(dr);


            gv_child.DataSource =  dtSource1;
            gv_child.DataBind();

            clear();
        
        }

        private void clear()
        {
            txt_chdname.Text = "";
            txt_chdage.Text = "";

        }


    
        protected void gv_child_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {

            SPWeb web = SPContext.Current.Web;
            DataTable dtSource1 = ViewState["dtSource1"] as DataTable;
            gv_child.EditIndex = -1;
            gv_child.DataSource = dtSource1;
            gv_child.DataBind();
        }

        protected void gv_child_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {

            //GridViewRow row = (GridViewRow)gv_child.Rows[e.RowIndex];
            //int Child = row.DataItemIndex;
            int Child = Convert.ToInt32(e.RowIndex);
             DataTable dtSource1 = ViewState["dtSource1"] as DataTable;
            DataRow dr = dtSource1.NewRow();
            dtSource1.Rows[Child].Delete();
           // ViewState["dtSource"] = dtSource;
           // SetInitialRow();
            gv_child.DataSource = dtSource1;
            gv_child.DataBind();
        }

        protected void gv_child_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource1 = ViewState["dtSource1"] as DataTable;
            gv_child.EditIndex = e.NewEditIndex;
            gv_child.DataSource = dtSource1;
            gv_child.DataBind();

        }

        protected void gv_child_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

          

            GridViewRow row = gv_child.Rows[e.RowIndex];
            
            int childindex = row.DataItemIndex;

          

            string name = (row.Cells[1].Controls[0] as TextBox).Text;
            string age = (row.Cells[2].Controls[0] as TextBox).Text;
            DataTable dtSource1 = ViewState["dtSource1"] as DataTable;
            dtSource1.Rows[row.RowIndex]["Child Name"] = name;
            dtSource1.Rows[row.RowIndex]["Child Age"] = age;
            //ViewState["dtSource"] = dtSource;
            gv_child.EditIndex = -1;
            gv_child.DataSource = dtSource1;
            gv_child.DataBind();

        }



        private void EducationGv()
        {
            DataTable dtSource2 = new DataTable();


            dtSource2.Columns.Add("ID");
            dtSource2.Columns.Add("Qualification");
            dtSource2.Columns.Add("School/College");
            dtSource2.Columns.Add("University");
            dtSource2.Columns.Add("Year Of Passing");
            dtSource2.Columns.Add("Marks");

            ViewState["dtSource2"] = dtSource2;

            gv_education.DataSource = dtSource2;
            gv_education.DataBind();
        }
        protected void btn_addedu_Click1(object sender, EventArgs e)
        {


            DataTable dtSource2 = ViewState["dtSource2"] as DataTable;

            DataRow dr = dtSource2.NewRow();


            dr["ID"] = txt_id.Text;
            dr["Qualification"] = txt_quali.Text;
            dr["School/College"] = txt_school.Text;
            dr["University"] = txt_uni.Text;
            dr["Year Of Passing"] = txt_yop.Text;
            dr["Marks"] = txt_marks.Text;
            dtSource2.Rows.Add(dr);
            gv_education.DataSource = dtSource2;
            gv_education.DataBind();

            clearedu();
        }

        private void clearedu()
        {
            txt_quali.Text = "";
            txt_school.Text = "";
            txt_uni.Text = "";
            txt_yop.Text = "";
            txt_marks.Text = "";

        }


        protected void gv_education_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource2 = ViewState["dtSource2"] as DataTable;
            gv_education.EditIndex = -1;
            gv_education.DataSource = dtSource2;
            gv_education.DataBind();
        }

        protected void gv_education_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Qualif = Convert.ToInt32(e.RowIndex);
            DataTable dtSource2 = ViewState["dtSource2"] as DataTable;
            DataRow dr = dtSource2.NewRow();
            dtSource2.Rows[Qualif].Delete();
            // ViewState["dtSource"] = dtSource;
            // SetInitialRow();
            gv_education.DataSource = dtSource2;
            gv_education.DataBind();


        }

       protected void gv_education_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource2 = ViewState["dtSource2"] as DataTable;
            gv_education.EditIndex = e.NewEditIndex;
            gv_education.DataSource = dtSource2;
            gv_education.DataBind();

        }

        protected void gv_education_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gv_education.Rows[e.RowIndex];
          
            string quali = (row.Cells[1].Controls[0] as TextBox).Text;
            string sch = (row.Cells[2].Controls[0] as TextBox).Text;
            string univ = (row.Cells[3].Controls[0] as TextBox).Text;
            string yop = (row.Cells[4].Controls[0] as TextBox).Text;
            string marks = (row.Cells[5].Controls[0] as TextBox).Text;
                    
            DataTable dtSource2 = ViewState["dtSource2"] as DataTable;
            dtSource2.Rows[row.RowIndex]["Qualification"] = quali;
            dtSource2.Rows[row.RowIndex]["School/College"] = sch;
            dtSource2.Rows[row.RowIndex]["University"] = univ;
            dtSource2.Rows[row.RowIndex]["Year Of Passing"] = yop;
            dtSource2.Rows[row.RowIndex]["Marks"] = marks;
        
       
            gv_education.EditIndex = -1;
            gv_education.DataSource = dtSource2;
            gv_education.DataBind();
        }

        

       

     


     private void CertificationGv()
        {
            DataTable dtSource3 = new DataTable();

       
            dtSource3.Columns.Add("ID");
            dtSource3.Columns.Add("Name");
            dtSource3.Columns.Add("Validity From");
            dtSource3.Columns.Add("Validity To");
          

            ViewState["dtSource3"] = dtSource3;

            gv_certifications.DataSource = dtSource3;
            gv_certifications.DataBind();
        }

        protected void gv_certifications_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource3 = ViewState["dtSource3"] as DataTable;
            gv_certifications.EditIndex = -1;
            gv_certifications.DataSource = dtSource3;
            gv_certifications.DataBind();
        }

        protected void gv_certifications_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Certif = Convert.ToInt32(e.RowIndex);
            DataTable dtSource3 = ViewState["dtSource3"] as DataTable;
            DataRow dr = dtSource3.NewRow();
            dtSource3.Rows[Certif].Delete();
            // ViewState["dtSource"] = dtSource;
            // SetInitialRow();
            gv_certifications.DataSource = dtSource3;
            gv_certifications.DataBind();
        }

        protected void gv_certifications_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource3 = ViewState["dtSource3"] as DataTable;
            gv_certifications.EditIndex = e.NewEditIndex;
            gv_certifications.DataSource = dtSource3;
            gv_certifications.DataBind();
        }

        protected void gv_certifications_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gv_certifications.Rows[e.RowIndex];

            string name = (row.Cells[1].Controls[0] as TextBox).Text;
            string from = (row.Cells[2].Controls[0] as TextBox).Text;
            string to= (row.Cells[3].Controls[0] as TextBox).Text;
           

            DataTable dtSource3 = ViewState["dtSource3"] as DataTable;
            dtSource3.Rows[row.RowIndex]["Name"] = name;
            dtSource3.Rows[row.RowIndex]["Validity From"] = from;
            dtSource3.Rows[row.RowIndex]["Validity To"] = to;
          


            gv_certifications.EditIndex = -1;
            gv_certifications.DataSource = dtSource3;
            gv_certifications.DataBind();
        }



         protected void btn_certadd_Click1(object sender, EventArgs e)
        {
            DataTable dtSource3 = ViewState["dtSource3"] as DataTable;

            DataRow dr = dtSource3.NewRow();
           
         
            dr["ID"] = txt_id.Text;
            dr["Name"] = txt_certname.Text;
            dr["Validity From"] = txt_valfrom.Text;
            dr["Validity To"] = txt_valto.Text;
            
            dtSource3.Rows.Add(dr);
            gv_certifications.DataSource = dtSource3;
            gv_certifications.DataBind();

            clearcert();
        }

        private void clearcert()
        {
            txt_certname.Text = "";
            txt_valfrom.Text = "";
            txt_valto.Text = "";
            

        }



        private void CareerGv()
        {
            DataTable dtSource4 = new DataTable();


            dtSource4.Columns.Add("ID");
            dtSource4.Columns.Add("Designation");
            dtSource4.Columns.Add("Company");
            dtSource4.Columns.Add("Tenure From");
            dtSource4.Columns.Add("Tenure To");
            dtSource4.Columns.Add("Technical Skill");
            dtSource4.Columns.Add("Final salary");
       


            ViewState["dtSource4"] = dtSource4;

            gv_careers.DataSource = dtSource4;
            gv_careers.DataBind();
        }

        protected void gv_careers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource4 = ViewState["dtSource4"] as DataTable;
            gv_careers.EditIndex = -1;
            gv_careers.DataSource = dtSource4;
            gv_careers.DataBind();
        }

        protected void gv_careers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Careers = Convert.ToInt32(e.RowIndex);
            DataTable dtSource4 = ViewState["dtSource4"] as DataTable;
            DataRow dr = dtSource4.NewRow();
            dtSource4.Rows[Careers].Delete();
            gv_careers.DataSource = dtSource4;
            gv_careers.DataBind();
        }

        protected void gv_careers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource4 = ViewState["dtSource4"] as DataTable;
            gv_careers.EditIndex = e.NewEditIndex;
            gv_careers.DataSource = dtSource4;
            gv_careers.DataBind();
        }

        protected void gv_careers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gv_careers.Rows[e.RowIndex];

            string desg = (row.Cells[1].Controls[0] as TextBox).Text;
            string comp = (row.Cells[2].Controls[0] as TextBox).Text;
            string from = (row.Cells[3].Controls[0] as TextBox).Text;
            string to = (row.Cells[4].Controls[0] as TextBox).Text;
            string skill = (row.Cells[5].Controls[0] as TextBox).Text;
            string sal = (row.Cells[6].Controls[0] as TextBox).Text;


            DataTable dtSource4 = ViewState["dtSource4"] as DataTable;
            dtSource4.Rows[row.RowIndex]["Designation"] = desg;
            dtSource4.Rows[row.RowIndex]["Company"] = comp;
            dtSource4.Rows[row.RowIndex]["Tenure From"] = from;
            dtSource4.Rows[row.RowIndex]["Tenure To"] = to;
            dtSource4.Rows[row.RowIndex]["Technical Skill"] = skill;
            dtSource4.Rows[row.RowIndex]["Final salary"] =sal;
         

            gv_careers.EditIndex = -1;
            gv_careers.DataSource = dtSource4;
            gv_careers.DataBind();
        }

        protected void btn_careeradd_Click(object sender, EventArgs e)
        {
            DataTable dtSource4 = ViewState["dtSource4"] as DataTable;

            DataRow dr = dtSource4.NewRow();
           

            dr["ID"] = txt_id.Text;
            dr["Designation"] = txt_desg.Text;
            dr["Company"] = txt_comp.Text;
            dr["Tenure From"] = txt_tenurefrom.Text;
            dr["Tenure To"] = txt_tenureto.Text;
            dr["Technical Skill"] = txt_skill.Text;
            dr["Final salary"] = txt_sal.Text;

            dtSource4.Rows.Add(dr);
            gv_careers.DataSource = dtSource4;
            gv_careers.DataBind();

            clearcareers();
        }

        private void clearcareers()
        {
            txt_desg.Text = "";
            txt_comp.Text = "";
            txt_tenurefrom.Text = "";
            txt_tenureto.Text = "";
            txt_skill.Text = "";
            txt_sal.Text = "";
        }

        private void NeoGv()
        {
            DataTable dtSource5 = new DataTable();


            dtSource5.Columns.Add("ID");
            dtSource5.Columns.Add("Designation");
            dtSource5.Columns.Add("From");
            dtSource5.Columns.Add("To");
            dtSource5.Columns.Add("Reporting Officer");
       

           

            ViewState["dtSource5"] = dtSource5;

            gv_neoexp.DataSource = dtSource5;
            gv_neoexp.DataBind();
        }

        protected void gv_neoexp_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource5 = ViewState["dtSource5"] as DataTable;
            gv_neoexp.EditIndex = -1;
            gv_neoexp.DataSource = dtSource5;
            gv_neoexp.DataBind();
        }

        protected void gv_neoexp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Neo = Convert.ToInt32(e.RowIndex);
            DataTable dtSource5 = ViewState["dtSource5"] as DataTable;
            DataRow dr = dtSource5.NewRow();
            dtSource5.Rows[Neo].Delete();
            gv_neoexp.DataSource = dtSource5;
            gv_neoexp.DataBind();
        }

        protected void gv_neoexp_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource5 = ViewState["dtSource5"] as DataTable;
            gv_neoexp.EditIndex = e.NewEditIndex;
            gv_neoexp.DataSource = dtSource5;
            gv_neoexp.DataBind();
        }

        protected void gv_neoexp_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gv_neoexp.Rows[e.RowIndex];

            string desg = (row.Cells[1].Controls[0] as TextBox).Text;
            string from = (row.Cells[2].Controls[0] as TextBox).Text;
            string to = (row.Cells[3].Controls[0] as TextBox).Text;
            string ro = (row.Cells[4].Controls[0] as TextBox).Text;
        


            DataTable dtSource5 = ViewState["dtSource5"] as DataTable;
            dtSource5.Rows[row.RowIndex]["Designation"] = desg;
            dtSource5.Rows[row.RowIndex]["From"] = from;
            dtSource5.Rows[row.RowIndex]["To"] = to;
            dtSource5.Rows[row.RowIndex]["Reporting Officer"] = ro;



            gv_neoexp.EditIndex = -1;
            gv_neoexp.DataSource = dtSource5;
            gv_neoexp.DataBind();
        }

        protected void btn_neoadd_Click1(object sender, EventArgs e)
        {
            DataTable dtSource5 = ViewState["dtSource5"] as DataTable;

            DataRow dr = dtSource5.NewRow();


            dr["ID"] = txt_id.Text;
            dr["Designation"] = txt_neodesg.Text;
            dr["From"] = txt_neofrom.Text;
            dr["To"] = txt_neoto.Text;
            dr["Reporting Officer"] = txt_neoRo.Text;
          

            dtSource5.Rows.Add(dr);
            gv_neoexp.DataSource = dtSource5;
            gv_neoexp.DataBind();

            clearneo();
        }

        private void clearneo()
        {
            txt_neodesg.Text = "";
            txt_neofrom.Text = "";
            txt_neoto.Text = "";
            txt_neoRo.Text = "";
        }



        private void StrenGv()
        {
            DataTable dtSource = new DataTable();


            dtSource.Columns.Add("ID");
            dtSource.Columns.Add("Strength");
            dtSource.Columns.Add("Weakness");
          


            ViewState["dtSource"] = dtSource;

            gv_strength.DataSource = dtSource;
            gv_strength.DataBind();
        }

   
 

 
        protected void gv_strength_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource = ViewState["dtSource"] as DataTable;
            gv_strength.EditIndex = -1;
            gv_strength.DataSource = dtSource;
            gv_strength.DataBind();
        }

        protected void gv_strength_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Stren= Convert.ToInt32(e.RowIndex);
            DataTable dtSource = ViewState["dtSource"] as DataTable;
            DataRow dr = dtSource.NewRow();
            dtSource.Rows[Stren].Delete();
            gv_strength.DataSource = dtSource;
            gv_strength.DataBind();
        }

        protected void gv_strength_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource = ViewState["dtSource"] as DataTable;
            gv_strength.EditIndex = e.NewEditIndex;
            gv_strength.DataSource = dtSource;
            gv_strength.DataBind();
        }

        protected void gv_strength_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gv_strength.Rows[e.RowIndex];

            string stren= (row.Cells[1].Controls[0] as TextBox).Text;
            string weak = (row.Cells[2].Controls[0] as TextBox).Text;
            



            DataTable dtSource = ViewState["dtSource"] as DataTable;
            dtSource.Rows[row.RowIndex]["Strength"] = stren;
            dtSource.Rows[row.RowIndex]["Weakness"] = weak;
          


            gv_strength.EditIndex = -1;
            gv_strength.DataSource = dtSource;
            gv_strength.DataBind();
        }




        protected void btn_stenadd_Click(object sender, EventArgs e)
        {
            DataTable dtSource = ViewState["dtSource"] as DataTable;

            DataRow dr = dtSource.NewRow();


            dr["ID"] = txt_id.Text;
            dr["Strength"] = txt_stren.Text;
            dr["Weakness"] = txt_weak.Text;
          

         
            dtSource.Rows.Add(dr);
            gv_strength.DataSource = dtSource;
            gv_strength.DataBind();

            clearstren();



        }

        private void clearstren()
        {
            txt_stren.Text = "";
            txt_weak.Text = "";
        }

     

      
       
       

    }
}


 