using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdminArea_welcome : System.Web.UI.Page
{
    public SqlCommand comm = null;
    public SqlConnection con = null;
    public SqlDataAdapter adapter = null;

    public DataSet dataset = null;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Reset_Items();
        }
    }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        Update();
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset_Items();
    }
    private void Update()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString2"].ConnectionString.ToString();
        string sql;

        con = new SqlConnection(connection);
        con.ConnectionString = connection;
        con.Open();

        sql = "UPDATE Mng_Word SET MngTitle = '" + Text_Title.Text + "', MngDetails ='" + Text_Details.Text + "', "+
              "MngDetails2 ='" + Text_Details2.Text + "', MngDetails3 ='" + Text_Details3.Text + "'";
                comm = new SqlCommand(sql, con);
                comm.ExecuteNonQuery();
        con.Close();
        Reset_Items();
        Label_Messages.Text = "Thank You, Your Record Saved";
    }
    private void Reset_Items()
    {
        Text_Details.Text = "";
        Text_Details2.Text = "";
        Text_Details3.Text = "";
        Text_Title.Text = "";
        Label_Messages.Text = "";
    }
}