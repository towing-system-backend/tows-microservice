using Application.Core;

namespace Tow.Domain
{
    public class TowLicensePlate : IValueObject<TowLicensePlate>
    {
        private readonly string Value;

        public TowLicensePlate(string value)
        {
            if (!LicensePlateRegex.IsLicensePlate(value))
            {
                throw new InvalidTowLicensePlateException();
            }

            Value = value;
        }
        public string GetValue() => Value;

        public bool Equals(TowLicensePlate other) => Value == other.Value;
    }
}
