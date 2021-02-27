namespace IO.Utils
{
    using System.Text.RegularExpressions;
    public static class EmailValidation {
        static public bool Validate(string email)
        {
            Regex rx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

            MatchCollection matches = rx.Matches(email);

            return false;
        }
    }
}
