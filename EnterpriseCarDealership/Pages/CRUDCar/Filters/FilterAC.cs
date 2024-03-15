using EnterpriseCarDealership.Models;

namespace EnterpriseCarDealership.Pages.CRUDCar.Filters
{  //Jakob
    public class FilterAC:ICarFilter
    {
        private ICarFilter _filter;
        UdenFilter uden= new UdenFilter();  

        public List<Car> Filter()
        {
            uden.Filter().Where((a) => a.AC); 
            return uden.Filter(); 
       
        }
        public FilterAC(ICarFilter carFilter)
        {
            _filter = carFilter;  
        }
    }
}
