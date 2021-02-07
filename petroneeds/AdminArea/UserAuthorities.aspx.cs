using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Configuration;

public partial class AdminArea_UserAuthorities : System.Web.UI.Page
{
    public SqlCommand comm = null;
    public SqlConnection con = null;
    public SqlDataAdapter adapter = null;

    public OdbcCommand odbccomm = null;
    public OdbcConnection odbccon = null;
    public OdbcDataAdapter odbcadapter = null;

    public DataSet dataset = null;
    public DataSet dset = null;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            UsersList();
        }
    }
    protected void Butt_Save_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue != "0")
        {
            Insert();
        }
        else
        {
            Label_Messages0.Text = "Please select Name name from up menu";
        }
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset_Items();
    }
    protected void Butt_Search_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue != "0")
        {
            UpdateUser();
            //GridView1.Visible = true;
        }
    }
    protected void Link_New_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        Panel3.Visible = true;
        Panel4.Visible = false;
        Reset_Items();
        UsersList();
        CheckBoxListItems();
    }
    protected void Link_Update_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        Panel3.Visible = true;
        Panel4.Visible = false;
        Reset_Items();
        UsersList();
        CheckBoxListItems2();
    }
    protected void Link_Edit_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;
        Panel4.Visible = true;
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Butt_Reset2_Click(object sender, EventArgs e)
    {
        Reset_Items();
    }
    protected void Butt_Update_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue != "0")
        {
            Update();
        }
        else
        {
            Label_Messages0.Text = "Please select Name name from up menu";
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

        int x = 0;

        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            x++;
            if (CheckBoxList1.Items[i].Selected)
            {
                sql = "IF NOT EXISTS (SELECT EmpNumber, MenuID, Status FROM User_Check WHERE MenuID = '" + CheckBoxList1.Items[i].Value + "' " +
                      "AND EmpNumber = '" + DropDownList1.SelectedValue + "') " +
                      "INSERT INTO User_Check (EmpNumber, MenuID, Status) VALUES " +
                      "('" + DropDownList1.SelectedValue + "', '" + CheckBoxList1.Items[i].Value + "', '1')";

                comm = new SqlCommand(sql, con);
                comm.ExecuteNonQuery();
            }
        }
        con.Close();
        Reset_Items();
        Label_Messages.Text = "Thank you, Your record/s was saved...";
    }
    private void Update()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString2"].ConnectionString.ToString();
        string sql;

        con = new SqlConnection(connection);
        con.ConnectionString = connection;
        con.Open();

        int x = 0;

        for (int i = 0; i < CheckBoxList2.Items.Count; i++)
        {
            x++;
            if (CheckBoxList2.Items[i].Selected)
            {
                  //sql = "UPDATE User_Check SET MenuID = '" + CheckBoxList2.Items[i].Value + "', Status = '1' WHERE "+
                  //  " EmpNumber = '" + DropDownList1.SelectedValue + "' AND MenuID = '" + CheckBoxList2.Items[i].Value + "'";

                sql = "IF NOT EXISTS (SELECT EmpNumber, MenuID, Status FROM User_Check WHERE MenuID = '" + CheckBoxList2.Items[i].Value + "' " +
                     "AND EmpNumber = '" + DropDownList1.SelectedValue + "') " +
                     "INSERT INTO User_Check (EmpNumber, MenuID, Status) VALUES " +
                     "('" + DropDownList1.SelectedValue + "', '" + CheckBoxList2.Items[i].Value + "', '1')";

                comm = new SqlCommand(sql, con);
                comm.ExecuteNonQuery();  
            }
        }
        con.Close();
        Reset_Items();
        Label_Messages0.Text = "Thank you, Your record/s was updated...";
    }
    private void UsersList()
    {
        DropDownList1.Items.Clear();
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

        odbccon = new OdbcConnection(connection);
        odbccon.ConnectionString = connection;
        odbccon.Open();

        dataset = new DataSet();
        odbccomm = new OdbcCommand("SELECT EMPLOYEE_NO, FULL_USER_NAME FROM USERS_INFORMATIONS WHERE ACTIVE = '1' ORDER BY FULL_USER_NAME ASC", odbccon);
        odbcadapter = new OdbcDataAdapter(odbccomm);
        odbcadapter.Fill(dataset);

        DropDownList1.DataSource = dataset;
        DropDownList1.DataTextField = "FULL_USER_NAME";
        DropDownList1.DataValueField = "EMPLOYEE_NO";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("<<<Select>>>", "0"));
        //DropDownList1.SelectedIndex = 0;
        //DropDownList1.SelectedValue = "0";
        DropDownList1.SelectedItem.Value = "0";
    }
    private void CheckBoxListItems()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString2"].ConnectionString.ToString();

        con = new SqlConnection(connection);
        con.ConnectionString = connection;
        con.Open();

        dataset = new DataSet();
        comm = new SqlCommand("SELECT MenuName, MenuID, ParentID FROM tbl_WebMenu", con);
        adapter = new SqlDataAdapter(comm);
        adapter.Fill(dataset);

        CheckBoxList1.DataSource = dataset;
        CheckBoxList1.DataTextField = "MenuName";
        CheckBoxList1.DataValueField = "MenuID";
        //CheckBoxList1.Items[].FindByValue(0) = "ParentID";
        ////CheckBoxList1.SelectedIndex.CompareTo("ParentID");
        CheckBoxList1.DataBind();

        if (CheckBoxList1.DataValueField.Length == 1)
        {
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                CheckBoxList1.Items[i].Selected = true;
            }
        }
    }
    private void CheckBoxListItems2()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString2"].ConnectionString.ToString();

        con = new SqlConnection(connection);
        con.ConnectionString = connection;
        con.Open();

        dataset = new DataSet();
        comm = new SqlCommand("SELECT MenuName, MenuID, ParentID FROM tbl_WebMenu", con);
        adapter = new SqlDataAdapter(comm);
        adapter.Fill(dataset);

        CheckBoxList2.DataSource = dataset;
        CheckBoxList2.DataTextField = "MenuName";
        CheckBoxList2.DataValueField = "MenuID";
        //CheckBoxList1.Items[].FindByValue(0) = "ParentID";
        ////CheckBoxList1.SelectedIndex.CompareTo("ParentID");
        CheckBoxList2.DataBind();

        if (CheckBoxList2.DataValueField.Length == 1)
        {
            for (int i = 0; i < CheckBoxList2.Items.Count; i++)
            {
                CheckBoxList2.Items[i].Selected = true;
            }
        }
    }
    private void Reset_Items()
    {
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                CheckBoxList1.SelectedItem.Selected = false;
            }
        }
        for (int i = 0; i < CheckBoxList2.Items.Count; i++)
        {
            if (CheckBoxList2.Items[i].Selected)
            {
                CheckBoxList2.SelectedItem.Selected = false;
            }
        }
        Label_Messages.Text = "";
        Label_Messages0.Text = "";
        UsersList();
        //GridView1.DataSource = null;
        //GridView1.DataBind();
    }
    /* public void RetriveData()
     {
         string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

         string sql = "SELECT (EmpNumber, MenuID) FROM User_Check";

         OdbcConnection conn = new OdbcConnection(connectionString);
         OdbcCommand cmd = new OdbcCommand(sql, conn);
   
         cmd.Connection.Open();
         OdbcDataReader read = cmd.ExecuteReader();
         read.Read();

         if (read.HasRows)
         {
             Text_Name.Text = "Welcome Mr/Mrs. " + read["EmpNumber"].ToString();
             Text_E_Mail.Text = "Your E-mail is " + read["MenuID"].ToString();
         }
         else
         {

         }
         cmd.Connection.Close();
     }*/

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString2"].ConnectionString.ToString();
        string sql;

        con = new SqlConnection(connection);
        con.ConnectionString = connection;
        con.Open();

        sql = "DELETE FROM User_Check WHERE number ='" + GridView1.DataKeys[e.RowIndex].Values[0].ToString() + "'";

        //sql = "DELETE FROM User_Check WHERE User_Check.EmpNumber = '" + DropDownList1.SelectedValue + "' AND number ='" + GridView1.DataKeys[e.RowIndex].Values[0].ToString() + "'";

        //SELECT User_Check.EmpNumber, User_Check.MenuID, tbl_WebMenu.MenuName  FROM tbl_WebMenu, User_Check WHERE " +
        //"User_Check.MenuID = tbl_WebMenu.MenuID AND User_Check.EmpNumber = '" + DropDownList1.SelectedValue + "' " +
        //"ORDER BY User_Check.MenuID ASC", connectionString);

        SqlCommand comm = new SqlCommand(sql, con);

        //comm.CommandText = "DELETE FROM User_Check WHERE number ='" + GridView1.DataKeys[e.RowIndex].Values[0].ToString() + "'";    
        //comm.Connection.Open();
        //con.Open();

        comm.ExecuteNonQuery();
        UpdateUser();
    }
    public void UpdateUser()
    {
        GridView1.DataSource = null;
        GridView1.DataBind();

        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString2"].ConnectionString;

        SqlConnection conn = new SqlConnection(connectionString);

        adapter = new SqlDataAdapter("SELECT User_Check.number, User_Check.MenuID, tbl_WebMenu.MenuName  FROM tbl_WebMenu, User_Check WHERE " +
        "User_Check.MenuID = tbl_WebMenu.MenuID AND User_Check.EmpNumber = '" + DropDownList1.SelectedValue + "' " +
        "ORDER BY User_Check.MenuID ASC", connectionString);
        dset = new DataSet();

        adapter.Fill(dset);
        GridView1.DataSource = dset.Tables[0];
        GridView1.DataBind();
    }
}