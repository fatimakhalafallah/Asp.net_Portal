using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing.Design;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data;
using AjaxControlToolkit;

public partial class UsersArea_TravelMigration : System.Web.UI.Page
{
    int Number = 0;
    private const string VIEWSTATEKEY = "ContactCount";

    public OdbcCommand comm = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter dadapter = null;
    public DataSet dset = null;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;

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
                Text_Date.Text = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
                getMenu();
                CheckAccount();
                UserData();
                ServiceType();
                ContractorData();
                TravelLocation();
                ContractorSection();
                //Label_Messages.Text = "";
                if (!Page.IsPostBack)
                {
                    int x = CheckBoxList1.Items.Count;
                    ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? x : ViewState[VIEWSTATEKEY];
                    LoadContactControls();
                }
            }
        }
    }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        if (Text_Remarks.Text.Length < 500)
        {
            Insert();
            SendEMail(Status);
            
            Response.Redirect("~/UsersArea/servicesSendRequest.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + "");
            Label_Messages.Text = "Thank You Mr,Mrs/ " + Text_Name.Text + " Your Record Saved";

            LoadContactControls();
            Reset();
            CheckAccount();
        }
        else
        {
            Label_Charactor.Visible = true;
        }
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset();
        //OnInit(e);
    }
    public void UserData()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

       string sql = "SELECT USERS_INFORMATIONS.FULL_USER_NAME, USERS_INFORMATIONS.EMAIL, DEPARTMENTS.DEP_NAME FROM USERS_INFORMATIONS INNER JOIN DEPARTMENTS ON (USERS_INFORMATIONS.DEP_NO = DEPARTMENTS.DEP_NO) AND USERS_INFORMATIONS.DEP_NO = '" + int.Parse(DEPARTMENT_NO) + "' WHERE USERS_INFORMATIONS.EMPLOYEE_NO = '" + Int32.Parse(EMPLOYEE_NO) + "'";


        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_Name.Text = read["FULL_USER_NAME"].ToString();
            Text_Department.Text = read["DEP_NAME"].ToString();
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
        cmd.Connection.Close();
    }
    public void ContractorData()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string sql = "SELECT EMPLOYEE_NAME, EMPLOYEE_NO FROM EMPLOYEES WHERE EMPLOYEE_STATUS = 1";

        dadapter = new OdbcDataAdapter(sql, connectionString);
        dset = new DataSet();
        dadapter.Fill(dset);
        DropDownList1.DataSource = dset.Tables[0];
        DropDownList1.DataTextField = "EMPLOYEE_NAME";
        DropDownList1.DataValueField = "EMPLOYEE_NO";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("<<<Select>>>", "0"));
        DropDownList1.SelectedIndex = 0;
        DropDownList1.SelectedValue = "0";
        DropDownList1.SelectedItem.Value = "0";
    }
    public void ServiceType()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string sql = "SELECT SER_NO, SER_NAME FROM TRAVEL_SERVICES_TYPE";

        dadapter = new OdbcDataAdapter(sql, connectionString);
        dset = new DataSet();
        dadapter.Fill(dset);
        CheckBoxList1.DataSource = dset.Tables[0];
        CheckBoxList1.DataTextField = "SER_NAME";
        CheckBoxList1.DataValueField = "SER_NO";
        CheckBoxList1.DataBind();
        }
    public void TravelLocation()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string sql = "SELECT LOC_NO, LOC_NAME FROM FLT_LOCATION";

        dadapter = new OdbcDataAdapter(sql, connectionString);
        dset = new DataSet();
        dadapter.Fill(dset);
        DropDownList2.DataSource = dset.Tables[0];
        DropDownList2.DataTextField = "LOC_NAME";
        DropDownList2.DataValueField = "LOC_NO";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("<<<Select>>>", "0"));
        DropDownList2.SelectedIndex = 0;
        DropDownList2.SelectedValue = "0";
        DropDownList2.SelectedItem.Value = "0";
    }
    public void ContractorSection()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        //string sql = "SELECT EMPLOYEES.EMPLOYEE_NO, EMPLOYEES.EMPLOYEE_NAME, DEPARTMENTS.DEP_NAME,"+
        //    "LKP_JOBS.JOB_NAME, PROJECT_CODE.PROJ_NAME "+
        //    "FROM  LKP_JOBS, PROJECT_CODE, EMPLOYEES INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO) WHERE "+
        //    "EMPLOYEES.EMPLOYEE_NO = '"+ DropDownList1.SelectedValue +"' AND EMPLOYEES.JOB_NO = LKP_JOBS.JOB_NO AND EMPLOYEES.SECTION_NO = PROJECT_CODE.PROJ_NO AND "+
        //    "EMPLOYEES.EMPLOYEE_STATUS = 1";

        string sql = "SELECT EMPLOYEES.EMPLOYEE_NO, EMPLOYEES.EMPLOYEE_NAME, DEPARTMENTS.DEP_NAME," +
             "LKP_JOBS.JOB_NAME, PROJECT_CODE.PROJ_NAME " +
             "FROM  LKP_JOBS, PROJECT_CODE, EMPLOYEES INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO) WHERE " +
             "EMPLOYEES.EMPLOYEE_NO = '" + EMPLOYEE_NO + "' AND EMPLOYEES.JOB_NO = LKP_JOBS.JOB_NO AND EMPLOYEES.SECTION_NO = PROJECT_CODE.PROJ_NO AND " +
             "EMPLOYEES.EMPLOYEE_STATUS = 1";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_SectionName.Text = read["PROJ_NAME"].ToString();
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
        cmd.Connection.Close();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ContractorSection();
    }  
    public void Insert()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        CheckAccount();

        sql = "INSERT INTO TRAVEL_SERVICES_MST " +
       "(TS_NO, TS_DATE, DEP_NO, SEC_NO, CREATED_USER, CREATED_DATE, REMARKS, MNGR_ID, MNGR_DATE, MNGR_TXT, STATUS, LOC_NO, PASSEN_NAME, FILE_NAME)  VALUES" +


        "('" + Text_Num.Text + "', '" + Text_Date.Text + "', '" + DEPARTMENT_NO + "', '4', '" + EMPLOYEE_NO + "', '" + Text_Date.Text + "'," +
        "'" + Text_Remarks.Text + "', '', '', '', '3', '" + DropDownList2.SelectedValue + "', '" + Text_ContractorName.Text + "', '" + Label_UplodeName.Text + "')";
        //0
        con = new OdbcConnection(connection);
        con.ConnectionString = connection;
        con.Open();

        comm = new OdbcCommand(sql, con);
        comm.ExecuteNonQuery();
        //Reset();
        //Label_Messages.Text = "Thank You Mr,Mrs/ " + Text_Name.Text + " Your Record Saved";
    }
    protected void DropDownList2_SelectedIndexChanged1(object sender, EventArgs e)
    {
        int x = CheckBoxList1.Items.Count;
        ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? x : ViewState[VIEWSTATEKEY];
        LoadContactControls();
    }
    private void Reset()
        {
                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                    {
                        CheckBoxList1.Items[i].Selected = false;
                    }

                Label_Messages.Text = "";
                Label_UplodeName.Text = "";
                DropDownList1.SelectedIndex = 0;
                DropDownList2.SelectedIndex = 0;
                Text_SectionName.Text = "";
                Text_ContractorName.Text = "";
                Text_Remarks.Text = "";
                Label_Charactor.Visible = false;
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    public void CheckAccount()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
            //string sql = "SELECT MAX(TS_NO)+1 FROM TRAVEL_SERVICES_MST";
            string sql = "SELECT NVL(MAX(TS_NO),0)+1 FROM TRAVEL_SERVICES_MST";
            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand(sql, conn);

            cmd.Connection.Open();
            OdbcDataReader read = cmd.ExecuteReader();
            read.Read();

            if (read.HasRows)
            {
                Text_Num.Text = read[0].ToString();
            }
            //else
            //{
            //    //Text_Num.Text = "1";
            //}
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
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int x = CheckBoxList1.Items.Count;
        ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? x : ViewState[VIEWSTATEKEY];
        LoadContactControls();
    }
    private void LoadContactControls()
    {
        int i = 0;
        int x = CheckBoxList1.Items.Count;

        if (x == -1)
        {
        for (i = 0; i < int.Parse(ViewState[VIEWSTATEKEY].ToString()); i++)
        {
           PlaceHolder1.Controls.Add(LoadControl("~/userControll/ServicesRequested.ascx"));
        }
        }
        else
        {
            string[] ServicesNo = new string[x];
            for (i = 0; i < int.Parse(ViewState[VIEWSTATEKEY].ToString()); i++)
            {
                ServicesNo[i] = CheckBoxList1.Items[i].Value;
                Session["ServicesNo"] = ServicesNo[i];
                Session["FormNo"] = Text_Num.Text;
                PlaceHolder1.Controls.Add(LoadControl("~/userControll/ServicesRequested.ascx"));
            }
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
        }
        Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Accommodation, Travel & Migration Servies Request&USERNAMESREQ=" + Text_Name.Text + "");
        
        //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=portal@petroneed.com.sd&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Leave Request Information&USERNAMESREQ=" + Text_Name.Text + "");
        //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Leave Request Information&USERNAMESREQ=" + Text_Name.Text + "");
        cmd.Connection.Close();
    }
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        int x = CheckBoxList1.Items.Count;
        ViewState[VIEWSTATEKEY] = ViewState[VIEWSTATEKEY] == null ? x : ViewState[VIEWSTATEKEY];
        LoadContactControls();

        Label_Uplode.Text = ProcessUploadedFile();
    }
    private string ProcessUploadedFile()
    {
        if (!FileUploader.HasFile)
            return "You must select a valid file to upload.";

        if (FileUploader.FileContent.Length == 0)
            return "You must select a non empty file to upload.";

        //As the input is external, always do case-insensitive comparison unless you actually care about the case.
       // if (FileUploader.PostedFile.ContentType == "application/pdf")
        if (!FileUploader.FileName.EndsWith("pdf")) 
            return "Only files of type PDF is supported. Uploaded File Type: " + FileUploader.PostedFile.ContentType;

        //rest of the code to actually process file.
        if (FileUploader.PostedFile.ContentLength > 0 && FileUploader.FileName.EndsWith("pdf"))
        //if (FileUploader.PostedFile.ContentType == ".PDF" || FileUploader.PostedFile.ContentType == ".pdf")
        {
            try
            {
                FileUploader.SaveAs(Server.MapPath("../Documents//") +
                FileUploader.FileName);

                Label_UplodeName.Text = "~/Documents/" + FileUploader.PostedFile.FileName;

                return"File name: " +  FileUploader.PostedFile.FileName + "<br>" +
                    "File size: " + FileUploader.PostedFile.ContentLength + " kb<br><br><b>Uploaded Successfully</b>";                
                //Label2.Text = "~/Documents/" + FileUploader.PostedFile.FileName;
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message.ToString();
            }
        }
        return "Erorr...";
    }
}