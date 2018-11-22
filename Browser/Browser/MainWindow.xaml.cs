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
using System.Xml;
using System.IO;
using Path = System.Windows.Shapes.Path;

namespace Browser
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            wbProg.Navigate("http://www.google.com");
        }

        private bool IsUrlValid(string url)
        {
            url = txtUrl.Text.ToString();
            string reg = @"^(http|https|ftp|)\//|[a-zA-Z0-9\-\.]+\.[a-zA-Z]([a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$^[.com|.ua|.ru]";
            Regex regex = new Regex(reg, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(url);
        }

        public void Create()
        {
            XmlTextWriter text = new XmlTextWriter("Story.xml", Encoding.UTF8);
            text.WriteStartDocument();
            text.WriteStartElement("Story");
            text.WriteEndElement();
            text.Close();

        }

        void Save()
        {
            string site = txtUrl.Text.ToString();
            XmlDocument document = new XmlDocument();
            document.Load("Story.xml");
            XmlNode node = document.CreateElement("Story");
            document.DocumentElement.AppendChild(node);
            XmlAttribute attribute = document.CreateAttribute("Date");
            attribute.Value = DateTime.Now.ToString();
            node.Attributes.Append(attribute);
            XmlNode subnode = document.CreateElement("Site");
            subnode.InnerText = site;
            node.AppendChild(subnode);
            document.Save("Story.xml");
        }

        public void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                wbProg.Navigate("http://" + txtUrl.Text + ".com");
                Create();
                if (File.Exists("Story.xml"))
                {
                    Save();
                }
                else
                {
                    Create();
                    Save();
                }
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

        private void story_button_Click(object sender, RoutedEventArgs e)
        {
            History wHistory = new History();
            wHistory.Show();
        }
    }
}
