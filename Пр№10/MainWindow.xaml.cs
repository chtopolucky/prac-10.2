using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

namespace Пр_10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        ArrayList array = new ArrayList();
        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random rand = new Random();
                int number = Convert.ToInt32(numberValues.Text);
                for (int i = 0; i < number; i++)
                {
                    array.Add(rand.Next(-5,5));
                }
                for (int i = 0; i < array.Count; i++)
                {
                    ListBox.Items.Add(array[i]);
                }
            }
            catch
            {
                MessageBox.Show("Проверьте правильность ввода", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                array.RemoveAt(ListBox.SelectedIndex);
                ListBox.Items.Clear();
                for (int i = 0; i < array.Count; i++)
                {
                    ListBox.Items.Add(array[i]);
                }
            }
            catch
            {
                MessageBox.Show("Выберите элемент для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }       
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            array.Clear();
            ListBox.Items.Clear();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            array.Add(addValue.Text);
            ListBox.Items.Add(addValue.Text);
        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int max = -10000, indexMax = -1;
                for (int i = 0; i < array.Count; i++)
                {
                    if (Convert.ToInt32(array[i]) < 0 && Convert.ToInt32(array[i]) > max)
                    {
                        max = Convert.ToInt32(array[i]);
                        indexMax = i;
                    }
                }
                result.Text = (indexMax + 1).ToString();
            }
            catch
            {
                MessageBox.Show("Ошибочные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №10\nВыполнил студент группы ИСП-31 Обухов Сергей\nЗадание: Составьте программу вычисления в массиве максимального среди отрицательных элементов и его номера. ", "Доп.Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
