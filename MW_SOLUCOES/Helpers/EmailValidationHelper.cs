namespace MW_SOLUCOES.Helpers;
using System.Text.RegularExpressions;

public static class EmailValidationHelper
{
    private const string emailRegexPattern = "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$";
    static Regex regex = new Regex(emailRegexPattern);
    static public bool IsValidEmail(string email)
    {
        if (regex.IsMatch(email))
        {
            return true;
        }
        return false;
    }
}