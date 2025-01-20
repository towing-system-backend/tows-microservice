using Application.Core;

namespace Tow.Domain
{
    public class TowLicensePlate : IValueObject<TowLicensePlate>
    {
        private readonly string _value;

        public TowLicensePlate(string value)
        {
            if (!LicensePlateRegex.IsLicensePlate(value))
            {
                throw new InvalidTowLicensePlateException();
            }

            _value = value;
        }
        public string GetValue() => _value;
        public bool Equals(TowLicensePlate other) => _value == other._value;
    }
}
