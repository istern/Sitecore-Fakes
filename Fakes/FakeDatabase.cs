using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.Fakes
{
    public class FakeDatabase : Database
    {
        private readonly ConcurrentBag<Item> _items;

        public FakeDatabase(string name) : base(name)
        {
            _items = new ConcurrentBag<Item>();
        }

        public virtual void FakeAddItem(Item item)
        {
            _items.Add(item);
        }

        public virtual Item FakeGetItem(ID itemid)
        {
            return _items.FirstOrDefault(i => i.ID == itemid);
        }
    }
}
