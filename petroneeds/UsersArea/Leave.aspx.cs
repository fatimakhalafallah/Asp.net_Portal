using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing.Design;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data;


public partial class Leave : System.Web.UI.Page
{
    public OdbcCommand comm = null;
    public OdbcConnection con = null;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;

    public string EMPLOYEE_NO, DEPARTMENT_NO;
    public static string EmpName, EmpEmail, Depart, Status="Send";
    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        if (EMPLOYEE_NO == "" || EMPLOYEE_NO == null && DEPARTMENT_NO == "" || DEPARTMENT_NO == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                Reset();
                Text_Date.Text = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
                getMenu();
                CheckAccount();
                UserData();
                /////////////////////////////////////////////////////////////////////
                ///////////////////////////////////
                Text_Year.Text = DateTime.Now.Date.Year.ToString();
                Annual_Leave();

            }
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            RadioButtonList1.Enabled = false;
            Panel1.Visible = true;
        }
        else
            if (CheckBox1.Checked == false)
            {
                Panel1.Visible = false;
                RadioButtonList1.Enabled = true;
            }

    } 

    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        Insert();
        SendEMail(Status);
        Response.Redirect("~/UsersArea/servicesSendRequest.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + "");
        Reset();
        CheckAccount();
    }

    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset();
        CheckAccount();
    }
    private void Reset()
    {
        Text_Num.Text = "";

        //Text_Id.Text = "";
        //Text_Name.Text = "";
        //Text_Position.Text = "";
        //Text_report.Text = "";
        CheckBox1.Checked = false;
        Text_Specify.Text = "";
        Text_To.Text = "";
        Text_from.Text = "";
        Text_Reasons.Text = "";
        Text_NoofDay.Text = "0";

        Text_Reasons.Text = "";
        Text_ContactLeave.Text = "";
        Label_Messages.Text = "";
        Label_Error.Visible = false;
    }
    private void Insert()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql;

        CheckAccount();

        if (Text_ContactLeave.Text.Length < 100)
        {
            sql = "INSERT INTO FORM_LEAVES_APPLICATION " +
           "(LEAVE_FORM__NO, FORM_DATE, EMPLOYEE_NO, GRADE_NO, LS_LEAVE_TYPE, LEAVE_YEAR, NUMBER_OF_DAYS, START_DATE, END_DATE, LT_COMMENT," +
           "LS_SETTING_NO, CONTACT_WHILE_ON_LEAVE, FORM_STATUS, FORM_STATUS_REASON, STATUS_DATE, LEAVE_ALLOWANCE, ALLOWANCE_AMOUNT, HR_ENDORSE, DOCTOR_APPROVAL, APPROVED_BY," +
           "APPROVED_BY_CAT, SENDTOHR, ACTINING_MNGR_ID, ENDORSE_FLAG, ENDORSE_BY, HR_ENDORSE_DATE, ENDORSE_DATE, APPROVE_DATE, ALERT_DATE)  VALUES" +


            "('" + Text_Num.Text + "', '" + Text_Date.Text + "' , '" + Text_Id.Text + "', '', '" + RadioButtonList1.SelectedValue + "', '', '" + Text_NoofDay.Text + "', '" + Text_from.Text + "' ,'" + Text_To.Text + "', '" + Text_Specify.Text + "', " +
            "'', '" + Text_ContactLeave.Text + "', '0', '"+ Text_Reasons.Text +"', '', '', '', '', '0', '', " +
            "'', '0', '', '0', '', '', '', '', '')";
            con = new OdbcConnection(connection);
            con.ConnectionString = connection;
            con.Open();

            comm = new OdbcCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
            //Reset();
            Label_Messages.Text = "Thank You Mr,MS " + Text_Name.Text + " Your Record Saved";
            //CheckAccount();
        }
        else
        {
            Label_Error.Visible = true;
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
    public void CheckAccount()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        string sql = "SELECT NVL(MAX(LEAVE_FORM__NO),0)+1 FROM FORM_LEAVES_APPLICATION";
        //string sql = "SELECT MAX(LEAVE_FORM__NO)+1 FROM FORM_LEAVES_APPLICATION";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_Num.Text = read[0].ToString();
        }
        cmd.Connection.Close();
    }
    public void UserData()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        //Text_ID.Text = EMPLOYEE_NO;

        //string sql = "SELECT USERS_INFORMATIONS.FULL_USER_NAME, USERS_INFORMATIONS.EMAIL, DEPARTMENTS.DEP_NAME FROM USERS_INFORMATIONS"+
        //    "INNER JOIN DEPARTMENTS ON (USERS_INFORMATIONS.DEP_NO = DEPARTMENTS.DEP_NO) AND USERS_INFORMATIONS.DEP_NO = '" + int.Parse(DEPARTMENT_NO) + "'"+
        //    "WHERE USERS_INFORMATIONS.EMPLOYEE_NO = '" + Int32.Parse(EMPLOYEE_NO) + "'";
        string sql = "SELECT EMPLOYEES.EMPLOYEE_NAME, DEPARTMENTS.DEP_NAME,"+
                       "LKP_JOBS.JOB_NAME FROM EMPLOYEES "+
                       "INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO)"+
                       "INNER JOIN LKP_JOBS ON    (LKP_JOBS.JOB_NO = EMPLOYEES.JOB_NO)"+
                       "WHERE EMPLOYEES.EMPLOYEE_STATUS = '1' AND EMPLOYEES.EMPLOYEE_NO = '" + Int32.Parse(EMPLOYEE_NO) + "' ";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
                //Text_Name.Text = read["FULL_USER_NAME"].ToString();
                //Text_Department.Text = read["DEP_NAME"].ToString();
            Text_Name.Text = read["EMPLOYEE_NAME"].ToString();
            Text_Department.Text = read["DEP_NAME"].ToString();
            Text_Position.Text = read["JOB_NAME"].ToString();
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
        Text_Id.Text = EMPLOYEE_NO.ToString();
        cmd.Connection.Close();
    }
    protected void Text_To_TextChanged(object sender, EventArgs e)
    {
        if (Text_from.Text != null && Text_To.Text != null && Text_from.Text != "" && Text_To.Text != "")
        {
            Calculation();
        }
    }
    protected void Text_from_TextChanged(object sender, EventArgs e)
    {
        if (Text_from.Text != null && Text_To.Text != null && Text_from.Text != "" && Text_To.Text != "")
        {
            Calculation();
        }
    }
    private void Calculation()
    {
        DateTime from = new DateTime();
        DateTime to = new DateTime();
        int No = 1;

        from = Convert.ToDateTime(Text_from.Text).Date;
        to = Convert.ToDateTime(Text_To.Text).Date;
        TimeSpan sumDate = (to) - (from) ;
        Text_NoofDay.Text = (No + (sumDate.Days)).ToString();

        int all     = Convert.ToInt32(Text_Days.Text);
        int prv     = Convert.ToInt32(Text_Previous.Text);
        int taken   = Convert.ToInt32(Text_Taken.Text);
        int Deserve = (all + prv) - taken;

        //if (Convert.ToInt32(Text_NoofDay.Text) > Convert.ToInt32(Text_Days.Text))
        if (Convert.ToInt32(Text_NoofDay.Text) > Deserve)
        {
            Label_Messages.Text = "You aren't Deserve this Vacation ... <br>"+
                " please Check Leftover Days...";
            Butt_Submit.Enabled = false;
        }
        else
        {
            Label_Messages.Text = "";
            Butt_Submit.Enabled = true;
        }
    }
    private void Annual_Leave()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO   = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string sql  = "SELECT NVL(ANNUAL_COUNT ('" + EMPLOYEE_NO + "','1','C'),0) FROM SYS.DUAL";
        string sql2 = "SELECT NVL(ANNUAL_COUNT ('" + EMPLOYEE_NO + "','1','T'),0) FROM SYS.DUAL";
        string sql3 = "SELECT NVL(ANNUAL_COUNT ('" + EMPLOYEE_NO + "','1','P'),0) FROM SYS.DUAL";
       
        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd  = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);

        cmd.Connection.Open();

        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_Days.Text = read[0].ToString();
        }
        read.Close();
        cmd.Connection.Close();

        cmd2.Connection.Open();
        read = cmd2.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_Taken.Text = read[0].ToString();
        }
        read.Close();
        cmd2.Connection.Close();

        cmd3.Connection.Open();
        read = cmd3.ExecuteReader();
        read.Read();

        if (read.HasRows != null)
        {
            Text_Previous.Text = read[0].ToString();
        }
        read.Close();
        cmd3.Connection.Close();

        // CHEACK BALANC

        int all = Convert.ToInt32(Text_Days.Text);
        int prv = Convert.ToInt32(Text_Previous.Text);
        int taken = Convert.ToInt32(Text_Taken.Text);
        int Deserve = (all + prv) - taken;

        Text_Balance.Text = Deserve.ToString();
    }
    public void SendEMail(string Status)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        //string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " + 
        //    "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO IN "+
        //    "(SELECT SUPER FROM EMP_MNG WHERE EMPLOYEE_NO = '"+ Text_Num.Text +"')"; 
        //string sql = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = 11";

        string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO IN " +
            "(SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = 11)"; 

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
        Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Leave Request Information&USERNAMESREQ=" + Text_Name.Text + "");
        //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=portal@petroneed.com.sd&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Leave Request Information&USERNAMESREQ=" + Text_Name.Text + "");

        //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&DATE=" + date + "");
        //Response.Redirect("~/UsersArea/E-mail.aspx?FULL_USER_NAME=" + EmpName + "&EMAIL=portal@petroneed.com.sd&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Leave Request Information&USERNAMESREQ = " + Text_Name.Text + "");
        cmd.Connection.Close();
    }
    protected void leaveHistory_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/UsersArea/leaveHistory.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + "");
    }
}