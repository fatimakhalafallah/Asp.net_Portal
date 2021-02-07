using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data;
using System.Configuration;

public partial class userControll_ServicesRequested : System.Web.UI.UserControl
{
    public OdbcCommand comm = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter dadapter = null;
    public DataSet dset = null;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxControlToolkit.ToolkitScriptManager.GetCurrent(Page);

        TextFrom.Text = Request.Form[TextFrom.UniqueID];
        TextTo.Text = Request.Form[TextTo.UniqueID];
        TextRemark.Text = Request.Form[TextRemark.UniqueID];

        if (TextFrom.Text != "" && TextTo.Text != "")
        {
            string FormNo = Session["FormNo"].ToString();
            string ServicesNo = Session["ServicesNo"].ToString();
            InsertValues(FormNo, ServicesNo);
        }
    }

    public void InsertValues(string FormNo, string ServicesNo)
    {
        string[] TextBoxes = new string[4];

        TextFrom.Text = Request.Form[TextFrom.UniqueID];
        TextTo.Text = Request.Form[TextTo.UniqueID];
        TextRemark.Text = Request.Form[TextRemark.UniqueID];

        TextBoxes[0] = TextFrom.Text;
        TextBoxes[1] = TextTo.Text;
        TextBoxes[2] = TextRemark.Text;
        //TextBoxes[3] = TextRemark.Text;

        //Response.Write(TextBoxes[0]);
        //Response.Write(TextBoxes[1]);
        //Response.Write(TextBoxes[2]);
        //Response.Write(TextBoxes[3]);


        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql;

        sql = "INSERT INTO TRAVEL_SERVICES_DTL " +
                   "(TS_NO, SER_NO, SER_FROM, SER_TO, REMARK)  VALUES" +
                   "('" + FormNo + "', '" + ServicesNo + "', '" + TextBoxes[0] + "', '" + TextBoxes[1] + "', '" + TextBoxes[2] + "')";

        con = new OdbcConnection(connection);
        con.ConnectionString = connection;
        con.Open();
        comm = new OdbcCommand(sql, con);
        comm.ExecuteNonQuery();
        con.Close();
    }
}