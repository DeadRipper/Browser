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
}
