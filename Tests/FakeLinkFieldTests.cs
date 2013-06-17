using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Sitecore.Collections;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Fakes.Fields;
using Sitecore.Resources.Media;
using Xunit;

namespace Sitecore.Fakes.Tests
{
    public class FakeLinkFieldTests
    {

        [Fact]
        public void Field_AddingLinkFieldWithLinkFromOneItemToAnother_TargetItemShouldReturnLinkedToItem()
        {
            Item linkedToItem = new FakeItem();
            FakeInternalLinkField fakeLinkField = new FakeInternalLinkField(linkedToItem);
           
            ID fieldId = ID.NewID;
            FieldList fieldCollection = new FieldList();
            fieldCollection.Add(fieldId,fakeLinkField.ToString());

            Item itemToLinkFrom = new FakeItem(fieldCollection);

            LinkField sitecoreLinkField = (LinkField) itemToLinkFrom.Fields[fieldId];
         
            sitecoreLinkField.TargetItem.ID.ShouldBeEquivalentTo(linkedToItem.ID);
        }


    
        
    }

   
}
