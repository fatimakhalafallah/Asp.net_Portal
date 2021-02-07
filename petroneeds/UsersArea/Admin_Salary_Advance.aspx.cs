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

public partial class UsersArea_Admin_Salary_Advance : System.Web.UI.Page
{
    public OdbcCommand comm = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter dadapter;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;

    public static string EMPLOYEE_NO, DEPARTMENT_NO, HRMANAGER, SUPERVISOR;
    public static string EmpName, EmpEmail, Depart, Status, AUTHORNAME;

    DataSet dset;
    string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
    string sql;

    private string sortDirection;
    private int No;

    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        HRMANAGER = Request.QueryString["MNG"];
        //SUPERVISOR = Request.QueryString["SUPER"];

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
                HRMANAGER = Request.QueryString["MNG"];
                //SUPERVISOR = Request.QueryString["SUPER"];

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
        HRMANAGER = Request.QueryString["MNG"];
        //SUPERVISOR = Request.QueryString["SUPER"];

        if (HRMANAGER == EMPLOYEE_NO)
        {
            No = 2;
        }
        //else
        ////{
        ////    Label_Message.Text = "You haven't Authority to see this page...";
        ////}
        ////if (MANAGER == SUPERVISOR && MANAGER == EMPLOYEE_NO)
        ////{
        ////    No = 3;
        ////}
       switch (No)
        {
            case 2:
                //dadapter = new OdbcDataAdapter("SELECT ADV_NO, EMPLOYEE_NO, SAL_DATE FROM" +
                //    " ADVANCE_SAL_FORM WHERE FORM_STATUS = '1' AND EMPLOYEE_NO IN " +
                //    " (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE SUPER ='" + SUPERVISOR + "')", connectionString); 

                dadapter = new OdbcDataAdapter("SELECT ADV_NO, EMPLOYEE_NO, SAL_DATE FROM ADVANCE_SAL_FORM WHERE FORM_STATUS = '1'", connectionString); 

                    dset = new DataSet();
                    dadapter.Fill(dset);
                    GridView1.DataSource = dset.Tables[0];
                    GridView1.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "2"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "3"));
                break;

            //case 3:
            //    dadapter = new OdbcDataAdapter("SELECT ADV_NO, EMPLOYEE_NO, SAL_DATE FROM" +
            //        " ADVANCE_SAL_FORM WHERE FORM_STATUS = '1' AND EMPLOYEE_NO IN " +
            //        " (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE SUPER = MNG AND MNG ='" + MANAGER + "')", connectionString); //6199
            //    dset = new DataSet();
            //    dadapter.Fill(dset);
            //    GridView1.DataSource = dset.Tables[0];
            //    GridView1.DataBind();

            //    RadioButtonList1.Items.Add(new ListItem("Approve", "2"));
            //    RadioButtonList1.Items.Add(new ListItem("Reject", "3"));
            //    break;

            default:
                Label_Message.Text = "There are no Requests...";
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
            HeaderCell.Text = "Admin Area: Advance Salary List";
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
                string EMP_NO = GridView1.Rows[i].Cells[1].Text;
                TextBox1.Text = FORM_NO.ToString();
                TextBox2.Text = EMP_NO.ToString();
                UserAdvanceDetails();
                //RadioButtonList1.Visible = true;
                Panel1.Visible = true;
            }
        }
    }
    void UserAdvanceDetails()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

       //string sql = "SELECT FORM_LEAVES_APPLICATION.FORM_DATE, FORM_LEAVES_APPLICATION.EMPLOYEE_NO, "+
       //     "FORM_LEAVES_APPLICATION.START_DATE, FORM_LEAVES_APPLICATION.END_DATE, LKP_LEAVE_TYPES.LEAVE_TYPE_NAME, USERS_INFORMATIONS.FULL_USER_NAME, FORM_LEAVES_APPLICATION.NUMBER_OF_DAYS " +
       //   " FROM FORM_LEAVES_APPLICATION, LKP_LEAVE_TYPES, USERS_INFORMATIONS WHERE FORM_LEAVES_APPLICATION.LEAVE_FORM__NO = '" + TextBox1.Text + "' AND" +
       //   " LKP_LEAVE_TYPES.LEAVE_TYPE_NO = FORM_LEAVES_APPLICATION.LS_LEAVE_TYPE AND USERS_INFORMATIONS.EMPLOYEE_NO = '" + EMPLOYEE_NO + "'";

        string sql = "SELECT ADVANCE_SAL_FORM.ADV_NO, ADVANCE_SAL_FORM.EMPLOYEE_NO, ADVANCE_SAL_FORM.SAL_DATE, ADVANCE_SAL_FORM.REMARK, "+
            " ADVANCE_SAL_FORM.AMT, USERS_INFORMATIONS.FULL_USER_NAME, ADVANCE_SAL_FORM.CREATED_DATE FROM USERS_INFORMATIONS, ADVANCE_SAL_FORM WHERE " +
            " ADVANCE_SAL_FORM.ADV_NO = '" + TextBox1.Text + "' AND USERS_INFORMATIONS.EMPLOYEE_NO = '"+ TextBox2.Text +"'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_ReqNum.Text       = read["ADV_NO"].ToString();
            Text_Num.Text          = read["EMPLOYEE_NO"].ToString();
            Text_Request.Text      = read["CREATED_DATE"].ToString();
            Text_Request_Date.Text = read["SAL_DATE"].ToString();
            Text_Remarks.Text      = read["REMARK"].ToString();
            Text_AMT.Text          = read["AMT"].ToString();
            Text_Name.Text         = read["FULL_USER_NAME"].ToString();
        }
        //else
        //{
        //    Response.Redirect("~/Login.aspx");
        //}
        cmd.Connection.Close();
    }
    protected void  RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Status = RadioButtonList1.SelectedItem.ToString();
        //Label_Message0.Text = RadioButtonList1.SelectedValue.ToString();
    }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        UpdateFormStatus();
        Status = RadioButtonList1.SelectedItem.Text.ToString();
        SendEMail(Status);
        Reset();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
        Panel1.Visible = false;
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset();
        Panel1.Visible = false;
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
            sql = "UPDATE ADVANCE_SAL_FORM SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "', HR_COMMENT = '" + Text_Comments.Text + "' " +
                ", HR_ID = '" + EMPLOYEE_NO + "', HR_DATE = '" + date + "'WHERE ADV_NO = '" + TextBox1.Text + "' AND EMPLOYEE_NO = '"+ TextBox2.Text +"'";
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
        Text_Num.Text = "";
        Text_Request.Text = "";
        Text_Comments.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";

        Text_ReqNum.Text = "";
        Text_Remarks.Text = "";
        Text_AMT.Text = "";
        Text_Name.Text = "";
    }
    public void SendEMail(string Status)
    //public void SendEMail()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND "+
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + TextBox2.Text + "'"; //DEP_NO

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);
        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            EmpName = read["FULL_USER_NAME"].ToString();
            EmpEmail = read["EMAIL"].ToString();
            Depart = read["DEP_NAME"].ToString();
        }
        string sql2 = "SELECT FULL_USER_NAME FROM USERS_INFORMATIONS WHERE EMPLOYEE_NO = '" + EMPLOYEE_NO + "'"; //DEP_NO
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
      
        OdbcDataReader read2 = cmd2.ExecuteReader();
        read2.Read();
        if (read2.HasRows)
        {
            AUTHORNAME = read2["FULL_USER_NAME"].ToString();
        }
        Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + ""+
            "&ApprovalName=&ApprovalEmail=&REQNAME=Salary Advance&AUTHORNAME=" + AUTHORNAME + "");
        cmd.Connection.Close(); 
        cmd2.Connection.Close();
    }
}
