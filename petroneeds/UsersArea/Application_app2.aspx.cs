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


public partial class UsersArea_Application_app2 : System.Web.UI.Page
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
    public static string EMPLOYEE_NO, FIN, PROCU, LOG, MAN, FUEL, PROC, CAMP, MANG, SHOP, CONT, FINANCEADMIN, PROJECT, GM, BUD, HR, ADMIN, INV, EMNG, DEPARTMENT_NO, ICMANAGER, SUPERVISOR, PROCe, SINMANAGER, MANAGER;
    public static string EmpName, EmpEmail, Depart, EmId, Status, EmpName2, EmpEmail2, EmpName3, EmpEmail3, EmpName6, EmpEmail6, ITEMP, ITEmail, EmpName4, EmpEmail4, EmpName7, EmpEmail7, EmpName8, EmpEmail8, EmpName9, EmpEmail9, EmpName10, EmpEmail10, EmpName11, EmpEmail11, EmpName12, EmpEmail12, EmpName13, EmpEmail13, EmpName14, EmpEmail14;
    
    DataSet dset, dset2, dataset;
    string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
    string sql;

    //private string sortDirection;
    private int No;

    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        MANAGER = Request.QueryString["MNG"];
        ICMANAGER = Request.QueryString["ICM"];
        PROJECT = Request.QueryString["PR"];
        FUEL = Request.QueryString["FU"];
        INV = Request.QueryString["IN"];
        LOG = Request.QueryString["LO"];
        FIN = Request.QueryString["FI"];
        ADMIN = Request.QueryString["AD"];
        HR = Request.QueryString["H"];
        BUD = Request.QueryString["BU"];
        CONT = Request.QueryString["CO"];
        CAMP = Request.QueryString["CA"];
        ICMANAGER = Request.QueryString["ICM"];
        PROCe = Request.QueryString["Ce"];



        
        
    
        if (EMPLOYEE_NO == "" || EMPLOYEE_NO == null && DEPARTMENT_NO == "" || DEPARTMENT_NO == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                string Da = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
                text_date.Text=Da;
                getMenu();
                GridViewBind();
                PR_ID(); 
                Panel1.Visible = false;   
            }
        }
    } 
    public void GridViewBind()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        MANAGER = Request.QueryString["MNG"];
        ICMANAGER = Request.QueryString["ICM"];
        PROJECT = Request.QueryString["PR"];
        FUEL = Request.QueryString["FU"];
        INV = Request.QueryString["IN"];
        LOG = Request.QueryString["LO"];
        FIN = Request.QueryString["FI"];
        ADMIN = Request.QueryString["AD"];
        HR = Request.QueryString["H"];
        BUD = Request.QueryString["BU"];
        CONT = Request.QueryString["CO"];
        CAMP = Request.QueryString["CA"];
        PROCe = Request.QueryString["Ce"];


        if (MANAGER == EMPLOYEE_NO)
        { No = 1; }
        if (PROJECT == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO)
         { No = 2; }
        if (FUEL == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO)
        { No = 3; }
        if (INV == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO)
        { No = 4; } 
        /* if (LOG == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO)
         { No = 12; }*/
        if (LOG == EMPLOYEE_NO)
        {No= 12;}
        if (FIN == EMPLOYEE_NO)
        { No = 5; }
        if (ADMIN == EMPLOYEE_NO)
        { No = 6; }
        if (HR == EMPLOYEE_NO)
        { No = 7; }
        if (BUD == EMPLOYEE_NO)
        { No = 8; }
        if (CONT == EMPLOYEE_NO)
        { No = 9;}
        if (CAMP == EMPLOYEE_NO)
        {No=10;}
        if (PROCe == EMPLOYEE_NO)
        {No = 13;}
        //if (PROCe == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO)
       // { No = 13; }
        if (ICMANAGER == EMPLOYEE_NO)
        { No = 11; }
       
       
        
        
        switch (No)
        {
            case 1:

                dadapter = new OdbcDataAdapter("SELECT FORM_NO , FORM_DATE ,USER_ID, USER_POSITION FROM ICT_APPLICATION,DEPARTMENTS,EMPLOYEES WHERE ICT_APPLICATION.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_APPLICATION.USER_DEP=DEPARTMENTS.DEP_NAME AND ICT_APPLICATION.FORM_STATUS='1' AND USER_ID IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG='" + MANAGER + "') ORDER BY FORM_NO ASC", connectionString);
                
                dset = new DataSet();
                ////////1
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();
                RadioButtonList1.Items.Add(new ListItem("Approve", "2")); // 1 PENDING 
                RadioButtonList1.Items.Add(new ListItem("Reject", "3"));
                break;

            case 2: //PROJECT BOTH MANAGER AND APPROVe 
                         
                dadapter = new OdbcDataAdapter("SELECT FORM_NO , FORM_DATE ,USER_ID, USER_POSITION FROM ICT_APPLICATION,DEPARTMENTS,EMPLOYEES,REQUEST_ACTORS WHERE ICT_APPLICATION.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_APPLICATION.USER_DEP=DEPARTMENTS.DEP_NAME AND (ICT_APPLICATION.APPLICATION_NAME='7' AND ICT_APPLICATION.FORM_STATUS='2'OR (ICT_APPLICATION.USER_ID IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG='" + PROJECT + "'))AND ICT_APPLICATION.FORM_STATUS='1')AND REQUEST_ACTORS.REQUEST_TYPE_ID='40'AND REQUEST_ACTORS.EMPLOYEE_NO='" + PROJECT + "' ORDER BY FORM_NO ASC", connectionString);
                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();
                RadioButtonList1.Items.Add(new ListItem("Approve", "4")); // WHEN 2 MANAGER APPROVE
                RadioButtonList1.Items.Add(new ListItem("Reject", "5"));
               
              
                      
                break;

            case 3: // FUEL MANAGER AND OWNER 

                dadapter = new OdbcDataAdapter(" SELECT FORM_NO , FORM_DATE ,USER_ID, USER_POSITION FROM ICT_APPLICATION,DEPARTMENTS,EMPLOYEES,REQUEST_ACTORS WHERE ICT_APPLICATION.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_APPLICATION.USER_DEP=DEPARTMENTS.DEP_NAME AND (ICT_APPLICATION.APPLICATION_NAME='11' AND ICT_APPLICATION.FORM_STATUS='2'OR (ICT_APPLICATION.USER_ID IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG='" + FUEL + "'))AND ICT_APPLICATION.FORM_STATUS='1')AND REQUEST_ACTORS.REQUEST_TYPE_ID='44'AND REQUEST_ACTORS.EMPLOYEE_NO='" + FUEL + "'ORDER BY FORM_NO ASC ", connectionString); 

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

               
                 RadioButtonList1.Items.Add(new ListItem("Approve", "6"));
                 RadioButtonList1.Items.Add(new ListItem("Reject", "7"));
           break;

           case 4: // INVENTROY CONTROL BOTH MANAGER APPROAVAL


           dadapter = new OdbcDataAdapter("SELECT FORM_NO , FORM_DATE ,USER_ID, USER_POSITION FROM ICT_APPLICATION,DEPARTMENTS,EMPLOYEES,REQUEST_ACTORS WHERE ICT_APPLICATION.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_APPLICATION.USER_DEP=DEPARTMENTS.DEP_NAME AND (ICT_APPLICATION.APPLICATION_NAME='3'AND ICT_APPLICATION.FORM_STATUS='2'OR (ICT_APPLICATION.USER_ID IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG='" + INV + "'))AND ICT_APPLICATION.FORM_STATUS='1') AND REQUEST_ACTORS.REQUEST_TYPE_ID='37'AND REQUEST_ACTORS.EMPLOYEE_NO='" + INV + "' ORDER BY FORM_NO ASC", connectionString);
           dset = new DataSet();
           dadapter.Fill(dset);
           GridView1.DataSource = dset.Tables[0];
           GridView1.DataBind();

           RadioButtonList1.Items.Add(new ListItem("Approve", "8"));
           RadioButtonList1.Items.Add(new ListItem("Reject", "9"));
           break;

             case 5: // FIANCE SYSTEM 
                

                dadapter = new OdbcDataAdapter("SELECT DISTINCT FORM_NO , FORM_DATE ,USER_ID , USER_POSITION FROM ICT_APPLICATION,DEPARTMENTS,EMPLOYEES,REQUEST_ACTORS WHERE ICT_APPLICATION.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_APPLICATION.USER_DEP=DEPARTMENTS.DEP_NAME AND ICT_APPLICATION.APPLICATION_NAME='5' AND ICT_APPLICATION.FORM_STATUS='2' OR ICT_APPLICATION.FORM_STATUS='4'AND REQUEST_ACTORS.REQUEST_TYPE_ID='34'AND REQUEST_ACTORS.EMPLOYEE_NO='"+FIN+"' ORDER BY FORM_NO ASC",connectionString);;  

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();
                RadioButtonList1.Items.Add(new ListItem("Approve", "10"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "11")); // 18 IT COMPLETE 

                break;

                
            case 6: //ADMIN SYSTEM 

                dadapter = new OdbcDataAdapter("SELECT FORM_NO , FORM_DATE ,USER_ID,USER_POSITION FROM ICT_APPLICATION,DEPARTMENTS,EMPLOYEES,REQUEST_ACTORS WHERE ICT_APPLICATION.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_APPLICATION.USER_DEP=DEPARTMENTS.DEP_NAME AND ICT_APPLICATION.APPLICATION_NAME='1' AND ICT_APPLICATION.FORM_STATUS='2'AND REQUEST_ACTORS.REQUEST_TYPE_ID='35'AND REQUEST_ACTORS.EMPLOYEE_NO='" + ADMIN + "' ORDER BY FORM_NO ASC", connectionString);
                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();
                
                RadioButtonList1.Items.Add(new ListItem("Approve", "12"));
                RadioButtonList1.Items. Add(new ListItem("Reject", "13"));
                break;

            case 7: // HR SYSTEM  

                dadapter = new OdbcDataAdapter("SELECT FORM_NO , FORM_DATE , USER_ID, USER_POSITION FROM ICT_APPLICATION,DEPARTMENTS,EMPLOYEES,REQUEST_ACTORS WHERE ICT_APPLICATION.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_APPLICATION.USER_DEP=DEPARTMENTS.DEP_NAME AND ICT_APPLICATION.APPLICATION_NAME='4' AND ICT_APPLICATION.FORM_STATUS='2'AND REQUEST_ACTORS.REQUEST_TYPE_ID='38'AND REQUEST_ACTORS.EMPLOYEE_NO='" + HR + "' ORDER BY FORM_NO ASC", connectionString);
                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "14"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "15"));
                break;

            case 8: // BUDGET SYSTEM 

                dadapter = new OdbcDataAdapter("SELECT FORM_NO , FORM_DATE ,USER_ID,USER_POSITION FROM ICT_APPLICATION,DEPARTMENTS,EMPLOYEES,REQUEST_ACTORS WHERE ICT_APPLICATION.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_APPLICATION.USER_DEP=DEPARTMENTS.DEP_NAME AND ICT_APPLICATION.APPLICATION_NAME='6' AND ICT_APPLICATION.FORM_STATUS='2'AND REQUEST_ACTORS.REQUEST_TYPE_ID='39'AND REQUEST_ACTORS.EMPLOYEE_NO='" + BUD + "' ORDER BY FORM_NO ASC", connectionString);


                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();
                RadioButtonList1.Items.Add(new ListItem("Approve", "16"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "17"));
                break;

            case 9: //CONTRACT SYSTEM

                dadapter = new OdbcDataAdapter("SELECT FORM_NO , FORM_DATE , USER_ID, USER_POSITION FROM ICT_APPLICATION,DEPARTMENTS,EMPLOYEES,REQUEST_ACTORS WHERE ICT_APPLICATION.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_APPLICATION.USER_DEP=DEPARTMENTS.DEP_NAME AND ICT_APPLICATION.APPLICATION_NAME='9' AND ICT_APPLICATION.FORM_STATUS='2'AND REQUEST_ACTORS.REQUEST_TYPE_ID='42'AND REQUEST_ACTORS.EMPLOYEE_NO='" + CONT + "' ORDER BY FORM_NO ASC", connectionString);

                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "20"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "21"));
                break;

            case 10: // CAMP SYSTEM

                dadapter = new OdbcDataAdapter("SELECT FORM_NO , FORM_DATE , USER_ID, USER_POSITION FROM ICT_APPLICATION,DEPARTMENTS,EMPLOYEES,REQUEST_ACTORS WHERE ICT_APPLICATION.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_APPLICATION.USER_DEP=DEPARTMENTS.DEP_NAME AND ICT_APPLICATION.APPLICATION_NAME='10' AND ICT_APPLICATION.FORM_STATUS='2'AND REQUEST_ACTORS.REQUEST_TYPE_ID='43'AND REQUEST_ACTORS.EMPLOYEE_NO='" + CAMP + "' ORDER BY FORM_NO ASC", connectionString);


                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

                RadioButtonList1.Items.Add(new ListItem("Approve", "22"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "23"));
                break;

            /*case 11: /// IF ICT MANAGER ONLY
                dadapter = new OdbcDataAdapter("SELECT  DISTINCT FORM_NO ,FORM_DATE ,USER_ID,USER_POSITION FROM ICT_APPLICATION,DEPARTMENTS,EMPLOYEES,REQUEST_ACTORS WHERE ICT_APPLICATION.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_APPLICATION.USER_DEP=DEPARTMENTS.DEP_NAME AND FORM_STATUS='4'OR FORM_STATUS='6' OR FORM_STATUS='10' OR FORM_STATUS='12' OR FORM_STATUS='8' OR FORM_STATUS='14' OR FORM_STATUS='16' OR FORM_STATUS='18' OR FORM_STATUS='20' OR FORM_STATUS='22' OR FORM_STATUS='24' OR (USER_ID IN(SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG='" + ICMANAGER + "') AND FORM_STATUS='1') AND REQUEST_ACTORS.REQUEST_TYPE_ID='31'AND REQUEST_ACTORS.EMPLOYEE_NO='" + ICMANAGER + "' ORDER BY FORM_NO ASC", connectionString); 
                
                   dset = new DataSet();
                   dadapter.Fill(dset);
                   GridView1.DataSource = dset.Tables[0];
                   GridView1.DataBind();
               
                  RadioButtonList1.Items.Add(new ListItem("Approve", "26"));
                  RadioButtonList1.Items. Add(new ListItem("Reject", "27"));
                  //RadioButtonList1.Items.Add(new ListItem("Return", "15"));
            break;*/

            case 12: //LOGISTIC , both manager and owner 

            dadapter = new OdbcDataAdapter("SELECT FORM_NO,FORM_DATE ,USER_ID,APPLICATION_NAME  ,USER_POSITION FROM ICT_APPLICATION,DEPARTMENTS,EMPLOYEES,REQUEST_ACTORS WHERE ICT_APPLICATION.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_APPLICATION.USER_DEP=DEPARTMENTS.DEP_NAME AND (ICT_APPLICATION.APPLICATION_NAME='8' AND ICT_APPLICATION.FORM_STATUS='2'OR (ICT_APPLICATION.USER_ID IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG='" + LOG + "'))AND ICT_APPLICATION.FORM_STATUS='1') AND REQUEST_ACTORS.REQUEST_TYPE_ID='41' AND REQUEST_ACTORS.EMPLOYEE_NO='"+LOG+"' ORDER BY FORM_NO ASC", connectionString);
           
            dset = new DataSet();
            dadapter.Fill(dset);
            GridView1.DataSource = dset.Tables[0];
            GridView1.DataBind();

            RadioButtonList1.Items.Add(new ListItem("Approve", "18"));
            RadioButtonList1.Items.Add(new ListItem("Reject", "19"));
            break;

            case 13: //procument system 

            dadapter = new OdbcDataAdapter("SELECT FORM_NO,FORM_DATE ,USER_ID,APPLICATION_NAME  ,USER_POSITION FROM ICT_APPLICATION,DEPARTMENTS,EMPLOYEES,REQUEST_ACTORS WHERE ICT_APPLICATION.USER_ID=EMPLOYEES.EMPLOYEE_NO AND ICT_APPLICATION.USER_DEP=DEPARTMENTS.DEP_NAME AND (ICT_APPLICATION.APPLICATION_NAME='2' AND ICT_APPLICATION.FORM_STATUS='2'OR (ICT_APPLICATION.USER_ID IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG='" + PROCe + "'))AND ICT_APPLICATION.FORM_STATUS='1') AND REQUEST_ACTORS.REQUEST_TYPE_ID='36' AND REQUEST_ACTORS.EMPLOYEE_NO='"+PROCe+"' ORDER BY FORM_NO ASC", connectionString); 

            dset = new DataSet();
            dadapter.Fill(dset);
            GridView1.DataSource = dset.Tables[0];
            GridView1.DataBind();

            RadioButtonList1.Items.Add(new ListItem("Approve", "28"));
            RadioButtonList1.Items.Add(new ListItem("Reject", "29"));
            break;



            default:
                 Label_Message.Text = "There are no Requests...";
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
                upd();
                GridView3.Visible = false; 
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

        odbcdadapter = new OdbcDataAdapter("SELECT  FORM_NO ,ACCESS_LEVEL ,FORM_DATE ,USER_NAME,USER_DEP , DECODE(APPLICATION_NAME ,1,'Administration',2,'Procurement',3,'Inventroy Control',4,'Human Resource',5,'Finance',6,'Budget Control',7,'Project',8,'Logistic',9,'Contracts',10,'Camps',11,'Fuel') AS APPLICATION_NAME  FROM ICT_APPLICATION WHERE FORM_NO ='" + TextBox1.Text + "'", connection);

        
        //SELECT ICT_TELE.FORM_NO,ICT_TELE.JUSTIFICATION,ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,ICT_TELE.SIM_TYPE,ICT_TELE.SIM_CEIL  FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'", connection);
       // ,, ICT_TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION

         /*<asp:BoundField DataField="FORM_NO"
                                            HeaderText="Form No" />
                                        <asp:BoundField DataField="USER_NAME"  
                                            HeaderText="User Name" />
                                        <asp:BoundField DataField="USER_DEP" HeaderText="User DEP" />
                                        <asp:BoundField DataField="APPLICATION_NAME"  
                                            HeaderText="Application Name"/>
                                        <asp:BoundField DataField="ACCESS_LEVEL"  
                                            HeaderText="Access Level"/>*/  
        dataset = new DataSet();
        odbcdadapter.Fill(dataset);
        GridView2.DataSource = dataset.Tables[0];
        GridView2.DataBind();
        GridView3.Visible = false; 
        F_comment();
        appName();
        App_form();
        User_ID();
        //Sub_munu(); 
        //Priv_vis();
       // App_form(); 

    }




    void App_form()
    {

        MANAGER = Request.QueryString["MNG"];
        ICMANAGER = Request.QueryString["ICM"];
        PROJECT = Request.QueryString["PR"];
        FUEL = Request.QueryString["FU"];
        INV = Request.QueryString["IN"];
        LOG = Request.QueryString["LO"];
        FIN = Request.QueryString["FI"];
        ADMIN = Request.QueryString["AD"];
        HR = Request.QueryString["H"];
        BUD = Request.QueryString["BU"];
        CONT = Request.QueryString["CO"];
        CAMP = Request.QueryString["CA"];
        PROCe = Request.QueryString["Ce"];
      
           //Priv_vis();  , main System No 

            string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

            EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
            DEPARTMENT_NO = Request.QueryString["DEP_NO"];

            rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
            connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();


            if (INV == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO & app_text.Text=="3")
            {
               

                GridView3.Visible = true;
                odbccon = new OdbcConnection(connection);
                odbccon.ConnectionString = connection;

                odbcdadapter = new OdbcDataAdapter("SELECT SYSTEM_INFORMATION.SYSTEM_NAME , SYSTEM_INFORMATION.MS_SYSTEM_NO , SYSTEM_INFORMATION.SUB_SYSTEM_NO FROM SYSTEM_INFORMATION,ICT_APP_NAME,MAIN_SYSTEM WHERE MAIN_SYSTEM.DESCRIPTION=ICT_APP_NAME.APP_ID AND MAIN_SYSTEM.SYSTEM_NO=SYSTEM_INFORMATION.MS_SYSTEM_NO AND ICT_APP_NAME.APP_ID ='3'", connection);

                //SELECT SYSTEM_NAME , MS_SYSTEM_NO ,SUB_SYSTEM_NO FROM SYSTEM_INFORMATION , ICT_APP_NAME  WHERE SYSTEM_INFORMATION.MS_SYSTEM_NO=ICT_APP_NAME.APP_ID AND MS_SYSTEM_NO='6'

                //SELECT ICT_TELE.FORM_NO, ,,,ICT_TELE.JUSTIFICATION,ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,ICT_TELE.SIM_TYPE,ICT_TELE.SIM_CEIL  FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'", connection);
                // ,, ICT_TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION

                //  HeaderText="Access Level"/>
                dataset = new DataSet();
                odbcdadapter.Fill(dataset);
                GridView3.DataSource = dataset.Tables[0];
                GridView3.DataBind();
                GridView3.Visible = true;
                
                

            }
        


       
        if (PROJECT == EMPLOYEE_NO){

            odbccon = new OdbcConnection(connection);
            odbccon.ConnectionString = connection;

            odbcdadapter = new OdbcDataAdapter("SELECT SYSTEM_INFORMATION.SYSTEM_NAME , SYSTEM_INFORMATION.MS_SYSTEM_NO , SYSTEM_INFORMATION.SUB_SYSTEM_NO FROM SYSTEM_INFORMATION,ICT_APP_NAME,MAIN_SYSTEM WHERE MAIN_SYSTEM.DESCRIPTION=ICT_APP_NAME.APP_ID AND MAIN_SYSTEM.SYSTEM_NO=SYSTEM_INFORMATION.MS_SYSTEM_NO AND ICT_APP_NAME.APP_ID ='7'", connection);

            //SELECT SYSTEM_NAME , MS_SYSTEM_NO ,SUB_SYSTEM_NO FROM SYSTEM_INFORMATION , ICT_APP_NAME  WHERE SYSTEM_INFORMATION.MS_SYSTEM_NO=ICT_APP_NAME.APP_ID AND MS_SYSTEM_NO='6'

            //SELECT ICT_TELE.FORM_NO, ,,,ICT_TELE.JUSTIFICATION,ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,ICT_TELE.SIM_TYPE,ICT_TELE.SIM_CEIL  FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'", connection);
            // ,, ICT_TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION

            //  HeaderText="Access Level"/>
            dataset = new DataSet();
            odbcdadapter.Fill(dataset);
            GridView3.DataSource = dataset.Tables[0];
            GridView3.DataBind();
            GridView3.Visible = true;

        }
      

          if (FUEL == EMPLOYEE_NO ){

              odbccon = new OdbcConnection(connection);
              odbccon.ConnectionString = connection;

              odbcdadapter = new OdbcDataAdapter("SELECT SYSTEM_INFORMATION.SYSTEM_NAME , SYSTEM_INFORMATION.MS_SYSTEM_NO , SYSTEM_INFORMATION.SUB_SYSTEM_NO FROM SYSTEM_INFORMATION,ICT_APP_NAME,MAIN_SYSTEM WHERE MAIN_SYSTEM.DESCRIPTION=ICT_APP_NAME.APP_ID AND MAIN_SYSTEM.SYSTEM_NO=SYSTEM_INFORMATION.MS_SYSTEM_NO AND ICT_APP_NAME.APP_ID ='11'", connection);

              //SELECT SYSTEM_NAME , MS_SYSTEM_NO ,SUB_SYSTEM_NO FROM SYSTEM_INFORMATION , ICT_APP_NAME  WHERE SYSTEM_INFORMATION.MS_SYSTEM_NO=ICT_APP_NAME.APP_ID AND MS_SYSTEM_NO='6'

              //SELECT ICT_TELE.FORM_NO, ,,,ICT_TELE.JUSTIFICATION,ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,ICT_TELE.SIM_TYPE,ICT_TELE.SIM_CEIL  FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'", connection);
              // ,, ICT_TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION

              //  HeaderText="Access Level"/>
              dataset = new DataSet();
              odbcdadapter.Fill(dataset);
              GridView3.DataSource = dataset.Tables[0];
              GridView3.DataBind();
              GridView3.Visible = true;

          }
         

         
        if (LOG == EMPLOYEE_NO){

            odbccon = new OdbcConnection(connection);
            odbccon.ConnectionString = connection;

            odbcdadapter = new OdbcDataAdapter("SELECT SYSTEM_INFORMATION.SYSTEM_NAME , SYSTEM_INFORMATION.MS_SYSTEM_NO , SYSTEM_INFORMATION.SUB_SYSTEM_NO FROM SYSTEM_INFORMATION,ICT_APP_NAME,MAIN_SYSTEM WHERE MAIN_SYSTEM.DESCRIPTION=ICT_APP_NAME.APP_ID AND MAIN_SYSTEM.SYSTEM_NO=SYSTEM_INFORMATION.MS_SYSTEM_NO AND ICT_APP_NAME.APP_ID ='8'", connection);

            //SELECT SYSTEM_NAME , MS_SYSTEM_NO ,SUB_SYSTEM_NO FROM SYSTEM_INFORMATION , ICT_APP_NAME  WHERE SYSTEM_INFORMATION.MS_SYSTEM_NO=ICT_APP_NAME.APP_ID AND MS_SYSTEM_NO='6'

            //SELECT ICT_TELE.FORM_NO, ,,,ICT_TELE.JUSTIFICATION,ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,ICT_TELE.SIM_TYPE,ICT_TELE.SIM_CEIL  FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'", connection);
            // ,, ICT_TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION

            //  HeaderText="Access Level"/>
            dataset = new DataSet();
            odbcdadapter.Fill(dataset);
            GridView3.DataSource = dataset.Tables[0];
            GridView3.DataBind();
            GridView3.Visible = true;

        }
        

         if (FIN == EMPLOYEE_NO){
             odbccon = new OdbcConnection(connection);
             odbccon.ConnectionString = connection;

             odbcdadapter = new OdbcDataAdapter("SELECT SYSTEM_INFORMATION.SYSTEM_NAME , SYSTEM_INFORMATION.MS_SYSTEM_NO , SYSTEM_INFORMATION.SUB_SYSTEM_NO FROM SYSTEM_INFORMATION,ICT_APP_NAME,MAIN_SYSTEM WHERE MAIN_SYSTEM.DESCRIPTION=ICT_APP_NAME.APP_ID AND MAIN_SYSTEM.SYSTEM_NO=SYSTEM_INFORMATION.MS_SYSTEM_NO AND ICT_APP_NAME.APP_ID ='5'", connection);

             //SELECT SYSTEM_NAME , MS_SYSTEM_NO ,SUB_SYSTEM_NO FROM SYSTEM_INFORMATION , ICT_APP_NAME  WHERE SYSTEM_INFORMATION.MS_SYSTEM_NO=ICT_APP_NAME.APP_ID AND MS_SYSTEM_NO='6'

             //SELECT ICT_TELE.FORM_NO, ,,,ICT_TELE.JUSTIFICATION,ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,ICT_TELE.SIM_TYPE,ICT_TELE.SIM_CEIL  FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'", connection);
             // ,, ICT_TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION

             //  HeaderText="Access Level"/>
             dataset = new DataSet();
             odbcdadapter.Fill(dataset);
             GridView3.DataSource = dataset.Tables[0];
             GridView3.DataBind();
             GridView3.Visible = true;

         }
         
         
        if (ADMIN == EMPLOYEE_NO){

            odbccon = new OdbcConnection(connection);
            odbccon.ConnectionString = connection;

            odbcdadapter = new OdbcDataAdapter("SELECT SYSTEM_INFORMATION.SYSTEM_NAME , SYSTEM_INFORMATION.MS_SYSTEM_NO , SYSTEM_INFORMATION.SUB_SYSTEM_NO FROM SYSTEM_INFORMATION,ICT_APP_NAME,MAIN_SYSTEM WHERE MAIN_SYSTEM.DESCRIPTION=ICT_APP_NAME.APP_ID AND MAIN_SYSTEM.SYSTEM_NO=SYSTEM_INFORMATION.MS_SYSTEM_NO AND ICT_APP_NAME.APP_ID ='1'", connection);

            //SELECT SYSTEM_NAME , MS_SYSTEM_NO ,SUB_SYSTEM_NO FROM SYSTEM_INFORMATION , ICT_APP_NAME  WHERE SYSTEM_INFORMATION.MS_SYSTEM_NO=ICT_APP_NAME.APP_ID AND MS_SYSTEM_NO='6'

            //SELECT ICT_TELE.FORM_NO, ,,,ICT_TELE.JUSTIFICATION,ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,ICT_TELE.SIM_TYPE,ICT_TELE.SIM_CEIL  FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'", connection);
            // ,, ICT_TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION

            //  HeaderText="Access Level"/>
            dataset = new DataSet();
            odbcdadapter.Fill(dataset);
            GridView3.DataSource = dataset.Tables[0];
            GridView3.DataBind();
            GridView3.Visible = true;


        }
       

        if (HR == EMPLOYEE_NO){

            odbccon = new OdbcConnection(connection);
            odbccon.ConnectionString = connection;

            odbcdadapter = new OdbcDataAdapter("SELECT SYSTEM_INFORMATION.SYSTEM_NAME , SYSTEM_INFORMATION.MS_SYSTEM_NO , SYSTEM_INFORMATION.SUB_SYSTEM_NO FROM SYSTEM_INFORMATION,ICT_APP_NAME,MAIN_SYSTEM WHERE MAIN_SYSTEM.DESCRIPTION=ICT_APP_NAME.APP_ID AND MAIN_SYSTEM.SYSTEM_NO=SYSTEM_INFORMATION.MS_SYSTEM_NO AND ICT_APP_NAME.APP_ID ='4'", connection);

            //SELECT SYSTEM_NAME , MS_SYSTEM_NO ,SUB_SYSTEM_NO FROM SYSTEM_INFORMATION , ICT_APP_NAME  WHERE SYSTEM_INFORMATION.MS_SYSTEM_NO=ICT_APP_NAME.APP_ID AND MS_SYSTEM_NO='6'

            //SELECT ICT_TELE.FORM_NO, ,,,ICT_TELE.JUSTIFICATION,ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,ICT_TELE.SIM_TYPE,ICT_TELE.SIM_CEIL  FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'", connection);
            // ,, ICT_TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION

            //  HeaderText="Access Level"/>
            dataset = new DataSet();
            odbcdadapter.Fill(dataset);
            GridView3.DataSource = dataset.Tables[0];
            GridView3.DataBind();
            GridView3.Visible = true;

        }
        

         if (BUD == EMPLOYEE_NO){
             odbccon = new OdbcConnection(connection);
             odbccon.ConnectionString = connection;

             odbcdadapter = new OdbcDataAdapter("SELECT SYSTEM_INFORMATION.SYSTEM_NAME , SYSTEM_INFORMATION.MS_SYSTEM_NO , SYSTEM_INFORMATION.SUB_SYSTEM_NO FROM SYSTEM_INFORMATION,ICT_APP_NAME,MAIN_SYSTEM WHERE MAIN_SYSTEM.DESCRIPTION=ICT_APP_NAME.APP_ID AND MAIN_SYSTEM.SYSTEM_NO=SYSTEM_INFORMATION.MS_SYSTEM_NO AND ICT_APP_NAME.APP_ID ='6'", connection);

             //SELECT SYSTEM_NAME , MS_SYSTEM_NO ,SUB_SYSTEM_NO FROM SYSTEM_INFORMATION , ICT_APP_NAME  WHERE SYSTEM_INFORMATION.MS_SYSTEM_NO=ICT_APP_NAME.APP_ID AND MS_SYSTEM_NO='6'

             //SELECT ICT_TELE.FORM_NO, ,,,ICT_TELE.JUSTIFICATION,ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,ICT_TELE.SIM_TYPE,ICT_TELE.SIM_CEIL  FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'", connection);
             // ,, ICT_TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION

             //  HeaderText="Access Level"/>
             dataset = new DataSet();
             odbcdadapter.Fill(dataset);
             GridView3.DataSource = dataset.Tables[0];
             GridView3.DataBind();
             GridView3.Visible = true;

         }
         

         if (CONT == EMPLOYEE_NO){

             odbccon = new OdbcConnection(connection);
             odbccon.ConnectionString = connection;

             odbcdadapter = new OdbcDataAdapter("SELECT SYSTEM_INFORMATION.SYSTEM_NAME , SYSTEM_INFORMATION.MS_SYSTEM_NO , SYSTEM_INFORMATION.SUB_SYSTEM_NO FROM SYSTEM_INFORMATION,ICT_APP_NAME,MAIN_SYSTEM WHERE MAIN_SYSTEM.DESCRIPTION=ICT_APP_NAME.APP_ID AND MAIN_SYSTEM.SYSTEM_NO=SYSTEM_INFORMATION.MS_SYSTEM_NO AND ICT_APP_NAME.APP_ID ='9'", connection);

             //SELECT SYSTEM_NAME , MS_SYSTEM_NO ,SUB_SYSTEM_NO FROM SYSTEM_INFORMATION , ICT_APP_NAME  WHERE SYSTEM_INFORMATION.MS_SYSTEM_NO=ICT_APP_NAME.APP_ID AND MS_SYSTEM_NO='6'

             //SELECT ICT_TELE.FORM_NO, ,,,ICT_TELE.JUSTIFICATION,ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,ICT_TELE.SIM_TYPE,ICT_TELE.SIM_CEIL  FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'", connection);
             // ,, ICT_TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION

             //  HeaderText="Access Level"/>
             dataset = new DataSet();
             odbcdadapter.Fill(dataset);
             GridView3.DataSource = dataset.Tables[0];
             GridView3.DataBind();
             GridView3.Visible = true;

         }
         
     
        if (CAMP == EMPLOYEE_NO){

            odbccon = new OdbcConnection(connection);
            odbccon.ConnectionString = connection;

            odbcdadapter = new OdbcDataAdapter("SELECT SYSTEM_INFORMATION.SYSTEM_NAME , SYSTEM_INFORMATION.MS_SYSTEM_NO , SYSTEM_INFORMATION.SUB_SYSTEM_NO FROM SYSTEM_INFORMATION,ICT_APP_NAME,MAIN_SYSTEM WHERE MAIN_SYSTEM.DESCRIPTION=ICT_APP_NAME.APP_ID AND MAIN_SYSTEM.SYSTEM_NO=SYSTEM_INFORMATION.MS_SYSTEM_NO AND ICT_APP_NAME.APP_ID ='10'", connection);

            //SELECT SYSTEM_NAME , MS_SYSTEM_NO ,SUB_SYSTEM_NO FROM SYSTEM_INFORMATION , ICT_APP_NAME  WHERE SYSTEM_INFORMATION.MS_SYSTEM_NO=ICT_APP_NAME.APP_ID AND MS_SYSTEM_NO='6'

            //SELECT ICT_TELE.FORM_NO, ,,,ICT_TELE.JUSTIFICATION,ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,ICT_TELE.SIM_TYPE,ICT_TELE.SIM_CEIL  FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'", connection);
            // ,, ICT_TELE , FORM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION

            //  HeaderText="Access Level"/>
            dataset = new DataSet();
            odbcdadapter.Fill(dataset);
            GridView3.DataSource = dataset.Tables[0];
            GridView3.DataBind();
            GridView3.Visible = true;

        }
        
        if (PROCe == EMPLOYEE_NO){
            odbccon = new OdbcConnection(connection);
            odbccon.ConnectionString = connection;

            odbcdadapter = new OdbcDataAdapter("SELECT SYSTEM_INFORMATION.SYSTEM_NAME , SYSTEM_INFORMATION.MS_SYSTEM_NO , SYSTEM_INFORMATION.SUB_SYSTEM_NO FROM SYSTEM_INFORMATION,ICT_APP_NAME,MAIN_SYSTEM WHERE MAIN_SYSTEM.DESCRIPTION=ICT_APP_NAME.APP_ID AND MAIN_SYSTEM.SYSTEM_NO=SYSTEM_INFORMATION.MS_SYSTEM_NO AND ICT_APP_NAME.APP_ID ='2'", connection);

            //SELECT SYSTEM_NAME , MS_SYSTEM_NO ,SUB_SYSTEM_NO FROM SYSTEM_INFORMATION , ICT_APP_NAME  WHERE SYSTEM_INFORMATION.MS_SYSTEM_NO=ICT_APP_NAME.APP_ID AND MS_SYSTEM_NO='6'

            //SELECT ICT_TELE.FORM_NO, ,,,ICT_TELE.JUSTIFICATION,ICT_TELE.USER_NAME,ICT_TELE.USER_DEP,ICT_TELE.SIM_TYPE,ICT_TELE.SIM_CEIL  FROM ICT_TELE WHERE ICT_TELE.FORM_NO ='" + TextBox1.Text + "'", connection);
            // ,, ICT_TELE , FO.RM_NO, FORM_DATE, USER_NAME, USER_ID, USER_DEP, SIM_TYPE, FORM_STATUS, SIM_CEIL, DID, JUSTIFICATION, MNG_COMMENT, GM_COMMENT, ICT_COMMENT, POSITION

            //  HeaderText="Access Level"/>
            dataset = new DataSet();
            odbcdadapter.Fill(dataset);
            GridView3.DataSource = dataset.Tables[0];
            GridView3.DataBind();
            GridView3.Visible = true;

        }
       

    }

 

    void appName()
    {

        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql, date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        sql = "SELECT APPLICATION_NAME FROM ICT_APPLICATION WHERE FORM_NO='" + TextBox1.Text + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);
        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            TextBox6.Text = read["APPLICATION_NAME"].ToString();
        }

        cmd.Connection.Close();

    }

   /* void Sub_munu()
    {

        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql, date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        sql = "SELECT SYSTEM_INFORMATION.SYSTEM_NAME , SYSTEM_INFORMATION.MS_SYSTEM_NO , SYSTEM_INFORMATION.SUB_SYSTEM_NO FROM SYSTEM_INFORMATION,ICT_APP_NAME,MAIN_SYSTEM WHERE MAIN_SYSTEM.DESCRIPTION=ICT_APP_NAME.APP_ID AND MAIN_SYSTEM.SYSTEM_NO=SYSTEM_INFORMATION.MS_SYSTEM_NO AND ICT_APP_NAME.APP_ID ='"+app_text.Text+"'"; 

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);
        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            main_sys.Text = read["MS_SYSTEM_NO"].ToString();
        }

        cmd.Connection.Close();

    }*/

    void F_comment()
    {

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

    
        ICMANAGER = Request.QueryString["ICM"];
        

                 
        if (ICMANAGER == EMPLOYEE_NO)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
            EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
            DEPARTMENT_NO = Request.QueryString["DEP_NO"];

            sql = "SELECT MNG_COMMENT FROM ICT_APPLICATION WHERE ICT_APPLICATION.FORM_NO='" + TextBox1.Text + "'";
            

            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand(sql, conn);

            cmd.Connection.Open();
            OdbcDataReader read = cmd.ExecuteReader();
            read.Read();

            if (read.HasRows)
            {
                MNG_C.Text = read["MNG_COMMENT"].ToString();

                MNG_C.Visible = true;
                MNG_l.Visible = true; 
                
            }
            cmd.Connection.Close();
        }
       
    }


    public virtual bool AllowPaging { get; set; }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {

        Update_P(); 
        UpdateFormStatus();
      
        Panel1.Visible = false;
        Reset();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);

    }

    public void Update_P()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
   
        foreach (GridViewRow row in GridView3.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                    CheckBox chkRow = (row.Cells[1].FindControl("IN") as CheckBox);
                    CheckBox chkRow1 = (row.Cells[2].FindControl("UP") as CheckBox);
                    CheckBox chkRow2 = (row.Cells[3].FindControl("DE") as CheckBox);

              

                    if (chkRow.Checked == true)
                    {
                        text_in.Text = row.Cells[0].Text;
                        Return_Menu_NO(text_in.Text);
                        CheckUser(text_in.Text);

                        PR_ID();

                        if (Us_ID.Text == user_no.Text & App_ID.Text == MN_ID2.Text)
                        {
                            //  sql = "UPDATE INTO USER_PRIVILEGS" +
                            // "(UP3_ID,INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +
                            //  "('" + TextBox7.Text + "','1','0','0','5','" + MN_ID.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";

                            sql = "UPDATE USER_PRIVILEGS SET INSERT_ALLOWED='1' , APPROVED_DEGREE='5' WHERE PI_PROGRAM_NO='" + App_ID.Text + "'";

                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();
                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();
                            text_in.Text = "";
                            MN_ID2.Text = "";
                            chkRow.Checked = false;

                        }
                        else
                        {
                            PR_ID();
                            sql = "INSERT INTO USER_PRIVILEGS" +
                            "(UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +

                           "('" + TextBox7.Text + "','1','0','0','5','" + MN_ID2.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();
                            text_in.Text = "";
                            chkRow.Checked = false;
                        }


                    }
                    if (chkRow1.Checked == true)
                    {

                        text_up.Text = row.Cells[0].Text;
                        Return_Menu_NO(text_up.Text);
                        CheckUser(text_up.Text);
                        PR_ID();


                        if (Us_ID.Text == user_no.Text & App_ID.Text == MN_ID2.Text)
                        {

                            // sql = "INSERT INTO USER_PRIVILEGS" +
                            //"(UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +

                            //"('" + TextBox7.Text + "','0','0','1','5','" + MN_ID.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";

                            sql = "UPDATE USER_PRIVILEGS SET CHANGE_ALLOWED='1' , APPROVED_DEGREE='5' WHERE PI_PROGRAM_NO='" + App_ID.Text + "'";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();
                            text_up.Text = "";
                            MN_ID2.Text = "";
                            chkRow1.Checked = false;
                        }

                        else
                        {

                            PR_ID();

                            sql = "INSERT INTO USER_PRIVILEGS" +
                            "(UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +

                           "('" + TextBox7.Text + "','0','0','1','5','" + MN_ID2.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();
                            text_up.Text = "";
                             MN_ID2.Text = "";
                            chkRow1.Checked = false;

                        }
                    }

                    if (chkRow2.Checked == true)
                    {
                        text_de.Text = row.Cells[0].Text;
                        Return_Menu_NO(text_de.Text);
                        CheckUser(text_de.Text);
                        PR_ID();

                        if (Us_ID.Text == user_no.Text & App_ID.Text == MN_ID2.Text)
                        {

                            // sql = "INSERT INTO USER_PRIVILEGS" +
                            // "(UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +

                            //"('" + TextBox7.Text + "','0','1','0','5','" + MN_ID.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";
                            sql = "UPDATE USER_PRIVILEGS SET DELETE_ALLOWED='1' , APPROVED_DEGREE='5' WHERE PI_PROGRAM_NO='" + App_ID.Text + "'";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();
                            text_de.Text = "";
                            MN_ID2.Text = "";
                            chkRow2.Checked = false;
                        }

                        else
                        {
                            sql = "INSERT INTO USER_PRIVILEGS" +
                            "(UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +

                           "('" + TextBox7.Text + "','0','1','0','5','" + MN_ID2.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();
                            text_de.Text = "";
                            MN_ID2.Text = "";
                            chkRow2.Checked = false;

                        }

                    }
                }

           // }
        }


    }


    public void Return_Menu_NO(string mnuText)
    {
        MN_ID.Text = mnuText;

        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        string sql = "SELECT SUB_SYSTEM_NO FROM SYSTEM_INFORMATION WHERE SYSTEM_NAME='" + MN_ID.Text + "' ";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            MN_ID2.Text = read["SUB_SYSTEM_NO"].ToString();

        }
        cmd.Connection.Close();

    }


    public void PR_ID()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
       
        string sql = "SELECT NVL(MAX(UP3_ID),0)+1 FROM USER_PRIVILEGS "; 

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            TextBox7.Text = read[0].ToString();

        }
        cmd.Connection.Close();
       // User_ID();
       // Sub_munu(); 
    }


    public void User_ID()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        string sql = "SELECT USER_NO FROM USERS_INFORMATIONS WHERE EMPLOYEE_NO='" + TextBox2.Text + "' ";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            user_no.Text = read["USER_NO"].ToString();
     
        }
        cmd.Connection.Close();
    }


    public void CheckUser(string mnuText)
    {
      // if(MN_ID.Text & user_no.Text)  
           
         string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

         string sql = "SELECT UI_USER_NO , PI_PROGRAM_NO FROM USER_PRIVILEGS WHERE UI_USER_NO ='" + user_no.Text + "' AND PI_PROGRAM_NO ='" + MN_ID2.Text+ "' ";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Us_ID.Text = read["UI_USER_NO"].ToString();
            App_ID.Text = read["PI_PROGRAM_NO"].ToString();
        }
        cmd.Connection.Close();
    }



   
   /* void UpateMain()
    {

        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        sql = "INSERT INTO USER_PRIVILEGS" +
             "(UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +

            "('" + TextBox7.Text + "','','','1','5','" + main_sys.Text + " ','','" + user_no.Text + "','" + text_date.Text + "','1','')";
                    con = new OdbcConnection(connection);
                    con.ConnectionString = connection;
                    con.Open();

                    comm = new OdbcCommand(sql, con);
                    comm.ExecuteNonQuery();
                    con.Close();


    }*/

    /*protected void SelectCheckBoxIN_OnCheckedChanged(object sender, EventArgs e)
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql, date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        if (TextBox6.Text != "")
        {
            var rows = GridView3.Rows;
            int count = GridView3.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                bool isChecked = ((CheckBox)rows[i].FindControl("IN")).Checked;
                if (isChecked)
                {

                    sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '8' , MNG_COMMENT='" + TextBox5.Text + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                    con = new OdbcConnection(connection);
                    con.ConnectionString = connection;
                    con.Open();

                    comm = new OdbcCommand(sql, con);
                    comm.ExecuteNonQuery();
                    con.Close();

                    //USER_PRIVILEGS
                   //UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE
                }
            }
        }
        
    }

    protected void SelectCheckBoxUP_OnCheckedChanged(object sender, EventArgs e)
    {
        if (TextBox6.Text != "")
        {
            var rows = GridView3.Rows;
            int count = GridView3.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                bool isChecked = ((CheckBox)rows[i].FindControl("UP")).Checked;
                if (isChecked)
                {
                    //Do what you want
                }
            }
        }

    }

    protected void SelectCheckBoxDE_OnCheckedChanged(object sender, EventArgs e)
    {
        if (TextBox6.Text != "")
        {

            var rows = GridView3.Rows;
            int count = GridView3.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                bool isChecked = ((CheckBox)rows[i].FindControl("DE")).Checked;
                if (isChecked)
                {
                    //Do what you want
                }
            }
        }

    }*/

    private void upd()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql , date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        MANAGER = Request.QueryString["MNG"];
        ICMANAGER = Request.QueryString["ICM"];
        PROJECT = Request.QueryString["PR"];
        FUEL = Request.QueryString["FU"];
        INV = Request.QueryString["IN"];
        LOG = Request.QueryString["LO"];
        FIN = Request.QueryString["FI"];
        ADMIN = Request.QueryString["AD"];
        HR = Request.QueryString["H"];
        BUD = Request.QueryString["BU"];
        CONT = Request.QueryString["CO"];
        CAMP = Request.QueryString["CA"];
        PROCe = Request.QueryString["Ce"];

        if (INV == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO)
        {
            sql = "SELECT FORM_NO , FORM_STATUS ,APPLICATION_NAME FROM ICT_APPLICATION WHERE (ICT_APPLICATION.APPLICATION_NAME='3' AND ICT_APPLICATION.FORM_STATUS='2' OR (ICT_APPLICATION.USER_ID IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG='"+INV+"'))AND ICT_APPLICATION.FORM_STATUS='1')AND FORM_NO='" + TextBox1.Text + "'";
            
            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand(sql, conn);
            cmd.Connection.Open();
            OdbcDataReader read = cmd.ExecuteReader();
            read.Read();

            if (read.HasRows)
            {
                status_text.Text = read["FORM_STATUS"].ToString();
                app_text.Text = read["APPLICATION_NAME"].ToString();
            }

            cmd.Connection.Close(); 

        }
        else

        if (PROJECT == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO)
        {
            sql = "SELECT FORM_NO , FORM_STATUS ,APPLICATION_NAME FROM ICT_APPLICATION WHERE (ICT_APPLICATION.APPLICATION_NAME='7' AND ICT_APPLICATION.FORM_STATUS='2'OR (ICT_APPLICATION.USER_ID IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG='" + PROJECT + "'))AND ICT_APPLICATION.FORM_STATUS='1')AND FORM_NO='" + TextBox1.Text + "'";

            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand(sql, conn);
            cmd.Connection.Open();
            OdbcDataReader read = cmd.ExecuteReader();
            read.Read();

            if (read.HasRows)
            {
                status_text.Text = read["FORM_STATUS"].ToString();
                app_text.Text = read["APPLICATION_NAME"].ToString();
            }

            cmd.Connection.Close();  
        }
        else
            if (FUEL == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO)
            {
                sql = "SELECT FORM_NO , FORM_STATUS ,APPLICATION_NAME FROM ICT_APPLICATION WHERE (ICT_APPLICATION.APPLICATION_NAME='11' AND ICT_APPLICATION.FORM_STATUS='2'OR (ICT_APPLICATION.USER_ID IN (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG='" + FUEL + "'))AND ICT_APPLICATION.FORM_STATUS='1')AND FORM_NO='"+TextBox1.Text+"'";
                OdbcConnection conn = new OdbcConnection(connectionString);
                OdbcCommand cmd = new OdbcCommand(sql, conn);
                cmd.Connection.Open();
                OdbcDataReader read = cmd.ExecuteReader();
                read.Read();

                if (read.HasRows)
                {
                    status_text.Text = read["FORM_STATUS"].ToString();
                    app_text.Text = read["APPLICATION_NAME"].ToString();
                }

                cmd.Connection.Close(); 


            }
            else
                if (ICMANAGER == EMPLOYEE_NO)
                {
                    sql = "SELECT FORM_NO , FORM_STATUS ,APPLICATION_NAME FROM ICT_APPLICATION WHERE ICT_APPLICATION.FORM_STATUS='1' AND FORM_NO='"+TextBox1.Text+"'";
                
                    OdbcConnection conn = new OdbcConnection(connectionString);
                    OdbcCommand cmd = new OdbcCommand(sql, conn);
                    cmd.Connection.Open();
                    OdbcDataReader read = cmd.ExecuteReader();
                    read.Read();

                    if (read.HasRows)
                    {
                        status_text.Text = read["FORM_STATUS"].ToString();
                        app_text.Text = read["APPLICATION_NAME"].ToString();
                    }

                    cmd.Connection.Close(); 
                }
            
    } 
    

    private void UpdateFormStatus()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql, date , ap_name;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        MANAGER = Request.QueryString["MNG"];
        ICMANAGER = Request.QueryString["ICM"];
        PROJECT = Request.QueryString["PR"];
        FUEL = Request.QueryString["FU"];
        INV = Request.QueryString["IN"];
        LOG = Request.QueryString["LO"];
        FIN = Request.QueryString["FI"];
        ADMIN = Request.QueryString["AD"];
        HR = Request.QueryString["H"];
        BUD = Request.QueryString["BU"];
        CONT = Request.QueryString["CO"];
        CAMP = Request.QueryString["CA"];
        PROCe = Request.QueryString["Ce"];
       

        if (TextBox1.Text != "")
        {
                   if (INV == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO)
                    {
                        if (status_text.Text == "1" & RadioButtonList1.SelectedValue == "8" & app_text.Text == "3")
                        {

                            sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '8' , MNG_COMMENT='" + TextBox5.Text + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();

                            Label_Message.Text = "Successfully...";
                            ap_name = app_text.Text; 
                            Status = RadioButtonList1.SelectedItem.Text.ToString();
                            SendEMail(Status, 2, ap_name);

                        }
                        else
                            if (status_text.Text == "1" & RadioButtonList1.SelectedValue == "9" & app_text.Text == "3")
                            {

                                sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '9',MNG_COMMENT='" + TextBox5.Text + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                                con = new OdbcConnection(connection);
                                con.ConnectionString = connection;
                                con.Open();

                                comm = new OdbcCommand(sql, con);
                                comm.ExecuteNonQuery();
                                con.Close();

                                Label_Message.Text = "Successfully...";
                                ap_name = app_text.Text;
                                Status = RadioButtonList1.SelectedItem.Text.ToString();
                                SendEMail(Status, 2,ap_name);

                            }
                            else

                                if (status_text.Text == "1" & RadioButtonList1.SelectedValue == "8") //other and approve
                                {

                                    sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '2', MNG_COMMENT='" + TextBox5.Text + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                                    con = new OdbcConnection(connection);
                                    con.ConnectionString = connection;
                                    con.Open();

                                    comm = new OdbcCommand(sql, con);
                                    comm.ExecuteNonQuery();
                                    con.Close();
                                    ap_name=app_text.Text; 

                                    Label_Message.Text = "Successfully...";
                                    Status = RadioButtonList1.SelectedItem.Text.ToString();
                                    SendEMail(Status, 3, ap_name);

                                }
                          else
                                    if (status_text.Text == "1" & RadioButtonList1.SelectedValue == "9")
                                    {

                                        sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '9' , MNG_COMMENT='" + TextBox5.Text + "'WHERE FORM_NO = '" + TextBox1.Text + "'";
                                        con = new OdbcConnection(connection);
                                        con.ConnectionString = connection;
                                        con.Open();

                                        comm = new OdbcCommand(sql, con);
                                        comm.ExecuteNonQuery();
                                        con.Close();
                                        ap_name = app_text.Text;
                                        Status = RadioButtonList1.SelectedItem.Text.ToString();
                                        SendEMail(Status, 3, ap_name); 
                                        Label_Message.Text = "Successfully...";
                                       

                                    }
                      else
                        if (status_text.Text == "2" & RadioButtonList1.SelectedValue == "8")
                        {

                            sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '8' WHERE FORM_NO = '" + TextBox1.Text + "'";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();

                            Label_Message.Text = "Successfully...";
                            ap_name = app_text.Text;
                            Status = RadioButtonList1.SelectedItem.Text.ToString();
                            SendEMail(Status, 2, ap_name);

                        }
                    else
                        if (status_text.Text == "2" & RadioButtonList1.SelectedValue == "9")
                        {

                            sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '9' WHERE FORM_NO = '" + TextBox1.Text + "'";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();

                            ap_name = app_text.Text;
                            Status = RadioButtonList1.SelectedItem.Text.ToString();
                            SendEMail(Status, 2, ap_name);

                        }

                    }

                   else

                 if (PROJECT == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO)
                {

                    if (status_text.Text == "1" & RadioButtonList1.SelectedValue == "4" & app_text.Text == "7")
                    {

                        sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '4' , MNG_COMMENT='" + TextBox5.Text + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                       con = new OdbcConnection(connection);
                       con.ConnectionString = connection;
                       con.Open();

                       comm = new OdbcCommand(sql, con);
                       comm.ExecuteNonQuery();
                       con.Close();

                       Label_Message.Text = "Successfully...";
                       ap_name = app_text.Text;
                       Status = RadioButtonList1.SelectedItem.Text.ToString();
                       SendEMail(Status, 4, ap_name);
 
                    }
                    else
                        if (status_text.Text == "1" & RadioButtonList1.SelectedValue == "5" & app_text.Text == "7")
                    {

                        sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '5' , MNG_COMMENT='" + TextBox5.Text + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                        con = new OdbcConnection(connection);
                        con.ConnectionString = connection;
                        con.Open();

                        comm = new OdbcCommand(sql, con);
                        comm.ExecuteNonQuery();
                        con.Close();

                        Label_Message.Text = "Successfully...";
                        ap_name = app_text.Text;
                        Status = RadioButtonList1.SelectedItem.Text.ToString();
                        SendEMail(Status, 4, ap_name);

                    }
                    else

                    if (status_text.Text == "1" & RadioButtonList1.SelectedValue == "4")
                    {

                        sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '2' , MNG_COMMENT='" + TextBox5.Text + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                        con = new OdbcConnection(connection);
                        con.ConnectionString = connection;
                        con.Open();

                        comm = new OdbcCommand(sql, con);
                        comm.ExecuteNonQuery();
                        con.Close();

                        ap_name = app_text.Text;

                       Label_Message.Text = "Successfully...";
                       Status = RadioButtonList1.SelectedItem.Text.ToString();
                       SendEMail(Status, 5, ap_name);

                    }
                    else
                        if (status_text.Text == "1" & RadioButtonList1.SelectedValue == "5")
                        {

                            sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '5' , MNG_COMMENT='" + TextBox5.Text + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();
                            ap_name = app_text.Text;
                            Label_Message.Text = "Successfully...";
                            Status = RadioButtonList1.SelectedItem.Text.ToString();
                            SendEMail(Status, 5, ap_name);

                        }

                        if (status_text.Text == "2" & RadioButtonList1.SelectedValue == "4")
                    {

                        sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '4' , MNG_COMMENT='" + TextBox5.Text + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                        con = new OdbcConnection(connection);
                        con.ConnectionString = connection;
                        con.Open();

                        comm = new OdbcCommand(sql, con);
                        comm.ExecuteNonQuery();
                        con.Close();

                        ap_name = app_text.Text;
                        Status = RadioButtonList1.SelectedItem.Text.ToString();
                        SendEMail(Status, 4, ap_name);

                    }
                        if (status_text.Text == "2" & RadioButtonList1.SelectedValue == "5")
                        {

                            sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '5' , MNG_COMMENT='" + TextBox5.Text + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();

                            ap_name = app_text.Text;
                            Status = RadioButtonList1.SelectedItem.Text.ToString();
                            SendEMail(Status , 4, ap_name);

                        }

                   
                }
              else
                    if (FUEL == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO)
                    {
                        if (status_text.Text == "1" & RadioButtonList1.SelectedValue == "6" & app_text.Text == "11") // approve for his staff
                        {

                            sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '6' , MNG_COMMENT='" + TextBox5.Text + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();

                            ap_name = app_text.Text;
                            Status = RadioButtonList1.SelectedItem.Text.ToString();
                            SendEMail(Status, 6, ap_name);

                        }
                        else
                            if (status_text.Text == "1" & RadioButtonList1.SelectedValue == "7" & app_text.Text == "11") // reject for his staff
                            {

                                sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '7' , MNG_COMMENT='" + TextBox5.Text + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                                con = new OdbcConnection(connection);
                                con.ConnectionString = connection;
                                con.Open();

                                comm = new OdbcCommand(sql, con);
                                comm.ExecuteNonQuery();
                                con.Close();

                                ap_name = app_text.Text;
                                Status = RadioButtonList1.SelectedItem.Text.ToString();
                                SendEMail(Status, 6, ap_name);

                            }
                            else

                                if (status_text.Text == "1" & RadioButtonList1.SelectedValue == "6")
                                {

                                    sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '2', MNG_COMMENT='" + TextBox5.Text + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                                    con = new OdbcConnection(connection);
                                    con.ConnectionString = connection;
                                    con.Open();

                                    comm = new OdbcCommand(sql, con);
                                    comm.ExecuteNonQuery();
                                    con.Close();

                                    Label_Message.Text = "Successfully...";
                                    ap_name = app_text.Text;
                                    Status = RadioButtonList1.SelectedItem.Text.ToString();
                                    SendEMail(Status, 7, ap_name);

                                }
                                else
                                    if (status_text.Text == "1" & RadioButtonList1.SelectedValue == "7")
                                    {

                                        sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '7' , MNG_COMMENT='" + TextBox5.Text + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                                        con = new OdbcConnection(connection);
                                        con.ConnectionString = connection;
                                        con.Open();

                                        comm = new OdbcCommand(sql, con);
                                        comm.ExecuteNonQuery();
                                        con.Close();

                                        ap_name = app_text.Text;
                                        Status = RadioButtonList1.SelectedItem.Text.ToString();
                                        SendEMail(Status, 7, ap_name);

                                    }
                                    else

                        if (status_text.Text == "2" & RadioButtonList1.SelectedValue == "6")
                        {

                            sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '6' , MNG_COMMENT='" + TextBox5.Text + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();

                            ap_name = app_text.Text;
                            Status = RadioButtonList1.SelectedItem.Text.ToString();
                            SendEMail(Status, 6, ap_name);

                        }
                        else
                        if (status_text.Text == "2" & RadioButtonList1.SelectedValue == "7")
                        {

                            sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '7' , MNG_COMMENT='" + TextBox5.Text + "' WHERE FORM_NO = '" + TextBox1.Text + "'";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();

                            ap_name = app_text.Text;
                            Status = RadioButtonList1.SelectedItem.Text.ToString();
                            SendEMail(Status, 6, ap_name);

                        }

                    }
                 

                    else
                       if (LOG == EMPLOYEE_NO)
                       {
                        /* if (LOG == EMPLOYEE_NO & MANAGER == EMPLOYEE_NO){ No = 12; }*/

                           sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "' WHERE FORM_NO = '" + TextBox1.Text + "'";

                           con = new OdbcConnection(connection);
                           con.ConnectionString = connection;
                           con.Open();

                           comm = new OdbcCommand(sql, con);
                           comm.ExecuteNonQuery();
                           con.Close();

                           ap_name = app_text.Text;
                           Status = RadioButtonList1.SelectedItem.Text.ToString();
                           SendEMail(Status, 8, ap_name);
                       }
                       else
                           if (FIN == EMPLOYEE_NO)
                           {

                               sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "' WHERE FORM_NO = '" + TextBox1.Text + "'";

                               con = new OdbcConnection(connection);
                               con.ConnectionString = connection;
                               con.Open();

                               comm = new OdbcCommand(sql, con);
                               comm.ExecuteNonQuery();
                               con.Close();

                               ap_name = app_text.Text;
                               Status = RadioButtonList1.SelectedItem.Text.ToString();
                               SendEMail(Status, 9, ap_name);
                           
                           
                           
                           }
                           else
                               if (ADMIN == EMPLOYEE_NO)
                               {
                                   sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "' WHERE FORM_NO = '" + TextBox1.Text + "'";

                                   con = new OdbcConnection(connection);
                                   con.ConnectionString = connection;
                                   con.Open();

                                   comm = new OdbcCommand(sql, con);
                                   comm.ExecuteNonQuery();
                                   con.Close();

                                   ap_name = app_text.Text;
                                   Status = RadioButtonList1.SelectedItem.Text.ToString();
                                   SendEMail(Status, 10, ap_name);
   
                               
                               }
                               
                           else
                                     if (HR == EMPLOYEE_NO)
                                   {
                                       sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "' WHERE FORM_NO = '" + TextBox1.Text + "'";

                                       con = new OdbcConnection(connection);
                                       con.ConnectionString = connection;
                                       con.Open();

                                       comm = new OdbcCommand(sql, con);
                                       comm.ExecuteNonQuery();
                                       con.Close();

                                       ap_name = app_text.Text;
                                       Status = RadioButtonList1.SelectedItem.Text.ToString();
                                       SendEMail(Status, 11, ap_name);
   
                                     }
                         else
                                         if (BUD == EMPLOYEE_NO)
                                         {

                                             sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "' WHERE FORM_NO = '" + TextBox1.Text + "'";

                                             con = new OdbcConnection(connection);
                                             con.ConnectionString = connection;
                                             con.Open();

                                             comm = new OdbcCommand(sql, con);
                                             comm.ExecuteNonQuery();
                                             con.Close();

                                             ap_name = app_text.Text;
                                             Status = RadioButtonList1.SelectedItem.Text.ToString();
                                             SendEMail(Status, 12, ap_name);
       
                                         
                                         }
                             else
                                             if (CONT == EMPLOYEE_NO)
                                             {

                                                 sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "' WHERE FORM_NO = '" + TextBox1.Text + "'";

                                                 con = new OdbcConnection(connection);
                                                 con.ConnectionString = connection;
                                                 con.Open();

                                                 comm = new OdbcCommand(sql, con);
                                                 comm.ExecuteNonQuery();
                                                 con.Close();

                                                 ap_name = app_text.Text;
                                                 Status = RadioButtonList1.SelectedItem.Text.ToString();
                                                 SendEMail(Status, 13, ap_name);
       
                                             
                                             }
                              else
                                                 if (CAMP == EMPLOYEE_NO)
                                                 {
                                                     sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "' WHERE FORM_NO = '" + TextBox1.Text + "'";

                                                     con = new OdbcConnection(connection);
                                                     con.ConnectionString = connection;
                                                     con.Open();

                                                     comm = new OdbcCommand(sql, con);
                                                     comm.ExecuteNonQuery();
                                                     con.Close();

                                                     ap_name = app_text.Text;
                                                     Status = RadioButtonList1.SelectedItem.Text.ToString();
                                                     SendEMail(Status, 14, ap_name); 
         
                                                 
                                                 }
                               else
                                                     if (PROCe == EMPLOYEE_NO)
                                                     {
                                                         sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "' WHERE FORM_NO = '" + TextBox1.Text + "'";

                                                         con = new OdbcConnection(connection);
                                                         con.ConnectionString = connection;
                                                         con.Open();

                                                         comm = new OdbcCommand(sql, con);
                                                         comm.ExecuteNonQuery();
                                                         con.Close();

                                                         ap_name = app_text.Text;
                                                         Status = RadioButtonList1.SelectedItem.Text.ToString();
                                                         SendEMail(Status, 15, ap_name); 


                                                     }
                                                     else


                                                   if (ICMANAGER == EMPLOYEE_NO)
                                                       {

                                                         if (status_text.Text == "1")
                                                               {
                                                                 sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '2' WHERE FORM_NO = '" + TextBox1.Text + "'";
                                                                 con = new OdbcConnection(connection);
                                                                 con.ConnectionString = connection;
                                                                 con.Open();

                                                                 comm = new OdbcCommand(sql, con);
                                                                 comm.ExecuteNonQuery();
                                                                 con.Close();

                                                               Label_Message.Text = "Successfully...";
                                                               ap_name = app_text.Text;
                                                               Status = RadioButtonList1.SelectedItem.Text.ToString();
                                                               SendEMail(Status, 16 , ap_name);

                            }

                            else
                            {
                                sql = "UPDATE ICT_APPLICATION SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "',REQUEST_EXECUTOR='', ICT_COMMENT = '" + TextBox5.Text + "' " +
                                     ", ICT_ID = '" + ICMANAGER + "', ICT_DATE = '" + date + "' WHERE FORM_NO = '" + TextBox1.Text + "'";


                                con = new OdbcConnection(connection);
                                con.ConnectionString = connection;
                                con.Open();

                                comm = new OdbcCommand(sql, con);
                                comm.ExecuteNonQuery();
                                con.Close();

                                ap_name = app_text.Text;
                                Status = RadioButtonList1.SelectedItem.Text.ToString();
                                SendEMail(Status, 1, ap_name);

                            }
                        }
               
                  
        }
        else
        {
            Reset();
            Panel1.Visible = false;
        }
    }

   /* private void UserList()
    {

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        ICMANAGER = Request.QueryString["ICM"];
    

      
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
    }*/



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
        text_de.Text = "";
        text_up.Text = "";
        text_in.Text = "";
       
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

    public void SendEMail(string Status, int UserCheck , string app)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        MANAGER = Request.QueryString["MNG"];
        ICMANAGER = Request.QueryString["ICM"];
        PROJECT = Request.QueryString["PR"];
        FUEL = Request.QueryString["FU"];
        INV = Request.QueryString["IN"];
        LOG = Request.QueryString["LO"];
        FIN = Request.QueryString["FI"];
        ADMIN = Request.QueryString["AD"];
        HR = Request.QueryString["H"];
        BUD = Request.QueryString["BU"];
        CONT = Request.QueryString["CO"];
        CAMP = Request.QueryString["CA"];
        ICMANAGER = Request.QueryString["ICM"];
        PROCe = Request.QueryString["Ce"];
        
        //EmId = DropDownList1.SelectedValue.ToString(); 

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


        // INV owner 
        string sql3 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
            "USERS_INFORMATIONS.EMPLOYEE_NO = '" + INV + "'";

        /// PROJECT owner 
        string sql4 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
         "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
         "USERS_INFORMATIONS.EMPLOYEE_NO = '" + PROJECT + "'";

        //SEND EMPLOYEE_IT
        string sql5 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
           "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
           "USERS_INFORMATIONS.EMPLOYEE_NO = '" + EmId + "'";

        // FUEL ADDRESS
        string sql6 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
           "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
           "USERS_INFORMATIONS.EMPLOYEE_NO = '" + FUEL + "'";

        // LOG ADDRESS
        string sql7 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
           "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
           "USERS_INFORMATIONS.EMPLOYEE_NO = '" + LOG + "'";

        // FIN ADDRESS
        string sql8 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
           "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
           "USERS_INFORMATIONS.EMPLOYEE_NO = '" + FIN + "'";

        //ADMIN ADDRESS
        string sql9 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
           "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
           "USERS_INFORMATIONS.EMPLOYEE_NO = '" + ADMIN + "'";

        //HR ADDRESS
        string sql10 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
           "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
           "USERS_INFORMATIONS.EMPLOYEE_NO = '" + HR + "'";

        //BUD ADDRESS
        string sql11 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
           "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
           "USERS_INFORMATIONS.EMPLOYEE_NO = '" + BUD + "'";


        //CONT ADDRESS
        string sql12 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
           "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
           "USERS_INFORMATIONS.EMPLOYEE_NO = '" + CONT + "'";

        //CAMP ADDRESS
        string sql13 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
           "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
           "USERS_INFORMATIONS.EMPLOYEE_NO = '" + CAMP + "'";

        //PROCument ADDRESS
        string sql14 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
           "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND " +
           "USERS_INFORMATIONS.EMPLOYEE_NO = '" + PROCe + "'";



        OdbcConnection conn = new OdbcConnection(connectionString);

        OdbcCommand cmd = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);
        OdbcCommand cmd4 = new OdbcCommand(sql4, conn);
        OdbcCommand cmd5 = new OdbcCommand(sql5, conn);
        OdbcCommand cmd6 = new OdbcCommand(sql6, conn);//13
        OdbcCommand cmd7 = new OdbcCommand(sql7, conn);
        OdbcCommand cmd8 = new OdbcCommand(sql8, conn);
        OdbcCommand cmd9 = new OdbcCommand(sql9, conn);
        OdbcCommand cmd10 = new OdbcCommand(sql10, conn);
        OdbcCommand cmd11 = new OdbcCommand(sql11, conn);
        OdbcCommand cmd12 = new OdbcCommand(sql12, conn);
        OdbcCommand cmd13 = new OdbcCommand(sql13, conn);
        OdbcCommand cmd14 = new OdbcCommand(sql14, conn);



        cmd.Connection.Open();

        OdbcDataReader read = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        OdbcDataReader read3 = cmd3.ExecuteReader();
        OdbcDataReader read4 = cmd4.ExecuteReader();
        OdbcDataReader read5 = cmd5.ExecuteReader();
        OdbcDataReader read6 = cmd6.ExecuteReader(); //13
        OdbcDataReader read7 = cmd7.ExecuteReader();
        OdbcDataReader read8 = cmd8.ExecuteReader();
        OdbcDataReader read9 = cmd9.ExecuteReader();
        OdbcDataReader read10 = cmd10.ExecuteReader();
        OdbcDataReader read11 = cmd11.ExecuteReader();
        OdbcDataReader read12 = cmd12.ExecuteReader();
        OdbcDataReader read13 = cmd13.ExecuteReader();
        OdbcDataReader read14 = cmd14.ExecuteReader();


        read.Read();
        read2.Read();
        read3.Read();
        read4.Read();
        read5.Read();
        read6.Read();
        read7.Read();//
        read8.Read();
        read9.Read();
        read10.Read();
        read11.Read();
        read12.Read();
        read13.Read();
        read14.Read(); 


        if (read.HasRows) // Requester 
        {
            EmpName = read["FULL_USER_NAME"].ToString();
            EmpEmail = read["EMAIL"].ToString();
            Depart = read["DEP_NAME"].ToString();
        }
        if (read2.HasRows)  // ICT_MNG
        {
            EmpName2 = read2["FULL_USER_NAME"].ToString();
            EmpEmail2 = read2["EMAIL"].ToString();

        }
        if (read3.HasRows)   //  INV 
        {
            EmpName3 = read3["FULL_USER_NAME"].ToString();
            EmpEmail3 = read3["EMAIL"].ToString();

        }
        if (read4.HasRows)   //  PROJECT 
        {
            EmpName4 = read4["FULL_USER_NAME"].ToString();
            EmpEmail4 = read4["EMAIL"].ToString();

        }
  
        if (read5.HasRows) // EMPLOYEE_IT
        {
          ITEMP = read5["FULL_USER_NAME"].ToString();
          ITEmail = read5["EMAIL"].ToString(); 
        }

        if (read6.HasRows)   // FUEL
        {
            EmpName6 = read6["FULL_USER_NAME"].ToString();
            EmpEmail6 = read6["EMAIL"].ToString();

        }
        if (read7.HasRows)   // LOG
        {
            EmpName7 = read7["FULL_USER_NAME"].ToString();
            EmpEmail7 = read7["EMAIL"].ToString();

        }
        if (read8.HasRows)   // FIN
        {
            EmpName8 = read8["FULL_USER_NAME"].ToString();
            EmpEmail8 = read8["EMAIL"].ToString();

        }
        if (read9.HasRows)   // ADMIN
        {
            EmpName9 = read9["FULL_USER_NAME"].ToString();
            EmpEmail9 = read9["EMAIL"].ToString();

        }
        if (read10.HasRows)   // HR
        {
            EmpName10 = read10["FULL_USER_NAME"].ToString();
            EmpEmail10 = read10["EMAIL"].ToString();
        }
        if (read11.HasRows)   // BUD
        {
            EmpName11 = read11["FULL_USER_NAME"].ToString();
            EmpEmail11 = read11["EMAIL"].ToString();

        }
        if (read12.HasRows)   // CONT
        {
            EmpName12 = read12["FULL_USER_NAME"].ToString();
            EmpEmail12 = read12["EMAIL"].ToString();

        }
        if (read13.HasRows)   // CAMP
        {
            EmpName13 = read13["FULL_USER_NAME"].ToString();
            EmpEmail13 = read13["EMAIL"].ToString();

        }

        if (read14.HasRows)   // PROCUMENT 
        {
            EmpName14 = read14["FULL_USER_NAME"].ToString();
            EmpEmail14 = read14["EMAIL"].ToString();

        }
      


        //if ICT MANAGER
        if (UserCheck == 1)
        {
            if (EmId == "0" | EmId == "<<<Select>>>")
            {
                Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&comment=" + TextBox5 + "&DATE=" + date + "" +
                      "&ApprovalName=&ApprovalEmail=&REQNAME= Application Access Request (AR)&AUTHORNAME=" + EmpName2 + "");
                /*Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                     "&ApprovalName=" + EmpName + "&ApprovalEmail=" + EmpEmail + "&REQNAME=Equpment Request (TRF)&AUTHORNAME=" + EmpName + "");*/

            }
            else
            {
                Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&comment=" + TextBox5 + "&DATE=" + date + "" +
                     "&ApprovalName=" + ITEMP + "&ApprovalEmail=" + ITEmail + "&REQNAME= Application Access Request (AR)&AUTHORNAME=" + EmpName2 + "");
                /*Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                     "&ApprovalName=" + EmpName + "&ApprovalEmail=" + EmpEmail + "&REQNAME=Equpment Request (TRF)&AUTHORNAME=" + EmpName + "");*/

            }
        }

        if (UserCheck == 2) // For staff , owner ---- INV  
        {
            
            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
               "&ApprovalName=&ApprovalEmail=&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName3 + "");

        }

         if (UserCheck == 3) // For staff owner and other app --- INV   
        {
            if (app == "1")
            {
                Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                   "&ApprovalName=" + EmpName9 + "&ApprovalEmail=" + EmpEmail9 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName3 + "");
            }
            else
                if (app == "2")
                {
                    Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                       "&ApprovalName=" + EmpName14 + "&ApprovalEmail=" + EmpEmail14 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName3 + "");
                }
                else
                    /*if (app == "3")
                    {
                        Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                           "&ApprovalName=" + EmpName3 + "&ApprovalEmail=" + EmpEmail3 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName3 + "");
                    }
                    else*/
                        if (app == "4") // HR 
                        {
                             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                        "&ApprovalName=" + EmpName10 + "&ApprovalEmail=" + EmpEmail10 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName3 + "");

                        }
                        else
                            if (app == "5") // FIANANCE 
                            {
                                Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                           "&ApprovalName=" + EmpName8 + "&ApprovalEmail=" + EmpEmail8 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName3 + "");

                            }
                            else
                                if (app == "6") // BUD 
                                {
                                    Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                               "&ApprovalName=" + EmpName11 + "&ApprovalEmail=" + EmpEmail11 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName3 + "");

                                }
                                else
                                    if (app == "7") // Project 
                                    {
                                        Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                   "&ApprovalName=" + EmpName4 + "&ApprovalEmail=" + EmpEmail4 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName3 + "");

                                    }
                                    else
                                        if (app == "8") // Logistic 
                                        {
                                            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                       "&ApprovalName=" + EmpName7 + "&ApprovalEmail=" + EmpEmail7 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName3 + "");
                                        }
                                        else
                                            if (app == "9") // Contract 
                                            {
                                                Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                           "&ApprovalName=" + EmpName12 + "&ApprovalEmail=" + EmpEmail12 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName3 + "");
                                            }
                                            else
                                                if (app == "10") // Camps 
                                                {
                                                    Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                               "&ApprovalName=" + EmpName13 + "&ApprovalEmail=" + EmpEmail13 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName3 + "");
                                                }
                                                else
                                                    if (app == "11") // Fuel 
                                                    {
                                                        Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                                   "&ApprovalName=" + EmpName6 + "&ApprovalEmail=" + EmpEmail6 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName3 + "");
                                                    }
        }

         if (UserCheck == 4) // For staff , owner ---- Project 
         {

             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                "&ApprovalName=&ApprovalEmail=&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName4 + "");

         }


         if (UserCheck == 5) // For staff owner and other app --- Project   
         {
             if (app == "1")
             {
                 Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                    "&ApprovalName=" + EmpName9 + "&ApprovalEmail=" + EmpEmail9 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName4 + "");
             }
             else
                 if (app == "2")
                 {
                     Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                        "&ApprovalName=" + EmpName14 + "&ApprovalEmail=" + EmpEmail14 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName4 + "");
                 }
                 else
                     if (app == "3")
                     {
                         Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                            "&ApprovalName=" + EmpName3 + "&ApprovalEmail=" + EmpEmail3 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName4 + "");
                     }
                     else
                     if (app == "4") // HR 
                     {
                         Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                    "&ApprovalName=" + EmpName10 + "&ApprovalEmail=" + EmpEmail10 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName4 + "");

                     }
                     else
                         if (app == "5") // FIANANCE 
                         {
                             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                        "&ApprovalName=" + EmpName8 + "&ApprovalEmail=" + EmpEmail8 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName4 + "");

                         }
                         else
                             if (app == "6") // BUD 
                             {
                                 Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                            "&ApprovalName=" + EmpName11 + "&ApprovalEmail=" + EmpEmail11 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName4 + "");

                             }
                             /*else
                                 if (app == "7") // Project 
                                 {
                                     Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                "&ApprovalName=" + EmpName4 + "&ApprovalEmail=" + EmpEmail4 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName4 + "");

                                 }*/
                                 else
                                     if (app == "8") // Logistic 
                                     {
                                         Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                    "&ApprovalName=" + EmpName7 + "&ApprovalEmail=" + EmpEmail7 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName4 + "");
                                     }
                                     else
                                         if (app == "9") // Contract 
                                         {
                                             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                        "&ApprovalName=" + EmpName12 + "&ApprovalEmail=" + EmpEmail12 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName4 + "");
                                         }
                                         else
                                             if (app == "10") // Camps 
                                             {
                                                 Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                            "&ApprovalName=" + EmpName13 + "&ApprovalEmail=" + EmpEmail13 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName4 + "");
                                             }
                                             else
                                                 if (app == "11") // Fuel 
                                                 {
                                                     Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                                "&ApprovalName=" + EmpName6 + "&ApprovalEmail=" + EmpEmail6 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName4 + "");
                                                 }
         }


         if (UserCheck == 6) // For staff , owner ---- FUEL  
         {

             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                "&ApprovalName=&ApprovalEmail=&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName6 + "");

         }

         if (UserCheck == 7) // For staff owner and other app --- FUEL    
         {
             if (app == "1")
             {
                 Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                    "&ApprovalName=" + EmpName9 + "&ApprovalEmail=" + EmpEmail9 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName6 + "");
             }
             else
                 if (app == "2")
                 {
                     Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                        "&ApprovalName=" + EmpName14 + "&ApprovalEmail=" + EmpEmail14 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName6 + "");
                 }
                 else
                     if (app == "3")
                     {
                         Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                            "&ApprovalName=" + EmpName3 + "&ApprovalEmail=" + EmpEmail3 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName6 + "");
                     }
                     else
                         if (app == "4") // HR 
                         {
                             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                        "&ApprovalName=" + EmpName10 + "&ApprovalEmail=" + EmpEmail10 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName6 + "");

                         }
                         else
                             if (app == "5") // FIANANCE 
                             {
                                 Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                            "&ApprovalName=" + EmpName8 + "&ApprovalEmail=" + EmpEmail8 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName6 + "");

                             }
                             else
                                 if (app == "6") // BUD 
                                 {
                                     Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                "&ApprovalName=" + EmpName11 + "&ApprovalEmail=" + EmpEmail11 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName6 + "");

                                 }
                                 else
                                     if (app == "7") // Project 
                                     {
                                         Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                    "&ApprovalName=" + EmpName4 + "&ApprovalEmail=" + EmpEmail4 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName6 + "");

                                     }
                                 else
                                     if (app == "8") // Logistic 
                                     {
                                         Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                    "&ApprovalName=" + EmpName7 + "&ApprovalEmail=" + EmpEmail7 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName6 + "");
                                     }
                                     else
                                         if (app == "9") // Contract 
                                         {
                                             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                        "&ApprovalName=" + EmpName12 + "&ApprovalEmail=" + EmpEmail12 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName6 + "");
                                         }
                                         else
                                             if (app == "10") // Camps 
                                             {
                                                 Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                            "&ApprovalName=" + EmpName13 + "&ApprovalEmail=" + EmpEmail13 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName6 + "");
                                             }
                                             /*else
                                                 if (app == "11") // Fuel 
                                                 {
                                                     Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                                "&ApprovalName=" + EmpName6 + "&ApprovalEmail=" + EmpEmail6 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName6 + "");
                                                 }*/
         }


         if (UserCheck == 8) // For staff , owner ---- Logistic  
         {

             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                "&ApprovalName=&ApprovalEmail=&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName7 + "");

         }

         if (UserCheck == 9) // For staff , owner ---- FIN  
         {

             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                "&ApprovalName=&ApprovalEmail=&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName8 + "");

         }

         if (UserCheck == 10) // For staff , owner ---- DMIN  
         {

             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                "&ApprovalName=&ApprovalEmail=&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName9 + "");

         }

         if (UserCheck == 11) // For staff , owner ---- HR  
         {

             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                "&ApprovalName=&ApprovalEmail=&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName10 + "");

         }

         if (UserCheck == 12) // For staff , owner ---- BUD  
         {

             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                "&ApprovalName=&ApprovalEmail=&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName11 + "");

         }

         if (UserCheck == 13) // For staff , owner ---- CONT  
         {

             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                "&ApprovalName=&ApprovalEmail=&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName12 + "");

         }

         if (UserCheck == 14) // For staff , owner ---- CAMP  
         {

             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                "&ApprovalName=&ApprovalEmail=&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName13 + "");

         }

         if (UserCheck == 15) // For staff , owner ---- PRocum  
         {

             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                "&ApprovalName=&ApprovalEmail=&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName14 + "");

         } 


         if (UserCheck == 16) // ICT _ staff    
         {
             if (app == "1")
             {
                 Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                    "&ApprovalName=" + EmpName9 + "&ApprovalEmail=" + EmpEmail9 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName2 + "");
             }
             else
                 if (app == "2")
                 {
                     Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                        "&ApprovalName=" + EmpName14 + "&ApprovalEmail=" + EmpEmail14 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName2 + "");
                 }
                 else
                     if (app == "3")
                     {
                         Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                            "&ApprovalName=" + EmpName3 + "&ApprovalEmail=" + EmpEmail3 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName2 + "");
                     }
                     else
                         if (app == "4") // HR 
                         {
                             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                        "&ApprovalName=" + EmpName10 + "&ApprovalEmail=" + EmpEmail10 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName2 + "");

                         }
                         else
                             if (app == "5") // FIANANCE 
                             {
                                 Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                            "&ApprovalName=" + EmpName8 + "&ApprovalEmail=" + EmpEmail8 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName2 + "");

                             }
                             else
                                 if (app == "6") // BUD 
                                 {
                                     Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                "&ApprovalName=" + EmpName11 + "&ApprovalEmail=" + EmpEmail11 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName2 + "");

                                 }
                                 else
                                     if (app == "7") // Project 
                                     {
                                         Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                    "&ApprovalName=" + EmpName4 + "&ApprovalEmail=" + EmpEmail4 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName2 + "");

                                     }
                                     else
                                         if (app == "8") // Logistic 
                                         {
                                             Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                        "&ApprovalName=" + EmpName7 + "&ApprovalEmail=" + EmpEmail7 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName2 + "");
                                         }
                                         else
                                             if (app == "9") // Contract 
                                             {
                                                 Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                            "&ApprovalName=" + EmpName12 + "&ApprovalEmail=" + EmpEmail12 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName2 + "");
                                             }
                                             else
                                                 if (app == "10") // Camps 
                                                 {
                                                     Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                                "&ApprovalName=" + EmpName13 + "&ApprovalEmail=" + EmpEmail13 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName2 + "");
                                                 }
                                               else
                                                   if (app == "11") // Fuel 
                                                   {
                                                        Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                                                    "&ApprovalName=" + EmpName6 + "&ApprovalEmail=" + EmpEmail6 + "&REQNAME=Application Access Request (AR)&AUTHORNAME=" + EmpName2 + "");
                                                     }
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
      //  EmId = DropDownList1.SelectedValue.ToString();

    }









    protected void Updtaa_Click(object sender, EventArgs e)
    {


        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        int count = GridView3.Rows.Count;

        foreach (GridViewRow row in GridView3.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[1].FindControl("IN") as CheckBox);
                CheckBox chkRow1 = (row.Cells[2].FindControl("UP") as CheckBox);
                CheckBox chkRow2 = (row.Cells[3].FindControl("DE") as CheckBox);


                /// text_in.Text = row.Cells[0].Text;


                if (chkRow.Checked)
                {

                    text_in.Text = row.Cells[0].Text;
                    Return_Menu_NO(text_in.Text);
                    CheckUser(text_in.Text);

                    PR_ID();

                    if (Us_ID.Text != "" & App_ID.Text != "")
                    {
                        //  sql = "UPDATE INTO USER_PRIVILEGS" +
                        // "(UP3_ID,INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +
                        //  "('" + TextBox7.Text + "','1','0','0','5','" + MN_ID.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";

                        sql = "UPDATE USER_PRIVILEGS SET INSERT_ALLOWED='1' , APPROVED_DEGREE='5' WHERE PI_PROGRAM_NO='" + App_ID.Text + "'";

                        con = new OdbcConnection(connection);
                        con.ConnectionString = connection;
                        con.Open();
                        comm = new OdbcCommand(sql, con);
                        comm.ExecuteNonQuery();
                        con.Close();
                        text_in.Text = "";
                        MN_ID.Text = "";
                        chkRow.Checked = false;

                    }
                    else
                    {
                        PR_ID();
                        sql = "INSERT INTO USER_PRIVILEGS" +
                       "(UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +

                      "('" + TextBox7.Text + "','1','0','0','5','" + MN_ID.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";
                        con = new OdbcConnection(connection);
                        con.ConnectionString = connection;
                        con.Open();

                        comm = new OdbcCommand(sql, con);
                        comm.ExecuteNonQuery();
                        con.Close();
                        text_in.Text = "";
                        MN_ID.Text = "";
                        chkRow.Checked = false;
                    }


                }
                if (chkRow1.Checked)
                {

                    text_up.Text = row.Cells[0].Text;
                    Return_Menu_NO(text_up.Text);
                    CheckUser(text_up.Text);
                    PR_ID();


                    if (Us_ID.Text != "" & App_ID.Text != "")
                    {

                        // sql = "INSERT INTO USER_PRIVILEGS" +
                        //"(UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +

                        //"('" + TextBox7.Text + "','0','0','1','5','" + MN_ID.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";

                        sql = "UPDATE USER_PRIVILEGS SET CHANGE_ALLOWED='1' , APPROVED_DEGREE='5' WHERE PI_PROGRAM_NO='" + App_ID.Text + "'";
                        con = new OdbcConnection(connection);
                        con.ConnectionString = connection;
                        con.Open();

                        comm = new OdbcCommand(sql, con);
                        comm.ExecuteNonQuery();
                        con.Close();
                        text_up.Text = "";
                        MN_ID.Text = "";
                        chkRow1.Checked = false;
                    }

                    else
                    {

                        PR_ID();

                        sql = "INSERT INTO USER_PRIVILEGS" +
                        "(UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +

                       "('" + TextBox7.Text + "','0','0','1','5','" + MN_ID.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";
                        con = new OdbcConnection(connection);
                        con.ConnectionString = connection;
                        con.Open();

                        comm = new OdbcCommand(sql, con);
                        comm.ExecuteNonQuery();
                        con.Close();
                        text_up.Text = "";
                        MN_ID.Text = "";
                        chkRow1.Checked = false;

                    }
                }

                if (chkRow2.Checked)
                {
                    text_de.Text = row.Cells[0].Text;
                    Return_Menu_NO(text_de.Text);
                    CheckUser(text_de.Text);
                    PR_ID();

                    if (Us_ID.Text != "" & App_ID.Text != "")
                    {

                        // sql = "INSERT INTO USER_PRIVILEGS" +
                        // "(UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +

                        //"('" + TextBox7.Text + "','0','1','0','5','" + MN_ID.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";
                        sql = "UPDATE USER_PRIVILEGS SET DELETE_ALLOWED='1' , APPROVED_DEGREE='5' WHERE PI_PROGRAM_NO='" + App_ID.Text + "'";
                        con = new OdbcConnection(connection);
                        con.ConnectionString = connection;
                        con.Open();

                        comm = new OdbcCommand(sql, con);
                        comm.ExecuteNonQuery();
                        con.Close();
                        text_de.Text = "";
                        MN_ID.Text = "";
                        chkRow2.Checked = false;
                    }

                    else
                    {
                        sql = "INSERT INTO USER_PRIVILEGS" +
                        "(UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +

                       "('" + TextBox7.Text + "','0','1','0','5','" + MN_ID.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";
                        con = new OdbcConnection(connection);
                        con.ConnectionString = connection;
                        con.Open();

                        comm = new OdbcCommand(sql, con);
                        comm.ExecuteNonQuery();
                        con.Close();
                        text_de.Text = "";
                        MN_ID.Text = "";
                        chkRow2.Checked = false;


                    }

                }
            }
        }
    }



    protected void Butt_Click(object sender, EventArgs e)
    {
         rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
         connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
       
         //int count = GridView3.Rows.Count;
            
          for (int i = 0; i < GridView3.Rows.Count; i++){
             
            CheckBox chkRow  =  (GridView3.Rows[i].Cells[1].FindControl("IN") as CheckBox); 
            CheckBox chkRow1 =  (GridView3.Rows[i].Cells[2].FindControl("UP") as CheckBox);
            CheckBox chkRow2 =  (GridView3.Rows[i].Cells[3].FindControl("DE") as CheckBox);


                    if (chkRow.Checked)
                    {
                        //text_in.Text = row.Cells[0].Text;
                        text_in.Text = GridView3.Rows[i].Cells[0].Text; 
                        Return_Menu_NO(text_in.Text);
                        CheckUser(text_in.Text);

                        PR_ID();

                        if (Us_ID.Text != "" & App_ID.Text != "")
                        {
                            //  sql = "UPDATE INTO USER_PRIVILEGS" +
                            // "(UP3_ID,INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +
                            //  "('" + TextBox7.Text + "','1','0','0','5','" + MN_ID.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";

                            sql = "UPDATE USER_PRIVILEGS SET INSERT_ALLOWED='1' , APPROVED_DEGREE='5' WHERE PI_PROGRAM_NO='" + App_ID.Text + "'";

                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();
                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();

                            text_in.Text = "";
                            MN_ID2.Text = "";
                            Us_ID.Text = "";
                            App_ID.Text = ""; 
                            chkRow.Checked = false;

                        }
                        else
                        {
                            PR_ID();
                            sql = "INSERT INTO USER_PRIVILEGS" +
                           "(UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +

                          "('" + TextBox7.Text + "','1','0','0','5','" + App_ID.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();
                            text_in.Text = "";
                            MN_ID2.Text = "";
                            chkRow.Checked = false;
                        }

                    }

                    if (chkRow1.Checked)
                    {

                        text_up.Text = GridView3.Rows[i].Cells[0].Text; 
                        Return_Menu_NO(text_up.Text);
                        CheckUser(text_up.Text);
                        PR_ID();


                        if (Us_ID.Text != "" & App_ID.Text != "")
                        {

                            // sql = "INSERT INTO USER_PRIVILEGS" +
                            //"(UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +

                            //"('" + TextBox7.Text + "','0','0','1','5','" + MN_ID.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";

                            sql = "UPDATE USER_PRIVILEGS SET CHANGE_ALLOWED='1' , APPROVED_DEGREE='5' WHERE PI_PROGRAM_NO='" + App_ID.Text + "'";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();
                            text_up.Text = "";
                            MN_ID2.Text = "";
                            chkRow1.Checked = false;
                        }

                        else
                        {

                            PR_ID();

                            sql = "INSERT INTO USER_PRIVILEGS" +
                            "(UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +

                           "('" + TextBox7.Text + "','0','0','1','5','" + App_ID.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                             comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();
                            text_up.Text = "";
                            MN_ID2.Text = "";
                            chkRow1.Checked = false;

                        }
                    }

                    if (chkRow2.Checked)
                    {
                        text_de.Text =  GridView3.Rows[i].Cells[0].Text; 
                        Return_Menu_NO(text_de.Text);
                        CheckUser(text_de.Text);
                        PR_ID();

                        if (Us_ID.Text != "" & App_ID.Text != "")
                        {

                            // sql = "INSERT INTO USER_PRIVILEGS" +
                            // "(UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +

                            //"('" + TextBox7.Text + "','0','1','0','5','" + MN_ID.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";
                            sql = "UPDATE USER_PRIVILEGS SET DELETE_ALLOWED='1' , APPROVED_DEGREE='5' WHERE PI_PROGRAM_NO='" + App_ID.Text + "'";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();
                            text_de.Text = "";
                            MN_ID2.Text = "";
                            chkRow2.Checked = false;
                        }

                        else
                        {
                            sql = "INSERT INTO USER_PRIVILEGS" +
                            "(UP3_ID, INSERT_ALLOWED, DELETE_ALLOWED, CHANGE_ALLOWED, APPROVED_DEGREE, PI_PROGRAM_NO, UG_GROUP_NO, UI_USER_NO, CREATE_DATE, ENABLE, MAIN_MODULE) VALUES" +

                           "('" + TextBox7.Text + "','0','1','0','5','" + App_ID.Text + "','','" + user_no.Text + "','" + text_date.Text + "','1','')";
                            con = new OdbcConnection(connection);
                            con.ConnectionString = connection;
                            con.Open();

                            comm = new OdbcCommand(sql, con);
                            comm.ExecuteNonQuery();
                            con.Close();
                            text_de.Text = "";
                            MN_ID2.Text = "";
                            chkRow2.Checked = false;

                        }
                    }
                }
            }
                  

}