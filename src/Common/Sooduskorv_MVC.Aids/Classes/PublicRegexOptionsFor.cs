using System.Text.RegularExpressions;

namespace Sooduskorv_MVC.Aids.Classes
{
    public static class PublicRegexOptionsFor
    {
        private const RegexOptions c = RegexOptions.Compiled;
        private const RegexOptions i = RegexOptions.IgnoreCase;
        private const RegexOptions m = RegexOptions.Multiline;
        private const RegexOptions ci = RegexOptions.CultureInvariant;
        private const RegexOptions e = RegexOptions.ECMAScript;
        private const RegexOptions ec = RegexOptions.ExplicitCapture;
        private const RegexOptions ipw = RegexOptions.IgnorePatternWhitespace;
        private const RegexOptions n = RegexOptions.None;
        private const RegexOptions rtl = RegexOptions.RightToLeft;
        private const RegexOptions s = RegexOptions.Singleline;
        public const RegexOptions AllMembers = c | i| m;
        public const RegexOptions SlowStartup = c |e;
        public const RegexOptions DeclaredMembers = c | i | m | ci | e | ec | ipw | n | rtl | s;
    }
}