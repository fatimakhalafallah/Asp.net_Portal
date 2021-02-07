using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Configuration;
using System.Data;

namespace ScrollingNews.userControll
{
    using System;
    using System.Data;
    using System.Data.Odbc;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;


    /// <summary>
    ///		Summary description for Scrolling_News.
    /// </summary>
    public partial class scrolling_emp : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
                       ///
            OdbcConnection myCon = new OdbcConnection(ConfigurationManager.ConnectionStrings["petroneedsConnectionString"].ConnectionString);
           
            //string strSql = "SELECT EMPLOYEE_NO, FULL_USER_NAME FROM USERS_INFORMATIONS WHERE ACTIVE = '" + 1 + "'  ORDER BY EMPLOYEE_NO ASC";
            //string strSql = "SELECT USERS_INFORMATIONS.EMPLOYEE_NO, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME FROM USERS_INFORMATIONS INNER JOIN DEPARTMENTS ON (USERS_INFORMATIONS.DEP_NO = DEPARTMENTS.DEP_NO) WHERE USERS_INFORMATIONS.ACTIVE = '" + 1 + "'  ORDER BY EMPLOYEE_NO ASC";
            string strSql = "SELECT EMPLOYEES.EMPLOYEE_NO, EMPLOYEES.EMPLOYEE_NAME, DEPARTMENTS.DEP_NAME FROM "+
" EMPLOYEES INNER JOIN DEPARTMENTS ON (EMPLOYEES.DEPT_DEPARTMRNT_NO = DEPARTMENTS.DEP_NO) WHERE EMPLOYEES.EMPLOYEE_STATUS = 1"+
" ORDER BY EMPLOYEE_NO ASC";
//"SELECT USERS_INFORMATIONS.FULL_USER_NAME, USERS_INFORMATIONS.EMAIL, DEPARTMENTS.DEP_NAME FROM USERS_INFORMATIONS INNER JOIN DEPARTMENTS ON (USERS_INFORMATIONS.DEP_NO = DEPARTMENTS.DEP_NO) AND USERS_INFORMATIONS.DEP_NO = '" + int.Parse(DEPARTMENT_NO) + "' WHERE USERS_INFORMATIONS.EMPLOYEE_NO = '" + Int32.Parse(EMPLOYEE_NO) + "'"; 
        
            string strScrolling = "";
            HtmlTableCell cellScrolling = new HtmlTableCell();
            OdbcCommand myComd = new OdbcCommand(strSql, myCon);
            OdbcDataReader odbcRdr;

            try
            {
                myCon.Open();
                odbcRdr = myComd.ExecuteReader();
                strScrolling = "<Marquee OnMouseOver='this.stop();' OnMouseOut='this.start();' direction='up' scrollamount='3' bgcolor='#ffffff' width='230px' height='130px' style=color: '#05568B'>";
              //  strScrolling = "<Marquee OnMouseOver='this.stop();' OnMouseOut='this.start();' direction='up' scrollamount='5' bgcolor='#902700' width='200px' height='500px'>";

                while (odbcRdr.Read())
                {
                    strScrolling = strScrolling + "<a href='#' OnClick=" + "javascript:window.open('EmpDetail.aspx?EMPLOYEE_NO=" + odbcRdr.GetValue(0) + "','EMPLOYEE_NAME','width=600,height=600;toolbar=yes;');" + "><font face='Verdana' size='2' color='#b00000'>" + "- &nbsp;" + odbcRdr.GetValue(1) + " &nbsp; &nbsp; &nbsp;" + odbcRdr.GetValue(2).ToString() + "</a>" + "</br></br> </font>";
                }
                strScrolling = strScrolling + "</Marquee>";
               // Label1.Text = strScrolling.ToString();
                odbcRdr.Close();
                cellScrolling.InnerHtml = strScrolling;
                rowScrolling.Cells.Add(cellScrolling);
            }
            catch (Exception msg)
            {
                Response.Write(msg.Message);
            }
            finally
            {
                //close sql connection				
                myCon.Close();
            }
        }
        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}