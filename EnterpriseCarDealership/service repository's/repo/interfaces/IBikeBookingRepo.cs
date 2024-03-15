using EnterpriseCarDealership.Models;

namespace EnterpriseCarDealership.service_repository_s.repo.interfaces
{//Jakob
    public interface IBikeBookingRepo
    {
        public List<BikeBooking> GetBikebookingList();

        public Task AddBikebooking(BikeBooking booking);


        public Task UpdateBikebooking(BikeBooking booking);


        public BikeBooking GetBikebookingById(int id);

        public Task DeleteBikebooking(int id);
        public double CalculatePayment(Bike bike, BikeBooking booking);
    }
}
