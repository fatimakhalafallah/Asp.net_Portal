using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data.Odbc;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UsersArea_E_mail : System.Web.UI.Page
{
    public string EMPNUMBER, DEPARTMENTNO, Rcomment, EMPNAME, EMPEMAIL, FORMSTATUS, ACTIONDATE, REQUESTNAME, USERNAME, AUTHORNAME, EMPNAME3, EMPEMAIL3, EMPNAME4, EMPEMAIL4;
    public OdbcCommand comm = null;
    public OdbcConnection conn = null;

    //E_mails mail = new E_mails();
    //private string Toaddress;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Email();

            EMPNUMBER = Request.QueryString["EMPLOYEE_NO"];
            DEPARTMENTNO = Request.QueryString["DEP_NO"];
            FORMSTATUS = Request.QueryString["REQSTATUS"];

            EMPNAME3 = Request.QueryString["EmpName3"];
            EMPEMAIL3 = Request.QueryString["EmpEmail3"];

            EMPNAME3 = Request.QueryString["ApprovalName"];
            EMPEMAIL3 = Request.QueryString["ApprovalEmail"];
            Rcomment = Request.QueryString["comment"];

            //ITEMPNO = Request.QueryString["ITEMP"];
            //ITEMAIL= Request.QueryString["ITEMA"];


            //"&ITEMP=" + ITEMP + "&ITEMA=" + ITEmail

            if (EMPNUMBER != "" && DEPARTMENTNO != "")
            {
                MANAGERNOTIFICATIONEMAIL();
                if (FORMSTATUS == "Approve" && EMPEMAIL3 != "")
                {
                    USERNOTIFICATIONEMAIL2();
                }
            }
            else
                if (EMPNUMBER == "" && DEPARTMENTNO == "")
                {
                    USERNOTIFICATIONEMAIL();
                }
            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }

    //private void Email()
    //{
    //////MailMessage mm = new MailMessage("from@here.com", "to@there.com");
    //////mm.Body = "<span>your html goes here -- for plain text see IsBodyHtml property</span>";

    ////MailMessage message = new MailMessage("mohamedabdalla7@gmail.com", "mohamedabdalla7@gmail.com");
    ////message.Subject = "Hi, You have received new Message";
    ////message.IsBodyHtml = true;   
    ////message.Body = "<span>your html goes here -- for plain text see IsBodyHtml property</span>";   
    ////SmtpClient client = new SmtpClient();
    ////client.EnableSsl = true;
    ////client.Send(message);

    ////System.Net.NetworkCredential aCred = new System.Net.NetworkCredential("myacct", "mypassword"); 
    ////SmtpClient smtp = new SmtpClient("smtp.mail.petroneed.com.sd", 465); 
    ////smtp.EnableSsl = true; 
    ////smtp.UseDefaultCredentials = false; 
    ////smtp.Credentials = aCred;


    //MailMessage message = new MailMessage();
    //message.From = new MailAddress("portal@petroneeds.com.co");
    ////message.To.Add(new MailAddress("portal@petroneed.com.sd"));
    //message.To.Add(new MailAddress("mohamedabdalla7@hotmail.com"));
    ////message.Priority = MailPriority.Normal;
    //message.Subject = "Notification";
    //message.Body = "content";

    //SmtpClient client = new SmtpClient();
    //client.Send(message);
    // }

    //E_mails mail = new E_mails();

    private void MANAGERNOTIFICATIONEMAIL()
    {
        EMPNUMBER = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENTNO = Request.QueryString["DEP_NO"];
        EMPNAME = Request.QueryString["FULL_USER_NAME"];
        EMPEMAIL = Request.QueryString["EMAIL"];
        FORMSTATUS = Request.QueryString["REQSTATUS"];
        ACTIONDATE = Request.QueryString["DATE"];

        AUTHORNAME = Request.QueryString["AUTHORNAME"];

        REQUESTNAME = Request.QueryString["REQNAME"];//
        AUTHORNAME = Request.QueryString["AUTHORNAME"];
        Rcomment = Request.QueryString["comment"];
        string To;
        if (FORMSTATUS == "Return")
        {
            To = EMPEMAIL;
            //string Body = " <html><body><h2><p> Dear </p></h2> Mr/Mrs: " + EMPNAME + " </br>" +
            //              " Your id Number: " + EMPNUMBER + " </br>" +
            //              " Form Status: " + FORMSTATUS + " </br>" +
            //    //" Action: Under processing </br>" +
            //              " Action By: " + AUTHORNAME + " </br>" +
            //              " Action Date: " + ACTIONDATE + " </br></br></br>";// +
            //              //" Best Regards.  </br>" +
            //              //" Petroneeds Portal System  </div></html></body>";


            string Body = " <html><body>" +//+ REQUESTNAME + " </br>" +
                        "<h2><p> Dear Mr/Mrs: </p></h2> </br>" +
                        "&nbsp; &nbsp; &nbsp;<strong>" + EMPNAME + "</strong> </br></br>" +
                //"&nbsp; &nbsp; &nbsp;" + ADMINNAME + " </br></br>" +
                //"You have a pending travel request from: " + USERNAME + " </br>" +
                //"Please login to your system account to process it </br>" +
                //"&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; Thank you." +
                        "</br>" +
                        " Your <strong>" + REQUESTNAME + "</strong>  was <strong>" + FORMSTATUS + "</strong> </br>" +
                        " by <strong>" + AUTHORNAME + "</strong>  Please login to your system account to process it</br>" +
                         "http://portal/petroneeds/Login.aspx";
            //"Please login to your system account to process it </br>";
            // " due to <strong>" + Rcomment + "</strong> </br>";
            //" Request Date: " + ACTIONDATE + " </br></br></br>" +


            Emails(To, Body);
        }
        else
        {
            To = EMPEMAIL;
            string Body = " <html><body>" +//+ REQUESTNAME + " </br>" +
                   "<h2><p> Dear Mr/Mrs: </p></h2> </br>" +
                   "&nbsp; &nbsp; &nbsp;<strong>" + EMPNAME + "</strong> </br></br>" +
                //"&nbsp; &nbsp; &nbsp;" + ADMINNAME + " </br></br>" +
                //"You have a pending travel request from: " + USERNAME + " </br>" +
                //"Please login to your system account to process it </br>" +
                //"&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; Thank you." +
                   "</br>" +
                   " Your <strong>" + REQUESTNAME + "</strong>  was <strong>" + FORMSTATUS + "</strong> </br>" +
                   " by  <strong>" + AUTHORNAME + "</strong> </br>";// +
            //" Request Date: " + ACTIONDATE + " </br></br></br>" +
            //" Please check your account.  </br></br></br>";// +

            Emails(To, Body);

        }
        //E_mails(To, Body);
        //Response.Redirect(Request.UrlReferrer.ToString());
    }
    private void USERNOTIFICATIONEMAIL()
    {
        EMPNAME = Request.QueryString["FULL_USER_NAME"];//
        EMPEMAIL = Request.QueryString["EMAIL"];//
        FORMSTATUS = Request.QueryString["REQSTATUS"];

        ACTIONDATE = Request.QueryString["DATE"];//
        REQUESTNAME = Request.QueryString["REQNAME"];//
        USERNAME = Request.QueryString["USERNAMESREQ"];//


        EMPNAME3 = Request.QueryString["ApprovalName"];
        EMPEMAIL3 = Request.QueryString["ApprovalEmail"];

        //ITEMPNO = Request.QueryString["ITEMP"];
        //ITEMAIL = Request.QueryString["ITEMA"];
        //if (EMPNAME3 == "" && EMPEMAIL3 == null)

        string To = EMPEMAIL;
        //string To = "nada.hameed@petroneeds.co";
        //string To = "portal@petroneeds.co";

        //string Body = " <html><body><h2><p> Dear Mr/Mrs: </p></h2>  &nbsp; &nbsp; &nbsp;" + EMPNAME + " </br></br>" +
        //              " You are received request: " + REQUESTNAME + " </br>" +
        //              " From user: " + USERNAME + " </br>" +
        //              " Request Date: " + ACTIONDATE + " </br></br></br>" +
        //              " Please check your account.  </br></br></br>";// +
        //              //" Best Regards.  </br>" +
        //              //" Petroneeds Portal System  </div></html></body>";

        string Body = " <html><body>" +// " <html><body>" + REQUESTNAME + " </br>" +
                    "<h2><p> Dear Mr/Mrs: </p></h2> </br>" +
                    "&nbsp; &nbsp; &nbsp;" + EMPNAME + " </br></br>" +
                    "You have a pending request from: " + USERNAME + " </br>" +  /////////////////////////////////////////////////////
                    "Please login to your system account to process it </br>"+
                    "http://portal/petroneeds/Login.aspx";// +
        //"&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; Thank you." +
        // "</br></br></br>"+
        //" You are received request: " + REQUESTNAME + " </br>" +
        //" From user: " + USERNAME + " </br>" +
        //" Request Date: " + ACTIONDATE + " </br></br></br>" +
        //" Please check your account.  </br></br></br>";// +
        //" Best Regards.  </br>" +
        //" Petroneeds Portal System  </div></html></body>";

        Emails(To, Body, REQUESTNAME);


        //E_mails(To, Body, REQUESTNAME);
        //Response.Redirect(Request.UrlReferrer.ToString());
        //Response.Redirect("~/UsersArea/servicesSendRequest.aspx?USERNAME=" + USERNAME + "");
    }
    private void USERNOTIFICATIONEMAIL2()
    {
        EMPNAME = Request.QueryString["FULL_USER_NAME"];//
        EMPEMAIL = Request.QueryString["EMAIL"];//
        FORMSTATUS = Request.QueryString["REQSTATUS"];

        ACTIONDATE = Request.QueryString["DATE"];//
        REQUESTNAME = Request.QueryString["REQNAME"];//
        //USERNAME = Request.QueryString["USERNAMESREQ"];//


        EMPNAME3 = Request.QueryString["ApprovalName"];
        EMPEMAIL3 = Request.QueryString["ApprovalEmail"];

        //ITEMPNO = Request.QueryString["ITEMP"];
        //ITEMAIL = Request.QueryString["ITEMA"];

        string To = EMPEMAIL3;
        string Body = " <html><body>" +// " <html><body>" + REQUESTNAME + " </br>" +
                    "<h2><p> Dear Mr/Mrs: </p></h2> </br>" +
                    "&nbsp; &nbsp; &nbsp;" + EMPNAME3 + " </br></br>" +
                    "You have a pending request from: " + EMPNAME + " </br>" + ////////////////////////////////////////////////////
                    "Please login to your system account to process it </br>" +
                    "http://portal/petroneeds/Login.aspx"+
            //"&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; Thank you." +
                    "</br></br></br>";
        //" You are received request: " + REQUESTNAME + " </br>" +
        //" From user: " + USERNAME + " </br>" +
        //" Request Date: " + ACTIONDATE + " </br></br></br>" +
        //" Please check your account.  </br></br></br>";// +

        Emails(To, Body, REQUESTNAME);




        //E_mails(To, Body, REQUESTNAME);
        //Response.Redirect(Request.UrlReferrer.ToString());
        //Response.Redirect("~/UsersArea/servicesSendRequest.aspx?USERNAME=" + USERNAME + "");
    }
    private void Emails(string _To, string _Body, string _REQUESTNAME)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;

        //string sql = @"EXECUTE MAIL_MESSAGE (@subject = '" + _REQUESTNAME + "', @MESSAGE_TXT = '" + _Body + "', @mail_info = '', @request_url = '', "+
        //               "@recipient_mail = '" + _To + "', @recipient_name = '', @cc_mail  = '', @bcc_mail = '', @Ty = '')";

        //string sql = "CALL MAIL_MESSAGE ('TEST', 'NADA', 'HI', '', 'PORTAL@PETRONEEDS.CO','NADA', '', '', '');";

        string sql = "CALL MAIL_MESSAGE ('" + _REQUESTNAME + "', '" + _Body + "', '', '', '" + _To + "','', '', '', '');";
        conn = new OdbcConnection(connectionString);
        conn.ConnectionString = connectionString;
        conn.Open();

        comm = new OdbcCommand(sql, conn);
        comm.ExecuteNonQuery();
        conn.Close();
    }
    private void Emails(string _To, string _Body)
    {
        EMPNUMBER = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENTNO = Request.QueryString["DEP_NO"];
        EMPNAME = Request.QueryString["FULL_USER_NAME"];
        EMPEMAIL = Request.QueryString["EMAIL"];
        FORMSTATUS = Request.QueryString["REQSTATUS"];
        ACTIONDATE = Request.QueryString["DATE"];
        AUTHORNAME = Request.QueryString["AUTHORNAME"];
        REQUESTNAME = Request.QueryString["REQNAME"];//

        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        //string sql = "CALL MAIL_MESSAGE ('TEST', 'NADA', 'HI', '', 'PORTAL@PETRONEEDS.CO','NADA', '', '', '');";
        //string sql = "CALL MAIL_MESSAGE ('Approval Manager', 'NADA', 'HI', '', 'PORTAL@PETRONEEDS.CO','NADA', '', '', '');";

        string sql = "CALL MAIL_MESSAGE ('" + REQUESTNAME + "', '" + _Body + "', '', '', '" + _To + "','', '', '', '');";
        conn = new OdbcConnection(connectionString);
        conn.ConnectionString = connectionString;
        conn.Open();

        comm = new OdbcCommand(sql, conn);
        comm.ExecuteNonQuery();
        conn.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //SmtpClient smtpClient = new SmtpClient("ExchangeServerName", 25);

        //SmtpClient smtpClient = new SmtpClient("PN-MAIL-HTCAS.petroneed.local", 25);
        //MailMessage message = new MailMessage();
        //try
        //{
        //    MailAddress fromAddress = new MailAddress("portal@petroneeds.com.co", "Portal");
        //    MailAddress toAddress   = new MailAddress("zelabdein@petroneed.com.sd", "To You");
        //    message.From = fromAddress;
        //    message.To.Add(toAddress);
        //    message.Subject = "Notification Message!";
        //    message.Body = "This is a Sample Message";
        //    smtpClient.UseDefaultCredentials = true;
        //    System.Net.NetworkCredential nc = CredentialCache.DefaultNetworkCredentials;
        //    smtpClient.Credentials = (System.Net.ICredentialsByHost)nc.GetCredential("ExchangeServerNameSoll", 25, "Basic");
        //    smtpClient.Send(message);
        //    lblText.Text = "Email sent.";
        //}
        //catch (Exception ex)
        //{
        //    lblText.Text = "Coudn't send the message!\n  " + ex.Message;
        //}
        //////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////
    }
    public void E_mails(string Address, string MesBody)
    {
        List<E_mails> E_mails = new List<E_mails>();
        E_mails m = new E_mails(Address, MesBody);
    }
    public void E_mails(string Address, string MesBody, string MesTitle)
    {
        List<E_mails> E_mails = new List<E_mails>();
        E_mails m = new E_mails(Address, MesBody, MesTitle);
    }
}