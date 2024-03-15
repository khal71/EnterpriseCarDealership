using EnterpriseCarDealership.Models;

namespace EnterpriseCarDealership.Pages.CRUDCar.Filters
{  //Jakob
    public class FilterDVD : ICarFilter
    {
        private ICarFilter _filter;
        UdenFilter uden=new UdenFilter();
        public List<Car> Filter()
        {
            uden.Filter().Where((D) => D.DVD);
            return uden.Filter();
        }
        public FilterDVD(ICarFilter filter)
        {
            _filter = filter;
        }
    }
}
