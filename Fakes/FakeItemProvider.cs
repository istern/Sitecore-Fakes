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
           FakeDatabase fakeDatabase = database as FakeDatabase;
           return fakeDatabase == null ? ((FakeDatabase) Factory.GetDatabase(database.Name)).FakeGetItem(itemId) : ((FakeDatabase) database).FakeGetItem(itemId);
       }

      
    }
}