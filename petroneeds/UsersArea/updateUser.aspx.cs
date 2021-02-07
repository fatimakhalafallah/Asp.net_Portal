using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class UsersArea_updateUser : System.Web.UI.Page
{
    public OdbcConnection conn = null;
    public OdbcCommand cmd = null;
    public OdbcDataReader read = null;

    public SqlCommand comm = null;
    public SqlConnection con = null;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;


    public string EMPLOYEE_NO, DEPARTMENT_NO;

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
                Text_New_Password.Text = "";
                Text_Old_Password.Text = "";
                Label4.Text = "";
                getMenu();
            }
        }
    }
    protected void Butt_Send_Click(object sender, EventArgs e)
    {
        //FIRST PASSWORD 
        //132343
        UpdatePassword();
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Text_New_Password.Text = "";
        Text_Old_Password.Text = "";
        Label4.Text = "";
    }
    private void UpdatePassword()
    {
        string date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        EMPLOYEE_NO     = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO   = Request.QueryString["DEP_NO"];

        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        OdbcConnection conn = new OdbcConnection(connectionString);

        conn = new OdbcConnection(connectionString);
        conn.ConnectionString = connectionString;
        conn.Open();

        //string sql = "UPDATE USERS_PASSWORDS SET PASSWORDS = '" + Text_New_Password.Text + "', CHANGE_DATE = '" + date + "' WHERE " +
        //             "UI_USER_NO = (SELECT USER_NO FROM USERS_INFORMATIONS WHERE "+
        //             "USERS_PASSWORDS.UI_USER_NO = USERS_INFORMATIONS.USER_NO "+
        //             "AND USERS_PASSWORDS.OLD_PASSWORDS  = '"+ Text_Old_Password.Text +"'"+
        //             "AND USERS_INFORMATIONS.EMPLOYEE_NO = '"+ EMPLOYEE_NO +"')";

        //if (Text_New_Password.Text == Text_Confirm_Password.Text)
        if (String.Equals(Text_New_Password.Text, Text_Confirm_Password.Text))
        {
            string sql = "UPDATE USERS_PASSWORDS SET USERS_PASSWORDS.PASSWORDS = '" + Text_New_Password.Text + "', " +
                         "USERS_PASSWORDS.CHANGE_DATE    = '" + date + "', " +
                         "USERS_PASSWORDS.OLD_PASSWORDS  = '" + Text_Old_Password.Text + "' WHERE " +
                         "USERS_PASSWORDS.UI_USER_NO = (SELECT USER_NO FROM USERS_INFORMATIONS WHERE " +
                         "USERS_PASSWORDS.UI_USER_NO = USERS_INFORMATIONS.USER_NO " +
                         "AND '" + Text_Old_Password.Text + "'  <>  '" + Text_New_Password.Text + "'" +
                         "AND USERS_PASSWORDS.PASSWORDS = '" + Text_Old_Password.Text + "'" +
                         "AND USERS_INFORMATIONS.EMPLOYEE_NO = '" + EMPLOYEE_NO + "')";

            OdbcCommand comm = new OdbcCommand(sql, conn);
            //comm.ExecuteNonQuery();
            string Msg = String.Empty;
            Msg = (string)comm.ExecuteNonQuery().ToString();

            if (Msg == "")
            {
                Label4.Text = "Error, You must insert your current password and then your new password...";
            }
            else
                if (Msg == "0")
                {
                    Label4.Text = "Error, You must insert your current password and then your new password...";
                }
                else
                    if (Msg == "-1")
                    {
                        Label4.Text = "Error, You must insert your current password and then your new password...";
                    }
                    else
                        if (Msg == "1")
                        {
                            Label4.Text = "Thank you, Your password was updated...";
                        }
            conn.Close();
            Text_Old_Password.Text = "";
            Text_New_Password.Text = "";
        }
        else
        {
            Label4.Text = "Error, different btween new & confirm password, please make sure your password..."; 
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
    /*public void UserLogin()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        Text_ID.Text = "Your ID Number is " + EMPLOYEE_NO;

        string sql = "SELECT USERS_INFORMATIONS.FULL_USER_NAME, USERS_INFORMATIONS.EMAIL, DEPARTMENTS.DEP_NAME FROM USERS_INFORMATIONS INNER JOIN DEPARTMENTS ON (USERS_INFORMATIONS.DEP_NO = DEPARTMENTS.DEP_NO) AND USERS_INFORMATIONS.DEP_NO = '" + int.Parse(DEPARTMENT_NO) + "' WHERE USERS_INFORMATIONS.EMPLOYEE_NO = '" + Int32.Parse(EMPLOYEE_NO) + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_Name.Text = "Welcome Mr/Mrs. " + read["FULL_USER_NAME"].ToString();
            Text_E_Mail.Text = "Your E-mail is " + read["EMAIL"].ToString();
            Text_Department.Text = "and your department is " + read["DEP_NAME"].ToString();
        }
        else
        {

        }

        cmd.Connection.Close();
    }*/
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        Response.Redirect("~/UsersArea/Default.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + "");
    }
}