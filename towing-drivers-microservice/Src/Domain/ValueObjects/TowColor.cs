using Application.Core;

namespace Tow.Domain
{
    public class TowColor : IValueObject<TowColor>
    {
        private readonly string Value;

        public TowColor(string value)
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidTowColorException();

            }
            Value = value;
        }
        public string GetValue() => Value;

        public bool Equals(TowColor other) => Value == other.Value;
    }
}
