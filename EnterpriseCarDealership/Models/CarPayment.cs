namespace EnterpriseCarDealership.Models
{
    public class CarPayment:Payment
    {//Jakob
        /// <summary>
        /// here har vi vores id fra carbooking som forbindes med payments id og total price,
        /// som er arved fra Payment
        /// </summary>
        public int CarBookingId {get; set;}
        /// <summary>
        /// Konstruktører
        /// </summary>
        /// <param name="id"></param>
        /// <param name="totalPrice"></param>
        /// <param name="carBookingId"></param>
        public CarPayment(int id, double totalPrice, int carBookingId): base(id, totalPrice)
        {
            CarBookingId = carBookingId;
        }
        public CarPayment()
        {
            CarBookingId = -1;
        }
        /// <summary>
        /// To string metode
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            return $"{{{nameof(CarBookingId)}={CarBookingId.ToString()}, {nameof(NextId)}={NextId.ToString()}, {nameof(TotalPrice)}={TotalPrice.ToString()}}}";
        }
    }
}
