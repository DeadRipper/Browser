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
using System.Windows.Shapes;

namespace Browser
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Window
    {
        public History()
        {
            InitializeComponent();
        }

        public void Add()
        {
            //MainWindow main = new MainWindow();
            //List<string> list = new List<string>();
            //list.Add(main.txtUrl.Text);
            //foreach (var VARIABLE in list)
            //{
            //    storytextbox.Text.ToString();
            //    storytextbox.Visibility = Visibility.Visible;
            //}
        }

        private void storytextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow window = new MainWindow();
            if (storytextbox.Text.Equals(window.txtUrl))
                storytextbox.Visibility = Visibility.Visible;
            else
                storytextbox.Visibility = Visibility.Hidden;
        }
    }
}
