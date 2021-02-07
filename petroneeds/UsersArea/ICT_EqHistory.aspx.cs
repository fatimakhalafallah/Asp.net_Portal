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

public partial class UsersArea_ICT_EqHistory : System.Web.UI.Page

{
    string  EMPLOYEE_NO , DEPARTMENT_NO;
    public OdbcCommand comm, comm_mas = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter odbcadabter = null;
    public OdbcDataAdapter dadapter;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;

    string EM="9493"; 
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
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        string sql = "SELECT ICT_MSTR.FORM_DATE ,ICT_MSTR.EQ_NAME,ICT_MSTR.DESCRIPTION,DECODE(ICT_MSTR.FORM_STATUS,5,'ICT MANAGER APPROVE',6,'ICT MANAGER DISAPPROVE',2,'SUPERVISOR APPROVE',3,'SUPERVISOR DISAPPROVE',1,'PENDING') AS FORM_STATUS  FROM ICT_MSTR WHERE ICT_MSTR.EMPLOYEE_NO='" + Int32.Parse(EMPLOYEE_NO) + "'"
                         ;  
        OdbcConnection con = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, con);
        con.Open();
        OdbcDataAdapter ad = new OdbcDataAdapter(sql, con);
        DataSet ds = new DataSet();
        ad.Fill(ds,"ICT_MSTR");
        DataView dv = ds.Tables["ICT_MSTR"].DefaultView;
        con.Close();
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











      