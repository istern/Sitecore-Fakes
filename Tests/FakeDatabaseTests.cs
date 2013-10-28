using FluentAssertions;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Templates;
using Xunit;

namespace Sitecore.Fakes.Tests
{
    public class FakeDatabaseTests
    {
        [Fact]
        public void DatabaseGetItemFromIdThatExistsInDatabaseShouldReturnItem()
        {
            FakeDatabase database = (FakeDatabase)Factory.GetDatabase("web");

            var fakeItem = new FakeItem(new FieldList());
            database.FakeAddItem(fakeItem);
            var demo = database.GetItem(fakeItem.ID);
            demo.Name.ShouldAllBeEquivalentTo("FakeItem");
        }

       

    }
}
