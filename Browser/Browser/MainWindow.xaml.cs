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

        private bool IsUrlValid(string url)
        {
            url = txtUrl.Text.ToString();
            string reg = @"^(http|https|ftp|)\//|[a-zA-Z0-9\-\.]+\.[a-zA-Z]([a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$^[.com|.ua|.ru]";
            Regex regex = new Regex(reg, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(url);
        }

        public string Method(string str)
        {
            List<string> list = new List<string>();
            list.Add(str);
            Save();
            return str;
        }

        public void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            History wHistory = new History();
            if (e.Key == Key.Enter)
            {
                if (IsUrlValid(txtUrl.Text) == true)
                {
                    wbProg.Navigate(txtUrl.Text);
                    txtUrlcombo.Items.Add(txtUrl.Text);
                    wHistory.listbox.Items.Add(txtUrl.Text);
                    Create();
                    foreach(var s in txtUrl.Text)
                        Method(txtUrl.Text);
                    //Save();
                }
                else
                {
                    wbProg.Navigate("http://" + txtUrl.Text + ".com");
                    txtUrlcombo.Items.Add(txtUrl.Text);
                    wHistory.listbox.Items.Add(txtUrl.Text);
                    Create();
                    foreach (var s in txtUrl.Text)
                        Method(txtUrl.Text);
                    //Save();
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

        public void Create()
        {
            /*XmlWriter writer = XmlWriter.Create("Story.xml");
            writer.WriteStartDocument();
            writer.WriteStartElement("Story");
            writer.WriteStartElement("Link");
            writer.WriteAttributeString("Time", DateTime.Now.ToString());
            writer.WriteString(txtUrl.Text.ToString());
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            XmlTextWriter writer = new XmlTextWriter("Story.xml", Encoding.UTF8);
            XmlDocument document = new XmlDocument();
            document.LoadXml("Story.xml");
            XmlNode node = document.CreateNode("Link","Date","");
            node.InnerText = txtUrl.Text.ToString();
            XmlElement root = document.DocumentElement;
            root.AppendChild(node);
            document.Save("Story.xml");
            XmlTextWriter writer = new XmlTextWriter("Story.xml", Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartElement("Story");
            writer.WriteAttributeString("Date", DateTime.Now.ToString());
            writer.WriteElementString("Link", txtUrl.Text.ToString());
            writer.WriteFullEndElement();
            writer.WriteEndElement();
            writer.WriteWhitespace("\n");
            writer.WriteRaw(txtUrl.Text.ToString() + DateTime.Now.ToString());
            writer.Close();
            if (File.Exists("Story.xml") == true)
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml("Story.xml");
                XmlElement link = document.CreateElement("Link");
                link.InnerText = txtUrl.Text.ToString();
                XmlElement date = document.CreateElement("Date");
                date.InnerText = DateTime.Now.ToString();
                XmlElement root = document.DocumentElement;
                root.AppendChild(link);
                root.AppendChild(date);
                document.Save("Story.xml");
            }
            else
            {

                XmlTextWriter writer = new XmlTextWriter("Story.xml", null);
                XmlDocument document = new XmlDocument();
                writer.WriteStartElement("Story");
                writer.WriteElementString("Link", txtUrl.Text.ToString());
                writer.WriteElementString("Date", DateTime.Now.ToString());
                writer.WriteEndElement();
                document.LoadXml("Story");
                XmlElement link = document.CreateElement("Link");
                link.InnerText = txtUrl.Text.ToString();
                XmlElement date = document.CreateElement("Date");
                date.InnerText = DateTime.Now.ToString();
                XmlElement root = document.DocumentElement;
                root.AppendChild(link);
                root.AppendChild(date);
                document.Save("Story.xml");
                writer.Close();
            }*/
                XmlWriter writer = XmlWriter.Create("Story.xml");
                writer.WriteStartElement("Story");
                writer.WriteElementString("Link", null);//, txtUrl.Text.ToString());
                writer.WriteElementString("Date", null);//DateTime.Now.ToString());
                writer.WriteEndElement();
                writer.Close();
            //XmlDocument document = new XmlDocument();
            //document.Load("Story.xml");
            //XmlNode node = document.DocumentElement.FirstChild;
            //XmlElement element = document.CreateElement("Story");
            //element.SetAttribute("Link", txtUrl.Text.ToString());
            //element.SetAttribute("Date", DateTime.Now.ToString());
            //document.DocumentElement.InsertAfter(element, node);
            //document.Save("Story.xml");
            //BindData();
            //XmlWriter writer = XmlWriter.Create("Story.xml");
            //writer.WriteStartElement("Story");
            //writer.WriteElementString("Link", txtUrl.Text.ToString());
            //writer.WriteElementString("Date", DateTime.Now.ToString());
            //writer.WriteEndElement();
            //XmlDocument document = new XmlDocument();
            //document.Load("Story.xml");
            //XmlNode node = document.DocumentElement.FirstChild;
            //XmlElement element = document.CreateElement("Story");
            //element.SetAttribute("Link",txtUrl.Text.ToString());
            //element.SetAttribute("Date", DateTime.Now.ToString());
            //document.DocumentElement.InsertAfter(element, node);
            //document.Save("Story.xml");
        }

        void Save()
        {
            XmlDocument document = new XmlDocument();
            document.Load("Story.xml");
            XmlNode node = document.DocumentElement.FirstChild;
            XmlElement element = document.CreateElement("History");
            foreach (var s in txtUrl.Text)
            {
                element.SetAttribute("Link", txtUrl.Text.ToString());
                element.SetAttribute("Date", DateTime.Now.ToString());
                document.DocumentElement.InsertAfter(element, node);
            }
            document.Save("Story.xml");
        }
    }
}
