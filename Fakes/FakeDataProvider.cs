using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;
using Sitecore.Data.DataProviders;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace Sitecore.Fakes
{
    public class FakeDataProvider : DataProvider
    {
        public Item FakeRootItem { get; set; }

        public override ID GetRootID(CallContext context)
        {
            return FakeRootItem.ID;
        }


    }

  

     

    
}
