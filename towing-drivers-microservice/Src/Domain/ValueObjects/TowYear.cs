using Application.Core;

namespace Tow.Domain
{
    public class TowYear : IValueObject<TowYear>
    {
        private readonly int _value;

        public TowYear(int value)
        {
            if (value < 1950 || value > DateTime.Now.Year)
            {
                throw new InvalidTowYearException();
            }

            _value = value;
        }
        public int GetValue() => _value;
        public bool Equals(TowYear other) => _value == other._value;
    }
}
