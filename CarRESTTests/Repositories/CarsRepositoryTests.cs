using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarREST.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsLib;

namespace CarREST.Repositories.Tests
{
    [TestClass()]
    public class CarsRepositoryTests
    {

        CarsRepository repository;
        Car testCar;

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new CarsRepository();
            testCar = repository.Add(new Car { Id = 1, LicensePlate = "12345", Model = "volvo", Price = 1000 });
        }


        [TestMethod()]
        public void CarsRepositoryTest()
        {
            List<Car> cars = repository.GetAll();
            Assert.AreEqual(5, cars.Count());
        }

        [TestMethod()]
        public void GetAllTest()
        {
            List<Car> cars = repository.GetAll();
            Assert.IsInstanceOfType(cars, typeof(List<Car>));
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.AreEqual("5 volvo 12345 1000", testCar.ToString());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Car updatedCar = new Car { Id = 5, LicensePlate = "test", Model = "volvo", Price = 110 };
            Car? result = repository.Update(testCar.Id, updatedCar);
            Assert.AreEqual("5 volvo test 110", result.ToString());
            Car? nullCar = repository.Update(7, updatedCar);
            Assert.IsNull(nullCar);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Car? getCar = repository.GetById(5);
            Assert.AreEqual(5, getCar.Id);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            int testId = testCar.Id;
            repository.Delete(testId);
            Assert.IsNull(repository.GetById(testId));

            repository.Delete(testId);
            Assert.IsNull(repository.GetById(testId));

        }
    }
}