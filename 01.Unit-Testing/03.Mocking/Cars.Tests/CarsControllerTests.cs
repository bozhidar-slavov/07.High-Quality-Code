namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using Cars.Models;

    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            // : this(new JustMockCarsRepository())
            : this(new MoqCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void SearchByValidMakeShouldReturnDetail()
        {
            var cars = (IList<Car>)this.GetModel(() => this.controller.Search("BMW"));

            foreach (var car in cars)
            {
                Assert.AreEqual(car.Make, "BMW");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortByInvalidOptionShouldThrowArgumentException()
        {
            var cars = (IList<Car>)this.GetModel(() => this.controller.Sort("invalid"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortingCarsByMakeShouldThrowErrorWhenNoArgumentIsPassed()
        {
            var cars = (IList<Car>)this.GetModel(() => this.controller.Sort(""));
        }

        [TestMethod]
        public void SortingCarsByMakeShouldReturnSortedListByMake()
        {
            var cars = (IList<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.IsNotNull(cars);
            Assert.AreEqual(4, cars.Count);

            Assert.AreEqual("Audi", cars[0].Make);
            Assert.AreEqual("BMW", cars[1].Make);
            Assert.AreEqual("BMW", cars[2].Make);
            Assert.AreEqual("Opel", cars[3].Make);
        }

        [TestMethod]
        public void SortingCarsByYearShouldReturnSortedListByYear()
        {
            var cars = (IList<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.IsNotNull(cars);
            Assert.AreEqual(4, cars.Count);

            Assert.AreEqual(2010, cars[0].Year);
            Assert.AreEqual(2008, cars[1].Year);
            Assert.AreEqual(2007, cars[2].Year);
            Assert.AreEqual(2005, cars[3].Year);
        }

        [TestMethod]
        public void DetailForValidCarShouldWorkCOrrectly()
        {
            var detailsForCar = (Car)this.GetModel(() => this.controller.Details(1));

            Assert.AreEqual(1, detailsForCar.Id);
            Assert.AreEqual("Audi", detailsForCar.Make);
            Assert.AreEqual(2005, detailsForCar.Year);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
