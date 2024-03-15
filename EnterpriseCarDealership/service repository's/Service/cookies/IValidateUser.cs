using EnterpriseCarDealership.Models;

namespace EnterpriseCarDealership.service_repository_s.Service.cookies
{  //Jakob
    public interface IValidateUser
    {
        /// <summary>
        /// vi skal brug den klasse til at arves til ValidateUser klasse som tjekker navn og password
        /// </summary>
        /// <param name="navn"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Validate(string navn, string password);
    }
}
