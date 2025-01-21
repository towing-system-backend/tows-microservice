using Application.Core;

namespace Tow.Domain
{
    public class Tow : AggregateRoot<TowId>
    {
        private new TowId _id;
        private TowBrand _towBrand;
        private TowModel _towModel;
        private TowColor _towColor;
        private TowLicensePlate _towLicensePlate;
        private TowLocation _towLocation;
        private TowYear _towYear;
        private TowSizeType _towSizeType;
        private TowStatus _towStatus;

        public Tow(TowId towId) : base(towId)
        {
            _id = towId;
        }
        public override void ValidateState()
        {
            if (
                Id == null ||
                _towBrand == null ||
                _towModel == null ||
                _towColor == null ||
                _towLicensePlate == null ||
                _towLocation == null ||
                _towYear == null ||
                _towSizeType == null ||
                _towStatus == null)
            {
                throw new InvalidTowException();
            }
        }
        public TowId GetTowId() => _id;

        public TowBrand GetTowBrand() => _towBrand;

        public TowModel GetTowModel() => _towModel;

        public TowColor GetTowColor() => _towColor;

        public TowLicensePlate GetTowLicensePlate() => _towLicensePlate;

        public TowLocation GetTowLocation() => _towLocation;

        public TowYear GetTowYear() => _towYear;

        public TowSizeType GetTowSizeType() => _towSizeType;

        public TowStatus GetTowStatus() => _towStatus;

        public static Tow Create(
            TowId towId, 
            TowBrand brand, 
            TowModel model, 
            TowColor color, 
            TowLicensePlate licensePlate, 
            TowLocation location,
            TowYear year, 
            TowSizeType sizeType, 
            TowStatus status, 
            bool fromPersistence = false)
        {
            
            if (fromPersistence)
            {
                return new Tow(towId)
                {
                    _id = towId,
                    _towBrand = brand,
                    _towModel = model,
                    _towColor = color,
                    _towLicensePlate = licensePlate,
                    _towLocation = location,
                    _towYear = year,
                    _towSizeType = sizeType,
                    _towStatus = status
                };
            }
            var tow = new Tow(towId);
            tow.Apply(TowCreated.CreateEvent(
                towId,
                brand, 
                model, 
                color, 
                licensePlate, 
                location,
                year, 
                sizeType, 
                status
               )
            );

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

        public void UpdateTowLocation(TowLocation location)
        {
            Apply(TowLocationUpdated.CreateEvent(Id, location));
        }

        public void UpdateTowYear(TowYear year)
        {
            Apply(TowYearUpdated.CreateEvent(Id, year));
        }

        public void UpdateTowSizeType(TowSizeType sizeType)
        {
            Apply(TowSizeTypeUpdated.CreateEvent(Id, sizeType));
        }

        public void UpdateTowStatus(TowStatus status)
        {
            Apply(TowStatusUpdated.CreateEvent(Id, status));
        }

        private void OnTowCreatedEvent(TowCreated context)
        {
            _id = new TowId(context.Id);
            _towBrand = new TowBrand(context.Brand);
            _towModel = new TowModel(context.Model);
            _towColor = new TowColor(context.Color);
            _towLicensePlate = new TowLicensePlate(context.LicensePlate);
            _towLocation = new TowLocation(context.Location);
            _towYear = new TowYear(context.Year);
            _towSizeType = new TowSizeType(context.SizeType);
            _towStatus = new TowStatus(context.Status);
        }

        private void OnTowBrandUpdatedEvent(TowBrandUpdated context)
        {
            _towBrand = new TowBrand(context.Brand);
        }

        private void OnTowModelUpdatedEvent(TowModelUpdated context)
        {
            _towModel = new TowModel(context.Model);
        }

        private void OnTowColorUpdatedEvent(TowColorUpdated context)
        {
            _towColor = new TowColor(context.Color);
        }

        private void OnTowLicensePlateUpdatedEvent(TowLicensePlateUpdated context)
        {
            _towLicensePlate = new TowLicensePlate(context.LicensePlate);
        }

        private void OnTowLocationUpdatedEvent(TowLocationUpdated context)
        {
            _towLocation = new TowLocation(context.Location);
        }

        private void OnTowYearUpdatedEvent(TowYearUpdated context)
        {
            _towYear = new TowYear(context.Year);
        }

        private void OnTowSizeTypeUpdatedEvent(TowSizeTypeUpdated context)
        {
            _towSizeType = new TowSizeType(context.SizeType);
        }

        private void OnTowStatusUpdatedEvent(TowStatusUpdated context)
        {
            _towStatus = new TowStatus(context.Status);
        }
    }
}
