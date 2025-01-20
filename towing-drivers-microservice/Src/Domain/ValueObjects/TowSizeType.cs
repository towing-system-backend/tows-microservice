using Application.Core;

namespace Tow.Domain
{
    public class TowSizeType : IValueObject<TowSizeType>
    {
        private readonly string _value;

        private static readonly string[] ValidSizes = { "Small", "Medium", "Large" };

        public TowSizeType(string value)
        {
            if (!IsValidSize(value))
            {
                throw new InvalidTowSizeTypeException();
            }
            _value = value;
        }

        private static bool IsValidSize(string value)
        {
            return Array.Exists(ValidSizes, size => size.Equals(value, StringComparison.OrdinalIgnoreCase));
        }
        public string GetValue() => _value;
        public bool Equals(TowSizeType other) => _value == other._value;
    }
}
