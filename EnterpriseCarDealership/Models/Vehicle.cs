namespace EnterpriseCarDealership.Models
{
    //Jakob
    public abstract class Vehicle
    {
        /// <summary>
        /// attributter til klassen vehicle som skal arves til Bike and Car
        /// </summary>
        public int NextId { get; set; }
        public string Brand { get; set; }
        public MotorType Type { get; set; }
        public double PrisPrDag { get; set; }
        public int Year { get; set; }
        public int Km { get; set; }

        /// <summary>
        /// Konstruktører
        /// </summary>
        public Vehicle() : this(-1, "dummy", MotorType.Hybrid, -1, 0, -1)
        {

        }
        public Vehicle(int id, string brand, MotorType type, double prisPrDag, int year, int km)
        {
            id = NextId++;
            Brand = brand;
            Type = type;
            PrisPrDag = prisPrDag;
            Year = year;
            Km = km;

        }
        /// <summary>
        /// ToString metode
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{{nameof(NextId)}={NextId.ToString()}, {nameof(Brand)}={Brand}, {nameof(Type)}={Type.ToString()}, {nameof(PrisPrDag)}={PrisPrDag.ToString()}, {nameof(Year)}={Year.ToString()}, {nameof(Km)}={Km.ToString()}}}";
        }
    }
}
