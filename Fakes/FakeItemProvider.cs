using Sitecore.Collections;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Globalization;
using Sitecore.SecurityModel;

namespace Sitecore.Fakes
{
    public class FakeItemProvider : ItemProvider
    {
        public override ChildList GetChildren(Item item, SecurityCheck securityCheck)
        {
            return new ChildList(item,((FakeItem)item).FakeChildren);
        }

       public override Item GetParent(Item item, SecurityCheck securityCheck)
       {
           return ((FakeItem) item).FakeParent;
       }

       public override Item GetItem(ID itemId, Language language, Version version, Database database, SecurityCheck securityCheck)
       {
           var fakeDatabase = database as FakeDatabase;
           return fakeDatabase == null ? ((FakeDatabase) Factory.GetDatabase(database.Name)).FakeGetItem(itemId) : ((FakeDatabase) database).FakeGetItem(itemId);
       }

       public override Item GetRootItem(Language language, Version version, Database database, SecurityCheck securityCheck)
       {
           var fakeDatabase = database as FakeDatabase;
           return fakeDatabase == null ? ((FakeDatabase)Factory.GetDatabase(database.Name)).RootItem : fakeDatabase.RootItem;
       }

       public override Item AddFromTemplate(string itemName, ID templateId, Item destination, ID newId)
       {
           FakeDatabase fakeDatabase = Factory.GetDatabase(destination.Database.Name) as FakeDatabase;
           FakeItem child = new FakeItem(newId, templateId, itemName, fakeDatabase.Name);
           FakeItem fakeParent = destination as FakeItem;
           fakeParent.AddChild(child);
           fakeDatabase.FakeAddItem(child);
           return child;
       }
    }
}