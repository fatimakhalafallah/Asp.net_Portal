using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Serialization;

public partial class test_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        doc.Load(Server.MapPath("MySource.xml"));
        System.Xml.Xsl.XslTransform trans = new
           System.Xml.Xsl.XslTransform();
        trans.Load(Server.MapPath("MyStyle.xsl"));
        Xml1.Document = doc;
        Xml1.Transform = trans;
    }
}