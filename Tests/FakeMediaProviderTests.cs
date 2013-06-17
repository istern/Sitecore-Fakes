using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using Xunit;

namespace Sitecore.Fakes.Tests
{
    public class FakeMediaProviderTests
    {
        [Fact]
        public void GetMediaUrl_ForAnItem_ShouldReturnNameplusExtension()
        {

            MediaItem mediaItem = new FakeMediaItem("hello", extension: "png");


            MediaManager.GetMediaUrl(mediaItem).ShouldAllBeEquivalentTo("/~/media/hello.png");



        }
    }
}
