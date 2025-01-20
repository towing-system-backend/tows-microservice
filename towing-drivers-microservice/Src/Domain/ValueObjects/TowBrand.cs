using Application.Core;

namespace Tow.Domain
{
    public class TowBrand : IValueObject<TowBrand>
    {
        private readonly string _value;

        public TowBrand(string value)
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidTowBrandException();

            }
            _value = value;
        }
        public string GetValue() => _value;
        public bool Equals(TowBrand other) => _value == other._value;
    }
}
