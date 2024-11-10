using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace rubtsova_zad3_ind
{
    public partial class Form1 : Form
    {
        // Список автомобилей
        private List<Car> cars = new List<Car>();
        // Коллекция автомобилей для хранения новых автомобилей
        List<Car> carCollection = new List<Car>();
        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик события нажатия на пункт меню "Добавить"
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка правильности полей ввода
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            double mileage;
            double consumptionPerKm;
            int yearOfManufacture;
            int numberOfDoors;

            bool isValidMileage = double.TryParse(textBox1.Text, out mileage);
            bool isValidConsumption = double.TryParse(textBox2.Text, out consumptionPerKm);
            bool isValidYear = int.TryParse(textBox5.Text, out yearOfManufacture);
            bool isValidDoors = int.TryParse(textBox8.Text, out numberOfDoors);

            // Проверьте наличие отрицательных значений
            if (mileage < 0 || consumptionPerKm < 0 || numberOfDoors < 0)
            {
                MessageBox.Show("Пожалуйста, вводите только положительные значения для пробега, расхода и количества дверей.");
                return;
            }

            // Реалистичная проверка пробега
            if (mileage > 1000000)
            {
                MessageBox.Show("Пробег должен быть менее 1,000,000 км.");
                return;
            }
            // Проверка на корректность введенных значений
            if (!isValidMileage || !isValidConsumption || !isValidYear || !isValidDoors)
            {
                MessageBox.Show("Пожалуйста, вводите только числовые значения в соответствующие поля.");
                return;
            }

            string brand = textBox3.Text;
            string color = textBox4.Text;
            string bodyType = textBox6.Text;

            // Проверьте, существует ли в CarCollection автомобиль с такими же параметрами

            bool avtomobilExists = carCollection.Any(avtomobil =>
                avtomobil.Mileage == mileage &&
                avtomobil.ConsumptionPerKm == consumptionPerKm &&
                avtomobil.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
                avtomobil.Color.Equals(color, StringComparison.OrdinalIgnoreCase));

            if (avtomobilExists)
            {
                MessageBox.Show("Автомобиль с такими параметрами уже существует в списке!");
                return;
            }

            Avtomobil newCar = new Avtomobil(mileage, consumptionPerKm, brand, color, yearOfManufacture, numberOfDoors, bodyType);
            carCollection.Add(newCar); // Добавить новый автомобиль в основную коллекцию
            cars.Add(newCar); // При необходимости также добавьте во временную коллекцию
            DisplayCars(); // Обновите отображение после добавления нового автомобиля
        }

        // Метод для отображения автомобилей в listBox
        private void DisplayCars()
        {
            listBox1.Items.Clear(); // Очистите поле списка перед добавлением элементов
            foreach (Avtomobil car in cars) // Повторите просмотр коллекции автомобилей один раз
            {
                listBox1.Items.Add(car.PrintInformation()); // Добавьте информацию о каждом автомобиле
            }
        }

        // Обработчик события нажатия на пункт меню "Выйти"
        private void выйтиИзПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Подтверждение выхода из программы
            DialogResult dr = MessageBox.Show("Вы действительно хотите выйти из программы", "Подтверждение", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();// Закрыть приложение
            }
        }

        // Обработчик события нажатия на пункт меню "Удалить"
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel4.Visible = true;
        }

        // Обработчик события нажатия на кнопку удаления автомобиля
        private void button4_Click(object sender, EventArgs e)
        {
            // Проверка, выбран ли элемент в listBox
            if (listBox1.SelectedIndex != -1)
            {
                // Удаление выбранного автомобиля из списка
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                MessageBox.Show("Автомобиль удалён.");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите автомобиль для удаления."); // Предупреждение о том, что ничего не выбрано
            }
        }
     
    }
}
