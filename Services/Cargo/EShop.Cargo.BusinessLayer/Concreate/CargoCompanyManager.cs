using Eshop.Cargo.DataAccessLayer.Abstract;
using EShop.Cargo.BusinessLayer.Abstract;
using EShop.Cargo.EntityLayer.Concreate;

namespace EShop.Cargo.BusinessLayer.Concreate
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;
        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }
        public void TDelete(int Id)
        {
            _cargoCompanyDal.Delete(Id);
        }

        public List<CargoCompany> TGetAll()
        {
            return _cargoCompanyDal.GetAll();   
        }

        public CargoCompany TGetById(int Id)
        {
            return _cargoCompanyDal.GetById(Id);
        }

        public void TInsert(CargoCompany entity)
        {
            _cargoCompanyDal.Insert(entity);
        }

        public void TUpdate(CargoCompany entity)
        {
            _cargoCompanyDal.Update(entity);
        }
    }
}
