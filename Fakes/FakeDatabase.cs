using System.Collections.Concurrent;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.Fakes
{
    public class FakeDatabase : Database
    {
        private readonly ConcurrentBag<Item> _items;
       

        public FakeDatabase(string name)
            : base(name)
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

        public Item RootItem { get; set; }
    }
}
