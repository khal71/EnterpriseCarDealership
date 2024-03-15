using DocumentFormat.OpenXml.Office2010.Excel;
using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDBooking;
using EnterpriseCarDealership.service_repository_s.repo.interfaces;

namespace EnterpriseCarDealership.service_repository_s.sercive
{//Jakob
    public class CarBookingService : ICarBookingService

    {
        /// <summary>
        /// Injektioner og KOnstruktører
        /// </summary>
        private ICarBookingRepo _CbookRep;
        private ICarRepo _carRep; 
        public CarBookingService(ICarBookingRepo CbookRep, ICarRepo carRep)
        {
            _CbookRep = CbookRep;
            _carRep = carRep;
        }
        /// <summary>
        ///  Add Metoden som kalder metoden fra repo for at gemme informationer
        /// </summary>
        /// <param name="Cbooking"></param>
        /// <returns></returns>
        public async Task AddCarbooking(CreateCarBooking Cbooking)
        {
            CarBooking newCarBooking = new CarBooking()
            {

                StartTime = Cbooking.StartTime,
                EndTime = Cbooking.EndTime,
                KundeId = Cbooking.KundeId,
                CarId = Cbooking.CarId,

            };
            await _CbookRep.AddCarbooking(newCarBooking);
        }
        /// <summary>
        /// Delete metoden som kalder metoden fra repo til at fjerne noget.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task DeleteCarbooking(int id)
        {
            await _CbookRep.DeleteCarbooking(id);
        }
        /// <summary>
        /// FindeviaId metoden som kalder metoden fra repo til at finde på noget
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public CarBooking? GetCarbookingById(int id)
        {
            CarBooking Cbooking = _CbookRep.GetCarbookingById(id);
            if (Cbooking == null)
            {
                throw new KeyNotFoundException();
            }
            return Cbooking;
        }
        /// <summary>
        /// hent listen metoden som kalder for Listen fra repos
        /// </summary>
        /// <returns></returns>
        public List<CarBooking> GetCarbookingList()
        {
            return _CbookRep.GetCarbookingList();
        }
        /// <summary>
        /// vi brugger den metode for at tjekker hvis der findes overlappning baseret på id'er, start tid og slut tid
        /// </summary>
        /// <param name="Cbooking"></param>
        /// <returns></returns>
        public bool IsOverlapping(CarBooking Cbooking)
        {
            return GetCarbookingList()
                .Any(a => a.Id != Cbooking.Id && a.StartTime <= Cbooking.EndTime && Cbooking.StartTime <= a.EndTime && a.CarId == Cbooking.CarId);
        }
        /// <summary>
        /// vi bruger denne metode for at kalde opdater metoden fra repo
        /// </summary>
        /// <param name="Cbooking"></param>
        /// <returns></returns>
        public async Task UpdateCarbooking(CarBooking Cbooking)
        {
            if (Cbooking != null)
            {
                await _CbookRep.UpdateCarbooking(Cbooking);
            }

        }
        /// <summary>
        ///  Vi brygge den metode for at kalde metoden fra repositories
        /// </summary>
        /// <param name="bookingId"></param>
        /// <param name="carId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        public double CalculatePayment(int bookingId, int carId)
        {
            var car = _carRep.GetCarById(carId);
            var booking = _CbookRep.GetCarbookingById(bookingId);

            if (car != null && booking != null)
            {
                return _CbookRep.CalculatePayment(car, booking);
            }
            else
            {
                throw new Exception("Car or booking not found.");
            }
        }



    }
}
