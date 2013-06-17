using FluentAssertions;
using Sitecore.Data;
using Sitecore.Data.Items;
using Xunit;

namespace Sitecore.Fakes.Tests
{
    public class NameItemDemo
    {
        [Fact]
        public void ItemTest()
        {   
            var demo =  new Demo();

            var fieldId = demo.FieldName;
            const string fieldValue = "demoText";
            var stubList = new FieldList {{fieldId, fieldValue}};
            var fakeItem = new FakeItem(stubList);

          
            var item = fakeItem;
            
            demo.GetField(item).ShouldAllBeEquivalentTo(fieldValue);
        }
    }

    public class Demo
    {
        public ID FieldName = ID.NewID;

        public string GetField(Item item)
        {
            return item[FieldName];
        }
    }
}
