using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace TriUgl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Val1.MaxLength = 10;
            Val2.MaxLength = 10;
            Val3.MaxLength = 10;
        }

        static public int Values { get; set; }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if ((Val1.Text == "") || (Val2.Text == "") || (Val3.Text == ""))
            {
                MessageBox.Show("Пустое значение!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int a = Convert.ToInt32(Val1.Text);
                int b = Convert.ToInt32(Val2.Text);
                int c = Convert.ToInt32(Val3.Text);
                if ((a + b > c) && (a + c > b) && (b + c > a))
                {
                    if ((a == b) && (b == c))
                    {
                        Values = 1;
                    }
                    else
                    {
                        if ((a == b) || (a == c) || (b == c))
                        {
                            Values = 2;
                        }
                        else
                        {
                            Values = 3;
                        }
                    }
                    Window1 window1 = new Window1();
                    window1.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Такой треугольник не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Val1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int result;

            if (!(int.TryParse(e.Text, out result)))
            {
                e.Handled = true;
            }
        }
    }
}
