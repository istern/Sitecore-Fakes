using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.Fakes.Fields
{
    public class FakeInternalLinkField : FakeLinkField
    {
        public FakeInternalLinkField(Item itemToLinkTo,string target="",string url = "", string text="", string anchor="",string querystring="" ,string title="" ,string cssclass="")
        {
            SetLinkToItem(itemToLinkTo);
            Target = target;
            Url = url;
            Text = text;
            Anchor = anchor;
            QueryString = querystring;
            Title = title;
            Class = cssclass;
            LinkType = "internal";
        }

        private void SetLinkToItem(Item itemToLinkTo)
        {
            ((FakeDatabase) Factory.GetDatabase(itemToLinkTo.Database.Name)).FakeAddItem(itemToLinkTo);
            TargetItem = itemToLinkTo;
        }

        public override string ToString()
        {
           return XMLDocument.InnerXml;
        }
    }
}
