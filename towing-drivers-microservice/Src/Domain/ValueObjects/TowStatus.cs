using Application.Core;

namespace Tow.Domain
{
    public class TowStatus : IValueObject<TowStatus>
    {
        private readonly string _value;

        private static readonly string[] ValidStatuses = { "Active", "Inactive" };

        public TowStatus(string value)
        {
            if (!IsValidStatus(value))
            {
                throw new InvalidTowStatusException();
            }
            _value = value;
        }

        private static bool IsValidStatus(string value)
        {
            return Array.Exists(ValidStatuses, status => status.Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        public string GetValue() => _value;
        public bool Equals(TowStatus other) => _value == other._value;
    }
}
