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
using System.Text.RegularExpressions;
using System.Windows.Media.Animation;
using System.IO;
using System.Xml;
using System.Xml.XmlConfiguration;

namespace Browser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            wbProg.Navigate("http://www.google.com");
        }

		public void XmlStory(string val)
		{
			val = txtUrl.Text.ToString();
			XmlDocument document = new XmlDocument();
			XmlDeclaration declaration = document.CreateXmlDeclaration("1.0", "utf-8", null);
			document.AppendChild(declaration);

			XmlComment comment = document.CreateComment("StoryDatabase");
			document.AppendChild(comment);

			XmlElement element = document.CreateElement("BrowserData");
			document.AppendChild(element);
			XmlElement ElementRow = document.CreateElement("row");
			element.AppendChild(ElementRow);

			XmlElement xml = document.CreateElement("Field");
			xml.SetAttribute("Data", "Site");
			xml.InnerText = val;
			ElementRow.AppendChild(xml);

			XmlElement element1 = document.CreateElement("Field");
			element1.SetAttribute("Data", "Time");
			element1.InnerText = DateTime.Now.ToString();
			ElementRow.AppendChild(element1);

			document.Save("Story.xml");
		}

        public void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
				wbProg.Navigate("http://" + txtUrl.Text + ".com");
				XmlStory(txtUrl.Text);
            }

        }

        private void wbProg_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            txtUrl.Text = e.Uri.OriginalString;
        }

        private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbProg != null) && (wbProg.CanGoBack));
        }

        private void BrowseBack_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbProg.GoBack();
        }

        private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbProg != null) && (wbProg.CanGoForward));
        }

        private void BrowseForward_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbProg.GoForward();
        }

        private void GoToPage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void GoToPage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbProg.Navigate(txtUrl.Text);
        }
    }
}
