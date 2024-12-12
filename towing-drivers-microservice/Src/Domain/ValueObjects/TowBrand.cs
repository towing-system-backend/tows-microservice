using Application.Core;

namespace Tow.Domain
{
    public class TowBrand : IValueObject<TowBrand>
    {
        private readonly string Value;

        public TowBrand(string value)
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidTowBrandException();

            }
            Value = value;
        }
        
        public string GetValue() => Value;

        public bool Equals(TowBrand other) => Value == other.Value;
    }
}
