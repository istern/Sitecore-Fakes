using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Templates;
using Sitecore.Globalization;
using Xunit;

namespace Sitecore.Fakes.Tests
{
   public class TemplateTests
    {
        [Fact]
        public void CreateTemplate()
        {

            Database masteDatabase = Factory.GetDatabase("master");

            ID parentTemplateId = ID.NewID;

            FakeItem item = new FakeItem("master", parentTemplateId, "newTemplate");
            FakeItem parent = new FakeItem("master", TemplateIDs.Template, "parent");

            ((FakeDatabase)masteDatabase).FakeAddItem(parent);


            FakeTemplateProvider templateProvider = new FakeTemplateProvider();
            templateProvider.AddTemplate(item);


            TemplateItem[] t = masteDatabase.Templates.GetTemplates(Language.Current);

            t.Should().NotBeNull();



        }


        [Fact]
        public void CreateTemplateWithBaseTemplates()
        {
            Database masteDatabase = Factory.GetDatabase("master");
            ID parentTemplateId = ID.NewID;

            ID baseTemplateId = ID.NewID;
            ID baseTemplateId2 = ID.NewID;
            ID baseTemplateId3 = ID.NewID;
            List<ID> baseIds = new List<ID>() { baseTemplateId, baseTemplateId2, baseTemplateId3 };

            FakeItem bItemitem1 = new FakeItem("master", baseTemplateId, "b1");
            FakeItem bItemitem2 = new FakeItem("master", baseTemplateId2, "b2");
            FakeItem bItemitem3 = new FakeItem("master", baseTemplateId3, "b3");


            FakeItem item = new FakeItem("master", parentTemplateId, "newTemplate");
            FakeItem parent = new FakeItem("master", TemplateIDs.Template, "parent");

            ((FakeDatabase)masteDatabase).FakeAddItem(parent);
            
            FakeTemplateProvider templateProvider = new FakeTemplateProvider();
            templateProvider.AddTemplate(item, baseIds);
            templateProvider.AddTemplate(bItemitem1, baseIds);
            templateProvider.AddTemplate(bItemitem2, baseIds);
            templateProvider.AddTemplate(bItemitem3, baseIds);

            TemplateItem templateItem = masteDatabase.GetTemplate("newTemplate");
           templateItem.BaseTemplates.Should().HaveCount(3);
        }

        [Fact]
        public void CreateTemplateAndItem_ItemShouldHaveAllBaseTemplates()
        {

            Database masteDatabase = Factory.GetDatabase("master");
            ID parentTemplateId = ID.NewID;
            ID baseTemplateId = ID.NewID;
            ID baseTemplateId2 = ID.NewID;
            ID baseTemplateId3 = ID.NewID;
            List<ID> baseIds = new List<ID>() { baseTemplateId, baseTemplateId2, baseTemplateId3 };
            FakeItem bItemitem1 = new FakeItem("master", baseTemplateId, "b1");
            FakeItem bItemitem2 = new FakeItem("master", baseTemplateId2, "b2");
            FakeItem bItemitem3 = new FakeItem("master", baseTemplateId3, "b3");

            FakeItem templateItem = new FakeItem("master", parentTemplateId, "newTemplate");
            FakeItem parent = new FakeItem("master", TemplateIDs.Template, "parent");

            ((FakeDatabase)masteDatabase).FakeAddItem(parent);
            ID fakeContentId = ID.NewID;
            FakeItem contentItemtem = new FakeItem(fakeContentId, templateItem.ID, "content", "master");
            ((FakeDatabase)masteDatabase).FakeAddItem(contentItemtem);

            ((FakeDatabase)masteDatabase).RootItem = parent;

            FakeTemplateProvider templateProvider = new FakeTemplateProvider();
            templateProvider.AddTemplate(templateItem, baseIds);
            templateProvider.AddTemplate(bItemitem1, baseIds);
            templateProvider.AddTemplate(bItemitem2, baseIds);
            templateProvider.AddTemplate(bItemitem3, baseIds);
            Item fetchedItem = masteDatabase.GetItem(fakeContentId);
           

           fetchedItem.Template.BaseTemplates.Should().HaveCount(3);
         }
    }
}
