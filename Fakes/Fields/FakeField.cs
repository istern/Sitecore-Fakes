using System.IO;
using System.Xml;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Xml;

namespace Sitecore.Fakes.Fields
{
    public class FakeField
    {
        public FakeField(string xmlString)
        {
            XMLDocument = XmlUtil.LoadXml(xmlString);
        }
 
        public void SetAttribute(string name, string value)
        {
            XmlUtil.SetAttribute(name, "", value, XMLDocument.FirstChild);
        }

        public XmlDocument XMLDocument;
    }
}