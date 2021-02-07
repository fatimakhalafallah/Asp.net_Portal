using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Configuration;


public partial class FunctionRequest : System.Web.UI.Page
{
    public OdbcCommand odbccomm = null;
    public OdbcConnection odbccon = null;

    public SqlCommand Sqlcomm   = null;
    public SqlConnection Sqlcon = null;
    public SqlCommand comm = null;
    public SqlConnection conn = null;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;
    public string EMPLOYEE_NO, DEPARTMENT_NO;
    public static string EmpName, EmpEmail, Depart, Status = "Send";

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
                CheckAccount();

                EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
                DEPARTMENT_NO = Request.QueryString["DEP_NO"];

                UserData();
                Text_Date.Text = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
                getMenu();
            }
        }
    }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        if (Text_Purpose.Text.Length < 1000)
        {
            Insert();
            SendEMail(Status);

            Response.Redirect("~/UsersArea/servicesSendRequest.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + "");

            Reset();
            CheckAccount();
        }
        else
        { Text_Purpose.Visible = true; }
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset();
        CheckAccount();
    }
    public void Reset()
    {             
        //Text_Num.Text = "";
        //Text_Department.Text = "";
        Text_Date.Text = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
        Text_Strat.Text = "hh:mm";
        Text_End.Text = "hh:mm";
        Text_End_Date.Text = "";
        Text_Strat_Date.Text = "";
        Text_Location.Text = "";
        Text_Purpose.Text = "";
        Text_No_Guest.Text = "";
        Text_Arrangements.Text = "";
        //Text_Request_By.Text = "";
        Label_Messages.Text = "";
    }
    private void Insert()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        CheckAccount();

        sql = "INSERT INTO ES_FUNCTION_REQ " +
       "(REQUEST_NO, RQUESTDATE, DEPT, SEC_NO, FUNSTARTDTAE, FUNCENDDATE, TIMEFROM, TIMETO, OFFICESITE, LOCATION," +
       " PURPOSE, COST_CENTER, GUESTS, ARRANGMENTS, PARTIES, STATUS, ESTIMAT_COST, SEND_DATE, CREATED_USER, CREATED_DATE," +
        "MNGR_ID, MNGR_TXT, MNGR_DATE, GM_ID, GM_DATE, GM_TXT, AD_ID, AD_TXT, AD_DATE, TIME_TYPE, TIME_TYPE2)  VALUES" +

        "('" + Text_Num.Text + "', '" + Text_Date.Text + "' , '" + int.Parse(DEPARTMENT_NO) + "' , '" + int.Parse(DEPARTMENT_NO) + "', '" + Text_Strat_Date.Text + "', '" + Text_End_Date.Text + "', '" + Text_Strat.Text + "', '" + Text_End.Text + "' ,'', '" + Text_Location.Text + "', " +
        "'" + Text_Purpose.Text + "', '', '" + Text_No_Guest.Text + "', '" + Text_Arrangements.Text + "', '', '0', '0', '" + Text_Date.Text + "', '" + EMPLOYEE_NO + "', '" + Text_Date.Text + "'," +
        "'', '', '', '', '', '', '', '', '', '"+ RadioButtonList1.SelectedItem +"', '"+ RadioButtonList2.SelectedItem +"')";

        odbccon = new OdbcConnection(connection);
        odbccon.ConnectionString = connection;
        odbccon.Open();

        odbccomm = new OdbcCommand(sql, odbccon);
        odbccomm.ExecuteNonQuery();
        odbccon.Close();
        //Reset();
        Label_Messages.Text = "Thank You Mr,MS " + Text_Name.Text + " Your Record Saved";
    }
    public void CheckAccount()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        string sql = "SELECT NVL(MAX(REQUEST_NO),0)+1 FROM ES_FUNCTION_REQ";
        // //NVL(MAX(REQUEST_NO),0)+1
        OdbcConnection odbcconn = new OdbcConnection(connectionString);
        OdbcCommand odbccom = new OdbcCommand(sql, odbcconn);

        odbccom.Connection.Open();
        OdbcDataReader read = odbccom.ExecuteReader();
        read.Read();

        if (read.HasRows)
        //if (read.Read())
        {
            Text_Num.Text = read[0].ToString();
        }
        //else
        //{
        //    Text_Num.Text = "1";
        //}
        odbccom.Connection.Close();
    }
    public void UserData()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO   = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];



        //Text_ID.Text = EMPLOYEE_NO;

        string sql = "SELECT USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME FROM USERS_INFORMATIONS INNER JOIN DEPARTMENTS ON (USERS_INFORMATIONS.DEP_NO = DEPARTMENTS.DEP_NO) AND USERS_INFORMATIONS.DEP_NO = '" + int.Parse(DEPARTMENT_NO) + "' WHERE USERS_INFORMATIONS.EMPLOYEE_NO = '" + Int32.Parse(EMPLOYEE_NO) + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_Name.Text = read["FULL_USER_NAME"].ToString();
            Text_Request_By.Text = read["FULL_USER_NAME"].ToString();
            Text_Department.Text = read["DEP_NAME"].ToString();
            //Text_Department.Text = read["DEP_NAME"].ToString();
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }

        //Text_Id.Text = EMPLOYEE_NO.ToString();
        cmd.Connection.Close();
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
    public void SendEMail(string Status)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
                     "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO IN" +
                     "(SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '18')";
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
           //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=portal@petroneed.com.sd&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Function Request Information&USERNAMESREQ=" + Text_Name.Text + "");
         Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL="+ EmpEmail+"&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Function Request Information&USERNAMESREQ=" + Text_Name.Text + "");
          
        cmd.Connection.Close();
    }
    //private void getMenu()
    //{
    //    rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
    //    connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString2"].ConnectionString.ToString();

    //    Sqlcon = new SqlConnection(connection);
    //    Sqlcon.ConnectionString = connection;
    //    Sqlcon.Open();


    //    DataSet ds = new DataSet();
    //    DataTable dt = new DataTable();

    //    //string sql = "Select * from tbl_WebMenu";
    //    string sql = "Select * from tbl_WebMenu INNER JOIN User_Check ON (tbl_WebMenu.MenuID = User_Check.MenuID)" +
    //        //"AND (User_Check.MenuID = tbl_WebMenu.ParentID)" +
    //                  "AND (User_Check.EmpNumber = '" + EMPLOYEE_NO + "' ) AND (User_Check.STATUS = '" + 1 + "')";

    //    SqlDataAdapter da = new SqlDataAdapter(sql, Sqlcon);
    //    da.Fill(ds);
    //    dt = ds.Tables[0];
    //    DataRow[] drowpar = dt.Select("ParentID=" + 0);

    //    foreach (DataRow dr in drowpar)
    //    {
    //        menuBar.Items.Add(new MenuItem(dr["MenuName"].ToString(),
    //                dr["MenuID"].ToString(), "",
    //                dr["MenuLocation"].ToString()));
    //    }

    //    foreach (DataRow dr in dt.Select("ParentID >" + 0))
    //    {
    //        MenuItem mnu = new MenuItem(dr["MenuName"].ToString(),
    //                         dr["MenuID"].ToString(), "", dr["MenuLocation"] + "?EMPLOYEE_NO=" + EMPLOYEE_NO.ToString() + "&DEP_NO=" + DEPARTMENT_NO.ToString()); //dr["MenuID"].ToString(),"", dr["MenuLocation"].ToString());
    //        menuBar.FindItem(dr["ParentID"].ToString()).ChildItems.Add(mnu);
    //    }
    //    Sqlcon.Close();
    //}

   

}