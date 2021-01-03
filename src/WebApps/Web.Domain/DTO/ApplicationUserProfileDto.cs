using System;

namespace Web.Domain.DTO
{
    public class ApplicationUserProfileDto
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string SubscriptionLevel { get; set; }
    }
}