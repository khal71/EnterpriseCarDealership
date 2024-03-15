using EnterpriseCarDealership.Models;

namespace EnterpriseCarDealership.Pages.CRUDCar.Filters
{  //Jakob
    public class FilterScreen : ICarFilter
    {
        private ICarFilter _filter;
        UdenFilter uden=new UdenFilter();   
        public List<Car> Filter()
        {
            uden.Filter().Where((s) => s.Screen); 
            return uden.Filter();
        }
        public FilterScreen(ICarFilter carFilter)
        {
                _filter=carFilter;  
        }
    }
}
