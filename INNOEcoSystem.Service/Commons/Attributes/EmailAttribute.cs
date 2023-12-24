using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace INNOEcoSystem.Service.Commons.Attributes;

public class EmailAttribute : ValidationAttribute
{
    private readonly Regex _emailRegex;

    public EmailAttribute()
    {
        _emailRegex = new Regex(@"^(?!.*--)([a-zA-Z0-9_.+-]+)@gmail\.com$", RegexOptions.Compiled);
    }

    public override bool IsValid(object value)
    {
        if (value is string email)
        {
            if (_emailRegex.IsMatch(email))
            {
                try
                {
                    var mail = new MailAddress(email);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        return false;
    }
}
