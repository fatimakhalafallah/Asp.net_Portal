using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;  
using System.Net.Mail;

/// <summary>
/// Summary description for E_mails
/// </summary>
public class E_mails
{
    //private string _ToAdress;
    //public string Address
    //{
    //    get { return _ToAdress; }
    //    set { _ToAdress = value; }
    //}

    public E_mails(string Address, string MesBody)
	{
        //SmtpClient smtpClient = new SmtpClient("ExchangeServerName", 25);
        SmtpClient smtpClient = new SmtpClient("PN-MAIL-HTCAS.petroneed.local", 25);
        MailMessage message = new MailMessage();
        try
        {
            MailAddress fromAddress = new MailAddress("portal@petroneeds.com.co", "Portal");
            MailAddress toAddress = new MailAddress(Address, "noreply@petroneeds.com.co");
            message.IsBodyHtml = true;
            message.From = fromAddress;
            message.To.Add(toAddress);
            //message.Subject = "Notification Message!";
            message.Subject = "Notification Message!";
            message.Body = MesBody;
            smtpClient.UseDefaultCredentials = true;
            System.Net.NetworkCredential nc = CredentialCache.DefaultNetworkCredentials;
            smtpClient.Credentials = (System.Net.ICredentialsByHost)nc.GetCredential("ExchangeServerNameSoll", 25, "Basic");
            smtpClient.Send(message);
            //lblText.Text = "Email sent.";
            //return Toaddress;
        }
        catch (Exception ex)
        {
            //lblText.Text = "Coudn't send the message!\n  " + ex.Message;
        }
	}
    public E_mails(string Address, string MesBody, string MesTitle)
    {
        //SmtpClient smtpClient = new SmtpClient("ExchangeServerName", 25);
        SmtpClient smtpClient = new SmtpClient("PN-MAIL-HTCAS.petroneed.local", 25);
        MailMessage message = new MailMessage();
        try
        {
            MailAddress fromAddress = new MailAddress("portal@petroneeds.com.co", "Portal");
            MailAddress toAddress = new MailAddress(Address, "noreply@petroneeds.com.co");
            message.IsBodyHtml = true;
            message.From = fromAddress;
            message.To.Add(toAddress);

            //message.Subject = "Notification Message!";
            message.Subject = "Notification Message!  " +  MesTitle;
            message.Body = MesBody;

            smtpClient.UseDefaultCredentials = true;
            System.Net.NetworkCredential nc = CredentialCache.DefaultNetworkCredentials;
            smtpClient.Credentials = (System.Net.ICredentialsByHost)nc.GetCredential("ExchangeServerNameSoll", 25, "Basic");
            smtpClient.Send(message);
            //lblText.Text = "Email sent.";
            //return Toaddress;
        }
        catch (Exception ex)
        {
            //lblText.Text = "Coudn't send the message!\n  " + ex.Message;
        }
    }
}