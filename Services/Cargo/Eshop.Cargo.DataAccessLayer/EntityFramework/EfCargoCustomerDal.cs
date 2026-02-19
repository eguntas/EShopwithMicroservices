using Eshop.Cargo.DataAccessLayer.Abstract;
using Eshop.Cargo.DataAccessLayer.Repositories;
using EShop.Cargo.DtoLayer.Concreate;
using EShop.Cargo.EntityLayer.Concreate;

namespace Eshop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal:GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _cargoContext;
        public EfCargoCustomerDal(CargoContext context, CargoContext cargoContext) : base(context)
        {
            _cargoContext = cargoContext;
        }

        public CargoCustomer GetCargoCustomerById(string id)
        {
           var values = _cargoContext.CargoCustomers.Where(x=>x.UserCustomerId == id).FirstOrDefault();
            return values;

        }
    }
}
