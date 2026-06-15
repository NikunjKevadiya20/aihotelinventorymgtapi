using System.Net;
namespace HotelBooking.Entity.Common.Methods
{
    public class SendSMS
    {
        public void SendOTP(string MobileNo, string SMS)
        {

            var SMSString = CommonRepositoryConstants.SMSGateway +  "number=" + MobileNo + "&message=" + SMS;
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(SMSString);

            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();

            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());

            string responseString = respStreamReader.ReadToEnd();

            respStreamReader.Close();

            myResp.Close();

        }
    }
}
