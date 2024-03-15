using EnterpriseCarDealership.Models;

namespace EnterpriseCarDealership.Pages.CRUDBike.Filters
{
    public class LeatherSaddle : IbikeFilters
    {
        //Jakob
        private IbikeFilters _filters;

         public LeatherSaddle(IbikeFilters filters)
         {
             _filters = filters;
         }

         public List<Bike> Filter()
         {
          List<Bike> bikes = _filters.Filter(); // Hent de filtrerede cykler fra det interne filterobjekt
          List<Bike> filteredBikes = bikes.Where(bike => bike.LeatherSddle).ToList(); // Filtrer cykler med lædersadel

          return filteredBikes;
         }
    }
}
