using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AjaxControlToolkit;

public partial class userControll_Reqruitment : System.Web.UI.UserControl
{
    public OdbcCommand comm = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter odbcadabter = null;

    public DataSet dataset = null;
    private string connection = null;

    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;
    public string EMPLOYEE_NO, DEPARTMENT_NO, FormNo;

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckAccountDetails();

        Text_Candidate.Text     = Request.Form[Text_Candidate.UniqueID];
        Text_Experience.Text    = Request.Form[Text_Experience.UniqueID];
        Text_Description.Text   = Request.Form[Text_Description.UniqueID];
        Text_Remarks.Text       = Request.Form[Text_Remarks.UniqueID];

        FormNo = Session["FormNo"].ToString();
        if (FormNo != "0")
            {
                if (Text_Description.Text.Length < 100 || Text_Description.Text.Length == 0)
                {
                    if (Text_Remarks.Text.Length < 100 || Text_Remarks.Text.Length == 0)
                    {
                        InsertValues(FormNo);
                    }
                    else
                    { 
                        Label_Chractor1.Visible = true;
                    }
                }
            else
                { 
                    Label_Chractor2.Visible = true;
                }
            }
    }
    public void CheckAccountDetails()
    {
        string FormNo = Session["FormNo"].ToString();

        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        string sql = "SELECT NVL(MAX(SERIAL_NO),0)+1 FROM RECRUITMENT_DTL WHERE RF_NO = '" + FormNo + "'";

        OdbcConnection odbcconn = new OdbcConnection(connectionString);
        OdbcCommand odbccmd = new OdbcCommand(sql, odbcconn);

        odbccmd.Connection.Open();
        OdbcDataReader read = odbccmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_Num2.Text = read[0].ToString();
        }
        odbccmd.Connection.Close();
    }
    private void InsertValues(string _FormNo)
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        OdbcCommand odbccomm = null;
        OdbcConnection odbccon = null;
        string sql;

        odbccon = new OdbcConnection(connection);
        odbccon.ConnectionString = connection;
        odbccon.Open();

        CheckAccountDetails();

        sql = "INSERT INTO RECRUITMENT_DTL (RF_NO, SERIAL_NO, CAND_NAME, EXP_YEAR, ADD_CREDIT, REMARKS) VALUES" +
            "('" + _FormNo + "', '" + Text_Num2.Text + "', '" + Text_Candidate.Text + "', '" + Text_Experience.Text + "', '" + Text_Description.Text + "', '" + Text_Remarks.Text + "')";
        odbccomm = new OdbcCommand(sql, odbccon);
        odbccomm.ExecuteNonQuery();
        odbccon.Close();
    }
}