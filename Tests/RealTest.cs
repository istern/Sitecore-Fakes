using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Demo demo =  new Demo();

            ID fieldId = demo.FieldName;
            string fieldValue = "demoText";
            FieldList stubList = new FieldList();
            stubList.Add(fieldId,fieldValue);
            FakeItem fakeItem = new FakeItem(stubList);

          
            Item item = fakeItem;
            
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
