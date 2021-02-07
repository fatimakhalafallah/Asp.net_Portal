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


public partial class UsersArea_DID_Approve : System.Web.UI.Page
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
    public static string EMPLOYEE_NO, GM, EMNG, DEPARTMENT_NO, ICMANAGER, SUPERVISOR, SINMANAGER, MANAGER;
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

        ICMANAGER = Request.QueryString["ICM"];
        MANAGER = Request.QueryString["MNG"];
        GM = Request.QueryString["GM"];
        SINMANAGER = Request.QueryString["SMNG"];
        EMNG = Request.QueryString["EMS"];

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

        ICMANAGER = Request.QueryString["ICM"];
        MANAGER = Request.QueryString["MNG"];
        GM = Request.QueryString["GM"];
        SINMANAGER = Request.QueryString["SMNG"];
        EMNG = Request.QueryString["EMS"];

        if (MANAGER == EMPLOYEE_NO & GM != EMPLOYEE_NO & ICMANAGER != EMPLOYEE_NO & SINMANAGER != EMPLOYEE_NO)//MANAGER ONLY 
        { No = 1; }
        else
            if (MANAGER == EMPLOYEE_NO & SINMANAGER == EMPLOYEE_NO & GM != EMPLOYEE_NO & ICMANAGER != EMPLOYEE_NO)// MANGER + SMNG 
            { No = 2;  }
            else
                if (SINMANAGER == EMPLOYEE_NO & GM != EMPLOYEE_NO) // SMNG ONLY 
                { No = 3; }
                else
                    if (GM == EMPLOYEE_NO)
                    { No = 4; }
                    else
                        if (ICMANAGER == EMPLOYEE_NO)
                        { No = 5; }
          
        switch (No)
        {
            case 1:
                dadapter = new OdbcDataAdapter("SELECT DISTINCT ICT_Tele.FORM_NO,ICT_Tele.POSITION,ICT_Tele.FORM_DATE,ICT_Tele.USER_NAME , ICT_Tele.USER_ID ,ICT_Tele.USER_DEP FROM ICT_Tele,EMPLOYEES,DEPARTMENTS WHERE ICT_Tele.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_Tele.FORM_STATUS = '8' AND ICT_Tele.USER_DEP= DEPARTMENTS.DEP_NAME AND ICT_Tele.USER_ID IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG = '" + MANAGER + "')", connectionString);

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();
                // manager 
                RadioButtonList1.Items.Add(new ListItem("Approve", "9"));
                RadioButtonList1.Items. Add(new ListItem("Reject", "10"));
                break;
                

            case 2:

                dadapter = new OdbcDataAdapter("SELECT DISTINCT ICT_Tele.FORM_NO,ICT_Tele.POSITION,ICT_Tele.FORM_DATE,ICT_Tele.USER_NAME , ICT_Tele.USER_ID ,ICT_Tele.USER_DEP FROM ICT_Tele,EMPLOYEES,DEPARTMENTS WHERE ICT_Tele.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_Tele.FORM_STATUS = '9' AND ICT_Tele.USER_DEP= DEPARTMENTS.DEP_NAME AND ICT_Tele.USER_ID IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE SMNG = '" + SINMANAGER + "')OR(ICT_Tele.FORM_STATUS='8' AND ICT_Tele.USER_ID IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG ='" + MANAGER + "'))",connectionString);

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();
                // manager 
                RadioButtonList1.Items.Add(new ListItem("Approve", "11"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "12"));
                break;
                

            case 3:


                dadapter = new OdbcDataAdapter("SELECT DISTINCT ICT_Tele.FORM_NO,ICT_Tele.POSITION,ICT_Tele.FORM_DATE,ICT_Tele.USER_NAME , ICT_Tele.USER_ID ,ICT_Tele.USER_DEP FROM ICT_Tele,EMPLOYEES,DEPARTMENTS WHERE ICT_Tele.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_Tele.FORM_STATUS = '9' AND ICT_Tele.USER_DEP= DEPARTMENTS.DEP_NAME AND ICT_Tele.USER_ID IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE SMNG = '" + SINMANAGER + "'",connectionString);

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

                // manager 
                RadioButtonList1.Items.Add(new ListItem("Approve", "11"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "12"));
                break;

            case 4:


                dadapter = new OdbcDataAdapter("SELECT DISTINCT ICT_Tele.FORM_NO,ICT_Tele.POSITION,ICT_Tele.FORM_DATE,ICT_Tele.USER_NAME , ICT_Tele.USER_ID ,ICT_Tele.USER_DEP FROM ICT_Tele,REQUEST_ACTORS,DEPARTMENTS,EMPLOYEES WHERE ICT_TELE.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_TELE.FORM_STATUS = '11' AND REQUEST_ACTORS.REQUEST_TYPE_ID = '3' AND REQUEST_ACTORS.EMPLOYEE_NO = '" + GM + "'" , connectionString);                                                                                                                                                                                                                                                  //   ("SELECT ICT_Tele.FORM_NO,ICT_Tele.POSITION,ICT_Tele.FORM_DATE,ICT_Tele.USER_NAME , ICT_Tele.USER_ID ,ICT_Tele.USER_DEP FROM ICT_Tele,EMPLOYEES,DEPARTMENTS WHERE ICT_Tele.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_Tele.FORM_STATUS = '1' AND ICT_Tele.USER_DEP= DEPARTMENTS.DEP_NAME AND ICT_Tele.USER_ID I WHERE MNG = '"+MANAGER+"')", connectionString)

               //SELECT DISTINCT ICT_Tele.FORM_NO, ICT_Tele.USER_ID, ICT_Tele.USER_NAME,ICT_Tele.USER_DEP ,ICT_Tele.POSITION FROM ICT_Tele, DEPARTMENTS,EMPLOYEES ,REQUEST_ACTORS WHERE ICT_Tele.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_Tele.FORM_STATUS='1' AND REQUEST_ACTORS.REQUEST_TYPE_ID='31' AND REQUEST_ACTORS.EMPLOYEE_NO='" + ICMANAGER + "')", connectionString); 

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "13"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "14"));
                RadioButtonList1.Items.Add(new ListItem("Return", "15"));

                break;

            case 5:
                

                dadapter = new OdbcDataAdapter("SELECT DISTINCT ICT_Tele.FORM_NO,ICT_Tele.POSITION,ICT_Tele.FORM_DATE,ICT_Tele.USER_NAME , ICT_Tele.USER_ID ,ICT_Tele.USER_DEP FROM ICT_Tele,REQUEST_ACTORS,DEPARTMENTS,EMPLOYEES WHERE ICT_TELE.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_TELE.FORM_STATUS = '13' AND REQUEST_ACTORS.REQUEST_TYPE_ID = '31' AND REQUEST_ACTORS.EMPLOYEE_NO = '" + ICMANAGER + "'", connectionString);                                                                                                                                                                                                                                                  //   ("SELECT ICT_Tele.FORM_NO,ICT_Tele.POSITION,ICT_Tele.FORM_DATE,ICT_Tele.USER_NAME , ICT_Tele.USER_ID ,ICT_Tele.USER_DEP FROM ICT_Tele,EMPLOYEES,DEPARTMENTS WHERE ICT_Tele.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_Tele.FORM_STATUS = '1' AND ICT_Tele.USER_DEP= DEPARTMENTS.DEP_NAME AND ICT_Tele.USER_ID I WHERE MNG = '"+MANAGER+"')", connectionString)

                //SELECT DISTINCT ICT_Tele.FORM_NO, ICT_Tele.USER_ID, ICT_Tele.USER_NAME,ICT_Tele.USER_DEP ,ICT_Tele.POSITION FROM ICT_Tele, DEPARTMENTS,EMPLOYEES ,REQUEST_ACTORS WHERE ICT_Tele.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_Tele.FORM_STATUS='1' AND REQUEST_ACTORS.REQUEST_TYPE_ID='31' AND REQUEST_ACTORS.EMPLOYEE_NO='" + ICMANAGER + "')", connectionString); 

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();
                RadioButtonList1.Items.Add(new ListItem("Approve", "16"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "17")); // 18 IT COMPLETE 

                break;

           /* case 4:


                dadapter = new OdbcDataAdapter("SELECT ICT_MSTR.FORM_NO , ICT_MSTR.EMPLOYEE_NO ,ICT_MSTR.REQUESTER_NAME,ICT_MSTR.FORM_DATE FROM ICT_MSTR,DEPARTMENTS,EMPLOYEES  WHERE ICT_MSTR.EMPLOYEE_NO=EMPLOYEES.EMPLOYEE_NO AND ICT_MSTR.FORM_STATUS = '2' AND ICT_MSTR.DEP_NO = DEPARTMENTS.DEP_NO AND ICT_MSTR.EMPLOYEE_NO IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE SMNG = '" + SINMANAGER + "')", connectionString);
                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "4"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "5"));

                break;*/

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

        odbcdadapter = new OdbcDataAdapter("SELECT ICT_TELE.FORM_NO,ICT_TELE.JUSTIFICATION,ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,ICT_TELE.SIM_TYPE,ICT_TELE.SIM_CEIL  FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'", connection);
       // ,, ICT_TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION
        dataset = new DataSet();
        odbcdadapter.Fill(dataset);
        GridView2.DataSource = dataset.Tables[0];
        GridView2.DataBind();
        F_comment();
        UserList();

    }

    void F_comment()
    {

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        ICMANAGER = Request.QueryString["ICM"];
        MANAGER = Request.QueryString["MNG"];
        GM = Request.QueryString["GM"];
        SINMANAGER = Request.QueryString["SMNG"];
        EMNG = Request.QueryString["EMS"];

      
        if (ICMANAGER == EMPLOYEE_NO)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
            EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
            DEPARTMENT_NO = Request.QueryString["DEP_NO"];
            sql = "SELECT ICT_TELE.FORM_NO,ICT_TELE.SMNG_COMMENT,ICT_TELE.GM_COMMENT FROM ICT_TELE WHERE ICT_TELE.FORM_NO='" + TextBox1.Text + "'";
            //SMNG_ID, SMNG_DATE, 
           // FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION, MNG_DATE, ICT_DATE, REQUEST_EXECUTOR, ICT_ID, MNG_ID
             // ,, ICT_TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION
      
            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand(sql, conn);

            cmd.Connection.Open();
            OdbcDataReader read = cmd.ExecuteReader();
            read.Read();

            if (read.HasRows)
            {
                gm_b.Text=read["GM_COMMENT"].ToString();
                sm_c.Text = read["SMNG_COMMENT"].ToString();
       
                gm_b.Visible = true;
                gm_l.Visible = true;
                sm_c.Visible = true;
                sm_l.Visible = true;      
              
            }
            cmd.Connection.Close();
        }
        else
                if (SINMANAGER == EMPLOYEE_NO & GM != EMPLOYEE_NO)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
                    EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
                    DEPARTMENT_NO = Request.QueryString["DEP_NO"];
                    sql = "SELECT ICT_TELE.FORM_NO,ICT_TELE.MNG_COMMENT FROM ICT_TELE WHERE ICT_TELE.FORM_NO='" + TextBox1.Text + "'";
                   //TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION

                    OdbcConnection conn = new OdbcConnection(connectionString);
                    OdbcCommand cmd = new OdbcCommand(sql, conn);

                    cmd.Connection.Open();
                    OdbcDataReader read = cmd.ExecuteReader();
                    read.Read();

                    if (read.HasRows)
                    {
                        //TextBox3.Text = read["MNG_COMMENT"].ToString();

                        TextBox3.Text = read["MNG_COMMENT"].ToString();

                        TextBox3.Visible = true;
                        Label6.Visible = true;
                        

                    }
                    cmd.Connection.Close();


                }
                if (GM == EMPLOYEE_NO)
                {

                    string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
                    EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
                    DEPARTMENT_NO = Request.QueryString["DEP_NO"];
                    sql = "SELECT ICT_TELE.FORM_NO,ICT_TELE.MNG_COMMENT,ICT_TELE.SMNG_COMMENT  FROM ICT_TELE WHERE ICT_TELE.FORM_NO='" + TextBox1.Text + "'";


                    // ,, ICT_TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION

                    OdbcConnection conn = new OdbcConnection(connectionString);
                    OdbcCommand cmd = new OdbcCommand(sql, conn);

                    cmd.Connection.Open();
                    OdbcDataReader read = cmd.ExecuteReader();
                    read.Read();

                    if (read.HasRows)
                    {
                        TextBox3.Text = read["MNG_COMMENT"].ToString();
                        sm_c.Text = read["SMNG_COMMENT"].ToString();

                        TextBox3.Visible = true;
                        Label6.Visible = true;
                        sm_c.Visible = true;
                        sm_l.Visible = true; 

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
        ICMANAGER = Request.QueryString["ICM"];
        MANAGER = Request.QueryString["MNG"];
        GM = Request.QueryString["GM"];
        SINMANAGER = Request.QueryString["SMNG"];
        EMNG = Request.QueryString["EMS"];



        if (TextBox1.Text != "")
        {

            if (MANAGER == EMPLOYEE_NO & GM != EMPLOYEE_NO & ICMANAGER != EMPLOYEE_NO & SINMANAGER != EMPLOYEE_NO)//MANAGER ONLY 
            {
                sql = "UPDATE ICT_TELE SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "', MNG_COMMENT = '" + TextBox5.Text + "' " +
                      ", MNG_ID = '" + MANAGER + "', MNG_DATE = '" + date + "' WHERE FORM_NO = '" + TextBox1.Text + "'";


                con = new OdbcConnection(connection);
                con.ConnectionString = connection;
                con.Open();

                comm = new OdbcCommand(sql, con);
                comm.ExecuteNonQuery();
                con.Close();

                Label_Message.Text = "Successfully...";
               // SendEMail(Status, 2);

            }
            else
                if (MANAGER == EMPLOYEE_NO & SINMANAGER == EMPLOYEE_NO & GM != EMPLOYEE_NO & ICMANAGER != EMPLOYEE_NO)// MANGER + SMNG
                {
                    sql = "UPDATE ICT_TELE SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "', SMNG_COMMENT = '" + TextBox5.Text + "' " +
                     ", SMNG_ID = '" + SINMANAGER + "', SMNG_DATE = '" + date + "' WHERE FORM_NO = '" + TextBox1.Text + "'";

                   // SMNG_ID, SMNG_DATE, SMNG_COMMENT

                    con = new OdbcConnection(connection);
                    con.ConnectionString = connection;
                    con.Open();

                    comm = new OdbcCommand(sql, con);
                    comm.ExecuteNonQuery();
                    con.Close();

                    Label_Message.Text = "Successfully...";
                    Status = RadioButtonList1.SelectedItem.Text.ToString();
                 //   SendEMail(Status, 3);

                }
                else
                    if (SINMANAGER == EMPLOYEE_NO & GM != EMPLOYEE_NO) // SMNG ONLY 
                    {
                        sql = "UPDATE ICT_TELE SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "', SMNG_COMMENT = '" + TextBox5.Text + "' " +
                          ", SMNG_ID = '" + SINMANAGER + "', SMNG_DATE = '" + date + "' WHERE FORM_NO = '" + TextBox1.Text + "'";

                        // SMNG_ID, SMNG_DATE, SMNG_COMMENT

                        con = new OdbcConnection(connection);
                        con.ConnectionString = connection;
                        con.Open();

                        comm = new OdbcCommand(sql, con);
                        comm.ExecuteNonQuery();
                        con.Close();

                        Label_Message.Text = "Successfully...";
                        Status = RadioButtonList1.SelectedItem.Text.ToString();
                   //     SendEMail(Status, 3);

                    }
                 
            else
               
                    if (GM == EMPLOYEE_NO)
                    {

                        sql = "UPDATE ICT_TELE SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "', GM_COMMENT = '" + TextBox5.Text + "' " +
                         ", GM_ID = '" + GM + "', GM_DATE = '" + date + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                        //FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION, MNG_DATE, ICT_DATE, REQUEST_EXECUTOR, ICT_ID, MNG_ID

                        con = new OdbcConnection(connection);
                        con.ConnectionString = connection;
                        con.Open();

                        comm = new OdbcCommand(sql, con);
                        comm.ExecuteNonQuery();
                        con.Close();
                       
                        Label_Message.Text = "Successfully...";
                     //   SendEMail(Status, 4);


                    }
                    else
                        if (ICMANAGER == EMPLOYEE_NO)
                        {
                            sql = "UPDATE ICT_TELE SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "',REQUEST_EXECUTOR='" + DropDownList1.SelectedValue + "', ICT_COMMENT = '" + TextBox5.Text + "' " +
                                 ", ICT_ID = '" + ICMANAGER + "', ICT_DATE = '" + date + "' WHERE FORM_NO = '" + TextBox1.Text + "'";


                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();

                            Label_Message.Text = "Successfully...";
                            Status = RadioButtonList1.SelectedItem.Text.ToString();
                       //     SendEMail(Status, 1);
                            //dropsend(); 
                        }
                
                /*else
                    if (MANAGER == EMPLOYEE_NO & SINMANAGER == EMPLOYEE_NO)
                    {

                        sql = "UPDATE ICT_MSTR SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "', SMNG_COMMENT = '" + TextBox5.Text + "' " +
                             ", SMNG_ID = '" + SINMANAGER + "', SMNG_DATE = '" + date + "' WHERE FORM_NO = '" + TextBox1.Text + "'";

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

                    else
                        if (SINMANAGER == EMPLOYEE_NO)
                        {

                            sql = "UPDATE ICT_MSTR SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "', SMNG_COMMENT = '" + TextBox5.Text + "' " +
                             ", SMNG_ID = '" + SINMANAGER + "', SMNG_DATE = '" + date + "' WHERE FORM_NO = '" + TextBox1.Text + "'";


                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();

                            Label_Message.Text = "Successfully...";
                            Status = RadioButtonList1.SelectedItem.Text.ToString();
                            SendEMail(Status, 4);
                        }*/
        }
        else
        {
            Reset();
            Panel1.Visible = false;
        }
    }

    private void UserList()
    {

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        ICMANAGER = Request.QueryString["ICM"];
        MANAGER = Request.QueryString["MNG"];
        

        if (EMPLOYEE_NO == ICMANAGER)
        {
            DropDownList1.Visible = true;
            Label2.Visible = true; 
            DropDownList1.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["petroneedsConnectionString"].ConnectionString;
            OdbcConnection con = new OdbcConnection(connectionString);

            //string sql = "SELECT DISTINCT USERS_INFORMATIONS.EMPLOYEE_NO,USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME FROM USERS_INFORMATIONS, DEPARTMENTS,EMP_MNG WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG = '9493')";
            string sql = "SELECT  DISTINCT USERS_INFORMATIONS.EMPLOYEE_NO,USERS_INFORMATIONS.FULL_USER_NAME FROM USERS_INFORMATIONS,EMP_MNG WHERE USERS_INFORMATIONS.EMPLOYEE_NO IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG = '9493')";
            con.Open();
            OdbcCommand cmd = new OdbcCommand(sql, con);
            DataSet dataset = new DataSet();
            OdbcDataAdapter ad = new OdbcDataAdapter(sql, con);
            ad.Fill(dataset);

            DropDownList1.DataSource = dataset;
            DropDownList1.DataTextField = "FULL_USER_NAME";///FULL_USER_NAME 
            DropDownList1.DataValueField = "EMPLOYEE_NO";//EMPLOYEE_NO
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("<<<Select>>>", "0"));
            //DropDownList1.SelectedIndex = 0;
            //DropDownList1.SelectedValue = "0";
            DropDownList1.SelectedItem.Value = "0";
        }
        else
        { 
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

        ICMANAGER = Request.QueryString["ICM"];
        MANAGER = Request.QueryString["MNG"];
        GM = Request.QueryString["GM"];
        SINMANAGER = Request.QueryString["SMNG"];
        EMNG = Request.QueryString["EMS"];
       
        //SINMANAGER = Request.QueryString["SMNG"];
        //EMSM = Request.QueryString["EMS"];
        EmId = DropDownList1.SelectedValue.ToString(); 

        string date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        // Requester 
        string sql = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + TextBox2.Text + "'";

        // ICT_MANAGE 
        string sql2 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + ICMANAGER + "'";
       

        // Manager
        string sql3 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + MANAGER + "'";
        /// SMNG 
        string sql4 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
         "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
         "USERS_INFORMATIONS.EMPLOYEE_NO = '" + EMNG + "'";

        // GM ADDRESS
        string sql6 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
           "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
           "USERS_INFORMATIONS.EMPLOYEE_NO = '" + GM + "'";
        
        //SEND EMPLOYEE_IT
        string sql5 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
           "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
           "USERS_INFORMATIONS.EMPLOYEE_NO = '" + EmId + "'";
      
       




        OdbcConnection conn = new OdbcConnection(connectionString);

        OdbcCommand cmd = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);
        OdbcCommand cmd4 = new OdbcCommand(sql4, conn);
        OdbcCommand cmd5 = new OdbcCommand(sql5, conn);
        OdbcCommand cmd6 = new OdbcCommand(sql6, conn);



        cmd.Connection.Open();

        OdbcDataReader read = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        OdbcDataReader read3 = cmd3.ExecuteReader();
        OdbcDataReader read4 = cmd4.ExecuteReader();
        OdbcDataReader read5 = cmd5.ExecuteReader();
        OdbcDataReader read6 = cmd6.ExecuteReader(); 


        read.Read();
        read2.Read();
        read3.Read();
        read4.Read();
        read5.Read();
        read6.Read(); 


        if (read.HasRows) // Requester 
        {
            EmpName = read["FULL_USER_NAME"].ToString();
            EmpEmail = read["EMAIL"].ToString();
            Depart = read["DEP_NAME"].ToString();
        }
        if (read2.HasRows)  // Approval ( ICT_MNG)
        {
            EmpName2 = read2["FULL_USER_NAME"].ToString();
            EmpEmail2 = read2["EMAIL"].ToString();

        }
        if (read3.HasRows)   // Approval (Manager)
        {
            EmpName3 = read3["FULL_USER_NAME"].ToString();
            EmpEmail3 = read3["EMAIL"].ToString();

        }
        if (read4.HasRows)   // SMNG 
        {
            EmpName4 = read4["FULL_USER_NAME"].ToString();
            EmpEmail4 = read4["EMAIL"].ToString();

        }
  
        if (read5.HasRows)
        {
          ITEMP = read5["FULL_USER_NAME"].ToString();
          ITEmail = read5["EMAIL"].ToString(); 
        }
        if (read6.HasRows)   // Approval (GM)
        {
            EmpName6 = read6["FULL_USER_NAME"].ToString();
            EmpEmail6 = read6["EMAIL"].ToString();

        }

        //if ICT MANAGER
        if (UserCheck == 1)
        {
           

            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&comment=" +TextBox5+ "&DATE=" + date + "" +
                  "&ApprovalName=" + ITEMP + "&ApprovalEmail=" + ITEmail + "&REQNAME= Direct International Dialing Request (DR)&AUTHORNAME=" + EmpName2 + "");
            /*Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                 "&ApprovalName=" + EmpName + "&ApprovalEmail=" + EmpEmail + "&REQNAME=Equpment Request (TRF)&AUTHORNAME=" + EmpName + "");*/
        }

        if (UserCheck == 2) // if Manager  
        {

            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
               "&ApprovalName=" + EmpName4 + "&ApprovalEmail=" + EmpEmail4 + "&REQNAME=Direct International Dialing Request (DR)&AUTHORNAME=" + EmpName3 + "");

        }

        if (UserCheck == 3) // if GM  
        {

            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
               "&ApprovalName=" + EmpName6 + "&ApprovalEmail=" + EmpEmail6 + "&REQNAME=Direct International Dialing Request (DR)&AUTHORNAME=" + EmpName4 + "");

        }
        if (UserCheck == 4) // if GM  
        {

            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
               "&ApprovalName=" + EmpName2 + "&ApprovalEmail=" + EmpEmail2 + "&REQNAME=Direct International Dialing Request (DR)&AUTHORNAME=" + EmpName6 + "");

        }
       
        cmd.Connection.Close(); 

    }


    /*protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
          EmId=DropDownList1.SelectedValue.ToString(); 
          //Status = RadioButtonList1.SelectedItem.ToString();
    }*/

    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        EmId = DropDownList1.SelectedValue.ToString(); 
    }
    
}