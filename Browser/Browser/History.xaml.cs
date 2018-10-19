using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
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
using System.Xml.Serialization;

namespace Browser
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
    [Serializable]
    public partial class History : Window
    {
        public History()
        {
            InitializeComponent();
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow wMain = new MainWindow();
            listbox.SelectedItems.ToString();
        }
    }
}
