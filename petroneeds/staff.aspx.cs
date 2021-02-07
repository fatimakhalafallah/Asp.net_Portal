using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls.Adapters;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data;
using System.Configuration;

public partial class staff : System.Web.UI.Page
{
     DataSet dset;
     string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
     string sql  = "SELECT DEP_NAME, DEP_NO FROM DEPARTMENTS";
     string sql2 = "SELECT EMPLOYEES.EMPLOYEE_NO, EMPLOYEES.EMPLOYEE_NAME," +
                        "LKP_JOBS.JOB_NAME, EMPLOYEES.CONTACT_PHONES, EMPLOYEES.ID_CARD FROM EMPLOYEES " +
                        "INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO)" +
                        "INNER JOIN LKP_JOBS ON    (LKP_JOBS.JOB_NO = EMPLOYEES.JOB_NO)" +
                        "WHERE EMPLOYEES.EMPLOYEE_STATUS = '1'";

    public OdbcConnection conn = null;
    public OdbcCommand cmd = null;
    public OdbcDataReader read = null;
    public OdbcDataAdapter dadapter;
    private string sortDirection;

    public OdbcCommand odbccomm = null;
    public OdbcConnection odbccon = null;
    public OdbcDataAdapter odbcdadapter;


    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Text_Name.Text = null;
            Text_Name.Text = "";
            dadapter = new OdbcDataAdapter(sql, connectionString);
            dset = new DataSet();
            dadapter.Fill(dset);
            DropDownList1.DataSource = dset.Tables[0];
            DropDownList1.DataTextField = "DEP_NAME";
            DropDownList1.DataValueField = "DEP_NO";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("<<<Select>>>","0"));
            DropDownList1.SelectedIndex = 0;
            DropDownList1.SelectedValue = "0";
            DropDownList1.SelectedItem.Value = "0";
            GridViewBind();

            using (OdbcDataAdapter sda = new OdbcDataAdapter(sql2, connectionString))
            {
                sda.Fill(dset);
                if (dset.Tables.Count > 0)
                {
                    DataView dv = dset.Tables[0].DefaultView;
                    if (ViewState["SortDirection"] != null)
                    {
                        sortDirection = ViewState["SortDirection"].ToString();
                    }
                    if (ViewState["SortExpression"] != null)
                    {
                        sortExpression = ViewState["SortExpression"].ToString();
                        dv.Sort = string.Concat(sortExpression, " ", sortDirection);
                    }

                    GridView1.DataSource = dv;
                    GridView1.DataBind();
                }
            }
        }
    }
    public void GridViewBind()
    {
        //dadapter = new OdbcDataAdapter("SELECT USERS_INFORMATIONS.EMPLOYEE_NO, DEPARTMENTS.DEP_NAME, USERS_INFORMATIONS.FULL_USER_NAME," +
        //        "USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.DESCRIPTION FROM USERS_INFORMATIONS " +
        //        "INNER JOIN DEPARTMENTS ON (USERS_INFORMATIONS.DEP_NO = DEPARTMENTS.DEP_NO)" +
        //        "WHERE USERS_INFORMATIONS.DEP_NO = '" + DropDownList1.SelectedValue + "' OR USERS_INFORMATIONS.FULL_USER_NAME LIKE '" + Text_Name .Text + "'", connectionString);



        if (Text_Number.Text != "")
        {

            dadapter = new OdbcDataAdapter("SELECT EMPLOYEES.EMPLOYEE_NO, EMPLOYEES.CARD_STATUS ,EMPLOYEES.EMPLOYEE_NAME," +
                     "LKP_JOBS.JOB_NAME, EMPLOYEES.CONTACT_PHONES, EMPLOYEES.ID_CARD FROM EMPLOYEES " +
                    "INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO)" +
                    "INNER JOIN LKP_JOBS ON    (LKP_JOBS.JOB_NO = EMPLOYEES.JOB_NO)" +
                 "WHERE EMPLOYEES.EMPLOYEE_STATUS = '1' AND EMPLOYEES.EMPLOYEE_NO='" + Text_Number.Text + "'", connectionString);

     }

        else
        if (Text_Name.Text != "" && DropDownList1.SelectedValue !="0")
        {
            //dadapter = new OdbcDataAdapter("SELECT EMPLOYEES.EMPLOYEE_NO, DEPARTMENTS.DEP_NAME, EMPLOYEES.EMPLOYEE_NAME," +
            //       "EMPLOYEES.CONTACT_PHONES, EMPLOYEES.ID_CARD FROM EMPLOYEES " +
            //       "INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO)" +
            //       "WHERE EMPLOYEES.DEPT_DEPARTMRNT_NO = '" + DropDownList1.SelectedValue + "' AND EMPLOYEES.EMPLOYEE_NAME LIKE'%" + Text_Name.Text + "%' AND EMPLOYEES.EMPLOYEE_STATUS = '1'", connectionString);
            //Response.Write(1);
            dadapter = new OdbcDataAdapter("SELECT EMPLOYEES.EMPLOYEE_NO, EMPLOYEES.CARD_STATUS , EMPLOYEES.EMPLOYEE_NAME," +
                      "LKP_JOBS.JOB_NAME, EMPLOYEES.CONTACT_PHONES, EMPLOYEES.ID_CARD FROM EMPLOYEES " +
                      "INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO)" +
                      "INNER JOIN LKP_JOBS ON    (LKP_JOBS.JOB_NO = EMPLOYEES.JOB_NO)" +
                      "WHERE EMPLOYEES.DEPT_DEPARTMRNT_NO = '" + DropDownList1.SelectedValue + "' AND EMPLOYEES.EMPLOYEE_NAME LIKE'%" + Text_Name.Text + "%' AND EMPLOYEES.EMPLOYEE_STATUS = '1'", connectionString);
        }
        else
            if (Text_Name.Text == "" && DropDownList1.SelectedValue != "0")
            {
                //Response.Write(2);
                dadapter = new OdbcDataAdapter("SELECT EMPLOYEES.EMPLOYEE_NO,EMPLOYEES.CARD_STATUS,EMPLOYEES.EMPLOYEE_NAME," +
                       "LKP_JOBS.JOB_NAME, EMPLOYEES.CONTACT_PHONES, EMPLOYEES.ID_CARD FROM EMPLOYEES " +
                       "INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO) " +
                       "INNER JOIN LKP_JOBS ON    (LKP_JOBS.JOB_NO = EMPLOYEES.JOB_NO)" +
                       "WHERE EMPLOYEES.DEPT_DEPARTMRNT_NO = '" + DropDownList1.SelectedValue + "' AND EMPLOYEES.EMPLOYEE_STATUS = '1'", connectionString);
            }
            else
                if (Text_Name.Text == "" && DropDownList1.SelectedItem.Value == "0")
                {
                    //Response.Write(3);
                    dadapter = new OdbcDataAdapter("SELECT EMPLOYEES.EMPLOYEE_NO,EMPLOYEES.CARD_STATUS,EMPLOYEES.EMPLOYEE_NAME," +
                                          "LKP_JOBS.JOB_NAME, EMPLOYEES.CONTACT_PHONES, EMPLOYEES.ID_CARD FROM EMPLOYEES " +
                                          "INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO) " +
                                          "INNER JOIN LKP_JOBS ON    (LKP_JOBS.JOB_NO = EMPLOYEES.JOB_NO)" +
                                          "WHERE EMPLOYEES.EMPLOYEE_STATUS = '1'", connectionString);
                }
                else
                if ( Text_Name.Text != "" && DropDownList1.SelectedItem.Value == "0")
                    {
                        //Response.Write(4);
                        dadapter = new OdbcDataAdapter("SELECT EMPLOYEES.EMPLOYEE_NO,EMPLOYEES.CARD_STATUS,EMPLOYEES.EMPLOYEE_NAME," +
                                              "LKP_JOBS.JOB_NAME, EMPLOYEES.CONTACT_PHONES, EMPLOYEES.ID_CARD FROM EMPLOYEES " +
                                              "INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO) " +
                                              "INNER JOIN LKP_JOBS ON    (LKP_JOBS.JOB_NO = EMPLOYEES.JOB_NO)" +
                                              "WHERE EMPLOYEES.EMPLOYEE_NAME LIKE'%" + Text_Name.Text + "%' AND EMPLOYEES.EMPLOYEE_STATUS = '1'", connectionString);
                    }
        dset = new DataSet();
        dadapter.Fill(dset);
        GridView1.DataSource = dset.Tables[0];
        GridView1.DataBind();

        ///////////////////////////////////////////////////
        if (dset.Tables.Count > 0)
        {
            DataView dv = dset.Tables[0].DefaultView;
            if (ViewState["SortDirection"] != null)
            {
                sortDirection = ViewState["SortDirection"].ToString();
            }
            if (ViewState["SortExpression"] != null)
            {
                sortExpression = ViewState["SortExpression"].ToString();
                dv.Sort = string.Concat(sortExpression, " ", sortDirection);
            }

            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
    }
    protected void Butt1_Search_Click(object sender, EventArgs e)
    {
        GridViewBind();
        //Text_Name.Text = null;
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       GridViewBind(); 
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null || ViewState["SortExpression"].ToString() != e.SortExpression)
        {
            ViewState["SortDirection"] = "ASC";
            GridView1.PageIndex = GridView1.PageIndex;
        }
        else if (ViewState["SortDirection"].ToString() == "ASC")
        {
            ViewState["SortDirection"] = "DESC";
            //ViewState["SortDirection"] = SortDirection.Descending;
        }
        else if (ViewState["SortDirection"].ToString() == "DESC")
        {
            ViewState["SortDirection"] = "ASC";
            //ViewState["SortDirection"] = SortDirection.Ascending;
        }

        ViewState["SortExpression"] = e.SortExpression;
        //BindGridView();
        GridViewBind();
    }
    private void BindGridView()
    {
        dadapter = new OdbcDataAdapter(sql2, connectionString);
        dset = new DataSet();
        dadapter.Fill(dset);
        //GridViewBind();
        using (OdbcDataAdapter sda = new OdbcDataAdapter(sql2, connectionString))
        {
            sda.Fill(dset);
            if (dset.Tables.Count > 0)
            {
                DataView dv = dset.Tables[0].DefaultView;
                if (ViewState["SortDirection"] != null)
                {
                    sortDirection = ViewState["SortDirection"].ToString();
                }
                if (ViewState["SortExpression"] != null)
                {
                    sortExpression = ViewState["SortExpression"].ToString();
                    dv.Sort = string.Concat(sortExpression, " ", sortDirection);
                }

                GridView1.DataSource = dv;
                GridView1.DataBind();
            }
        }
    }


   //void check_change(Object sender, EventArgs e)
    //{

      //  if (ch.Checked)
        //{


        //}



    //}


   // void Check_Clicked(Object sender, EventArgs e)
   // {

     //   if (ch_ava.Checked)
       // {



        //} 

        // Calculate the subtotal and display the result in currency format.
        // Include tax if the check box is selected.
     //   Message.Text = CalculateTotal(checkbox1.Checked).ToString("c");

//    }





    public string sortExpression { get; set; }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //BindGridView();
        GridViewBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string number, strUrl;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.SelectedIndex == i)
            {
                number = GridView1.Rows[i].Cells[0].Text;
                strUrl = "EmpDetail.aspx?EMPLOYEE_NO=" + number.ToString() + "";
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + strUrl + "','_blank')", true);
                //Response.Redirect(strUrl, "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
                ClientScript.RegisterStartupScript(this.Page.GetType(), "", "window.open('" + strUrl + "','Graph','height=600,width=600');", true);
             }
        }
    }


    /*protected void Button1_Click(object sender, EventArgs e)
    {
     
       rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql, employee_val, uPrimaryid;



        foreach (GridViewRow rw in GridView1.Rows)
        {
            CheckBox chkBx = (CheckBox)rw.FindControl("card_box");
          
            if (chkBx.Checked)
            {
                //for ( i=0 ; 

                uPrimaryid = GridView1.Rows[0].Cells[1].Text.ToString();
                TextBox2.Text = uPrimaryid; 


            }
        }




    */

    /* protected void check_change(Object sender, EventArgs e)
     {
         foreach (GridViewRow row in GridView1.Rows)
         {
             // Access the CheckBox
             CheckBox cb = (CheckBox)row.FindControl("card_box");
             if (cb != null && cb.Checked)
             {
                 // Delete row! (Well, not really...)
                // atLeastOneRowDeleted = true;
                 // First, get the ProductID for the selected row
                 int productID =
                     Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);

                 TextBox2.Text = "productID";
                 // "Delete" the row
                 //DeleteResults.Text += string.Format(

                 //"This would have deleted ProductID {0}<br />", productID);
             }


         }*/
    
   /* protected void  Button1_Click(object sender, EventArgs e)
{


    foreach (GridViewRow row in GridView1.Rows)
    {
        // Access the CheckBox
        CheckBox cb = (CheckBox)row.FindControl("card_box");
        if (cb != null && cb.Checked)
        {
            // Delete row! (Well, not really...)
            // atLeastOneRowDeleted = true;
            // First, get the ProductID for the selected row
          //  int productID = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);


           // employee_val = row.Cells[1].Text;
            TextBox2.Text = "productID";
            // "Delete" the row
            //DeleteResults.Text += string.Format(

            //"This would have deleted ProductID {0}<br />", productID);
        }




}
}  */



   /* protected void Button1_Click(object sender, EventArgs e)
    {

         rootCfg    = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
         connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

         string str = string.Empty;
         string sql;
         string strname = string.Empty;
         //string lblRecord = string.Empty;

        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gvrow.FindControl("card_box");
            if (chk != null & chk.Checked)
            {
                str += "<b>EmpId :- </b>" + gvrow.Cells[1].Text + ", ";

            
                    
                }

                
       
           }

      

        lblRecord.Text = "<b>Selected EmpDetails: </b>" + str; 

  }*/



   



}