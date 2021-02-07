using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Odbc;

public partial class UsersArea_AccountRequest : System.Web.UI.Page
{

    public string EMPLOYEE_NO, DEPARTMENT_NO;
    public OdbcCommand comm, comm_mas = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter odbcadabter = null;
    public OdbcDataAdapter dadapter;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxControlToolkit.ToolkitScriptManager.GetCurrent(Page);
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
                    Text_Date.Text = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
                    Reset();
                    getMenu();
                    UserData();
                    CheckAccount();
                   
                }

        }
    }

    public void UserData()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        //Text_ID.Text = EMPLOYEE_NO;
        //string sql = "SELECT USERS_INFORMATIONS.FULL_USER_NAME, USERS_INFORMATIONS.EMAIL, DEPARTMENTS.DEP_NAME FROM USERS_INFORMATIONS INNER JOIN DEPARTMENTS ON (USERS_INFORMATIONS.DEP_NO = DEPARTMENTS.DEP_NO) AND USERS_INFORMATIONS.DEP_NO = '" + int.Parse(DEPARTMENT_NO) + "' WHERE USERS_INFORMATIONS.EMPLOYEE_NO = '" + Int32.Parse(EMPLOYEE_NO) + "'";

        string sql = "SELECT EMPLOYEES.EMPLOYEE_NAME, DEPARTMENTS.DEP_NAME," +
                       "LKP_JOBS.JOB_NAME FROM EMPLOYEES " +
                       "INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO)" +
                       "INNER JOIN LKP_JOBS ON    (LKP_JOBS.JOB_NO = EMPLOYEES.JOB_NO)" +
                       "WHERE EMPLOYEES.EMPLOYEE_STATUS = '1' AND EMPLOYEES.EMPLOYEE_NO = '" + Int32.Parse(EMPLOYEE_NO) + "' ";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_Name.Text = read["EMPLOYEE_NAME"].ToString();
            Text_Department.Text = read["DEP_NAME"].ToString();
        }
        Text_Id.Text = EMPLOYEE_NO.ToString();
        cmd.Connection.Close();

       
    }

     

    protected void Text_I_TextChanged(object sender, EventArgs e)
     {
        string user_id=Text_I.Text;
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        string sql = "SELECT DISTINCT USERS_INFORMATIONS.FULL_USER_NAME , DEPARTMENTS.DEP_NAME FROM EMPLOYEES , USERS_INFORMATIONS INNER JOIN DEPARTMENTS ON (USERS_INFORMATIONS.DEP_NO = DEPARTMENTS.DEP_NO)WHERE EMPLOYEES.EMPLOYEE_STATUS = '1' AND USERS_INFORMATIONS.USER_NO = '"+user_id+"'"; 

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            TextBox2.Text = read["FULL_USER_NAME"].ToString();
            TextBox1.Text = read["DEP_NAME"].ToString();
        }

        cmd.Connection.Close(); 
    }

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
           if  (CheckBoxList1.Text=="Temporary")
        {
            Label8.Visible = true;
            start_date.Visible = true;
            Label7.Visible = true;
            end_date.Visible = true;
        }
        else
        {
            Label8.Visible = false;
            start_date.Visible = false;
            Label7.Visible = false;
            end_date.Visible = false;

        } 


    }

  

    public void CheckAccount()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        //string sql = "SELECT MAX(TRF_NO)+1 FROM TRAVEL_MSTR";
        string sql = "SELECT NVL(MAX(FORM_NO),0)+1 FROM ICT_NEW_ACCOUNT "; // add the database 

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

    private void Reset()
    {
        //Desc_Box.Text = "";
        //DropDownList2.Items.Clear();
        Text_Name.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        Text_I.Text = ""; 
         //CheckBoxList1.DataValueField="";
         //CheckBoxList1.SelectedItem= "";
         CheckBoxList1.ClearSelection();
       // CheckBox1.Checked=false;
        //CheckBox2.Checked = false;
        start_date.Text = "";
        end_date.Text = "";

        // Text_Position.Text = "";
        //Label_Messages0.Text = ""; //"Thank You Mr,MS " + Text_Name.Text + " Your Record Saved";
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


    protected void Butt_Submit_Click(object sender, EventArgs e)
    {

        InsertMaster();
        SendEMail();
        Reset();
        UserData();
        //Label_Messages0.Text = "Please select an item from up list";

    }


    private void InsertMaster()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql_mas;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        if (CheckBoxList1.Text == "Permanent")
        {
            CheckAccount();
            sql_mas = "INSERT INTO ICT_NEW_ACCOUNT" +
                      "(FORM_NO, FORM_DATE, REQUEST_USER , REQUEST_USER_ID, USER_FULL_NAME, USER_DEPARTMENT, ACCOUNT_TYPE, " +
                      "START_DATE, END_DATE,FORM_STATUS,REQUEST_DEP,MNG_ID,MNG_DATE,MNG_COMMENT,IMNG_ID,IMNG_DATE,IMNG_COMMENT,REQUEST_EXECUTOR,USER_ID) VALUES" +

                      "('" + Text_Num.Text + "', '" + Text_Date.Text + "', '" + Text_Name.Text + "', '" + Text_Id.Text + "', '" + TextBox2.Text + "','" + TextBox1.Text + "','" + CheckBoxList1.Text + "','','','1','" + Text_Department.Text + "','','','','','','','','"+Text_I.Text+"')";

            // string sql2="INSERT INTO ICT_NEW_ACCOUNT"
            //0
            con = new OdbcConnection(connection);
            con.ConnectionString = connection;
            con.Open();

            comm_mas = new OdbcCommand(sql_mas, con);
            comm_mas.ExecuteNonQuery();

            con.Close();
        }
        else
            if (CheckBoxList1.Text == "Temporary") 
            {

                CheckAccount();
                sql_mas = "INSERT INTO ICT_NEW_ACCOUNT" +
                      "(FORM_NO, FORM_DATE, REQUEST_USER , REQUEST_USER_ID, USER_FULL_NAME, USER_DEPARTMENT, ACCOUNT_TYPE, " +
                      "START_DATE, END_DATE,FORM_STATUS,REQUEST_DEP,MNG_ID,MNG_DATE,MNG_COMMENT,IMNG_ID,IMNG_DATE,IMNG_COMMENT,REQUEST_EXECUTOR,USER_ID) VALUES" +

                          "('" + Text_Num.Text + "', '" + Text_Date.Text + "', '" + Text_Name.Text + "', '" + Text_Id.Text + "', '" + TextBox2.Text + "','" + TextBox1.Text + "','" + CheckBoxList1.Text + "','" + start_date.Text + "','" + end_date.Text + "','1','" + Text_Department.Text + "','','','','','','','','"+Text_I.Text+"')";


                con = new OdbcConnection(connection);
                con.ConnectionString = connection;
                con.Open();

                comm_mas = new OdbcCommand(sql_mas, con);
                comm_mas.ExecuteNonQuery();

                con.Close();


            }

    }



    public static string EmpName, EmpEmail, Depart;
    public string EMPNUMBER, DEPARTMENTNO, EMPNAME, EMPEMAIL, ACTIONDATE, REQUESTNAME, USERNAME;
    public void SendEMail()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO IN " +
            "(SELECT MNG FROM EMP_MNG WHERE EMPLOYEE_NO = '" + Text_Id.Text + "')";

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
            EMPNAME = EmpName;
            EMPEMAIL = EmpEmail;
        }

        //USERNOTIFICATIONEMAIL(EMPNAME, EMPEMAIL);
        Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME= New Account Request (AR)&USERNAMESREQ=" + Text_Name.Text + "");
        //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=portal@petroneeds.co&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Travel Request (TRF)&USERNAMESREQ=" + Text_Name.Text + "");

        cmd.Connection.Close();
    }



    protected void  Butt_Reset_Click(object sender, EventArgs e)
{
        Reset();
        UserData();
}





   
}