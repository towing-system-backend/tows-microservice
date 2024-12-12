using Application.Core;

namespace Tow.Domain
{
    public class TowId : IValueObject<TowId>
    {
        private readonly string Value;
        public TowId(string value)
        {
            if (!GuidEx.IsGuid(value))
            {
                throw new InvalidTowIdException();
            }
            Value = value;
        }
        public string GetValue() => Value;

        public bool Equals(TowId other) => Value == other.Value;
    }
}
