using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Odbc;
using System.Configuration;

public partial class login : System.Web.UI.Page
{
    public OdbcConnection conn = null;
    public OdbcCommand cmd = null;
    public OdbcDataReader read = null;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Clear_Text();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Text_User.Text.ToLower() != "admin")
        {
            UserLogin();
        }
        else
            if (Text_User.Text.ToLower() == "admin")
        {
            LOGIN_Admin_Area();
       } 
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/MasterPage.master");
        Response.Redirect("~/Default.aspx");
    }
    private void UserLogin()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        //string sql = "SELECT EMPLOYEE_NO, DEP_NO FROM USERS_INFORMATIONS WHERE LOGIN_NAME = '" + Text_User.Text.ToLower() + "' AND ACTIVE = '"+1+"'";
        string sql = "SELECT USERS_INFORMATIONS.EMPLOYEE_NO, USERS_INFORMATIONS.DEP_NO FROM USERS_INFORMATIONS, USERS_PASSWORDS "+
                      "WHERE USERS_INFORMATIONS.USER_NO = USERS_PASSWORDS.UI_USER_NO AND USERS_INFORMATIONS.LOGIN_NAME = '" + Text_User.Text.ToLower() + "' AND " + //nada
                      "USERS_PASSWORDS.PASSWORDS = '" + Text_Password.Text + "' AND USERS_INFORMATIONS.ACTIVE = '1'";//132343
        
        string Msg = String.Empty;

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        //Msg = (string)cmd.ExecuteScalar();
        OdbcDataReader read = cmd.ExecuteReader();

        string Emp_No, Emp_Status, Dep_No;

        if (read.Read())
        {
            Emp_No = read.GetValue(0).ToString();
            Dep_No = read.GetValue(1).ToString();
            Emp_Status = read.Read().ToString();

            //string username = Text_User.Text.ToLower();
            //string password = Text_Password.Text;
            //if (FormsAuthentication.Authenticate(username, password))
            //{
            //    FormsAuthentication.RedirectFromLoginPage(username, false);

                if (read.HasRows == true)
                {
                    if (Emp_No != "" && Dep_No != "")
                    {
                        if (FormsAuthentication.Authenticate(Emp_No, Dep_No) == false)
                        {
                            Session["loginStatus"] = Emp_No;
                            //System.Web.Security.FormsAuthentication.RedirectFromLoginPage(Emp_No, false);

                            System.Web.Security.FormsAuthentication.RedirectFromLoginPage(Emp_No, false);
                            //FormsAuthentication.SetAuthCookie(Emp_No, false);
                            Response.Redirect("~/UsersArea/Default.aspx?EMPLOYEE_NO=" + Emp_No + "&DEP_NO=" + Dep_No + "&" + true + "");
                        }

                       // Response.Redirect("~/UsersArea/Default.aspx?EMPLOYEE_NO=" + Emp_No + "&DEP_NO=" + Dep_No + "");

                        //Response.Redirect("~/UsersArea/Default.aspx?EMPLOYEE_NO=" + 6199 + "&DEP_NO=" + Dep_No + "");
                       //Server.Transfer("~/UsersArea/Default.aspx?EMPLOYEE_NO=" + Emp_No + "&DEP_NO=" + Dep_No + "", false);
                        //Response.Redirect("~/UsersArea/Default.aspx?EMPLOYEE_NO=" + Emp_No + "&DEP_NO=" + Dep_No + "&,NewWindow,location=no,menubar=no,status=no,toolbar=no,titlebar=no");
                        //window.open('http://www.asp.net/', 'NewWindow', 'location=no,menubar=no,status=no,toolbar=no,titlebar=no');
                        //FormsAuthentication.RedirectFromLoginPage(Text_User.Text.ToLower(), true, "~/UsersArea/Default.aspx?EMPLOYEE_NO=" + Emp_No + "&DEP_NO=" + Dep_No + "");
                        //System.Web.Security.FormsAuthentication.RedirectFromLoginPage(Text_User.Text.ToLower(), true, "~/UsersArea/Default.aspx?EMPLOYEE_NO=" + Emp_No + "&DEP_NO=" + Dep_No + "");
                        //Response.Redirect("~/UsersArea/Default.aspx?EMPLOYEE_NO=" + Emp_No + "&DEP_NO=" + Dep_No + "");
                    }
                    else
                    {
                        Label4.Text = "This user not exist";
                    }
                    cmd.Connection.Close();
                }
            }
            else
            {
                Label4.Text = "Error Your User Name or Password,</br>or You haven't Authorization to access this area, </br>or you are suspend </br>" +
                 "Please contact your Administrator";
            }
    }
    private void Clear_Text()
    {
        Text_User.Text = "";
        Text_Password.Text = "";
        Label3.Text = "";
        Label4.Text = "";
    }



    private void LOGIN_Admin_Area1()
    {
        string username = Text_User.Text.ToLower();
        string password = Text_Password.Text;

        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        //string sql = "SELECT EMPLOYEE_NO, DEP_NO FROM USERS_INFORMATIONS WHERE LOGIN_NAME = '" + Text_User.Text.ToLower() + "' AND ACTIVE = '"+1+"'";
        string sql = "SELECT USERS_INFORMATIONS.EMPLOYEE_NO, USERS_INFORMATIONS.DEP_NO FROM USERS_INFORMATIONS, USERS_PASSWORDS " +
                      "WHERE USERS_INFORMATIONS.USER_NO = USERS_PASSWORDS.UI_USER_NO AND USERS_INFORMATIONS.LOGIN_NAME = '" + Text_User.Text.ToLower() + "' AND " + //nada
                      "USERS_PASSWORDS.PASSWORDS = '" + Text_Password.Text + "' AND USERS_INFORMATIONS.ACTIVE = '1'";//132343

        string Msg = String.Empty;

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand(sql, conn);

        cmd.Connection.Open();
        //Msg = (string)cmd.ExecuteScalar();
        OdbcDataReader read = cmd.ExecuteReader();

        string Emp_No, Emp_Status, Dep_No;

        if (read.Read())
        {
            Emp_No = read.GetValue(0).ToString();
            Dep_No = read.GetValue(1).ToString();
            Emp_Status = read.Read().ToString();

            //string username = Text_User.Text.ToLower();
            //string password = Text_Password.Text;
            //if (FormsAuthentication.Authenticate(username, password))
            //{
            //    FormsAuthentication.RedirectFromLoginPage(username, false);

            if (read.HasRows == true)
            {
                if (Emp_No != "" && Dep_No != "")
                {
                    if (FormsAuthentication.Authenticate(Emp_No, Dep_No) == false)
                    {
                        Session["loginStatus"] = Emp_No;
                        //System.Web.Security.FormsAuthentication.RedirectFromLoginPage(Emp_No, false);

                        System.Web.Security.FormsAuthentication.RedirectFromLoginPage(Emp_No, false);
                        //FormsAuthentication.SetAuthCookie(Emp_No, false);
                        Response.Redirect("~/UsersArea/Default.aspx?EMPLOYEE_NO=" + Emp_No + "&DEP_NO=" + Dep_No + "&" + true + "");
                    }

                    // Response.Redirect("~/UsersArea/Default.aspx?EMPLOYEE_NO=" + Emp_No + "&DEP_NO=" + Dep_No + "");

                    //Response.Redirect("~/UsersArea/Default.aspx?EMPLOYEE_NO=" + 6199 + "&DEP_NO=" + Dep_No + "");
                    //Server.Transfer("~/UsersArea/Default.aspx?EMPLOYEE_NO=" + Emp_No + "&DEP_NO=" + Dep_No + "", false);
                    //Response.Redirect("~/UsersArea/Default.aspx?EMPLOYEE_NO=" + Emp_No + "&DEP_NO=" + Dep_No + "&,NewWindow,location=no,menubar=no,status=no,toolbar=no,titlebar=no");
                    //window.open('http://www.asp.net/', 'NewWindow', 'location=no,menubar=no,status=no,toolbar=no,titlebar=no');
                    //FormsAuthentication.RedirectFromLoginPage(Text_User.Text.ToLower(), true, "~/UsersArea/Default.aspx?EMPLOYEE_NO=" + Emp_No + "&DEP_NO=" + Dep_No + "");
                    //System.Web.Security.FormsAuthentication.RedirectFromLoginPage(Text_User.Text.ToLower(), true, "~/UsersArea/Default.aspx?EMPLOYEE_NO=" + Emp_No + "&DEP_NO=" + Dep_No + "");
                    //Response.Redirect("~/UsersArea/Default.aspx?EMPLOYEE_NO=" + Emp_No + "&DEP_NO=" + Dep_No + "");
                }
                else
                {
                    Label4.Text = "This user not exist";
                }
                cmd.Connection.Close();
            }
        }
        else
        {
            Label4.Text = "Error Your User Name or Password,</br>or You haven't Authorization to access this area, </br>or you are suspend </br>" +
             "Please contact your Administrator";
        }
    }


    private void LOGIN_Admin_Area()
    {
        string username = Text_User.Text.ToLower();
        string password = Text_Password.Text;

        if (FormsAuthentication.Authenticate(username, password) == false)
        {
            System.Web.Security.FormsAuthentication.RedirectFromLoginPage(username , false);
            Response.Redirect("AdminArea/Default.aspx");
        }

        else
        {
            Label4.ForeColor = System.Drawing.Color.DarkRed;
            Label4.Text = "Valid User Name or Password";
        }
    }
}