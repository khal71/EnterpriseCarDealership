using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDBikeBooking;
using EnterpriseCarDealership.Pages.CRUDBooking;

namespace EnterpriseCarDealership.service_repository_s.Service.Interface
{//Jakob
    public interface IBikeBookingService
    {
        
            public List<BikeBooking> GetBikebookingList();

            public Task AddBikebooking(CreateBikeBooking Bbooking);


            public Task UpdateBikebooking(BikeBooking Bbooking);


            public BikeBooking GetBikebookingById(int id);

            public Task DeleteBikebooking(int id);


        public double CalculatePayment(int carId, int bookingId);
    }
}
