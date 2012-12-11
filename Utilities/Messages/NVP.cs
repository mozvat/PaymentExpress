using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Utilities.Messages
{
    public static class NVP
    {
        public static Dictionary<string, string> Parse(string data)
        {
            Dictionary<string, string> dataDictionary = new Dictionary<string, string>();

            string[] pairs = data.Split('&');

            for (int i = 0; i < pairs.Length; i++)
            {
                string[] pair = pairs[i].Split('=');

                // All keys will be UPPERCARD
                string keyName = pair[0].ToUpper();
                
                // Only take the first unique tag and ignore duplicates
                if (!dataDictionary.ContainsKey(keyName) 
                    && pair.Length == 2)
                {
                    dataDictionary.Add(keyName, HttpUtility.UrlDecode(pair[1]));
                }
            }

            return dataDictionary;
        }

        public static string Create(Dictionary<string, string> dataDictionary)
        {
            StringBuilder nvpStringBuilder = new StringBuilder();

            foreach(KeyValuePair<string, string> kvp in dataDictionary)
            {
                if (!string.IsNullOrEmpty(kvp.Value))
                {
                    nvpStringBuilder.AppendFormat("&{0}={1}", kvp.Key, HttpUtility.UrlEncode(kvp.Value));
                }
            }

            return nvpStringBuilder.Remove(0,1).ToString();
        }
    }
}
