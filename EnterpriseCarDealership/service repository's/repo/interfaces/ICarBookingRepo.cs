using EnterpriseCarDealership.Models;

namespace EnterpriseCarDealership.service_repository_s.repo.interfaces
{//Jakob
    public interface ICarBookingRepo
    {
        public List<CarBooking> GetCarbookingList();

        public Task AddCarbooking(CarBooking carbooking);


        public Task UpdateCarbooking(CarBooking carbooking);


        public CarBooking GetCarbookingById(int id);

        public Task DeleteCarbooking(int id);

        public double CalculatePayment(Car car, CarBooking booking);
       
    }
}
