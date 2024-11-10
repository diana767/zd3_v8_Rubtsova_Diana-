using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rubtsova_zad3_ind
{
    public class Avtomobil : Car
    {
        // Дополнительное поле
        public int YearOfManufacture { get; set; }

        // Свойства
        public int NumberOfDoors { get; set; }
        public string BodyType { get; set; }

        // Конструктор
        public Avtomobil(double mileage, double consumptionPerKm, string brand, string color, int yearOfManufacture, int numberOfDoors, string bodyType)
            : base(mileage, consumptionPerKm, brand, color)
        {
            YearOfManufacture = yearOfManufacture;
            NumberOfDoors = numberOfDoors;
            BodyType = bodyType;
        }

        // Функция для определения качества объекта класса потомка
        public override double Q()
        {
            return base.Q() * 1.5 * YearOfManufacture; // Example: add some factor based on the age of the car
        }

        // Дополнительная функция для класса потомка
        public override string PrintInformation()
        {
            // Call the base PrintInformation and append additional details
            return $"{base.PrintInformation()}, Год выпуска: {YearOfManufacture}, Кол-во дверей: {NumberOfDoors}, Тип кузова: {BodyType}";
        }
    }
}
