using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;
using Xunit;

namespace Sitecore.Fakes.Tests
{
    public class SecurityAndEditTests
    {
        [Fact]
        public void CreateItemTest()
        {

            FakeDatabase database = (FakeDatabase)Factory.GetDatabase("web");

            var homeItem = new FakeItem(new FieldList());
            database.FakeAddItem(homeItem);
            var home = database.GetItem(homeItem.ID);

            TemplateID templateId = new TemplateID(ID.NewID);
            Item subNode;
            using (new SecurityDisabler())
            {
                subNode = home.Add("SubNode", templateId);

            }
            subNode.Name.ShouldAllBeEquivalentTo("SubNode");
        }

        [Fact]
        public void CreateAndEditItemTest()
        {
            //setup database so we have a rood node to add our content to
           
            var homeFakeItem = new FakeItem();
            Item homeItem = (Item) homeFakeItem;
            
            

            //Define some Field IDs
            TemplateID templateId = new TemplateID(ID.NewID);
            Item subNode;
            ID fieldIdA = ID.NewID;
            ID fieldIdB = ID.NewID;

            using (new SecurityDisabler())
            {
                subNode = homeItem.Add("SubNode", templateId);
                using (new EditContext(subNode))
                {
                    subNode[fieldIdA] = "test";
                    subNode[fieldIdB] = "testBBB";
                }

            }
            subNode[fieldIdA].ShouldAllBeEquivalentTo("test");
            subNode[fieldIdB].ShouldAllBeEquivalentTo("testBBB"); ;
        }

        [Fact]
        public void CreateAndEditItemTestMultilesubItems()
        {

            FakeDatabase database = (FakeDatabase)Factory.GetDatabase("master");


            var homeItem = new FakeItem("master","homeItem");
            var home = (Item)homeItem;

            TemplateID templateId = new TemplateID(ID.NewID);
            Item subNode;

            ID fieldIdA = ID.NewID;
            ID fieldIdB = ID.NewID;
            Item subsubnode;
            ID subsubNodeId;
            using (new SecurityDisabler())
            {
                subNode = home.Add("SubNode", templateId);
                using (new EditContext(subNode))
                {
                    subNode[fieldIdA] = "test";
                    subNode[fieldIdB] = "testBBB";
                }
               subsubnode  = subNode.Add("SubSubNode", templateId);
                subsubNodeId = subsubnode.ID;
            }

            //THE master database should contain the subsubnode
            Item n = database.GetItem(subsubNodeId);

            //And the subsubnode should have inserted content
            n.Name.ShouldAllBeEquivalentTo("SubSubNode");
        }
    }
}
