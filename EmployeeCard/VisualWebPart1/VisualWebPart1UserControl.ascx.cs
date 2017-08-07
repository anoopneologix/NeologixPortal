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

      

        protected void btn_add_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Child Name");
            dt.Columns.Add("Child Age");

            DataRow dr = dt.NewRow();
            dr["ID"] = txt_id.Text;
            dr["Child Name"] = txt_chdname.Text;
            dr["Child Age"] = txt_chdage.Text;
            dt.Rows.Add(dr);

            
            gv_child.DataSource = dt;
            gv_child.DataBind();

            clear();

  
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
          


            childgvbind(web);
        }

        private void clear()
        {

            txt_chdname.Text = "";
            txt_chdage.Text =  "";
        }

  
        protected void gv_child_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            
            SPWeb web = SPContext.Current.Web;
          
            gv_child.EditIndex = -1;
            childgvbind(web);
          
          
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



             
          }
            
            
        protected void gv_child_RowEditing(object sender, GridViewEditEventArgs e)
          {
            SPWeb web = SPContext.Current.Web;
        
            gv_child.EditIndex = e.NewEditIndex;
            childgvbind(web);
         

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

        protected void btn_addedu_Click1(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;

            DataTable dt2 = new DataTable();

            dt2.Columns.Add("ID");
            dt2.Columns.Add("Qualification");
            dt2.Columns.Add("School/College");
            dt2.Columns.Add("University");
            dt2.Columns.Add("Year Of Passing");
            dt2.Columns.Add("Marks");

            DataRow dr2 = dt2.NewRow();
            dr2["ID"] = txt_id.Text;
            dr2["Qualification"] = txt_quali.Text;
            dr2["School/College"] = txt_school.Text;
            dr2["University"] = txt_uni.Text;
            dr2["Year Of Passing"] = txt_yop.Text;
            dr2["Marks"] = txt_marks.Text;
            dt2.Rows.Add(dr2);

            gv_education.DataSource = dt2;
            gv_education.DataBind();

            clearedu();

           
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

            educationgvbind(web);
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
          
            gv_education.EditIndex = -1;
            educationgvbind(web);
           
          
          
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



               
            
        }

        protected void gv_education_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
           
            gv_education.EditIndex = e.NewEditIndex;
            educationgvbind(web);
           
        
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

         

        protected void btn_certadd_Click1(object sender, EventArgs e)
        {

            SPWeb web = SPContext.Current.Web;
            DataTable dt3 = new DataTable();

            dt3.Columns.Add("ID");
            dt3.Columns.Add("Name");
            dt3.Columns.Add("Validity From");
            dt3.Columns.Add("Validity To");


            DataRow dr3 = dt3.NewRow();


            dr3["ID"] = txt_id.Text;
            dr3["Name"] = txt_certname.Text;
            dr3["Validity From"] = txt_valfrom.Text;
            dr3["Validity To"] = txt_valto.Text;

            dt3.Rows.Add(dr3);

            gv_certifications.DataSource = dt3;
            gv_certifications.DataBind();

            clearcert();

         
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

            certificategvbind(web);
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
           
            gv_certifications.EditIndex = -1;
            certificategvbind(web);
            

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


           
            
            
        }

        protected void gv_certifications_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
         
            gv_certifications.EditIndex = e.NewEditIndex;
            certificategvbind(web);
           

         
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



        protected void btn_careeradd_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;

            DataTable dt4 = new DataTable();
            dt4.Columns.Add("ID");
            dt4.Columns.Add("Designation");
            dt4.Columns.Add("Company");
            dt4.Columns.Add("Tenure From");
            dt4.Columns.Add("Tenure To");
            dt4.Columns.Add("Technical Skill");
            dt4.Columns.Add("Final salary");

            DataRow dr4 = dt4.NewRow();
            dr4["ID"] = txt_id.Text;
            dr4["Designation"] = txt_desg.Text;
            dr4["Company"] = txt_comp.Text;
            dr4["Tenure From"] = txt_tenurefrom.Text;
            dr4["Tenure To"] = txt_tenureto.Text;
            dr4["Technical Skill"] = txt_skill.Text;
            dr4["Final salary"] = txt_sal.Text;

            dt4.Rows.Add(dr4);
            gv_careers.DataSource = dt4;
            
            gv_careers.DataBind();

            clearcareers();


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


            careersgvbind(web);
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
      

        protected void gv_careers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
        
            gv_careers.EditIndex = -1;
            careersgvbind(web);

        
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

            
        }

        protected void gv_careers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
         
            gv_careers.EditIndex = e.NewEditIndex;
            careersgvbind(web);
       
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


        protected void btn_neoadd_Click1(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;

            DataTable dt5 = new DataTable();
            dt5.Columns.Add("ID");
            dt5.Columns.Add("Designation");
            dt5.Columns.Add("From");
            dt5.Columns.Add("To");
            dt5.Columns.Add("Reporting Officer");


            DataRow dr5 = dt5.NewRow();

            dr5["ID"] = txt_id.Text;
            dr5["Designation"] = txt_neodesg.Text;
            dr5["From"] = txt_neofrom.Text;
            dr5["To"] = txt_neoto.Text;
            dr5["Reporting Officer"] = txt_neoRo.Text;


            dt5.Rows.Add(dr5);
            gv_neoexp.DataSource = dt5;
            gv_neoexp.DataBind();

            clearneo();


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

            neoexpgvbind(web);
       
        }

        private void clearneo()
        {
            txt_neodesg.Text = "";
            txt_neofrom.Text = "";
            txt_neoto.Text = "";
            txt_neoRo.Text = "";
        }


        protected void gv_neoexp_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
         
            gv_neoexp.EditIndex = -1;
            neoexpgvbind(web);
          
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



         
        }

        protected void gv_neoexp_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
         
            gv_neoexp.EditIndex = e.NewEditIndex;
            neoexpgvbind(web);
        
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



        protected void btn_stenadd_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;

            DataTable dt6 = new DataTable();

            dt6.Columns.Add("ID");
            dt6.Columns.Add("Strength");
            dt6.Columns.Add("Weakness");

            DataRow dr6 = dt6.NewRow();
            dr6["ID"] = txt_id.Text;
            dr6["Strength"] = txt_stren.Text;
            dr6["Weakness"] = txt_weak.Text;



            dt6.Rows.Add(dr6);
            gv_strength.DataSource = dt6;
            gv_strength.DataBind();

            clearstren();
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
            personalitygvbind(web);
          
        }

        private void clearstren()
        {
            txt_stren.Text = "";
            txt_weak.Text = "";
        }

       
     


        protected void gv_strength_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
           
            gv_strength.EditIndex = e.NewEditIndex;
            personalitygvbind(web);

         
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

           
            
        }

        protected void gv_strength_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
         
            gv_strength.EditIndex = -1;
            personalitygvbind(web);
         
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

         
        }

     

        protected void gv_education_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {

          Page.Response.Redirect("EmployeeList.aspx");
          
           
          
        }

    }
}
