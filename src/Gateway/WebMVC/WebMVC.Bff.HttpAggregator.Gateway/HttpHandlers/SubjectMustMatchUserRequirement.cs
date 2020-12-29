using Microsoft.AspNetCore.Authorization;

namespace WebMVC.Bff.HttpAggregator.Gateway.HttpHandlers
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