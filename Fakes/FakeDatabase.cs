using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.Fakes
{
    public class FakeDatabase : Database
    {
        private readonly ConcurrentBag<Item> _items;
        private readonly ConcurrentBag<Tuple<Item, IEnumerable<Item>>> _templates;

        public FakeDatabase(string name)
            : base(name)
        {
            _items = new ConcurrentBag<Item>();
            _templates = new ConcurrentBag<Tuple<Item, IEnumerable<Item>>>();
        }

        public virtual void FakeAddItem(Item item)
        {
            _items.Add(item);
        }
        public virtual void FakeAddTemplate(Item item, IEnumerable<Item> baseTemplates)
        {

            if (_templates.Count(tuple => tuple.Item1.ID == ID.Parse("{ab86861a-6030-46c5-b394-e8f99e8b87db}")) == 1)
            {
                Item defaultTemplateItem = new FakeItem(ID.Parse("{ab86861a-6030-46c5-b394-e8f99e8b87db}"), ID.NewID,
                    "Template", this.Name);
                Tuple<Item, IEnumerable<Item>> defaultTemplateMapping =
                    new Tuple<Item, IEnumerable<Item>>(defaultTemplateItem, new List<Item>());
                _templates.Add(defaultTemplateMapping);
            }


            Tuple<Item, IEnumerable<Item>> templateMapping = new Tuple<Item, IEnumerable<Item>>(item, baseTemplates);
            _templates.Add(templateMapping);
        }

        public virtual ConcurrentBag<Tuple<Item, IEnumerable<Item>>> GetTemplateMappings()
        {
            return _templates;
        }

       

        public virtual Item FakeGetItem(ID itemid)
        {
            return _items.FirstOrDefault(i => i.ID == itemid);
        }

       
 

 


        public Item RootItem { get; set; }
    }
}
