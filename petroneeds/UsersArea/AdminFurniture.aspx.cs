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

public partial class UsersArea_AdminFurniture : System.Web.UI.Page
{

    public OdbcCommand odbccomm = null;
    public OdbcConnection odbccon = null;
    public OdbcDataAdapter odbcdadapter;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand sqlcommand = null;
    public SqlConnection sqlconn = null;
    public SqlCommand command = null;
    public SqlConnection conn = null;

    public static string EMPLOYEE_NO, DEPARTMENT_NO, MANAGER, HRMANAGER, SUPERVISOR, STATIONERYAPP;
    public static string EmpName, EmpEmail, Depart, Status, EmpName2, EmpEmail2, EmpName3, EmpEmail3, EmpName4, EmpEmail4;

    DataSet dataset;
    string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
    string sql;

    private string sortDirection;
    private int No;

    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        MANAGER = Request.QueryString["MNG"];
        STATIONERYAPP = Request.QueryString["STATIONERYAPP"];

        if (EMPLOYEE_NO == "" || EMPLOYEE_NO == null && DEPARTMENT_NO == "" || DEPARTMENT_NO == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
                DEPARTMENT_NO = Request.QueryString["DEP_NO"];
                HRMANAGER = Request.QueryString["MNG"];

                Reset();
                getMenu();
                GridViewBind();
                Panel1.Visible = false;
            }
        }
    }
    public void GridViewBind()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        MANAGER = Request.QueryString["MNG"];
        STATIONERYAPP = Request.QueryString["STATIONERYAPP"];

        if (STATIONERYAPP == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO)
        {
            No = 1;
        }
        if (MANAGER == EMPLOYEE_NO & STATIONERYAPP != EMPLOYEE_NO)
        {
            No = 2;
        }


        switch (No)
        {
            case 1:

                //odbcdadapter = new OdbcDataAdapter("SELECT STOCK_REQUEST.ORDER_NO, STOCK_REQUEST.CREATED_ID ,STOCK_REQUEST.CREATED_USER, STOCK_REQUEST.ORDER_DATE, DEPARTMENTS.DEP_NAME,EMPLOYEES.EMPLOYEE_NAME FROM STOCK_REQUEST, DEPARTMENTS, EMPLOYEES ,REQUEST_ACTORS WHERE EMPLOYEES.EMPLOYEE_NO = STOCK_REQUEST.CREATED_ID AND DEPARTMENTS.DEP_NO = STOCK_REQUEST.DEP_NO AND STOCK_REQUEST.STATUS = '9' AND REQUEST_ACTORS.REQUEST_TYPE_ID = '19' AND REQUEST_ACTORS.EMPLOYEE_NO= '" + STATIONERYAPP + "'", connectionString); 
                odbcdadapter = new OdbcDataAdapter("SELECT STOCK_REQUEST.ORDER_NO, STOCK_REQUEST.CREATED_ID ,STOCK_REQUEST.CREATED_USER, STOCK_REQUEST.ORDER_DATE, DEPARTMENTS.DEP_NAME,EMPLOYEES.EMPLOYEE_NAME FROM STOCK_REQUEST, DEPARTMENTS, EMPLOYEES ,REQUEST_ACTORS WHERE EMPLOYEES.EMPLOYEE_NO = STOCK_REQUEST.CREATED_ID AND DEPARTMENTS.DEP_NO = STOCK_REQUEST.DEP_NO AND (STOCK_REQUEST.STATUS = '9' OR (STOCK_REQUEST.CREATED_ID IN(SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG='" + STATIONERYAPP + "') AND STOCK_REQUEST.STATUS = '8' )) AND REQUEST_ACTORS.REQUEST_TYPE_ID = '19' AND REQUEST_ACTORS.EMPLOYEE_NO= '" + STATIONERYAPP + "'", connectionString);

                dataset = new DataSet();
                odbcdadapter.Fill(dataset);
                GridView1.DataSource = dataset.Tables[0];
                GridView1.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "11"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "12"));
                break;


            case 2:
                odbcdadapter = new OdbcDataAdapter("SELECT STOCK_REQUEST.ORDER_NO, STOCK_REQUEST.CREATED_ID ,STOCK_REQUEST.CREATED_USER, STOCK_REQUEST.ORDER_DATE, DEPARTMENTS.DEP_NAME," +
                     " EMPLOYEES.EMPLOYEE_NAME FROM STOCK_REQUEST, DEPARTMENTS, EMPLOYEES" +
                     " WHERE EMPLOYEES.EMPLOYEE_NO = STOCK_REQUEST.CREATED_ID AND DEPARTMENTS.DEP_NO = STOCK_REQUEST.DEP_NO AND STOCK_REQUEST.STATUS = '8' AND  " +
                     " STOCK_REQUEST.CREATED_ID IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG = '" + MANAGER + "')", connectionString);

                dataset = new DataSet();
                odbcdadapter.Fill(dataset);
                GridView1.DataSource = dataset.Tables[0];
                GridView1.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "9"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "10"));
                break;


            default:
                Label_Message.Text = "There are no Requests...";
                //Label_Message.Text = "You aren't Authorized to see this page ...";
                break;
        }
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
            HeaderCell.Text = "Admin Area: Stationary Rquests List";
            HeaderCell.ColumnSpan = 8;
            HeaderGridRow.Cells.Add(HeaderCell);
            GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }
    public string sortExpression { get; set; }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label_Message.Text = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.SelectedIndex == i)
            {
                string FORM_NO = GridView1.Rows[i].Cells[0].Text;
                TextBox1.Text = FORM_NO.ToString();
                TextBox2.Text = GridView1.Rows[i].Cells[1].Text;
                RequestDetails();
                //RadioButtonList1.Visible = true;
                Panel1.Visible = true;
            }
        }
    }
    public void RequestDetails()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

        odbccon = new OdbcConnection(connection);
        odbccon.ConnectionString = connection;


        odbcdadapter = new OdbcDataAdapter("SELECT STOCK_REQUEST_DETAILS.ORDER_NO, STOCK_REQUEST_DETAILS.REQ_NO, STOCK_REQUEST_DETAILS.GROUP_NO,STOCK_REQUEST_DETAILS.ITEM_NO,STOCK_REQUEST_DETAILS.QTY_ORDERED,STOCK_REQUEST_DETAILS.DESCRIPTION FROM STOCK_REQUEST_DETAILS WHERE STOCK_REQUEST_DETAILS.ORDER_NO = '" + TextBox1.Text + "'", connection);


        //ORDER_NO, REQ_NO, GROUP_NO, ITEM_NO, QTY_ORDERED, DESCRIPTION

        dataset = new DataSet();
        odbcdadapter.Fill(dataset);
        GridView2.DataSource = dataset.Tables[0];
        GridView2.DataBind();
        S_comment(); 

    }

    void S_comment()
    {

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        MANAGER = Request.QueryString["MNG"];
        STATIONERYAPP = Request.QueryString["STATIONERYAPP"];


        if (STATIONERYAPP == EMPLOYEE_NO)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
            EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
            DEPARTMENT_NO = Request.QueryString["DEP_NO"];
            sql = "SELECT STOCK_REQUEST.MNG_COMMENT FROM STOCK_REQUEST WHERE STOCK_REQUEST.ORDER_NO='" + TextBox1.Text + "'";


            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand(sql, conn);

            cmd.Connection.Open();
            OdbcDataReader read = cmd.ExecuteReader();
            read.Read();
            if (read.HasRows)
            {
                TextBox4.Text = read["MNG_COMMENT"].ToString();

                TextBox4.Visible = true;
                Label7.Visible = true;


            }
            cmd.Connection.Close();
        }
    }


    protected void  RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Status = RadioButtonList1.SelectedItem.ToString();
        //Label_Message0.Text = RadioButtonList1.SelectedValue.ToString();
    }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        UpdateFormStatus();
        Status = RadioButtonList1.SelectedItem.Text.ToString();
        SendEMail(Status);
        Reset();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
        Panel1.Visible = false;
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset();
        Panel1.Visible = false;
    }


    private void UpdateFormStatus()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql, date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        MANAGER = Request.QueryString["MNG"];
        STATIONERYAPP = Request.QueryString["STATIONERYAPP"];

        if (TextBox1.Text != "")
        {

          //  if (STATIONERYAPP == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO)
          //  {
          //      No = 1;
          //  }
          //  if (MANAGER == EMPLOYEE_NO & STATIONERYAPP != EMPLOYEE_NO)
            if (STATIONERYAPP == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO)
                {
                    //// ", IMNG_ID = '" + ICMANAGER + "', IMNG_DATE = '" + date + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                    sql = "UPDATE STOCK_REQUEST SET  ADMIN_ID='" + STATIONERYAPP + "' , STATUS = '" + RadioButtonList1.SelectedValue + "', ADMIN_COMMENT='" + TextBox3.Text + "' WHERE ORDER_NO = '" + TextBox1.Text + "'";
                    odbccon = new OdbcConnection(connection);
                    odbccon.ConnectionString = connection;
                    odbccon.Open();

                    odbccomm = new OdbcCommand(sql, odbccon);
                    odbccomm.ExecuteNonQuery();
                    odbccon.Close();
                }
           
            else
               if (MANAGER == EMPLOYEE_NO & STATIONERYAPP != EMPLOYEE_NO)
                 {
                     // sql = "UPDATE ICT_NEW_ACCOUNT SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "',REQUEST_EXECUTOR='" + DropDownList1.SelectedValue + "', IMNG_COMMENT = '" + TextBox5.Text + "' " +
                     //  ", IMNG_ID = '" + ICMANAGER + "', IMNG_DATE = '" + date + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                     sql = "UPDATE STOCK_REQUEST SET STATUS = '" + RadioButtonList1.SelectedValue + "' " +
                     ",MNG_ID = '" + MANAGER + "', MNG_DATE = '" + date + "' ,MNG_COMMENT='" + TextBox3.Text + "' WHERE ORDER_NO = '" + TextBox1.Text + "'";
                     // MNG_ID, MNG_DATE, MNG_COMMENT
                     odbccon = new OdbcConnection(connection);
                     odbccon.ConnectionString = connection;
                     odbccon.Open();

                     odbccomm = new OdbcCommand(sql, odbccon);
                     odbccomm.ExecuteNonQuery();
                     odbccon.Close();

                 }
               

        }
        else
        {
            Reset();
            Panel1.Visible = false;
        }
    }
    private void Reset()
    {
        TextBox1.Text = "";
        //RadioButtonList1.Items.Clear();
    }
    public void SendEMail(string Status)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        STATIONERYAPP = Request.QueryString["STATIONERYAPP"];
        MANAGER = Request.QueryString["MNG"];

        //string EmpName4, EmpEmail4; 
        string date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
        string ta = "9633"; 

        // REQUETER
        string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO = '" + TextBox2.Text + "'"; 
        // APPROVAL (MNG)
        string sql2 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO = '" + MANAGER + "'";
        // APPROVAL (STATIONER ADMIN APPROVAL)
        string sql3 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO = '" + STATIONERYAPP + "'";
        string sql4 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
          "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO = '" + ta + "'"; 


        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);
        OdbcCommand cmd4 = new OdbcCommand(sql4, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        OdbcDataReader read3 = cmd3.ExecuteReader();
        OdbcDataReader read4 = cmd4.ExecuteReader();

        read.Read();
        read2.Read();
        read4.Read(); 

        if (read.HasRows)
        {
            EmpName  = read["FULL_USER_NAME"].ToString();
            EmpEmail = read["EMAIL"].ToString();
            Depart   = read["DEP_NAME"].ToString();
        }
        if (read2.HasRows)
        {
            EmpName2  = read2["FULL_USER_NAME"].ToString();
            EmpEmail2 = read2["EMAIL"].ToString();
        }
        if (read3.HasRows)
        {
            EmpName3  = read3["FULL_USER_NAME"].ToString();
            EmpEmail3 = read3["EMAIL"].ToString();
        }
        if (read4.HasRows)
        {
            EmpName4 = read4["FULL_USER_NAME"].ToString();
            EmpEmail4 = read4["EMAIL"].ToString();
        }

      

        if (STATIONERYAPP == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO)
        {
            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
              "&ApprovalName=" + EmpName4 + "&ApprovalEmail=" + EmpEmail4 + "&REQNAME=Furniture Request(FR)&AUTHORNAME=" + EmpName3 + "");

        }

        if (MANAGER == EMPLOYEE_NO & STATIONERYAPP != EMPLOYEE_NO)
        {
            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
              "&ApprovalName=" + EmpName3 + "&ApprovalEmail=" + EmpEmail3 + "&REQNAME=Furniture Request(FR)&AUTHORNAME=" + EmpName2 + "");
        }
        
        cmd.Connection.Close();
    }
}
