using System.Collections.Generic;
using Sitecore.Security.Domains;
using Sitecore.SecurityModel;

namespace Sitecore.Fakes.ConfigurationFakes
{
    public class FakeDomainProvider : DomainProvider
    {
        public override void AddDomain(string domainName, bool locallyManaged)
        {
            
        }

        public override Domain GetDomain(string name)
        {
           return new Domain(name);
        }

        public override IEnumerable<Domain> GetDomains()
        {
            return new List<Domain>();
        }

        public override void RemoveDomain(string domainName)
        {
            
        }
    }
}
