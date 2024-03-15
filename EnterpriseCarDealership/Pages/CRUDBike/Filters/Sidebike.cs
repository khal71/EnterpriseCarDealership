using EnterpriseCarDealership.Models;

namespace EnterpriseCarDealership.Pages.CRUDBike.Filters
{
    public class Sidebike : IbikeFilters
    {
        //Jakob
        private IbikeFilters _filters;

        public Sidebike(IbikeFilters filters)
        {
            _filters = filters;
        }

        public List<Bike> Filter()
        {
            List<Bike> bikes = _filters.Filter(); // Hent de filtrerede cykler fra det interne filterobjekt
            List<Bike> filteredBikes = bikes.Where(bike => bike.Sidebike).ToList(); // Filtrer cykler med ekstra cykelplads

            return filteredBikes;
        }
    }
}
