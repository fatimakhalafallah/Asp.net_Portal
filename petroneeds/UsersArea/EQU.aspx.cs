using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Configuration;
using System.Drawing.Design;
using System.Data.SqlClient;
using System.Data;

public partial class UsersArea_EQU : System.Web.UI.Page
{

    private const string VIEWSTATEKEY = "EqupReq2";
    public string EMPLOYEE_NO, DEPARTMENT_NO;
    public OdbcCommand comm, comm_mas = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter odbcadabter = null;
    public OdbcDataAdapter dadapter;

    public OdbcConnection odbccon = null;
    public OdbcDataAdapter odbcdadapter;
    DataSet dset, dset2, dataset;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        Items();
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
                //EquList();
                Form_N();

                if (!Page.IsPostBack)
                {
                    ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? 1 : ViewState[VIEWSTATEKEY];
                   // LoadContactControls(0);
                }
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
            //Text_Name.Text = read["FULL_USER_NAME"].ToString();
            //Text_Department.Text = read["DEP_NAME"].ToString();
            Text_Name.Text = read["EMPLOYEE_NAME"].ToString();
            Text_Department.Text = read["DEP_NAME"].ToString();
            Text_Position.Text = read["JOB_NAME"].ToString();
        }
        Text_Id.Text = EMPLOYEE_NO.ToString();
        cmd.Connection.Close();
    }


    private void Items()
    {
        DataSet dset;


        DropDownList1.Items.Clear();
        string connectionString = ConfigurationManager.ConnectionStrings["petroneedsConnectionString"].ConnectionString;
        OdbcConnection con = new OdbcConnection(connectionString);

        string sql = "SELECT EQ_NAME , EID FROM ICT_EQU";

        con.Open();
        OdbcCommand cmd = new OdbcCommand(sql, con);
        DataSet dataset = new DataSet();
        OdbcDataAdapter ad = new OdbcDataAdapter(sql, con);
        ad.Fill(dataset);

        DropDownList1.DataSource = dataset;
        DropDownList1.DataTextField = "EQ_NAME";///FULL_USER_NAME 
        DropDownList1.DataValueField = "EQ_NAME";//EMPLOYEE_NO
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("<<<Select>>>", "0"));
        //DropDownList1.Items.Insert(0, new ListItem("--Select--", "-1")); 
        //DropDownList1.SelectedIndex = 0;
        //DropDownList1.SelectedValue = "0";
        DropDownList1.SelectedItem.Value = "0";


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

    public void Form_N()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        //string sql = "SELECT MAX(TRF_NO)+1 FROM TRAVEL_MSTR";
        string sql = "SELECT NVL(MAX(FORM_NO),0)+1 FROM ICT_MSTR";

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


    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];


        InsertMaster();
        //LoadContactControls(1);
        //  SendEMail();
       // CHECKITEM();
        //checkitem2();

        //ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? 1 : ViewState[VIEWSTATEKEY];
        //LoadContactControls(0);
        //Page.Response.Redirect(Page.Request.Url.ToString(), true);

    }


  




   



    private void InsertMaster()
    {
        //MODIFY FORM_STATUS=1

        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql_mas;
        //string va = DropDownList2.DataValueField;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        Form_N();

        sql_mas = "INSERT INTO ICT_MSTR" +
                   "(FORM_NO, EMPLOYEE_NO, DEP_NO, FORM_DATE , FORM_STATUS,REQUESTER_NAME,REQUESTER_POSITION,IMNG_COMMENT,IMNG_ID,IMNG_DATE,SMNG_ID,SMNG_DATE,SMNG_COMMENT,MNG_ID,MNG_DATE,MNG_COMMENT,REQUEST_EXECUTOR) VALUES" +

                   "('" + Text_Num.Text + "', '" + Text_Id.Text + "', '" + DEPARTMENT_NO + "', '" + Text_Date.Text + "', '1','"+Text_Name.Text+"','','','','','','','','','','','')";


        con = new OdbcConnection(connection);
        con.ConnectionString = connection;
        con.Open();

        comm_mas = new OdbcCommand(sql_mas, con);
        comm_mas.ExecuteNonQuery();

        con.Close();
        //EQ_requestl.
            

       
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
        Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME= ICT Equipment  Request (EQ)&USERNAMESREQ=" + Text_Name.Text + "");
        //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=portal@petroneeds.co&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Travel Request (TRF)&USERNAMESREQ=" + Text_Name.Text + "");

        cmd.Connection.Close();
    }

    private void Reset()
    {
        //Desc_Box.Text = "";
        //DropDownList2.Items.Clear();
        Text_Name.Text = "";
        Text_Position.Text = "";
        Label_Messages.Text = ""; //"Thank You Mr,MS " + Text_Name.Text + " Your Record Saved";

    }

    private void Redir()
    {

        //EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        //DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        Response.Redirect("~/UsersArea/SubmitApprove.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + "");

    }

    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset();
        UserData();
      //  ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? 1 : ViewState[VIEWSTATEKEY];
       // LoadContactControls(0);
        //Page.Response.Redirect(Page.Request.Url.ToString(), true);
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }

    /*protected void Button1_Click1(object sender, EventArgs e)
    {

        Response.Redirect("~/UsersArea/TRY2.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + "");

    }*/


    /*protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UsersArea/Eq_Histroy.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + "");
    }*/
    /*protected void Button4_Click(object sender, EventArgs e)
    {

        ViewState[VIEWSTATEKEY] = int.Parse(ViewState[VIEWSTATEKEY].ToString()) + 1;
        LoadContactControls(0);

    }*/
   

    /*protected void Button1_Click(object sender, EventArgs e)
    {
        //Reset();
        //UserData();
        ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? 1 : ViewState[VIEWSTATEKEY];
        LoadContactControls(3);
        Response.Redirect("~/UsersArea/Eq_Histroy.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + "");  

    }*/
    protected void Button1_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/UsersArea/EQU_Return.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + "");
        //Reset();
        //UserData();
        //ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? 1 : ViewState[VIEWSTATEKEY];
        //LoadContactControls(0);
        //Page.Response.Redirect(Page.Request.Url.ToString(), true);
        //Page.Response.Redirect(Page.Request.Url.ToString(), true);


    }

}