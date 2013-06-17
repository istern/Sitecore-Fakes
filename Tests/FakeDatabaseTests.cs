using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Xunit;

namespace Sitecore.Fakes.Tests
{
    public class FakeDatabaseTests
    {
        [Fact]
        public void Database_GetItem_FromIdThatExistsInDatabase_ShouldReturnItem()
        {
            FakeDatabase database = (FakeDatabase)Factory.GetDatabase("web");

            Item fakeItem = new FakeItem(new FieldList());
            database.FakeAddItem(fakeItem);
            Item demo = database.GetItem(fakeItem.ID);
            demo.Name.ShouldAllBeEquivalentTo("FakeItem");
        }

       

    }
}
