using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Browser
{
    public class Record
    {
        public string data { get; set; }
        public List<StorySave> list { get; set; }

        public static void Populate()
        {
            MainWindow window = new MainWindow();
            var saving = new Record
            {
                data = DateTime.Now.ToString(),
                list = new List<StorySave>
                {
                    new StorySave
                    {
                        StorySaving = window.txtUrl.Text.ToString()
                    }
                }
            };
        }
    }

    public class StorySave
    {
        public string StorySaving { get; set; }
    }

    public static class XmlHelper
    {
        public static bool NewLineAttribute { get; set; }

        public static string Toxml(object obj, XmlSerializerNamespaces ns)
        {
            Type T = obj.GetType();
            var xs = new XmlSerializer(T);
            var ws = new XmlWriterSettings
            {
                Indent = true,
                NewLineOnAttributes = NewLineAttribute,
                OmitXmlDeclaration = true
            };
            var sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb, ws))
            {
                xs.Serialize(writer, obj, ns);
            }
            return sb.ToString();
        }

        public static string ToXml(object obj)
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("","");
            return Toxml(obj, ns);
        }

        public static T FromXml<T>(string xml)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StringReader sr = new StringReader(xml))
                return (T)xs.Deserialize(sr);
        }

        public static object FromXml(string xml, string typeName)
        {
            Type T = Type.GetType(typeName);
            XmlSerializer xs = new XmlSerializer(T);
            using (StringReader sr = new StringReader(xml))
                return xs.Deserialize(sr);
        }

        public static void ToXmlFile(Object obj, string filePath)
        {
            var xs = new XmlSerializer(obj.GetType());
            var ns = new XmlSerializerNamespaces();
            var ws = new XmlWriterSettings
            {
                Indent = true,
                NewLineOnAttributes = NewLineAttribute,
                OmitXmlDeclaration = true
            };
            ns.Add("", "");
            using (XmlWriter writer = XmlWriter.Create(filePath, ws))
                xs.Serialize(writer, obj);
        }

        public static T FromXmlFile<T>(string filePath)
        {
            StringReader sr = new StringReader(filePath);
            try
            {
                var res = FromXml<T>(sr.ReadToEnd());
                return res;
            }
            catch(Exception ex)
            {
                throw new Exception("" + filePath + ex.InnerException.Message);
            }
        }
    }
}
