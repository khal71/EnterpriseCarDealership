using EnterpriseCarDealership.DBContextFolder;
using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s.repo.interfaces;

namespace EnterpriseCarDealership.service_repository_s.repo
{//Jakob
    public class BikeBookingRepo : IBikeBookingRepo
        /// Bike bookking repository's job er at forbinde programmet med vores database. den arver metoder fra interface.
    {
        /// <summary>
        /// vi injekter vores database context and make a new instance of the repo
        /// </summary>
        private readonly DealershipContext _context = new DealershipContext();

        private readonly BikeRepo _BikeRepo = new BikeRepo();

        /// <summary>
        /// Delete metoden bruger metoden GetBikeBooking by Id, og ved bryg af remove command den fjerner
        /// den specifikke Booking fra listen efter det den gemmer ændringerne
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteBikebooking(int id)
        {
            BikeBooking? bikebooking = GetBikebookingById(id);
            _context.BikeBooking.Remove(bikebooking);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Metoden Get Bike Booking by Id bryges metode get booking list of tager den first bike booking som 
        /// har id alime med den id som vi har givet den og returnerer den
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BikeBooking GetBikebookingById(int id)
        {
            BikeBooking Bikebooking = GetBikebookingList().FirstOrDefault(x => x.Id == id);
            return Bikebooking;
        }

        /// <summary>
        /// ved update bike booking vi bruger metoden updat til at sætte de rigtige values på den rigtig sted og gemmer ændringer
        /// </summary>
        /// <param name="Bikebooking"></param>
        /// <returns></returns>

        public async Task UpdateBikebooking( BikeBooking Bikebooking)
        {
            //BikeBooking book = GetBikebookingById(Bikebooking.Id);


            //Bikebooking.StartTime = book.StartTime;
            //Bikebooking.EndTime = book.EndTime;
            //Bikebooking.KundeId = book.KundeId;
            //Bikebooking.BikeId = book.BikeId;

            _context.BikeBooking.Update(Bikebooking);
            await _context.SaveChangesAsync();

        }
        /// <summary>
        /// Den metoder bare henter en liste fra databasen
        /// </summary>
        /// <returns></returns>

        public List<BikeBooking> GetBikebookingList()
        {
            return new List<BikeBooking>(_context.BikeBooking);
        }

        /// <summary>
        /// Ved add vi bruger den inbygget version af add til at sætte og gemme den ny booking.
        /// </summary>
        /// <param name="Bikebooking"></param>
        /// <returns></returns>
        public async Task AddBikebooking(BikeBooking Bikebooking)
        {
            //Bikebooking.StartTime = DateTime.Now.AddDays(1);
            //Bikebooking.EndTime = DateTime.Now.AddDays(2);
            await _context.BikeBooking.AddAsync(Bikebooking);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// den metode prøver at finde hvor meget man skal betale. vi tager en booking ved dens id og en bike ved dens id.
        /// efter vi bryger timespan til at finde hvor mange days der findes hvis vi fjerner end time fra starttime.
        /// efter vi sætter den til en int number of days og sætter +1 til at includerer begge to dage. vi efter kalkulerer vores total payment.
        /// ved at gange de dage med vores pris pr dag og returner vores double. ellers den kaster en exception.
        /// </summary>
        /// <param name="bike"></param>
        /// <param name="booking"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public double CalculatePayment(Bike bike, BikeBooking booking)
        {
            var res = GetBikebookingById(booking.Id);
            var result = _BikeRepo.GetBikeById(bike.NextId);

            if (res != null && result != null)
            {
                TimeSpan duration = booking.EndTime - booking.StartTime;
                int numberOfDays = duration.Days + 1; // Include both the start and end dates

                double totalPayment = (numberOfDays * bike.PrisPrDag);
                return totalPayment;
            }
            else
            {
                // Handle case where car or booking is not found
                throw new Exception("Bike or booking not found.");
            }
        }

    }
}
