using Microsoft.SharePoint;
using SP = Microsoft.SharePoint.Client;
using System;
using System.Linq;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.Web;

namespace EmployeeCard.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string siteURL = SPContext.Current.Site.Url.ToString() + "/HR";
                using (SPSite site = new SPSite(siteURL))
                {

                    using (SPWeb web = SPContext.Current.Web)
                    {
                        SPList PDlist = web.Lists["Personal Details"];
                        SPQuery PDquery = new SPQuery();
                        String qEmpId = Request.QueryString["empid"].ToString();

                        if (!string.IsNullOrEmpty(qEmpId))
                        {
                            PDquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", qEmpId, "</Value></Eq></Where>");
                            SPListItemCollection newitems = PDlist.GetItems(PDquery);

                            foreach (SPListItem item in newitems)
                            {
                                txt_id.Text = Convert.ToString(item["Employee Id"]);
                                txt_name.Text = Convert.ToString(item["Name"]);
                                dp_doj.SelectedDate = Convert.ToDateTime(item["DOJ"].ToString());
                                txt_blood.Text = Convert.ToString(item["Blood GP"]);
                                dtcDoB.SelectedDate = Convert.ToDateTime(item["DOB"]);
                                txt_pancard.Text = Convert.ToString(item["Pan card"]);
                                txt_officialemail.Text = Convert.ToString(item["OfficialEmail"]);
                                txt_personalemail.Text = Convert.ToString(item["PersonalEmail"]);
                                txt_mobno.Text = Convert.ToString(item["Mobile No"]);
                                txt_permantaddr.Text = ScrubHtml(Convert.ToString(item["Permanent Address"]));
                                txt_current.Text = ScrubHtml(Convert.ToString(item["Current Address"]));
                                txt_emercontactno.Text = Convert.ToString(item["Emergency Contact No"]);
                                txt_residenceno.Text = Convert.ToString(item["Residence No"]);
                                txt_father.Text = Convert.ToString(item["Father's Name"]);
                                txt_mothernam.Text = Convert.ToString(item["Mother's Name"]);
                                if (string.Compare(Convert.ToString(item["Marital status"]), "Single") == 0)
                                {

                                    rdbtn_single.Checked = true;

                                }
                                else
                                {
                                    rdbtn_married.Checked = true;
                                }

                                dtc_marriageanniversary.SelectedDate = Convert.ToDateTime(item["Marriage Anniversary"]);
                                txt_spousename.Text = Convert.ToString(item["Spouse Name"]);
                                dtcspouseDoB.SelectedDate = Convert.ToDateTime(item["Spouse DOB"]);
                                txt_spousedesignation.Text = Convert.ToString(item["Spouse Designation"]);
                                txt_spouseorganisation.Text = Convert.ToString(item["Spouse Organisation"]);
                            }



                            childgvbind(web);
                            educationgvbind(web);
                            certificategvbind(web);
                            careersgvbind(web);
                            neoexpgvbind(web);
                            personalitygvbind(web);



                          }
                       }
                   }
                }
            else 
              {
                SetInitialRow();
                SetEducationRow();
                SetCertificationRow();
                SetCareersRow();
                SetNeoRow();
                SetPersonalityRow();
            }
             
            }

      
       protected void btn_Save_Click(object sender, EventArgs e)
          {

            SPWeb web = SPContext.Current.Web;
            SPList PDlist = web.Lists["Personal Details"];
            SPQuery PDquery = new SPQuery();
            PDquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
           
            //SPListItemCollection items = PDlist.Items;
            SPListItemCollection newitems = PDlist.GetItems(PDquery);

            foreach (SPListItem item in newitems)
            {
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

            SaveChildDetails();
            SaveEducationQualif();
            SaveCertifications();
            SaveCareers();
            SaveNeoExp();
            SavePersonality();

            lbl_alert.Text = "Saved Succefully";
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
               DateTime valFrom = Convert.ToDateTime(row.Cells[2].Text);
               item6["From"] = valFrom.Date;
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
               DateTime valFrom = Convert.ToDateTime(row.Cells[3].Text);
            
               item5["Tenure From"] = valFrom.Date;

               DateTime valFrom2 = Convert.ToDateTime(row.Cells[4].Text);
              
               item5["Tenure To"] = valFrom2.Date;
            
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
               DateTime valFrom = Convert.ToDateTime(row.Cells[2].Text);
               item4["Validity From"] = valFrom.Date;
               DateTime valFrom2 = Convert.ToDateTime(row.Cells[3].Text);
               item4["Validity To"] = valFrom2.Date;
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

   

        public static string ScrubHtml(string value)
          {
            var step1 = Regex.Replace(value, @"<[^>]+>|&nbsp;", "").Trim();
            var step2 = Regex.Replace(step1, @"\s{2,}", " ");
            return step2;
         }
        private void childgvbind(SPWeb web)
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

            foreach(SPListItem item in newcditems)
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

        private void SetInitialRow()
         {
            SPWeb web = SPContext.Current.Web;
            SPList CDlist = web.Lists["Employee Child Details"];
            DataTable dtSource1 = new DataTable();

            // DataRow dr = dtSource.NewRow();
            // DataRow dr = null;
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
            gv_child.DataSource = dtSource1;
            gv_child.DataBind();
            clear();

        }

        private void clear()
        {

            txt_chdname.Text = "";
            txt_chdage.Text = "";
        }


        protected void gv_child_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource1 = ViewState["dtSource1"] as DataTable;
            gv_child.EditIndex = -1;
            childgvbind(web);
            gv_child.DataSource = dtSource1;
            gv_child.DataBind();
          
        }

        protected void gv_child_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gv_child.Rows[e.RowIndex];
            int Child = row.DataItemIndex;
            SPWeb web = SPContext.Current.Web;
            
                SPList CDlist = web.Lists["Employee Child Details"];
                SPQuery CDquery = new SPQuery();
                CDquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
                SPListItemCollection newcditems = CDlist.GetItems(CDquery);

                int itemcount = newcditems.Count;


                for (int i = 0; i <= itemcount - 1; i++)
                {
                    SPListItem item = newcditems[i];
                    if (Child == i)
                    {
                        newcditems.Delete(i);
                    }
                }

                childgvbind(web);



                int Child2 = Convert.ToInt32(e.RowIndex);
                DataTable dtSource1 = ViewState["dtSource1"] as DataTable;
                DataRow dr = dtSource1.NewRow();
                dtSource1.Rows[Child2].Delete();
                gv_child.DataSource = dtSource1;
                gv_child.DataBind();
          }
            
            
        protected void gv_child_RowEditing(object sender, GridViewEditEventArgs e)
          {
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource1 = ViewState["dtSource1"] as DataTable;
            gv_child.EditIndex = e.NewEditIndex;
            childgvbind(web);
            gv_child.DataSource = dtSource1;
            gv_child.DataBind();

          }

        protected void gv_child_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {  
            GridViewRow row = (GridViewRow)gv_child.Rows[e.RowIndex];
            int childindex = row.DataItemIndex;



            SPWeb web = SPContext.Current.Web;
            
                SPList CDlist = web.Lists["Employee Child Details"];
                SPQuery CDquery = new SPQuery();
                CDquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
                SPListItemCollection newcditems = CDlist.GetItems(CDquery);

                int itemcount = newcditems.Count;

                TextBox textchildname = (TextBox)row.Cells[1].Controls[0];
                TextBox textchildage = (TextBox)row.Cells[2].Controls[0];

                string d = textchildname.Text;
                string age = textchildage.Text;


                for (int i = 0; i <= itemcount - 1; i++)
                {
                    SPListItem item = newcditems[i];
                    if (childindex == i)
                    {
                        item["Child Name"] = d;
                        item["Child Age"] = age;
                        item.Update();
                    }
                }
                gv_child.EditIndex = -1;
                childgvbind(web);


                string name = (row.Cells[1].Controls[0] as TextBox).Text;
                string chdage = (row.Cells[2].Controls[0] as TextBox).Text;
                DataTable dtSource1 = ViewState["dtSource1"] as DataTable;
                dtSource1.Rows[row.RowIndex]["Child Name"] = name;
                dtSource1.Rows[row.RowIndex]["Child Age"] = chdage;
                //ViewState["dtSource"] = dtSource;
                gv_child.EditIndex = -1;
                gv_child.DataSource = dtSource1;
                gv_child.DataBind();


        }


    private void educationgvbind(SPWeb web)
    
         {
                SPList EQlist = web.Lists["Educational Qualifications"];
                SPQuery EQquery = new SPQuery();
                EQquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
                SPListItemCollection eqitems = EQlist.Items;

                SPListItemCollection neweqitems = EQlist.GetItems(EQquery);

                DataSet ds2 = new DataSet();
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID");
                dt2.Columns.Add("Qualification");
                dt2.Columns.Add("School/College");
                dt2.Columns.Add("University");
                dt2.Columns.Add("Year Of Passing");
                dt2.Columns.Add("Marks");

                foreach (SPListItem item in neweqitems)
                {
                    DataRow dr2 = dt2.NewRow();

                    dr2[0] = item["ID"].ToString();
                    dr2[1] = item["Qualification"].ToString();
                    dr2[2] = item["School/College"].ToString();
                    dr2[3] = item["University"].ToString();
                    dr2[4] = item["Year Of Passing"].ToString();
                    dr2[5] = item["Marks"].ToString();
                    
                    dt2.Rows.Add(dr2);
                }

                ds2.Tables.Add(dt2);
                gv_education.DataSource = ds2;
                gv_education.DataBind();

            
        }

    private void SetEducationRow()
    {
        SPWeb web = SPContext.Current.Web;
        SPList EQlist = web.Lists["Educational Qualifications"];

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
            educationgvbind(web);
            gv_education.DataSource = dtSource2;
            gv_education.DataBind();
          
          
        }

        protected void gv_education_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gv_education.Rows[e.RowIndex];
            int Education = row.DataItemIndex;
        
                SPWeb web = SPContext.Current.Web;
                SPList EQlist = web.Lists["Educational Qualifications"];
                SPQuery EQquery = new SPQuery();
                EQquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
                SPListItemCollection eqitems = EQlist.Items;

                SPListItemCollection neweqitems = EQlist.GetItems(EQquery);

                int itemcount = neweqitems.Count;


                for (int i = 0; i <= itemcount - 1; i++)
                {
                    SPListItem item = neweqitems[i];
                    if (Education == i)
                    {
                        neweqitems.Delete(i);
                    }
                }

                educationgvbind(web);



                int Qualif = Convert.ToInt32(e.RowIndex);
                DataTable dtSource2 = ViewState["dtSource2"] as DataTable;
                DataRow dr = dtSource2.NewRow();
                dtSource2.Rows[Qualif].Delete();
             
                gv_education.DataSource = dtSource2;
                gv_education.DataBind();
               
            
        }

        protected void gv_education_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource2 = ViewState["dtSource2"] as DataTable;
            gv_education.EditIndex = e.NewEditIndex;
            educationgvbind(web);
            gv_education.DataSource = dtSource2;
            gv_education.DataBind();
        
        }


        protected void gv_education_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)gv_education.Rows[e.RowIndex];
            int Educationindex = row.DataItemIndex;


           SPWeb web = SPContext.Current.Web;
            
                SPList EQlist = web.Lists["Educational Qualifications"];
                SPQuery EQquery = new SPQuery();
                EQquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
                SPListItemCollection eqitems = EQlist.Items;

                SPListItemCollection neweqitems = EQlist.GetItems(EQquery);

                int itemcount = neweqitems.Count;


                TextBox text_Qualification = (TextBox)row.Cells[1].Controls[0];
                TextBox text_SchoolCollege = (TextBox)row.Cells[2].Controls[0];
                TextBox text_University = (TextBox)row.Cells[3].Controls[0];
                TextBox text_Year = (TextBox)row.Cells[4].Controls[0];
                TextBox text_Marks = (TextBox)row.Cells[5].Controls[0];

                string quali = text_Qualification.Text;
                string school = text_SchoolCollege.Text;
                string univ = text_University.Text;
                string year = text_Year.Text;
                string marks = text_Marks.Text;


                for (int i = 0; i <= itemcount - 1; i++)
                {
                    SPListItem item = neweqitems[i];
                    if (Educationindex == i)
                    {
                        item["Qualification"] = quali;
                        item["School/College"] = school;
                        item["University"] = univ;
                        item["Year Of Passing"] = year;
                        item["Marks"] = marks;
                        item.Update();
                    }
                }
                gv_education.EditIndex = -1;
                educationgvbind(web);



             //   GridViewRow row = gv_education.Rows[e.RowIndex];

                string qualif = (row.Cells[1].Controls[0] as TextBox).Text;
                string schl = (row.Cells[2].Controls[0] as TextBox).Text;
                string univer = (row.Cells[3].Controls[0] as TextBox).Text;
                string yop = (row.Cells[4].Controls[0] as TextBox).Text;
                string mark = (row.Cells[5].Controls[0] as TextBox).Text;

                DataTable dtSource2 = ViewState["dtSource2"] as DataTable;
                dtSource2.Rows[row.RowIndex]["Qualification"] = qualif;
                dtSource2.Rows[row.RowIndex]["School/College"] = schl;
                dtSource2.Rows[row.RowIndex]["University"] = univer;
                dtSource2.Rows[row.RowIndex]["Year Of Passing"] = yop;
                dtSource2.Rows[row.RowIndex]["Marks"] = mark;


                gv_education.EditIndex = -1;
                gv_education.DataSource = dtSource2;
                gv_education.DataBind();

          }


    private void certificategvbind(SPWeb web)
        {
              
                SPList CTlist = web.Lists["Certifications"];
                SPQuery CTquery = new SPQuery();
                CTquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
                //SPListItemCollection ctitems = EQlist.Items;

                SPListItemCollection newctitems = CTlist.GetItems(CTquery);


                DataSet ds3 = new DataSet();
                DataTable dt3 = new DataTable();
                dt3.Columns.Add("ID");
                dt3.Columns.Add("Name");
                dt3.Columns.Add("Validity From");
                dt3.Columns.Add("Validity To");
                     

                foreach (SPListItem item in newctitems)
                {
                    DataRow dr3 = dt3.NewRow();

                    dr3[0] = item["ID"].ToString();
                    dr3[1] = item["Name"].ToString();
                    DateTime valFrom = Convert.ToDateTime(item["Validity From"].ToString());
                    dr3[2] = valFrom.ToShortDateString();
                    DateTime valFrom2 = Convert.ToDateTime(item["Validity To"].ToString());
                    dr3[3] = valFrom2.ToShortDateString();



                    dt3.Rows.Add(dr3);
                }

                ds3.Tables.Add(dt3);
                gv_certifications.DataSource = ds3;
                gv_certifications.DataBind();

            
        }

           private void SetCertificationRow()
            {
                SPWeb web = SPContext.Current.Web;
                SPList CTlist = web.Lists["Certifications"];
                DataTable dtSource3 = new DataTable();


                dtSource3.Columns.Add("ID");
                dtSource3.Columns.Add("Name");
                dtSource3.Columns.Add("Validity From");
                dtSource3.Columns.Add("Validity To");


                ViewState["dtSource3"] = dtSource3;

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

        protected void gv_certifications_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource3 = ViewState["dtSource3"] as DataTable;
            gv_certifications.EditIndex = -1;
            certificategvbind(web);
            gv_certifications.DataSource = dtSource3;
            gv_certifications.DataBind();

        }

        protected void gv_certifications_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            GridViewRow row = (GridViewRow)gv_certifications.Rows[e.RowIndex];
            int Certificate = row.DataItemIndex;

            SPWeb web = SPContext.Current.Web;
                SPList CTlist = web.Lists["Certifications"];
                SPQuery CTquery = new SPQuery();
                CTquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
                //SPListItemCollection ctitems = EQlist.Items;

                SPListItemCollection newctitems = CTlist.GetItems(CTquery);

                int itemcount = newctitems.Count;


                for (int i = 0; i <= itemcount - 1; i++)
                {
                    SPListItem item = newctitems[i];
                    if (Certificate == i)
                    {
                        newctitems.Delete(i);
                    }
                }

                certificategvbind(web);


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
            certificategvbind(web);
            gv_certifications.DataSource = dtSource3;
            gv_certifications.DataBind();

         
        }

        protected void gv_certifications_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {  
            GridViewRow row = (GridViewRow)gv_certifications.Rows[e.RowIndex];
            int CertificateIndex = row.DataItemIndex;

                SPWeb web = SPContext.Current.Web;
                SPList CTlist = web.Lists["Certifications"];
                SPQuery CTquery = new SPQuery();
                CTquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
                //SPListItemCollection ctitems = EQlist.Items;

                SPListItemCollection newctitems = CTlist.GetItems(CTquery);

                int itemcount = newctitems.Count;

                TextBox text_Name = (TextBox)row.Cells[1].Controls[0];
                TextBox text_ValidityFrom = (TextBox)row.Cells[2].Controls[0];
                TextBox text_ValidityTo = (TextBox)row.Cells[3].Controls[0];

                string name = text_Name.Text;
                string from = text_ValidityFrom.Text;
                string to = text_ValidityTo.Text;


                for (int i = 0; i <= itemcount - 1; i++)
                {
                    SPListItem item = newctitems[i];
                    if (CertificateIndex == i)
                    {
                        item["Name"] = name;
                        item["Validity From"] = from;
                        item["Validity To"] = to;
                        item.Update();
                    }
                }
                gv_certifications.EditIndex = -1;
                certificategvbind(web);


          //      GridViewRow row = gv_certifications.Rows[e.RowIndex];

                string namecert = (row.Cells[1].Controls[0] as TextBox).Text;
                string fromcert = (row.Cells[2].Controls[0] as TextBox).Text;
                string tocert = (row.Cells[3].Controls[0] as TextBox).Text;


                DataTable dtSource3 = ViewState["dtSource3"] as DataTable;
                dtSource3.Rows[row.RowIndex]["Name"] = namecert;
                dtSource3.Rows[row.RowIndex]["Validity From"] = fromcert;
                dtSource3.Rows[row.RowIndex]["Validity To"] = tocert;



                gv_certifications.EditIndex = -1;
                gv_certifications.DataSource = dtSource3;
                gv_certifications.DataBind();
          
        }



        private void careersgvbind(SPWeb web)
        {
              
                SPList CRlist = web.Lists["Careers"];
                SPQuery CRquery = new SPQuery();
                CRquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
                //SPListItemCollection critems = CRlist.Items;

                SPListItemCollection newcritems = CRlist.GetItems(CRquery);

                DataSet ds4 = new DataSet();
                DataTable dt4 = new DataTable();
                dt4.Columns.Add("ID");
                dt4.Columns.Add("Designation");
                dt4.Columns.Add("Company");
                dt4.Columns.Add("Tenure From");
                dt4.Columns.Add("Tenure To");
                dt4.Columns.Add("Technical Skill");
                dt4.Columns.Add("Final salary");



                foreach (SPListItem item in newcritems)
                {
                    DataRow dr4 = dt4.NewRow();

                    dr4[0] = item["ID"].ToString();
                    dr4[1] = item["Designation"].ToString();
                    dr4[2] = item["Company"].ToString();
                    DateTime valFrom = Convert.ToDateTime(item["Tenure From"].ToString());
                    dr4[3] = valFrom.ToShortDateString();
                    DateTime valFrom2 = Convert.ToDateTime(item["Tenure To"].ToString());
                    dr4[4] = valFrom2.ToShortDateString();
                    dr4[5] = item["Technical Skill"].ToString();
                    dr4[6] = item["Final salary"].ToString();

                    dt4.Rows.Add(dr4);
                }

                ds4.Tables.Add(dt4);
                gv_careers.DataSource = ds4;
                gv_careers.DataBind();
            
        }


        private void SetCareersRow()
        {
            SPWeb web = SPContext.Current.Web;
            SPList CRlist = web.Lists["Careers"];
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
            careersgvbind(web);

            gv_careers.DataSource = dtSource4;
            gv_careers.DataBind();
        }

        protected void gv_careers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gv_careers.Rows[e.RowIndex];
            int Careers = row.DataItemIndex;


            SPWeb web = SPContext.Current.Web;
                SPList CRlist = web.Lists["Careers"];
                SPQuery CRquery = new SPQuery();
                CRquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");


                SPListItemCollection newcritems = CRlist.GetItems(CRquery);


                int itemcount = newcritems.Count;


                for (int i = 0; i <= itemcount - 1; i++)
                {
                    SPListItem item = newcritems[i];
                    if (Careers == i)
                    {
                        newcritems.Delete(i);
                    }
                }

                careersgvbind(web);

             //   int Careers = Convert.ToInt32(e.RowIndex);
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
            careersgvbind(web);
            gv_careers.DataSource = dtSource4;
            gv_careers.DataBind();
        }

        protected void gv_careers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)gv_careers.Rows[e.RowIndex];
            int careerindex = row.DataItemIndex;



            SPWeb web = SPContext.Current.Web;
                SPList CRlist = web.Lists["Careers"];
                SPQuery CRquery = new SPQuery();
                CRquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
                SPListItemCollection newcritems = CRlist.GetItems(CRquery);



                int itemcount = newcritems.Count;


                TextBox text_designation = (TextBox)row.Cells[1].Controls[0];
                TextBox text_company = (TextBox)row.Cells[2].Controls[0];
                TextBox text_tenurefrom = (TextBox)row.Cells[3].Controls[0];
                TextBox text_tenureto = (TextBox)row.Cells[4].Controls[0];
                TextBox text_technicalskill = (TextBox)row.Cells[5].Controls[0];
                TextBox text_finalsal = (TextBox)row.Cells[6].Controls[0];

                string desg = text_designation.Text;
                string comp = text_company.Text;
                string from = text_tenurefrom.Text;
                string to = text_tenureto.Text;
                string skill = text_technicalskill.Text;
                string sal = text_finalsal.Text;


                for (int i = 0; i <= itemcount - 1; i++)
                {
                    SPListItem item = newcritems[i];
                    if (careerindex == i)
                    {
                        item["Designation"] = desg;
                        item["Company"] = comp;
                        item["Tenure From"] = from;
                        item["Tenure To"] = to;
                        item["Technical Skill"] = skill;
                        item["Final salary"] = sal;

                        item.Update();
                    }
                }
                gv_careers.EditIndex = -1;
                careersgvbind(web);



            //    GridViewRow row = gv_careers.Rows[e.RowIndex];

                string desgcareer = (row.Cells[1].Controls[0] as TextBox).Text;
                string compcareer = (row.Cells[2].Controls[0] as TextBox).Text;
                string fromcareer = (row.Cells[3].Controls[0] as TextBox).Text;
                string tocareer = (row.Cells[4].Controls[0] as TextBox).Text;
                string skillcareer = (row.Cells[5].Controls[0] as TextBox).Text;
                string salcareer = (row.Cells[6].Controls[0] as TextBox).Text;


                DataTable dtSource4 = ViewState["dtSource4"] as DataTable;
                dtSource4.Rows[row.RowIndex]["Designation"] = desgcareer;
                dtSource4.Rows[row.RowIndex]["Company"] = compcareer;
                dtSource4.Rows[row.RowIndex]["Tenure From"] = fromcareer;
                dtSource4.Rows[row.RowIndex]["Tenure To"] = tocareer;
                dtSource4.Rows[row.RowIndex]["Technical Skill"] = skillcareer;
                dtSource4.Rows[row.RowIndex]["Final salary"] = salcareer;


                gv_careers.EditIndex = -1;
                gv_careers.DataSource = dtSource4;
                gv_careers.DataBind();
            
        }

        private void neoexpgvbind(SPWeb web)
        {
                SPList NEOlist = web.Lists["Neo Experience"];
                SPQuery NEOquery = new SPQuery();
                NEOquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");


                SPListItemCollection newneoitems = NEOlist.GetItems(NEOquery);
                DataSet ds5 = new DataSet();
                DataTable dt5 = new DataTable();
                dt5.Columns.Add("ID");
                dt5.Columns.Add("Designation");
                dt5.Columns.Add("From");
                dt5.Columns.Add("To");
                dt5.Columns.Add("Reporting Officer");
                


                foreach (SPListItem item in newneoitems)
                {

                    DataRow dr5 = dt5.NewRow();
                    dr5[0] = item["ID"].ToString();
                    dr5[1] = item["Designation"].ToString();
                  
                    DateTime valFrom = Convert.ToDateTime(item["From"].ToString());
                    dr5[2] = valFrom.ToShortDateString();
                   // dr5[3] = item["To"].ToString();

                    DateTime valFrom2 = Convert.ToDateTime(item["To"].ToString());
                    dr5[3] = valFrom2.ToShortDateString();
                    dr5[4] = item["Reporting Officer"].ToString();
                    dt5.Rows.Add(dr5);
                }

                ds5.Tables.Add(dt5);

                gv_neoexp.DataSource = ds5;
                gv_neoexp.DataBind();
            
        }


        private void SetNeoRow()
        {

            SPWeb web = SPContext.Current.Web;
            SPList NEOlist = web.Lists["Neo Experience"];
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
            neoexpgvbind(web);
            gv_neoexp.DataSource = dtSource5;
            gv_neoexp.DataBind();
        }

        protected void gv_neoexp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gv_neoexp.Rows[e.RowIndex];
            int Neo = row.DataItemIndex;


            SPWeb web = SPContext.Current.Web;
            
                SPList NEOlist = web.Lists["Neo Experience"];
                SPQuery NEOquery = new SPQuery();
                NEOquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");


                SPListItemCollection newneoitems = NEOlist.GetItems(NEOquery);


                int itemcount = newneoitems.Count;


                for (int i = 0; i <= itemcount - 1; i++)
                {
                    SPListItem item = newneoitems[i];
                    if (Neo == i)
                    {
                        newneoitems.Delete(i);
                    }
                }

                neoexpgvbind(web);



            //  int Neo = Convert.ToInt32(e.RowIndex);
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
            neoexpgvbind(web);
            gv_neoexp.DataSource = dtSource5;
            gv_neoexp.DataBind();
        }

        protected void gv_neoexp_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)gv_neoexp.Rows[e.RowIndex];
            int NeoIndex = row.DataItemIndex;


                SPWeb web = SPContext.Current.Web;
                SPList NEOlist = web.Lists["Neo Experience"];
                SPQuery NEOquery = new SPQuery();
                NEOquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");


                SPListItemCollection newneoitems = NEOlist.GetItems(NEOquery);
                int itemcount = newneoitems.Count;

                TextBox text_designation = (TextBox)row.Cells[1].Controls[0];

                TextBox text_from = (TextBox)row.Cells[2].Controls[0];
                TextBox text_to = (TextBox)row.Cells[3].Controls[0];
                TextBox text_repofficer = (TextBox)row.Cells[4].Controls[0];


                string desg = text_designation.Text;
                string from = text_from.Text;
                string to = text_to.Text;
                string officer = text_repofficer.Text;



                for (int i = 0; i <= itemcount - 1; i++)
                {
                    SPListItem item = newneoitems[i];
                    if (NeoIndex == i)
                    {
                        item["Designation"] = desg;
                        item["From"] = from;
                        item["To"] = to;
                        item["Reporting Officer"] = officer;


                        item.Update();
                    }
                }
                gv_neoexp.EditIndex = -1;
                neoexpgvbind(web);


           //     GridViewRow row = gv_neoexp.Rows[e.RowIndex];

                string desgneo = (row.Cells[1].Controls[0] as TextBox).Text;
                string fromneo = (row.Cells[2].Controls[0] as TextBox).Text;
                string toneo = (row.Cells[3].Controls[0] as TextBox).Text;
                string roneo = (row.Cells[4].Controls[0] as TextBox).Text;



                DataTable dtSource5 = ViewState["dtSource5"] as DataTable;
                dtSource5.Rows[row.RowIndex]["Designation"] = desgneo;
                dtSource5.Rows[row.RowIndex]["From"] = fromneo;
                dtSource5.Rows[row.RowIndex]["To"] = toneo;
                dtSource5.Rows[row.RowIndex]["Reporting Officer"] = roneo;



                gv_neoexp.EditIndex = -1;
                gv_neoexp.DataSource = dtSource5;
                gv_neoexp.DataBind();
            
        }

        private void personalitygvbind(SPWeb web)
        {
           
           
                SPList SWlist = web.Lists["Strengths And Weakness"];
                SPQuery SWquery = new SPQuery();
                SWquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
               
                SPListItemCollection newswitems = SWlist.GetItems(SWquery);

                DataSet ds6 = new DataSet();
                DataTable dt6 = new DataTable();
                dt6.Columns.Add("ID");
                dt6.Columns.Add("Strength");
                dt6.Columns.Add("Weakness");

                foreach (SPListItem item in newswitems)
                {
                    DataRow dr6 = dt6.NewRow();
                    dr6[0] = item["ID"].ToString();
                    dr6[1] = item["Strength"].ToString();
                    dr6[2] = item["Weakness"].ToString();
                    dt6.Rows.Add(dr6);
                }

                ds6.Tables.Add(dt6);

                gv_strength.DataSource = ds6;
                gv_strength.DataBind();

            
        }

        private void SetPersonalityRow()
        {

            SPWeb web = SPContext.Current.Web;
            SPList SWlist = web.Lists["Strengths And Weakness"];
            DataTable dtSource = new DataTable();


            dtSource.Columns.Add("ID");
            dtSource.Columns.Add("Strength");
            dtSource.Columns.Add("Weakness");



            ViewState["dtSource"] = dtSource;

            gv_strength.DataSource = dtSource;
            gv_strength.DataBind();
        }


        protected void gv_strength_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource = ViewState["dtSource"] as DataTable;
            gv_strength.EditIndex = e.NewEditIndex;
            personalitygvbind(web);

            gv_strength.DataSource = dtSource;
            gv_strength.DataBind();
        }

        protected void gv_strength_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gv_strength.Rows[e.RowIndex];
            int Personality = row.DataItemIndex;


            SPWeb web = SPContext.Current.Web;
            
                SPList SWlist = web.Lists["Strengths And Weakness"];
                SPQuery SWquery = new SPQuery();
                SWquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
                //SPListItemCollection switems = SWlist.Items;

                SPListItemCollection newswitems = SWlist.GetItems(SWquery);

                int itemcount = newswitems.Count;


                for (int i = 0; i <= itemcount - 1; i++)
                {
                    SPListItem item = newswitems[i];
                    if (Personality == i)
                    {
                        newswitems.Delete(i);
                    }
                }

                personalitygvbind(web);

                int Stren = Convert.ToInt32(e.RowIndex);
                DataTable dtSource = ViewState["dtSource"] as DataTable;
                DataRow dr = dtSource.NewRow();
                dtSource.Rows[Stren].Delete();
                gv_strength.DataSource = dtSource;
                gv_strength.DataBind();
            
        }

        protected void gv_strength_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            DataTable dtSource = ViewState["dtSource"] as DataTable;
            gv_strength.EditIndex = -1;
            personalitygvbind(web);
            gv_strength.DataSource = dtSource;
            gv_strength.DataBind();
        }

        protected void gv_strength_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)gv_strength.Rows[e.RowIndex];
            int PersonalityIndex = row.DataItemIndex;


            SPWeb web = SPContext.Current.Web;
            
                SPList SWlist = web.Lists["Strengths And Weakness"];
                SPQuery SWquery = new SPQuery();
                SWquery.Query = string.Concat("<Where><Eq><FieldRef Name='Employee_x0020_Id' /> <Value Type='Text'>", txt_id.Text, "</Value></Eq></Where>");
                //SPListItemCollection switems = SWlist.Items;

                SPListItemCollection newswitems = SWlist.GetItems(SWquery);

                int itemcount = newswitems.Count;
                TextBox text_stren = (TextBox)row.Cells[1].Controls[0];
                TextBox text_weakness = (TextBox)row.Cells[2].Controls[0];


                string stren = text_stren.Text;
                string weakness = text_weakness.Text;


                for (int i = 0; i <= itemcount - 1; i++)
                {
                    SPListItem item = newswitems[i];
                    if (PersonalityIndex == i)
                    {
                        item["Strength"] = stren;
                        item["Weakness"] = weakness;


                        item.Update();
                    }
                }
                gv_strength.EditIndex = -1;
                personalitygvbind(web);

          //      GridViewRow row = gv_strength.Rows[e.RowIndex];

                string streng = (row.Cells[1].Controls[0] as TextBox).Text;
                string weak = (row.Cells[2].Controls[0] as TextBox).Text;

                DataTable dtSource = ViewState["dtSource"] as DataTable;
                dtSource.Rows[row.RowIndex]["Strength"] = streng;
                dtSource.Rows[row.RowIndex]["Weakness"] = weak;



                gv_strength.EditIndex = -1;
                gv_strength.DataSource = dtSource;
                gv_strength.DataBind();
            
        }

     

        protected void gv_education_SelectedIndexChanged(object sender, EventArgs e)
        {

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
