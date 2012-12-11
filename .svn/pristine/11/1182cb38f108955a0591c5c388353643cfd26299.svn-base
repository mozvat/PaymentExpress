using System.Collections.Generic;
using Utilities.Finance;

namespace PayPal
{
    public class DoDirectPayment
    {
        public string CreateDoDirectPaymentNVP(
            PaymentAction paymentAction
            , string clientIpAddress
            , CreditCardType creditCardType
            , string creditCardNumber
            , string expDate
            , string cvv2
            , string firstName
            , string lastName
            , string street
            , string city
            , string state
            , CountryCode countryCode
            , string zip
            , CurrencyCode currencyCode
            , decimal amount
            )
        {
            string responseNVP = string.Empty;

            Dictionary<string, string> data = new Dictionary<string, string>();
            Security.AddSecurityData(data);

            data.Add("METHOD", "DoDirectPayment");
            data.Add("PAYMENTACTION", paymentAction.ToString());
            data.Add("IPADDRESS", clientIpAddress);
            data.Add("CREDITCARDTYPE", creditCardType.ToString());
            data.Add("ACCT", creditCardNumber);
            data.Add("EXPDATE", expDate);
            data.Add("CVV2", cvv2);
            data.Add("FIRSTNAME", firstName);
            data.Add("LASTNAME", lastName);
            data.Add("STREET", street);
            data.Add("CITY", city);
            data.Add("STATE", state);
            data.Add("COUNTRYCODE", countryCode.ToString());
            data.Add("ZIP", zip);
            data.Add("CURRENCYCODE", currencyCode.ToString());
            data.Add("AMT", amount.ToString("F"));

            responseNVP = Utilities.Messages.NVP.Create(data);

            return responseNVP;
        }               
    }
}
