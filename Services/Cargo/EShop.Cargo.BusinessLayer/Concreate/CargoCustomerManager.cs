using Eshop.Cargo.DataAccessLayer.Abstract;
using EShop.Cargo.BusinessLayer.Abstract;
using EShop.Cargo.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Cargo.BusinessLayer.Concreate
{
    public class CargoCustomerManager : IGenericService<CargoCustomer>
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;
        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }
        public void TDelete(int Id)
        {
            _cargoCustomerDal.Delete(Id);
        }

        public List<CargoCustomer> TGetAll()
        {
            return _cargoCustomerDal.GetAll();
        }

        public CargoCustomer TGetById(int Id)
        {
            return _cargoCustomerDal.GetById(Id);
        }

        public void TInsert(CargoCustomer entity)
        {
            _cargoCustomerDal.Insert(entity);
        }

        public void TUpdate(CargoCustomer entity)
        {
            _cargoCustomerDal.Update(entity);
        }
    }
}
