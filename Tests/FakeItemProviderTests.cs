using System.Linq;
using FluentAssertions;
using Sitecore.Data;
using Xunit;

namespace Sitecore.Fakes.Tests
{
    public class FakeItemProviderTests
    {

        [Fact]
        public void FakeItemAddMultipleChildrenChildListShouldHaveAllChildren()
        {
            var child = new FakeItem(new FieldList());
            var fake = new FakeItem(new FieldList());
            fake.AddChild(child);
            fake.AddChild(child);
            fake.AddChild(child);
            fake.AddChild(child);
            fake.AddChild(child);

            fake.Children.Should().HaveCount(5);
        }

        [Fact]
        public void FakeItemAddChildToChildrenShouldReturnChild()
        {
            var child = new FakeItem(new FieldList());
            var fake = new FakeItem(new FieldList());
            fake.AddChild(child);

            fake.Children.First().ShouldBeEquivalentTo(child);
        }

        [Fact]
        public void FakeItemAddChildToChildrenChildShouldHaveParent()
        {
            var child = new FakeItem(new FieldList());
            var fake = new FakeItem(new FieldList());
            fake.AddChild(child);

            fake.Children.First().Parent.ShouldBeEquivalentTo(fake);
           
        }

        [Fact]
        public void FakeItemAddChildToChildrenChildShouldHaveParentWithId()
        {
            var child = new FakeItem(new FieldList());
            var fake = new FakeItem(new FieldList());
            fake.AddChild(child);

            fake.Children.First().ParentID.ShouldBeEquivalentTo(fake.ID);

        }
       

      
    }

}
