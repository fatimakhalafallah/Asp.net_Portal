using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Odbc;


public partial class UsersArea_servicesSendRequest : System.Web.UI.Page
{
    public string EMPLOYEE_NO, DEPARTMENT_NO, EMPLOYEE_NAME;

    protected void Page_Load(object sender, EventArgs e)
    {
        EMPLOYEE_NO   = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        UserInformation();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        Response.Redirect("~/UsersArea/default.aspx?EMPLOYEE_NO=" + EMPLOYEE_NO + "&DEP_NO=" + DEPARTMENT_NO + "&" + true + "");
        //Response.End();
        //Response.Close();
    }
    public void UserInformation()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];

        string sql = "SELECT USERS_INFORMATIONS.FULL_USER_NAME, USERS_INFORMATIONS.EMAIL, " +
                    "DEPARTMENTS.DEP_NAME FROM USERS_INFORMATIONS INNER JOIN DEPARTMENTS ON (USERS_INFORMATIONS.DEP_NO = DEPARTMENTS.DEP_NO) " +
                    "AND USERS_INFORMATIONS.DEP_NO = '" + int.Parse(DEPARTMENT_NO) + "' WHERE USERS_INFORMATIONS.EMPLOYEE_NO = '" + Int32.Parse(EMPLOYEE_NO) + "'";

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        OdbcDataReader read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            EMPLOYEE_NAME = read["FULL_USER_NAME"].ToString();
            //Label2.Text = EMPLOYEE_NAME + ", your request was send, please press the below link or sign out";
            Label2.Text = EMPLOYEE_NAME + ", your request was send, please press";
            Label2.Text = "or";
        }
        else
        {

        }
        cmd.Connection.Close();
    }
    protected void LoginStatus2_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Session["loginStatus"] = null;
        Session.Remove("loginStatus");
        Session.Clear();
        Session.Abandon();


        System.Web.Security.FormsAuthentication.SignOut();
        Response.Redirect(Request.UrlReferrer.ToString());
        Response.Cookies.Clear();
        Session.RemoveAll();
        Response.CacheControl = "no-cache";
    }
}