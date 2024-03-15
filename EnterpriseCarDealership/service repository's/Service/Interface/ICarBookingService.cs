using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDBooking;

namespace EnterpriseCarDealership.service_repository_s
{//Jakob
    public interface ICarBookingService
    {
        public List<CarBooking> GetCarbookingList();

        public Task AddCarbooking(CreateCarBooking Cbooking);


        public Task UpdateCarbooking(CarBooking Cbooking);


        public CarBooking GetCarbookingById(int id);

        public Task DeleteCarbooking(int id);

        public double CalculatePayment(int carId, int bookingId); 


    }
}
