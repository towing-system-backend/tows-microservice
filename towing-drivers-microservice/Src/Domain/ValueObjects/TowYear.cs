using Application.Core;

namespace Tow.Domain
{
    public class TowYear : IValueObject<TowYear>
    {
        private readonly int Value;

        public TowYear(int value)
        {
            if (value < 1950 || value > DateTime.Now.Year)
            {
                throw new InvalidTowYearException();
            }

            Value = value;
        }
        public int GetValue() => Value;

        public bool Equals(TowYear other) => Value == other.Value;
    }
}
