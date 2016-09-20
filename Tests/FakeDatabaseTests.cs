using FluentAssertions;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Templates;
using Sitecore.Globalization;
using Xunit;

namespace Sitecore.Fakes.Tests
{
    public class FakeDatabaseTests
    {
        [Fact]
        public void DatabaseGetItemFromIdThatExistsInDatabaseShouldReturnItem()
        {
            FakeDatabase database = new FakeDatabase("web");

            var fakeItem = new FakeItem();
            database.FakeAddItem(fakeItem);
            var demo = database.GetItem(fakeItem.ID);
            demo.Name.ShouldAllBeEquivalentTo("FakeItem");
        }

        [Fact]
        public void DatabaseGetItemFromIdAndLanguage_DatabaseShouldReturnItem()
        {
            FakeDatabase database = new FakeDatabase("web");
            var language = Language.Parse("en-Us");
            var itemId = ID.NewID;
            var templateId = ID.NewID;
            var fakeItem = new FakeItem(itemId, templateId,language) ;
           
            database.FakeAddItem(fakeItem);
            var demo = database.GetItem(fakeItem.ID,language);
            demo.ID.ShouldBeEquivalentTo(itemId);
        }


        [Fact]
        public void DatabaseGetItemFromIdAndOitherLanguage_DatabaseShouldReturnNoItem()
        {
            FakeDatabase database = new FakeDatabase("web");
            var language = Language.Parse("en-Us");
            var itemId = ID.NewID;
            var templateId = ID.NewID;
            var fakeItem = new FakeItem(itemId, templateId, language);
            var otherLanguage = Language.Parse("en-Gb");
            database.FakeAddItem(fakeItem);



            var demo = database.GetItem(fakeItem.ID, otherLanguage);
            demo.Should().BeNull();
        }

        [Fact]
        public void DatabaseRootItem_ShouldAlwaysHaveOneItem()
        {
            FakeDatabase database = new FakeDatabase("web");

            var rootItem = database.RootItem;
            rootItem.ID.Should().NotBeSameAs(ID.Null);
        }

        [Fact]
        public void DatabaseGetRootItem_ShouldAlwaysHaveOneItem()
        {
            FakeDatabase database = new FakeDatabase("web");

            var rootItem = database.GetRootItem();
            rootItem.ID.Should().NotBeSameAs(ID.Null);
        }

    }
}
