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
        private const string DefaultTemplateId = "{ab86861a-6030-46c5-b394-e8f99e8b87db}";
        private const string DefaultTemplateName = "Template";

        public FakeTemplateProvider()
        {
            Template.Builder builder = new Template.Builder(DefaultTemplateName, ID.Parse(DefaultTemplateId), new TemplateCollection());
            AddTemplate(builder.Template);
        }

        public void AddTemplate(FakeItem item)
        {
            Template.Builder builder = new Template.Builder(item.Name, item.ID, new TemplateCollection());
            AddTemplate(builder.Template);
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
            AddTemplate(builder.Template);
        }

        private void AddTemplate(Template template)
        {
            if(!Templates.Contains(template.ID))
            {
                Templates.Add(template);
                IdCollection.Add(ID.Parse(DefaultTemplateId));
            }
        }


        public override IdCollection GetTemplateItemIds(CallContext context)
        {
            return IdCollection;
        }

        public override TemplateCollection GetTemplates(CallContext context)
        {
            return Templates;
        }

        private static TemplateCollection _templates;
        public TemplateCollection Templates
        {
            get { return _templates ?? (_templates = new TemplateCollection()); }
        }
        private static IdCollection _ids;
        public IdCollection IdCollection
        {
            get { return _ids ?? (_ids = new IdCollection()); }
        }
    }
}
