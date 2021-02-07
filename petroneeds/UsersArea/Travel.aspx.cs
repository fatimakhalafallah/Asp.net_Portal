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


public partial class Travel: System.Web.UI.Page
{
    private const string VIEWSTATEKEY2 = "TravelDescribtion";

    public OdbcCommand comm, comm_mas = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter odbcadabter = null;
    public OdbcDataAdapter dadapter;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;

    public string EMPLOYEE_NO, DEPARTMENT_NO;
    //public static string EmpName, EmpEmail, Depart, Status = "Send";

    public static int x = 0;

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
              

                //CompDepartments();
                CheckAccount();
                if (!Page.IsPostBack)
                {
                    ViewState[VIEWSTATEKEY2] = ViewState[VIEWSTATEKEY2] == null ? 2 : ViewState[VIEWSTATEKEY2];
                    LoadContactControls(0);
                }
            }
            else
            { 
             
            }
        }
    }



    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        InsertMaster();
        LoadContactControls(1);
        SendEMail();

        Response.Redirect("~/UsersArea/servicesSendRequest.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + "");

        Reset();
        Label_Messages.Text = "Thank You Mr,MS " + Text_Name.Text + " Your Record Saved";

        ViewState[VIEWSTATEKEY2] = ViewState[VIEWSTATEKEY2] == null ? 1 : ViewState[VIEWSTATEKEY2];
        LoadContactControls(0);
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset();
        UserData();
        ViewState[VIEWSTATEKEY2] = ViewState[VIEWSTATEKEY2] == null ? 1 : ViewState[VIEWSTATEKEY2];
        LoadContactControls(0);
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
    private void Reset()
    {
        //AirLine();

        //Text_NumDeta.Text = "";
        //Text_from_Loca.Text = "";
        //Text_from_Date.Text = "";
        //Text_To_Loca.Text = "";
        //Text_To_Date.Text = "";
        //Text_Class.Text = "";
        //Text_Remarks.Text = "";
        Text_Specify.Text = "";
        Label_Messages.Text = "";
        Text_Name.Text = "";
        Text_Position.Text = "";
    }
    private void InsertMaster()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql_mas;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        CheckAccount();
        sql_mas = "INSERT INTO TRAVEL_MSTR" +
                  "(TRF_NO, EMPLOYEE_NO, DEP_NO, FORM_DATE, PURPOSE, PURPOSE_DESC, COMMENTS, " +
                  "MNG_COMMENT, ADDRESS_ABROAD, ACCOMODATION_COST, PERDIEM, VISA_FEES, TICKET_COST, OTHERS_AMNT," +
                  "CURR_NO, COST_CENTER, HR_COMMENT, FINANCE_COMMENT, MNG_ID, MNG_DATE, HR_ID, " +
                  "HR_DATE, FIN_ID, FIN_DATE, FORM_STATUS, TRAVELER_NAME, TRAVELER_POSITION) VALUES" +

                  "('" + Text_Num.Text + "', '" + Text_Id.Text + "', '" + DEPARTMENT_NO + "', '" + Text_Date.Text + "', '" + RadioButtonList1.SelectedValue + "', '" + Text_Specify.Text + "', ''," +
                  "'', '', '', '', '', '', ''," +
                  "'', '', '', '', '', '', '', " +
                  "'', '', '', '1', '" + Text_Name.Text + "', '" + Text_Position.Text + "')";
                              //0
        con = new OdbcConnection(connection);
        con.ConnectionString = connection;
        con.Open();

        comm_mas = new OdbcCommand(sql_mas, con);
        comm_mas.ExecuteNonQuery();
     
        con.Close();
    }
    /*private void InsertDetails()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

       
        sql = "INSERT INTO TRAVEL_DTL " +
       "(TRF_NO, SERIAL_NO, TRANS_DATE, CITY_FROM, FROM_DATE, CITY_TO, TO_DATE, AIR_LINE_NO, " +
       " FLIHT_CODE, CLASS, REMARKS)  VALUES" +

        "('" + Text_Num.Text + "', '" + Text_NumDeta.Text + "' , '" + Text_Date.Text + "' , '" + Text_from_Loca.Text + "', '" + Text_from_Date.Text + "', '" + Text_To_Loca.Text + "', '" + Text_To_Date.Text + "', '" + DropDownList1.SelectedValue + "' " +
        ",'', '" + Text_Class.Text + "', '" + Text_Remarks.Text + "')";


        con = new OdbcConnection(connection);
        con.ConnectionString = connection;
        con.Open();

        comm = new OdbcCommand(sql, con);
        comm.ExecuteNonQuery();
        con.Close();

        //Reset();
        Label_Messages.Text = "Thank You Mr,MS " + Text_Name.Text + " Your Record Saved";
        CheckAccountDetails();
    }*/
    //private void Number_Account()
    //{
    //    rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
    //    connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
    //    string sql;
    //}
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
        //string sql = "SELECT MAX(TRF_NO)+1 FROM TRAVEL_MSTR";
        string sql = "SELECT NVL(MAX(TRF_NO),0)+1 FROM TRAVEL_MSTR";
      
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
    /*  public void CheckAccountDetails()
      {
          string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
          //string sql = "SELECT MAX(TRF_NO)+1 FROM TRAVEL_MSTR";
          string sql = "SELECT NVL(MAX(SERIAL_NO),0)+1 FROM TRAVEL_DTL WHERE TRF_NO = '"+ Text_Num.Text +"'";

          OdbcConnection conn = new OdbcConnection(connectionString);
          OdbcCommand cmd = new OdbcCommand(sql, conn);

          cmd.Connection.Open();
          OdbcDataReader read = cmd.ExecuteReader();
          read.Read();

          if (read.HasRows)
          {
              Text_NumDeta.Text = read[0].ToString();
          }
          cmd.Connection.Close();
      }*/
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
    /* private void AirLine()
     {
         DataSet dset;
         string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
         string sql = "SELECT AIR_LINE_NAME, AIR_LINE_NO FROM AIR_LINERS";


         odbcadabter = new OdbcDataAdapter(sql, connectionString);
         dset = new DataSet();
         odbcadabter.Fill(dset);
         DropDownList1.DataSource = dset.Tables[0];
         DropDownList1.DataTextField = "AIR_LINE_NAME";
         DropDownList1.DataValueField = "AIR_LINE_NO";
         DropDownList1.DataBind();
     }*/
    protected void Butt_Add_Description_Click(object sender, EventArgs e)
    {   
        //InsertMaster();
        
        //SendEMail();

        //CheckAccountDetails();

        //Butt_Add_Description.Enabled = true;
        //Butt_Add_New.Visible = false;

        ViewState[VIEWSTATEKEY2] = int.Parse(ViewState[VIEWSTATEKEY2].ToString()) + 1;
        LoadContactControls(0);
    }
    protected void Butt_Add_New_Click(object sender, EventArgs e)
    {
        Reset();
        UserData();
        CheckAccount();
        //CheckAccountDetails();
    }



    protected void Butt_Close_Click(object sender, EventArgs e)
    {
        //SendEMail(Status);
        Reset();
        //Panel1.Visible = false;
        Butt_Add_Description.Enabled = false;
    }
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
        Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Travel Request (TRF)&USERNAMESREQ=" + Text_Name.Text + "");
        //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=portal@petroneeds.co&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Travel Request (TRF)&USERNAMESREQ=" + Text_Name.Text + "");
       
        cmd.Connection.Close();
    }
    /*  public void E_mails(string Address, string MesBody)
    {
        List<E_mails> E_mails = new List<E_mails>();
        E_mails m = new E_mails(Address, MesBody);
    }*/
    /*private void USERNOTIFICATIONEMAIL(string _EMPNAME, string _EMPEMAIL)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        ACTIONDATE = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
        REQUESTNAME = "Travel Request";//
        USERNAME = Text_Name.Text;//

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
        string[] DetailsNo = new string[x];
        if (Status == 0)
        for (int i = 0; i < int.Parse(ViewState[VIEWSTATEKEY2].ToString()); i++)
        {
            Session["FormNo"] = "0";
            Session["FormDate"] = "0";
            Session["DetailsNo"] = "0";
            PlaceHolder1.Controls.Add(LoadControl("~/userControll/TravelDescription.ascx"));
        }
        else
            if (Status == 1)
            {
                for (int i = 0; i < int.Parse(ViewState[VIEWSTATEKEY2].ToString()); i++)
                {
                    x ++;
                    Session["FormNo"] = Text_Num.Text;
                    Session["FormDate"] = Text_Date.Text;
                    //Session["DetailsNo"] = DetailsNo[x];
                    PlaceHolder1.Controls.Add(LoadControl("~/userControll/TravelDescription.ascx"));
                }
            }
    }



    
    /* private void CompDepartments()
     {
         DataSet dset;
         string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
         string sql = "SELECT DEP_NAME, DEP_NO FROM DEPARTMENTS";

         dadapter = new OdbcDataAdapter(sql, connectionString);
         dset = new DataSet();
         dadapter.Fill(dset);
         DropDownList1.DataSource = dset.Tables[0];
         DropDownList1.DataTextField = "DEP_NAME";
         DropDownList1.DataValueField = "DEP_NO";
         DropDownList1.DataBind();
         DropDownList1.Items.Insert(0, new ListItem("<<<Select>>>", "0"));
         DropDownList1.SelectedIndex = 0;
         DropDownList1.SelectedValue = "0";
         DropDownList1.SelectedItem.Value = "0";
     }*/
   /* public void SendEMail(string Status)
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
        }
        //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&DATE=" + date + "");
        Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=portal@petroneed.com.sd&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Travel Request (TRF)&USERNAMESREQ=" + Text_Name.Text + "");
        cmd.Connection.Close();
    }*/
    

    protected void Button1_Click1(object sender, EventArgs e)
    {

        Response.Redirect("~/UsersArea/TRY2.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + "");
          
        }


} 

    
    
