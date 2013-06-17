using FluentAssertions;
using Sitecore.Resources.Media;
using Xunit;

namespace Sitecore.Fakes.Tests
{
    public class FakeMediaProviderTests
    {
        [Fact]
        public void GetMediaUrlForAnItemShouldReturnNameplusExtension()
        {

            var mediaItem = new FakeMediaItem("hello", extension: "png");


            MediaManager.GetMediaUrl(mediaItem).ShouldAllBeEquivalentTo("/~/media/hello.png");



        }
    }
}
