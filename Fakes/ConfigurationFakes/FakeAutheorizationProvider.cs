using Sitecore.Security.AccessControl;
using Sitecore.Security.Accounts;

namespace Sitecore.Fakes.ConfigurationFakes
{
    public class FakeAutheorizationProvider : AuthorizationProvider
    {
        public override AccessRuleCollection GetAccessRules(ISecurable entity)
        {
            return new AccessRuleCollection();

        }

        public override void SetAccessRules(ISecurable entity, AccessRuleCollection rules)
        {
            
        }

        protected override AccessResult GetAccessCore(ISecurable entity, Account account, AccessRight accessRight)
        {
            return new AccessResult(AccessPermission.Allow, new AccessExplanation(""));
        }
    }
}
