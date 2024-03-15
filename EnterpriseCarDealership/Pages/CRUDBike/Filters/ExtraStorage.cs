using EnterpriseCarDealership.Models;

namespace EnterpriseCarDealership.Pages.CRUDBike.Filters
{
    public class ExtraStorage : IbikeFilters
    {
        //Jakob
        private IbikeFilters _filters;

        public ExtraStorage(IbikeFilters filters)
        {
            _filters = filters;
        }

        public List<Bike> Filter()
        {
            List<Bike> bikes = _filters.Filter(); // Hent de filtrerede cykler fra det interne filterobjekt
            List<Bike> filteredBikes = bikes.Where(bike => bike.ExtraStorage).ToList(); // Filtrer cykler med ekstra plads

            return filteredBikes;
        }
    }
}
