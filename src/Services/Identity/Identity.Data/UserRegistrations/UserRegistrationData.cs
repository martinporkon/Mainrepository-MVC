namespace Identity.Data.UserRegistrations
{
    public sealed class UserRegistrationData
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}