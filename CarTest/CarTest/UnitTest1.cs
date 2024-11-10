using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using rubtsova_zad3_ind;
using System.Collections.Generic;
namespace CarTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Car_Constructor_InitializesPropertiesCorrectly()
        {
            // Arrange
            double mileage = 100000;
            double consumptionPerKm = 7.5;
            string brand = "Toyota";
            string color = "Red";

            // Act
            Car car = new Car(mileage, consumptionPerKm, brand, color);

            // Assert
            Assert.AreEqual(mileage, car.Mileage);
            Assert.AreEqual(consumptionPerKm, car.ConsumptionPerKm);
            Assert.AreEqual(brand, car.Brand);
            Assert.AreEqual(color, car.Color);
        }

        [TestMethod]
        public void Car_Q_CalculatesQualityCorrectly()
        {
            // Arrange
            Car car = new Car(150000, 6.0, "Honda", "Blue");

            // Act
            double quality = car.Q();

            // Assert
            Assert.AreEqual(25000, quality);
        }
        [TestMethod]
        public void Car_PrintInformation_ReturnsCorrectInformation()
        {
            // Arrange
            Car car = new Car(120000, 8.0, "Ford", "Black");

            // Act
            string info = car.PrintInformation();

            // Assert
            Assert.AreEqual("Марка: Ford, Цвет: Black, Пробег: 120000, Расход на км: 8, Качество: 15000", info);
        }

        [TestMethod]
        public void Car_Add_AddsCarToList()
        {
            // Arrange
            List<Car> cars = new List<Car>();
            Car car = new Car(100000, 7.0, "Nissan", "Silver");

            // Act
            car.Add(cars, car);

            // Assert
            Assert.AreEqual(1, cars.Count);
            Assert.AreEqual(car, cars[0]);
        }


        [TestMethod]
        public void Car_Remove_RemovesCarFromDictionary()
        {
            // Arrange
            Dictionary<string, Car> cars = new Dictionary<string, Car>()
            {
                { "car1", new Car(100000, 7.0, "Nissan", "Silver") }
            };

            // Act
            cars.Remove("car1");

            // Assert
            Assert.AreEqual(0, cars.Count);
        }

        [TestMethod]
        public void Car_Add_AddsCarToDictionary()
        {
            // Arrange
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            Car car = new Car(100000, 7.0, "Nissan", "Silver");

            // Act
            car.Add(cars, "car1", car);

            // Assert
            Assert.AreEqual(1, cars.Count);
            Assert.AreEqual(car, cars["car1"]);
        }

       
    }
    [TestClass]
    public class AvtomobilTests
    {
        [TestMethod]
        public void Avtomobil_Constructor_InitializesPropertiesCorrectly()
        {
            // Arrange
            double mileage = 100000;
            double consumptionPerKm = 7.5;
            string brand = "Toyota";
            string color = "Red";
            int yearOfManufacture = 2020;
            int numberOfDoors = 4;
            string bodyType = "Sedan";

            // Act
            Avtomobil avtomobil = new Avtomobil(mileage, consumptionPerKm, brand, color, yearOfManufacture, numberOfDoors, bodyType);

            // Assert
            Assert.AreEqual(mileage, avtomobil.Mileage);
            Assert.AreEqual(consumptionPerKm, avtomobil.ConsumptionPerKm);
            Assert.AreEqual(brand, avtomobil.Brand);
            Assert.AreEqual(color, avtomobil.Color);
            Assert.AreEqual(yearOfManufacture, avtomobil.YearOfManufacture);
            Assert.AreEqual(numberOfDoors, avtomobil.NumberOfDoors);
            Assert.AreEqual(bodyType, avtomobil.BodyType);
        }

    }
}
