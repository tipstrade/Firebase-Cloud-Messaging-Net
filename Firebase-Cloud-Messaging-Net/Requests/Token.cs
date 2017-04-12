using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace net.tipstrade.FCMNet.Requests
{
    public class Token
    {
        protected const string FCMSendUri = "https://android.googleapis.com/gcm/notification";
        [JsonProperty("operation", NullValueHandling = NullValueHandling.Ignore)]
        public string Operation { get; set; }
        [JsonProperty("notification_key_name", NullValueHandling = NullValueHandling.Ignore)]
        public string Notification_key_name { get; set; }
        [JsonProperty("registration_ids", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Registration_ids { get; set; }
        [JsonProperty("notification_key", NullValueHandling = NullValueHandling.Ignore)]
        public string Notification_key { get; set; }

        #region Methods
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="key">The Firebase Cloud Messaging authorization key.</param>
        public Responses.TokenResponse Send(string key)
        {
            if (this.Operation == "create")
            {
                this.Notification_key = null;
            }
            else
            {
                if (Notification_key == null)
                    throw new Exception("Notification_key must not null");
            }
           
            var req = (HttpWebRequest)HttpWebRequest.Create(FCMSendUri);
            req.Method = "POST";
            req.ContentType = "application/json";
            //req.Headers.Add("Authorization", "key=" + key);
            req.Headers.Add(string.Format("Authorization: key={0}", key));
            req.Headers.Add(string.Format("project_id:923461195943"));


            using (var writer = new StreamWriter(req.GetRequestStream()))
            {
                writer.NewLine = "";
#if DEBUG
                var json = JsonConvert.SerializeObject(this
                 );
#endif
                writer.Write(JsonConvert.SerializeObject(this));
            }

            HttpWebResponse resp = null;
            WebResponse r = null;
            try
            {
               
                //resp = (HttpWebResponse)(req.GetResponse());
                r = req.GetResponse();
                
                using (var reader = new StreamReader(r.GetResponseStream()))
                {
                    return JsonConvert.DeserializeObject<Responses.TokenResponse>(reader.ReadToEnd());
                }

            }
            catch (WebException ex)
            {
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    return JsonConvert.DeserializeObject<Responses.TokenResponse>(reader.ReadToEnd());
                }
            }
            finally
            {
                if (resp != null)
                    resp.Dispose();
            }
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="key">The Firebase Cloud Messaging authorization key.</param>
        public async Task<Responses.TokenResponse> SendAsync(string key)
        {
            return await Task.Run(() => Send(key));
        }
        #endregion
        
    }
}
