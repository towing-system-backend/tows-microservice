using Application.Core;

namespace Tow.Domain
{
    public class TowSizeType : IValueObject<TowSizeType>
    {
        private readonly string Value;

        private static readonly string[] ValidSizes = { "Small", "Medium", "Large" };

        public TowSizeType(string value)
        {
            if (!IsValidSize(value))
            {
                throw new InvalidTowSizeTypeException();
            }
            Value = value;
        }

        private static bool IsValidSize(string value)
        {
            return Array.Exists(ValidSizes, size => size.Equals(value, StringComparison.OrdinalIgnoreCase));
        }
        public string GetValue() => Value;

        public bool Equals(TowSizeType other) => Value == other.Value;
    }
}
