using System;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
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
        public void FakeItemPathShouldContainFullPathParentNameChildName(string parentName, string childName)
        {
               
            var parent = new FakeItem(parentName);
            ((FakeDatabase)Factory.GetDatabase("web")).RootItem = parent;
            var child = new FakeItem(childName);
            parent.AddChild(child);
            var sut = (Item)child;
            sut.Paths.FullPath.ShouldAllBeEquivalentTo("/"+parent.Name+"/"+child.Name);
        }


        [Theory, AutoData]
        public void FakeItemUpdateTemplateIdShouldReturnTemplateId()
        {
            ID tempalteId = ID.NewID;
            
           
            var parent = new FakeItem(ID.NewID, tempalteId);
            
            var sut = (Item)parent;
            
            sut.TemplateID.ShouldBeEquivalentTo(tempalteId);
        }
       

       


  
    }
}
