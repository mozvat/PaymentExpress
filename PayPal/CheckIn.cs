using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayPal
{
    public class CheckIn
    {

        public string CreateCheckInNVP
(
PaymentAction paymentAction
, string clientIpAddress
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

            data.Add("CUSTOMERTYPE", "POS");
            data.Add("STOREID", "123");
            data.Add("TERMINALID", "001");
            data.Add("TERMINALTYPE", "CASH_REGISTER");
            data.Add("TERMINALCAPABILITYUSED", "TERMINAL_NOT_USED");
            data.Add("ID", cvv2);
            data.Add("COUNTRYCODE", "1");
            data.Add("PHONENUMBER", "4085551212");
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


//requestEnvelope.errorLanguage=en_US
//&posDetails.clientDetails.customerType=POS
//&posDetails.storeId=123
//&posDetails.terminalId=001
//&posDetails.terminalType=CASH_REGISTER
//&posDetails.terminalCapabilityUsed=TERMINAL_NOT_USED

//&context.retailer.accountId.id=ZM2NJX94N8M66
//&context.customer.mobilePhone.phoneNumber.countryCode=1
//&context.customer.mobilePhone.phoneNumber.phoneNumber=4085551212
//&context.customer.mobilePhone.pin=...