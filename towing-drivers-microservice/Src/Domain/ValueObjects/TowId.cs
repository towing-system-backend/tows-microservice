using Application.Core;

namespace Tow.Domain
{
    public class TowId : IValueObject<TowId>
    {
        private readonly string _value;

        public TowId(string value)
        {
            if (!GuidEx.IsGuid(value))
            {
                throw new InvalidTowIdException();
            }
            _value = value;
        }
        public string GetValue() => _value;
        public bool Equals(TowId other) => _value == other._value;
    }
}
