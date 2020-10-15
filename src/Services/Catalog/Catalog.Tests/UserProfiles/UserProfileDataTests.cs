using Catalog.Data.UserProfiles;
using CommonData;
using CommonTests.BaseTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Tests.UserProfiles
{
    [TestClass] public class UserProfileDataTests:SealedClassTests<UserProfileData,PeriodData>
    {
        [TestMethod]
        public void SubjectTest() =>
            isNullableProperty(() => obj.Subject, x => obj.Subject = x);
        [TestMethod]
        public void SubscriptionLevelTest() =>
            isNullableProperty(() => obj.SubscriptionLevel, x => obj.SubscriptionLevel= x);
        [TestMethod]
        public void SelectedPartyTest() =>
            isNullableProperty(() => obj.SelectedParty, x => obj.SelectedParty = x);
    }
}
