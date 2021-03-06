﻿using System;
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
using System.Data.SqlTypes;
using System.Data.Common;

public partial class userControll_EQ_requestl : System.Web.UI.UserControl
{
    public OdbcCommand odbccomm = null;
    public OdbcConnection odbccon = null;
    public OdbcDataAdapter odbcadabter = null;
    public DataSet dataset = null;

    private string connection = null;
    protected System.Configuration.Configuration rootCfg = null;
    protected System.Configuration.ConnectionStringSettings ConfigConString = null;

    public SqlCommand sqlcomm = null;
    public SqlConnection sqlconn = null;

    public string EMPLOYEE_NO, DEPARTMENT_NO, FormNo, FormDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        ItemNo();
        Text_Bran_No.Text = Request.Form[Text_Bran_No.UniqueID];
        Text_Description.Text = Request.Form[Text_Description.UniqueID];
        //Text_Unit.Text = Request.Form[Text_Unit.UniqueID];
        Text_QTY.Text = Request.Form[Text_QTY.UniqueID];
        DropDownList1.SelectedValue = Request.Form[DropDownList1.UniqueID];

       // TextBox1.Text = Request.Form[TextBox1.UniqueID];

        FormNo = Session["FormNo"].ToString();
        FormDate = Session["FormDate"].ToString();

        if (FormNo != "0")
        {

            //CheckAccountDetails();
            //AddNewFormNu();
            Add_new(FormNo, FormDate);
            

        }
        else
        {

        }
    }


   

   /* public string FirstName
    {

        get {  return DropDownList1.SelectedValue = Request.Form[DropDownList1.UniqueID]; }

       //  DropDownList1.DataSourceSelectArguments
       // get { return DropDownList1.SelectedValue; }
            //.SelectedValue;

           //set { DropDownList1.SelectedValue = value; }
          // get { return this.DropDownList1.SelectedValue; }
       // return  DropDownList1.SelectedValue;
    }*/

    public string FirstName
    {
        get
        {
            return DropDownList1.SelectedValue;
        }
    }



    public void AddNewFormNu()
    {
        FormNo = Session["FormNo"].ToString();
        string connectionString = ConfigurationManager.ConnectionStrings["PetroneedsConnectionString"].ConnectionString;
        string sql = "SELECT NVL(MAX(REQ_NO),0)+1 FROM ICT_EDETAIL";

        OdbcConnection odbcconn = new OdbcConnection(connectionString);
        OdbcCommand odbccmd = new OdbcCommand(sql, odbcconn);

        odbccmd.Connection.Open();
        OdbcDataReader read = odbccmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            Text_Bran_No.Text = read[0].ToString();
        }
        odbccmd.Connection.Close();
    }
    private void ItemNo()
    {
        DataSet dset;


        DropDownList1.Items.Clear();
        string connectionString = ConfigurationManager.ConnectionStrings["petroneedsConnectionString"].ConnectionString;
        OdbcConnection con = new OdbcConnection(connectionString);

        string sql = "SELECT EQ_NAME , EID FROM ICT_EQU";

        con.Open();
        OdbcCommand cmd = new OdbcCommand(sql, con);
        DataSet dataset = new DataSet();
        OdbcDataAdapter ad = new OdbcDataAdapter(sql, con);
        ad.Fill(dataset);

        DropDownList1.DataSource = dataset;
        DropDownList1.DataTextField = "EQ_NAME";///FULL_USER_NAME 
        DropDownList1.DataValueField = "EQ_NAME";//EMPLOYEE_NO
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("<<<Select>>>", "0"));
        //DropDownList1.Items.Insert(0, new ListItem("--Select--", "-1")); 
        //DropDownList1.SelectedIndex = 0;
        //DropDownList1.SelectedValue = "0";
        DropDownList1.SelectedItem.Value = "0";


    }


  

    private void Add_new(string FormNo, string FormDate)
    {
        rootCfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/petroneeds");
        connection = rootCfg.ConnectionStrings.ConnectionStrings["petroneedsConnectionString"].ConnectionString.ToString();

        EMPLOYEE_NO = Request.QueryString["EMPLOYEE_NO"];
        DEPARTMENT_NO = Request.QueryString["DEP_NO"];
        AddNewFormNu();

        OdbcCommand odbccomm = null;
        OdbcConnection odbccon = null;
        string sql;
       
            odbccon = new OdbcConnection(connection);
            odbccon.ConnectionString = connection;
            odbccon.Open();
            AddNewFormNu();
            sql = "INSERT INTO ICT_EDETAIL(REQ_NO,FORM_NO,EQ_NAME,QUANTITY,DESCRIPTION, ITEM_NO) VALUES('" + Text_Bran_No.Text + "','" + FormNo + "', ' "+DropDownList1.SelectedValue+"', '" + Text_QTY.Text + "', '" + Text_Description.Text + "','')";


            odbccomm = new OdbcCommand(sql, odbccon);
            odbccomm.ExecuteNonQuery();
            odbccon.Close();
            AddNewFormNu();
        
    }


}



