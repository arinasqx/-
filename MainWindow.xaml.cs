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
using Microsoft.Win32;
using System.IO;

namespace _9
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

        private void MenuItem_Click(object ob, RoutedEventArgs pup) // Открыть
        {
            OpenFileDialog a = new OpenFileDialog();
            a.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"; 
            bool? резульат = a.ShowDialog();
            if (резульат == true)
            {
                string файл = a.FileName;
                string b = File.ReadAllText(файл);
                rtb.Text = b;
            }
        }
        private void MenuItem_Click_1(object ob, RoutedEventArgs pup) // Сохрнить
        {
            SaveFileDialog a = new SaveFileDialog();
            a.DefaultExt = ".txt";
            a.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            bool? резульат = a.ShowDialog();
            if (резульат == true)
            {
                string файл = a.FileName;
                string b = rtb.Text;
                File.WriteAllText(файл, b);
            }
        }

        private void MenuItem_Click_2(object ob, RoutedEventArgs pup) // выход
        {
            this.Close();
        }
        private void rtd_TextChanged(object sender, TextChangedEventArgs e) // объявили пустой обработчик события
        {

        }
        private void ColorSelector_SelectionChanged(object sender, SelectionChangedEventArgs e) //Изменение цветов
        {
            if (rtb != null && ColorSelector.SelectedItem != null)   
            {
                string colorName = (ColorSelector.SelectedItem as ComboBoxItem).Content.ToString();      
                if (colorName == "Red")    // Используя цикл if устанавила цвет для текста 
                {
                    rtb.Foreground = Brushes.Red;     // красный
                }
                if (colorName == "Yellow")
                {   
                    rtb.Foreground = Brushes.Yellow;  // желтый
                }
                if (colorName == "Green")
                {
                    rtb.Foreground = Brushes.Green;   // зеленый
                }
                if (colorName == "Pink")
                {// красный
                    rtb.Foreground = Brushes.Pink;  // розовый
                }
                else if (colorName == "Blue")
                {
                    rtb.Foreground = Brushes.Blue;     // синий
                }
            }
        }
        private void FontComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // Выбор шрифта
        {
            if (FontComboBox.SelectedItem != null)
            {
                string selectedFont = (FontComboBox.SelectedItem as ComboBoxItem).Content.ToString();

                FontFamily = new System.Windows.Media.FontFamily(selectedFont);
            }
        }
        private void FontSelector_SelectionChanged(object sender, SelectionChangedEventArgs e) // Размер шрифта по умолчанию
        {               
            if (rtb != null)   
            {
                double fontSize = 14; // В данном случае размер по умолчанию 14
                if (FontSelector.SelectedItem != null)
                {
                    string selectedFontSize = ((ComboBoxItem)FontSelector.SelectedItem).Content.ToString();
                    if (double.TryParse(selectedFontSize, out fontSize))       
                    {
                        FontSize = fontSize;   
                    }
                }
            }
        }
    }
}




