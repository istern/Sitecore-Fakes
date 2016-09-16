using System;
using System.Reflection;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
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
        public void FakeItemUpdateTemplateIdShouldReturnTemplateId()
        {
            ID tempalteId = ID.NewID;
            var parent = new FakeItem(ID.NewID, tempalteId);
      
            var sut = (Item)parent;
            
            sut.TemplateID.ShouldBeEquivalentTo(tempalteId);
        }



        [Fact]
        public void FakesAssignFakeChildrenWithAdd()
        {
            var child = new FakeItem(new ID("{11111111-1111-1111-1111-111111111115}"), "testSub1");

            var parent = new FakeItem(new ID("{030C5633-85B5-492E-BDF1-E24789A3B49B}"), "MyTest");
            parent.FakeChildren.Add(child);
       
            parent.Children.Count.Should().Be(1);
            parent.Children[0].Should().Be(child);

        }

  
    }
}
