using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Utilities.Messages
{
    public static class XML
    {
        public static Dictionary<string, string> Parse(string data)
        {
            XDocument doc = XDocument.Parse(data);
            Dictionary<string, string> dataDictionary = new Dictionary<string, string>();

            foreach (XElement element in doc.Descendants().Where(p => p.HasElements == false))
            {
                // All keys will be UPPERCARD
                string keyName = element.Name.LocalName.ToUpper();

                // Only take the first unique tag and ignore duplicates
                if (!dataDictionary.ContainsKey(keyName))
                {
                    dataDictionary.Add(keyName, element.Value);
                }
            }

            return dataDictionary;
        }

        public static string Create(string rootNode, Dictionary<string, string> dataDictionary)
        {
            string xmlString = string.Empty;

            XmlDocument doc = new XmlDocument();
            
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode responseNode = doc.CreateElement(rootNode);
            doc.AppendChild(responseNode);

            foreach (KeyValuePair<string, string> kvp in dataDictionary)
            {
                if (!string.IsNullOrEmpty(kvp.Value))
                {
                    XmlNode propertyNode = doc.CreateElement(kvp.Key);
                    propertyNode.AppendChild(doc.CreateTextNode(kvp.Value));
                    responseNode.AppendChild(propertyNode);
                }
            }

            using (StringWriter sw = new StringWriter())
            {
                using (XmlTextWriter tx = new XmlTextWriter(sw))
                {
                    tx.Formatting = Formatting.Indented;
                    doc.WriteTo(tx);
                }

                xmlString = sw.ToString();
            }

            return xmlString;
        }
    }
}
