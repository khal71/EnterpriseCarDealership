namespace EnterpriseCarDealership.Models
{//Khaled
    public class Medarbejder : User
    {
        /// <summary>
        /// Unikke attributter for Medarbejder resten er arvet fra User
        /// </summary>
        public string Adress { get; set; }
        public int ManagerId { get; set; }      
        /// <summary>
        /// Konstroktører
        /// </summary>
        public Medarbejder()
        {
            Adress = "nowhere";
            ManagerId = 0;
        }
        public Medarbejder(int id, string name, string password, bool IsMedarbejder, bool isAdmin, string tlf,string adress, int managerId) : base(id, name, password, IsMedarbejder, isAdmin,tlf )
        {
            Adress = adress;
            ManagerId = managerId;
        }
        /// <summary>
        /// To string Metode
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            return $"{{{nameof(Adress)}={Adress}, {nameof(ManagerId)}={ManagerId.ToString()}, {nameof(NextId)}={NextId.ToString()}, {nameof(Name)}={Name}, {nameof(Password)}={Password}, {nameof(IsAdmin)}={IsAdmin.ToString()}, {nameof(Tlf)}={Tlf}}}";
        }
    }
}
