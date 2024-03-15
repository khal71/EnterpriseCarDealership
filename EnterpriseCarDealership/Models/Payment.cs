namespace EnterpriseCarDealership.Models
{
    //khaled
    public abstract class Payment
    {/// <summary>
    /// her sætter vi attributter for Payment som skal arves til CarPayment og Bike Payment
    /// </summary>
        public int NextId { get; set; }
     
        public double TotalPrice { get; set; }
        /// <summary>
        /// Konstruktører
        /// </summary>
        /// <param name="id"></param>
        /// <param name="totalPrice"></param>
        public Payment(int id,  double totalPrice)
        {
            id = NextId++;
            
            TotalPrice = totalPrice;
        }
        public Payment()
        {
            NextId = -1;
           
            TotalPrice = -1;
        }
        /// <summary>
        /// ToString metode
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{{nameof(NextId)}={NextId.ToString()},  {nameof(TotalPrice)}={TotalPrice.ToString()}}}";
        }
    }
}
