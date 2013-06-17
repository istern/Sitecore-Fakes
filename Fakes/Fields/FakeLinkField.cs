using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.IO;
using Sitecore.Xml;

namespace Sitecore.Fakes.Fields
{
    public class FakeLinkField : FakeField
    {
        public static string LinkFieldXML = "<link linktype='' url='' querystring='' target='' id='' class='' anchor='' text='' title='' />";

        public FakeLinkField() : base(LinkFieldXML)
        {
        
        }
        
        public string Anchor
        {
            set
            {
                SetAttribute("anchor", value);
            }
        }

        public string Class
        {
            set
            {
                SetAttribute("class", value);
            }
        }

        public string LinkType
        {
            set
            {
                SetAttribute("linktype", value);
            }
        }

        public string QueryString
        {
            set
            {
                SetAttribute("querystring", value);
            }
        }

        public string Target
        {
            set
            {
                SetAttribute("target", value);
            }
        }

        public ID TargetID
        {
            set
            {

                SetAttribute("id", value.ToString());
            }
        }

        public Item TargetItem
        {
            set
            {
                TargetID = value.ID;
                ((FakeDatabase)Factory.GetDatabase("web")).FakeAddItem(value);
            }
        }

        public string Text
        {
            set
            {
                SetAttribute("text", value);
            }
        }

        public string Title
        {
 
            set
            {
                SetAttribute("title", value);
            }
        }

        public string Url
        {
           set { SetAttribute("url", value); }
        }

    }
}
