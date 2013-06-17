        using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture.Xunit;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
        using Sitecore.Fakes.Fields;
        using Sitecore.Resources.Media;

namespace Sitecore.Fakes.Tests
{
    [TestFixture]
    class NunitTestsFakeItemTests
    {


   

        [Test]
        public void NewFakeItem_DefaultName_ShouldBeFakeItem()
        {
            Item fake = new FakeItem();
            fake.Name.Should().Be("FakeItem");
        }


        [Test]
        public void NewFakeItem_OverrideName_ShouldReturnNameOtherThanDefaultNam()
        {
            string itemName = "dummy";
            Item fake = new FakeItem(itemName);
            fake.Name.Should().Be(itemName);  
        }

        [Test]
        public void NewFakeItem_OverrideID_ShouldReturnID()
        {
            ID fieldId = ID.NewID;
            Item fake = new FakeItem(fieldId);
            fake.ID.Should().Be(fieldId);
        }

        [Test]
        public void FakeItem_AddField_ShouldReturnField()
        {

            FieldList fieldList = new FieldList();
            string fieldValue = "value";
            ID fieldId = ID.NewID;
            fieldList.Add(fieldId,fieldValue);
            Item fake = new FakeItem(fieldList);
            fake[fieldId].ShouldBeEquivalentTo(fieldValue);
        }



        [Test]
        public void FakeItem_AddMultipleField_ShouldReturnField()
        {
            FieldList fieldList = new FieldList();
            string fieldValue = "value";
            ID fieldIdOne = ID.NewID;
            ID fieldIdTwo = ID.NewID;
            fieldList.Add(fieldIdOne, fieldValue);
            fieldList.Add(fieldIdTwo, fieldValue);
            Item fake = new FakeItem(fieldList);
   
            fake.Fields.Should().HaveCount(2);
        }


        [Test]
        public void FakeItem_GetFieldFromID_ShoudlReturnFieldValue()
        {
            FieldList fieldList = new FieldList();
            string fieldValue = "value";
            ID fieldId = ID.NewID;

            fieldList.Add(fieldId, fieldValue);
            FakeItem fake = new FakeItem(fieldList);

            fake[fieldId].ShouldAllBeEquivalentTo(fieldValue);
        }


     

  
    }
}



