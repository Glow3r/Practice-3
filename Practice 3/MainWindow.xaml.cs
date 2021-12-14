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
using DoubleDimensionArrayManager;
using Microsoft.Win32;
using Library12;

namespace Practice_3
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

        private MyArray _myArray = new MyArray(3, 3);


        private void Calculation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                outputValue.Text = _myArray.MinimalNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void FillArray_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                outputValue.Clear();
                _myArray.Fill();
                dataGridMain.ItemsSource = _myArray.ToDataTable().DefaultView;
            }
            catch 
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void ClearArray_Click(object sender, RoutedEventArgs e)
        {
            _myArray.Clear();
            outputValue.Clear();
            dataGridMain.ItemsSource = _myArray.ToDataTable().DefaultView;
        }

        private void SaveArray_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Title = "Экспорт массива";

            if (saveFileDialog.ShowDialog() == true)
            {
                _myArray.Export(saveFileDialog.FileName);
            }
            outputValue.Clear();
            dataGridMain.ItemsSource = null;
        }

        private void OpenArray_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Импорт массива";

            if (openFileDialog.ShowDialog() == true)
            {
                _myArray.Import(openFileDialog.FileName);
            }
            outputValue.Clear();
            dataGridMain.ItemsSource = _myArray.ToDataTable().DefaultView;
        }

        private void GetInformation_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнил Гаврюшин К. ИСП-34.", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
