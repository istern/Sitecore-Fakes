using System;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Items;


namespace Sitecore.Fakes
{
    public class FakeItem : Item
    {
        public const string DefaultitemName = "FakeItem";
        public const string DefaultDatabaseName = "web";


        public FakeItem()
            : this(ID.NewID)
        {
        }

        public FakeItem(string itemName = DefaultitemName)
            : this(ID.NewID,itemName)
        {
        }


        public FakeItem(ID itemId,string itemName=DefaultitemName)
            : this(new FieldList(), itemId,itemName)
        {
        }
        public FakeItem(FieldList fieldList, ID itemId)
            : this(fieldList, itemId,DefaultitemName,DefaultDatabaseName )
        {
        }

        public FakeItem(FieldList fieldList, string itemName = DefaultitemName)
            : this(fieldList, ID.NewID, itemName)
        {
        }
        
        public FakeItem(FieldList fieldList, ID itemid, string itemName = DefaultitemName, string databaseName = DefaultDatabaseName)
            : base(
               itemid,
                new ItemData(new ItemDefinition(new ID(new Guid()), itemName, new ID(new Guid()), new ID(new Guid())),
                             Globalization.Language.Invariant, new Data.Version(1), fieldList),
                new Database(databaseName))
        {
            FakeChildren = new ItemList();
        }

        
        public virtual void AddChild(Item child)
        {
            ((FakeItem)child).FakeParent = this;
            FakeChildren.Add(child);
        }

        public Item FakeParent { get; set; }
        public ItemList FakeChildren { get; set; }
    }
}