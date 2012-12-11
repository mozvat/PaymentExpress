using System.Collections.Generic;

namespace PayPal
{
    internal static class Security
    {
        internal static Dictionary<string, string> AddSecurityData(Dictionary<string, string> requestData)
        {
            Settings settings = new Settings();

            requestData.Add("USER", settings.User);
            requestData.Add("PWD", settings.Password);
            requestData.Add("SIGNATURE", settings.Signature);
            requestData.Add("VERSION", settings.Version);

            return requestData;
        }
    }
}
