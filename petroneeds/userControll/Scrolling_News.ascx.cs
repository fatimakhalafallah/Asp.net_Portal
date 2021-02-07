using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ScrollingNews.userControll
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;


    /// <summary>
    ///		Summary description for Scrolling_News.
    /// </summary>
    public partial class Scrolling_News : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
                       ///
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["petroneedsConnectionString2"].ConnectionString);
            ///
            //string strSql = "SELECT * FROM tbl_News order by dateCreated ASC";

            string strSql = "SELECT id, NewTitle, dateCreated FROM tbl_News Where Status = 0 order by NewTitle ASC";
            string strScrolling = "";
            HtmlTableCell cellScrolling = new HtmlTableCell();
            SqlCommand myComd = new SqlCommand(strSql, myCon);
            SqlDataReader sqlRdr;

            try
            {
                myCon.Open();
                sqlRdr = myComd.ExecuteReader();
                strScrolling = "<Marquee OnMouseOver='this.stop();' OnMouseOut='this.start();' direction='up' scrollamount='3' bgcolor='#ffffff' width='230px' height='130px' style=color: '#05568B'>";
              //  strScrolling = "<Marquee OnMouseOver='this.stop();' OnMouseOut='this.start();' direction='up' scrollamount='5' bgcolor='#902700' width='200px' height='500px'>";

                while (sqlRdr.Read())
                {
                    strScrolling = strScrolling + "<a href='#' OnClick=" + "javascript:window.open('newsDetail.aspx?id=" + sqlRdr.GetValue(0) + "','NewsDetail','width=600,height=600;toolbar=yes;');" + "><font face='Verdana' size='2' color='#b00000'>" + "- &nbsp;" + sqlRdr.GetValue(1) + " &nbsp; &nbsp; &nbsp;" + sqlRdr.GetValue(2).ToString() + "</a>" + "</br></br> </font>";
                }
                strScrolling = strScrolling + "</Marquee>";
               // Label1.Text = strScrolling.ToString();
                sqlRdr.Close();
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