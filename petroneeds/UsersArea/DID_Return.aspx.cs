using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data;
using System.Configuration;
using System.Collections;

public partial class UsersArea_DID_Return : System.Web.UI.Page
{
    
    public OdbcCommand comm = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter dadapter;
    public OdbcCommand odbccomm = null;
    public OdbcConnection odbccon = null;
    public OdbcDataAdapter odbcdadapter;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;

    //public static string EMPLOYEE_NO, DEPARTMENT_NO, MANAGER, SUPERVISOR;
    public static string EMPLOYEE_NO,FORMNO, EMSM, DEPARTMENT_NO, ICMANAGER, SUPERVISOR, SINMANAGER, MANAGER;
    

    DataSet dset, dset2, dataset;
    string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
    string sql;

    private string sortDirection;
    private int No;

    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        ICMANAGER = Request.QueryString["ICM"];
        MANAGER = Request.QueryString["MNG"];
        SINMANAGER = Request.QueryString["SMNG"];
        EMSM = Request.QueryString["EMS"];


        if (EMPLOYEE_NO == "" || EMPLOYEE_NO == null && DEPARTMENT_NO == "" || DEPARTMENT_NO == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                getMenu();
                GridViewBind();
                Panel1.Visible = false;
                //returnuser();
                UserDetails(); 

            }
        }
    }

    public void GridViewBind()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        //FORMNO=Request.QueryString["FORM_NO"];
        


           dadapter = new OdbcDataAdapter("SELECT DISTINCT ICT_Tele.FORM_NO,ICT_Tele.POSITION,ICT_Tele.FORM_DATE,ICT_Tele.USER_NAME , ICT_Tele.USER_ID ,ICT_Tele.USER_DEP FROM ICT_Tele,EMPLOYEES,DEPARTMENTS WHERE ICT_Tele.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_Tele.FORM_STATUS = '15' AND ICT_Tele.USER_DEP= DEPARTMENTS.DEP_NAME AND ICT_Tele.USER_ID = '" + EMPLOYEE_NO + "'", connectionString);

            dset = new DataSet();
            dadapter.Fill(dset);
            GridView1.DataSource = dset.Tables[0];
            GridView1.DataBind();
    
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridViewBind();
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new
            GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "YOUR RETURN REUESTS";
            HeaderCell.ColumnSpan = 8;
            HeaderGridRow.Cells.Add(HeaderCell);
            GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }

    public string sortExpression { get; set; }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Label_Message.Text = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.SelectedIndex == i)
            {
                string FORM_NO = GridView1.Rows[i].Cells[0].Text;
                string EMP_NO = GridView1.Rows[i].Cells[1].Text;
                TextBox1.Text = FORM_NO.ToString();
                TextBox2.Text = EMP_NO.ToString();

                UserDetails();
                Panel1.Visible = true;
               

            }
        }
    }

    void UserDetails()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

        odbccon = new OdbcConnection(connection);
        odbccon.ConnectionString = connection;


        odbcdadapter = new OdbcDataAdapter("SELECT ICT_TELE.FORM_NO,ICT_TELE.JUSTIFICATION,ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,ICT_TELE.SIM_TYPE,ICT_TELE.SIM_CEIL  FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'", connection);

        dataset = new DataSet();
        odbcdadapter.Fill(dataset);
        GridView2.DataSource = dataset.Tables[0];
        GridView2.DataBind();
        Comments_Field();
        

    }

    void Comments_Field()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        string sql = "SELECT ICT_TELE.GM_COMMENT , ICT_TELE.FORM_NO FROM ICT_TELE WHERE ICT_Tele.FORM_STATUS = '15'AND ICT_TELE.FORM_NO='" + TextBox1.Text + "'";
           
        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            TextBox3.Text = read[0].ToString();
        }
        cmd.Connection.Close();

    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        this.UserDetails();
       // GridView2.DataBind();
    }


    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        this.UserDetails();
    }



    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
                        GridViewRow row = GridView2.Rows[e.RowIndex];
                        int FORM_NO = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);
                       
                       // string FORM_NO = (row.FindControl("txtfo") as TextBox).Text;
                        string USERNAME = (row.FindControl("txtus") as TextBox).Text;
                        string DEP = (row.FindControl("txtde") as TextBox).Text;
                        string JUST = (row.FindControl("txtju") as TextBox).Text;
          
                 ////for (int i = 0; i < GridView2.Rows.Count; i++)

                     

              rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
              connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

               //string sql = "UPDATE ICT_EDETAIL SET FORM_NO='" + FORM_NO + " ', EQ_NAME='" + EQ_NAME + "', QUANTITY='" + QUANTITY + "' , DESCRIPTION='" + DESCRIPTION + "' WHERE REQ_NO='" + REQ_NO + "' AND FORM_NO='" + FORM_NO + "'";
              string sql = "UPDATE ICT_TELE SET USER_NAME='" + USERNAME + "' , USER_DEP='" + DEP + "' , JUSTIFICATION='" + JUST + "' WHERE FORM_NO='" + FORM_NO + "'"; 

                con = new OdbcConnection(connection);
                con.ConnectionString = connection;
                con.Open();
                comm = new OdbcCommand(sql, con);

               odbcdadapter = new OdbcDataAdapter(sql, connection);

               //OdbcParameter req = new OdbcParameter(":REQN",REQNO); 
               //cmd.Parameters.Add("?comment", OdbcType.VarChar).Value = (((TextBox)GridView2.Rows[i].FindControl("TextBox4")).Text);
               //comm.Parameters.AddWi.thValue("?", REQ_NO);
               //comm.Parameters.AddWithValue("?FORM_NO", FORM_NO);
               //comm.Parameters.AddWithValue("?EQ_NAME", EQ_NAME);
               //comm.Parameters.AddWithValue("?QUANTITY", QUANTITY);
               //comm.Parameters.AddWithValue("?DESCRIPTION","OdbcType.VarChar(DESCRIPTION)"); 

                comm.Connection = con;
               
                comm.ExecuteNonQuery();
                con.Close();
                GridView2.EditIndex = -1;
                this.UserDetails();

    }


    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        //for (int i = 1; i < GridView2.Rows.Count; i++)
        //{
            rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
            connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
            GridViewRow row = GridView2.Rows[e.RowIndex];
            int REQ_NO = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);
                       
            string sql = "DELETE FROM ICT_EDETAIL WHERE REQ_NO='" + REQ_NO + "'";


            con = new OdbcConnection(connection);
            con.ConnectionString = connection;
            con.Open();
            comm = new OdbcCommand(sql, con);
      
            //odbcdadapter = new OdbcDataAdapter(sql, connection);


            comm.Connection = con;

        //}
      
        comm.ExecuteNonQuery();
        con.Close();
        GridView2.EditIndex = -1;
        this.UserDetails();
      
    }



    private void getMenu()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString2"].ConnectionString.ToString();

        conn = new SqlConnection(connection);
        conn.ConnectionString = connection;
        conn.Open();

        DataTable table = new DataTable();


        string sql = "Select * from tbl_WebMenu INNER JOIN User_Check ON (tbl_WebMenu.MenuID = User_Check.MenuID)" +
            //"AND (User_Check.MenuID = tbl_WebMenu.ParentID)" +
                      "AND (User_Check.EmpNumber = '" + EMPLOYEE_NO + "' ) AND (User_Check.STATUS = '" + 1 + "')";

        SqlDataAdapter da = new SqlDataAdapter(sql, conn);

        da.Fill(table);
        DataView view = new DataView(table);
        view.RowFilter = "ParentID=0";
        foreach (DataRowView row in view)
        {
            MenuItem menuItem = new MenuItem(row["MenuName"].ToString(),
            row["MenuID"].ToString());
            menuItem.NavigateUrl = row["MenuID"].ToString() + row["MenuLocation"] + "?EMPLOYEE_NO=" + EMPLOYEE_NO.ToString() + "&DEP_NO=" + DEPARTMENT_NO.ToString();
            menuBar.Items.Add(menuItem);
            AddChildItems(table, menuItem);
        }
        conn.Close();
    }

    private void AddChildItems(DataTable table, MenuItem menuItem)
    {
        DataView viewItem = new DataView(table);
        viewItem.RowFilter = "ParentID=" + menuItem.Value;
        foreach (DataRowView childView in viewItem)
        {
            MenuItem childItem = new MenuItem(childView["MenuName"].ToString(),
            childView["MenuID"].ToString());
            // childItem.NavigateUrl = childView["MenuLocation"].ToString();
            childItem.NavigateUrl = childView["MenuLocation"].ToString() + "?EMPLOYEE_NO=" + EMPLOYEE_NO.ToString() + "&DEP_NO=" + DEPARTMENT_NO.ToString();

            menuItem.ChildItems.Add(childItem);
            AddChildItems(table, childItem);
        }
    }

    public virtual bool AllowPaging { get; set; }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        requestUpdate(); 

        //SendEMail();
        Panel1.Visible = false;
        Reset();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);

    }

     private void Reset()
    {    
        TextBox1.Text = "";
        TextBox2.Text = "";
    }



     protected void requestUpdate()
     {
         //date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

         EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
         DEPARTMENT_NO = Request.QueryString["DEP_NO"];
         rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
         connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

         if (TextBox1.Text != "")
         {

             //sql = "UPDATE ICT_MSTR SET FORM_STATUS = '1' WHERE FORM_NO = '" + TextBox1.Text + "'";
             sql = " UPDATE ICT_TELE SET FORM_STATUS = '8' WHERE FORM_NO = '" + TextBox1.Text + "'"; 
             con = new OdbcConnection(connection);
             con.ConnectionString = connection;
             con.Open();

             comm = new OdbcCommand(sql, con);
             comm.ExecuteNonQuery();
             con.Close();

             SendEMail();

         }
         else
         {
         }
     }

     public static string EmpName, EmpEmail, Depart, EmpName2;
    public string EMPNUMBER, DEPARTMENTNO, EMPNAME, EMPEMAIL, ACTIONDATE, REQUESTNAME, USERNAME;
    public void SendEMail()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO IN " +
            "(SELECT MNG FROM EMP_MNG WHERE EMPLOYEE_NO = '" + TextBox2.Text + "')";


        string sql2 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + TextBox2.Text + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        read.Read();
        read2.Read();

        if (read.HasRows)
        {
            EmpName = read["FULL_USER_NAME"].ToString();
            EmpEmail = read["EMAIL"].ToString();
            Depart = read["DEP_NAME"].ToString();
           
        }
        if (read2.HasRows)
        {

         EmpName2 = read2["FULL_USER_NAME"].ToString();
        }


        //USERNOTIFICATIONEMAIL(EMPNAME, EMPEMAIL);
        Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Direct International Dialing Request (DR)&USERNAMESREQ=" + EmpName2 + "");
        //Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=&DEP_NO=&FULL_USER_NAME=" + EmpName + "&EMAIL=portal@petroneeds.co&DEP_NAME=" + Depart + "&DATE=" + date + "&REQNAME=Travel Request (TRF)&USERNAMESREQ=" + Text_Name.Text + "");

        cmd.Connection.Close();
    }



}