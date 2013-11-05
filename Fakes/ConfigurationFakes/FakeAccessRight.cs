using Sitecore.Security.AccessControl;

namespace Sitecore.Fakes.ConfigurationFakes
{
    public class FakeAccessRight : AccessRightProvider
    {
        public override AccessRight GetAccessRight(string accessRightName)
        {
            return new AccessRight(accessRightName);
        }
    }
}
