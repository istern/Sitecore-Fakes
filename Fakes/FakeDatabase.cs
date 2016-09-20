using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Lucene.Net.Search;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Archiving;
using Sitecore.Data.Clones;
using Sitecore.Data.DataProviders;
using Sitecore.Data.Eventing;
using Sitecore.Data.Items;
using Sitecore.Data.Proxies;
using Sitecore.Globalization;
using Sitecore.Resources;
using Sitecore.Workflows;
using Version = Sitecore.Data.Version;

namespace Sitecore.Fakes
{
    public class FakeDatabase : Database
    {
        private readonly ConcurrentBag<Item> _items;
        private readonly ConcurrentBag<Tuple<Item, IEnumerable<Item>>> _templates;
        private Item _rootItem;

        public FakeDatabase(string name)
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

       

        public Item RootItem {
            get
            {
                if(_rootItem == null)
                    return new FakeItem();
                return _rootItem;
            } 
            set { _rootItem = value; } }
        public override bool CleanupDatabase()
        {
            throw new NotImplementedException();
        }

        public override Item CreateItemPath(string path)
        {
            throw new NotImplementedException();
        }

        public override Item CreateItemPath(string path, TemplateItem template)
        {
            throw new NotImplementedException();
        }

        public override Item CreateItemPath(string path, TemplateItem folderTemplate, TemplateItem itemTemplate)
        {
            throw new NotImplementedException();
        }

        public override DataProvider[] GetDataProviders()
        {
            throw new NotImplementedException();
        }

        public override long GetDataSize(int minEntitySize, int maxEntitySize)
        {
            throw new NotImplementedException();
        }

        public override long GetDictionaryEntryCount()
        {
            throw new NotImplementedException();
        }

        public override Item GetItem(ID itemId)
        {
            return _items.FirstOrDefault(i => i.ID == itemId);
        }

        public override Item GetItem(ID itemId, Language language)
        {
            return _items.FirstOrDefault(i => i.ID == itemId && i.Language == language);
        }

        public override Item GetItem(ID itemId, Language language, Version version)
        {
            throw new NotImplementedException();
        }

        public override Item GetItem(string path)
        {
            throw new NotImplementedException();
        }

        public override Item GetItem(string path, Language language)
        {
            throw new NotImplementedException();
        }

        public override Item GetItem(string path, Language language, Version version)
        {
            throw new NotImplementedException();
        }

        public override Item GetItem(DataUri uri)
        {
            throw new NotImplementedException();
        }

        public override LanguageCollection GetLanguages()
        {
            throw new NotImplementedException();
        }

        public override Item GetRootItem()
        {
            return RootItem;
        }

        public override Item GetRootItem(Language language)
        {
            throw new NotImplementedException();
        }

        public override IndexSearcher GetSearcher(string name)
        {
            throw new NotImplementedException();
        }

        public override TemplateItem GetTemplate(ID templateId)
        {
            return (TemplateItem) _items.FirstOrDefault(i => i.ID == templateId);
        }

        public override TemplateItem GetTemplate(string fullName)
        {
            throw new NotImplementedException();
        }

        public override Item[] SelectItems(string query)
        {
            throw new NotImplementedException();
        }

        public override ItemList SelectItemsUsingXPath(string query)
        {
            throw new NotImplementedException();
        }

        public override Item SelectSingleItem(string query)
        {
            throw new NotImplementedException();
        }

        public override Item SelectSingleItemUsingXPath(string query)
        {
            throw new NotImplementedException();
        }

        public override AliasResolver Aliases { get; }
        public override List<string> ArchiveNames { get; }
        public override DataArchives Archives { get; }
        public override DatabaseCaches Caches { get; }
        public override string ConnectionStringName { get; set; }
        public override DataManager DataManager { get; }
        public override DatabaseEngines Engines { get; }
        public override bool HasContentItem { get; }
        public override string Icon { get; set; }
        public override ItemRecords Items { get; }
        public override Language[] Languages { get; }
        public override BranchRecords Branches { get; }
        public override BranchRecords Masters { get; }
        public override string Name { get; }
        public override DatabaseProperties Properties { get; }
        public override bool Protected { get; set; }
        public override bool ProxiesEnabled { get; set; }
        public override ProxyDataProvider ProxyDataProvider { get; set; }
        public override bool PublishVirtualItems { get; set; }
        public override bool ReadOnly { get; set; }
        public override DatabaseRemoteEvents RemoteEvents { get; }
        public override ResourceItems Resources { get; }
        public override bool SecurityEnabled { get; set; }
        public override Item SitecoreItem { get; }
        public override TemplateRecords Templates { get; }
        public override IWorkflowProvider WorkflowProvider { get; set; }
        public override NotificationProvider NotificationProvider { get; set; }
        protected override DataProviderCollection DataProviders { get; }
    }
}
