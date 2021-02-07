using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SalarySlip
/// </summary>
public class SalarySlip
{
	//public SalarySlip()

    private string _NAME;
    private int _AMT;

    public SalarySlip(string NAME, int AMT)
    {
        _NAME = NAME;
        _AMT = AMT;
    }

    public string Name
    {
        get
        {
            return _NAME;
        }
    }

    public int AMT
    {
        get
        {
            return _AMT;
        }
	}
}