using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPS_HostedPayment.MPS_HostedCheckoutWebService;
using System.Configuration;

namespace MPS_HostedPayment
{
    class Initialize
    {
        private void CreditCardProcess()
        {

            double amount = double.Parse(ConfigurationManager.AppSettings["DepositAmount"]);
            //Create the InitializePayment request
            InitPaymentRequest hcRequest = new InitPaymentRequest();
            //Populated the request fields. All this info needs to come from the Payment.aspx fields of Billing Info.
            hcRequest.MerchantID = ConfigurationManager.AppSettings["MerchantID"];
            hcRequest.Password = ConfigurationManager.AppSettings["HCPassword"];
            hcRequest.TranType = "Sale";
            hcRequest.TotalAmount = amount;
            hcRequest.Invoice = GetNextInvoiceNumber();
            hcRequest.CardHolderName = string.Empty;
            hcRequest.AVSAddress = string.Empty;
            hcRequest.AVSZip = string.Empty;
            hcRequest.Frequency = "Recurring";
            hcRequest.Memo = "MPS Hosted Checkout Ecommerce 1.0";
            hcRequest.ReturnUrl = ConfigurationManager.AppSettings["ReturnURL"];
            hcRequest.ProcessCompleteUrl = ConfigurationManager.AppSettings["ProcessCompleteURL"];
            hcRequest.BackgroundColor = "White";
            hcRequest.FontColor = "Black";
            hcRequest.FontSize = "Medium";
            hcRequest.FontFamily = "FontFamily1";
            hcRequest.PageTitle = "MPS EComm";
            hcRequest.LogoUrl = string.Empty;
            hcRequest.DisplayStyle = "Custom";
            hcRequest.SecurityLogo = "On";
            //Call the InitializePayment Web Service Method.
            HCServiceSoapClient hcWS = new HCServiceSoapClient();
            InitPaymentResponse response = hcWS.InitializePayment(hcRequest);
            //check the responseCode
            string paymentID = string.Empty;
            string paymentMSG = string.Empty;

            if (response.ResponseCode == 0)
            {
                //get the payment ID
                paymentID = response.PaymentID;
            }


            //access the response message if needed.
            paymentMSG = response.Message;

            //Set the necessary variables before building html.
            string hostedCheckoutURL = ConfigurationManager.AppSettings["HostedCheckoutURL"];

            //Build an html form post to be sent back to the browser.  
            //It will redirect the browser to the Mercury Hosted Checkout page.
            Response.Clear();
            Response.Write("<html><head>");
            Response.Write("</head><body onload=\"document.frmCheckout.submit()\">");
            Response.Write("<form name=\"frmCheckout\" method=\"Post\" action=\"" + hostedCheckoutURL + "\" >");
            Response.Write("<input name=\"PaymentID\" type=\"hidden\" value=\"" + paymentID + "\">");
            Response.Write("</form>");
            Response.Write("</body></html>");
            Response.End();
        }

        private string GetNextInvoiceNumber()
        {
            Random rand = new Random();
            int randNumber = rand.Next(999);
            return randNumber.ToString();
        }
    }
}
