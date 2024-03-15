using EnterpriseCarDealership.Models;

namespace EnterpriseCarDealership.service_repository_s.repo.interfaces
{
    public interface ICarPaymentRepo
    {
        public List<CarPayment> getCarPayments();

        public CarPayment getCarPayment(int id);

    }
}
