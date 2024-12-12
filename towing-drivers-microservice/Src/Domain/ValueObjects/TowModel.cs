using Application.Core;

namespace Tow.Domain
{
    public class TowModel : IValueObject<TowModel>
    {
        private readonly string Value;
        public TowModel(string value)
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidTowModelException();
            }
            Value = value;
        }
        public string GetValue() => Value;
        
        public bool Equals(TowModel other) => Value == other.Value;
    }
}
