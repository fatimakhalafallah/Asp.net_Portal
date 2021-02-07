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

public partial class UsersArea_Admin_FunctionRequest : System.Web.UI.Page
{
    public OdbcCommand odbccomm     = null;
    public OdbcConnection odbccon   = null;
    public OdbcDataAdapter odbcdadapter;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand sqlcommand = null;
    public SqlConnection sqlconn = null;
    public SqlCommand comm = null;
    public SqlConnection con = null;


   

    public static string EMPLOYEE_NO, DEPARTMENT_NO, MANAGER, HRMANAGER, GMANAGER, AUTHORNAME;
    public static string EmpName, EmpEmail, Depart, Status, EmpName3, EmpEmail3, Depart3, EmpName4, EmpEmail4, Depart4, EmpName2, EmpEmail2;
    public static string FORM_NO = "";

    DataSet dataset;
    string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
    //string sql;

    //private string sortDirection;
    private int No;

    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        MANAGER = Request.QueryString["MNG"];
        HRMANAGER = Request.QueryString["HRMNG"];
        GMANAGER = Request.QueryString["GM"];

        if (EMPLOYEE_NO == "" || EMPLOYEE_NO == null && DEPARTMENT_NO == "" || DEPARTMENT_NO == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
                DEPARTMENT_NO = Request.QueryString["DEP_NO"];
                MANAGER = Request.QueryString["MNG"];
                HRMANAGER = Request.QueryString["HRMNG"];
                GMANAGER = Request.QueryString["GM"];

                getMenu();
                RadioButtonList1.Items.Clear();
                RadioButtonList2.Items.Clear();
                GridViewBind();
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
        }
    }
    /* public void GridViewBind()
     {
         EMPLOYEE_NO     = Request.QueryString["EMPLOYEE_NO"];
         DEPARTMENT_NO   = Request.QueryString["DEP_NO"];
         MANAGER         = Request.QueryString["MNG"];
         HRMANAGER       = Request.QueryString["HRMNG"];
         GMANAGER        = Request.QueryString["GM"];

         if (MANAGER == EMPLOYEE_NO)
         {
             No = 1;
         }
         else
             if (GMANAGER == EMPLOYEE_NO)
             {
                 No = 2;
             }
        switch (No)
         {
             case 1:
                  odbcdadapter = new OdbcDataAdapter("SELECT ES_FUNCTION_REQ.REQUEST_NO, ES_FUNCTION_REQ.CREATED_USER, ES_FUNCTION_REQ.RQUESTDATE, DEPARTMENTS.DEP_NAME, EMPLOYEES.EMPLOYEE_NAME "+
                      "FROM ES_FUNCTION_REQ, DEPARTMENTS, EMPLOYEES, EMP_MNG " +
                      "WHERE ES_FUNCTION_REQ.CREATED_USER = EMPLOYEES.EMPLOYEE_NO AND "+
                      "DEPARTMENTS.DEP_NO = ES_FUNCTION_REQ.DEPT AND ES_FUNCTION_REQ.STATUS = '0' AND ES_FUNCTION_REQ.CREATED_USER = EMP_MNG.EMPLOYEE_NO "+
                      "AND EMP_MNG.MNG = " + EMPLOYEE_NO + "", connectionString);

                     dataset = new DataSet();
                     odbcdadapter.Fill(dataset);
                     GridView1.DataSource = dataset.Tables[0];
                     GridView1.DataBind();

                 RadioButtonList1.Items.Add(new ListItem("Approve", "4"));
                 RadioButtonList1.Items.Add(new ListItem("Reject", "5"));
                 break;
             case 2:
                 odbcdadapter = new OdbcDataAdapter("SELECT ES_FUNCTION_REQ.REQUEST_NO, ES_FUNCTION_REQ.CREATED_USER, ES_FUNCTION_REQ.RQUESTDATE, DEPARTMENTS.DEP_NAME, EMPLOYEES.EMPLOYEE_NAME" +
                     " FROM ES_FUNCTION_REQ, DEPARTMENTS, EMPLOYEES" +
                     " WHERE ES_FUNCTION_REQ.CREATED_USER = EMPLOYEES.EMPLOYEE_NO AND DEPARTMENTS.DEP_NO = ES_FUNCTION_REQ.DEPT AND ES_FUNCTION_REQ.STATUS = '4'", connectionString);

                 dataset = new DataSet();
                 odbcdadapter.Fill(dataset);
                 GridView1.DataSource = dataset.Tables[0];
                 GridView1.DataBind();

                 RadioButtonList1.Items.Add(new ListItem("Approve", "6"));
                 RadioButtonList1.Items.Add(new ListItem("Reject", "7"));
                 break;
             default:
                 Label_Message.Text = "There are no Requests...";
              break;
         }
     }*/
    public void GridViewBind()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        MANAGER = Request.QueryString["MNG"];
        HRMANAGER = Request.QueryString["HRMNG"];
        GMANAGER = Request.QueryString["GM"];

        if (MANAGER == EMPLOYEE_NO)
        {
            odbcdadapter = new OdbcDataAdapter("SELECT ES_FUNCTION_REQ.REQUEST_NO, ES_FUNCTION_REQ.CREATED_USER, ES_FUNCTION_REQ.RQUESTDATE, DEPARTMENTS.DEP_NAME, EMPLOYEES.EMPLOYEE_NAME " +
                   "FROM ES_FUNCTION_REQ, DEPARTMENTS, EMPLOYEES, EMP_MNG " +
                   "WHERE ES_FUNCTION_REQ.CREATED_USER = EMPLOYEES.EMPLOYEE_NO AND " +
                   "DEPARTMENTS.DEP_NO = ES_FUNCTION_REQ.DEPT AND ES_FUNCTION_REQ.STATUS = '0' AND ES_FUNCTION_REQ.CREATED_USER = EMP_MNG.EMPLOYEE_NO " +
                   "AND EMP_MNG.MNG = " + EMPLOYEE_NO + "", connectionString);

            dataset = new DataSet();
            odbcdadapter.Fill(dataset);
            GridView1.DataSource = dataset.Tables[0];
            GridView1.DataBind();

            RadioButtonList1.Items.Clear();
            RadioButtonList1.Items.Add(new ListItem("Approve", "4"));
            RadioButtonList1.Items.Add(new ListItem("Reject", "5"));
        }
        else
        { 
            //Label_Message.Text = "There are no Requests..."; 
        }
            if (GMANAGER == EMPLOYEE_NO)
            {
                odbcdadapter = new OdbcDataAdapter("SELECT ES_FUNCTION_REQ.REQUEST_NO, ES_FUNCTION_REQ.CREATED_USER, ES_FUNCTION_REQ.RQUESTDATE, DEPARTMENTS.DEP_NAME, EMPLOYEES.EMPLOYEE_NAME" +
                    " FROM ES_FUNCTION_REQ, DEPARTMENTS, EMPLOYEES" +
                    " WHERE ES_FUNCTION_REQ.CREATED_USER = EMPLOYEES.EMPLOYEE_NO AND DEPARTMENTS.DEP_NO = ES_FUNCTION_REQ.DEPT AND ES_FUNCTION_REQ.STATUS = '4'", connectionString);

                dataset = new DataSet();
                odbcdadapter.Fill(dataset);
                GridView2.DataSource = dataset.Tables[0];
                GridView2.DataBind();

                RadioButtonList2.Items.Clear();
                RadioButtonList2.Items.Add(new ListItem("Approve", "6"));
                RadioButtonList2.Items.Add(new ListItem("Reject", "7"));
            }
            else
            { 
                //Label_Message.Text = "There are no Requests..."; 
            }
    }
    private void getMenu()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString2"].ConnectionString.ToString();

        con = new SqlConnection(connection);
        con.ConnectionString = connection;
        con.Open();

        DataTable table = new DataTable();


        string sql = "Select * from tbl_WebMenu INNER JOIN User_Check ON (tbl_WebMenu.MenuID = User_Check.MenuID)" +
            //"AND (User_Check.MenuID = tbl_WebMenu.ParentID)" +
                      "AND (User_Check.EmpNumber = '" + EMPLOYEE_NO + "' ) AND (User_Check.STATUS = '" + 1 + "')";

        SqlDataAdapter da = new SqlDataAdapter(sql, con);

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
        con.Close();
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

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridViewBind();
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
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
            HeaderCell.Text = "Admin Area  (Manager): Function Rquests List";
            HeaderCell.ColumnSpan = 8;
            HeaderGridRow.Cells.Add(HeaderCell);
            GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }
    protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new
            GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Admin Area (General Manager): Function Rquests List";
            HeaderCell.ColumnSpan = 8;
            HeaderGridRow.Cells.Add(HeaderCell);
            GridView2.Controls[0].Controls.AddAt(0, HeaderGridRow);

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
                FORM_NO = GridView1.Rows[i].Cells[0].Text;
                TextBox1.Text = FORM_NO.ToString();
                TextBox2.Text = GridView1.Rows[i].Cells[1].Text;//ES_FUNCTION_REQ.CREATED_USER 
                FunctionRequestDetails();
                //RadioButtonList1.Visible = true;
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
        }
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label_Message.Text = "";
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            if (GridView2.SelectedIndex == i)
            {
                FORM_NO = GridView2.Rows[i].Cells[0].Text;
                TextBox3.Text = FORM_NO.ToString();
                TextBox2.Text = GridView2.Rows[i].Cells[1].Text;

                FunctionRequestDetails2();
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
        }
    }
    public void FunctionRequestDetails()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string sql = "SELECT ES_FUNCTION_REQ.REQUEST_NO, ES_FUNCTION_REQ.RQUESTDATE, ES_FUNCTION_REQ.FUNSTARTDTAE, ES_FUNCTION_REQ.FUNCENDDATE, "+
            "DEPARTMENTS.DEP_NAME, EMPLOYEES.EMPLOYEE_NAME, ES_FUNCTION_REQ.TIMEFROM, ES_FUNCTION_REQ.TIMETO, ES_FUNCTION_REQ.LOCATION, ES_FUNCTION_REQ.PURPOSE, ES_FUNCTION_REQ.ARRANGMENTS, " +
            "ES_FUNCTION_REQ.SEND_DATE, ES_FUNCTION_REQ.CREATED_DATE FROM ES_FUNCTION_REQ, DEPARTMENTS, EMPLOYEES " +
            "WHERE DEPARTMENTS.DEP_NO = ES_FUNCTION_REQ.DEPT AND ES_FUNCTION_REQ.CREATED_USER = EMPLOYEES.EMPLOYEE_NO AND ES_FUNCTION_REQ.REQUEST_NO = '" + TextBox1.Text + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_ReqNum.Text        = read["REQUEST_NO"].ToString();
            Text_ReqDate.Text       = read["RQUESTDATE"].ToString();
            Text_startDate.Text     = read["FUNSTARTDTAE"].ToString();
            Text_EndDate.Text       = read["FUNCENDDATE"].ToString();
            Text_Department.Text    = read["DEP_NAME"].ToString();
            Text_Emp_Name.Text      = read["EMPLOYEE_NAME"].ToString();
            Text_From.Text          = read["TIMEFROM"].ToString();
            Text_To.Text            = read["TIMETO"].ToString();
            Text_Location.Text      = read["LOCATION"].ToString();
            Text_PURPOSE.Text       = read["PURPOSE"].ToString();
            Text_ARRANGMENTS.Text   = read["ARRANGMENTS"].ToString();
            Text_SendDate.Text      = read["SEND_DATE"].ToString();
            Text_Created_Date.Text  = read["CREATED_DATE"].ToString();

        }
        cmd.Connection.Close();
    }
    public void FunctionRequestDetails2()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string sql = "SELECT ES_FUNCTION_REQ.REQUEST_NO, ES_FUNCTION_REQ.RQUESTDATE, ES_FUNCTION_REQ.FUNSTARTDTAE, ES_FUNCTION_REQ.FUNCENDDATE, " +
            "DEPARTMENTS.DEP_NAME, EMPLOYEES.EMPLOYEE_NAME, ES_FUNCTION_REQ.TIMEFROM, ES_FUNCTION_REQ.TIMETO, ES_FUNCTION_REQ.LOCATION, ES_FUNCTION_REQ.PURPOSE, ES_FUNCTION_REQ.ARRANGMENTS, " +
            "ES_FUNCTION_REQ.SEND_DATE, ES_FUNCTION_REQ.CREATED_DATE FROM ES_FUNCTION_REQ, DEPARTMENTS, EMPLOYEES " +
            "WHERE DEPARTMENTS.DEP_NO = ES_FUNCTION_REQ.DEPT AND ES_FUNCTION_REQ.CREATED_USER = EMPLOYEES.EMPLOYEE_NO AND ES_FUNCTION_REQ.REQUEST_NO = '" + TextBox3.Text + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_ReqNum0.Text = read["REQUEST_NO"].ToString();
            Text_ReqDate0.Text = read["RQUESTDATE"].ToString();
            Text_startDate0.Text = read["FUNSTARTDTAE"].ToString();
            Text_EndDate0.Text = read["FUNCENDDATE"].ToString();
            Text_Department0.Text = read["DEP_NAME"].ToString();
            Text_Emp_Name0.Text = read["EMPLOYEE_NAME"].ToString();
            Text_From0.Text = read["TIMEFROM"].ToString();
            Text_To0.Text = read["TIMETO"].ToString();
            Text_Location0.Text = read["LOCATION"].ToString();
            Text_PURPOSE0.Text = read["PURPOSE"].ToString();
            Text_ARRANGMENTS0.Text = read["ARRANGMENTS"].ToString();
            Text_SendDate0.Text = read["SEND_DATE"].ToString();
            Text_Created_Date0.Text = read["CREATED_DATE"].ToString();

        }
        cmd.Connection.Close();
    }
    protected void  RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
            //Label_Message0.Text = RadioButtonList1.SelectedValue.ToString();
        Status = RadioButtonList1.SelectedItem.ToString();
        //Text_Comments.Text = Status;
    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Label_Message0.Text = RadioButtonList1.SelectedValue.ToString();
        Status = RadioButtonList2.SelectedItem.ToString();
        //Text_Comments.Text = Status;
    }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        UpdateFormStatus();
        //Status = RadioButtonList1.SelectedItem.Text.ToString();
        SendEMail(Status);
        Panel1.Visible = false;
        Reset();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
        //GridViewBind();
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset();
        Panel1.Visible = false;
        Panel2.Visible = false;
        GridViewBind();
    }
    private void UpdateFormStatus()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql, date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];


        if (TextBox1.Text != "" || TextBox3.Text != "")
        {
            if (MANAGER == EMPLOYEE_NO)
            {
                if (TextBox1.Text != "" && FORM_NO == TextBox1.Text)
                {
                    sql = "UPDATE ES_FUNCTION_REQ SET STATUS = '" + RadioButtonList1.SelectedValue + "' " +
                        ", MNGR_ID = '" + EMPLOYEE_NO + "', MNGR_DATE = '" + date + "' , MNGR_TXT ='" + Text_Comments.Text + "' " +
                        " WHERE REQUEST_NO = '" + TextBox1.Text + "'";
                    odbccon = new OdbcConnection(connection);
                    odbccon.ConnectionString = connection;
                    odbccon.Open();

                    odbccomm = new OdbcCommand(sql, odbccon);
                    odbccomm.ExecuteNonQuery();
                    odbccon.Close();
                    //Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    //Reset();
                    Label_Message.Text = "Successfully...";
                    Status = RadioButtonList1.SelectedItem.Text.ToString();
                }
            }
            else
            {
                //Reset();
                Panel1.Visible = false;
            }
              if (GMANAGER == EMPLOYEE_NO)
              {
                  if (TextBox3.Text != "" && FORM_NO == TextBox3.Text)
                  {
                      sql = "UPDATE ES_FUNCTION_REQ SET STATUS = '" + RadioButtonList2.SelectedValue + "' " +
                      ", GM_ID = '" + EMPLOYEE_NO + "', GM_DATE = '" + date + "' , GM_TXT ='" + Text_Comments0.Text + "' " +
                      " WHERE REQUEST_NO = '" + TextBox3.Text + "'";
                      odbccon = new OdbcConnection(connection);
                      odbccon.ConnectionString = connection;
                      odbccon.Open();

                      odbccomm = new OdbcCommand(sql, odbccon);
                      odbccomm.ExecuteNonQuery();
                      odbccon.Close();
                      //Page.Response.Redirect(Page.Request.Url.ToString(), true);
                      //Reset();
                      Label_Message.Text = "Successfully...";
                      Status = RadioButtonList2.SelectedItem.Text.ToString();
                  }
              }
              else
              {
                  //Reset();
                  Panel2.Visible = false;
              }
        }
        else
        {
            Reset();
            Panel1.Visible = false;
            Panel2.Visible = false;
        }
    }
    private void Reset()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        RadioButtonList1.Items.Clear();
        RadioButtonList2.Items.Clear();
    }
    public void SendEMail(string Status)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO   = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        HRMANAGER = Request.QueryString["HRMNG"];
        GMANAGER  = Request.QueryString["GM"];

        string date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        //REQUESTER 
        string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO = '" + TextBox2.Text + "'";
       
        // SUPERVISOR OR MANAGER
        string sql2 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO = '" + EMPLOYEE_NO + "'"; //DEP_NO
      
        //G MANAGER
        string sql3 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO = '" + GMANAGER + "'";
       
        //HR MANAGER
        string sql4 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO = '" + HRMANAGER + "'";
         
        
        OdbcConnection conn = new OdbcConnection(connectionString);

        OdbcCommand cmd  = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);
        OdbcCommand cmd4 = new OdbcCommand(sql4, conn);

        cmd.Connection.Open();

        OdbcDataReader read  = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        OdbcDataReader read3 = cmd3.ExecuteReader();
        OdbcDataReader read4 = cmd4.ExecuteReader();

        read.Read();
        read2.Read();
        read3.Read();
        read4.Read();
        
        if (read.HasRows)
        {
            EmpName  = read["FULL_USER_NAME"].ToString();
            EmpEmail = read["EMAIL"].ToString();
            Depart   = read["DEP_NAME"].ToString();
        }
        if (read2.HasRows)
        {
            EmpName2 = read2["FULL_USER_NAME"].ToString();
            EmpEmail2 = read2["EMAIL"].ToString();
            AUTHORNAME = read2["FULL_USER_NAME"].ToString();
        }
        if (read3.HasRows)
        {
            EmpName3  = read3["FULL_USER_NAME"].ToString();
            EmpEmail3 = read3["EMAIL"].ToString();
            Depart3   = read3["DEP_NAME"].ToString();
        }
        if (read4.HasRows)
        {
            EmpName4  = read4["FULL_USER_NAME"].ToString();
            EmpEmail4 = read4["EMAIL"].ToString();
            Depart4   = read4["DEP_NAME"].ToString();
        }
    
        if (MANAGER == EMPLOYEE_NO)
        {
            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "&AUTHORNAME=" + EmpName2 + "" +
               "&ApprovalName=" + EmpName3 + "&ApprovalEmail=" + EmpEmail3 + "&REQNAME=Function Request");
        }
        else
            if (GMANAGER == EMPLOYEE_NO)
        {
            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "&AUTHORNAME=" + EmpName3 + "" +
                          "&ApprovalName=" + EmpName4 + "&ApprovalEmail=" + EmpEmail4 + "&REQNAME=Function Request");
        }
        cmd.Connection.Close();
        cmd2.Connection.Close();
     }
    /*  public void SendEMail(string Status)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO   = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        GMANAGER = Request.QueryString["GM"];

        string date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        //REQUESTER 
        string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO = '" + TextBox2.Text + "'";

        //G MANAGER
        string sql3 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO = '" + GMANAGER + "'";
       
        //HR MANAGER
        string sql4 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO = '" + HRMANAGER + "'";


        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd  = new OdbcCommand(sql, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);
        OdbcCommand cmd4 = new OdbcCommand(sql4, conn);

        cmd.Connection.Open();
        OdbcDataReader read  = cmd.ExecuteReader();
        OdbcDataReader read3 = cmd3.ExecuteReader();
        OdbcDataReader read4 = cmd4.ExecuteReader();

        read.Read();
        read3.Read();
        read4.Read();

        if (read.HasRows)
        {
            EmpName  = read["FULL_USER_NAME"].ToString();
            EmpEmail = read["EMAIL"].ToString();
            Depart   = read["DEP_NAME"].ToString();
        }
        if (read3.HasRows)
        {
            EmpName3  = read3["FULL_USER_NAME"].ToString();
            EmpEmail3 = read3["EMAIL"].ToString();
            Depart3   = read3["DEP_NAME"].ToString();
        }
        if (read4.HasRows)
        {
            EmpName4  = read4["FULL_USER_NAME"].ToString();
            EmpEmail4 = read4["EMAIL"].ToString();
            Depart4   = read4["DEP_NAME"].ToString();
        }
         // SUPERVISOR OR MANAGER
        string sql2 = "SELECT FULL_USER_NAME FROM USERS_INFORMATIONS WHERE EMPLOYEE_NO = '" + EMPLOYEE_NO + "'"; //DEP_NO
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        //cmd2.Connection.Open();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        read2.Read();
        if (read2.HasRows)
        {
            AUTHORNAME = read2["FULL_USER_NAME"].ToString();
        }
        //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=portal@petroneed.com.sd&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "&AUTHORNAME=" + AUTHORNAME + "");
        Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "&AUTHORNAME=" + AUTHORNAME + ""+
            "&EmpName3=" + EmpName3 + "&EmpEmail3=" + EmpEmail3 + "&EmpName4=" + EmpName4 + "&EmpEmail4=" + EmpEmail4 + "&REQNAME=Function Request");
        
        cmd.Connection.Close();
        cmd2.Connection.Close();
     }*/
}
