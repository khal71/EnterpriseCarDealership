using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.Service.Interface;
///Jakob
namespace EnterpriseCarDealership.Models
{

    /// <summary>
    /// Her ligger attributter for vores Bike booking
    /// </summary>

    public class BikeBooking
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? KundeId { get; set; }
        public int BikeId { get; set; }
        public Bike? Bike { get; set; }
        public Kunde? Kunde { get; set; }

        private readonly IBikeBookingService BookingService;

        /// <summary>
        /// Konstroktører
        /// </summary>
        public BikeBooking()

        {

        }







        public BikeBooking(int ID, DateTime StartTime, DateTime EndTime, int KundeId,  int BikeId)

        {
            if (ID == default) throw new ArgumentOutOfRangeException(nameof(ID), "Booking Id is required");
            if (StartTime == default) throw new ArgumentOutOfRangeException(nameof(StartTime), "StartTime date is required");
            if (EndTime == default) throw new ArgumentOutOfRangeException(nameof(EndTime), "EndTime date is required");
            if (KundeId == default) throw new ArgumentOutOfRangeException(nameof(KundeId), "Customer id is required");
            if (BikeId == default) throw new ArgumentOutOfRangeException(nameof(BikeId), "Bike id  is required");
            if (StartTime >= EndTime) throw new Exception($"EndTime has to come later than StartTime (StartTime, EndTime): {StartTime}, {EndTime}");
            this.Id = ID;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.KundeId = KundeId;
            this.BikeId = BikeId;


        }



        public BikeBooking(int _id, DateTime _startTime, DateTime _endTime, int _kundeID, int _carId, int _bikeId, IBikeBookingService _services)

        {
            if (_id == default) throw new ArgumentOutOfRangeException(nameof(_id), "Booking Id is required");
            if (_startTime == default) throw new ArgumentOutOfRangeException(nameof(_startTime), "Start time date is required");
            if (_endTime == default) throw new ArgumentOutOfRangeException(nameof(_endTime), "End Time date is required");
            if (_kundeID == default) throw new ArgumentOutOfRangeException(nameof(_kundeID), "Customer id is required");
            if (_bikeId == default) throw new ArgumentOutOfRangeException(nameof(_bikeId), "Bike id  is required");
            if (_startTime >= _endTime) throw new Exception($"End time has to come later than Start Time (StartTime, End): {_startTime}, {_endTime}");
            Id = _id;
            StartTime = _startTime;
            EndTime = _endTime;
            KundeId = _kundeID;
            BikeId = _bikeId;
            BookingService = _services;


        }
        /// <summary>
        /// To string metode
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(StartTime)}={StartTime.ToString()}, {nameof(EndTime)}={EndTime.ToString()}, {nameof(KundeId)}={KundeId.ToString()}, {nameof(BikeId)}={BikeId.ToString()}, {nameof(Bike)}={Bike}, {nameof(Kunde)}={Kunde}}}";
        }
    } }
