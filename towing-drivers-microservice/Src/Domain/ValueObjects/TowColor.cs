using Application.Core;

namespace Tow.Domain
{
    public class TowColor : IValueObject<TowColor>
    {
        private readonly string _value;

        public TowColor(string value)
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidTowColorException();

            }
            _value = value;
        }
        public string GetValue() => _value;
        public bool Equals(TowColor other) => _value == other._value;
    }
}
