namespace Sooduskorv_MVC.Aids.Extensions
{
    public static class SystemString
    {
        public static bool StartsWithLetter(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            return char.IsLetter(s[0]);
        }
    }
}