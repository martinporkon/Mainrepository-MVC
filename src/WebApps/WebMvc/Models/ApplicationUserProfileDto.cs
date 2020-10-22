using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace SooduskorvWebMVC.Models
{
    public class ApplicationUserProfileDto
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string SubscriptionLevel { get; set; }
    }
}