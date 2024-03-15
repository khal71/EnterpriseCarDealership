namespace EnterpriseCarDealership.Models
{
    //Khaled

    public class Car:Vehicle
    {
        /// <summary>
        /// Her har vi attributter som er unikke for car og resten er arvet gennem Vehicle klassen
        /// </summary>
        public bool AC { get; set; }
        public bool Sunroof { get; set; }

        public bool Screen { get; set; }

        public bool DVD { get; set; }
        public bool Camera { get; set; }
        public bool Sensor { get; set; }
        /// <summary>
        /// Konstruktører
        /// </summary>
        public Car()
        {

        }
        public Car(int Id, string Brand, MotorType Type, double PrisPrDag, int Year, int Km, bool aC, bool sunroof, bool screen, bool dVD, bool camera, bool sensor):base(Id, Brand, Type, PrisPrDag, Year, Km)
        {

            
            AC = aC;
            Sunroof = sunroof;
            Screen = screen;
            DVD = dVD;
            Camera = camera;
            Sensor = sensor;

        }
        public Car(string brand)
        {
           
        }
        /// <summary>
        /// To string metode
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{{nameof(AC)}={AC.ToString()}, {nameof(Sunroof)}={Sunroof.ToString()}," +
            $" {nameof(Screen)}={Screen.ToString()}, {nameof(DVD)}={DVD.ToString()}, " +
            $"{nameof(Camera)}={Camera.ToString()}, {nameof(Sensor)}={Sensor.ToString()}, " +
            $"{nameof(NextId)}={NextId.ToString()}, {nameof(Brand)}={Brand}, {nameof(Type)}={Type.ToString()}, " +
            $"{nameof(PrisPrDag)}={PrisPrDag.ToString()}, {nameof(Year)}={Year.ToString()}, " +
            $"{nameof(Km)}={Km.ToString()}}}";
        }
    }
}
