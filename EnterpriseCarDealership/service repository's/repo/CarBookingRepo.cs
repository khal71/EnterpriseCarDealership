using EnterpriseCarDealership.DBContextFolder;
using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s.repo.interfaces;

namespace EnterpriseCarDealership.service_repository_s.repo
{//Jakob
    public class CarBookingRepo : ICarBookingRepo
    {
        /// <summary>
        /// vi injekter vores database context and make a new instance of the repo
        /// </summary>
        private DealershipContext _Carbookdb = new DealershipContext();


        private readonly CarRepo _CarRepo = new CarRepo(); 

        /// <summary>
        /// den metode skaber og gemmer en booking i listen
        /// </summary>
        /// <param name="Carbooking"></param>
        /// <returns></returns>
        public async Task Addcarbooking(CarBooking Carbooking)
        {
            //Carbooking.StartTime = DateTime.Now.AddDays(1);
            //Carbooking.EndTime = DateTime.Now.AddDays(2);
            _Carbookdb.CarBooking.Add(Carbooking);
            await _Carbookdb.SaveChangesAsync();

        }
        /// <summary>
        /// den metode finder og fjerner en bestemt booking og gemmer ændringer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task DeleteCarbooking(int id)
        {
            CarBooking? Carbooking = GetCarbookingById(id);
            _Carbookdb.CarBooking.Remove(Carbooking);
            await _Carbookdb.SaveChangesAsync();
        }
        /// <summary>
        /// den metode finder en bestemt Car Booking ved hjælp id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CarBooking GetCarbookingById(int id)
        {
           return _Carbookdb.CarBooking.FirstOrDefault(x => x.Id == id);
           
        }

        /// <summary>
        /// den metode opdaterer attributter af en bestemt booking og gemmer ændringer
        /// </summary>
        /// <param name="Carbooking"></param>
        /// <returns></returns>

        public async Task UpdateCarbooking(CarBooking Carbooking)
        {
            _Carbookdb.CarBooking.Update(Carbooking);
            await _Carbookdb.SaveChangesAsync();

        }
        /// <summary>
        /// den metode returner en liste
        /// </summary>
        /// <returns></returns>

        public List<CarBooking> GetCarbookingList()
        {
            return new List<CarBooking>(_Carbookdb.CarBooking);
        }
        /// <summary>
        /// den metode skaber og gemmer en ny car booking
        /// </summary>
        /// <param name="carbooking"></param>
        /// <returns></returns>
        public async Task AddCarbooking(CarBooking carbooking)
        {
            _Carbookdb.CarBooking.Add(carbooking);
            await _Carbookdb.SaveChangesAsync();
        }
        /// <summary>
        /// den metode prøver at finde hvor meget man skal betale. vi tager en booking ved dens id og en car ved dens id.
        /// efter vi bryger timespan til at finde hvor mange days der findes hvis vi fjerner end time fra starttime.
        /// efter vi sætter den til en int number of days og sætter +1 til at includerer begge to dage. vi efter kalkulerer vores total payment.
        /// ved at gange de dage med vores pris pr dag og returner vores double. ellers den kaster en exception.
        /// </summary>

        public double CalculatePayment(Car car, CarBooking booking)
        {
            var res = GetCarbookingById(booking.Id);
            var result = _CarRepo.GetCarById(car.NextId);

            if (res != null && result != null)
            {
                TimeSpan duration = booking.EndTime - booking.StartTime;
                int numberOfDays = duration.Days + 1; // Include both the start and end dates

                double totalPayment = (numberOfDays * car.PrisPrDag);
                return totalPayment;
            }
            else
            {
                // Handle case where car or booking is not found
                throw new Exception("Car or booking not found.");
            }
        }
    }

}

