using Application.Core;

namespace Tow.Domain
{
    public class TowLocation : IValueObject<TowLocation>
    {
        private readonly string _value;

        public TowLocation(string value)
        {
            if (value.Length < 3 || value.Length > 40)
            {
                throw new InvalidTowLocationException();
            }
            _value = value;
        }
        public string GetValue() => _value;
        public bool Equals(TowLocation other) => _value == other._value;
    }
}
