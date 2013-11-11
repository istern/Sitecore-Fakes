using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
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
        [Theory]
        public void CreateTemplate()
        {
            Database masteDatabase = Factory.GetDatabase("master");

            ID templateId = ID.NewID;

            FakeItem item = new FakeItem("master", templateId, "newTemplate");
          

            ((FakeDatabase)masteDatabase).FakeAddTemplate(item, new List<Item>());

            TemplateItem[] t = masteDatabase.Templates.GetTemplates(Language.Current);

            t.Should().HaveCount(1);
            
        }


        [Theory]
        public void CreateTemplateWithBaseTemplates_TemplateItem_ShouldhaveAllBaseTemplates()
        {
           Database masteDatabase = Factory.GetDatabase("master");

            ID parentTemplateId = ID.NewID;

             ID baseTemplateId = ID.NewID;
             ID baseTemplateId2 = ID.NewID;
             ID baseTemplateId3 = ID.NewID;
            List<ID>baseIds = new List<ID>(){baseTemplateId,baseTemplateId2,baseTemplateId3};

            FakeItem bItemitem1 = new FakeItem("master", baseTemplateId, "b1");
            FakeItem bItemitem2 = new FakeItem("master", baseTemplateId2, "b2");
            FakeItem bItemitem3 = new FakeItem("master", baseTemplateId3, "b3");
            List<Item>baseTemplates = new List<Item>();
            baseTemplates.Add(bItemitem1);
            baseTemplates.Add(bItemitem2);
            baseTemplates.Add(bItemitem3);

            FakeItem item = new FakeItem("master", parentTemplateId, "newTemplate");


            ((FakeDatabase)masteDatabase).FakeAddTemplate(bItemitem1, new List<Item>());

            ((FakeDatabase)masteDatabase).FakeAddTemplate(bItemitem2, new List<Item>());

            ((FakeDatabase)masteDatabase).FakeAddTemplate(bItemitem3, new List<Item>());

            ((FakeDatabase)masteDatabase).FakeAddTemplate(item,baseTemplates);

            TemplateItem[] t = masteDatabase.Templates.GetTemplates(Language.Parse("en"));
            TemplateItem templateItem =  masteDatabase.GetTemplate("newTemplate");
            templateItem.BaseTemplates.Should().HaveCount(3);
        }

        [Theory]
        public void CreateItemFromTemplate_ItemTemplateShouldHaveAllBaseTemplates()
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
            List<Item> baseTemplates = new List<Item>();
            baseTemplates.Add(bItemitem1);
            baseTemplates.Add(bItemitem2);
            baseTemplates.Add(bItemitem3);

            FakeItem item = new FakeItem("master", parentTemplateId, "newTemplate");



            ((FakeDatabase)masteDatabase).FakeAddTemplate(bItemitem1, new List<Item>());

            ((FakeDatabase)masteDatabase).FakeAddTemplate(bItemitem2, new List<Item>());

            ((FakeDatabase)masteDatabase).FakeAddTemplate(bItemitem3, new List<Item>());

            ((FakeDatabase)masteDatabase).FakeAddTemplate(item, baseTemplates);



            ID fakeContentId = ID.NewID;
            FakeItem contentItemtem = new FakeItem(fakeContentId, item.ID, "content", "master");
            ((FakeDatabase)masteDatabase).FakeAddItem(contentItemtem);

            Item i = masteDatabase.GetItem(fakeContentId);

            i.Template.BaseTemplates.Should().HaveCount(3);
        }
    }
}
