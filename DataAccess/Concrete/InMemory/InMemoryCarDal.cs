using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{BrandId=1, ColorId=2, DailyPrice=100, Description="Porsche", Id=1, ModelYear=1990},
                new Car{BrandId=2, ColorId=5, DailyPrice=150, Description="Mercedes", Id=3, ModelYear=1950},
                new Car{BrandId=3, ColorId=6, DailyPrice=200, Description="BMW", Id=6, ModelYear=1980},
                new Car{BrandId=4, ColorId=3, DailyPrice=300, Description="Bentley", Id=8, ModelYear=1999},
                new Car{BrandId=5, ColorId=8, DailyPrice=400, Description="Rolls Royce", Id=9, ModelYear=2010},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByCategory(int Id)
        {
            return _cars.Where(p => p.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Id = car.Id;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;
        }
    }
}
