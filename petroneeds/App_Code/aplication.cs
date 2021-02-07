using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;

/// <summary>
/// Summary description for Candidates
/// </summary>
public class aplication
{
    //private int rF_NO;
    private int sERIAL_nO;
    private string cAND_nAME;
    private int eXP_yEAR;
    private string aDD_cREDIT;
    private string rEMARKS;

    //public int RF_NO
    //{
    //    get{ return rF_NO; }
    //    set{ rF_NO = value; }
    //}

    public int SERIAL_NO
    {
        get{return sERIAL_nO;  }
        set{sERIAL_nO = value;  }
    }

    public string CAND_NAME
    {
        get { return cAND_nAME; }
        set {cAND_nAME =value;}
    }
    public int EXP_YEAR
    {
        get { return eXP_yEAR; }
        set { eXP_yEAR = value; } 
    }

    public string ADD_CREDIT
    {
        get { return aDD_cREDIT; }
        set { aDD_cREDIT = value; }
    }

	public string REMARKS
	{
        get { return rEMARKS; }
        set { rEMARKS = value; }
	}
}