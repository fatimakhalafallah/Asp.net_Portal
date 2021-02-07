using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Configuration;
using System.Drawing.Design;
using System.Data.SqlClient;
using System.Data;


public partial class UsersArea_TravelHist : System.Web.UI.Page
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
        string sql = "SELECT TRAVEL_MSTR.TRAVELER_NAME ,  TRAVEL_MSTR.PURPOSE_DESC ,TRAVEL_PURPOSE.PURPOSE, TRAVEL_MSTR.TRF_NO ,TRAVEL_DTL.CITY_FROM, TRAVEL_DTL.FROM_DATE ,TRAVEL_DTL.CITY_TO ,TRAVEL_DTL.TO_DATE,DECODE(TRAVEL_MSTR.FORM_STATUS,2,'MANAGER APPROVE',3,'MANAGER DISAPPROVE',4,'DGM APPROVE',5,'DGM DISAPPROVE',6,'HR APPROVE',7,'HR DISAPPROVE',8,'FINANCIAL MNG APPROVE',9,'FINANCIAL MNG DISAPPROVE',10,'COMPLETE') AS FORM_STATUS  FROM TRAVEL_DTL , TRAVEL_MSTR INNER JOIN TRAVEL_PURPOSE ON TRAVEL_MSTR.PURPOSE= TRAVEL_PURPOSE.SERIAL  WHERE TRAVEL_DTL.TRF_NO=TRAVEL_MSTR.TRF_NO AND TRAVEL_MSTR.DEP_NO='22' ORDER BY TRF_NO DESC";
             
        OdbcConnection con = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, con);
        con.Open();
        OdbcDataAdapter ad = new OdbcDataAdapter(sql, con);
        DataSet ds = new DataSet();
        ad.Fill(ds, "TRAVEL_DTL");
        DataView dv = ds.Tables["TRAVEL_DTL"].DefaultView;
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

        for (int i = 0; i < grid1.Rows.Count; i++)
        {
            if (grid1.SelectedIndex == i)
            {
                string Req_no = grid1.Rows[i].Cells[0].Text;

                int NO = Convert.ToInt32(Req_no);

                Response.Redirect(@"http://pn-bu-srv:7778/reports/rwservlet?server=rep_PN-BU-SRV_FRHome1&userid=PETRO/PETROadmin@APP&report=c:\petroneeds\services\reports\travel_req&execution_mode=batch&comm_mode=synchronous&destype=cache&desformat=PDF&a=" + NO + "");
                /*TextBox1.Text = FORM_NO.ToString();
                TextBox2.Text = EMP_NO.ToString();
                detail();
                GridView3.Visible = true;
                GridView2.Visible = true;
                //UserDetails();
                Panel1.Visible = true;
                //returnuser(); 
                UserList();
                detail(); */

            }
        }


    }

   /* protected void PrintTravelRequest_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if   (e.CommandName == "Print")    
        {

            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                if (grid1.SelectedIndex == i)
                {
                    string FORM_NO = grid1.Rows[i].Cells[0].Text;

                    RE_Link(string FORM_NO);
                }
            }

        }
    }*/

   /* protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
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
                detail();
                GridView3.Visible = true;
                GridView2.Visible = true;
                //UserDetails();
                Panel1.Visible = true;
                //returnuser(); 
                UserList();
                detail();

            }
        }
    }*/

     
}