using CarsLib;

namespace CarREST.Repositories
{
    public class CarsRepository
    {
        private int _nextID;
        private List<Car> _cars;

        public CarsRepository()
        {
            _nextID = 1;
            _cars = new List<Car>() 
            { 
                new Car() {Id = _nextID++, LicensePlate="AB 123", Model="Volvo", Price=12000},
                new Car() {Id = _nextID++, LicensePlate="CD 456", Model="Fiat", Price=34000},
                new Car() {Id = _nextID++, LicensePlate="EF 789", Model="Peugeot", Price=23990},
                new Car() {Id = _nextID++, LicensePlate="GH 012", Model="Kia", Price=34000},
            };
        }

        public List<Car> GetAll()
        {
            List<Car> result = new List<Car>(_cars);
            return result;
        }

        public Car Add(Car newCar)
        {
            newCar.Validate();
            newCar.Id = _nextID++;
            _cars.Add(newCar);
            return newCar;
        }

        public Car? Update(int id, Car updatesCar)
        {
            updatesCar.Validate();
            Car? carToBeUpdated = GetById(id);
            if (carToBeUpdated == null)
            {
                return null;
            }
            carToBeUpdated.Price = updatesCar.Price;
            carToBeUpdated.LicensePlate = updatesCar.LicensePlate;
            carToBeUpdated.Model = updatesCar.Model;
            return carToBeUpdated;
        }

        public Car? GetById(int id)
        {
            return _cars.Find(car => car.Id == id);
        }

        public Car Delete(int id)
        {
            Car? carToBeDeleted = GetById(id);
            if(carToBeDeleted == null)
            {
                return null;
            }
            _cars.Remove(carToBeDeleted);
            return carToBeDeleted;
        }




    }
}
