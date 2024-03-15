using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace EnterpriseCarDealership.Models
{//Jakob
    public class User
    {
        /// <summary>
        /// Her sætter vi attributter for user som skal arves til Manager, Medarbejder og Kunde
        /// </summary>
        public  int NextId { get; set; }
        public string Name { get; set; }
        public string Password {get; set; }
        public bool IsMedarbejder { get; set; }
        public bool IsAdmin { get; set; }
        //public string? Tlf { get; set; }
         
        /// <summary>
        /// Den her regular expression vil tjekke hvor mange tegn der findes og symboler som skal passe til tlf nummer
        /// </summary>

        private Regex r = new Regex(@"^((\+)?\d{2}(\s|\-)?)?\d{8}$");
        
        private string _tlf = "";
        public string? Tlf
        {
            get => _tlf;
            set
            {

                if (!(r.IsMatch(value)))
                {
                    throw new ArgumentException("Mobil skal have mellem 8 og 12 tegn");
                }

                _tlf = value;
            }
        }
        /// <summary>
        /// konstruktør, den konstruktør med json er til at binde id nå den skal læses fra reder metoden
        /// </summary>
        /// <param name="NextId"></param>
        /// <param name="Name"></param>
        /// <param name="Password"></param>
        /// <param name="isMedarbejder"></param>
        /// <param name="isAdmin"></param>
        /// <param name="Tlf"></param>
        [JsonConstructor]
        public User(int NextId, string Name, string Password, bool isMedarbejder, bool isAdmin, string Tlf)
        {
            this.NextId=NextId;
            this.Name = Name;
            this.Password = Password;
            this.IsMedarbejder = isMedarbejder;
            this.IsAdmin = isAdmin;
            this.Tlf = Tlf;

        }
        public User()
        {
            NextId = -1;
            Name = "dummy";
            Password = "dummy";
            IsMedarbejder = false;
            IsAdmin = false;
            Tlf = "00000000";

        }
    

        /// <summary>
        /// To string metoden
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{{nameof(NextId)}={NextId.ToString()}, {nameof(Name)}={Name}, {nameof(Password)}={Password}, {nameof(IsMedarbejder)}={IsMedarbejder.ToString()}, {nameof(IsAdmin)}={IsAdmin.ToString()}, {nameof(Tlf)}={Tlf}}}";
        }
    }
}
