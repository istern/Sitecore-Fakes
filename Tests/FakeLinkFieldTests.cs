using FluentAssertions;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Fakes.Fields;
using Xunit;

namespace Sitecore.Fakes.Tests
{
    public class FakeLinkFieldTests
    {

        [Fact]
        public void FieldAddingLinkFieldWithLinkFromOneItemToAnotherTargetItemShouldReturnLinkedToItem()
        {
            var linkedToItem = new FakeItem();
            var fakeLinkField = new FakeInternalLinkField(linkedToItem);
           
            var fieldId = ID.NewID;
            var fieldCollection = new FieldList();
            fieldCollection.Add(fieldId,fakeLinkField.ToString());

            var itemToLinkFrom = new FakeItem(fieldCollection);

            var sitecoreLinkField = (LinkField) itemToLinkFrom.Fields[fieldId];
         
            sitecoreLinkField.TargetItem.ID.ShouldBeEquivalentTo(linkedToItem.ID);
        }


    
        
    }

   
}
