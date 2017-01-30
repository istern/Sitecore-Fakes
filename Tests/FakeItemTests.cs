using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit;
using Sitecore.Collections;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Globalization;
using Xunit;
using Xunit.Extensions;

namespace Sitecore.Fakes.Tests
{
    public class FakeItemTests
    {

        [Fact]
        public void NewFakeItemDefaultNameShouldBeFakeItem()
        {
            var fake = new FakeItem();
            fake.Name.Should().Be("FakeItem");
        }


        [Theory,AutoData]
        public void NewFakeItemOverrideNameShouldReturnNameOtherThanDefaultNam(string itemName)
        {
            var fake = new FakeItem(itemName);
            fake.Name.Should().Be(itemName);  
        }

        [Theory, AutoData]
        public void NewFakeItemOverrideIdShouldReturnId(Guid itemGuid)
        {
            var fieldId = new ID(itemGuid);
            var fake = new FakeItem(fieldId);
            fake.ID.Should().Be(fieldId);
        }

        [Theory, AutoData]
        public void DefaultConstructorTest(string databaseName,string itemName)
        {
            var fake = new FakeItem(databaseName,itemName);
            fake.Name.Should().Be(itemName);
        }

        [Theory, AutoData]
        public void DefaultConstructorTestWithParameter(string databaseName, ID itemId, string itemName)
        {
           
            var fake = new FakeItem(databaseName,itemId, itemName);
            fake.Name.Should().Be(itemName);
        }

        [Theory, AutoData]
        public void DefaultConstructorTestWithoutFieldListParameter(ID itemId, ID templateID, string itemName, string databaseName)
        {
            
            var fake = new FakeItem(itemId,templateID, itemName, databaseName);
            fake.Name.Should().Be(itemName);
        }

        [Theory, AutoData]
        public void FakeItemAddFieldShouldReturnField(FieldList fieldList,string fieldValue)
        {
            var fieldId = ID.NewID;
            fieldList.Add(fieldId,fieldValue);
            var fake = new FakeItem(fieldList);
            fake[fieldId].ShouldBeEquivalentTo(fieldValue);
        }



        [Theory, AutoData]
        public void FakeItemAddMultipleFieldShouldReturnField(FieldList fieldList, string fieldValue)
        {
            var fieldIdOne = ID.NewID;
            var fieldIdTwo = ID.NewID;
            fieldList.Add(fieldIdOne, fieldValue);
            fieldList.Add(fieldIdTwo, fieldValue);
            var fake = new FakeItem(fieldList);
   
            fake.Fields.Should().HaveCount(2);
        }

       

        [Theory, AutoData]
        public void FakeItemGetFieldFromIdShoudlReturnFieldValue(string fieldValue, FieldList fieldList)
        {
            var fieldId = ID.NewID;

            fieldList.Add(fieldId, fieldValue);
            var fake = new FakeItem(fieldList);

            fake[fieldId].ShouldAllBeEquivalentTo(fieldValue);
        }


      


        [Theory, AutoData]
        public void FakeItemUpdateTemplateIdShouldReturnTemplateId()
        {
            ID tempalteId = ID.NewID;
            var parent = new FakeItem(ID.NewID, tempalteId);
      
            var sut = (Item)parent;
            
            sut.TemplateID.ShouldBeEquivalentTo(tempalteId);
        }


        [Theory, AutoData]
        public void FakeItem_CreateItemWithLanguagNoFieldList_ShouldGiveValidItem(ID itemId, ID templateID)
        {

            var language = FakeLanguageFactory.Create("en-US");
            var parent = new FakeItem(itemId, templateID, language);

            var sut = (Item)parent;

            sut.Language.Equals(language);
        }


        [Theory, AutoData]
        public void FakeItem_CreateItemWithLanguagFieldList_ShouldGiveValidItem(ID itemId, ID templateID)
        {

            var language = FakeLanguageFactory.Create("en-US");
            var parent = new FakeItem(new FieldList(),itemId, templateID, language);

            var sut = (Item)parent;

            sut.Language.Equals(language);
            
        }


        [Theory, AutoData]
        public void FakeItem_AddChildItem_ShouldGiveValidItem( TemplateID templateID)
        {
      
            var parent = new FakeItem();
            var childName = "childName";

           var child = parent.Add(childName, templateID);

            parent.Database.GetItem(child.ID).Should().NotBeNull();
        }


       [ Theory, AutoData]
        public void GetItemPath_FullPath_ShouldContainFullPathToItem(TemplateID templateID)
        {

            var parent = new FakeItem();
            var childName = "childName";

            var child = parent.Add(childName, templateID);

            
        //   var str = child.Paths.FullPath;
        }

        [Theory, AutoData]
        public void GetChildren_ForItemsWithNotChildren_ChildListShouldBeEmpty(TemplateID templateID)
        {

            FakeItem parent = new FakeItem("demo");
            parent.Add("test", new TemplateID(ID.NewID));
            var child =  parent.Children;


           var children = parent.GetChildren();

           children.FirstOrDefault().Name.ShouldBeEquivalentTo("test");
            children.FirstOrDefault().Parent.ID.ShouldBeEquivalentTo(parent.ID);
            //   var str = child.Paths.FullPath;
        }


    }
}
