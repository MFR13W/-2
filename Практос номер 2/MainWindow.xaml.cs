using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Практос_номер_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CS(object sender, RoutedEventArgs e)
        {
            // Сброс предыдущих результатов
            ITB.Text = "";
            RTB.Text = "";

            // Генерация случайных чисел
            string numbers = "";
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {

                Random random = new Random();
                int number = random.Next(1, 10);

                // Добавление запятой, если это не первое число
                if (i > 0)
                {
                    numbers += ", ";
                }

                numbers += number;

                // Суммирование чисел больше 5
                if (number > 5)
                {
                    sum += number;
                }
            }

            // Вывод результатов
            RTB.Text = $"{sum}";
            ITB.Text = numbers;
            
        }

        private void Save_MenuItem_Click(object sender, RoutedEventArgs e) // Окно с сохранением файла
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == true) // Получаем путь к файлу
            {
                StreamWriter file = new StreamWriter(save.FileName);
                for (int i = 0; i < 0; i++)
                {
                    file.WriteLine(ITB);
                    file.WriteLine(RTB);
                }
                file.Close();

                // Диалоговое окно после сохранения таблицы
                try
                {
                    File.WriteAllText(ITB.Text, RTB.Text);
                    MessageBox.Show("Файл успешно сохранен");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения файла: {ex.Message}");
                }
            }
        }

        private void Open_MenuItem_Click(object sender, RoutedEventArgs e) // Окно с открытием файла
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            if (open.ShowDialog() == true) // Получаем путь к файлу
            {
                using (StreamReader file = new StreamReader(open.FileName))
                {
                    ITB.Text = file.ReadToEnd();
                    RTB.Text = file.ReadToEnd();
                }

                // Диалоговое окно с открытием файла
                try
                {
                    MessageBox.Show("Файл успешно открыт");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка открытия файла: {ex.Message}");
                }
            }
        }

        private void Button_Prog(object sender, RoutedEventArgs e) // Диалоговое окно и с условием задания
        {
            MessageBox.Show("Кашаев Кирилл \r\n ИСП-24 \r\n "+
            "Ввести n целых чисел. Найти сумму чисел > 5. Результат вывести на экран", "О проге");
        }

        private void Button_Exit(object sender, RoutedEventArgs e) // Закрытие практического задания
        {
            Close();
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            ITB.Clear();
            RTB.Text= "";
        }
    }
}