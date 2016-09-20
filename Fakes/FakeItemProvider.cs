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
            return null;
        }

       public override Item GetParent(Item item, SecurityCheck securityCheck)
       {
           return null;
       }

       public override Item GetItem(ID itemId, Language language, Version version, Database database, SecurityCheck securityCheck)
       {
           return database.GetItem(itemId, language);
       }

       public override Item GetRootItem(Language language, Version version, Database database, SecurityCheck securityCheck)
       {
           return database.GetRootItem();
       }

       public override Item AddFromTemplate(string itemName, ID templateId, Item destination, ID newId)
       {
          return null;
       }
    }
}