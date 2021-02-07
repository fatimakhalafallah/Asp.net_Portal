using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdminArea_events : System.Web.UI.Page
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
            Panel1.Visible = false;
            Panel2.Visible = false;
        }
    }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        Insert();
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset_Items();
    }
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        if (FileUploader.HasFile)

            try
            {
                FileUploader.SaveAs(Server.MapPath("../news_image//") +
                FileUploader.FileName);
                Label8.Text = "File name: " +

                FileUploader.PostedFile.FileName + "<br>" +
                    //FileUploader.PostedFile.ContentLength + " kb<br>" +

                "Content type: " +
               FileUploader.PostedFile.ContentType + "<br><b>Uploaded Successfully";

                Label2.Text = "~/news_image/" + FileUploader.PostedFile.FileName;
            }
            catch (Exception ex)
            {
                Label8.Text = "ERROR: " + ex.Message.ToString();
            }
        else
        {
            Label8.Text = "You have not specified a file.";
        }
    }
    private void Insert()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString2"].ConnectionString.ToString();
        string sql;

        con = new SqlConnection(connection);
        con.ConnectionString = connection;
        con.Open();

        sql = "INSERT INTO tbl_News (NewTitle, NewsDetail, DateCreated, image, status) VALUES ('" + Text_Title.Text + "', '" + Text_Details.Text + "', '" + Text_Date.Text + "', '" + Label2.Text + "', '0')";

        comm = new SqlCommand(sql, con);
        comm.ExecuteNonQuery();
        con.Close();
        Reset_Items();
        Label_Messages.Text = "Thank You, Your Record Saved";
    }
    private void Reset_Items()
    {
        Text_Title.Text = "";
        Text_Details.Text = "";
        Text_Date.Text = "";
        Label2.Text = "";
        Label8.Text = "";
        Label_Messages.Text = "";
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
    }
    protected void Butt_Close_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
    }
}