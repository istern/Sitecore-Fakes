using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Collections;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.DataProviders;
using Sitecore.Data.Items;
using Sitecore.Data.Templates;
using Sitecore.Shell.Framework.Commands.Masters;


namespace Sitecore.Fakes
{
    public class FakeTemplateProvider : DataProvider
    {
        public void AddTemplate(Item item, IEnumerable<Item> baseTeamplates)
        {

            Template.Builder builder = new Template.Builder(item.Name, item.ID, new TemplateCollection());
            StringBuilder strnBuilder = new StringBuilder();
            foreach (Item baseTemplate in baseTeamplates)
            {
                strnBuilder.Append(string.Format("{0}|", baseTemplate.ID));
            }
            if (baseTeamplates.Any())
            {
                string idsString = strnBuilder.ToString().TrimEnd('|');
                builder.SetBaseIDs(idsString);
            }
            _templateCollection.Add(builder.Template);
            _idCollection.Add(item.ID);

        }


        public override IdCollection GetTemplateItemIds(CallContext context)
        {
            if (_idCollection == null)
                CreateTemplateProviderData(context.DataManager.Database.Name);
            return _idCollection;
        }




        public override TemplateCollection GetTemplates(CallContext context)
        {
            if (_templateCollection == null)
                CreateTemplateProviderData(context.DataManager.Database.Name);
            return _templateCollection;
        }


        private void CreateTemplateProviderData(string databaseName)
        {
            _templateCollection = new TemplateCollection();
            _idCollection = new IdCollection();
            FakeDatabase fakeDatabase = ((FakeDatabase)Factory.GetDatabase(databaseName));
            IEnumerable<Tuple<Item, IEnumerable<Item>>> templates = fakeDatabase.GetTemplateMappings();
            foreach (Tuple<Item, IEnumerable<Item>> mapping in templates)
            {
                AddTemplate(mapping.Item1, mapping.Item2);
            }

        }

        private IdCollection _idCollection;
        private TemplateCollection _templateCollection;

    }
}
