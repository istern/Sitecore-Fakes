using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Globalization;

namespace Sitecore.Fakes
{
    public class FakeLanguageFactory 
    {
        public static Language Create(string name) 
        {
            var constructor = typeof(Language).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(string)}, null);
            var instance = (Language)constructor.Invoke(new object[] { name});
            return instance;
        }
    }
}
