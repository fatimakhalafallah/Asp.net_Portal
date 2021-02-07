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

public partial class UsersArea_BussinessCard_Approve : System.Web.UI.Page
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
    public static string EMPLOYEE_NO, ADMINI, DEPARTMENT_NO,MANAGER ,HRM;
    public static string EmpName, EmpEmail, Depart, EmId, Status, EmpName2, EmpEmail2, EmpName3, EmpEmail3, EmpName4, EmpEmail4, EmpName5, EmpEmail5;
    
    DataSet dset, dset2, dataset;
    string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
    string sql;

    private string sortDirection;
    private int No;

    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        ADMINI = Request.QueryString["ADMIN"];
        MANAGER = Request.QueryString["MNG"];
        HRM = Request.QueryString["HR"];

         

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


        ADMINI = Request.QueryString["ADMIN"];
        MANAGER = Request.QueryString["MNG"];
        HRM = Request.QueryString["HR"];

        if (MANAGER == EMPLOYEE_NO & MANAGER != HRM & MANAGER != ADMINI)
        { No = 3; }
        else
       if (HRM == EMPLOYEE_NO)
            { No = 1; }
       else
        if (ADMINI == EMPLOYEE_NO)
        {No = 2; }

        // Manager , HR , Admin complete 
        switch (No)
        {
            case 1:

                dadapter = new OdbcDataAdapter("SELECT DISTINCT BUSINESS_CARD.REQ_NO , BUSINESS_CARD.EMPLOYEE_NO, BUSINESS_CARD.JOB_NAME , DEPARTMENTS.DEP_NAME , BUSINESS_CARD.EMP_NAME, BUSINESS_CARD.REQ_DATE FROM BUSINESS_CARD,REQUEST_ACTORS,DEPARTMENTS,EMPLOYEES WHERE BUSINESS_CARD.EMPLOYEE_NO=EMPLOYEES.EMPLOYEE_NO AND (BUSINESS_CARD.STATUS = '4' OR(BUSINESS_CARD.EMPLOYEE_NO IN(SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG='" + HRM + "')) AND BUSINESS_CARD.STATUS = '1' )  AND BUSINESS_CARD.DEP_NO = DEPARTMENTS.DEP_NO  AND REQUEST_ACTORS.REQUEST_TYPE_ID = '12' AND REQUEST_ACTORS.EMPLOYEE_NO = '" + HRM + "'", connectionString); 

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "6"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "7"));
               
                break;

            case 2:

                dadapter = new OdbcDataAdapter("SELECT DISTINCT BUSINESS_CARD.REQ_NO ,BUSINESS_CARD.EMPLOYEE_NO ,BUSINESS_CARD.JOB_NAME , DEPARTMENTS.DEP_NAME , BUSINESS_CARD.EMP_NAME, BUSINESS_CARD.REQ_DATE FROM BUSINESS_CARD,REQUEST_ACTORS,DEPARTMENTS,EMPLOYEES WHERE BUSINESS_CARD.EMPLOYEE_NO=EMPLOYEES.EMPLOYEE_NO AND BUSINESS_CARD.STATUS = '6'  AND BUSINESS_CARD.DEP_NO = DEPARTMENTS.DEP_NO  AND REQUEST_ACTORS.REQUEST_TYPE_ID = '13' AND REQUEST_ACTORS.EMPLOYEE_NO = '" + ADMINI + "'", connectionString);  

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

                
                break;

            case 3:

                dadapter = new OdbcDataAdapter("SELECT DISTINCT BUSINESS_CARD.REQ_NO , BUSINESS_CARD.EMPLOYEE_NO,DEPARTMENTS.DEP_NAME ,BUSINESS_CARD.JOB_NAME ,BUSINESS_CARD.EMP_NAME, BUSINESS_CARD.REQ_DATE FROM BUSINESS_CARD,REQUEST_ACTORS,DEPARTMENTS,EMPLOYEES WHERE BUSINESS_CARD.EMPLOYEE_NO=EMPLOYEES.EMPLOYEE_NO AND BUSINESS_CARD.STATUS = '1' AND BUSINESS_CARD.DEP_NO = DEPARTMENTS.DEP_NO  AND BUSINESS_CARD.EMPLOYEE_NO IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG='" + MANAGER + "')", connectionString); 



                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "4")); //Pending 1 
                RadioButtonList1.Items.Add(new ListItem("Reject", "5"));
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
            HeaderCell.Text = "CARD REQUESTS";
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

    /*void MainData()
    {

        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        sql = "SELECT SEC_NO, DEP_NO FROM BUSINESS_CARD WHERE REQ_NO='" + TextBox1.Text + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            TextBox4.Text = read["DEP_NO"].ToString();
            TextBox6.Text = read["SEC_NO"].ToString();

        }
            DepDetail();      
    }

    void DepDetail()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        string sql = "SELECT DEP_NAME  FROM DEPARTMENTS WHERE DEP_NO='" + TextBox4.Text + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            dep.Text= read["DEP_NAME"].ToString();

        }
        SectionDE(); 
    }

    void SectionDE()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;


        string sql = "SELECT PROJ_NAME  FROM PROJECT_CODE WHERE PROJ_NO='" + TextBox6.Text + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            sec.Text = read["PROJ_NAME"].ToString();
        }
    }*/

    void UserDetails()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

        odbccon = new OdbcConnection(connection);
        odbccon.ConnectionString = connection;

        odbcdadapter = new OdbcDataAdapter("SELECT DEP_Name, REQ_NO, SEC_NO , JOB_NAME, TEL1, TEL2, EMAIL, QTY, PHONE , EXTE FROM BUSINESS_CARD WHERE REQ_NO='" + TextBox1.Text + "'", connection); 
        
        dataset = new DataSet();
        odbcdadapter.Fill(dataset);
        GridView2.DataSource = dataset.Tables[0];
        GridView2.DataBind();
        //BC(); 
    
    
   }
    /*void BC()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        ADMINI = Request.QueryString["ADMIN"];
        MANAGER = Request.QueryString["MNG"];
        HRM = Request.QueryString["HR"];
        if (EMPLOYEE_NO == ADMINI )
        {
            Butt_Complete.Visible = true; 
        }
      //Butt_Complete


    }*/

    public virtual bool AllowPaging { get; set; }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        UpdateFormStatus();
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

        ADMINI = Request.QueryString["ADMIN"];
        MANAGER = Request.QueryString["MNG"];
        HRM = Request.QueryString["HR"];

   

        if (TextBox1.Text != "")
        {

            if (MANAGER == EMPLOYEE_NO & MANAGER != ADMINI & MANAGER != HRM)
            {
                sql = "UPDATE BUSINESS_CARD SET STATUS = '" + RadioButtonList1.SelectedValue + "',MAN_APPROVE='" + MANAGER + "', MAN_DATE = '" + date + "' WHERE REQ_NO='" + TextBox1.Text + "'";
               
                con = new OdbcConnection(connection);
                con.ConnectionString = connection;
                con.Open();

                comm = new OdbcCommand(sql, con);
                comm.ExecuteNonQuery();
                con.Close();

                Label_Message.Text = "Successfully...";
                Status = RadioButtonList1.SelectedItem.Text.ToString();
                SendEMail(Status, 1);
                //dropsend(); 
            }
            else
                if (HRM == EMPLOYEE_NO)
                {

                    sql = "UPDATE BUSINESS_CARD SET STATUS = '" + RadioButtonList1.SelectedValue + "',HR_APPROVE='" + HRM + "', HR_DATE = '" + date + "'  WHERE REQ_NO='" + TextBox1.Text + "'";
               
                   // HR_APPROVE, HR_DATE
                    con = new OdbcConnection(connection);
                    con.ConnectionString = connection;
                    con.Open();

                    comm = new OdbcCommand(sql, con);
                    comm.ExecuteNonQuery();
                    con.Close();
                    //Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    //Reset();
                    //Response.Write(HRMANAGER);
                    Label_Message.Text = "Successfully...";
                    Status = RadioButtonList1.SelectedItem.Text.ToString();
                    SendEMail(Status, 2);
                }
                else

           if (ADMINI == EMPLOYEE_NO)
            {

                sql = "UPDATE BUSINESS_CARD SET STATUS = '8', AS_APPROVE='" + ADMINI + "', AS_DATE = '" + date + "' WHERE REQ_NO='" + TextBox1.Text + "'";
               

                con = new OdbcConnection(connection);
                con.ConnectionString = connection;
                con.Open();

                comm = new OdbcCommand(sql, con);
                comm.ExecuteNonQuery();
                con.Close();
               
               
               
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




    protected void Butt_Complete_Click(object sender, EventArgs e)
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

        sql = "UPDATE BUSINESS_CARD SET STATUS = '8' WHERE REQ_NO='" + TextBox1.Text + "'";

        con = new OdbcConnection(connection);
        con.ConnectionString = connection;
        con.Open();

        comm = new OdbcCommand(sql, con);
        comm.ExecuteNonQuery();
        con.Close();
        
    }



    public void SendEMail(string Status, int UserCheck)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        ADMINI = Request.QueryString["ADMIN"];
        MANAGER = Request.QueryString["MNG"];
        HRM = Request.QueryString["HR"];
        

        string date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        // Requester 
        string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + TextBox2.Text + "'";

        
        //adminstrati 
        string sql2 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + ADMINI + "'";

        // Manager 
        string sql3 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + MANAGER + "'";

        // HRM

        string sql5 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
           "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
           "USERS_INFORMATIONS.EMPLOYEE_NO = '" + HRM + "'"; 




        OdbcConnection conn = new OdbcConnection(connectionString);

        OdbcCommand cmd = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);
        OdbcCommand cmd5 = new OdbcCommand(sql5, conn); 



        cmd.Connection.Open();

        OdbcDataReader read = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        OdbcDataReader read3 = cmd3.ExecuteReader();
        OdbcDataReader read5 = cmd5.ExecuteReader(); 


        read.Read();
        read2.Read();
        read3.Read();
        read5.Read(); 


        if (read.HasRows) // Requester 
        {
            EmpName = read["FULL_USER_NAME"].ToString();
            EmpEmail = read["EMAIL"].ToString();
            Depart = read["DEP_NAME"].ToString();
        }
        if (read2.HasRows)  //  Admin
        {
            EmpName2 = read2["FULL_USER_NAME"].ToString();
            EmpEmail2 = read2["EMAIL"].ToString();

        }
        if (read3.HasRows)   //  Manager
        {
            EmpName3 = read3["FULL_USER_NAME"].ToString();
            EmpEmail3 = read3["EMAIL"].ToString();

        }
  
        if (read5.HasRows)// HR 
        {
            EmpName5= read5["FULL_USER_NAME"].ToString();
            EmpEmail5 = read5["EMAIL"].ToString(); 
        }

       
        if (UserCheck == 1) //Manager
        {
      
            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&comment=" +TextBox1+ "&DATE=" + date + "" +
                  "&ApprovalName=" + EmpName5 + "&ApprovalEmail=" + EmpEmail5 + "&REQNAME=Business Card Request(BC)&AUTHORNAME=" + EmpName3 + "");
        }

        if (UserCheck == 2) // HR  
        {

            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
               "&ApprovalName=" + EmpName2 + "&ApprovalEmail=" + EmpEmail2 + "&REQNAME= Business Card Request(BC)&AUTHORNAME=" + EmpName5 + "");

        }
 
          
        cmd.Connection.Close(); 
    }




   
}