using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rubtsova_zad3_ind
{
    public class Car
    {
        // Поля
        public double Mileage { get; set; }
        public double ConsumptionPerKm { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }

        // Конструктор
        public Car(double mileage, double consumptionPerKm, string brand, string color)
        {
            Mileage = mileage;
            ConsumptionPerKm = consumptionPerKm;
            Brand = brand;
            Color = color;
        }

        // Функция для определения качества объекта
        public virtual double Q()
        {
            return Mileage / ConsumptionPerKm;
        }

        // Метод для вывода информации об объекте
        public virtual string PrintInformation()
        {
            return $"Марка: {Brand}, Цвет: {Color}, Пробег: {Mileage}, Расход на км: {ConsumptionPerKm}, Качество: {Q()}";
        }

        // Методы для добавления и удаления
        public void Add(List<Car> collection, Car car)
        {
            collection.Add(car);
        }

        public void Remove(List<Car> collection, Car car)
        {
            collection.Remove(car);
        }

        public void Remove(Dictionary<string, Car> collection, string key)
        {
            collection.Remove(key);
        }

        public void Add(Dictionary<string, Car> collection, string key, Car car)
        {
            collection[key] = car;
        }

        // Перегрузка метода Add для добавления нескольких автомобилей
        public void Add(List<Car> collection, List<Car> cars)
        {
            collection.AddRange(cars);
        }

        // Перегрузка метода PrintInformation для вывода информации о нескольких автомобилях
        public string PrintInformation(List<Car> cars)
        {
            string info = "";
            foreach (var car in cars)
            {
                info += car.PrintInformation() + "\n";
            }
            return info;
        }
    }




}

