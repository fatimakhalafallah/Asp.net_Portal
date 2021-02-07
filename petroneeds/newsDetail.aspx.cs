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
using System.Configuration;


using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Default
{
    /// <summary>
    /// Summary description for newsDetail.
    /// </summary>
    public partial class newsDetail : System.Web.UI.Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["petroneedsConnectionString2"].ConnectionString);


            string strSql = "SELECT NewsDetail, image FROM tbl_News WHERE Id=" + Convert.ToInt32(Request.QueryString["id"]);
            //string strSql = "SELECT newsDetail FROM tbl_NewsDetail WHERE newsId=" + Convert.ToInt32(Request.QueryString["NewsId"]);

            HtmlTableCell cellNewsDetail = new HtmlTableCell();
            //HtmlTableCell cellNewsDetail2 = new HtmlTableCell();

            HtmlImage img = new HtmlImage();

            SqlCommand myComd = new SqlCommand(strSql, myCon);
            SqlDataReader sqlRdr;
            try
            {
                myCon.Open();
                sqlRdr = myComd.ExecuteReader();
                if (sqlRdr.Read())
                {
                    //cellNewsDetail.InnerText = "<tr><td>" + sqlRdr.GetValue(0).ToString() + "</td></tr>";
                    cellNewsDetail.InnerHtml += "<tr><td>" + sqlRdr.GetValue(0).ToString() + "</td></tr>";
                    cellNewsDetail.Align = "justify";
                    rowNewsDetail.Cells.Add(cellNewsDetail);

                    Image1.ImageUrl ="<tr><td>" + sqlRdr.GetValue(1).ToString() + "</td></tr>"; //["image"].ToString();
                    
                    //img.Src = sqlRdr.GetValue(1).ToString();
                    //img.ResolveUrl(img.ToString());//.Add(img);
                }
                else
                {
                    Response.Write("No Record found in the detail table");
                }
                sqlRdr.Close();
            }
            catch (Exception msg)
            {
                Response.Write(msg.Message);
            }
            finally
            {
                //close connection
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}
