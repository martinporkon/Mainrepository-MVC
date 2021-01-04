using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Data.Entities;

namespace Identity.Domain.Services
{
    public interface ILocalUserService
    {
        Task<bool> ValidateCredentialsAsync(
            string userName,
            string password);
        Task<IEnumerable<UserClaimData>> GetUserClaimsBySubjectAsync(
            string subject);
        Task<UserData> GetUserByUserNameAsync(
            string userName);
        Task<UserData> GetUserBySubjectAsync(
            string subject);
        void AddUser(
            UserData userToAdd,
            string password);
        Task<bool> IsUserActive(
            string subject);
        Task<bool> ActivateUser(
            string securityCode);
        Task<bool> SaveChangesAsync();
        Task<string> InitiatePasswordResetRequest(
            string email);
        Task<bool> SetPassword(
            string securityCode,
            string password);
    }
}