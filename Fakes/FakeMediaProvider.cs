using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.Fakes.Fields;
using Sitecore.Resources.Media;

namespace Sitecore.Fakes
{
    public class FakeMediaProvider : MediaProvider
    {
        public override string GetMediaUrl(MediaItem item)
        {
            Item sourceItem =  item;
            return String.Format("/~/media/{0}.{1}", sourceItem.Name, sourceItem[MediaStandardFields.ExtensionId]);
        }
    }
}
