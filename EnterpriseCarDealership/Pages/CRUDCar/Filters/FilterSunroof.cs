using EnterpriseCarDealership.Models;

namespace EnterpriseCarDealership.Pages.CRUDCar.Filters
{  //Jakob
    public class FilterSunroof:ICarFilter
    {
        private ICarFilter _carFilter;
        UdenFilter uden= new UdenFilter();
        public List<Car> Filter()
        {
            return null;
        }
    }
}
