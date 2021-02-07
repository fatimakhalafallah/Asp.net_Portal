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
using System.Data.SqlTypes;
using System.Data.Common;
//using System.Windows.Forms;

public partial class StationeryRequest : System.Web.UI.Page
{
    public OdbcCommand odbccomm = null;
    public OdbcConnection odbccon = null;
    public OdbcDataAdapter odbcadabter = null;
    public DataSet dataset = null;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand sqlcomm = null;
    public SqlConnection sqlconn = null;

    //SqlDataAdapter da;
    //DataSet ds = new DataSet();
    //SqlCommand cmd = new SqlCommand();
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
                CheckAccount();
                getMenu();
                UserData();
                Text_Date.Text = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
                //CheckAccount();
                ItemNo();
                Panel1.Visible = false;

                //BindData();
            }
        }
    }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        if (Text_Description.Text.Length < 100 || Text_Description.Text.Length == 0)
        {
            Text_Description.Visible = false;

            Details_Add();
            CheckAccountDetails();
            BindData();
            Text_Description.Text = "";
            Text_Unit.Text = "";
            Text_QTY.Text = "";
            DropDownList1.SelectedItem.Text = "";
        }
        else
        { Text_Description.Visible = true; }
    }
    private void Master_Add()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        OdbcCommand odbccomm = null;
        OdbcConnection odbccon = null;
        string sql;

        odbccon = new OdbcConnection(connection);
        odbccon.ConnectionString = connection;
        odbccon.Open();

        CheckAccount();

        sql = "INSERT INTO STOCK_REQUEST (ORDER_NO, ORDER_DATE, STATUS, CREATED_USER, DEP_NO, STORE_NO) " +
              "VALUES('" + Text_Num.Text + "' ,' " + Text_Date.Text + " ', '3', '" + EMPLOYEE_NO + "', '" + DEPARTMENT_NO + "', '4')";
        odbccomm = new OdbcCommand(sql, odbccon);                          //1
        odbccomm.ExecuteNonQuery();
        odbccon.Close();
    }
    private void Details_Add()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        OdbcCommand odbccomm = null;
        OdbcConnection odbccon = null;
        string sql;

        odbccon = new OdbcConnection(connection);
        odbccon.ConnectionString = connection;
        odbccon.Open();

        sql = "INSERT INTO STOCK_REQUEST_DETAILS (BRAN_NO, ORDER_NO, ORDER_DATE, GROUP_NO, ITEM_NO, QTY_ORDERED, DESCRIPTION) " +
            "VALUES('" + Text_Bran_No.Text + "', '" + Text_Num.Text + "', '" + Text_Date.Text + "', '51', '" + DropDownList1.SelectedValue + "', '" + Convert.ToInt32(Text_QTY.Text) + "', '" + Text_Description.Text + "')";

        //odbccomm = new OdbcCommand(sql, odbccon);
        odbccomm = new OdbcCommand(sql, odbccon);
        odbccomm.ExecuteNonQuery();
        odbccon.Close();
    }
    public void BindData()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

        odbccon = new OdbcConnection(connection);
        odbccon.ConnectionString = connection;
        //odbccon.Open();

        //odbccomm.CommandText = "SELECT BRAN_NO, ITEM_NO, QTY_ORDERED, DESCRIPTION FROM STOCK_REQUEST_DETAILS WHERE ORDER_NO = '" + Convert.ToInt32(Text_Num.Text) + "'";
        //odbccomm.Connection = odbccon;

        //odbcadabter = new OdbcDataAdapter(odbccomm);
        //odbcadabter.Fill(dataset);

        //odbccon.Open();
        //odbccomm.ExecuteNonQuery();

        //GridView1.DataSource = dataset;
        //GridView1.DataBind();
        //odbccon.Close();


        odbcadabter = new OdbcDataAdapter("SELECT BRAN_NO, ITEM_NO, QTY_ORDERED, GROUP_NO, DESCRIPTION FROM STOCK_REQUEST_DETAILS WHERE ORDER_NO = '" + Convert.ToInt32(Text_Num.Text) + "'", connection);

        dataset = new DataSet();
        odbcadabter.Fill(dataset);
        GridView1.DataSource = dataset.Tables[0];
        GridView1.DataBind();

    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Label_Messages.Text = "";
        Text_Bran_No.Text = "";
        Text_Description.Text = "";
        Text_Unit.Text = "";
        Text_QTY.Text = "";
        DropDownList1.SelectedIndex = 0;
        //Panel1.Visible = false;
        //CheckAccount();
        CheckAccountDetails();
    }
    private void getMenu()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString2"].ConnectionString.ToString();

        sqlconn = new SqlConnection(connection);
        sqlconn.ConnectionString = connection;
        sqlconn.Open();


        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        //string sql = "Select * from tbl_WebMenu";
        string sql = "Select * from tbl_WebMenu INNER JOIN User_Check ON (tbl_WebMenu.MenuID = User_Check.MenuID)" +
            //"AND (User_Check.MenuID = tbl_WebMenu.ParentID)" +
                      "AND (User_Check.EmpNumber = '" + EMPLOYEE_NO + "' ) AND (User_Check.STATUS = '" + 1 + "')";

        SqlDataAdapter da = new SqlDataAdapter(sql, sqlconn);
        da.Fill(ds);
        dt = ds.Tables[0];
        DataRow[] drowpar = dt.Select("ParentID=" + 0);

        foreach (DataRow dr in drowpar)
        {
            menuBar.Items.Add(new System.Web.UI.WebControls.MenuItem(dr["MenuName"].ToString(),
                    dr["MenuID"].ToString(), "",
                    dr["MenuLocation"].ToString()));
        }

        foreach (DataRow dr in dt.Select("ParentID >" + 0))
        {
            System.Web.UI.WebControls.MenuItem mnu = new System.Web.UI.WebControls.MenuItem(dr["MenuName"].ToString(),
                //dr["MenuID"].ToString(), "", dr["MenuLocation"] + "?EMPLOYEE_NO=" + EMPLOYEE_NO.ToString()); //dr["MenuID"].ToString(),"", dr["MenuLocation"].ToString());
                             dr["MenuID"].ToString(), "", dr["MenuLocation"] + "?EMPLOYEE_NO=" + EMPLOYEE_NO.ToString() + "&DEP_NO=" + DEPARTMENT_NO.ToString()); //dr["MenuID"].ToString(),"", dr["MenuLocation"].ToString());
            menuBar.FindItem(dr["ParentID"].ToString()).ChildItems.Add(mnu);
        }
        sqlconn.Close();
    }
    public void UserData()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string sql = "SELECT USERS_INFORMATIONS.FULL_USER_NAME, USERS_INFORMATIONS.EMAIL, DEPARTMENTS.DEP_NAME FROM USERS_INFORMATIONS INNER JOIN DEPARTMENTS ON (USERS_INFORMATIONS.DEP_NO = DEPARTMENTS.DEP_NO) AND USERS_INFORMATIONS.DEP_NO = '" + int.Parse(DEPARTMENT_NO) + "' WHERE USERS_INFORMATIONS.EMPLOYEE_NO = '" + int.Parse(EMPLOYEE_NO) + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            //if (read.Read())
            //{
            Text_Name.Text = read["FULL_USER_NAME"].ToString();
            Text_Department.Text = read["DEP_NAME"].ToString();
            //}
            //else
            // {
            //    Response.Redirect("~/Login.aspx");
            // }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
        cmd.Connection.Close();
    }
    public void CheckAccount()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        string sql = "SELECT NVL(MAX(ORDER_NO),0)+1 FROM STOCK_REQUEST";

        OdbcConnection odbcconn = new OdbcConnection(connectionString);
        OdbcCommand odbccmd = new OdbcCommand(sql, odbcconn);

        odbccmd.Connection.Open();
        OdbcDataReader read = odbccmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_Num.Text = read[0].ToString();
        }
        odbccmd.Connection.Close();
    }
    public void CheckAccountDetails()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        string sql = "SELECT NVL(MAX(BRAN_NO),0)+1 FROM STOCK_REQUEST_DETAILS WHERE ORDER_NO = '" + Text_Num.Text + "'";

        OdbcConnection odbcconn = new OdbcConnection(connectionString);
        OdbcCommand odbccmd = new OdbcCommand(sql, odbcconn);

        odbccmd.Connection.Open();
        OdbcDataReader read = odbccmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_Bran_No.Text = read[0].ToString();
        }
        odbccmd.Connection.Close();
    }
    //protected void GridView1_PageIndexChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
    //{
    //    GridView1.CurrentPageIndex = e.NewPageIndex;

    //    BindData();
    //}
    protected void Butt_NewRequ_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;

        CheckAccount();
        Master_Add();

        SendEMail();

        Label_Messages.Text = "";
        Text_Bran_No.Text = "";
        Text_Description.Text = "";
        Text_Unit.Text = "";
        Text_QTY.Text = "";

        ItemNo();
        DropDownList1.SelectedItem.Text = "";
        CheckAccountDetails();
    }
    private void ItemNo()
    {
        DataSet dset;
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        string sql = "SELECT ITEM_NAME_ENGLISH, ITEM_NO FROM PURCHASING_ITEMS WHERE GROUP_NO = '51'";


        odbcadabter = new OdbcDataAdapter(sql, connectionString);
        dset = new DataSet();
        odbcadabter.Fill(dset);
        DropDownList1.DataSource = dset.Tables[0];
        DropDownList1.DataTextField = "ITEM_NAME_ENGLISH";
        DropDownList1.DataValueField = "ITEM_NO";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("<<<Select>>>", "0"));
        DropDownList1.SelectedIndex = 0;
        DropDownList1.SelectedValue = "0";
        DropDownList1.SelectedItem.Value = "0";
    }
    private void UnitNo()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        //string sql = "SELECT UNIT_NO FROM PURCHASING_ITEMS WHERE ITEM_NO = '" + DropDownList1.SelectedValue + "'";
        //string sql = "SELECT UNITS.UNIT_NAME FROM UNITS INNER JOIN PURCHASING_ITEMS ON (PURCHASING_ITEMS.UNIT_NO = UNITS.UNIT_NO) AND (UNITS.UNIT_NO = '" + DropDownList1.SelectedValue + "')" +
        //    "AND PURCHASING_ITEMS.ITEM_NO = '" + DropDownList1.SelectedValue + "'";

        string sql = "SELECT UNITS.UNIT_NAME FROM UNITS INNER JOIN PURCHASING_ITEMS ON (PURCHASING_ITEMS.UNIT_NO = UNITS.UNIT_NO)" +
           "AND PURCHASING_ITEMS.ITEM_NO = '" + DropDownList1.SelectedValue + "'";
        OdbcConnection odbcconn = new OdbcConnection(connectionString);
        OdbcCommand odbccmd = new OdbcCommand(sql, odbcconn);

        odbccmd.Connection.Open();
        OdbcDataReader read = odbccmd.ExecuteReader();
        read.Read();
        if (read.HasRows)
        {
            Text_Unit.Text = read[0].ToString();
        }
        odbccmd.Connection.Close();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        UnitNo();
    }

    /// <summary>
    /// Emergancy Functions For e-mail
    /// </summary>
    public static string EmpName, EmpEmail, Depart;
    public string EMPNUMBER, DEPARTMENTNO, EMPNAME, EMPEMAIL, ACTIONDATE, REQUESTNAME, USERNAME;
    public void E_mails(string Address, string MesBody)
    {
        List<E_mails> E_mails = new List<E_mails>();
        E_mails m = new E_mails(Address, MesBody);
    }
    public void SendEMail()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO IN " +
            "(SELECT MNG FROM EMP_MNG WHERE EMPLOYEE_NO = '" + EMPLOYEE_NO + "')";

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

        USERNOTIFICATIONEMAIL(EMPNAME, EMPEMAIL);
        cmd.Connection.Close();
    }
    private void USERNOTIFICATIONEMAIL(string _EMPNAME, string _EMPEMAIL)
    {
        EMPLOYEE_NO   = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];        
        ACTIONDATE = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
        REQUESTNAME = "Stationary Request";//
        USERNAME = Text_Name.Text;//

        //string To   = "portal@petroneed.com.sd";// EMPEMAIL;
        string To = EMPEMAIL;
        string Body = " <html><body><h2><p> Dear Mr/Mrs: </p></h2>  &nbsp; &nbsp; &nbsp;" + EMPNAME + " </br></br>" +
                      " You are received request: " + REQUESTNAME + " </br>" +
                      " from user: " + USERNAME + " </br>" +
                      " Request Date: " + ACTIONDATE + " </br></br></br>" +
                      " Please check your account.  </br></br></br>" +
                      " Best Regards.  </br>" +
                      " Petroneeds Portal System  </div></html></body>";
        E_mails(To, Body);
    }
}

      