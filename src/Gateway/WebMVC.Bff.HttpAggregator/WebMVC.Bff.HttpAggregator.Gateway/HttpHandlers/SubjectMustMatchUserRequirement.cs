using Microsoft.AspNetCore.Authorization;

namespace Catalog.API.HttpHandlers
{   
    public class SubjectMustMatchUserRequirement : IAuthorizationRequirement
    {
        public string Value { get; }
        public SubjectMustMatchUserRequirement(string value)
        {
            Value = value;
        }
    }
}