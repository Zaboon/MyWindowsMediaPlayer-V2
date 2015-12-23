using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace MyWindowsMediaPlayer.XML
{
    class XMLClass
    {
        public static bool CreateXml(string name, List<File> it)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(@name, null))
                {
                    writer.WriteStartElement("Media");
                    foreach (File data in it)
                    {
                        writer.WriteStartElement("Item");
                        writer.WriteElementString("uri", @data.getUri.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occured: " + e.Message);
            }
            return false;
        }

        public static List<File> ReadXml(string name)
        {
            List<File> reader = new List<File>();
            XmlDocument file = new XmlDocument();
            XmlNode uriNode;
            XmlNodeList node;

            string path;
            try
            {
                file.Load(@name);
                node = file.SelectNodes("/Media/Item");
                foreach (XmlNode actualNode in node)
                {
                    uriNode = actualNode.SelectSingleNode("uri");
                    path = uriNode.InnerText;
                    reader.Add(new File(uriNode.InnerText));
                }
            }
            catch (XmlException e)
            {
                MessageBox.Show("An error occured in xml file: " + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occured: " + e.Message);
            }
            return reader;
        }
    }
}
