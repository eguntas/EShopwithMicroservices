using Eshop.Cargo.DataAccessLayer.Abstract;
using EShop.Cargo.BusinessLayer.Abstract;
using EShop.Cargo.EntityLayer.Concreate;

namespace EShop.Cargo.BusinessLayer.Concreate
{
   
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }

        public void TDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<CargoOperation> TGetAll()
        {
            throw new NotImplementedException();
        }

        public CargoOperation TGetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(CargoOperation entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(CargoOperation entity)
        {
            throw new NotImplementedException();
        }
    }
}
