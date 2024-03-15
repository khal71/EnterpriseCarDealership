using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDBikeBooking;
using EnterpriseCarDealership.service_repository_s.repo;
using EnterpriseCarDealership.service_repository_s.repo.interfaces;
using EnterpriseCarDealership.service_repository_s.Service.Interface;

namespace EnterpriseCarDealership.service_repository_s.Service
{//Jakob
    public class BikeBookingService : IBikeBookingService
    {
         /// <summary>
         /// Injektioner og KOnstruktører
         /// </summary>
        private readonly IBikeBookingRepo _BbookRep;
        private IBikeRepo _bikeRep;
        public BikeBookingService(IBikeBookingRepo BbookRep, IBikeRepo bikeRep)
        {
            _BbookRep = BbookRep;
            _bikeRep = bikeRep;
        }

        /// <summary>
        /// Add Metoden som kalder metoden fra repo for at gemme informationer
        /// </summary>
        /// <param name="Bbooking"></param>
        /// <returns></returns>
        public async Task AddBikebooking(CreateBikeBooking Bbooking)
        {
            BikeBooking newBikeBooking = new BikeBooking()
            {
                StartTime = Bbooking.StartTime,
                EndTime = Bbooking.EndTime,
                KundeId = Bbooking.KundeId,
               
                BikeId = Bbooking.BikeId,


            };
            await _BbookRep.AddBikebooking(newBikeBooking);
        }

        /// <summary>
        /// Delete metoden som kalder metoden fra repo til at fjerne noget.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteBikebooking(int id)
        {
            await _BbookRep.DeleteBikebooking(id);
        }
        /// <summary>
        /// FindeviaId metoden som kalder metoden fra repo til at finde på noget
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public BikeBooking? GetBikebookingById(int id)
        {
            BikeBooking Bbooking = _BbookRep.GetBikebookingById(id);
            if (Bbooking == null)
            {
                throw new KeyNotFoundException();
            }
            return Bbooking;
        }
        /// <summary>
        /// hent listen metoden som kalder for Listen fra repos
        /// </summary>
        /// <returns></returns>
        public List<BikeBooking> GetBikebookingList()
        {
            return _BbookRep.GetBikebookingList();
        }
        /// <summary>
        /// vi brugger den metode for at tjekker hvis der findes overlappning baseret på id'er, start tid og slut tid
        /// </summary>
        /// <param name="Bbooking"></param>
        /// <returns></returns>
        public bool IsOverlapping(BikeBooking Bbooking)
        {
            return GetBikebookingList()
                .Any(a => a.Id != Bbooking.Id && a.StartTime <= Bbooking.EndTime && Bbooking.StartTime <= a.EndTime && a.BikeId == Bbooking.BikeId);
        }

        /// <summary>
        /// vi bruger denne metode for at kalde opdater metoden fra repo
        /// </summary>
        /// <param name="Bbooking"></param>
        /// <returns></returns>
        public async Task UpdateBikebooking(BikeBooking Bbooking)
        {
            if (Bbooking != null)
            {
                await _BbookRep.UpdateBikebooking(Bbooking);
            }

        }
        /// <summary>
        /// Vi brygge den metode for at kalde metoden fra repositories
        /// </summary>
        /// <param name="bookingId"></param>
        /// <param name="bikeId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public double CalculatePayment(int bookingId, int bikeId)
        {
            var bike = _bikeRep.GetBikeById(bikeId);
            var booking = _BbookRep.GetBikebookingById(bookingId);

            if (bike != null && booking != null)
            {
                return _BbookRep.CalculatePayment(bike, booking);
            }
            else
            {
                throw new Exception("Bike or booking not found.");
            }
        }
    }
}

