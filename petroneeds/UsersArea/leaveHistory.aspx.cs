using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Odbc;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Design;

public partial class UsersArea_leaveHistory : System.Web.UI.Page
{
    
    string  EMPLOYEE_NO , DEPARTMENT_NO ;
    public OdbcCommand comm, comm_mas = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter odbcadabter = null;
    public OdbcDataAdapter dadapter;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;

    //string EM="9493"; 
    protected void Page_Load(object sender, EventArgs e)
    {
  
         EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
         DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        if (EMPLOYEE_NO == "" || EMPLOYEE_NO == null)
        {
            Response.Redirect("~/Login.aspx");
            
        }
        else
        
        if (!IsPostBack)
        {
            getMenu();
            DataView dvm = Getdata();
            grid1.DataSource = dvm;
            grid1.DataBind();
                 
         }
    }

    private DataView Getdata()
    {
        string ft = Request.QueryString["Name"];
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
     
        string sql = "SELECT LKP_LEAVE_TYPES.LEAVE_TYPE_NAME,FORM_LEAVES_APPLICATION.START_DATE,FORM_LEAVES_APPLICATION.END_DATE, DECODE(FORM_LEAVES_APPLICATION.FORM_STATUS , 2 , 'HR ENDORSE' , 3 , 'HR UNENDORSE' ,4,'SUPERVISOR APPROVE',5,'SUPERVISOR DISAPPROVE',6,'MANAGER APPROVE',7,'MANAGER DISAPPROVE') AS FORM_STATUS FROM FORM_LEAVES_APPLICATION ,LKP_LEAVE_TYPES WHERE FORM_LEAVES_APPLICATION.LS_LEAVE_TYPE=LKP_LEAVE_TYPES.LEAVE_TYPE_NO  AND FORM_LEAVES_APPLICATION.EMPLOYEE_NO='" + Int32.Parse(EMPLOYEE_NO) + "'"
                         ;
        OdbcConnection con = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, con);
        con.Open();
        OdbcDataAdapter ad = new OdbcDataAdapter(sql, con);
        DataSet ds = new DataSet();
        ad.Fill(ds, "FORM_LEAVES_APPLICATION");
        DataView dv = ds.Tables["FORM_LEAVES_APPLICATION"].DefaultView;
        return dv;

    }

    protected void grid1_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
    {
        grid1.PageIndex = e.NewPageIndex;
        DataView dvm = Getdata();
        grid1.DataSource = dvm;
        grid1.DataBind();
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
    protected void grid1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }








}