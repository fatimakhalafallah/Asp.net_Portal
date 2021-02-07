using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data;

public partial class UsersArea_Default : System.Web.UI.Page
{
    public OdbcConnection conn = null;
    public OdbcCommand cmd = null;
    public OdbcDataReader read = null;

    public SqlCommand comm = null;
    public SqlConnection con = null;


    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;
    public string EMPLOYEE_NO, DEPARTMENT_NO ;
    string CommentDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        CommentDate = DateTime.Now.Date.ToString();
        Text_Date.Text = DateTime.Now.Date.ToString();

     if (EMPLOYEE_NO == "" || EMPLOYEE_NO == null && DEPARTMENT_NO == "" || DEPARTMENT_NO == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                Panel1.Visible = false;
                UserLogin();
                UserPassword();
                getMenu();
            }
        }
    }
    public void UserLogin()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        Text_ID.Text = "Your ID Number is " + EMPLOYEE_NO;

        string sql = "SELECT USERS_INFORMATIONS.FULL_USER_NAME, USERS_INFORMATIONS.EMAIL, "+
                    "DEPARTMENTS.DEP_NAME FROM USERS_INFORMATIONS INNER JOIN DEPARTMENTS ON (USERS_INFORMATIONS.DEP_NO = DEPARTMENTS.DEP_NO) "+
                    "AND USERS_INFORMATIONS.DEP_NO = '" + int.Parse(DEPARTMENT_NO) + "' WHERE USERS_INFORMATIONS.EMPLOYEE_NO = '" + Int32.Parse(EMPLOYEE_NO) + "'"; 
        
        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_Name.Text      = "Welcome Mr/Mrs. "+ read["FULL_USER_NAME"].ToString();
            Text_E_Mail.Text    = "Your E-mail is "+ read["EMAIL"].ToString();
            Text_Department.Text = "and your department is "+ read["DEP_NAME"].ToString();
        }
        else
        {

        }
        cmd.Connection.Close();
    }
    public void UserPassword()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];


        string sql = "SELECT USERS_PASSWORDS.PASSWORDS, USERS_PASSWORDS.CHANGE_DATE FROM USERS_PASSWORDS, USERS_INFORMATIONS WHERE  " +
                     "USERS_PASSWORDS.UI_USER_NO = USERS_INFORMATIONS.USER_NO AND "+
                     "USERS_INFORMATIONS.EMPLOYEE_NO = '" + EMPLOYEE_NO + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        string Password    = read["PASSWORDS"].ToString();
        string ChangeDate  = read["CHANGE_DATE"].ToString();
        string CurrentDate = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
        int Leftover = 0;
        int no = 90;

        DateTime Change  = new DateTime();
        DateTime Current = new DateTime();

        Change  = Convert.ToDateTime(ChangeDate).Date;
        Current = Convert.ToDateTime(CurrentDate).Date;

        TimeSpan EndDate = (Current) - (Change);
        //Leftover = (EndDate.Days);
        Leftover = (no) - (EndDate.Days);

        //if (Leftover <= no)
        //{ }
        //else
        //{ }

        if (read.HasRows)
        {
            if (string.Equals(Password, "FIRST PASSWORD"))
            {
                Label_Check_Password.Text = "<strong>Warning! please change the system password, you have " + Leftover + " days to change</strong>";
            }
        }
        else
        {

        } 
        cmd.Connection.Close();
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

    /*
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
     *
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

     */







    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Text_Comment.Text = "";
    }
    protected void Butt_send_Click(object sender, EventArgs e)
    {
        if (Text_Comment.Text == "")
        {
            Label_Messages.Text = "Please Add Your Comment";
        }
        else
        {
            Insert_Comment();
        }
        
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Text_Comment.Text = "";
        Label_Messages.Text = "";
    }
    private void Insert_Comment()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString2"].ConnectionString.ToString();
        string sql;

        con = new SqlConnection(connection);
        con.ConnectionString = connection;
        con.Open();

        sql = "INSERT INTO Users_Comments (EmpComment, EmpNumber, CommentDate)  VALUES" +
        "('" + Text_Comment.Text + "', '" + Int32.Parse(EMPLOYEE_NO) + "' , '" + Text_Date.Text + "')";

      
        con = new SqlConnection(connection);
        con.ConnectionString = connection;
        con.Open();

        comm = new SqlCommand(sql, con);
        comm.ExecuteNonQuery();
        con.Close();
        
        Label_Messages.Text = "Thank You, Your Record Saved";
        Text_Comment.Text = "";
    }
    protected void Link_Leave_Click(object sender, EventArgs e)
    {
        //EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        //DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        //Response.Redirect("~/UsersArea/LeaveAdmin.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + " &DEP_NO=" + DEPARTMENT_NO + "");
    }
    protected void Link_Update_Password_Click(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        Response.Redirect("~/UsersArea/updateUser.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + "");
    }
    protected void Text_Name_TextChanged(object sender, EventArgs e)
    {

    }
    protected void menuBar_MenuItemClick(object sender, MenuEventArgs e)
    {

    }
}