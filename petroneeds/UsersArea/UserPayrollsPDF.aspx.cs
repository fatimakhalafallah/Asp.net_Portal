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
using iTextSharp.xmp.options;
using iTextSharp.xmp.impl;
using iTextSharp.xmp.properties;
using iTextSharp.text.html.simpleparser;
using Microsoft.Reporting.WebForms;
using System.Web.UI;
using System.ServiceModel.Web;

public partial class UsersArea_UserPayrollsPDF : System.Web.UI.Page
{
    public OdbcConnection odbcconn = null;
    public OdbcCommand odbccmd = null;
    public OdbcDataReader odbcread = null;

    public SqlCommand Sqlcomm = null;
    public SqlConnection Sqlcon = null;

    DataSet dset;

    public string EMPLOYEE_NO, DEPARTMENT_NO, SALARY_DATE;
    public OdbcDataAdapter odbcdadapter;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        SALARY_DATE = Request.QueryString["TO_CHAR"];

        //Text_Date.Text = SALARY_DATE;
        //Text_ID.Text = EMPLOYEE_NO;
        //Text_Department.Text = DEPARTMENT_NO;

        if (!IsPostBack)
        {
            UserData();
            //GridViewBind();
            //EXPORT_PDF();
            DisplayReport();
        }
    }
    /* public void GridViewBind()
     {
         string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
         EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
         DEPARTMENT_NO = Request.QueryString["DEP_NO"];
         SALARY_DATE = Request.QueryString["TO_CHAR"];



         odbcdadapter = new OdbcDataAdapter("SELECT PAY_PAYROLL_ITEMS_TYPES.NAME, PAY_PAYROLLS_LINES.AMT FROM PAY_PAYROLLS_LINES, PAY_PAYROLL_ITEMS_TYPES,EMPLOYEES, PAY_PAYROLLS " +
               "WHERE PAY_PAYROLLS_LINES.PAY_ID = PAY_PAYROLLS.ID AND PAY_PAYROLLS_LINES.PAY_PAYROLL_TYPES_ID = PAY_PAYROLL_ITEMS_TYPES.ID " +
               "AND PAY_PAYROLLS.EMP_ID = EMPLOYEES.EMPLOYEE_NO AND " +
               "PAY_PAYROLLS.EMP_ID ='" + EMPLOYEE_NO + "' AND TO_CHAR(PAY_DATE,'MM/YYYY') = '" + Text_Date.Text + "' AND PAY_PAYROLLS.PAYROLL_STATUS = '1' AND PAY_PAYROLLS_LINES.AMT <> '0' ORDER BY REPORT_ORDER", connectionString);

         dset = new DataSet();
         odbcdadapter.Fill(dset);
         GridView1.DataSource = dset.Tables[0];
         GridView1.DataBind();
     }*/
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
          //Text_ID.Text = EMPLOYEE_NO;
          if (read.HasRows)
          {
              Text_Name.Text = read["FULL_USER_NAME"].ToString();
              Text_Department.Text = read["DEP_NAME"].ToString();
              //Text_Name.Text = read["FULL_USER_NAME"].ToString();
              //Text_Department.Text = read["DEP_NAME"].ToString();
          }
          else
          {
              Response.Redirect("~/Login.aspx");
          }
          cmd.Connection.Close();
      }
    /*public void EXPORT_PDF()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        try
        {
            Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=EmpPayrollDetails.pdf");
            Response.AddHeader("content-disposition", "attachment;filename=" + EMPLOYEE_NO + "" + DateTime.Now.ToString("yyyyMMdd") +".pdf");
           
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            this.Page.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());

            Document PdfDoc = new Document(PageSize.A4, 7f, 7f, 7f, 0f);

            GridView1.AllowPaging = false;
            GridViewBind();
            GridView1.RenderControl(hw);
            GridView1.HeaderRow.Style.Add("width", "15%");
            GridView1.HeaderRow.Style.Add("font-size", "10px");
            GridView1.Style.Add("text-decoration", "none");
            GridView1.Style.Add("font-family", "Tahoma, Arial, sans-serif;");
            GridView1.Style.Add("font-size", "8px");

            var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/images/Portal-Head.gif"));
            logo.SetAbsolutePosition(75, 667);
            PdfDoc.Add(logo);

            
            HTMLWorker htmlparser = new HTMLWorker(PdfDoc);

            //PdfWriter.GetInstance(PdfDoc, Response.OutputStream);
            PdfWriter.GetInstance(PdfDoc, new FileStream(EMPLOYEE_NO + "" + DateTime.Now.ToString("yyyyMMdd") + ".pdf", FileMode.Create));

            PdfDoc.Open();
            htmlparser.Parse(sr);

            Response.Write(PdfDoc);
            PdfDoc.Close();
            Response.End();
        }
        catch (Exception ex)
        {
            string ErrMsg = ex.Message;
        }
    }*/
    /* public void EXPORT_PDF()
     {
         EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];

         Response.ContentType = "application/pdf";
         //Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
         Response.AddHeader("content-disposition", "attachment;filename=" + EMPLOYEE_NO + "" + DateTime.Now.ToString("yyyyMMdd") + ".pdf");
           
         Response.Cache.SetCacheability(HttpCacheability.NoCache);
         StringWriter sw = new StringWriter();
         HtmlTextWriter hw = new HtmlTextWriter(sw);
         this.Page.RenderControl(hw);
         StringReader sr = new StringReader(sw.ToString());
         iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 100f, 0f);

         GridView1.AllowPaging = false;
         GridView1.DataBind();
         //GridViewBind();
         //GridView1.RenderControl(hw);
         GridView1.HeaderRow.Style.Add("width", "20%");
         GridView1.HeaderRow.Style.Add("font-size", "15px");
         GridView1.Style.Add("text-decoration", "none");
         GridView1.Style.Add("font-family", "Tahoma, Arial, sans-serif;");
         GridView1.Style.Add("font-size", "10px");

         iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
         PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
         pdfDoc.Open();

         //var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/images/Portal-Head.gif"));
         //logo.SetAbsolutePosition(75, 667);
         //pdfDoc.Add(logo);

         htmlparser.Parse(sr);
         pdfDoc.Close();
         Response.Write(pdfDoc);
         Response.End();
     }*/
    protected void Button1_Click(object sender, EventArgs e)
    {
        //EXPORT_PDF();
    }
    /*protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }*/
    //protected void BtnViewReport_Click(object sender, EventArgs e)
    public void DisplayReport()
    {
        EMPLOYEE_NO     = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO   = Request.QueryString["DEP_NO"];
        SALARY_DATE     = Request.QueryString["TO_CHAR"];

        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/SalaryDetails.rdlc");

        DataSet ds = GetData("SELECT PAY_PAYROLL_ITEMS_TYPES.NAME, PAY_PAYROLLS_LINES.AMT FROM PAY_PAYROLLS_LINES, PAY_PAYROLL_ITEMS_TYPES, EMPLOYEES, PAY_PAYROLLS " +
                  "WHERE PAY_PAYROLLS_LINES.PAY_ID = PAY_PAYROLLS.ID AND PAY_PAYROLLS_LINES.PAY_PAYROLL_TYPES_ID = PAY_PAYROLL_ITEMS_TYPES.ID " +
                  "AND PAY_PAYROLLS.EMP_ID = EMPLOYEES.EMPLOYEE_NO AND " +
                  "PAY_PAYROLLS.EMP_ID ='" + EMPLOYEE_NO + "' AND TO_CHAR(PAY_DATE,'MM/YYYY') = '" + SALARY_DATE + "' "+
                  "AND PAY_PAYROLLS.PAYROLL_STATUS = '1' AND PAY_PAYROLLS_LINES.AMT <> '0' ORDER BY REPORT_ORDER");

        ReportParameter[] param = new ReportParameter[3];
        param[0] = new ReportParameter("ReportParameter1", Text_Name.Text);
        param[1] = new ReportParameter("ReportParameter2", Text_Department.Text);
        param[2] = new ReportParameter("ReportParameter3", SALARY_DATE);

        ReportViewer1.LocalReport.SetParameters(param);
        

        ////param[0] = new ReportParameter("param1", Text_Name.Text);
        ////param[1] = new ReportParameter("param2", Text_Department.Text);

        ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(datasource);
        ReportViewer1.ServerReport.Refresh();


        //ReportParameter p = new ReportParameter("ShowDescriptions", TextBox1.Text);
        //this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p });
        //ReportViewer1.ServerReport.Refresh();
    }
    private DataSet GetData(string query)
    {
        string conString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        OdbcCommand cmd = new OdbcCommand(query);
        using (OdbcConnection con = new OdbcConnection(conString))
        {
            using (OdbcDataAdapter sda = new OdbcDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
               {
                   sda.Fill(ds,"DataSet1");
                   //sda.Fill(ds, "PAY_PAYROLLS_LINES, EMPLOYEES, PAY_PAYROLLS");
                   return ds;
                }
            }
        }
    }
}