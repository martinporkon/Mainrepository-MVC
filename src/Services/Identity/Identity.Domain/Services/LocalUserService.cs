using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Identity.Data.Entities;
using Identity.Infra.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Identity.Domain.Services
{
    public class LocalUserService : ILocalUserService
    {
        private readonly IdentityDbContext _context;

        public LocalUserService(IdentityDbContext context)
        {
            _context = context ??
                       throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> IsUserActive(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject)) return false;

            var user = await GetUserBySubjectAsync(subject);

            if (user is null) return false;

            return user.Active;
        }

        public async Task<bool> ValidateCredentialsAsync(string userName,
            string password)
        {
            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var user = await GetUserByUserNameAsync(userName);

            if (user is null)
            {
                return false;
            }

            if (!user.Active)
            {
                return false;
            }

            return (user.Password == password);
        }

        public async Task<UserData> GetUserByUserNameAsync(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentNullException(nameof(userName));

            return await _context.Users
                 .FirstOrDefaultAsync(u => u.Username == userName);
        }

        public async Task<IEnumerable<UserClaim>> GetUserClaimsBySubjectAsync(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject)) throw new ArgumentNullException(nameof(subject));

            return await _context.UserClaims.Where(u => u.User.Subject == subject).ToListAsync();
        }

        public async Task<UserData> GetUserBySubjectAsync(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject)) throw new ArgumentNullException(nameof(subject));

            return await _context.Users.FirstOrDefaultAsync(u => u.Subject == subject);
        }

        public void AddUser(UserData userToAdd, string password)
        {
            if (userToAdd is null) throw new ArgumentNullException(nameof(userToAdd));
            //TODO
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (_context.Users.Any(u => u.Username == userToAdd.Username))
            {
                throw new Exception("Email must be unique");
            }

            if (_context.Users.Any(u => u.Email == userToAdd.Email))
            {
                throw new Exception("Email must be unique");
            }

            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var securityCodeData = new byte[128];
                randomNumberGenerator.GetBytes(securityCodeData);
                userToAdd.SecurityCode = Convert.ToBase64String(securityCodeData);
            }

            userToAdd.SecurityCodeExpirationDate = DateTime.UtcNow.AddHours(1);

            userToAdd.Password = password;

            _context.Users.AddAsync(userToAdd);
        }

        public async Task<bool> ActivateUser(string securityCode)
        {
            if (string.IsNullOrWhiteSpace(securityCode)) throw new ArgumentNullException(nameof(securityCode));

            var user = await _context.Users.FirstOrDefaultAsync(u =>
                u.SecurityCode == securityCode &&
                u.SecurityCodeExpirationDate >= DateTime.UtcNow);

            if (user is null) return false;

            user.Active = true;
            user.SecurityCode = null;
            return true;
        }

        public async Task<string> InitiatePasswordResetRequest(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));
            email = email.ToLowerInvariant();
            var user = await _context.Users.FirstOrDefaultAsync(u =>
                u.Email == email);

            if (user is null) throw new Exception($"User with email address {email} can't be found.");

            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var securityCodeData = new byte[128];
                randomNumberGenerator.GetBytes(securityCodeData);
                user.SecurityCode = Convert.ToBase64String(securityCodeData);
            }

            user.SecurityCodeExpirationDate = DateTime.UtcNow.AddHours(1);
            return user.SecurityCode;
        }

        public async Task<bool> SaveChangesAsync() => (await _context.SaveChangesAsync() > 0);

        public async Task<bool> SetPassword(string securityCode, string password)
        {
            if (string.IsNullOrWhiteSpace(securityCode)) throw new ArgumentNullException(nameof(securityCode));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException(nameof(password));

            var user = await _context.Users.FirstOrDefaultAsync(u =>
            u.SecurityCode == securityCode &&
            u.SecurityCodeExpirationDate >= DateTime.UtcNow);

            if (user is null) return false;

            user.SecurityCode = null;
            user.Password = password;
            //TODO
            return true;
        }
    }
}