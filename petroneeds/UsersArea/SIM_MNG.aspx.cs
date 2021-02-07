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




public partial class UsersArea_SIM_MNG : System.Web.UI.Page
{

    string  EMPLOYEE_NO , DEPARTMENT_NO;
    public OdbcCommand comm, comm_mas = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter odbcadabter = null;
    public OdbcDataAdapter dadapter;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;

    //string EM="9493"; 
    protected void Page_Load(object sender, EventArgs e)
    {
  
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        if (EMPLOYEE_NO == "" || EMPLOYEE_NO == null)
        {
            Response.Redirect("~/Login.aspx");
            
        }
        else
        
        if (!IsPostBack)
        {
            getMenu();
            DataView dvm = Getdata();
            grid1.DataSource = dvm;
            grid1.DataBind();
          
        }      

    }

    private DataView Getdata()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        //string sql = "SELECT FORM_NO , FORM_DATE, USER_NAME, USER_DEP ,REQUEST_EXECUTOR ,DECODE(FORM_STATUS,1,'Pending',2,'MNG Approve',3,'MNG Disapprove',4 ,'ICT MNG Approve',5,'ICT MNG Disapprove',6,'Return',7,'Complete') AS FORM_STATUS FROM ICT_TELE ,REQUEST_ACTORS  WHERE DID='0' AND REQUEST_ACTORS.REQUEST_TYPE_ID = '31' AND REQUEST_ACTORS.EMPLOYEE_NO ='" + EMPLOYEE_NO + "' ORDER BY FORM_NO ASC ";

        string sql="SELECT DISTINCT ICT_TELE.FORM_NO, ICT_TELE.FORM_DATE, ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,EMPLOYEES.EMPLOYEE_NAME,DECODE(ICT_TELE.FORM_STATUS,1,'Pending',2,'MNG Approve',3,'MNG Disapprove',4 ,'ICT MNG Approve',5,'ICT MNG Disapprove',6,'Return',7,'Complete') AS FORM_STATUS FROM REQUEST_ACTORS,ICT_TELE INNER JOIN EMPLOYEES ON EMPLOYEES.EMPLOYEE_NO=ICT_TELE.REQUEST_EXECUTOR  WHERE REQUEST_ACTORS.REQUEST_TYPE_ID = '31' AND REQUEST_ACTORS.EMPLOYEE_NO='"+EMPLOYEE_NO+"' AND ICT_TELE.DID='0' ORDER BY FORM_NO ASC";

        OdbcConnection con = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, con);
        con.Open();
        OdbcDataAdapter ad = new OdbcDataAdapter(sql, con);
        DataSet ds = new DataSet();
        ad.Fill(ds, "ICT_TELE");
        DataView dv = ds.Tables["ICT_TELE"].DefaultView;
        con.Close();
        return dv;  
    }

    protected void grid1_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
    {
        grid1.PageIndex = e.NewPageIndex;
        DataView dvm = Getdata();
        grid1.DataSource = dvm;
        grid1.DataBind();
 
    }
    public string sortExpression { get; set; }

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
    protected void grid1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=SIM_RequestForm.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        grid1.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
        grid1.AllowPaging = true;
        grid1.DataBind();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }


}











      