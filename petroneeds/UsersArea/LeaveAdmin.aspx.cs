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

public partial class UsersArea_LeaveAdmin : System.Web.UI.Page
{
    public OdbcCommand comm = null;
    public OdbcConnection con = null;
    public OdbcDataAdapter dadapter;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand command = null;
    public SqlConnection conn = null;

    public static string EMPLOYEE_NO, DEPARTMENT_NO, MANAGER, SUPERVISOR, MANAGERSUPERVISOR;
    public static string EmpName, EmpEmail, Depart, Status, AUTHORNAME, EmpName2, EmpEmail2, EmpName3, EmpEmail3;

    DataSet dset;
    string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
    //string sql;

    private string sortDirection;
    private int No;

    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO   = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        MANAGER       = Request.QueryString["MNG"];
        SUPERVISOR    = Request.QueryString["SUPER"];
        MANAGERSUPERVISOR = Request.QueryString["MANAGERSUPERVISOR"];

        if (EMPLOYEE_NO == "" || EMPLOYEE_NO == null && DEPARTMENT_NO == "" || DEPARTMENT_NO == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                getMenu();
                //RadioButtonList1.Items.Clear();
                //RadioButtonList2.Items.Clear();
                GridViewBind();
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
        }
    }
    /* public void GridViewBind()
     {
         EMPLOYEE_NO         = Request.QueryString["EMPLOYEE_NO"];
         DEPARTMENT_NO       = Request.QueryString["DEP_NO"];
         MANAGER             = Request.QueryString["MNG"];
         SUPERVISOR          = Request.QueryString["SUPER"];

         MANAGERSUPERVISOR   = Request.QueryString["MANAGERSUPERVISOR"];

         if (SUPERVISOR == EMPLOYEE_NO)
         {
             No = 2;
             //Response.Write(No);
         }
         else
         if (MANAGER == EMPLOYEE_NO)
         {
             No = 4;
             //Response.Write(No);
         }
         else
         if (MANAGERSUPERVISOR == EMPLOYEE_NO)
         {
             No = 5;
             //Response.Write(No);
         }
         switch (No)
         {
             case 2:
                 dadapter = new OdbcDataAdapter("SELECT LEAVE_FORM__NO, FORM_DATE, EMPLOYEE_NO FROM" +
                     " FORM_LEAVES_APPLICATION WHERE FORM_STATUS = '2' AND EMPLOYEE_NO IN " +
                     " (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE SUPER ='" + SUPERVISOR + "')", connectionString); //SUPERVISOR 
                 dset = new DataSet();
                 dadapter.Fill(dset);
                 GridView1.DataSource = dset.Tables[0];
                 GridView1.DataBind();

                 RadioButtonList1.Items.Add(new ListItem("Approve", "4"));
                 RadioButtonList1.Items.Add(new ListItem("Reject", "5"));
                 break;

             case 4:
                 dadapter = new OdbcDataAdapter("SELECT LEAVE_FORM__NO, FORM_DATE, EMPLOYEE_NO FROM" +
                     " FORM_LEAVES_APPLICATION WHERE FORM_STATUS = '4' AND EMPLOYEE_NO IN " +
                     " (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG ='" + MANAGER + "')", connectionString); //6199
                     dset = new DataSet();
                     dadapter.Fill(dset);
                     GridView1.DataSource = dset.Tables[0];
                     GridView1.DataBind();

                 RadioButtonList1.Items.Add(new ListItem("Approve", "6"));
                 RadioButtonList1.Items.Add(new ListItem("Reject", "7"));
                 break;

             case 5:
                 dadapter = new OdbcDataAdapter("SELECT LEAVE_FORM__NO, FORM_DATE, EMPLOYEE_NO FROM" +
                     " FORM_LEAVES_APPLICATION WHERE FORM_STATUS = '2' AND EMPLOYEE_NO IN " +
                     " (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE SUPER = MNG AND MNG ='" + MANAGERSUPERVISOR + "')", connectionString); //6199
                 dset = new DataSet();
                 dadapter.Fill(dset);
                 GridView1.DataSource = dset.Tables[0];
                 GridView1.DataBind();

                 RadioButtonList1.Items.Add(new ListItem("Approve", "6"));
                 RadioButtonList1.Items.Add(new ListItem("Reject", "7"));
                 break;

             default:
                 //Label_Message.Text = "There are no Requests...";
                Label_Message.Text = "You aren't Authorized to see Contents of this page ...";
             break;
         }
     }*/
    public void GridViewBind()
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        MANAGER = Request.QueryString["MNG"];
        SUPERVISOR = Request.QueryString["SUPER"];

        MANAGERSUPERVISOR = Request.QueryString["MANAGERSUPERVISOR"];

        if (SUPERVISOR == EMPLOYEE_NO)
        {
            dadapter = new OdbcDataAdapter("SELECT LEAVE_FORM__NO, FORM_DATE, EMPLOYEE_NO FROM" +
                   " FORM_LEAVES_APPLICATION WHERE FORM_STATUS = '2' AND EMPLOYEE_NO IN " +
                   " (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE SUPER ='" + SUPERVISOR + "')", connectionString);
            dset = new DataSet();
            dadapter.Fill(dset);
            GridView1.DataSource = dset.Tables[0];
            GridView1.DataBind();

            RadioButtonList1.Items.Clear();
            RadioButtonList1.Items.Add(new ListItem("Approve", "4"));
            RadioButtonList1.Items.Add(new ListItem("Reject", "5"));
            //No = 2;
            //Response.Write(No);
        }
        else
            if (MANAGER == EMPLOYEE_NO)
            {
                dadapter = new OdbcDataAdapter("SELECT LEAVE_FORM__NO, FORM_DATE, EMPLOYEE_NO FROM" +
                    " FORM_LEAVES_APPLICATION WHERE FORM_STATUS = '4' AND EMPLOYEE_NO IN " +
                    " (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE MNG ='" + MANAGER + "')", connectionString);
                dset = new DataSet();
                dadapter.Fill(dset);
                GridView1.DataSource = dset.Tables[0];
                GridView1.DataBind();

                RadioButtonList1.Items.Clear();
                RadioButtonList1.Items.Add(new ListItem("Approve", "6"));
                RadioButtonList1.Items.Add(new ListItem("Reject", "7"));
                //No = 4;
                //Response.Write(No);
            }
            
                if (MANAGERSUPERVISOR == EMPLOYEE_NO)
                {
                    dadapter = new OdbcDataAdapter("SELECT LEAVE_FORM__NO, FORM_DATE, EMPLOYEE_NO FROM" +
                    " FORM_LEAVES_APPLICATION WHERE FORM_STATUS in ('2','4') AND EMPLOYEE_NO IN " +
                    " (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE SUPER = MNG AND MNG ='" + MANAGERSUPERVISOR + "')", connectionString);
                    dset = new DataSet();
                    dadapter.Fill(dset);
                    GridView1.DataSource = dset.Tables[0];
                    GridView1.DataBind();

                    RadioButtonList1.Items.Clear();
                    RadioButtonList1.Items.Add(new ListItem("Approve", "6"));
                    RadioButtonList1.Items.Add(new ListItem("Reject", "7"));
                    //No = 5;
                    //Response.Write(No);
                }
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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridViewBind();
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GridViewBind();
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        //if (ViewState["SortDirection"] == null || ViewState["SortExpression"].ToString() != e.SortExpression)
        //{
        //    ViewState["SortDirection"] = "ASC";
        //    GridView1.PageIndex = GridView1.PageIndex;
        //}
        //else if (ViewState["SortDirection"].ToString() == "ASC")
        //{
        //    ViewState["SortDirection"] = "DESC";
        //}
        //else if (ViewState["SortDirection"].ToString() == "DESC")
        //{
        //    ViewState["SortDirection"] = "ASC";
        //}

        //ViewState["SortExpression"] = e.SortExpression;
        //BindGridView();
    }
    //private void BindGridView()
    //{
    //    EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
    //    DEPARTMENT_NO = Request.QueryString["DEP_NO"];

    //    sql = "SELECT LEAVE_FORM__NO, FORM_DATE, EMPLOYEE_NO FROM" +
    //       " FORM_LEAVES_APPLICATION WHERE FORM_STATUS = '0' AND EMPLOYEE_NO IN " +
    //       " (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE SUPER ='" + 6199 + "')";


    //    //sql = "SELECT LEAVE_FORM__NO, FORM_DATE, EMPLOYEE_NO FROM" +
    //    //   " FORM_LEAVES_APPLICATION WHERE FORM_STATUS = '2' AND EMPLOYEE_NO IN " +
    //    //   " (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE SUPER ='" + EMPLOYEE_NO + "')";

        
    //    dadapter = new OdbcDataAdapter(sql, connectionString);
    //    dset = new DataSet();
    //    dadapter.Fill(dset);

    //    GridViewBind();

    //    using (OdbcDataAdapter sda = new OdbcDataAdapter(sql, connectionString))
    //    {
    //        sda.Fill(dset);
    //        if (dset.Tables.Count > 0)
    //        {
    //            DataView dv = dset.Tables[0].DefaultView;
    //            if (ViewState["SortDirection"] != null)
    //            {
    //                sortDirection = ViewState["SortDirection"].ToString();
    //            }
    //            if (ViewState["SortExpression"] != null)
    //            {
    //                sortExpression = ViewState["SortExpression"].ToString();
    //                dv.Sort = string.Concat(sortExpression, " ", sortDirection);
    //            }

    //            GridView1.DataSource = dv;
    //            GridView1.DataBind();
    //        }
    //    }
    //}
   protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new
            GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Admin Area: Leave Requests List";
            HeaderCell.ColumnSpan = 8;
            HeaderGridRow.Cells.Add(HeaderCell);
            GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }
   protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
   {
       if (e.Row.RowType == DataControlRowType.Header)
       {
           GridView HeaderGrid = (GridView)sender;
           GridViewRow HeaderGridRow = new
           GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
           TableCell HeaderCell = new TableCell();
           HeaderCell.HorizontalAlign = HorizontalAlign.Center;
           HeaderCell.Text = "Admin Area: Leave Requests List";
           HeaderCell.ColumnSpan = 8;
           HeaderGridRow.Cells.Add(HeaderCell);
           GridView2.Controls[0].Controls.AddAt(0, HeaderGridRow);

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

                UserLeaveDetails();
                //RadioButtonList1.Visible = true;
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
        }
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label_Message.Text = "";
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            if (GridView2.SelectedIndex == i)
            {
                string FORM_NO = GridView2.Rows[i].Cells[0].Text;
                string EMP_NO = GridView2.Rows[i].Cells[1].Text;
                TextBox3.Text = FORM_NO.ToString();
                TextBox2.Text = EMP_NO.ToString();

                UserLeaveDetails2();
                //RadioButtonList1.Visible = true;
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
        }
    }
    void UserLeaveDetails()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        //Text_ID.Text = EMPLOYEE_NO;

        //string sql = "SELECT FORM_DATE, EMPLOYEE_NO, LS_LEAVE_TYPE, START_DATE, END_DATE" +
        //   " FROM FORM_LEAVES_APPLICATION WHERE LEAVE_FORM__NO = '" + TextBox1.Text + "'"; //6199

        string sql = "SELECT FORM_LEAVES_APPLICATION.FORM_DATE, FORM_LEAVES_APPLICATION.EMPLOYEE_NO, "+
            "FORM_LEAVES_APPLICATION.START_DATE, FORM_LEAVES_APPLICATION.END_DATE, LKP_LEAVE_TYPES.LEAVE_TYPE_NAME, (employees.employee_NAME)FULL_USER_NAME, FORM_LEAVES_APPLICATION.NUMBER_OF_DAYS " +
          " FROM FORM_LEAVES_APPLICATION, LKP_LEAVE_TYPES, employees WHERE FORM_LEAVES_APPLICATION.LEAVE_FORM__NO = '" + TextBox1.Text + "' AND" +
          " LKP_LEAVE_TYPES.LEAVE_TYPE_NO = FORM_LEAVES_APPLICATION.LS_LEAVE_TYPE AND employees.EMPLOYEE_NO = '" + TextBox2.Text + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_Request.Text = read["FORM_DATE"].ToString();
            Text_NumOfDays.Text = read["NUMBER_OF_DAYS"].ToString();
            Text_Num.Text = read["EMPLOYEE_NO"].ToString();
            Text_Leave_Name.Text = read["LEAVE_TYPE_NAME"].ToString();
            Text_StDate.Text = read["START_DATE"].ToString();
            Text_EnDate.Text = read["END_DATE"].ToString();
            Text_Name.Text = read["FULL_USER_NAME"].ToString();
        }
        //else
        //{
        //    Response.Redirect("~/Login.aspx");
        //}
        cmd.Connection.Close();
    }
    void UserLeaveDetails2()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        //Text_ID.Text = EMPLOYEE_NO;

        //string sql = "SELECT FORM_DATE, EMPLOYEE_NO, LS_LEAVE_TYPE, START_DATE, END_DATE" +
        //   " FROM FORM_LEAVES_APPLICATION WHERE LEAVE_FORM__NO = '" + TextBox1.Text + "'"; //6199

        string sql = "SELECT FORM_LEAVES_APPLICATION.FORM_DATE, FORM_LEAVES_APPLICATION.EMPLOYEE_NO, " +
            "FORM_LEAVES_APPLICATION.START_DATE, FORM_LEAVES_APPLICATION.END_DATE, LKP_LEAVE_TYPES.LEAVE_TYPE_NAME, (employees.employee_NAME)FULL_USER_NAME, FORM_LEAVES_APPLICATION.NUMBER_OF_DAYS " +
          " FROM FORM_LEAVES_APPLICATION, LKP_LEAVE_TYPES, employees WHERE FORM_LEAVES_APPLICATION.LEAVE_FORM__NO = '" + TextBox3.Text + "' AND" +
          " LKP_LEAVE_TYPES.LEAVE_TYPE_NO = FORM_LEAVES_APPLICATION.LS_LEAVE_TYPE AND employees.EMPLOYEE_NO = '" + TextBox2.Text + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_Request0.Text = read["FORM_DATE"].ToString();
            Text_NumOfDays0.Text = read["NUMBER_OF_DAYS"].ToString();
            Text_Num0.Text = read["EMPLOYEE_NO"].ToString();
            Text_Leave_Name0.Text = read["LEAVE_TYPE_NAME"].ToString();
            Text_StDate0.Text = read["START_DATE"].ToString();
            Text_EnDate0.Text = read["END_DATE"].ToString();
            Text_Name0.Text = read["FULL_USER_NAME"].ToString();
        }
        //else
        //{
        //    Response.Redirect("~/Login.aspx");
        //}
        cmd.Connection.Close();
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Status = RadioButtonList1.SelectedItem.ToString();
    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Status = RadioButtonList2.SelectedItem.ToString();
    }
    protected void Butt_Submit_Click(object sender, EventArgs e)
    {
        UpdateFormStatus();
        //Status = RadioButtonList1.SelectedItem.Text.ToString();
        SendEMail(Status);
        Panel1.Visible = false;
        Panel2.Visible = false;
        Reset();
        GridViewBind();
        //Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
    private void UpdateFormStatus()
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();
        string sql, date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        //string test = RadioButtonList1.SelectedItem.Text.ToString();

            if (TextBox1.Text != "" || TextBox3.Text != "")
                {
                  
                if (SUPERVISOR == EMPLOYEE_NO && RadioButtonList1.SelectedValue != "")
                {
                        sql = "UPDATE FORM_LEAVES_APPLICATION SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "', FORM_STATUS_REASON = '" + Text_Comments.Text + "' " +
                            ", ENDORSE_BY = '" + EMPLOYEE_NO + "', ENDORSE_DATE = '" + date + "'WHERE LEAVE_FORM__NO = '" + TextBox1.Text + "'";
                        con = new OdbcConnection(connection);
                        con.ConnectionString = connection;
                        con.Open();

                        comm = new OdbcCommand(sql, con);
                        comm.ExecuteNonQuery();
                        con.Close();
                        Label_Message.Text = "Successfully...";
                        Status = RadioButtonList1.SelectedItem.Text.ToString();
                  }
            else
                    if (MANAGER == EMPLOYEE_NO && RadioButtonList1.SelectedValue != null)
                   {
                       sql = "UPDATE FORM_LEAVES_APPLICATION SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "', FORM_STATUS_REASON = '" + Text_Comments.Text + "' " +
                           ", ENDORSE_BY = '" + EMPLOYEE_NO + "', ENDORSE_DATE = '" + date + "', APPROVE_DATE = '" + date + "', APPROVED_BY = '" + EMPLOYEE_NO + "' WHERE LEAVE_FORM__NO = '" + TextBox1.Text + "'";
                       con = new OdbcConnection(connection);
                       con.ConnectionString = connection;
                       con.Open();

                       comm = new OdbcCommand(sql, con);
                       comm.ExecuteNonQuery();
                       con.Close();
                       Label_Message.Text = "Successfully...";
                       Status = RadioButtonList1.SelectedItem.Text.ToString();
                   }
            //else
                    if (MANAGERSUPERVISOR == EMPLOYEE_NO && RadioButtonList2.SelectedValue != "")
                    {
                        sql = "UPDATE FORM_LEAVES_APPLICATION SET FORM_STATUS = '" + RadioButtonList1.SelectedValue + "', FORM_STATUS_REASON = '" + Text_Comments.Text + "' " +
                        ", ENDORSE_BY = '" + EMPLOYEE_NO + "', ENDORSE_DATE = '" + date + "', APPROVE_DATE = '" + date + "', APPROVED_BY = '" + EMPLOYEE_NO + "' WHERE LEAVE_FORM__NO = '" + TextBox1.Text + "'";
                        con = new OdbcConnection(connection);
                        con.ConnectionString = connection;
                        con.Open();

                        comm = new OdbcCommand(sql, con);
                        comm.ExecuteNonQuery();
                        con.Close();
                        Label_Message.Text = "Successfully...";
                        Status = RadioButtonList1.SelectedItem.Text.ToString();
                   } 
        }
        else
        {
            //Reset();
            Panel1.Visible = false;
            Panel2.Visible = false;
        }
    }
    private void Reset()
    {
        Text_Num.Text = "";
        Text_Request.Text = "";
        Text_StDate.Text = "";
        Text_EnDate.Text = "";
        Text_NumOfDays.Text = "";
        Text_Leave_Name.Text = "";
        Text_Comments.Text = "";

        //RadioButtonList1.Items.Clear();
        //RadioButtonList2.Items.Clear();
        GridViewBind();
        //TextBox1.Text = "";
    }
    protected void Butt_Reset_Click(object sender, EventArgs e)
    {
        Reset();
        Panel1.Visible = false;
        Panel2.Visible = false;
    }
    public void SendEMail(string Status)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        SUPERVISOR = Request.QueryString["SUPER"];
        MANAGER = Request.QueryString["MNG"];
        

        string date;
        date = DateTime.Now.Date.ToString("dd-MMMM-yyyy");

        // REQUESTER
        string sql = "SELECT nvl(EMPLOYEES.EMAIL,'nada.hameed@petroneeds.co')email, (EMPLOYees.employee_name)FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM employees, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = employees.DEPt_departmrnt_NO AND employees.EMPLOYEE_NO = '" + TextBox2.Text + "'"; //DEP_NO
        // SUPERVISOR
        string sql2 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO = '" + SUPERVISOR + "'";
        // MANAGER
        string sql3 = "SELECT USERS_INFORMATIONS.EMAIL, USERS_INFORMATIONS.FULL_USER_NAME, DEPARTMENTS.DEP_NAME " +
            "FROM USERS_INFORMATIONS, DEPARTMENTS WHERE DEPARTMENTS.DEP_NO = USERS_INFORMATIONS.DEP_NO AND USERS_INFORMATIONS.EMPLOYEE_NO = '" + MANAGER + "'";

       
        OdbcConnection conn = new OdbcConnection(connectionString);

        OdbcCommand cmd  = new OdbcCommand(sql, conn);
        OdbcCommand cmd2 = new OdbcCommand(sql2, conn);
        OdbcCommand cmd3 = new OdbcCommand(sql3, conn);

        cmd.Connection.Open();

        OdbcDataReader read  = cmd.ExecuteReader();
        OdbcDataReader read2 = cmd2.ExecuteReader();
        OdbcDataReader read3 = cmd3.ExecuteReader();
        
        read.Read();
        read2.Read();
        read3.Read();

        if (read.HasRows)
        {
            EmpName  = read["FULL_USER_NAME"].ToString();
            EmpEmail = read["EMAIL"].ToString();
            Depart   = read["DEP_NAME"].ToString();
        }
        if (read2.HasRows)
        {
            EmpName2   = read2["FULL_USER_NAME"].ToString();
            EmpEmail2  = read2["EMAIL"].ToString();
            AUTHORNAME = read2["FULL_USER_NAME"].ToString();
        }
        if (read3.HasRows)
        {
            EmpName3  = read3["FULL_USER_NAME"].ToString();
            EmpEmail3 = read3["EMAIL"].ToString();
        }

        if (SUPERVISOR == EMPLOYEE_NO && RadioButtonList1.SelectedValue != "")
        {
            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL="+ EmpEmail +"&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                            "&ApprovalName=" + EmpName3 + "&ApprovalEmail=" + EmpEmail3 + "&REQNAME=Leave Request&AUTHORNAME=" + EmpName2 + "");
        }
        else
            if (MANAGER == EMPLOYEE_NO && RadioButtonList2.SelectedValue != null)
        {
            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                           "&ApprovalName=&ApprovalEmail=&REQNAME=Leave Request&AUTHORNAME=" + EmpName3 + "");
        }
        else
            if (MANAGERSUPERVISOR == EMPLOYEE_NO && RadioButtonList1.SelectedValue != "")
        {
            Response.Redirect("~/UsersArea/E-mail.aspx?EMPLOYEE_NO=" + TextBox2.Text + "&DEP_NO=" + DEPARTMENT_NO + "&FULL_USER_NAME=" + EmpName + "&EMAIL=" + EmpEmail + "&DEP_NAME=" + Depart + "&REQSTATUS=" + Status + "&DATE=" + date + "" +
                           "&ApprovalName=&ApprovalEmail=&REQNAME=Leave Request&AUTHORNAME=" + EmpName3 + "");
        }
        cmd.Connection.Close();
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }
    //public int CheckStatus(int no)
    //{
    //    string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
    //    int FlagStatus;
    //    int count;
    //    EMPLOYEE_NO   =  Request.QueryString["EMPLOYEE_NO"];
    //    DEPARTMENT_NO = Request.QueryString["DEP_NO"];

    //    //string sql = "SELECT * FROM FORM_LEAVES_APPLICATION WHERE FORM_STATUS = '4' AND EMPLOYEE_NO IN " +
    //    //   " (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE SUPER ='" + 6199 + "')"; //int.Parse(EMPLOYEE_NO)
    //    string sql = "SELECT * FROM FORM_LEAVES_APPLICATION WHERE FORM_STATUS = '2' AND EMPLOYEE_NO IN " +
    //      " (SELECT EMPLOYEE_NO FROM EMP_MNG WHERE SUPER ='" + int.Parse(EMPLOYEE_NO) + "')"; //int.Parse(EMPLOYEE_NO)

    //    OdbcConnection conn = new OdbcConnection(connectionString);
    //    OdbcCommand cmd = new OdbcCommand(sql, conn);

    //    cmd.Connection.Open();
    //    OdbcDataReader read = cmd.ExecuteReader();
    //    read.Read();

    //    //DataSet ds = new DataSet();
    //    //OdbcDataAdapter adabter = new OdbcDataAdapter(cmd);

    //    //adabter.Fill(ds);

    //    //foreach (DataRow dr in ds.Tables[0].Rows)
    //    //{
    //    //    FlagStatus = dr["FORM_STATUS"].ToString();
    //    //    return int.Parse(FlagStatus);
    //    //}

    //    count = read.FieldCount;
    //    //Label_Message.Text = count.ToString();

    //    if (read.HasRows)
    //    //if (count == 2)
    //    {
    //        //FlagStatus = read["FORM_STATUS"].ToString();
    //        no = 4;
    //        //return CheckStatus(no);
    //        return (no);
    //    }
    //    else
    //    {
    //        return -1;
    //    }
    //    /////////////////////////////////////////////////////////////////////////
    //    //do
    //    //{
    //    //   //count = read.FieldCount;
    //    //   //Label_Message.Text = count.ToString();
    //    //    while (read.Read())
    //    //    {
    //    //        for (int i = 0; i < count; i++)
    //    //        {
    //    //            //read.GetValue(i);
    //    //            //FlagStatus =  read.GetInt32(read.GetOrdinal("FORM_STATUS")).ToString();

    //    //            //FlagStatus = read["FORM_STATUS"].ToString();
    //    //            //FlagStatus = read[i].ToString();

    //    //            FlagStatus = read.GetString(i);
    //    //            return int.Parse(FlagStatus);
    //    //        } 
    //    //    }
    //    //} while (read.NextResult());
    //    //////////////////////////////////////
    //    cmd.Connection.Close();
    //    //return -1;
    //}
}