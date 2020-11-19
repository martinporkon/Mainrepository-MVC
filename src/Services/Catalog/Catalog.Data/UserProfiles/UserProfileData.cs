using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Data.UserProfiles
{
    public class UserProfileData
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(250)]
        public string SubscriptionLevel { get; set; }
        [MaxLength(250)]
        public string SelectedParty { get; set; }
    }
}