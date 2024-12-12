using Application.Core;

namespace Tow.Domain
{
    public class TowStatus : IValueObject<TowStatus>
    {
        private readonly string Value;

        private static readonly string[] ValidStatuses = { "Active", "Inactive" };

        public TowStatus(string value)
        {
            if (!IsValidStatus(value))
            {
                throw new InvalidTowStatusException();
            }
            Value = value;
        }

        private static bool IsValidStatus(string value)
        {
            return Array.Exists(ValidStatuses, status => status.Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        public string GetValue() => Value;
     
        public bool Equals(TowStatus other) => Value == other.Value;
    }
}
