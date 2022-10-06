using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Application.Models;
using Asp.Omeno.Service.Application.Services.Users.Commands.PushNotifications;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Net;
using System.Text;
namespace Asp.Omeno.Service.Infrastructure
{
    public class PushNotification : IPushNotification
    {
        public async Task Push(PushNotificationsCommand model)
        {
            try
            {
                string url = @"https://fcm.googleapis.com/fcm/send";
                WebRequest tRequest = WebRequest.Create(url);
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";

                string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message=" + "This is the message" + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + model.RegisterId + "";
                var data = new
                {
                    to = model.To, // "8D17EBE12557CD76",
                    notification = new
                    {
                        body = model.Body,
                        title = model.Title

                    }
                };
                string jsonss = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                Byte[] byteArray = Encoding.UTF8.GetBytes(jsonss);                
                tRequest.Headers.Add(string.Format("Authorization: key={0}",model.Key));
                tRequest.Headers.Add(string.Format("Sender: id={0}", model.SenderId));
                tRequest.ContentLength = byteArray.Length;
                tRequest.ContentType = "application/json";
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                
                                Console.Write(sResponseFromServer);                                
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.Write(ex.Message);
                {
                    var sss = ex.Message;
                    if (ex.InnerException != null)
                    {
                        var ss = ex.InnerException;
                    }
                }

            }



        }
    }
}
