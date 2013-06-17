using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Data.Templates;


namespace Sitecore.Fakes
{
    public class FakeItem : Item
    {
        public const string DefaultitemName = "FakeItem";
        public const string DefaultDatabaseName = "web";


        public FakeItem(string itemName = DefaultitemName)
            : this(new FieldList(), itemName)
        {

        }


        public FakeItem(ID itemId, string itemName = DefaultitemName)
            : this(new FieldList(), itemId,itemName)
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

        public virtual Item FakeParent { get; set; }
        public virtual ItemList FakeChildren { get; set; }
    }




}