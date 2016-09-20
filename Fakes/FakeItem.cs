using System;
using Sitecore.Collections;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;


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
            : this(fieldList, itemid, ID.NewID, itemName,databaseName)
        {
        }

        public FakeItem(FieldList fieldList, ID itemid, ID templateId, string itemName = DefaultitemName, string databaseName = DefaultDatabaseName)
            : base(
               itemid,
                new ItemData(new ItemDefinition(ID.NewID, itemName, templateId, ID.NewID),
                             Globalization.Language.Invariant, new Data.Version(1), fieldList),
                new FakeDatabase(databaseName))
        {         
         
        }

    }
}