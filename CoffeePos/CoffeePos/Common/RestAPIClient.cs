using System;
using System.IO;
using System.Net;
using static CoffeePos.Common.Enums;

namespace CoffeePos.Common
{
    class RestAPIClient
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string endPoint { get; set; }
        public httpVerb httpVerb { get; set; }
        public RestAPIClient()
        {
            endPoint = string.Empty;
            httpVerb = httpVerb.GET;
        }

        public string makeGetRequest()
        {
            string strResValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = httpVerb.ToString();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                log.Debug(response.StatusCode);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    log.Error(response.StatusDescription.ToString());
                    throw new ApplicationException($"Error messages: " + response.StatusCode.ToString());
                }
                //Proccessing when get value
                using (StreamReader responseStream = new StreamReader(response.GetResponseStream()))
                {
                    if (!String.IsNullOrEmpty(responseStream.ToString()))
                    {
                        strResValue = responseStream.ReadToEnd();
                    }
                }
            }
            return strResValue;
        }
    }
}
