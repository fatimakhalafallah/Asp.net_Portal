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
    private const string VIEWSTATEKEY = "StationaryRequest";

    public OdbcCommand odbccomm = null;
    public OdbcConnection odbccon = null;
    public OdbcDataAdapter odbcadabter = null;
    public DataSet dataset = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;
    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand sqlcomm = null;
    public SqlConnection sqlconn = null;

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

                CheckAccount();
                if (!Page.IsPostBack)
                {
                    ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? 1 : ViewState[VIEWSTATEKEY];
                    LoadContactControls(0);
                }
            }
        }
    }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        Master_Add();
        LoadContactControls(1);
        SendEMail();

        Response.Redirect("~/UsersArea/servicesSendRequest.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + "");

        ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? 1 : ViewState[VIEWSTATEKEY];
        LoadContactControls(0);
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
        Label_Messages.Text = "Thank You Mr,MS " + Text_Name.Text + " Your Record Saved";

        //if (Text_Description.Text.Length < 100 || Text_Description.Text.Length == 0)
        //{
        //    Text_Description.Visible = false;

        //    Details_Add();
        //    CheckAccountDetails();
        //    BindData();
        //    Text_Description.Text = "";
        //    Text_Unit.Text = "";
        //    Text_QTY.Text = "";
        //    DropDownList1.SelectedItem.Text = "";
        //}
        //else
        //{ Text_Description.Visible = true; }
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
       // 9633

        sql = "INSERT INTO STOCK_REQUEST (ORDER_NO, ORDER_DATE, STATUS, ADMIN_COMMENT,ADMIN_ID, CREATED_USER ,CREATED_ID ,DEP_NO,MNG_ID,MNG_DATE,MNG_COMMENT,REQUEST_EXCUTOR) " +
              "VALUES('" + Text_Num.Text + "' ,' " + Text_Date.Text + " ', '3','','', '" + Text_Name.Text + "','" + EMPLOYEE_NO + "', '" + DEPARTMENT_NO + "','','','','9633')";

      //ORDER_NO, ORDER_DATE, STATUS, ADMIN_COMMENT, ADMIN_ID, CREATED_USER, CREATED_ID, DEP_NO, MNG_ID, MNG_DATE, MNG_COMMENT
       
        odbccomm = new OdbcCommand(sql, odbccon);                          //1
        odbccomm.ExecuteNonQuery();
        odbccon.Close();
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Label_Messages.Text = "";

        ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? 1 : ViewState[VIEWSTATEKEY];
        LoadContactControls(0);
        Page.Response.Redirect(Page.Request.Url.ToString(), true);

        //Text_Bran_No.Text = "";
        //Text_Description.Text = "";
        //Text_Unit.Text = "";
        //Text_QTY.Text = "";
        //DropDownList1.SelectedIndex = 0;
        //Panel1.Visible = false;
        //CheckAccount();
        //CheckAccountDetails();
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
    protected void Butt_Add_New_Click(object sender, EventArgs e)
    {
        ViewState[VIEWSTATEKEY] = int.Parse(ViewState[VIEWSTATEKEY].ToString()) + 1;
        LoadContactControls(0);
    }
    private void LoadContactControls(int Status)
    {
        if (Status == 0)
            for (int i = 0; i < int.Parse(ViewState[VIEWSTATEKEY].ToString()); i++)
            {
                Session["FormNo"] = "0";
                Session["FormDate"] = "0";
                Session["DetailsNo"] = "0";
                PlaceHolder1.Controls.Add(LoadControl("~/userControll/StationaryRequest.ascx"));
            }
        else
            if (Status == 1)
            {
                for (int i = 0; i < int.Parse(ViewState[VIEWSTATEKEY].ToString()); i++)
                {
                    Session["FormNo"]   = Text_Num.Text;
                    Session["FormDate"] = Text_Date.Text;
                    //Session["DetailsNo"] = DetailsNo[x];
                    PlaceHolder1.Controls.Add(LoadControl("~/userControll/StationaryRequest.ascx"));
                }
            }
    }
    /*public void BindData()
   {
       rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
       connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

       odbccon = new OdbcConnection(connection);
       odbccon.ConnectionString = connection;
       //odbccon.Open();

       //odbccomm.CommandText = "SELECT BRAN_NO, ITEM_NO, QTY_ORDERED, DESCRIPTION FROM STOCK_REQUEST_DETAILS WHERE ORDER_NO = '" + Convert.ToInt32(Text_Num.Text) + "'";
       //odbccomm.Connection = odbccon;

       /
     * /odbcadabter = new OdbcDataAdapter(odbccomm);
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

   }*/
    /*public void CheckAccountDetails()
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
    }*/
    //protected void GridView1_PageIndexChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
    //{
    //    GridView1.CurrentPageIndex = e.NewPageIndex;

    //    BindData();
    //}
    /// <summary>
    /// Emergancy Functions For e-mail
    /// </summary>
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
        Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Stationery Request&USERNAMESREQ=" + Text_Name.Text + "");
        //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=portal@petroneed.com.sd&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Stationery Request&USERNAMESREQ=" + Text_Name.Text + "");

        //USERNOTIFICATIONEMAIL(EMPNAME, EMPEMAIL);
        cmd.Connection.Close();
    }
    /* private void USERNOTIFICATIONEMAIL(string _EMPNAME, string _EMPEMAIL)
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
     }*/
    /* public void E_mails(string Address, string MesBody)
     {
         List<E_mails> E_mails = new List<E_mails>();
         E_mails m = new E_mails(Address, MesBody);
     }*/
}

      