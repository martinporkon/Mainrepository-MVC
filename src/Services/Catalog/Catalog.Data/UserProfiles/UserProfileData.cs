using CommonData;
using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Data.UserProfiles
{
    public sealed class UserProfileData:PeriodData
    {
        public string Subject { get; set; }        
        public string SubscriptionLevel { get; set; }
        public string SelectedParty { get; set; }
    }
}