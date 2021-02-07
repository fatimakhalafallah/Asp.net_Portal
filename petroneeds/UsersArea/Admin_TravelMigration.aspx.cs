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

public partial class UsersArea_Admin_TravelMigration : System.Web.UI.Page
{
    public OdbcCommand comm = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter dadapter;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;

    public static string EMPLOYEE_NO, DEPARTMENT_NO, MANAGER, SUPERVISOR, HRMANAGER, AUTHORNAME;
    public static string EmpName, EmpEmail, Depart, Status, EmpName2, EmpEmail2, EmpName3, EmpEmail3;

    DataSet dset, dset2;
    string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
    string sql;

    private string sortDirection;
    private int No;

    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO     = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO   = Request.QueryString["DEP_NO"];
        
        MANAGER         = Request.QueryString["MNG"];
        HRMANAGER       = Request.QueryString["EMPLOYEE_NO"];
        //SUPERVISOR = Request.QueryString["SUPER"];

        if (EMPLOYEE_NO == "" || EMPLOYEE_NO == null && DEPARTMENT_NO == "" || DEPARTMENT_NO == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                getMenu();
                GridViewBind();
                Panel1.Visible = false;
            }
        }
    }
    public void GridViewBind()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        MANAGER = Request.QueryString["MNG"];
        HRMANAGER = Request.QueryString["HRMNG"];

        if (MANAGER == EMPLOYEE_NO)
        {
            No = 1;
        }
        else
            if (HRMANAGER == EMPLOYEE_NO)
            {
                No = 2;
            }
        //Response.Write(No);
        switch (No)
        {
                
            case 1:
                //dadapter = new OdbcDataAdapter("SELECT TRAVEL_MSTR.TRF_NO, TRAVEL_MSTR.EMPLOYEE_NO, DEPARTMENTS.DEP_NAME, TRAVEL_MSTR.FORM_DATE FROM" +
                //    " TRAVEL_MSTR, DEPARTMENTS WHERE TRAVEL_MSTR.FORM_STATUS = '3' AND TRAVEL_MSTR.DEP_NO = DEPARTMENTS.DEP_NO AND TRAVEL_MSTR.EMPLOYEE_NO IN " +
                //    " (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG ='" + Convert.ToInt32(MANAGER) + "')", connectionString); //SUPERVISOR 

                //dadapter = new OdbcDataAdapter("SELECT TRAVEL_SERVICES_MST.TS_NO, TRAVEL_SERVICES_MST.TS_DATE, DEPARTMENTS.DEP_NAME, TRAVEL_SERVICES_MST.CREATED_DATE FROM" +
                //    " TRAVEL_SERVICES_MST, DEPARTMENTS WHERE TRAVEL_SERVICES_MST.STATUS = '3' AND TRAVEL_SERVICES_MST.DEP_NO = DEPARTMENTS.DEP_NO AND TRAVEL_SERVICES_MST.CREATED_USER IN " +
                //    " (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG ='" + Convert.ToInt32(MANAGER) + "')", connectionString); //SUPERVISOR 

                dadapter = new OdbcDataAdapter("SELECT TRAVEL_SERVICES_MST.TS_NO, TRAVEL_SERVICES_MST.CREATED_USER, TRAVEL_SERVICES_MST.TS_DATE, "+
                    " DEPARTMENTS.DEP_NAME, TRAVEL_SERVICES_MST.CREATED_DATE, TRAVEL_SERVICES_MST.PASSEN_NAME, TRAVEL_SERVICES_MST.FILE_NAME, EMPLOYEES.EMPLOYEE_NAME FROM" +
                    " TRAVEL_SERVICES_MST, DEPARTMENTS, EMPLOYEES " +
                    " WHERE TRAVEL_SERVICES_MST.CREATED_USER = EMPLOYEES.EMPLOYEE_NO AND TRAVEL_SERVICES_MST.STATUS = '3' AND TRAVEL_SERVICES_MST.DEP_NO = DEPARTMENTS.DEP_NO AND TRAVEL_SERVICES_MST.CREATED_USER IN " +
                    " (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG ='" + Convert.ToInt32(MANAGER) + "')", connectionString); 

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "4"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "5"));
                break;

            case 2:
                dadapter = new OdbcDataAdapter("SELECT DISTINCT TRAVEL_SERVICES_MST.TS_NO, TRAVEL_SERVICES_MST.CREATED_USER, TRAVEL_SERVICES_MST.TS_DATE, " +
                    " DEPARTMENTS.DEP_NAME, TRAVEL_SERVICES_MST.CREATED_DATE, TRAVEL_SERVICES_MST.PASSEN_NAME, TRAVEL_SERVICES_MST.FILE_NAME, EMPLOYEES.EMPLOYEE_NAME FROM" +
                    " TRAVEL_SERVICES_MST, DEPARTMENTS, EMPLOYEES, REQUEST_ACTORS " +
                    " WHERE TRAVEL_SERVICES_MST.CREATED_USER = EMPLOYEES.EMPLOYEE_NO AND TRAVEL_SERVICES_MST.STATUS = '4' "+
                    " AND TRAVEL_SERVICES_MST.DEP_NO = DEPARTMENTS.DEP_NO AND REQUEST_ACTORS.EMPLOYEE_NO = '" + HRMANAGER + "'", connectionString);
                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "6"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "7"));
                break;

            default:
                Label_Message.Text = "There are no Requests...";
                //Label_Message.Text = "You aren't Authorized to see this page ...";
                break;
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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
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
            HeaderCell.Text = "Admin Area: Travel Migrations List";
            HeaderCell.ColumnSpan = 8;
            HeaderGridRow.Cells.Add(HeaderCell);
            GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);

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
                //string EMP_NO = GridView1.Rows[i].Cells[1].Text;
                TextBox1.Text = FORM_NO.ToString();
                TextBox2.Text = GridView1.Rows[i].Cells[1].Text;
                UserDetails();
                Panel1.Visible = true;
            }
        }
    }
    void UserDetails()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        //dadapter = new OdbcDataAdapter("SELECT SERIAL_NO, TRANS_DATE, CITY_FROM, FROM_DATE, CITY_TO, TO_DATE FROM TRAVEL_DTL WHERE TRF_NO ='" + TextBox1.Text + "'", connectionString);
        dadapter = new OdbcDataAdapter("SELECT TRAVEL_SERVICES_DTL.TS_NO, TRAVEL_SERVICES_TYPE.SER_NAME FROM" +
                    " TRAVEL_SERVICES_DTL, TRAVEL_SERVICES_TYPE WHERE TRAVEL_SERVICES_TYPE.SER_NO = TRAVEL_SERVICES_DTL.SER_NO" +
                    " AND TRAVEL_SERVICES_DTL.TS_NO = '" + TextBox1.Text + "'", connectionString);
        dset2 = new DataSet();
        dadapter.Fill(dset2);
        DetailsView1.DataSource = dset2.Tables[0];
        DetailsView1.DataBind();
    }
    public virtual bool AllowPaging { get; set; }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        UpdateFormStatus();
        Status = RadioButtonList1.SelectedItem.Text.ToString();
        SendEMail(Status);
        Panel1.Visible = false;
        Reset();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
    private void UpdateFormStatus()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql, date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        if (TextBox1.Text != "")
        {
            sql = "UPDATE TRAVEL_SERVICES_MST SET STATUS = '" + RadioButtonList1.SelectedValue + "', MNGR_TXT = '" + Text_Comments.Text + "' " +
                ", MNGR_ID = '" + EMPLOYEE_NO + "', MNGR_DATE = '" + date + "'WHERE TS_NO = '" + TextBox1.Text + "'";
            con = new OdbcConnection(connection);
            con.ConnectionString = connection;
            con.Open();

            comm = new OdbcCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
            //Page.Response.Redirect(Page.Request.Url.ToString(), true);
            //Reset();
            Label_Message.Text = "Successfully...";
        }
        else
        {
            Reset();
            Panel1.Visible = false;
        }
    }
    private void Reset()
    {
        //Text_Num.Text = "";
        //Text_Request.Text = "";
        //Text_StDate.Text = "";
        //Text_EnDate.Text = "";
        //Text_NumOfDays.Text = "";
        //Text_Leave_Name.Text = "";
        //Text_Comments.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset();
        Panel1.Visible = false;
    }
    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {
        //DetailsView1.PagerSettings.Mode = PagerButtons.NextPreviousFirstLast;
        DetailsView1.PageIndex = e.NewPageIndex;
        UserDetails();
    }
    public void SendEMail(string Status)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        // Requester
        string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO = '" + TextBox2.Text + "'"; //DEP_NO

        //Approval (MNG)
        string sql2 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME "+
            " FROM USERS_INFORMATIONS, DEPARTMENTS WHERE USERS_INFORMATIONS.EMPLOYEE_NO = '" + MANAGER + "'"; //DEP_NO

        //Approval (HRMNG)
        string sql3 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            " FROM USERS_INFORMATIONS, DEPARTMENTS WHERE USERS_INFORMATIONS.EMPLOYEE_NO = '" + HRMANAGER + "'"; //DEP_NO

        OdbcConnection conn = new OdbcConnection(connectionString);

        OdbcCommand cmd  = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);

        cmd.Connection.Open();
        OdbcDataReader read  = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        OdbcDataReader read3 = cmd3.ExecuteReader();

        read.Read();
        read2.Read();
        read3.Read();

        if (read.HasRows)
        {
            EmpName  = read["FULL_USER_NAME"].ToString();
            EmpEmail = read["EMAIL"].ToString();
            Depart   = read["DEP_NAME"].ToString();
        }
        if (read2.HasRows)
        {
            EmpName2   = read2["FULL_USER_NAME"].ToString();
            EmpEmail2  = read2["EMAIL"].ToString();
            AUTHORNAME = read2["FULL_USER_NAME"].ToString();
        }
        if (read3.HasRows)
        {
            EmpName3   = read3["FULL_USER_NAME"].ToString();
            EmpEmail3  = read3["EMAIL"].ToString();
        }
        if (MANAGER == EMPLOYEE_NO)
        {
            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + ""+
                "&ApprovalName=" + EmpName3 + "&ApprovalEmail=" + EmpEmail3 + "&REQNAME=Travel Migration&AUTHORNAME=" + EmpName2 + "");
        }
        else
         if (HRMANAGER == EMPLOYEE_NO)
         {
             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
               "&ApprovalName=&ApprovalEmail=&REQNAME=Travel Migration&AUTHORNAME=" + EmpName3 + "");
         }

         cmd.Connection.Close();
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Status = RadioButtonList1.SelectedItem.ToString();
    }
}