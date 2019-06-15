using System.IO;
using System.Net;
using System.Text;

namespace Token_Validator_Windows.Utils
{
    class HttpQuery
    {
        //use Unity WWW Form or sth like this instead of this
        public static string Post(string url, string data)
        {
            var byteArray = new UTF8Encoding().GetBytes(data);
            var request = WebRequest.Create(url);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            ((HttpWebRequest) request).UserAgent = "SCP SL Token Validation Tool";
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            var dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            var response = request.GetResponse();
            dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);

            var responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }
    }
}
