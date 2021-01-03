using Catalog.Data.UserProfiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sooduskorv_MVC.CommonTests.OverallTests;
using Sooduskorv_MVC.Data.CommonData;

namespace Catalog.Tests.Data.UserProfiles
{
    [TestClass]
    public class UserProfileDataTests : SealedClassTests<UserProfileData, PeriodData>
    {
        [TestMethod]
        public void SubjectTest() =>
            isNullableProperty(() => obj.Subject, x => obj.Subject = x);
        [TestMethod]
        public void SubscriptionLevelTest() =>
            isNullableProperty(() => obj.SubscriptionLevel, x => obj.SubscriptionLevel = x);
        [TestMethod]
        public void SelectedPartyTest() =>
            isNullableProperty(() => obj.SelectedParty, x => obj.SelectedParty = x);
    }
}
