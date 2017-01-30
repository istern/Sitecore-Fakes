using System;
using System.Collections.Generic;
using Sitecore.Collections;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;


namespace Sitecore.Fakes
{
    public class FakeItem : Item
    {
        public const string DefaultitemName = "FakeItem";
        public const string DefaultDatabaseName = "web";

        public FakeItem(string itemName = DefaultitemName)
            : this(ID.NewID, itemName)
        {
        }


        public FakeItem(ID itemId, string itemName = DefaultitemName)
            : this(new FieldList(), itemId, itemName)
        {
        }

        public FakeItem(string databaseName, string itemName = DefaultitemName)
            : this(new FieldList(), ID.NewID, itemName, databaseName)
        {
        }

        public FakeItem(string databaseName, ID itemId, string itemName = DefaultitemName)
            : this(new FieldList(), itemId, ID.NewID, itemName, databaseName)
        {
        }



        public FakeItem(ID itemId, ID templateID, string itemName, string dabaseName = DefaultDatabaseName)
            : this(new FieldList(), itemId, templateID, itemName, dabaseName)
        {

        }

        public FakeItem(ID itemId, ID templateID, string itemName = DefaultitemName)
            : this(new FieldList(), itemId, templateID, itemName)
        {
        }

        public FakeItem(FieldList fieldList, string itemName = DefaultitemName)
            : this(fieldList, ID.NewID, ID.NewID, itemName)
        {
        }

        public FakeItem(FieldList fieldList, ID itemid, string itemName = DefaultitemName, string databaseName = DefaultDatabaseName)
            : this(fieldList, itemid, ID.NewID, itemName, databaseName)
        {
        }
        public FakeItem(FieldList fieldList, ID itemid, ID templateId, Language language, string itemName = DefaultitemName, string databaseName = DefaultDatabaseName)
          : base(
             itemid,
              new ItemData(new ItemDefinition(ID.NewID, itemName, templateId, ID.NewID),
                           language, new Data.Version(1), fieldList),
              new FakeDatabase(databaseName))
        {

        }

        public FakeItem(ID itemid, ID templateId, Language language, string itemName = DefaultitemName, string databaseName = DefaultDatabaseName)
        : base(
           itemid,
            new ItemData(new ItemDefinition(ID.NewID, itemName, templateId, ID.NewID),
                         language, new Data.Version(1), new FieldList()),
            new FakeDatabase(databaseName))
        {
            FakeDatabase db = (FakeDatabase)this.Database;
            db.FakeAddItem(this);
        }


        public FakeItem(FieldList fieldList, ID itemid, ID templateId, string itemName = DefaultitemName, string databaseName = DefaultDatabaseName)
            : base(
               itemid,
                new ItemData(new ItemDefinition(ID.NewID, itemName, templateId, ID.NewID),
                             Globalization.Language.Invariant, new Data.Version(1), fieldList),
                new FakeDatabase(databaseName))
        {
            FakeDatabase db = (FakeDatabase)this.Database;
            db.FakeAddItem(this);
        }

        private FakeDatabase _fakeDatabase;
        public FakeDatabase GetFakeDatabase(string name = "web")
        {

            if (_fakeDatabase == null)
            {
                if (this.Database != null)
                    _fakeDatabase = (FakeDatabase)this.Database;
                if (_fakeDatabase == null)
                    _fakeDatabase = new FakeDatabase(name);
            }
            return _fakeDatabase;
        }

        public Item FakeParent;
        public override Item Parent
        {
            get { return FakeParent; }
        }

        public override ChildList GetChildren()
        {
            return GetChildren(ChildListOptions.None);
        }


        public override ChildList GetChildren(ChildListOptions options)
        {

            return new ChildList(this, FakeChildren);
        }

        public virtual ChildList Children
        {
            get
            {
                return new ChildList(this, FakeChildren);
            }
        }


        public static List<Item> FakeChildren = new List<Item>();
        public override Item Add(string name, TemplateID templateID)
        {
            var newItem = new FakeItem(ID.NewID, templateID, name, dabaseName: this.Database.Name);
           FakeDatabase db = (FakeDatabase) this.Database;
            FakeChildren.Add(newItem);
            db.FakeAddChildItem(this, newItem);
            newItem.FakeParent = this;
            return newItem;
        }
    }
}