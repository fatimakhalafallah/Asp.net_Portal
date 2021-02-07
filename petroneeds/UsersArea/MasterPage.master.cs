using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Odbc;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public SqlCommand comm = null;
    public SqlConnection con = null;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;
    public string EMPLOYEE_NO, SUPER, CONT, PROCe, LOG, BUD, INV, CAMP, PRO, FUEL, DEPARTMENT_NO, GM, HR, ADMIN, EMNG, ICMANAGER, MANAGER, SUPERVISOR, URLPAGE, HRMANAGER, FINANCEMG, GMANAGER, MANAGERSUPERVISOR, STATIONERYAPP, SINMANAGER, FINANCEADMIN;
    string SessionNo;

    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
        {
            //Link_Leave.Enabled = false;
            //Link_Salary.Enabled = false;
            //LinkTravel.Enabled = false;
            //Link_Recruitment.Enabled = false;

            //Link_Travel.Enabled = false;
            //Link_Function.Enabled = false;
            //Link_Stationary.Enabled = false;

            EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
            DEPARTMENT_NO = Request.QueryString["DEP_NO"];

            if (Session["loginStatus"] == "" || Session["loginStatus"] == null)
            {
                Response.Redirect("~/Login.aspx");
                //Response.Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                SessionNo = Session["loginStatus"].ToString();
                //Response.Write(SessionNo);
            }
            if (EMPLOYEE_NO == "" || EMPLOYEE_NO == null && DEPARTMENT_NO == "" || DEPARTMENT_NO == null)
            {
                Response.Redirect("~/Login.aspx");
            }
        }
         Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
         Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
         Response.Cache.SetNoStore();
    }
    protected void LinkTravel_Click(object sender, EventArgs e)
    {
        URLPAGE = "Admin_TravelMigration.aspx";
        CheckAdminHRAdmin(URLPAGE);
    }
    protected void Link_Leave_Click(object sender, EventArgs e)
    {
        URLPAGE = "LeaveAdmin.aspx";
        CheckAdmin(URLPAGE);
    }
    protected void Link_Salary_Click(object sender, EventArgs e)
    {
        URLPAGE = "Admin_Salary_Advance.aspx";
        CheckHRAdmin(URLPAGE);
    }
    protected void Link_Recruitment_Click(object sender, EventArgs e)
    {
        URLPAGE = "Admin_Recruitment.aspx";
        CheckAdminHRGMAdmin(URLPAGE);
    }
    protected void Link_Travel_Click(object sender, EventArgs e)
    {
        URLPAGE = "Admin_Travel.aspx";
        CheckAdminHRAdmin(URLPAGE);
    }
    protected void Link_Function_Click(object sender, EventArgs e)
    {
        URLPAGE = "Admin_FunctionRequest.aspx";
        CheckAdminAdminApproval(URLPAGE);
    }
    protected void Link_Stationary_Click(object sender, EventArgs e)
    {
        URLPAGE = "Admin_StationeryRequest.aspx";
        CheckAdmin2(URLPAGE);
    }
    protected void ICT_eq_Click(object sender, EventArgs e)
    {
        URLPAGE = "EQU_Approve.aspx";
        CheckAdmICTM(URLPAGE);
    }

    protected void ICT_Account_Click(object sender, EventArgs e)
    {
        URLPAGE = "Account_approve.aspx";
        CheckMICT(URLPAGE);
    }
    protected void Furniture_Link_Click(object sender, EventArgs e)
    {
        URLPAGE = "AdminFurniture.aspx";
        CheckAdmin1(URLPAGE);
    }
    protected void ICT_Tele_Click1(object sender, EventArgs e)
    {
        URLPAGE = "Telec.aspx";
        CheckTEL(URLPAGE);
    }

    protected void Card_Link_Click(object sender, EventArgs e)
    {
        //URLPAGE = "BussinessCard_Approve.aspx";
       // CheckCard(URLPAGE);
    }

    protected void Vehicle_Link_Click(object sender, EventArgs e)
    {
        URLPAGE = "VehicleRequest_Approve.aspx";
        CheckVE(URLPAGE);
    }


    protected void ICT_App_Click(object sender, EventArgs e)
    {
        
       URLPAGE = "Application_app2.aspx";
        Checkappp(URLPAGE);
    }


    void Checkappp(string URL)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        string sql = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID='31'"; //ICT
        string sql2 = "SELECT MNG FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "'";//MNG
        string sql3 = "SELECT EMPLOYEE_NO FROM  REQUEST_ACTORS  WHERE REQUEST_TYPE_ID='40'"; //PROJECT
        string sql4 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID='44'"; //FUEL
        string sql5 = "SELECT EMPLOYEE_NO FROM  REQUEST_ACTORS  WHERE REQUEST_TYPE_ID='37'"; //InventroyControl
        string sql6 = "SELECT EMPLOYEE_NO FROM  REQUEST_ACTORS  WHERE REQUEST_TYPE_ID='41'"; // LOGISTIC 
        string sql7 = "SELECT EMPLOYEE_NO FROM  REQUEST_ACTORS  WHERE REQUEST_TYPE_ID='34'"; //FIANANCE 
        string sql8 = "SELECT EMPLOYEE_NO FROM  REQUEST_ACTORS  WHERE REQUEST_TYPE_ID='35'"; //ADMINRATION 
        string sql9 = "SELECT EMPLOYEE_NO FROM  REQUEST_ACTORS  WHERE REQUEST_TYPE_ID='38'"; //HR
        string sql10 = "SELECT EMPLOYEE_NO FROM  REQUEST_ACTORS  WHERE REQUEST_TYPE_ID='39'"; //BUDGET CONTROL
        string sql11 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID='42'"; // CONTRACTS 
        string sql12 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID='43'"; //CAMP
        string sql13 = "SELECT EMPLOYEE_NO FROM  REQUEST_ACTORS  WHERE REQUEST_TYPE_ID='36'"; //Procurement

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);
        OdbcCommand cmd4 = new OdbcCommand(sql4, conn);
        OdbcCommand cmd5 = new OdbcCommand(sql5, conn);
        OdbcCommand cmd6 = new OdbcCommand(sql6, conn);
        OdbcCommand cmd7 = new OdbcCommand(sql7, conn);
        OdbcCommand cmd8 = new OdbcCommand(sql8, conn);
        OdbcCommand cmd9 = new OdbcCommand(sql9, conn);
        OdbcCommand cmd10 = new OdbcCommand(sql10, conn);
        OdbcCommand cmd11 = new OdbcCommand(sql11, conn);
        OdbcCommand cmd12 = new OdbcCommand(sql12, conn);
        OdbcCommand cmd13 = new OdbcCommand(sql13, conn);



        cmd.Connection.Open();

        OdbcDataReader read = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        OdbcDataReader read3 = cmd3.ExecuteReader();
        OdbcDataReader read4 = cmd4.ExecuteReader();
        OdbcDataReader read5 = cmd5.ExecuteReader();
        OdbcDataReader read6 = cmd6.ExecuteReader();
        OdbcDataReader read7 = cmd7.ExecuteReader();
        OdbcDataReader read8 = cmd8.ExecuteReader();
        OdbcDataReader read9 = cmd9.ExecuteReader();
        OdbcDataReader read10 = cmd10.ExecuteReader();
        OdbcDataReader read11 = cmd11.ExecuteReader();
        OdbcDataReader read12 = cmd12.ExecuteReader();
        OdbcDataReader read13 = cmd13.ExecuteReader();


        read.Read();
        read2.Read();
        read3.Read();
        read4.Read();
        read5.Read();
        read6.Read();
        read7.Read();
        read8.Read();
        read9.Read();
        read10.Read();
        read11.Read();
        read12.Read();
        read13.Read();


        if (read.HasRows)
        { ICMANAGER = read["EMPLOYEE_NO"].ToString(); }
        else { ICMANAGER = "0"; }
        if (read2.HasRows)
        { MANAGER = read2["MNG"].ToString(); }
        else { MANAGER = "0"; }
        if (read3.HasRows)
        { PRO = read3["EMPLOYEE_NO"].ToString(); }
        else { PRO = "0"; }
        if (read4.HasRows)
        { FUEL = read4["EMPLOYEE_NO"].ToString(); }
        else { FUEL = "0"; }
        if (read5.HasRows)
        { INV = read5["EMPLOYEE_NO"].ToString(); }
        else { INV = "0"; }
        if (read6.HasRows)
        { LOG = read6["EMPLOYEE_NO"].ToString(); }
        else { LOG = "0"; }
        if (read7.HasRows)
        { FINANCEADMIN = read7["EMPLOYEE_NO"].ToString(); }
        else { FINANCEADMIN = "0"; }
        if (read8.HasRows)
        { ADMIN = read8["EMPLOYEE_NO"].ToString(); }
        else { ADMIN = "0"; }
        if (read9.HasRows)
        { HR = read9["EMPLOYEE_NO"].ToString(); }
        else { HR = "0"; }
        if (read10.HasRows)
        { BUD = read10["EMPLOYEE_NO"].ToString(); }
        else { BUD = "0"; }
        if (read11.HasRows)
        { CONT = read11["EMPLOYEE_NO"].ToString(); }
        else { CONT = "0"; }
        if (read12.HasRows)
        { CAMP = read12["EMPLOYEE_NO"].ToString(); }
        else { CAMP = "0"; }
        if (read13.HasRows)
        { PROCe = read13["EMPLOYEE_NO"].ToString(); }
        else { PROCe = "0"; }

        if (MANAGER != "0" || ICMANAGER != "0" || PRO != "0" || FUEL != "0" || INV != "0" || LOG != "0" || FINANCEADMIN != "0" || ADMIN != "0" || HR != "0" || BUD != "0" || CONT != "0" || CAMP != "0" || PROCe != "0")
        {
            ICT_App.Enabled = true;
            Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&MNG=" + MANAGER + "&ICM=" + ICMANAGER + "&PR=" + PRO + "&FU=" + FUEL + "&IN=" + INV + "&LO=" + LOG + "&FI=" + FINANCEADMIN + "&AD=" + ADMIN + "&H=" + HR + "&BU=" + BUD + "&CO=" + CONT + "&CA=" + CAMP + "&Ce=" + PROCe + "");
        }

        else
        {
            ICT_App.Enabled = false;
        }
        cmd.Connection.Close();

    }

    void CheckVE(string URL)
    {

        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];


        string sql = "SELECT SUPER FROM EMP_MNG WHERE SUPER = '" + EMPLOYEE_NO + "'";
        string sql2 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '45'"; // ADMIN VECHILE

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
            SUPER = read["SUPER"].ToString();
        }
        else
        {
            SUPER = "0";
        }
        if (read2.HasRows)
        {
            ADMIN = read2["EMPLOYEE_NO"].ToString();
        }
        else
        {
            ADMIN = "0";
        }

        if (ADMIN != "0" || SUPER != "0")
        {

            Vehicle_Link.Enabled = true;
            Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&SUPER=" + SUPER + "&ADMIN=" + ADMIN + "");
            //Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&MNG=" + MANAGER + "&STATIONERYAPP=" + STATIONERYAPP + "");
        }
        else
        {
            Vehicle_Link.Enabled = false;
        }
        cmd.Connection.Close();

    }

    void CheckCard(string URL)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        //string sql  = "SELECT MNG, SUPER FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "' OR SUPER = '" + EMPLOYEE_NO + "'";

        string sql = "SELECT MNG FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "'";
        string sql2 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '12'"; // HR 
        string sql3 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '13'"; //Admin

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

        if (read.HasRows)
        {
            MANAGER = read["MNG"].ToString();
        }
        else
        {
            MANAGER = "0";
        }
        if (read2.HasRows)
        {
            HR = read2["EMPLOYEE_NO"].ToString();
        }
        else
        {
            HR = "0";
        }
        if (read3.HasRows)
        {
            ADMIN = read3["EMPLOYEE_NO"].ToString();
        }
        else
        {
            ADMIN = "0";
        }

        if (ADMIN != "0" || HR != "0" || MANAGER != "0")
        {

            Card_Link.Enabled = true;
            Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&MNG=" + MANAGER + "&ADMIN=" + ADMIN + "&HR=" + HR + "");
            //Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&MNG=" + MANAGER + "&STATIONERYAPP=" + STATIONERYAPP + "");
        }
        else
        {
            Card_Link.Enabled = false;
        }
        cmd.Connection.Close();

    }

    void CheckTEL(string URL)
    {

        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        string sql = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID='31'"; //ICT
        string sql2 = "SELECT MNG FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "'";//MNG
        string sql3 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID='3'"; // GM
        string sql4 = "SELECT SMNG FROM EMP_MNG WHERE EMPLOYEE_NO = '" + EMPLOYEE_NO + "'"; //ESMNG
        string sql5 = "SELECT SMNG FROM EMP_MNG WHERE SMNG = '" + EMPLOYEE_NO + "'";  //SMNG

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);
        OdbcCommand cmd4 = new OdbcCommand(sql4, conn);
        OdbcCommand cmd5 = new OdbcCommand(sql5, conn);

        cmd.Connection.Open();

        OdbcDataReader read = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        OdbcDataReader read3 = cmd3.ExecuteReader();
        OdbcDataReader read4 = cmd4.ExecuteReader();
        OdbcDataReader read5 = cmd5.ExecuteReader();

        read.Read();
        read2.Read();
        read3.Read();
        read4.Read();
        read5.Read();

        if (read.HasRows)
        { ICMANAGER = read["EMPLOYEE_NO"].ToString(); }
        else { ICMANAGER = "0"; }
        if (read2.HasRows)
        { MANAGER = read2["MNG"].ToString(); }
        else { MANAGER = "0"; }
        if (read3.HasRows)
        { GM = read3["EMPLOYEE_NO"].ToString(); }
        else { GM = "0"; }
        if (read4.HasRows)
        { SINMANAGER = read4["SMNG"].ToString(); }
        else { SINMANAGER = "0"; }
        if (read5.HasRows)
        { EMNG = read5["SMNG"].ToString(); }
        else { EMNG = "0"; }


        if (MANAGER != "0" || ICMANAGER != "0" || GM != "0" || SINMANAGER != "0" || EMNG != "0")
        {
            ICT_Tele.Enabled = true;
            Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&MNG=" + MANAGER + "&ICM=" + ICMANAGER + "&GM=" + GM + "&SMNG=" + SINMANAGER + "&EMS=" + EMNG + "");
        }

        else
        {
            ICT_Tele.Enabled = false;
        }
        cmd.Connection.Close();

    }


    void CheckMICT(string URL)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        string sql = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID='31'"; //ICT
        string sql2 = "SELECT MNG FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "'";//MNG


        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);


        cmd.Connection.Open();

        OdbcDataReader read = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();

        read.Read();
        read2.Read();
        if (read.HasRows)
        { ICMANAGER = read["EMPLOYEE_NO"].ToString(); }
        else { ICMANAGER = "0"; }
        if (read2.HasRows)
        { MANAGER = read2["MNG"].ToString(); }
        else { MANAGER = "0"; }

        if (MANAGER != "0" || ICMANAGER != "0")
        {
            ICT_Account.Enabled = true;
            Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&MNG=" + MANAGER + "&ICM=" + ICMANAGER + "");
        }

        else
        {
            ICT_Account.Enabled = false;
        }
        cmd.Connection.Close();

    }

    void CheckAdmICTM(string URL)
    {

        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        string sql = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID='31'"; //ICT
        string sql2 = "SELECT SMNG FROM EMP_MNG WHERE SMNG = '" + EMPLOYEE_NO + "'";  //SMNG
        string sql3 = "SELECT MNG FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "'";//MNG
        string sql4 = "SELECT SMNG FROM EMP_MNG WHERE EMPLOYEE_NO = '" + EMPLOYEE_NO + "'"; //SMNG
        //string sql5 = "SELECT EMPLOYEE_NO FROM EMP_MNG ";


        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);
        OdbcCommand cmd4 = new OdbcCommand(sql4, conn);

        cmd.Connection.Open();

        OdbcDataReader read = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        OdbcDataReader read3 = cmd3.ExecuteReader();
        OdbcDataReader read4 = cmd4.ExecuteReader();

        read.Read();
        read2.Read();
        read3.Read();
        read4.Read();

        if (read.HasRows)
        { ICMANAGER = read["EMPLOYEE_NO"].ToString(); }
        else { ICMANAGER = "0"; }
        if (read2.HasRows)
        { SINMANAGER = read2["SMNG"].ToString(); }
        else
        { SINMANAGER = "0"; }
        if (read3.HasRows)
        { MANAGER = read3["MNG"].ToString(); }
        else
        { MANAGER = "0"; }
        if (read4.HasRows)
        { EMNG = read4["SMNG"].ToString(); }
        else { EMNG = "0"; }

        if (SINMANAGER != "0" || MANAGER != "0" || ICMANAGER != "0" || EMNG != "0")
        {
            ICT_eq.Enabled = true;
            Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&MNG=" + MANAGER + "&ICM=" + ICMANAGER + "&SMNG=" + SINMANAGER + "&EMS=" + EMNG + "");
        }

        else
        {
            ICT_eq.Enabled = false;
        }
        cmd.Connection.Close();

    }

    void CheckAdmin1(string URL)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        //string sql  = "SELECT MNG, SUPER FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "' OR SUPER = '" + EMPLOYEE_NO + "'";

        string sql = "SELECT MNG FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "'";
        string sql4 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '19'"; //19

        OdbcConnection conn = new OdbcConnection(connectionString);

        OdbcCommand cmd = new OdbcCommand(sql, conn);
        OdbcCommand cmd4 = new OdbcCommand(sql4, conn);
        cmd.Connection.Open();

        OdbcDataReader read = cmd.ExecuteReader();
        OdbcDataReader read4 = cmd4.ExecuteReader();

        read.Read();
        read4.Read();


        if (read4.HasRows)
        {
            STATIONERYAPP = read4["EMPLOYEE_NO"].ToString();
        }
        else
        {
            STATIONERYAPP = "0";
        }
        if (read.HasRows)
        {
            MANAGER = read["MNG"].ToString();
        }
        else
        {
            MANAGER = "0";
        }
        if (STATIONERYAPP != "0" || MANAGER != "0")
        {
            Furniture_Link.Enabled = true;
            Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&MNG=" + MANAGER + "&STATIONERYAPP=" + STATIONERYAPP + "");
            //Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&MNG=" + MANAGER + "&STATIONERYAPP=" + STATIONERYAPP + "");
        }
        else
        {
            Furniture_Link.Enabled = false;
        }
        cmd.Connection.Close();
    }

    void CheckAdmin(string URL)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO   = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        //string sql  = "SELECT MNG, SUPER FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "' OR SUPER = '" + EMPLOYEE_NO + "'";

        string sql  = "SELECT MNG FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "'";
        string sql2 = "SELECT MNG FROM EMP_MNG WHERE MNG = SUPER AND MNG = '" + EMPLOYEE_NO + "'";
        string sql3 = "SELECT SUPER FROM EMP_MNG WHERE SUPER != MNG AND SUPER = '" + EMPLOYEE_NO + "'";
        //string sql3 = "SELECT SUPER FROM EMP_MNG WHERE SUPER = '" + EMPLOYEE_NO + "'";
        

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd  = new OdbcCommand(sql , conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);
 
        cmd.Connection.Open();

        OdbcDataReader read  = cmd .ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        OdbcDataReader read3 = cmd3.ExecuteReader();
        

        read.Read();
        read2.Read();
        read3.Read();
      
        if (read.HasRows)
        { MANAGER = read["MNG"].ToString();}
        else{ MANAGER = "0"; }
        if (read2.HasRows)
        { MANAGERSUPERVISOR = read2["MNG"].ToString(); }
        else
        {  MANAGERSUPERVISOR = "0"; }
        if (read3.HasRows)
        { SUPERVISOR = read3["SUPER"].ToString(); }
        else
        { SUPERVISOR = "0"; }
        if (MANAGERSUPERVISOR != "0" || SUPERVISOR != "0" || MANAGER != "0")
        {
            Link_Leave.Enabled = true;
            Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&MNG=" + MANAGER + "&SUPER=" + SUPERVISOR + "&MANAGERSUPERVISOR=" + MANAGERSUPERVISOR + "");
        }
        else
        {Link_Leave.Enabled = false;}
        cmd.Connection.Close();
    }
    void CheckAdmin2(string URL)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        //string sql  = "SELECT MNG, SUPER FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "' OR SUPER = '" + EMPLOYEE_NO + "'";

        string sql = "SELECT MNG FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "'";
        string sql2 = "SELECT MNG FROM EMP_MNG WHERE MNG = SUPER AND MNG = '" + EMPLOYEE_NO + "'";
        string sql3 = "SELECT SUPER FROM EMP_MNG WHERE SUPER = '" + EMPLOYEE_NO + "'";
        string sql4 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '19'"; //19

        OdbcConnection conn = new OdbcConnection(connectionString);

        OdbcCommand cmd = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);
        OdbcCommand cmd4 = new OdbcCommand(sql4, conn);
        cmd.Connection.Open();

        OdbcDataReader read = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        OdbcDataReader read3 = cmd3.ExecuteReader();
        OdbcDataReader read4 = cmd4.ExecuteReader();

        read.Read();
        read2.Read();
        read3.Read();
        read4.Read();

        if (read2.HasRows)
        {
            MANAGERSUPERVISOR = read2["MNG"].ToString();
        }
        else
        {
            MANAGERSUPERVISOR = "0";
        }
        if (read3.HasRows)
        {
            SUPERVISOR = read3["SUPER"].ToString();
        }
        else
        {
            SUPERVISOR = "0";
        }
        if (read4.HasRows)
        {
            STATIONERYAPP = read4["EMPLOYEE_NO"].ToString();
        }
        else
        {
            STATIONERYAPP = "0";
        }
        if (read.HasRows)
        {
            MANAGER = read["MNG"].ToString();
        }
        else
        {
            MANAGER = "0";
        }
        if (MANAGERSUPERVISOR != "0" || SUPERVISOR != "0" || STATIONERYAPP != "0" || MANAGER != "0")
        {
            //Link_Leave.Enabled = true;
            Link_Stationary.Enabled = true;
            Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&MNG=" + MANAGER + "&SUPER=" + SUPERVISOR + "&MANAGERSUPERVISOR=" + MANAGERSUPERVISOR + "&STATIONERYAPP=" + STATIONERYAPP + "");
            //Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&MNG=" + MANAGER + "&STATIONERYAPP=" + STATIONERYAPP + "");
        }
        else
        {
            Link_Stationary.Enabled = false;
        }
        cmd.Connection.Close();
    }
    void CheckHRAdmin(string URL)
    {
        //SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '11'
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        //string sql = "SELECT MNG, SUPER FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "' OR SUPER = '" + EMPLOYEE_NO + "'";
        //string sql = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '11'";//HR Leave Approval = 11 WAS 11
        string sql = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '20'";//HR Leave Approval = 11 WAS 11
        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            //Link_Leave.Enabled = true;
            Link_Salary.Enabled = true;
            //LinkTravel.Enabled = true;
            //Link_Recruitment.Enabled = true;

            //Link_Travel.Enabled = true;
            //Link_Function.Enabled = true;
            //Link_Stationary.Enabled = true;

            HRMANAGER = read["EMPLOYEE_NO"].ToString();
            Response.Redirect("~/UsersArea/"+URL+"?EMPLOYEE_NO="+EMPLOYEE_NO+"&DEP_NO="+DEPARTMENT_NO+"&MNG="+HRMANAGER+"");
        }
        else
        {
            //Link_Leave.Enabled = false;
            Link_Salary.Enabled = false;
            //LinkTravel.Enabled = false;
            //Link_Recruitment.Enabled = false;

            //Link_Travel.Enabled = false;
            //Link_Function.Enabled = false;
            //Link_Stationary.Enabled = false;
        }
        cmd.Connection.Close();
    }
    void CheckAdminHRAdmin(string URL)
    {
        //SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '11'
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        //string sql  = "SELECT MNG FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "' OR SUPER = '" + EMPLOYEE_NO + "'";
        string sql  = "SELECT MNG FROM EMP_MNG WHERE MNG = '"+ EMPLOYEE_NO +"'";
        string sql2 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '15'"; // HR MANAGER
        string sql3 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '14'"; //FINANCE
        string sql4 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '4'";  //GM

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd  = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);
        OdbcCommand cmd4 = new OdbcCommand(sql4, conn);

        cmd.Connection.Open();
        OdbcDataReader read  = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        OdbcDataReader read3 = cmd3.ExecuteReader();
        OdbcDataReader read4 = cmd4.ExecuteReader();

        read.Read();
        read2.Read();
        read3.Read();
        read4.Read();

        if (read.HasRows)
        { MANAGER = read["MNG"].ToString(); }
        else
        { MANAGER = "0";}
        if (read2.HasRows)
        { HRMANAGER = read2["EMPLOYEE_NO"].ToString();}
        else
        { HRMANAGER = "0";}
        if (read3.HasRows)
        {FINANCEMG = read3["EMPLOYEE_NO"].ToString();}
        else
        { FINANCEMG = "";}
        if (read4.HasRows)
        { GMANAGER = read4["EMPLOYEE_NO"].ToString(); }
        else
        { GMANAGER = "0";}

        if (MANAGER != "0" || HRMANAGER != "0" || FINANCEMG != "0" || GMANAGER !="0")
        {
            Link_Travel.Enabled = true;
            Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&MNG=" + MANAGER + "&HRMNG=" + HRMANAGER + "&FINMNG=" + FINANCEMG + "&GM=" + GMANAGER + "");
        }
        else
        {LinkTravel.Enabled = false;}
          cmd.Connection.Close();
    }
    void CheckAdminHRGMAdmin(string URL)
    {
        //SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '11'
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO   = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        //string sql  = "SELECT MNG FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "'";
        string sql2 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '17'";    // HR REQRUITMENT
        string sql3 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '4'";     //  GENERAL MANAGER

        string sql4 = "SELECT SMNG FROM EMP_MNG WHERE SMNG = '" + EMPLOYEE_NO + "'";            // SENIOR MANAGER
        string sql5 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '21'";    //  FIN & ADMIN

        OdbcConnection conn = new OdbcConnection(connectionString);

        //OdbcCommand cmd  = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);

        OdbcCommand cmd4 = new OdbcCommand(sql4, conn);
        OdbcCommand cmd5 = new OdbcCommand(sql5, conn);
   
        cmd2.Connection.Open();

        //OdbcDataReader read  = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        OdbcDataReader read3 = cmd3.ExecuteReader();

        OdbcDataReader read4 = cmd4.ExecuteReader();
        OdbcDataReader read5 = cmd5.ExecuteReader();

        //read.Read();
        read2.Read();
        read3.Read();
        read4.Read();
        read5.Read();

        //if (read.HasRows)
        //{MANAGER = read["EMPLOYEE_NO"].ToString();}
        //else {MANAGER = "0";}
        if (read2.HasRows)
        {HRMANAGER = read2["EMPLOYEE_NO"].ToString();}
        else {HRMANAGER = "0";}
        if (read3.HasRows)
        {GMANAGER = read3["EMPLOYEE_NO"].ToString();}
        else {GMANAGER = "0";}

        if (read4.HasRows)
        { SINMANAGER = read4["SMNG"].ToString(); }
        else { SINMANAGER = "0"; }
        if (read5.HasRows)
        { FINANCEADMIN = read5["EMPLOYEE_NO"].ToString(); }
        else { FINANCEADMIN = "0"; }

        if (HRMANAGER != "0" || GMANAGER != "0" || SINMANAGER != "0" || FINANCEADMIN != "0")
        {
            Link_Recruitment.Enabled = true;
            Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&MNG=0&HRMNG=" + HRMANAGER + "&GM=" + GMANAGER + ""+
            "&SMNG="+ SINMANAGER+"&FINADMIN="+ FINANCEADMIN +"");
        }
        else
        {Link_Recruitment.Enabled = false;}
        
        
        
        cmd2.Connection.Close();
    }
    void CheckAdminAdminApproval(string URL)
    {
        //SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '11'
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string sql  = "SELECT MNG FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "' OR SUPER = '" + EMPLOYEE_NO + "'";
        string sql2 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '18'"; // HR REQRUITMENT
        string sql3 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '4'"; //GENERAL MANAGER

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
        if (read.HasRows && read2.HasRows && read3.HasRows)
        {
             Link_Function.Enabled = true;
            
            MANAGER   = read["MNG"].ToString();
            HRMANAGER = read2["EMPLOYEE_NO"].ToString();
            GMANAGER  = read3["EMPLOYEE_NO"].ToString();

            //Response.Redirect("~/UsersArea/"+URL+"?EMPLOYEE_NO="+EMPLOYEE_NO+"&DEP_NO="+DEPARTMENT_NO+"&MNG="+MANAGER+"&EMPLOYEE_NO="+HRMANAGER+"");
            Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&MNG=" + MANAGER + "&HRMNG=" + HRMANAGER + "&GM=" + GMANAGER + "");
        }
        else
        {
            Link_Function.Enabled = false;
        }
        cmd.Connection.Close();
    }
    protected void LoginStatus1_LoggingOut1(object sender, LoginCancelEventArgs e)
    {
        ////////System.Web.Security.FormsAuthentication.SignOut();
        ////////Response.Redirect(Request.UrlReferrer.ToString());
        ////////Response.Cookies.Clear();

        //////Session.Abandon();
        //////Session.RemoveAll();
        //////Session.Clear();

        //////Session.Contents.RemoveAll();
        //////System.Web.Security.FormsAuthentication.SignOut();
        ////////Response.Redirect("~/Default.aspx");

        //////System.Web.Security.FormsAuthentication.SignOut();
        //////System.Web.Security.FormsAuthentication.RedirectToLoginPage();
        //////Response.Clear();

        //System.Web.Security.FormsAuthentication.SignOut();
        //Response.Cookies.Clear();
        //Response.Equals(false);
        //Response.Redirect("~/Login.aspx");
        //Response.End();
        //Response.Redirect(Request.UrlReferrer.ToString());

        //if (Session["loginStatus"] != null)
        {
           
            Session["loginStatus"] = null;
            Session.Remove("loginStatus");
            Session.Clear();
            Session.Abandon();


            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect(Request.UrlReferrer.ToString()); 
            Response.Cookies.Clear();
            Session.RemoveAll();
            //Response.Redirect("~/Login.aspx");
            Response.CacheControl = "no-cache";
        }
        
    }
    //void CheckAdminHRAdmin2(string URL)
    //{
    //    string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

    //    EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
    //    DEPARTMENT_NO = Request.QueryString["DEP_NO"];

    //    string sql = "SELECT MNG FROM EMP_MNG WHERE MNG = '" + EMPLOYEE_NO + "' OR SUPER = '" + EMPLOYEE_NO + "'";
    //    string sql2 = "SELECT EMPLOYEE_NO FROM REQUEST_ACTORS WHERE REQUEST_TYPE_ID = '16'";

    //    OdbcConnection conn = new OdbcConnection(connectionString);
    //    OdbcCommand cmd = new OdbcCommand(sql, conn);
    //    OdbcCommand cmd2 = new OdbcCommand(sql2, conn);

    //    cmd.Connection.Open();
    //    OdbcDataReader read = cmd.ExecuteReader();
    //    OdbcDataReader read2 = cmd2.ExecuteReader();

    //    read.Read();
    //    read2.Read();
    //    if (read.HasRows && read2.HasRows)
    //    {
    //        Link_Leave.Enabled = true;
    //        Link_Salary.Enabled = true;
    //        LinkTravel.Enabled = true;
    //        Link_Recruitment.Enabled = true;

    //        Link_Travel.Enabled = true;
    //        Link_Function.Enabled = true;
    //        Link_Stationary.Enabled = true;

    //        MANAGER = read["MNG"].ToString();
    //        HRMANAGER = read2["EMPLOYEE_NO"].ToString();
    //        //Response.Redirect("~/UsersArea/"+URL+"?EMPLOYEE_NO="+EMPLOYEE_NO+"&DEP_NO="+DEPARTMENT_NO+"&MNG="+MANAGER+"&EMPLOYEE_NO="+HRMANAGER+"");
    //        Response.Redirect("~/UsersArea/" + URL + "?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&MNG=" + MANAGER + "&HRMNG=" + HRMANAGER + "");
    //    }
    //    else
    //    {
    //        Link_Leave.Enabled = false;
    //        Link_Salary.Enabled = false;
    //        LinkTravel.Enabled = false;
    //        Link_Recruitment.Enabled = false;

    //        Link_Travel.Enabled = false;
    //        Link_Function.Enabled = false;
    //        Link_Stationary.Enabled = false;
    //    }
    //    cmd.Connection.Close();
    //}

   
}
