using System;

namespace PayPal
{
    public class Processing
    {
        public Response ProcessRequestNVP(string requestNVP)
        {
            Response response = null;

            try
            {
                string responseString = Utilities.Communication.Web.Post(
                    requestNVP
                    , new Settings().ApiURL
                    , Utilities.Communication.ContentType.URLEncoded);

                response = new Response(Utilities.Messages.NVP.Parse(responseString));
            }
            catch (Exception ex)
            {
                response = null;
                string message = ex.Message;
            }

            return response;
        } 
    }
}
