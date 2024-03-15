using EnterpriseCarDealership.Models;

namespace EnterpriseCarDealership.Pages.CRUDCar.Filters
{  //Jakob
    public class FilterCamera : ICarFilter
    {
        private ICarFilter _filter; 
        UdenFilter uden=new UdenFilter();
        public List<Car> Filter()
        {
            uden.Filter().Where((C) => C.Camera);
            return uden.Filter();
        }
        public FilterCamera(ICarFilter filter)
        {
            _filter = filter;
        }
    }
}
