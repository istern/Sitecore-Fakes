using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Pipelines.GetFieldValue;

namespace Sitecore.Fakes
{
    public class GetFakeFieldValue
    {
        public void Process(GetFieldValueArgs args)
        {
         
           
           
            args.Value = args.Value; ;
            args.AbortPipeline();
        }
    }
}
