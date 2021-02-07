using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Configuration;


using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.HtmlControls;
namespace Default
{
    /// <summary>
    /// Summary description for newsDetail.
    /// </summary>
    public partial class EmpDetail : System.Web.UI.Page
    {
        OdbcDataAdapter dadapter = null;
        DataSet dset = null;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            OdbcConnection connectionString = new OdbcConnection(ConfigurationManager.ConnectionStrings["petroneedsConnectionString"].ConnectionString);


            // dadapter = new OdbcDataAdapter("SELECT EMPLOYEES.EMPLOYEE_NO, EMPLOYEES.EMPLOYEE_NAME, DEPARTMENTS.DEP_NAME, EMPLOYEES.DATE_OF_JOIN, EMPLOYEES.EMAIL, EMPLOYEES.ID_CARD" +
            //" FROM EMPLOYEES INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO) WHERE" +
            //" EMPLOYEES.EMPLOYEE_NO = '" + Convert.ToInt32(Request.QueryString["EMPLOYEE_NO"]) + "'", connectionString);

            dadapter = new OdbcDataAdapter("SELECT EMPLOYEES.EMPLOYEE_NO, EMPLOYEES.EMPLOYEE_NAME, DEPARTMENTS.DEP_NAME, EMPLOYEES.DATE_OF_JOIN, EMPLOYEES.EMAIL, EMPLOYEES.ID_CARD,"+
            "LKP_JOBS.JOB_NAME, PROJECT_CODE.PROJ_NAME "+
			"FROM  LKP_JOBS, PROJECT_CODE, EMPLOYEES INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO) WHERE "+
            "EMPLOYEES.EMPLOYEE_NO = '" + Convert.ToInt32(Request.QueryString["EMPLOYEE_NO"]) + "' AND EMPLOYEES.JOB_NO = LKP_JOBS.JOB_NO AND EMPLOYEES.SECTION_NO = PROJECT_CODE.PROJ_NO AND " +
			"EMPLOYEES.EMPLOYEE_STATUS = 1", connectionString);

          
            dset = new DataSet();
            dadapter.Fill(dset);
            DetailsView1.DataSource = dset.Tables[0];
            DetailsView1.DataBind();
            IMAGES();
            Comments();
            //HtmlTableCell cellEmpDetail  = new HtmlTableCell();
            //HtmlTableCell cellEmpDetail2 = new HtmlTableCell();
            //HtmlTableCell cellEmpDetail3 = new HtmlTableCell();
            //HtmlTableCell cellEmpDetail4 = new HtmlTableCell();
            //HtmlTableCell cellEmpDetail5 = new HtmlTableCell();

            //OdbcCommand myComd = new OdbcCommand(odbcSql, myCon);
            //OdbcDataReader odbcRdr;
            //try
            //{
            //    myCon.Open();
            //    odbcRdr = myComd.ExecuteReader();
            //    if (odbcRdr.Read())
            //    {
            //        string space = "'+</br> </br>+'";
            //        cellEmpDetail.InnerText = odbcRdr.GetValue(0).ToString() + space;
            //        rowNewsDetail.Cells.Add(cellEmpDetail);

            //        cellEmpDetail2.InnerText = odbcRdr.GetValue(1).ToString() + space;
            //        rowNewsDetail.Cells.Add(cellEmpDetail2);

            //        cellEmpDetail3.InnerText = odbcRdr.GetValue(2).ToString();
            //        rowNewsDetail.Cells.Add(cellEmpDetail3);

            //        cellEmpDetail4.InnerText = odbcRdr.GetValue(3).ToString();
            //        rowNewsDetail.Cells.Add(cellEmpDetail4);

            //        cellEmpDetail5.InnerText = odbcRdr.GetValue(4).ToString();
            //        rowNewsDetail.Cells.Add(cellEmpDetail5);
            //    }
            //    else
            //    {
            //        Response.Write("No Record found in the detail table");
            //    }
            //    odbcRdr.Close();
            //}
            //catch (Exception msg)
            //{
            //    Response.Write(msg.Message);
            //}
            //finally
            //{
            //    myCon.Close();
            //}
        }
        private void IMAGES()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

           
            string date;
            date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

            string sql = "SELECT ID_CARD FROM EMPLOYEES WHERE EMPLOYEE_NO = '" + Request.QueryString["EMPLOYEE_NO"] + "'"; 

            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand(sql, conn);
            cmd.Connection.Open();
            OdbcDataReader read = cmd.ExecuteReader();
            read.Read();

            if (read.HasRows)
            {
                //Image1.ImageUrl = "../photos/" + read["ID_CARD"] + ".JPEG".ToString();
                ImageButton1.ImageUrl = "~/photos/" + read["ID_CARD"] + ".JPG".ToString();
            }
            cmd.Connection.Close();
        }
        private void Comments()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString2"].ConnectionString;


            string date;
            date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

            string sql = "SELECT EmpComment FROM Users_Comments WHERE EmpNumber = '" + Request.QueryString["EMPLOYEE_NO"] + "'";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Connection.Open();
            SqlDataReader read = cmd.ExecuteReader();
            read.Read();

            if (read.HasRows)
            {
                //Image1.ImageUrl = "../photos/" + read["ID_CARD"] + ".JPEG".ToString();
                Label2.Text = read["EmpComment"].ToString();
            }
            else
            { TextBox1.Visible = false;
            Label2.Visible = false;
            Label1.Visible = false;
            }
            cmd.Connection.Close();
        }
        
    }
}
