using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

namespace EnterpriseCarDealership.Models
{
   
    /// Jakob
   
    public class Manager:User
    {
        /// <summary>
        /// Konstruktører
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="password"></param>
        /// <param name="IsMedarbejder"></param>
        /// <param name="isAdmin"></param>
        /// <param name="tlf"></param>
        public Manager(int Id, string Name, string password,bool IsMedarbejder, bool isAdmin, string tlf) : base(Id, Name, password, IsMedarbejder , isAdmin, tlf)
        {
           
        }
        public Manager()
        {

        }
        /// <summary>
        /// Tostring metode
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{{nameof(NextId)}={NextId.ToString()}, {nameof(Name)}={Name}, {nameof(Password)}={Password}, {nameof(IsMedarbejder)}={IsMedarbejder.ToString()}, {nameof(IsAdmin)}={IsAdmin.ToString()}, {nameof(Tlf)}={Tlf}}}";
        }
    }
}
