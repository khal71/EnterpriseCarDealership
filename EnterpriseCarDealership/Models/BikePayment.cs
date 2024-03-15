namespace EnterpriseCarDealership.Models
{
    public class BikePayment:Payment
    {//Jakob
        /// <summary>
        /// here har vi vores id fra bikebooking som forbindes med payments id og total price,
        /// som er arved fra Payment
        /// </summary>
        public int BikeBookingId { get; set; }
        /// <summary>
        /// Konstroktører
        /// </summary>
        /// <param name="id"></param>
        /// <param name="totalPrice"></param>
        /// <param name="bikeBookingId"></param>
        public BikePayment(int id, double totalPrice, int bikeBookingId) : base(id, totalPrice)
        {
            BikeBookingId = bikeBookingId;
        }
        public BikePayment()
        {
            BikeBookingId = -1;
        }
        /// <summary>
        /// To string Metode
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{{nameof(BikeBookingId)}={BikeBookingId.ToString()}, {nameof(NextId)}={NextId.ToString()}, {nameof(TotalPrice)}={TotalPrice.ToString()}}}";
        }
    }
}
