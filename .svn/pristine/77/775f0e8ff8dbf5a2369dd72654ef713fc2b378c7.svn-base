using System;
using System.Collections.Specialized;
using System.Configuration;

namespace PayPal
{
    internal class Settings
    {
        #region Private Fields

        private string _apiURL = string.Empty;
        private string _expressURL = string.Empty;        
        private string _user = string.Empty;
        private string _password = string.Empty;
        private string _signature = string.Empty;
        private string _version = string.Empty;
        private string _returnURL = string.Empty;
        private string _cancelURL = string.Empty;

        #endregion Private Fields

        #region Public Properties

        public string ApiURL
        {
            get { return _apiURL; }
        }
        public string ExpressURL
        {
            get { return _expressURL; }
        }
        public string User
        {
            get { return _user; }
        }
        public string Password
        {
            get { return _password; }
        }
        public string Signature
        {
            get { return _signature; }
        }
        public string Version
        {
            get { return _version; }
        }
        public string ReturnURL
        {
            get { return _returnURL; }
        }
        public string CancelURL
        {
            get { return _cancelURL; }
        }

        #endregion Public Properties

        #region Constructors

        public Settings()
        {
            try
            {
                NameValueCollection configSection = ConfigurationManager.GetSection("MPS.PayPal") as NameValueCollection;
                
                _apiURL = ConfigurationManager.AppSettings["ApiURL"];
                _expressURL = ConfigurationManager.AppSettings["ExpressURL"]; 
                _user = ConfigurationManager.AppSettings["User"];
                _password = ConfigurationManager.AppSettings["Password"];
                _signature = ConfigurationManager.AppSettings["Signature"];
                _version = ConfigurationManager.AppSettings["Version"];
                _returnURL = ConfigurationManager.AppSettings["ReturnURL"];
                _cancelURL = ConfigurationManager.AppSettings["CancelURL"]; 
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to read MPS.PayPal configuration section", ex);
            }

        }

        #endregion Constructors
    }
}
