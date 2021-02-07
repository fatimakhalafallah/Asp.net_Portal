using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;


public partial class UsersArea_SIM_IT : System.Web.UI.Page
{



    public OdbcCommand comm = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter dadapter;
    public OdbcCommand odbccomm = null;
    public OdbcConnection odbccon = null;
    public OdbcDataAdapter odbcdadapter;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;

    //public static string EMPLOYEE_NO, DEPARTMENT_NO, MANAGER, SUPERVISOR;
    public static string EMPLOYEE_NO, FORMNO, EMSM, DEPARTMENT_NO, ICMANAGER, SUPERVISOR, SINMANAGER, MANAGER, checkUser;


    DataSet dset, dset2, dataset;
    string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
    string sql;

    private string sortDirection;
    private int No;

    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        ICMANAGER = Request.QueryString["ICM"];
        MANAGER = Request.QueryString["MNG"];
        EMSM = Request.QueryString["EMS"];


        if (EMPLOYEE_NO == "" || EMPLOYEE_NO == null && DEPARTMENT_NO == "" || DEPARTMENT_NO == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                getMenu();
                GridViewBind();
                Panel1.Visible = false;
                //returnuser();

            }
        }
    }

    public void GridViewBind()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
       

           EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
           DEPARTMENT_NO = Request.QueryString["DEP_NO"];


                dadapter = new OdbcDataAdapter("SELECT ICT_Tele.FORM_NO,ICT_Tele.POSITION,ICT_Tele.FORM_DATE,ICT_Tele.USER_NAME , ICT_Tele.USER_ID ,ICT_Tele.USER_DEP FROM ICT_Tele,EMPLOYEES,DEPARTMENTS WHERE ICT_Tele.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_Tele.FORM_STATUS = '4' AND ICT_Tele.USER_DEP= DEPARTMENTS.DEP_NAME AND ICT_Tele.REQUEST_EXECUTOR= '" + EMPLOYEE_NO + "'", connectionString);
                                                                                                                                                                                                                                                //   ("SELECT ICT_Tele.FORM_NO,ICT_Tele.POSITION,ICT_Tele.FORM_DATE,ICT_Tele.USER_NAME , ICT_Tele.USER_ID ,ICT_Tele.USER_DEP FROM ICT_Tele,EMPLOYEES,DEPARTMENTS WHERE ICT_Tele.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_Tele.FORM_STATUS = '1' AND ICT_Tele.USER_DEP= DEPARTMENTS.DEP_NAME AND ICT_Tele.USER_ID I WHERE MNG = '"+MANAGER+"')", connectionString)

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();
         

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridViewBind();
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new
            GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "LIST OF REQUEST";
            HeaderCell.ColumnSpan = 8;
            HeaderGridRow.Cells.Add(HeaderCell);
            GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }

    public string sortExpression { get; set; }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Label_Message.Text = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.SelectedIndex == i)
            {
              
                 string FORM_NO = GridView1.Rows[i].Cells[0].Text;
                string EMP_NO = GridView1.Rows[i].Cells[1].Text;
                TextBox1.Text = FORM_NO.ToString();
                TextBox2.Text = EMP_NO.ToString();
                detail();
                GridView3.Visible = true;
                GridView2.Visible = true;
                //UserDetails();
                Panel1.Visible = true;
                //returnuser(); 
                //UserList();
                detail(); 




            }
        }
    }

    void detail()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        //string checkUser; 
        //TextBox1.Text; //FORM_NO.ToString();
        //TextBox2.Text; // EMP_NO.ToString();
        string sql = "SELECT ICT_TELE.NEW_USER FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            checkUser = read["NEW_USER"].ToString();

        }
        cmd.Connection.Close();

        if (checkUser == "" || checkUser == null)
        {
            GridView3.Visible = false;
            UserDetails();
        }
        else
        {
            GridView2.Visible = false;
            UserDetail2();

        }


    }
    void UserDetails()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

        odbccon = new OdbcConnection(connection);
        odbccon.ConnectionString = connection;


        //odbcdadapter = new OdbcDataAdapter("SELECT ICT_EDETAIL.REQ_NO ,ICT_EDETAIL.FORM_NO ,ICT_EDETAIL.EQ_NAME, ICT_EDETAIL.QUANTITY,ICT_EDETAIL.DESCRIPTION  FROM ICT_EDETAIL WHERE ICT_EDETAIL.FORM_NO ='" + TextBox1.Text + "'", connection);
        odbcdadapter = new OdbcDataAdapter("SELECT ICT_TELE.FORM_NO,ICT_TELE.USER_SIM_NU,ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,ICT_TELE.SIM_TYPE,ICT_TELE.SIM_CEIL  FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'", connection);
       
        dataset = new DataSet();
        odbcdadapter.Fill(dataset);
        GridView2.DataSource = dataset.Tables[0];
        GridView2.DataBind();
        Comments_Field();


    }

    void UserDetail2()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

        odbccon = new OdbcConnection(connection);
        odbccon.ConnectionString = connection;

        odbcdadapter = new OdbcDataAdapter("SELECT ICT_TELE.FORM_NO ,ICT_TELE.NEW_USER ,ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,ICT_TELE.SIM_TYPE,ICT_TELE.SIM_CEIL  FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'", connection);
        // ,, ICT_TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION
        dataset = new DataSet();
        odbcdadapter.Fill(dataset);
        GridView3.DataSource = dataset.Tables[0];
        GridView3.DataBind();
        Comments_Field();
        //UserList();


    }

    void Comments_Field()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        string sql = "SELECT ICT_COMMENT FROM ICT_TELE WHERE FORM_STATUS='4' AND FORM_NO= '" + TextBox1.Text + "'";
        //string sql = "SELECT NVL(MAX(TRF_NO),0)+1 FROM TRAVEL_MSTR";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            TextBox5.Text = read[0].ToString();
        }
        cmd.Connection.Close();

    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        this.UserDetails();
        // GridView2.DataBind();
    }


    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        this.UserDetails();
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

    public virtual bool AllowPaging { get; set; }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        //SendEMail();
        UpdateFormStatus();
        Panel1.Visible = false;
        Reset();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);


    }
    private void UpdateFormStatus()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql, date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
      

        if (TextBox1.Text != "")
        {
 
                sql = "UPDATE ICT_TELE SET FORM_STATUS = '7' WHERE FORM_NO = '" + TextBox1.Text + "'";
             

                con = new OdbcConnection(connection);
                con.ConnectionString = connection;
                con.Open();

                comm = new OdbcCommand(sql, con);
                comm.ExecuteNonQuery();
                con.Close();

                Label_Message.Text = "Successfully...";
           
                //SendEMail(Status, 1);
                //dropsend(); 
            }
          
        else
        {
            Reset();
            Panel1.Visible = false;
        }
    }



    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset();
        Panel1.Visible = false;
    }
    private void Reset()
    {

        TextBox1.Text = "";
        TextBox2.Text = "";
    }

    public static string EmpName, EmpEmail, Depart, EmpName2;
    public string EMPNUMBER, DEPARTMENTNO, EMPNAME, EMPEMAIL, ACTIONDATE, REQUESTNAME, USERNAMEm;
    public void SendEMail()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");


       // string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            //"FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO='9493";
        string sql2 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + TextBox2.Text + "'";


        OdbcConnection conn = new OdbcConnection(connectionString);
        //OdbcCommand cmd = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        cmd2.Connection.Open();
        //OdbcDataReader read = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();

        //read.Read();
        read2.Read();
        /*if (read.HasRows)
        {
            EmpName = read["FULL_USER_NAME"].ToString();
            EmpEmail = read["EMAIL"].ToString();
            Depart = read["DEP_NAME"].ToString();
            EMPNAME = EmpName;
            EMPEMAIL = EmpEmail;
        }*/
        if (read2.HasRows)
        {
            EmpName2 = read2["FULL_USER_NAME"].ToString();
            // EmpEmail2=read2["EMAIL"].ToString();
        }


        Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME= SIM Request (SR)&USERNAMESREQ=" + EmpName2 + "");


        cmd2.Connection.Close();
    }

 
    protected void Button1_Click(object sender, EventArgs e)
    {
        ExportGridToPDF(); 
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        
    }
    private void ExportGridToPDF()
    {

        if (GridView3.Visible==false)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=SIM_RequestForm.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView2.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            GridView2.AllowPaging = true;
            GridView2.DataBind();
        }
        else
        {

            if (GridView2.Visible == false)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=SIM_RequestForm.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView3.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();
                GridView3.AllowPaging = true;
                GridView3.DataBind();

            }
        }





    }  

}