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
				//using (XmlTextWriter writer1 = new XmlTextWriter("Story.xml", null))
				//{
				//	XmlDocument xDoc = new XmlDocument();
				//	xDoc.Load("Story.xml");
				//	XmlElement xRoot = xDoc.DocumentElement;
				//	// создаем новый элемент user
				//	XmlElement story = xDoc.CreateElement("Story");
				//	// создаем атрибут name
				//	XmlAttribute site = xDoc.CreateAttribute("today");
				//	// создаем элементы company и age
				//	XmlElement date = xDoc.CreateElement("date");
				//	XmlElement ageElem = xDoc.CreateElement("age");
				//	// создаем текстовые значения для элементов и атрибута
				//	XmlText nameText = xDoc.CreateTextNode(val);
				//	XmlText companyText = xDoc.CreateTextNode(DateTime.Now.ToString());

				//	//добавляем узлы
				//	site.AppendChild(nameText);
				//	date.AppendChild(companyText);
				//	story.Attributes.Append(site);
				//	story.AppendChild(date);
				//	xRoot.AppendChild(story);
				//	xDoc.Save("Story.xml");
				//using (XmlTextWriter writer1 = new XmlTextWriter("Story.xml", null))
				//{
				//	XmlDocument xmldoc = new XmlDocument();
				//	XmlWriter xml = XmlWriter.Create("Story.xml");
				//	xml.WriteStartDocument();
				//	xml.WriteStartElement("story");
				//	xml.WriteStartElement("today");
				//	xml.WriteAttributeString("date", DateTime.Now.ToString());
				//	xml.WriteString(txtUrl.Text.ToString());
				//	xml.WriteEndElement();
				//	xml.WriteEndDocument();
				//	xml.Close();
				//	writer1.Formatting = Formatting.Indented;
				//	xmldoc.Save(writer1);
				//}

			XmlTextWriter textWriter = new XmlTextWriter("Story.xml", Encoding.UTF8);
			XmlDocument document = new XmlDocument();
			textWriter.WriteStartDocument();
			textWriter.WriteStartElement("Story");
			XmlNode node = document.CreateElement("Day");
			document.DocumentElement.AppendChild(node);
			XmlAttribute attribute = document.CreateAttribute("Site");
			attribute.Value = DateTime.Now.ToString();
			node.Attributes.Append(attribute);
			XmlNode subnode = document.CreateElement("Site");
			subnode.InnerText = val;
			node.AppendChild(subnode);
			document.Save("Story.xml");
			textWriter.WriteEndElement();
			textWriter.Close();
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
