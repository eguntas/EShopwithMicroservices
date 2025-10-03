using Eshop.Cargo.DataAccessLayer.Abstract;
using Eshop.Cargo.DataAccessLayer.Repositories;
using EShop.Cargo.DtoLayer.Concreate;
using EShop.Cargo.EntityLayer.Concreate;

namespace Eshop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoOperationDal:GenericRepository<CargoOperation> , ICargoOperationDal
    {
        public EfCargoOperationDal(CargoContext context) : base(context)
        {
            
        }
    }
}
