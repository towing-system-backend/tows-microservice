using Application.Core;

namespace Tow.Domain
{
    public class Tow : AggregateRoot<TowId>
    {
        private new TowId Id;
        private TowBrand Brand;
        private TowModel Model;
        private TowColor Color;
        private TowLicensePlate LicensePlate;
        private TowYear Year;
        private TowSizeType SizeType;
        private TowStatus Status;

        public Tow(TowId towId) : base(towId)
        {
            Id = towId;
        }
        public override void ValidateState()
        {
            if (
                Id == null ||
                Brand == null || 
                Model == null || 
                Color == null || 
                LicensePlate == null ||
                Year == null ||
                SizeType == null ||
                Status == null)
            {
                throw new InvalidTowException();
            }
        }
        public TowId GetTowId() => Id;
        public TowBrand GetTowBrand() => Brand;
        public TowModel GetTowModel() => Model;
        public TowColor GetTowColor() => Color;
        public TowLicensePlate GetTowLicensePlate() => LicensePlate;
        public TowYear GetTowYear() => Year;
        public TowSizeType GetTowSizeType() => SizeType;
        public TowStatus GetTowStatus() => Status;

        public static Tow Create(TowId towId, TowBrand brand, TowModel model, TowColor color, TowLicensePlate licensePlate, TowYear year, TowSizeType sizeType, TowStatus status, bool fromPersistence = false)
        {
            
            if (fromPersistence)
            {
                return new Tow(towId)
                {
                    Id = towId,
                    Brand = brand,
                    Model = model,
                    Color = color,
                    LicensePlate = licensePlate,
                    Year = year,
                    SizeType = sizeType,
                    Status = status
                };
            }
            var tow = new Tow(towId);
            tow.Apply(TowCreated.CreateEvent(towId, brand, model, color, licensePlate, year, sizeType, status));

            return tow;
        }

        public void UpdateTowBrand(TowBrand brand)
        {
            Apply(TowBrandUpdated.CreateEvent(Id, brand));
        }

        public void UpdateTowModel(TowModel model)
        {
            Apply(TowModelUpdated.CreateEvent(Id, model));
        }

        public void UpdateTowColor(TowColor color)
        {
            Apply(TowColorUpdated.CreateEvent(Id, color));
        }

        public void UpdateTowLicensePlate(TowLicensePlate licensePlate)
        {
            Apply(TowLicensePlateUpdated.CreateEvent(Id, licensePlate));
        }

        public void UpdateTowYear(TowYear year)
        {
            Apply(TowYearUpdated.CreateEvent(Id, year));
        }

        public void UpdateTowSizeType(TowSizeType sizeType)
        {
            Apply(TowSizeTypeUpdate.CreateEvent(Id, sizeType));
        }

        public void UpdateTowStatus(TowStatus status)
        {
            Apply(TowStatusUpdated.CreateEvent(Id, status));
        }

        private void OnTowCreatedEvent(TowCreated context)
        {
            Id = new TowId(context.Id);
            Brand = new TowBrand(context.Brand);
            Model = new TowModel(context.Model);
            Color = new TowColor(context.Color);
            LicensePlate = new TowLicensePlate(context.LicensePlate);
            Year = new TowYear(context.Year);
            SizeType = new TowSizeType(context.SizeType);
            Status = new TowStatus(context.Status);
        }

        private void OnTowBrandUpdatedEvent(TowBrandUpdated context)
        {
            Brand = new TowBrand(context.Brand);
        }

        private void OnTowModelUpdatedEvent(TowModelUpdated context)
        {
            Model = new TowModel(context.Model);
        }

        private void OnTowColorUpdatedEvent(TowColorUpdated context)
        {
            Color = new TowColor(context.Color);
        }

        private void OnTowLicensePlateUpdatedEvent(TowLicensePlateUpdated context)
        {
            LicensePlate = new TowLicensePlate(context.LicensePlate);
        }

        private void OnTowYearUpdatedEvent(TowYearUpdated context)
        {
            Year = new TowYear(context.Year);
        }

        private void OnTowSizeTypeUpdateEvent(TowSizeTypeUpdate context)
        {
            SizeType = new TowSizeType(context.SizeType);
        }

        private void OnTowStatusUpdatedEvent(TowStatusUpdated context)
        {
            Status = new TowStatus(context.Status);
        }

    }
}
