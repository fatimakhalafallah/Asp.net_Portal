using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UsersArea_Recruitment : System.Web.UI.Page
{
    private const string VIEWSTATEKEY = "Reqruitment";
    public OdbcCommand comm = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter odbcadabter = null;

    public DataSet dataset = null;
    private string connection = null;

    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;
    public string EMPLOYEE_NO, DEPARTMENT_NO, MANAGER;

    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO   = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        if (EMPLOYEE_NO == "" || EMPLOYEE_NO == null && DEPARTMENT_NO == "" || DEPARTMENT_NO == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                UserAuthorization();
                getMenu();
                ResetMaster();
                CheckAccountMaster();
                Text_Date.Text = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
                ComDepartments();

                if (!Page.IsPostBack)
                {
                    UserAuthorization();
                    ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? 1 : ViewState[VIEWSTATEKEY];
                    LoadContactControls(0);
                }
            }
        }
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        ResetMaster();
        ComDepartments();
        CheckAccountMaster();

        ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? 1 : ViewState[VIEWSTATEKEY];
        LoadContactControls(0);
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
    private void Master_Add()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql;

        CheckAccountMaster();
        sql = "INSERT INTO RECRUITMENT_FORM" +
        "(RF_NO, DEP_NO, JOB_NO, JOB_AVAILABLE, RF_TYPE, REPORTING_NO, REQ_PERIOD, " +
        "POSITION_JUSTIFICATION, NO_OF_CANDIDATE, SINGLE_JUSTIFICATION, RF_DATE, MNG_CREATER, MNG_DATE, HR_ID," +
        "HR_DATE, GM_ID, GM_DATE, SNR_MNG_ID, SNR_MNG_DATE, FORM_STATUS) VALUES" +

        //"('" + Text_Num.Text + "', '" + DropDownList1.SelectedValue + "', '', '', '" + DropDownList2.SelectedItem + "', '', ''," +
        //"'" + Text_Position.Text +" ', '"+ RadioButtonList2.SelectedValue +"', '"+ Text_Justific.Text +"', '"+ Text_Date.Text +"', '', '', ''," +
        //"'', '', '', '', '', '0')";

         "('" + Text_Num.Text + "', '" + DropDownList1.SelectedValue + "', '" + Text_Position.Text + "', '" + RadioButtonList1 .SelectedValue + "', '" + DropDownList2.SelectedValue + "', '', '" + Text_period.Text + "'," +
        "'" + Text_Justific.Text + " ', '" + RadioButtonList2.SelectedValue + "', '" + Text_Single_Justific.Text + "', '" + Text_Date.Text + "', '" + EMPLOYEE_NO + "', '" + Text_Date.Text + "', ''," +
        "'', '', '', '', '', '1')";
                            //0
        con = new OdbcConnection(connection);
        con.ConnectionString = connection;
        con.Open();

        comm = new OdbcCommand(sql, con);
        comm.ExecuteNonQuery();
        con.Close();
    }
    private void ResetMaster()
    {
        Text_Num.Text = "";
        Text_Position.Text = "";
        //Text_Report_to.Text = "";
        Text_Justific.Text = "";
        Text_Single_Justific.Text = "";
        Text_Single_Justific.Enabled = false;
        DropDownList2.SelectedValue = "0";
        Label_Messages.Text = "";
   
        RadioButtonList1.SelectedValue = "";
        Text_period.Text = "";
        Text_period.Enabled = false;
        CheckAccountMaster();
    }
    public void CheckAccountMaster()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        string sql = "SELECT NVL(MAX(RF_NO),0)+1 FROM RECRUITMENT_FORM";
        // //NVL(MAX(RF_NO),0)+1
        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_Num.Text = read[0].ToString();
        }
        else
        {
            Text_Num.Text ="1";
        }
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
    private void ComDepartments()
    {
        DataSet dset;
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        string sql = "SELECT DEP_NAME, DEP_NO FROM DEPARTMENTS";

        odbcadabter = new OdbcDataAdapter(sql, connectionString);
        dset = new DataSet();
        odbcadabter.Fill(dset);
        DropDownList1.DataSource = dset.Tables[0];
        DropDownList1.DataTextField = "DEP_NAME";
        DropDownList1.DataValueField = "DEP_NO";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("<<<Select>>>", "0"));
        DropDownList1.SelectedIndex = 0;
        DropDownList1.SelectedValue = "0";
        DropDownList1.SelectedItem.Value = "0";
    }
    protected void Butt_Add_Details_Click(object sender, EventArgs e)
    {
        ViewState[VIEWSTATEKEY] = int.Parse(ViewState[VIEWSTATEKEY].ToString()) + 1;
        LoadContactControls(0);
    }
    protected void Submit_Click_Click(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        if (Text_Justific.Text.Length < 100 || Text_Justific.Text.Length == 0)
        {
            ////Label_Charactor.Visible = true;
            Master_Add();
            LoadContactControls(1);
            SendEMail();

            Response.Redirect("~/UsersArea/servicesSendRequest.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + "");

            ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? 1 : ViewState[VIEWSTATEKEY];
            LoadContactControls(0);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);

            Label_Messages.Text = "Thank You Mr,MS Your Record Saved";
        }
        else
        {
            Label_Charactor.Visible = true;
        }
    }
    /* protected void Butt_New_Click(object sender, EventArgs e)
     {
         ResetMaster();
         ComDepartments();
         CheckAccountMaster();
         Butt_New.Visible = true;
     }*/
    /* public void BindData()
     {
         rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
         connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

         con = new OdbcConnection(connection);
         con.ConnectionString = connection;

         odbcadabter = new OdbcDataAdapter("SELECT SERIAL_NO, CAND_NAME, EXP_YEAR, ADD_CREDIT, REMARKS FROM RECRUITMENT_DTL WHERE RF_NO = '" + Convert.ToInt32(Text_Num.Text) + "'", connection);

         dataset = new DataSet();
         odbcadabter.Fill(dataset);
         GridView1.DataSource = dataset.Tables[0];
         GridView1.DataBind();

     }*/
    public static string EmpName, EmpEmail, Depart, UserName;
    public string EMPNUMBER, DEPARTMENTNO, EMPNAME, EMPEMAIL, ACTIONDATE, REQUESTNAME, USERNAME;
    public void SendEMail()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        //string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
        //    "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO IN " +
        //    "(SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '17')";

        string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
           "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO IN " +
           "(SELECT SMNG FROM EMP_MNG WHERE MNG = '"+ EMPLOYEE_NO +"')";
        //SELECT SMNG FROM EMP_MNG WHERE SMNG = '" + EMPLOYEE_NO + "'

        string sql2 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO = '"+ EMPLOYEE_NO +"'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);
        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        //cmd2.Connection.Open();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        read2.Read();

        if (read2.HasRows)
        {
            UserName = read["FULL_USER_NAME"].ToString();
        }
        if (read.HasRows)
        {
            EmpName = read["FULL_USER_NAME"].ToString();
            EmpEmail = read["EMAIL"].ToString();
            Depart = read["DEP_NAME"].ToString();
            EMPNAME = EmpName;
            EMPEMAIL = EmpEmail;
        }
        Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Recruitment Request&USERNAMESREQ=" + UserName + "");
        //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=portal@petroneed.com.sd&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Recruitment Request&USERNAMESREQ=" + UserName + "");

        //USERNOTIFICATIONEMAIL(EMPNAME, EMPEMAIL);
        cmd.Connection.Close();
    }
    /*public void E_mails(string Address, string MesBody)
    {
        List<E_mails> E_mails = new List<E_mails>();
        E_mails m = new E_mails(Address, MesBody);
    }*/
    /*  private void USERNOTIFICATIONEMAIL(string _EMPNAME, string _EMPEMAIL)
      {
          EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
          DEPARTMENT_NO = Request.QueryString["DEP_NO"];
          ACTIONDATE = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
          REQUESTNAME = "Recruitment Request";//

          string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
          string sql = "SELECT FULL_USER_NAME FROM USERS_INFORMATIONS WHERE EMPLOYEE_NO = '" + EMPLOYEE_NO + "'";
          OdbcConnection conn = new OdbcConnection(connectionString);
          OdbcCommand cmd = new OdbcCommand(sql, conn);
          cmd.Connection.Open();
          OdbcDataReader read = cmd.ExecuteReader();
          read.Read();

          if (read.HasRows)
          {
              USERNAME = read["FULL_USER_NAME"].ToString();
          }
          //string To = "portal@petroneed.com.sd";// EMPEMAIL;
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
    private void LoadContactControls(int Status)
    {
        if (Status == 0)
            for (int i = 0; i < int.Parse(ViewState[VIEWSTATEKEY].ToString()); i++)
            {
                Session["FormNo"] = "0";
                PlaceHolder1.Controls.Add(LoadControl("~/userControll/Reqruitment.ascx"));
            }
        else
            if (Status == 1)
            {
                for (int i = 0; i < int.Parse(ViewState[VIEWSTATEKEY].ToString()); i++)
                {
                    Session["FormNo"] = Text_Num.Text;
                    PlaceHolder1.Controls.Add(LoadControl("~/userControll/Reqruitment.ascx"));
                }
            }
    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList2.SelectedValue == "1")
        {
            Text_Single_Justific.Enabled = true;
        }
        else
        if (RadioButtonList2.SelectedValue == "2")
        {
            Text_Single_Justific.Enabled = false;
        }
        ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? 1 : ViewState[VIEWSTATEKEY];
        LoadContactControls(0);
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedValue == "2")
        { Text_period.Enabled = true; }
        else
            if (DropDownList2.SelectedValue == "1")
            { Text_period.Enabled = false; }
        ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? 1 : ViewState[VIEWSTATEKEY];
        LoadContactControls(0);
    }
    void UserAuthorization()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];


        string sql = "SELECT MNG FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "'";
        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            MANAGER = read["MNG"].ToString();
        }
        else
        {
            //GridView1.Enabled = false;
            //GridView2.Enabled = false;

            Butt_Submit.Enabled = false;
            Butt_Reset.Enabled = false;
            PlaceHolder1.Visible = false;
            Butt_Add_Details.Enabled = false;

            Label_Messages.Text = "You are not Authorized to See this Contents ...";
            //Response.Redirect("~/UsersArea/DEFAULT.ASPX");
        }
        cmd.Connection.Close();
    }
}
