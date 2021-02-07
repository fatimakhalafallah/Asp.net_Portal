﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Events : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.SelectedIndex == i)
            {
                string name = GridView1.Rows[i].Cells[0].Text;
                TextBox1.Text = name.ToString();
            }
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.SelectedIndex == i)
            {
                string name = GridView1.Rows[i].Cells[0].Text;
                TextBox1.Text = name.ToString();
            }
        }
    }
}