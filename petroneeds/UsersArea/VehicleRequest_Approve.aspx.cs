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


public partial class UsersArea_VehicleRequest_Approve : System.Web.UI.Page
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
    public static string EMPLOYEE_NO, ADMIN, DEPARTMENT_NO,SUPERVISOR;
    public static string EmpName, EmpEmail, Depart, EmId, Status, EmpName2, EmpEmail2, EmpName3, EmpEmail3, EmpName6, EmpEmail6, ITEMP, ITEmail, EmpName4, EmpEmail4;
    
    DataSet dset, dset2, dataset;
    string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
    string sql;

    private string sortDirection;
    private int No;

    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        SUPERVISOR = Request.QueryString["SUPER"];
        ADMIN = Request.QueryString["ADMIN"];
        
        
       
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
                
            }
        }
    }
    public void GridViewBind()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

    
        SUPERVISOR = Request.QueryString["SUPER"];
        ADMIN = Request.QueryString["ADMIN"];


        if (SUPERVISOR == EMPLOYEE_NO)
        { No=1;}
        if (ADMIN == EMPLOYEE_NO) 
        { No = 2; }
        
          
        switch (No)
        {
            case 1:
                dadapter = new OdbcDataAdapter("SELECT ADMIN_VEHICLE.REQ_NO , ADMIN_VEHICLE.EMPLOYEE_ID ,ADMIN_VEHICLE.DEP_NAME  ,ADMIN_VEHICLE.REQ_DATE , ADMIN_VEHICLE.POSITION ,  EMPLOYEES.EMPLOYEE_NAME  FROM EMPLOYEES , ADMIN_VEHICLE WHERE ADMIN_VEHICLE.EMPLOYEE_ID=EMPLOYEES.EMPLOYEE_NO AND STATUS='1' AND ADMIN_VEHICLE.EMPLOYEE_ID IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE SUPER='" + SUPERVISOR + "')", connectionString);   


                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();
               
                RadioButtonList1.Items.Add(new ListItem("Approve", "2"));//pending 1
                RadioButtonList1.Items. Add(new ListItem("Reject", "3"));
                break;
                

            case 2:

                dadapter = new OdbcDataAdapter("SELECT ADMIN_VEHICLE.REQ_NO , ADMIN_VEHICLE.DEP_NAME ,ADMIN_VEHICLE.EMPLOYEE_ID ,ADMIN_VEHICLE.REQ_DATE, ADMIN_VEHICLE.POSITION ,  EMPLOYEES.EMPLOYEE_NAME  FROM EMPLOYEES , ADMIN_VEHICLE ,REQUEST_ACTORS WHERE ADMIN_VEHICLE.EMPLOYEE_ID=EMPLOYEES.EMPLOYEE_NO AND ADMIN_VEHICLE.STATUS='2' AND REQUEST_ACTORS.REQUEST_TYPE_ID='45' AND REQUEST_ACTORS.EMPLOYEE_NO='" + ADMIN + "'", connectionString);  

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();
              
                RadioButtonList1.Items.Add(new ListItem("Approve", "4"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "5"));
                RadioButtonList1.Items.Add(new ListItem("Return", "6"));// RETUTM 
                break;
                

            default:
                Label_Message.Text = "There are no Requests...";
                //Label_Message.Text = "You aren't Authorized to see this page ...";
                break;
        }
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
            HeaderCell.Text = "List of Requests";
            HeaderCell.ColumnSpan = 8;
            HeaderGridRow.Cells.Add(HeaderCell);
            GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }
    public string sortExpression { get; set; }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label_Message.Text = "";
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
                //returnuser(); 
                //UserList();

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

        odbcdadapter = new OdbcDataAdapter("SELECT REQ_NO ,DESTINATION,PURPOSE,DEPAR_DAY,DEPAR_TIME,DEPAR_APP FROM ADMIN_VEHICLE WHERE ADMIN_VEHICLE.REQ_NO='" + TextBox1.Text + "'", connection);
      

        //REQ_NO, EMPLOYEE_ID, POSITION, DEP_NO, DESTINATION, PURPOSE, DEPAR_DAY, DEPAR_TIME, DEPAR_APP, DEP_NAME, STATUS, REQ_DATE
        dataset = new DataSet();
        odbcdadapter.Fill(dataset);
        GridView2.DataSource = dataset.Tables[0];
        GridView2.DataBind();
        D_comment();
       

    }

    void D_comment()
    {

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];


        
        ADMIN = Request.QueryString["ADMIN"];


        if (ADMIN == EMPLOYEE_NO)
                {

                    string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
                    EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
                    DEPARTMENT_NO = Request.QueryString["DEP_NO"];
                    sql = "SELECT SUPER_COMMENT FROM ADMIN_VEHICLE WHERE ADMIN_VEHICLE.REQ_NO='" + TextBox1.Text + "'";
                     //  ADMIN_VEHICLE

                    // ,, ICT_TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION

                    OdbcConnection conn = new OdbcConnection(connectionString);
                    OdbcCommand cmd = new OdbcCommand(sql, conn);

                    cmd.Connection.Open();
                    OdbcDataReader read = cmd.ExecuteReader();
                    read.Read();

                    if (read.HasRows)
                    {

                        Super_c.Text= read["SUPER_COMMENT"].ToString();
                        Super_l.Visible = true;
                        Super_c.Visible = true; 
                    }
                    cmd.Connection.Close();

                }

    }



    public virtual bool AllowPaging { get; set; }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        UpdateFormStatus();
        //Status = RadioButtonList1.SelectedItem.Text.ToString();
        //SendEMail(Status);
        Panel1.Visible = false;
        Reset();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);



    }
    private void UpdateFormStatus()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql, date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];


        SUPERVISOR = Request.QueryString["SUPER"];
        ADMIN = Request.QueryString["ADMIN"]; ;



        if (TextBox1.Text != "")
        {

            if (SUPERVISOR == EMPLOYEE_NO)
            {
                sql = "UPDATE ADMIN_VEHICLE SET STATUS = '" + RadioButtonList1.SelectedValue + "', SUPER_COMMENT = '" + Text_COMMENT.Text + "' " +
                      ", SUPER_ID = '" + SUPERVISOR + "', SUPER_DATE = '" + date + "' WHERE REQ_NO = '" + TextBox1.Text + "'";


                con = new OdbcConnection(connection);
                con.ConnectionString = connection;
                con.Open();

                comm = new OdbcCommand(sql, con);
                comm.ExecuteNonQuery();
                con.Close();

                Label_Message.Text = "Successfully...";
                SendEMail(Status, 2);

            }
            else
                if (ADMIN == EMPLOYEE_NO)
                {
                    sql = "UPDATE ADMIN_VEHICLE SET STATUS = '" + RadioButtonList1.SelectedValue + "', ADMIN_COMMENT = '" + Text_COMMENT.Text + "' " +
                     ", ADMIN_ID = '" + ADMIN + "', ADMIN_DATE = '" + date + "' WHERE REQ_NO = '" + TextBox1.Text + "'";

                   // SMNG_ID, SMNG_DATE, SMNG_COMMENT

                    con = new OdbcConnection(connection);
                    con.ConnectionString = connection;
                    con.Open();

                    comm = new OdbcCommand(sql, con);
                    comm.ExecuteNonQuery();
                    con.Close();

                    Label_Message.Text = "Successfully...";
                    Status = RadioButtonList1.SelectedItem.Text.ToString();
                    SendEMail(Status, 3);

                }
               
        }
        else
        {
            Reset();
            Panel1.Visible = false;
        }
    }

   



    private void Reset()
    {
        //Text_Num.Text = "";
        //Text_Request.Text = "";
        //Text_StDate.Text = "";
        //Text_EnDate.Text = "";
        //Text_NumOfDays.Text = "";
        //Text_Leave_Name.Text = "";
        //Text_Comments.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset();
        Panel1.Visible = false;
    }
    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {
        //DetailsView1.PagerSettings.Mode = PagerButtons.NextPreviousFirstLast;
        //DetailsView1.PageIndex = e.NewPageIndex;
        //UserDetails();
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







    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Status = RadioButtonList1.SelectedItem.ToString();
    }

    void dropsend()
    {

       

    }

    public void SendEMail(string Status, int UserCheck)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;


        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];


        SUPERVISOR = Request.QueryString["SUPER"];
        ADMIN = Request.QueryString["ADMIN"]; ;
       

        string date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        // Requester 
        string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + TextBox2.Text + "'";

        // SUPER 
        string sql2 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + SUPERVISOR + "'";
       

        // ADMIN
        string sql3 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + ADMIN + "'";
        
       




        OdbcConnection conn = new OdbcConnection(connectionString);

        OdbcCommand cmd = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);
       



        cmd.Connection.Open();

        OdbcDataReader read = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        OdbcDataReader read3 = cmd3.ExecuteReader();
       


        read.Read();
        read2.Read();
        read3.Read();
        


        if (read.HasRows) // Requester 
        {
            EmpName = read["FULL_USER_NAME"].ToString();
            EmpEmail = read["EMAIL"].ToString();
            Depart = read["DEP_NAME"].ToString();
        }
        if (read2.HasRows)  // SUPER
        {
            EmpName2 = read2["FULL_USER_NAME"].ToString();
            EmpEmail2 = read2["EMAIL"].ToString();

        }
        if (read3.HasRows)   // ADMIN
        {
            EmpName3 = read3["FULL_USER_NAME"].ToString();
            EmpEmail3 = read3["EMAIL"].ToString();

        }
       

   

        if (UserCheck == 2) // if  SUPER  
        {

            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
               "&ApprovalName=" + EmpName3 + "&ApprovalEmail=" + EmpEmail3 + "&REQNAME=Vehicle Request (VR)&AUTHORNAME=" + EmpName2 + "");

        }

        if (UserCheck == 3) // if ADMIN

            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
               "&ApprovalName=&ApprovalEmail=&REQNAME=Vehicle Request (VR)&AUTHORNAME=" + EmpName3 + "");

       
        cmd.Connection.Close(); 

    }


    
    

}