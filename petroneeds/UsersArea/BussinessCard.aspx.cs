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

public partial class UsersArea_BussinessCard : System.Web.UI.Page
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

        /*string sql = "SELECT EMPLOYEES.EMPLOYEE_NAME,EMPLOYEES.SECTION_NO,EMPLOYEES.EMAIL, DEPARTMENTS.DEP_NAME," +
                      "LKP_JOBS.JOB_NAME FROM EMPLOYEES " +
                      "INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO)" +
                      "INNER JOIN LKP_JOBS ON (LKP_JOBS.JOB_NO = EMPLOYEES.JOB_NO)" +
                      "WHERE EMPLOYEES.EMPLOYEE_STATUS = '1' AND EMPLOYEES.EMPLOYEE_NO = '" + Int32.Parse(EMPLOYEE_NO) + "' ";*/

        string sql = "SELECT EMPLOYEES.EMPLOYEE_NAME, DEPARTMENTS.DEP_NAME,EMPLOYEES.EMAIL,PROJECT_CODE.PROJ_NAME,LKP_JOBS.JOB_NAME,LKP_JOBS.JOB_NO FROM EMPLOYEES INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO)INNER JOIN LKP_JOBS ON (LKP_JOBS.JOB_NO = EMPLOYEES.JOB_NO)INNER JOIN PROJECT_CODE ON (EMPLOYEES.SECTION_NO = PROJECT_CODE.PROJ_NO)WHERE EMPLOYEES.EMPLOYEE_STATUS = '1' AND EMPLOYEES.EMPLOYEE_NO ='" + Int32.Parse(EMPLOYEE_NO) + "'";
					  
					   				 				  	
        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_Name.Text = read["EMPLOYEE_NAME"].ToString();
            Text_Department.Text = read["DEP_NAME"].ToString();
            TextBox1.Text = read["JOB_NAME"].ToString();
            Text_email.Text = read["EMAIL"].ToString();
            Text_section.Text = read["PROJ_NAME"].ToString();
            Text_job.Text = read["JOB_NO"].ToString(); 
           ////
        }
        Text_Id.Text = EMPLOYEE_NO.ToString();
        cmd.Connection.Close();
        indataa();
    }

    public void indataa()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        string sql22 = "SELECT DEP_NO FROM DEPARTMENTS WHERE DEP_NAME='" + Text_Department.Text + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql22, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_depno.Text = read["DEP_NO"].ToString();

        }

        cmd.Connection.Close();
        section(); 

    }

    public void section()
    {

         string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

         string sql22 = "SELECT PROJ_NO FROM PROJECT_CODE WHERE PROJ_NAME='"+Text_section.Text+"'";


        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql22, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_SectionNO.Text = read["PROJ_NO"].ToString();

        }

        cmd.Connection.Close();


    }
   
    
    public void CheckAccount()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        //string sql = "SELECT MAX(TRF_NO)+1 FROM TRAVEL_MSTR";
        string sql = "SELECT NVL(MAX(REQ_NO),0)+1 FROM BUSINESS_CARD"; // add the database 

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
        
        Text_Name.Text = "";
        Text_qty.Text = "";
        Text_phone.Text = "";
        Text_ext.Text = "";
        Tel1.Text = "";
        Tel2.Text = "";

         
    }

    protected void txtMQty_TextChanged(object sender, EventArgs e)
    {

        Text_phone.Text = "+24918708"; 

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
          

            CheckAccount();

            sql_mas = "INSERT INTO BUSINESS_CARD" +
                      "(EMPLOYEE_NO, DEP_NO, SEC_NO,JOB_NO,REQ_DATE,EMP_NAME,JOB_NAME, TEL1, TEL2, EMAIL, MAN_APPROVE, MAN_DATE, HR_APPROVE, HR_DATE, STATUS, AS_APPROVE, AS_DATE, QTY, PHONE, EXTE,REQ_NO,DEP_NAME)VALUES" +

                      "('" + Text_Id.Text + "','" + Text_depno.Text + "',' " + Text_SectionNO.Text + "','" + Text_job.Text + "','" + Text_Date.Text + "','" + Text_Name.Text + "','" + TextBox1.Text + "','" + Tel1.Text + "','" + Tel2.Text + "','" + Text_email.Text + "','','','','','1','','','" + Text_qty.Text + "','" + Text_phone.Text + "','" + Text_ext.Text + "','" + Text_Num.Text + "','"+Text_Department.Text+"')";

            //BUSINESS_CARD
            //EMPLOYEE_NO, DEP_NO, SEC_NO,JOB_NO,REQ_DATE,EMP_NAME,JOB_NAME, TEL1, TEL2, EMAIL, MAN_APPROVE, MAN_DATE, HR_APPROVE, HR_DATE, STATUS, AS_APPROVE, AS_DATE, QTY, PHONE, EXTE
            con = new OdbcConnection(connection);
            con.ConnectionString = connection;
            con.Open();

            comm_mas = new OdbcCommand(sql_mas, con);
            comm_mas.ExecuteNonQuery();
            con.Close();
       
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
           Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME= Business Card Request(BC)&USERNAMESREQ=" + Text_Name.Text + "");
        //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=portal@petroneeds.co&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Travel Request (TRF)&USERNAMESREQ=" + Text_Name.Text + "");

        cmd.Connection.Close();
    }



    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset();
        UserData();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/UsersArea/DID_Return.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + ""); 
    }

}