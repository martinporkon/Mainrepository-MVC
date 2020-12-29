using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Identity.Data.Entities;

namespace Identity.Facade.Users
{
    public class UserView
    {
        [Key]
        public Guid Id { get; set; }// TODO configuration

        [MaxLength(200)]
        [Required]
        public string Subject { get; set; }

        [MaxLength(200)]
        public string Username { get; set; }

        // TODO missing properties !!!

        [MaxLength(200)]
        public string Password { get; set; }// TODO passwords into another table?

        [Required]
        public bool Active { get; set; }

        [MaxLength(200)]
        [EmailAddress(ErrorMessage = "Consider using a valid email address")]
        public string Email { get; set; }

        [ConcurrencyCheck]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString(); // TODO mustritesse ning diagrammidele. Praegu ainukene koht kus seda realiseerime.

        public ICollection<UserClaimData> Claims { get; set; } = new List<UserClaimData>();

        [MaxLength(200)]
        public string SecurityCode { get; set; }

        public DateTime SecurityCodeExpirationDate { get; set; }

        // TODO missing properties !!!
    }
}
