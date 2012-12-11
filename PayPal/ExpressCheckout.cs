using System.Collections.Generic;

namespace PayPal
{
    public class ExpressCheckout
    {
        public string CreateSetExpressCheckoutNVP(
            PaymentAction paymentAction
            , CurrencyCode currencyCode
            , decimal amount
            , ShippingOptions shippingOptions
            , SolutionType solutionType
            , LandingPage landingPage)
        {
            string responseNVP = string.Empty;
            Settings settings = new Settings();
            Dictionary<string, string> data = new Dictionary<string, string>();
            Security.AddSecurityData(data);

            data.Add("METHOD", "SetExpressCheckout");
            data.Add("RETURNURL", settings.ReturnURL);
            data.Add("CANCELURL", settings.CancelURL);
            data.Add("PAYMENTREQUEST_0_PAYMENTACTION", "Sale");
            data.Add("L_PAYMENTREQUEST_0_NAME0", "10% Decaf Kona Blend Coffee");
            data.Add("L_PAYMENTREQUEST_0_NUMBER0", "623083");
            data.Add("L_PAYMENTREQUEST_0_DESC0", "Size: 8.8-oz");
            data.Add("L_PAYMENTREQUEST_0_AMT0", "9.95");
            data.Add("L_PAYMENTREQUEST_0_QTY0", "2");
            data.Add("L_PAYMENTREQUEST_0_NAME1", "Coffee Filter bags");
            data.Add("L_PAYMENTREQUEST_0_NUMBER1", "623084");
            data.Add("L_PAYMENTREQUEST_0_DESC1", "Size: Two 24-piece boxes");
            data.Add("L_PAYMENTREQUEST_0_AMT1", "39.70");
            data.Add("L_PAYMENTREQUEST_0_QTY1", "2");
            data.Add("PAYMENTREQUEST_0_ITEMAMT", "99.30");
            data.Add("PAYMENTREQUEST_0_TAXAMT", "2.58");
            data.Add("PAYMENTREQUEST_0_SHIPPINGAMT", "3.00");
            data.Add("PAYMENTREQUEST_0_HANDLINGAMT", "2.99");
            data.Add("PAYMENTREQUEST_0_SHIPDISCAMT", "-3.00");
            data.Add("PAYMENTREQUEST_0_INSURANCEAMT", "1.00");
            data.Add("PAYMENTREQUEST_0_AMT", "105.87");
            data.Add("PAYMENTREQUEST_0_CURRENCYCODE", "USD");
            data.Add("ALLOWNOTE", "1");
            data.Add("BUYEREMAILOPTINENABLE", "1");
            data.Add("CUSTOMERSERVICENUMBER", "1-800-COFFREE");
            data.Add("NOSHIPPING", ((int)shippingOptions).ToString());
            data.Add("NOTETOBUYER", "Your Text#12345 to start your Loyalty Program. For your next purchase use Code#L8SH35 for 10% off!");

            responseNVP = Utilities.Messages.NVP.Create(data);
            return responseNVP;
        }

        public string CreateRedirectURL(string tokenValue)
        {
            string redirectURL = string.Empty;
            Settings settings = new Settings();            
            return new Settings().ExpressURL + "?cmd=_express-checkout&token=" + tokenValue;
        }


        //Return information about the Payer to display on the Developers Site
        public string CreateGetExpressCheckoutDetails(
             string token)
        {
            string responseNVP = string.Empty;
            Settings settings = new Settings();
            Dictionary<string, string> data = new Dictionary<string, string>();
            Security.AddSecurityData(data);

            data.Add("METHOD", "GetExpressCheckoutDetails");
            data.Add("TOKEN", token);

            responseNVP = Utilities.Messages.NVP.Create(data);

            return responseNVP;
        }


        public string CreateDoExpressCheckoutPayment(
            string token
            , PaymentAction paymentAction
            , string payerID          
            , CurrencyCode currencyCode
            , decimal amount)
        {
            string responseNVP = string.Empty;
            Settings settings = new Settings();
            Dictionary<string, string> data = new Dictionary<string, string>();
            Security.AddSecurityData(data);

            data.Add("METHOD", "DoExpressCheckoutPayment");
            data.Add("TOKEN", token);
            data.Add("PAYMENTREQUEST_0_PAYMENTACTION", paymentAction.ToString());
            data.Add("PAYERID", payerID);            
            data.Add("PAYMENTREQUEST_0_CURRENCYCODE", currencyCode.ToString());
            data.Add("PAYMENTREQUEST_0_AMT", amount.ToString("F"));
            
            responseNVP = Utilities.Messages.NVP.Create(data);

            return responseNVP;
        }

    }
}
