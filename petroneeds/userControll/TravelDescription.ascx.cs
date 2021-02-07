using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Odbc;

public partial class userControll_TravelDescription : System.Web.UI.UserControl
{
    public OdbcCommand comm, comm_mas = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter odbcadabter = null;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;
    string FormNo, FormDate, DetailsNo;
    public int num = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckAccountDetails();
        AirLine();
        

        AjaxControlToolkit.ToolkitScriptManager.GetCurrent(Page);

        //Text_NumDeta.Text = Request.Form[Text_NumDeta.UniqueID];
        Text_from_Loca.Text = Request.Form[Text_from_Loca.UniqueID];
        Text_To_Loca.Text = Request.Form[Text_To_Loca.UniqueID];

        Text_from_Date.Text = Request.Form[Text_from_Date.UniqueID];
        //Text_To_Date.Text = Request.Form[Text_To_Date.UniqueID];
        Text_Class.Text = Request.Form[Text_Class.UniqueID];
        Text_Remarks.Text = Request.Form[Text_Remarks.UniqueID];
        DropDownList1.SelectedValue = Request.Form[DropDownList1.UniqueID];

        FormNo = Session["FormNo"].ToString();
        FormDate = Session["FormDate"].ToString();
        //DetailsNo = Session["DetailsNo"].ToString();

        if (Text_from_Loca.Text != "" && Text_To_Loca.Text != "" && Text_from_Date.Text != "")
        {
            if (FormNo != "0" && FormDate != "0")
            {
                InsertDetails(FormNo, FormDate);
            }
        }
        else
        {}
    }
    private void InsertDetails(string FormNo, string FormDate)
   {
       rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
       connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
       string sql;

       CheckAccountDetails();     
       sql = "INSERT INTO TRAVEL_DTL " +
      "(TRF_NO, SERIAL_NO, TRANS_DATE, CITY_FROM, FROM_DATE, CITY_TO, TO_DATE, AIR_LINE_NO, " +
      " FLIHT_CODE, CLASS, REMARKS)  VALUES" +

       "('" + FormNo + "', '" + Text_NumDeta.Text + "' , '" + FormDate + "' , '" + Text_from_Loca.Text + "', '" + Text_from_Date.Text + "', '" + Text_To_Loca.Text + "', '" + Text_from_Date.Text + "', '" + DropDownList1.SelectedValue + "' " +
       ",'', '" + Text_Class.Text + "', '" + Text_Remarks.Text + "')";


       con = new OdbcConnection(connection);
       con.ConnectionString = connection;
       con.Open();

       comm = new OdbcCommand(sql, con);
       comm.ExecuteNonQuery();
       con.Close();
       
   }
    public void CheckAccountDetails()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        //string sql = "SELECT MAX(TRF_NO)+1 FROM TRAVEL_MSTR";
        string sql = "SELECT NVL(MAX(SERIAL_NO),0)+1 FROM TRAVEL_DTL WHERE TRF_NO = '" + FormNo + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_NumDeta.Text = read[0].ToString();
        }
        cmd.Connection.Close();
    }
    private void AirLine()
    {
        DataSet dset;
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        string sql = "SELECT AIR_LINE_NAME, AIR_LINE_NO FROM AIR_LINERS";


        odbcadabter = new OdbcDataAdapter(sql, connectionString);
        dset = new DataSet();
        odbcadabter.Fill(dset);
        DropDownList1.DataSource = dset.Tables[0];
        DropDownList1.DataTextField = "AIR_LINE_NAME";
        DropDownList1.DataValueField = "AIR_LINE_NO";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("<<<Select>>>", "0"));
        DropDownList1.SelectedIndex = 0;
        DropDownList1.SelectedValue = "0";
        DropDownList1.SelectedItem.Value = "0";
    }
}