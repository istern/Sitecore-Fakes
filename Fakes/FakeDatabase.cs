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
        private static ConcurrentBag<Item> _items = new ConcurrentBag<Item>();

        private static ConcurrentBag<Tuple<Item, List<Item>>> _childMappings =
            new ConcurrentBag<Tuple<Item, List<Item>>>();

        private static ConcurrentBag<Tuple<Item, IEnumerable<Item>>> _templates =
            new ConcurrentBag<Tuple<Item, IEnumerable<Item>>>();

        private Item _rootItem;
        private readonly string _name;

        internal void AddDataProvider(DataProvider provider)
        {

        }

        public FakeDatabase(string name = "web")
        {
            _name = name;
            //  _items = 
            // _templates 

        }

        public virtual void FakeAddItem(Item item)
        {
            _items.Add(item);
            Tuple<Item, List<Item>> childMapping =
                new Tuple<Item, List<Item>>(item, new List<Item>());
            _childMappings.Add(childMapping);
        }


        public virtual void FakeAddChildItem(Item parent, Item item)
        {
            var children = _childMappings.FirstOrDefault(x => x.Item1.ID == parent.ID);
            if (children != null)
                children.Item2.Add(item);
        }

        public virtual IEnumerable<Item> FakeGetChildren(Item parent)
        {
            var mapping = _childMappings.FirstOrDefault(x => x.Item1.ID == parent.ID);
            if (mapping == null)
                return new List<Item>();
            return mapping.Item2;
        }



        public virtual void FakeAddTemplate(Item item, List<Item> baseTemplates)
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



        public Item RootItem
        {
            get
            {
                if (_rootItem == null)
                    return new FakeItem("sitecore");
                return _rootItem;
            }
            set { _rootItem = value; }
        }

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
            return new LanguageCollection();
        }

        public override Item GetRootItem()
        {
            return RootItem;
        }

        public override Item GetRootItem(Language language)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
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

        public override AliasResolver Aliases
        {
            get { return null; }
        }

        public override List<string> ArchiveNames
        {
            get { return null; }
        }

        public override DataArchives Archives
        {
            get { return null; }
        }

        public override DatabaseCaches Caches
        {
            get { return null; }
        }

        public override string ConnectionStringName { get; set; }

        public override DataManager DataManager
        {
            get { return null; }
        }

        public override DatabaseEngines Engines
        {
            get { return null; }
        }

        public override bool HasContentItem
        {
            get { return false; }
        }

        public override string Icon { get; set; }

        public override ItemRecords Items
        {
            get { return null; }
        }

        public override Language[] Languages
        {
            get { return null; }
        }

        public override BranchRecords Branches
        {
            get { return null; }
        }

        [Obsolete]
        public override BranchRecords Masters
        {
            get { return null; }
        }

        public override string Name
        {
            get { return null; }
        }

        public override DatabaseProperties Properties
        {
            get { return null; }
        }

        public override bool Protected { get; set; }
        public override bool ProxiesEnabled { get; set; }
        public override ProxyDataProvider ProxyDataProvider { get; set; }
        public override bool PublishVirtualItems { get; set; }
        public override bool ReadOnly { get; set; }

        public override DatabaseRemoteEvents RemoteEvents
        {
            get { return null; }
        }

        public override ResourceItems Resources
        {
            get { return null; }
        }

        public override bool SecurityEnabled { get; set; }

        public override Item SitecoreItem
        {
            get { return null; }
        }

        public override TemplateRecords Templates
        {
            get { return null; }
        }

        public override IWorkflowProvider WorkflowProvider { get; set; }
        public override NotificationProvider NotificationProvider { get; set; }

        protected override DataProviderCollection DataProviders
        {
            get { return new DataProviderCollection(); }
        }
    }
}
