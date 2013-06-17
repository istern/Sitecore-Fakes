using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Items;
using Xunit;
using Xunit.Extensions;

namespace Sitecore.Fakes.Tests
{
    public class FakeItemProviderTests
    {

        [Fact]
        public void FakeItem_AddMultipleChildren_ChildListShouldHaveAllChildren()
        {
            Item child = new FakeItem(new FieldList());
            FakeItem fake = new FakeItem(new FieldList());
            fake.AddChild(child);
            fake.AddChild(child);
            fake.AddChild(child);
            fake.AddChild(child);
            fake.AddChild(child);

            fake.Children.Should().HaveCount(5);
        }

        [Fact]
        public void FakeItem_AddChildToChildren_ShouldReturnChild()
        {
            Item child = new FakeItem(new FieldList());
            FakeItem fake = new FakeItem(new FieldList());
            fake.AddChild(child);

            fake.Children.First().ShouldBeEquivalentTo(child);
        }

        [Fact]
        public void FakeItem_AddChildToChildren_ChildShouldHaveParent()
        {
            Item child = new FakeItem(new FieldList());
            FakeItem fake = new FakeItem(new FieldList());
            fake.AddChild(child);

            fake.Children.First().Parent.ShouldBeEquivalentTo(fake);
           
        }

        [Fact]
        public void FakeItem_AddChildToChildren_ChildShouldHaveParentWithId()
        {
            Item child = new FakeItem(new FieldList());
            FakeItem fake = new FakeItem(new FieldList());
            fake.AddChild(child);

            fake.Children.First().ParentID.ShouldBeEquivalentTo(fake.ID);

        }
       

      
    }

}
