﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class recruiter_profile : System.Web.UI.Page
{
    SqlConnection con = null;
    SqlDataAdapter adp = null;
    string RName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["RName"] != null)
        {
            RName = Session["RName"].ToString();
        }
         
        con = new SqlConnection("Data Source=ANAH-PC;Initial Catalog=Jobbada;Integrated Security=True;");
        con.Open();

        string query = "select * from Company where username='" + RName + "'";
        adp = new SqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        DetailsView1.DataSource = ds;   
        DetailsView1.DataBind();

        
    }
}
