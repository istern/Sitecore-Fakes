using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Xunit;
using Xunit.Extensions;

namespace Sitecore.Fakes.Tests
{
    public class FakeItemTests
    {

        [Fact]
        public void NewFakeItem_DefaultName_ShouldBeFakeItem()
        {
            Item fake = new FakeItem();
            fake.Name.Should().Be("FakeItem");
        }


        [Theory,AutoData]
        public void NewFakeItem_OverrideName_ShouldReturnNameOtherThanDefaultNam(string itemName)
        {
            Item fake = new FakeItem(itemName);
            fake.Name.Should().Be(itemName);  
        }

        [Theory, AutoData]
        public void NewFakeItem_OverrideID_ShouldReturnID(Guid itemGuid)
        {
            ID fieldId = new ID(itemGuid);
            Item fake = new FakeItem(fieldId);
            fake.ID.Should().Be(fieldId);
        }

        [Theory, AutoData]
        public void FakeItem_AddField_ShouldReturnField(FieldList fieldList,string fieldValue)
        {
            ID fieldId = ID.NewID;
            fieldList.Add(fieldId,fieldValue);
            Item fake = new FakeItem(fieldList);
            fake[fieldId].ShouldBeEquivalentTo(fieldValue);
        }



        [Theory, AutoData]
        public void FakeItem_AddMultipleField_ShouldReturnField(FieldList fieldList, string fieldValue)
        {
            ID fieldIdOne = ID.NewID;
            ID fieldIdTwo = ID.NewID;
            fieldList.Add(fieldIdOne, fieldValue);
            fieldList.Add(fieldIdTwo, fieldValue);
            Item fake = new FakeItem(fieldList);
   
            fake.Fields.Should().HaveCount(2);
        }


        [Theory, AutoData]
        public void FakeItem_GetFieldFromID_ShoudlReturnFieldValue(string fieldValue, FieldList fieldList)
        {
            ID fieldId = ID.NewID;

            fieldList.Add(fieldId, fieldValue);
            FakeItem fake = new FakeItem(fieldList);

            fake[fieldId].ShouldAllBeEquivalentTo(fieldValue);
        }
       

       


  
    }
}
