using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using net.tipstrade.FCMNet;
using net.tipstrade.FCMNet.Requests;
using net.tipstrade.FCMNet.Responses;
using Newtonsoft.Json;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string key = "secret_key";
                Message<Notification> m = new Message<Notification>();
                m.To = "destination_token";
                m.Priority = Priority.High;

                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("date", DateTime.Now.ToShortDateString());
                data.Add("remarks", "remarks dari .Net Console");
                data.Add("amount", "20");
                data.Add("points", "10");
                m.Data = data;
                //Response r = m.Send(key);
                //Console.WriteLine(r.CanonicalIDs);

                Token t = new Token();
                t.Notification_key =  "" ;
                t.Notification_key_name = "";
                t.Operation = "add";
                t.Registration_ids = new string[] { "" };
                Response re =  t.Send(key);

                Console.Write("send Add : ", JsonConvert.SerializeObject(re));

                t.Operation = "create";
                re = t.Send(key);
                Console.Write("send Create : ",JsonConvert.SerializeObject(re));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }

        }
    }
}
