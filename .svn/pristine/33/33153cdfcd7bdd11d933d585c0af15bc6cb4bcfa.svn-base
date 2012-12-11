using System.IO;
using System.Net;

namespace Utilities.Communication
{
    public static class Web
    {
        public static string Post(
            string requestString
            , string url
            , ContentType contentType)
        {
            string responseString = string.Empty;

            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "POST";

            switch (contentType)
            {
                case ContentType.URLEncoded:
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    break;
                case ContentType.XML:
                    webRequest.ContentType = "text/xml";
                    break;
                default:
                    webRequest.ContentType = "text/xml";
                    break;
            }

            webRequest.ContentLength = requestString.Length;
            
            using (StreamWriter writer = new StreamWriter(webRequest.GetRequestStream()))
            {
                writer.Write(requestString.ToString());
            }

            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                // Check status
                if (webRequest.HaveResponse
                    && (webResponse.StatusCode == HttpStatusCode.OK || webResponse.StatusCode == HttpStatusCode.Accepted))
                {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        responseString = reader.ReadToEnd();
                    }
                }
            }

            return responseString;
        }
    }
}
