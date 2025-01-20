using System.Text.RegularExpressions;

namespace Application.Core
{
    public class LicensePlateRegex
    {
        public static bool IsLicensePlate(string licensePlate)
        {
            return Regex.IsMatch(licensePlate, @"^[A-Z]{3}[0-9]{3}$");
        }
    }
}
