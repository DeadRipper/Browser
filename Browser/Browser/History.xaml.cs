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
