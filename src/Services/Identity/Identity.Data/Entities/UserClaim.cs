using System;
using System.ComponentModel.DataAnnotations;

namespace Identity.Data.Entities
{
    public class UserClaim : IConcurrency
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Type { get; set; }

        [MaxLength(250)]
        [Required]
        public string Value { get; set; }

        [ConcurrencyCheck]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public Guid UserId { get; set; }

        public UserData User { get; set; }
    }
}