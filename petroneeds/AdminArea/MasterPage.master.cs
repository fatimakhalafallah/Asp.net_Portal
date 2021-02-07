using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Odbc;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public SqlCommand comm = null;
    public SqlConnection con = null;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //getMenu();
        }
    }

    //private void getMenu()
    //{
    //    rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
    //    connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString2"].ConnectionString.ToString();

    //    con = new SqlConnection(connection);
    //    con.ConnectionString = connection;
    //    con.Open();

        
    //    DataSet ds = new DataSet();
    //    DataTable dt = new DataTable();

    //    string sql = "Select * from tbl_WebMenu";
    //    //string sql = "Select * from tbl_WebMenu INNER JOIN User_Check ON (tbl_WebMenu.MenuID = User_Check.MenuID)"+
    //    //              "AND (User_Check.EmpNumber = '"+ 8080 +"' ) AND (User_Check.STATUS = '"+1+"')";

    //    SqlDataAdapter da = new SqlDataAdapter(sql, con);
    //    da.Fill(ds);
    //    dt = ds.Tables[0];
    //    DataRow[] drowpar = dt.Select("ParentID=" + 0);

    //    foreach (DataRow dr in drowpar)
    //    {
    //        menuBar.Items.Add(new MenuItem(dr["MenuName"].ToString(),
    //                dr["MenuID"].ToString(), "",
    //                dr["MenuLocation"].ToString()));
    //    }

    //    foreach (DataRow dr in dt.Select("ParentID >" + 0))
    //    {
    //        MenuItem mnu = new MenuItem(dr["MenuName"].ToString(),
    //                         dr["MenuID"].ToString(), "", dr["MenuLocation"].ToString()); //dr["MenuID"].ToString(),"", dr["MenuLocation"+"+'"+ 0 +"'+"].ToString());
    //        menuBar.FindItem(dr["ParentID"].ToString()).ChildItems.Add(mnu);
    //    }
    //    con.Close();
    //}
    protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        System.Web.Security.FormsAuthentication.SignOut();
        Response.Redirect(Request.UrlReferrer.ToString());
        Response.Cookies.Clear();
    }
}
