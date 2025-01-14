using Application.Core;

namespace Tow.Domain
{
    public class TowModel : IValueObject<TowModel>
    {
        private readonly string _value;

        public TowModel(string value)
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidTowModelException();
            }
            _value = value;
        }
        public string GetValue() => _value;
        public bool Equals(TowModel other) => _value == other._value;
    }
}
