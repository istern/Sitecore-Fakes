using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.Fakes
{
    public static class DatabaseExtensions
    {
        private static Item RootItem { get; set; }
        public static void SetRootItem(this Database database, Item rootItem)
        {
            RootItem = rootItem;
        }

        public static Item GetRootItem(this Database database)
        {
            return RootItem;
        }

    }
}
