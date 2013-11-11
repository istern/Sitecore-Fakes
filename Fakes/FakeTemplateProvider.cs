using System.Collections.Generic;
using System.Text;
using Sitecore.Collections;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.DataProviders;
using Sitecore.Data.Templates;


namespace Sitecore.Fakes
{
    public class FakeTemplateProvider : DataProvider
    {
        private static TemplateCollection _templates;
        private const string DefaultTemplateId = "{ab86861a-6030-46c5-b394-e8f99e8b87db}";
        private const string DefaultTemplateName = "Template";

        public FakeTemplateProvider()
        {
            _templates = new TemplateCollection();
            Template.Builder builder = new Template.Builder(DefaultTemplateName, ID.Parse(DefaultTemplateId), new TemplateCollection());
            _templates.Add(builder.Template);

        }

        public void AddTemplate(FakeItem item)
        {
            Template.Builder builder = new Template.Builder(item.Name, item.ID, new TemplateCollection());
            _templates.Add(builder.Template);
            ((FakeDatabase)Factory.GetDatabase(item.Database.Name)).FakeAddItem(item);
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
            _templates.Add(builder.Template);
        }


        public override IdCollection GetTemplateItemIds(CallContext context)
        {
            IdCollection ids = new IdCollection();
            foreach (var t in _templates)
            {
                ids.Add(t.ID);
            }
            return ids;
        }

        public override TemplateCollection GetTemplates(CallContext context)
        {
            return _templates;
        }
    }
}
