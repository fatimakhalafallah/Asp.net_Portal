using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Odbc;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Design;


public partial class UsersArea_TravelHistory : System.Web.UI.Page
{
    public OdbcDataAdapter odbcadabter = null;
    public OdbcDataAdapter odbcdadapter;
    public string La;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["EMPLOYEE_NO"] != null)
            La = Request.QueryString["EMPLOYEE_NO"];

        if (!IsPostBack)
        {
            DataView dvm = Getdata();
            grid1.DataSource = dvm;
            grid1.DataBind();
        }
    }


    private DataView Getdata()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        string sql = "SELECT TRAVEL_PURPOSE.PURPOSE ,TRAVEL_DTL.CITY_FROM, TRAVEL_DTL.FROM_DATE ,TRAVEL_DTL.CITY_TO ,TRAVEL_DTL.TO_DATE  FROM TRAVEL_DTL , TRAVEL_MSTR INNER JOIN TRAVEL_PURPOSE ON TRAVEL_MSTR.PURPOSE= TRAVEL_PURPOSE.SERIAL  WHERE TRAVEL_DTL.TRF_NO=TRAVEL_MSTR.TRF_NO AND TRAVEL_MSTR.EMPLOYEE_NO='" + La + "'"
                         ;

        OdbcConnection con = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, con);
        OdbcDataAdapter ad = new OdbcDataAdapter(sql, con);
        DataSet ds = new DataSet();
        ad.Fill(ds,"TRAVEL_DTL");
        DataView dv = ds.Tables["TRAVEL_DTL"].DefaultView;
        return dv;
    }


    protected void grid1_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
    {
        grid1.PageIndex = e.NewPageIndex;
        DataView dvm = Getdata();
        grid1.DataSource = dvm;
        grid1.DataBind();
    }


}