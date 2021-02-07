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

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class UsersArea_UserPayrolls : System.Web.UI.Page
{
    public OdbcConnection odbcconn = null;
    public OdbcCommand odbccmd = null;
    public OdbcDataReader odbcread = null;

    public SqlCommand Sqlcomm = null;
    public SqlConnection Sqlcon = null;
    public SqlCommand comm = null;
    public SqlConnection con = null;

    DataSet dset;

    public string EMPLOYEE_NO, DEPARTMENT_NO;
    public OdbcDataAdapter odbcdadapter;
    
    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

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
                UserData();
                getMenu();
                GridViewBind();
            }
        }

    }
    public void UserData()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string sql = "SELECT USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME FROM USERS_INFORMATIONS INNER JOIN DEPARTMENTS ON (USERS_INFORMATIONS.DEP_NO = DEPARTMENTS.DEP_NO) AND USERS_INFORMATIONS.DEP_NO = '" + int.Parse(DEPARTMENT_NO) + "' WHERE USERS_INFORMATIONS.EMPLOYEE_NO = '" + Int32.Parse(EMPLOYEE_NO) + "' AND USERS_INFORMATIONS.ACTIVE = '1'";
        //string sql = "SELECT EMPLOYEES.EMPLOYEE_NAME DEPARTMENTS.DEP_NAME FROM EMPLOYEES INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO)" +
        //        "AND EMPLOYEES.DEPT_DEPARTMRNT_NO = '" + int.Parse(DEPARTMENT_NO) + "' WHERE EMPLOYEES.EMPLOYEE_NO = '" + Int32.Parse(EMPLOYEE_NO) + "' AND EMPLOYEES.EMPLOYEE_STATUS = '1'";


        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();
        Text_ID.Text = EMPLOYEE_NO;
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
    public void GridViewBind()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

         //odbcdadapter = new OdbcDataAdapter("SELECT PAY_PAYROLLS_LINES.AMT, PAY_PAYROLL_ITEMS_TYPES.NAME, PAY_PAYROLLS.PAY_DATE, EMPLOYEES.EMPLOYEE_NAME FROM PAY_PAYROLLS_LINES, PAY_PAYROLL_ITEMS_TYPES,EMPLOYEES, PAY_PAYROLLS "+
         //       "WHERE PAY_PAYROLLS_LINES.PAY_ID = PAY_PAYROLLS.ID AND PAY_PAYROLLS_LINES.PAY_PAYROLL_TYPES_ID = PAY_PAYROLL_ITEMS_TYPES.ID "+
         //       "AND PAY_PAYROLLS.EMP_ID = EMPLOYEES.EMPLOYEE_NO AND "+
         //       "PAY_PAYROLLS.EMP_ID ='" + EMPLOYEE_NO + "' AND TO_CHAR(PAY_DATE,'MM/YYYY') = '"+ Text_Date.Text +"' ORDER BY REPORT_ORDER", connectionString);
         ////06/2013

        //odbcdadapter = new OdbcDataAdapter("SELECT PAY_PAYROLLS_LINES.AMT, PAY_PAYROLL_ITEMS_TYPES.NAME, PAY_PAYROLLS.PAY_DATE FROM PAY_PAYROLLS_LINES, PAY_PAYROLL_ITEMS_TYPES,EMPLOYEES, PAY_PAYROLLS " +
        //        "WHERE PAY_PAYROLLS_LINES.PAY_ID = PAY_PAYROLLS.ID AND PAY_PAYROLLS_LINES.PAY_PAYROLL_TYPES_ID = PAY_PAYROLL_ITEMS_TYPES.ID " +
        //        "AND PAY_PAYROLLS.EMP_ID = EMPLOYEES.EMPLOYEE_NO AND " +
        //        "PAY_PAYROLLS.EMP_ID ='" + EMPLOYEE_NO + "' AND TO_CHAR(PAY_DATE,'MM/YYYY') = '" + Text_Date.Text + "' ORDER BY REPORT_ORDER", connectionString);

        odbcdadapter = new OdbcDataAdapter("SELECT PAY_PAYROLL_ITEMS_TYPES.NAME, PAY_PAYROLLS_LINES.AMT FROM PAY_PAYROLLS_LINES, PAY_PAYROLL_ITEMS_TYPES,EMPLOYEES, PAY_PAYROLLS " +
              "WHERE PAY_PAYROLL_ITEMS_TYPES.SHOW_ON_REPORT=1 and PAY_PAYROLLS_LINES.PAY_ID = PAY_PAYROLLS.ID AND PAY_PAYROLLS_LINES.PAY_PAYROLL_TYPES_ID = PAY_PAYROLL_ITEMS_TYPES.ID " +
              "AND PAY_PAYROLLS.EMP_ID = EMPLOYEES.EMPLOYEE_NO AND " +
              "PAY_PAYROLLS.EMP_ID ='" + EMPLOYEE_NO + "' AND TO_CHAR(PAY_DATE,'MM/YYYY') = '" + Text_Date.Text + "' AND PAY_PAYROLLS.PAYROLL_STATUS = '1' AND PAY_PAYROLLS_LINES.AMT <> '0' ORDER BY REPORT_ORDER", connectionString);
     
        dset = new DataSet();
        odbcdadapter.Fill(dset);
        GridView1.DataSource = dset.Tables[0];
        GridView1.DataBind();
    }

    private void getMenu()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString2"].ConnectionString.ToString();

        con = new SqlConnection(connection);
        con.ConnectionString = connection;
        con.Open();

        DataTable table = new DataTable();


        string sql = "Select * from tbl_WebMenu INNER JOIN User_Check ON (tbl_WebMenu.MenuID = User_Check.MenuID)" +
            //"AND (User_Check.MenuID = tbl_WebMenu.ParentID)" +
                      "AND (User_Check.EmpNumber = '" + EMPLOYEE_NO + "' ) AND (User_Check.STATUS = '" + 1 + "')";

        SqlDataAdapter da = new SqlDataAdapter(sql, con);

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
        con.Close();
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

    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {

    }

    protected void Butt_Butt_Search(object sender, EventArgs e)
    {
        GridViewBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        Response.Redirect("~/UsersArea/UserPayrollsPDF.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO= " + DEPARTMENT_NO + "&TO_CHAR=" + Text_Date.Text + "");
        //try
        //{
        //    Response.ContentType = "application/pdf";
        //    //Response.AddHeader("content-disposition", "attachment;filename=EmpDetails.pdf");
        //    Response.AddHeader("content-disposition", "attachment;filename=" + EMPLOYEE_NO + "" + DateTime.Now.ToString("yyyyMMdd") + ".pdf");
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    GridView1.AllowPaging = false;
        //    GridViewBind();
        //    GridView1.RenderControl(hw);
        //    GridView1.HeaderRow.Style.Add("width", "15%");
        //    GridView1.HeaderRow.Style.Add("font-size", "10px");
        //    GridView1.Style.Add("text-decoration", "none");
        //    GridView1.Style.Add("font-family", "Tahoma, Arial, sans-serif;");
        //    GridView1.Style.Add("font-size", "8px");
        //    StringReader sr = new StringReader(sw.ToString());
        //    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 7f, 7f, 7f, 0f);
        //    iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
        //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //    pdfDoc.Open();
        //    htmlparser.Parse(sr);
        //    pdfDoc.Close();
        //    Response.Write(pdfDoc);
        //    Response.End();
        //}
        //catch (Exception ex)
        //{
        //    string ErrMsg = ex.Message;
        //}
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
            HeaderCell.Text = "Payroll Details: &nbsp; " + "" + Text_Name.Text + "" + ",&nbsp;&nbsp;&nbsp;" + Text_Department.Text + "";
            HeaderCell.ColumnSpan = 8;
            HeaderGridRow.Cells.Add(HeaderCell);
            GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }
}