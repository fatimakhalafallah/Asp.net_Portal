using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data;
using System.Configuration;
using System.Collections;

public partial class UsersArea_Admin_Recruitment : System.Web.UI.Page
{
    public OdbcCommand comm = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter dadapter;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;

    public static string EMPLOYEE_NO, DEPARTMENT_NO, HRMANAGER, SUPERVISOR, GMANAGER, AUTHORNAME, MANAGER, SINMANAGER, FINANCEADMIN;
    public static string EmpName, EmpEmail, Depart, Status, EmpName2, EmpEmail2, EmpName3, EmpEmail3, EmpName4, EmpEmail4, EmpName5, EmpEmail5;
    DataSet dset, dset2;
    string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
    string sql;

    private string sortDirection;
    public static int No = 0;
        /*
         1\ MANAGER             (REQUESTER)
         2\ SIN MANAGER         (APPROVAL)
         3\ HR MANAGER          (APPROVAL)
         4\ FINANCE MANAGER     (APPROVAL)
         5\ G MANAGER           (APPROVAL)
         */
    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO     = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO   = Request.QueryString["DEP_NO"];
        HRMANAGER       = Request.QueryString["HRMNG"];
        GMANAGER        = Request.QueryString["GM"];

        SINMANAGER      = Request.QueryString["SMNG"];
        FINANCEADMIN    = Request.QueryString["FINADMIN"];

        if (EMPLOYEE_NO == "" || EMPLOYEE_NO == null && DEPARTMENT_NO == "" || DEPARTMENT_NO == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                EMPLOYEE_NO     = Request.QueryString["EMPLOYEE_NO"];
                DEPARTMENT_NO   = Request.QueryString["DEP_NO"];
                HRMANAGER       = Request.QueryString["HRMNG"];
                GMANAGER        = Request.QueryString["GM"];

                getMenu();
                GridViewBind();
                Panel1.Visible = false;
                RadioButtonList1.Visible = false;
                RadioButtonList2.Visible = false;
                //UserAuthorization();
            }
        }
    }
    /*public void GridViewBind()
    {
        EMPLOYEE_NO     = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO   = Request.QueryString["DEP_NO"];
        HRMANAGER       = Request.QueryString["HRMNG"];
        GMANAGER        = Request.QueryString["GM"];

        SINMANAGER      = Request.QueryString["SMNG"];
        FINANCEADMIN    = Request.QueryString["FINADMIN"];

        if (HRMANAGER == EMPLOYEE_NO)
        {
            No = 1;
            //Response.Write(No);
        }
        else
            if (GMANAGER == EMPLOYEE_NO)
            {
                No = 2;
                //Response.Write(No);
            }
            else


                if (SINMANAGER == EMPLOYEE_NO)
                {
                    No = 2;
                }
                else
                if (FINANCEADMIN == EMPLOYEE_NO)
                {
                    No = 2;
                }

        switch (No)
        {
            case 1:
                dadapter = new OdbcDataAdapter("SELECT RECRUITMENT_FORM.RF_NO, RECRUITMENT_FORM.MNG_CREATER, DEPARTMENTS.DEP_NAME, "+
                    "RECRUITMENT_FORM.POSITION_JUSTIFICATION, RECRUITMENT_FORM.NO_OF_CANDIDATE, RECRUITMENT_FORM.RF_DATE, "+
                    "RECRUITMENT_FORM.SINGLE_JUSTIFICATION, DECODE(RECRUITMENT_FORM.RF_TYPE, 1, 'Permanent', 2, 'Temporary')RF_TYPE " +
                    "FROM RECRUITMENT_FORM, "+
                    "DEPARTMENTS WHERE FORM_STATUS = '1' "+
                    "AND RECRUITMENT_FORM.DEP_NO = DEPARTMENTS.DEP_NO", connectionString);

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "2"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "3"));
                break;
            case 2:
                dadapter = new OdbcDataAdapter("SELECT RECRUITMENT_FORM.RF_NO, RECRUITMENT_FORM.MNG_CREATER, DEPARTMENTS.DEP_NAME, " +
                    "RECRUITMENT_FORM.POSITION_JUSTIFICATION, RECRUITMENT_FORM.NO_OF_CANDIDATE, RECRUITMENT_FORM.RF_DATE, " +
                    "RECRUITMENT_FORM.SINGLE_JUSTIFICATION, DECODE(RECRUITMENT_FORM.RF_TYPE, 1, 'Permanent', 2, 'Temporary')RF_TYPE " +
                    "FROM RECRUITMENT_FORM, " +
                    "DEPARTMENTS WHERE FORM_STATUS = '2' " +
                    "AND RECRUITMENT_FORM.DEP_NO = DEPARTMENTS.DEP_NO", connectionString);

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "4"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "5"));
                break;
            default:
                Label_Message.Text = "There are no Requests...";
                break;
        }
    }*///1
    /*public void GridViewBind()
    {
        EMPLOYEE_NO     = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO   = Request.QueryString["DEP_NO"];
        HRMANAGER       = Request.QueryString["HRMNG"];
        GMANAGER        = Request.QueryString["GM"];

        SINMANAGER      = Request.QueryString["SMNG"];
        FINANCEADMIN    = Request.QueryString["FINADMIN"];

        if (HRMANAGER == EMPLOYEE_NO)
        {
            No = 1;         //3
            //Response.Write(No);
        }
        else
            if (SINMANAGER == EMPLOYEE_NO)
            {
                No = 3;     //2
            }
            //else
        if (GMANAGER == EMPLOYEE_NO)
        {
            No = 2;  //5
            //Response.Write(No); 
        }
        else
            if (FINANCEADMIN == EMPLOYEE_NO)
            {
                No = 4;   //4
            }

        switch (No)
        {
            case 1: // HR MANAGER 3
                dadapter = new OdbcDataAdapter("SELECT DISTINCT RECRUITMENT_FORM.RF_NO, RECRUITMENT_FORM.MNG_CREATER, DEPARTMENTS.DEP_NAME, " +
                    "RECRUITMENT_FORM.POSITION_JUSTIFICATION, RECRUITMENT_FORM.NO_OF_CANDIDATE, RECRUITMENT_FORM.RF_DATE, " +
                    "RECRUITMENT_FORM.SINGLE_JUSTIFICATION, DECODE(RECRUITMENT_FORM.RF_TYPE, 1, 'Permanent', 2, 'Temporary')RF_TYPE " +
                    "FROM RECRUITMENT_FORM, DEPARTMENTS WHERE RECRUITMENT_FORM.FORM_STATUS = '2' " +
                    "AND RECRUITMENT_FORM.DEP_NO = DEPARTMENTS.DEP_NO", connectionString);

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "4"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "5"));
                break;
            case 2: //G MANAGER 5
                dadapter = new OdbcDataAdapter("SELECT DISTINCT RECRUITMENT_FORM.RF_NO, RECRUITMENT_FORM.MNG_CREATER, DEPARTMENTS.DEP_NAME, " +
                    "RECRUITMENT_FORM.POSITION_JUSTIFICATION, RECRUITMENT_FORM.NO_OF_CANDIDATE, RECRUITMENT_FORM.RF_DATE, " +
                    "RECRUITMENT_FORM.SINGLE_JUSTIFICATION, DECODE(RECRUITMENT_FORM.RF_TYPE, 1, 'Permanent', 2, 'Temporary')RF_TYPE " +
                    "FROM RECRUITMENT_FORM, DEPARTMENTS WHERE RECRUITMENT_FORM.FORM_STATUS = '6' " +
                    "AND RECRUITMENT_FORM.DEP_NO = DEPARTMENTS.DEP_NO", connectionString);

                dset2 = new DataSet();
                dadapter.Fill(dset2);
                GridView3.DataSource = dset2.Tables[0];
                GridView3.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "8"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "9"));
                break;
            case 3: //SIN MANAGER (NEW) 2
                dadapter = new OdbcDataAdapter("SELECT DISTINCT RECRUITMENT_FORM.RF_NO, RECRUITMENT_FORM.MNG_CREATER, DEPARTMENTS.DEP_NAME, " +
                    "RECRUITMENT_FORM.POSITION_JUSTIFICATION, RECRUITMENT_FORM.NO_OF_CANDIDATE, RECRUITMENT_FORM.RF_DATE, " +
                    "RECRUITMENT_FORM.SINGLE_JUSTIFICATION, DECODE(RECRUITMENT_FORM.RF_TYPE, 1, 'Permanent', 2, 'Temporary')RF_TYPE " +
                    "FROM RECRUITMENT_FORM, DEPARTMENTS, EMPLOYEES WHERE RECRUITMENT_FORM.FORM_STATUS = '1' " +
                    "AND RECRUITMENT_FORM.DEP_NO = DEPARTMENTS.DEP_NO "+
                    "AND RECRUITMENT_FORM.MNG_CREATER IN (SELECT MNG FROM EMP_MNG WHERE SMNG = '"+ SINMANAGER +"') ", connectionString);

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "2"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "3"));
                break;
            case 4: //FINANCE ADMIN (NEW) 4
                dadapter = new OdbcDataAdapter("SELECT DISTINCT RECRUITMENT_FORM.RF_NO, RECRUITMENT_FORM.MNG_CREATER, DEPARTMENTS.DEP_NAME, " +
                    "RECRUITMENT_FORM.POSITION_JUSTIFICATION, RECRUITMENT_FORM.NO_OF_CANDIDATE, RECRUITMENT_FORM.RF_DATE, " +
                    "RECRUITMENT_FORM.SINGLE_JUSTIFICATION, DECODE(RECRUITMENT_FORM.RF_TYPE, 1, 'Permanent', 2, 'Temporary')RF_TYPE " +
                    "FROM RECRUITMENT_FORM, DEPARTMENTS WHERE RECRUITMENT_FORM.FORM_STATUS = '4' " +
                    "AND RECRUITMENT_FORM.DEP_NO = DEPARTMENTS.DEP_NO", connectionString);

                dset2 = new DataSet();
                dadapter.Fill(dset2);
                GridView3.DataSource = dset2.Tables[0];
                GridView3.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "6"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "7"));
                break;
            default:
                Label_Message.Text = "You aren't Authorized to See this Contents...";//"There are no Requests...";
                break;
        }
    }*///2
    /*   public void GridViewBind()
       {
           EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
           DEPARTMENT_NO = Request.QueryString["DEP_NO"];
           HRMANAGER = Request.QueryString["HRMNG"];
           GMANAGER = Request.QueryString["GM"];

           SINMANAGER = Request.QueryString["SMNG"];
           FINANCEADMIN = Request.QueryString["FINADMIN"];

           if (HRMANAGER == EMPLOYEE_NO)
           {
               No = 1;         //3
               //Response.Write(No);
               dadapter = new OdbcDataAdapter("SELECT DISTINCT RECRUITMENT_FORM.RF_NO, RECRUITMENT_FORM.MNG_CREATER, DEPARTMENTS.DEP_NAME, " +
                      "RECRUITMENT_FORM.POSITION_JUSTIFICATION, RECRUITMENT_FORM.NO_OF_CANDIDATE, RECRUITMENT_FORM.RF_DATE, " +
                      "RECRUITMENT_FORM.SINGLE_JUSTIFICATION, DECODE(RECRUITMENT_FORM.RF_TYPE, 1, 'Permanent', 2, 'Temporary')RF_TYPE " +
                      "FROM RECRUITMENT_FORM, DEPARTMENTS WHERE RECRUITMENT_FORM.FORM_STATUS = '2' " +
                      "AND RECRUITMENT_FORM.DEP_NO = DEPARTMENTS.DEP_NO", connectionString);

               dset = new DataSet();
               dadapter.Fill(dset);
               GridView1.DataSource = dset.Tables[0];
               GridView1.DataBind();

               RadioButtonList1.Items.Clear();
               RadioButtonList1.Items.Add(new ListItem("Approve", "4"));
               RadioButtonList1.Items.Add(new ListItem("Reject", "5"));
           }
           else
               if (SINMANAGER == EMPLOYEE_NO)
               {
                  No = 3;     //2
                   dadapter = new OdbcDataAdapter("SELECT DISTINCT RECRUITMENT_FORM.RF_NO, RECRUITMENT_FORM.MNG_CREATER, DEPARTMENTS.DEP_NAME, " +
                      "RECRUITMENT_FORM.POSITION_JUSTIFICATION, RECRUITMENT_FORM.NO_OF_CANDIDATE, RECRUITMENT_FORM.RF_DATE, " +
                      "RECRUITMENT_FORM.SINGLE_JUSTIFICATION, DECODE(RECRUITMENT_FORM.RF_TYPE, 1, 'Permanent', 2, 'Temporary')RF_TYPE " +
                      "FROM RECRUITMENT_FORM, DEPARTMENTS, EMPLOYEES WHERE RECRUITMENT_FORM.FORM_STATUS = '1' " +
                      "AND RECRUITMENT_FORM.DEP_NO = DEPARTMENTS.DEP_NO " +
                      "AND RECRUITMENT_FORM.MNG_CREATER IN (SELECT MNG FROM EMP_MNG WHERE SMNG = '" + SINMANAGER + "') ", connectionString);

                   dset = new DataSet();
                   dadapter.Fill(dset);
                   GridView1.DataSource = dset.Tables[0];
                   GridView1.DataBind();

                   RadioButtonList1.Items.Clear();
                   RadioButtonList1.Items.Add(new ListItem("Approve", "2"));
                   RadioButtonList1.Items.Add(new ListItem("Reject", "3"));
               }
           //else
           if (GMANAGER == EMPLOYEE_NO)
           {
               No = 2;  //5
               //Response.Write(No); 
               dadapter = new OdbcDataAdapter("SELECT DISTINCT RECRUITMENT_FORM.RF_NO, RECRUITMENT_FORM.MNG_CREATER, DEPARTMENTS.DEP_NAME, " +
                    "RECRUITMENT_FORM.POSITION_JUSTIFICATION, RECRUITMENT_FORM.NO_OF_CANDIDATE, RECRUITMENT_FORM.RF_DATE, " +
                    "RECRUITMENT_FORM.SINGLE_JUSTIFICATION, DECODE(RECRUITMENT_FORM.RF_TYPE, 1, 'Permanent', 2, 'Temporary')RF_TYPE " +
                    "FROM RECRUITMENT_FORM, DEPARTMENTS WHERE RECRUITMENT_FORM.FORM_STATUS = '6' " +
                    "AND RECRUITMENT_FORM.DEP_NO = DEPARTMENTS.DEP_NO", connectionString);

               dset2 = new DataSet();
               dadapter.Fill(dset2);
               GridView3.DataSource = dset2.Tables[0];
               GridView3.DataBind();

               RadioButtonList2.Items.Clear();
               RadioButtonList2.Items.Add(new ListItem("Approve", "8"));
               RadioButtonList2.Items.Add(new ListItem("Reject", "9"));
           }
           else
               if (FINANCEADMIN == EMPLOYEE_NO)
               {
                   No = 4;   //4
                   dadapter = new OdbcDataAdapter("SELECT DISTINCT RECRUITMENT_FORM.RF_NO, RECRUITMENT_FORM.MNG_CREATER, DEPARTMENTS.DEP_NAME, " +
                     "RECRUITMENT_FORM.POSITION_JUSTIFICATION, RECRUITMENT_FORM.NO_OF_CANDIDATE, RECRUITMENT_FORM.RF_DATE, " +
                     "RECRUITMENT_FORM.SINGLE_JUSTIFICATION, DECODE(RECRUITMENT_FORM.RF_TYPE, 1, 'Permanent', 2, 'Temporary')RF_TYPE " +
                     "FROM RECRUITMENT_FORM, DEPARTMENTS WHERE RECRUITMENT_FORM.FORM_STATUS = '4' " +
                     "AND RECRUITMENT_FORM.DEP_NO = DEPARTMENTS.DEP_NO", connectionString);

                   dset2 = new DataSet();
                   dadapter.Fill(dset2);
                   GridView3.DataSource = dset2.Tables[0];
                   GridView3.DataBind();

                   RadioButtonList2.Items.Clear();
                   RadioButtonList2.Items.Add(new ListItem("Approve", "6"));
                   RadioButtonList2.Items.Add(new ListItem("Reject", "7"));
               }
       }*///3
    public void GridViewBind()
    {
        EMPLOYEE_NO     = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO   = Request.QueryString["DEP_NO"];
        HRMANAGER       = Request.QueryString["HRMNG"];
        GMANAGER        = Request.QueryString["GM"];

        SINMANAGER      = Request.QueryString["SMNG"];
        FINANCEADMIN    = Request.QueryString["FINADMIN"];

        if (SINMANAGER == EMPLOYEE_NO)
        {
            No = 3;     //2
            dadapter = new OdbcDataAdapter("SELECT DISTINCT RECRUITMENT_FORM.RF_NO, RECRUITMENT_FORM.MNG_CREATER, DEPARTMENTS.DEP_NAME, " +
               "RECRUITMENT_FORM.POSITION_JUSTIFICATION, RECRUITMENT_FORM.NO_OF_CANDIDATE, RECRUITMENT_FORM.RF_DATE, " +
               "RECRUITMENT_FORM.SINGLE_JUSTIFICATION, DECODE(RECRUITMENT_FORM.RF_TYPE, 1, 'Permanent', 2, 'Temporary')RF_TYPE " +
               "FROM RECRUITMENT_FORM, DEPARTMENTS, EMPLOYEES WHERE RECRUITMENT_FORM.FORM_STATUS = '1' " +
               "AND RECRUITMENT_FORM.DEP_NO = DEPARTMENTS.DEP_NO " +
               "AND RECRUITMENT_FORM.MNG_CREATER IN (SELECT MNG FROM EMP_MNG WHERE SMNG = '" + SINMANAGER + "') ", connectionString);

            dset = new DataSet();
            dadapter.Fill(dset);
            GridView1.DataSource = dset.Tables[0];
            GridView1.DataBind();

            RadioButtonList1.Items.Clear();
            RadioButtonList1.Items.Add(new ListItem("Approve", "2"));
            RadioButtonList1.Items.Add(new ListItem("Reject", "3"));
        }
        else
        if (HRMANAGER == EMPLOYEE_NO)
        {
            No = 1;         //3
            dadapter = new OdbcDataAdapter("SELECT DISTINCT RECRUITMENT_FORM.RF_NO, RECRUITMENT_FORM.MNG_CREATER, DEPARTMENTS.DEP_NAME, " +
                   "RECRUITMENT_FORM.POSITION_JUSTIFICATION, RECRUITMENT_FORM.NO_OF_CANDIDATE, RECRUITMENT_FORM.RF_DATE, " +
                   "RECRUITMENT_FORM.SINGLE_JUSTIFICATION, DECODE(RECRUITMENT_FORM.RF_TYPE, 1, 'Permanent', 2, 'Temporary')RF_TYPE " +
                   "FROM RECRUITMENT_FORM, DEPARTMENTS WHERE RECRUITMENT_FORM.FORM_STATUS = '2' " +
                   "AND RECRUITMENT_FORM.DEP_NO = DEPARTMENTS.DEP_NO", connectionString);

            dset = new DataSet();
            dadapter.Fill(dset);
            GridView1.DataSource = dset.Tables[0];
            GridView1.DataBind();

            RadioButtonList1.Items.Clear();
            RadioButtonList1.Items.Add(new ListItem("Approve", "4"));
            RadioButtonList1.Items.Add(new ListItem("Reject", "5"));
        }

         if (FINANCEADMIN == EMPLOYEE_NO)
            {
                No = 4;   //4
                dadapter = new OdbcDataAdapter("SELECT DISTINCT RECRUITMENT_FORM.RF_NO, RECRUITMENT_FORM.MNG_CREATER, DEPARTMENTS.DEP_NAME, " +
                  "RECRUITMENT_FORM.POSITION_JUSTIFICATION, RECRUITMENT_FORM.NO_OF_CANDIDATE, RECRUITMENT_FORM.RF_DATE, " +
                  "RECRUITMENT_FORM.SINGLE_JUSTIFICATION, DECODE(RECRUITMENT_FORM.RF_TYPE, 1, 'Permanent', 2, 'Temporary')RF_TYPE " +
                  "FROM RECRUITMENT_FORM, DEPARTMENTS WHERE RECRUITMENT_FORM.FORM_STATUS = '4' " +
                  "AND RECRUITMENT_FORM.DEP_NO = DEPARTMENTS.DEP_NO", connectionString);

                dset2 = new DataSet();
                dadapter.Fill(dset2);
                GridView3.DataSource = dset2.Tables[0];
                GridView3.DataBind();

                RadioButtonList2.Items.Clear();
                RadioButtonList2.Items.Add(new ListItem("Approve", "6"));
                RadioButtonList2.Items.Add(new ListItem("Reject", "7"));
            }
        else
        if (GMANAGER == EMPLOYEE_NO)
        {
            No = 2;  //5
            //Response.Write(No); 
            dadapter = new OdbcDataAdapter("SELECT DISTINCT RECRUITMENT_FORM.RF_NO, RECRUITMENT_FORM.MNG_CREATER, DEPARTMENTS.DEP_NAME, " +
                 "RECRUITMENT_FORM.POSITION_JUSTIFICATION, RECRUITMENT_FORM.NO_OF_CANDIDATE, RECRUITMENT_FORM.RF_DATE, " +
                 "RECRUITMENT_FORM.SINGLE_JUSTIFICATION, DECODE(RECRUITMENT_FORM.RF_TYPE, 1, 'Permanent', 2, 'Temporary')RF_TYPE " +
                 "FROM RECRUITMENT_FORM, DEPARTMENTS WHERE RECRUITMENT_FORM.FORM_STATUS = '6' " +
                 "AND RECRUITMENT_FORM.DEP_NO = DEPARTMENTS.DEP_NO", connectionString);

            dset2 = new DataSet();
            dadapter.Fill(dset2);
            GridView3.DataSource = dset2.Tables[0];
            GridView3.DataBind();

            RadioButtonList2.Items.Clear();
            RadioButtonList2.Items.Add(new ListItem("Approve", "8"));
            RadioButtonList2.Items.Add(new ListItem("Reject", "9"));
        }
           
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridViewBind();
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        GridViewBind();
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new
            GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Admin Area: Recruitment List (Senior Manager, HR Manager)";
            HeaderCell.ColumnSpan = 8;
            HeaderGridRow.Cells.Add(HeaderCell);
            GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }
    protected void GridView3_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new
            GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Admin Area: Recruitment List (Finance Manager, General Manager)";
            HeaderCell.ColumnSpan = 8;
            HeaderGridRow.Cells.Add(HeaderCell);
            GridView3.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }
    public string sortExpression { get; set; }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label_Message.Text = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.SelectedIndex == i)
            {
                string FORM_NO = GridView1.Rows[i].Cells[0].Text;
                TextBox1.Text = FORM_NO.ToString();
                TextBox2.Text = GridView1.Rows[i].Cells[1].Text;
                UserRecruitmentDetails();
                Panel1.Visible = true;
                RadioButtonList1.Visible = true;
                RadioButtonList2.Visible = false;
            }
        }
    }
    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label_Message.Text = "";
        for (int i = 0; i < GridView3.Rows.Count; i++)
        {
            if (GridView3.SelectedIndex == i)
            {
                string FORM_NO = GridView3.Rows[i].Cells[0].Text;
                TextBox1.Text = FORM_NO.ToString();
                TextBox2.Text = GridView3.Rows[i].Cells[1].Text;
                UserRecruitmentDetails();
                Panel1.Visible = true;
                RadioButtonList1.Visible = false;
                RadioButtonList2.Visible = true;
            }
        }
    }
    void UserRecruitmentDetails()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

        con = new OdbcConnection(connection);
        con.ConnectionString = connection;

        dadapter = new OdbcDataAdapter("SELECT SERIAL_NO, CAND_NAME, EXP_YEAR, ADD_CREDIT, REMARKS FROM RECRUITMENT_DTL WHERE RF_NO = '" + Convert.ToInt32(TextBox1.Text) + "'", connection);

        dset = new DataSet();
        dadapter.Fill(dset);
        GridView2.DataSource = dset.Tables[0];
        GridView2.DataBind();

    }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        UpdateFormStatus();
        //Status = RadioButtonList1.SelectedItem.Text.ToString();
        //SendEMail(Status);
        Reset();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
        Panel1.Visible = false;
    }
    private void UpdateFormStatus()
    {
        EMPLOYEE_NO     = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO   = Request.QueryString["DEP_NO"];
        HRMANAGER       = Request.QueryString["HRMNG"];
        GMANAGER        = Request.QueryString["GM"];

        SINMANAGER      = Request.QueryString["SMNG"];
        FINANCEADMIN    = Request.QueryString["FINADMIN"];

        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql, date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        if (TextBox1.Text != "")
        {
            if (HRMANAGER == EMPLOYEE_NO && RadioButtonList1.SelectedValue != "")
            //if (No == 1)
           { 
               sql = "UPDATE RECRUITMENT_FORM SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "' " +
                ", HR_ID = '" + EMPLOYEE_NO + "', HR_DATE = '" + date + "'WHERE RF_NO = '" + TextBox1.Text + "'";
            con = new OdbcConnection(connection);
            con.ConnectionString = connection;
            con.Open();

            comm = new OdbcCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
            //Page.Response.Redirect(Page.Request.Url.ToString(), true);
            //Reset();
            Status = RadioButtonList1.SelectedItem.Text.ToString();
            SendEMail(Status, 3);
            Label_Message.Text = "Successfully...";
           }
            else
               if (SINMANAGER == EMPLOYEE_NO && RadioButtonList1.SelectedValue != "")
            //    if (No == 3)
           {
               sql = "UPDATE RECRUITMENT_FORM SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "' " +
               ", SNR_MNG_ID = '" + EMPLOYEE_NO + "', SNR_MNG_DATE = '" + date + "'WHERE RF_NO = '" + TextBox1.Text + "'";
               con = new OdbcConnection(connection);
               con.ConnectionString = connection;
               con.Open();

               comm = new OdbcCommand(sql, con);
               comm.ExecuteNonQuery();
               con.Close();
               //Page.Response.Redirect(Page.Request.Url.ToString(), true);
               //Reset();
               Status = RadioButtonList1.SelectedItem.Text.ToString();
               SendEMail(Status, 2);
               Label_Message.Text = "Successfully...";
           }
            else
               if (GMANAGER == EMPLOYEE_NO && RadioButtonList2.SelectedValue != "")
            //if (No == 2)
            {
                sql = "UPDATE RECRUITMENT_FORM SET FORM_STATUS = '" + RadioButtonList2.SelectedValue + "' " +
                ", GM_ID = '" + EMPLOYEE_NO + "', GM_DATE = '" + date + "'WHERE RF_NO = '" + TextBox1.Text + "'";
                con = new OdbcConnection(connection);
                con.ConnectionString = connection;
                con.Open();

                comm = new OdbcCommand(sql, con);
                comm.ExecuteNonQuery();
                con.Close();
                //Page.Response.Redirect(Page.Request.Url.ToString(), true);
                //Reset();
                Status = RadioButtonList2.SelectedItem.Text.ToString();
                SendEMail(Status, 5);
                Label_Message.Text = "Successfully...";
            }
           else
                if (FINANCEADMIN == EMPLOYEE_NO && RadioButtonList2.SelectedValue != "")
                //if (No == 4)
               {
                   sql = "UPDATE RECRUITMENT_FORM SET FORM_STATUS = '" + RadioButtonList2.SelectedValue + "' " +
                   ", ADMIN_ID = '" + EMPLOYEE_NO + "', ADMIN_DATE = '" + date + "'WHERE RF_NO = '" + TextBox1.Text + "'";
                   con = new OdbcConnection(connection);
                   con.ConnectionString = connection;
                   con.Open();

                   comm = new OdbcCommand(sql, con);
                   comm.ExecuteNonQuery();
                   con.Close();
                   //Page.Response.Redirect(Page.Request.Url.ToString(), true);
                   //Reset();
                   Status = RadioButtonList2.SelectedItem.Text.ToString();
                   SendEMail(Status, 4);
                   Label_Message.Text = "Successfully...";
               }
        }
        else
        {
            Reset();
            Panel1.Visible = false;
        }
    }
    private void getMenu()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString2"].ConnectionString.ToString();

        conn = new SqlConnection(connection);
        conn.ConnectionString = connection;
        conn.Open();

        DataTable table = new DataTable();


        string sql = "Select * from tbl_WebMenu INNER JOIN User_Check ON (tbl_WebMenu.MenuID = User_Check.MenuID)" +
            //"AND (User_Check.MenuID = tbl_WebMenu.ParentID)" +
                      "AND (User_Check.EmpNumber = '" + EMPLOYEE_NO + "' ) AND (User_Check.STATUS = '" + 1 + "')";

        SqlDataAdapter da = new SqlDataAdapter(sql, conn);

        da.Fill(table);
        DataView view = new DataView(table);
        view.RowFilter = "ParentID=0";
        foreach (DataRowView row in view)
        {
            MenuItem menuItem = new MenuItem(row["MenuName"].ToString(),
            row["MenuID"].ToString());
            menuItem.NavigateUrl = row["MenuID"].ToString() + row["MenuLocation"] + "?EMPLOYEE_NO=" + EMPLOYEE_NO.ToString() + "&DEP_NO=" + DEPARTMENT_NO.ToString();
            menuBar.Items.Add(menuItem);
            AddChildItems(table, menuItem);
        }
        conn.Close();
    }

    private void AddChildItems(DataTable table, MenuItem menuItem)
    {
        DataView viewItem = new DataView(table);
        viewItem.RowFilter = "ParentID=" + menuItem.Value;
        foreach (DataRowView childView in viewItem)
        {
            MenuItem childItem = new MenuItem(childView["MenuName"].ToString(),
            childView["MenuID"].ToString());
            // childItem.NavigateUrl = childView["MenuLocation"].ToString();
            childItem.NavigateUrl = childView["MenuLocation"].ToString() + "?EMPLOYEE_NO=" + EMPLOYEE_NO.ToString() + "&DEP_NO=" + DEPARTMENT_NO.ToString();

            menuItem.ChildItems.Add(childItem);
            AddChildItems(table, childItem);
        }
    }
    void Reset()
    { 
        TextBox1.Text = ""; 
        TextBox2.Text = ""; 
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset();
        Panel1.Visible = false;
        RadioButtonList1.Visible = false;
        RadioButtonList2.Visible = false;
    }
    public void SendEMail(string Status, int UserCheck)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        // Requester Name (MANAGER)
        string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
                     "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND "+
                     "USERS_INFORMATIONS.EMPLOYEE_NO = '" + TextBox2.Text + "'";

        // Aproval Name (SIN MANAGER) 2
        string sql2 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + SINMANAGER + "'";

        // Aproval Name (HR)  3
        //string sql2 = "SELECT FULL_USER_NAME FROM USERS_INFORMATIONS WHERE EMPLOYEE_NO = '" + HRMANAGER + "'";
        string sql3 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + HRMANAGER + "'";

        // Aproval Name (FINANCE ADMIN)  4
        string sql4 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + FINANCEADMIN + "'";

        // Aproval Name (GM)   5
        string sql5 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND "+
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + GMANAGER + "'";
       

        OdbcConnection conn = new OdbcConnection(connectionString);

        OdbcCommand cmd     = new OdbcCommand(sql, conn);
        OdbcCommand cmd2    = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3    = new OdbcCommand(sql3, conn);

        OdbcCommand cmd4    = new OdbcCommand(sql4, conn);
        OdbcCommand cmd5    = new OdbcCommand(sql5, conn);

        cmd.Connection.Open();

        OdbcDataReader read     = cmd.ExecuteReader();
        OdbcDataReader read2    = cmd2.ExecuteReader();
        OdbcDataReader read3    = cmd3.ExecuteReader();

        OdbcDataReader read4    = cmd4.ExecuteReader();
        OdbcDataReader read5    = cmd5.ExecuteReader();

        read.Read();
        read2.Read();
        read3.Read();
        read4.Read();
        read5.Read();

        if (read.HasRows)
        {
            EmpName     = read["FULL_USER_NAME"].ToString();
            EmpEmail    = read["EMAIL"].ToString();
            Depart      = read["DEP_NAME"].ToString();
        } 
        if (read2.HasRows) //(SIN MANAGER)
        {
            EmpName2 = read2["FULL_USER_NAME"].ToString();
            EmpEmail2 = read2["EMAIL"].ToString();
            AUTHORNAME = read2["FULL_USER_NAME"].ToString();
        }
        if (read3.HasRows) //(HR)
        {
            EmpName3    = read3["FULL_USER_NAME"].ToString();
            EmpEmail3   = read3["EMAIL"].ToString();
        }
        if (read4.HasRows) //(FINANCE ADMIN)
        {
            EmpName4    = read4["FULL_USER_NAME"].ToString();
            EmpEmail4   = read4["EMAIL"].ToString();
        }
        if (read5.HasRows)  //(GM)
        {
            EmpName5    = read5["FULL_USER_NAME"].ToString();
            EmpEmail5   = read5["EMAIL"].ToString();
        }

        // Aproval Name (SIN MANAGER) NEW 2
       // if (SINMANAGER == EMPLOYEE_NO)
        if (UserCheck == 2)
        {
            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
            "&ApprovalName=" + EmpName3 + "&ApprovalEmail=" + EmpEmail3 + "&REQNAME=Recruitment Request&AUTHORNAME=" + EmpName2 + "");
            //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=PORTAL@PETRONEEDS.CO&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
            //"&ApprovalName=" + EmpName3 + "&ApprovalEmail=PORTAL@PETRONEEDS.CO&REQNAME=Recruitment Request&AUTHORNAME=" + EmpName2 + "");
        }
        else
            //if (HRMANAGER == EMPLOYEE_NO)
        if (UserCheck == 3)
        {
            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
            "&ApprovalName=" + EmpName4 + "&ApprovalEmail=" + EmpEmail4 + "&REQNAME=Recruitment Request&AUTHORNAME=" + EmpName3 + "");
            //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=PORTAL@PETRONEEDS.CO&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
            //"&ApprovalName=" + EmpName4 + "&ApprovalEmail=PORTAL@PETRONEEDS.CO&REQNAME=Recruitment Request&AUTHORNAME=" + EmpName3 + "");
        }
        else
            //if (FINANCEADMIN == EMPLOYEE_NO) 
                if (UserCheck == 4)
        {
            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
            "&ApprovalName=" + EmpName5 + "&ApprovalEmail=" + EmpEmail5 + "&REQNAME=Recruitment Request&AUTHORNAME=" + EmpName4 + "");
   //         Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=PORTAL@PETRONEEDS.CO&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
   //"&ApprovalName=" + EmpName5 + "&ApprovalEmail=PORTAL@PETRONEEDS.CO&REQNAME=Recruitment Request&AUTHORNAME=" + EmpName4 + "");
        }
            else
            //if (GMANAGER == EMPLOYEE_NO)
                if (UserCheck == 5)
        {
            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
            "&ApprovalName=" + EmpName3 + "&ApprovalEmail=" + EmpEmail3 + "&REQNAME=Recruitment Request&AUTHORNAME=" + EmpName5 + "");
  //          Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=PORTAL@PETRONEEDS.CO&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
  //"&ApprovalName=" + EmpName3 + "&ApprovalEmail=PORTAL@PETRONEEDS.CO&REQNAME=Recruitment Request&AUTHORNAME=" + EmpName5 + "");
        }
        //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "&AUTHORNAME=" + AUTHORNAME + "&REQNAME=Recruitment Request");
        cmd.Connection.Close();
        cmd2.Connection.Close();
        }
    // PAGE CONTENTS FOR ONLY MANAGERS
    void UserAuthorization()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

      
        string sql = "SELECT MNG FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "'";
        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            MANAGER = read["MNG"].ToString();  
        }
        else
        {
            GridView1.Enabled = false;
            GridView2.Enabled = false;
            Label_Message.Text = "You are not Authorized to See this Contents ...";
        }
        cmd.Connection.Close();
    }
   
}