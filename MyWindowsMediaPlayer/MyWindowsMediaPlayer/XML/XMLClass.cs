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
        public static bool XMLCreate(string name, List<File> it)
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
                MessageBox.Show("ERROR : " + e.Message);
            }
            return false;
        }

        public static List<File> XMLRead(string name)
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
                foreach (XmlNode currentNode in node)
                {
                    uriNode = currentNode.SelectSingleNode("uri");
                    path = uriNode.InnerText;
                    reader.Add(new File(path));
                }
            }
            catch (XmlException e)
            {
                MessageBox.Show("An error in xml file : " + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR : " + e.Message);
            }
            return reader;
        }
    }
}
