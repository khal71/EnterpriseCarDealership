namespace EnterpriseCarDealership.Models
{
    //Jakob
    public class Bike :Vehicle
    {
       /// <summary>
       /// here har vi tre ekstra attributter, rester er arved gennem Vehicle
       /// </summary>
        public bool Sidebike { get; set; }
        public bool LeatherSddle { get; set; }
        public bool ExtraStorage { get; set; }
        /// <summary>
        /// konstruktører
        /// </summary>
        public Bike()
        {

        }
        public Bike(int Id, string Brand, MotorType Type, double PrisPrDag, int Year, int Km, bool sidebike, bool leatherSddle, bool extraStorage) : base(Id, Brand, Type, PrisPrDag, Year, Km)
        {
            Sidebike = sidebike;
            LeatherSddle = leatherSddle;
            ExtraStorage = extraStorage;
        }
        /// <summary>
        /// To string metode
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{{nameof(Sidebike)}={Sidebike.ToString()}, {nameof(LeatherSddle)}={LeatherSddle.ToString()}, " +
                $"{nameof(ExtraStorage)}={ExtraStorage.ToString()}, {nameof(NextId)}={NextId.ToString()}, " +
                $"{nameof(Brand)}={Brand}, {nameof(Type)}={Type.ToString()}, {nameof(PrisPrDag)}={PrisPrDag.ToString()}, " +
                $"{nameof(Year)}={Year.ToString()}, {nameof(Km)}={Km.ToString()}}}";
        }
    }
}
