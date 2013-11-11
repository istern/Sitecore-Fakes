using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Collections;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.DataProviders;
using Sitecore.Data.Templates;
using Sitecore.Shell.Framework.Commands.Masters;


namespace Sitecore.Fakes
{
    public class FakeTemplateProvider : DataProvider
    {
        private static TemplateCollection _templates;

        public TemplateCollection Templates
        {
            get
            {
                if (_templates == null)
                    _templates = new TemplateCollection();
                return _templates;
            }
        }

        public IdCollection IdCollection
        {
            get
            {
                if (_ids == null)
                    _ids = new IdCollection();
                return _ids;
            }
        }

        private static IdCollection _ids;
        private const string DefaultTemplateId = "{ab86861a-6030-46c5-b394-e8f99e8b87db}";
        private const string DefaultTemplateName = "Template";

        public FakeTemplateProvider()
        {
            
            Template.Builder builder = new Template.Builder(DefaultTemplateName, ID.Parse(DefaultTemplateId), new TemplateCollection());
            Templates.Add(builder.Template);
            IdCollection.Add(ID.Parse(DefaultTemplateId));

        }

        public void AddTemplate(FakeItem item)
        {
            Template.Builder builder = new Template.Builder(item.Name, item.ID, new TemplateCollection());
            Templates.Add(builder.Template);
            IdCollection.Add(item.ID);

        }

        public void AddTemplate(FakeItem item, IEnumerable<ID> baseTeamplatesIds)
        {

            Template.Builder builder = new Template.Builder(item.Name, item.ID, new TemplateCollection());
            StringBuilder strnBuilder = new StringBuilder();
            foreach (var baseTeamplatesId in baseTeamplatesIds)
            {
                strnBuilder.Append(string.Format("{0}|", baseTeamplatesId));
            }
            string idsString = strnBuilder.ToString().TrimEnd('|');
            builder.SetBaseIDs(idsString);
           Templates.Add(builder.Template);
           IdCollection.Add(item.ID);
        }



        public override IdCollection GetTemplateItemIds(CallContext context)
        {
            return IdCollection;
        }

        public override TemplateCollection GetTemplates(CallContext context)
        {
            return Templates;
        }
    }
}
