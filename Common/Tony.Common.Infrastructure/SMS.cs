using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using Microsoft.VisualBasic.Devices;

namespace Tony.Common.Infrastructure
{
    public class Sms
    {
        #region Static Members
        private static string _baseUrl = "http://www.mobilewilki.com/api/", _username = "", _password = "";

        public static string UserName
        {
            get
            {
                if (_username == null)
                    throw new ArgumentNullException("User name have not being set");
                return _username;
            }
            set { _username = value; }
        }

        public static string Password
        {
            get
            {
                if (_password == null)
                    throw new ArgumentNullException("password have not being set");
                return _password;
            }
            set { _password = value; }
        }

        public static string BaseUrl
        {
            get
            {
                if (_baseUrl == null)
                    throw new ArgumentNullException("BaseURL have not being set");
                return _baseUrl;
            }
            set { _baseUrl = value; }
        }

        public static bool IsConnected()
        {
            return new Network().IsAvailable;
        }

        public static bool Send(List<Sms> messages, ref string status, string userId, string password, 
            bool isUniquePerReciever = true)
        {
            var senderId = (from m in messages select m.Sender).FirstOrDefault();
            var message = (from m in messages select m.Body).FirstOrDefault();
            //check network connection
            if (!IsConnected())
            {
                status = "Unable to connect to the internet, check your network connection and try again";
                return false;
            }
            //ensure that there is atleaset one msg to send
            if (messages.Count < 1)
            {
                status = "No message sent";
                return false;
            }
            var numbers = "";
            foreach (var me in messages)
            {
                if (me.Number.Substring(0, 1) == "0")
                    me.Number = "234" + me.Number.Substring(1, me.Number.Length - 1);
                numbers += (me.Number + ",");
            }
            var qString = string.Format("loginId={0}&password={1}&sender={2}&recipients={3}&message={4}",
                userId, password, senderId, numbers, message);



            var url = BaseUrl + "sendMessage?" + qString;

            //throw new Exception(qString);

            try
            {
                var req = WebRequest.Create(url);
                req.Proxy = new WebProxy(); //true means no proxy
                var resp = req.GetResponse();
                var sr = new StreamReader(resp.GetResponseStream());
                var outPut = sr.ReadToEnd();

                var respo = new JavaScriptSerializer().Deserialize<SmsResponse>(outPut);
                status = respo.Message;
                return !respo.Error;

            }
            catch (WebException e)
            {
                switch (e.Status)
                {
                    case WebExceptionStatus.Timeout:
                        status = "Connection time out. Please try again";
                        break;
                    case WebExceptionStatus.SendFailure:
                        status = "Error in sending request";
                        break;
                    case WebExceptionStatus.NameResolutionFailure:
                        status = "Error in connecting to the remote server. Please check your internet connection";
                        break;
                    default:
                        status = "Unknown error in sending request";
                        break;

                }
                return false;
            }
            catch (Exception e)
            {
                status = "Error in sending message. This may be as a result of slow internet connection" + e.Message;
                return false;
            }

        }

        public static double GetBalance(string username, string password, ref string message, ref bool succeded)
        {
            var qString = string.Format("loginId={0}&password={1}", username, password);

            var url = BaseUrl + "checkBalance?" + qString; 
            
            try
            {
                var req = WebRequest.Create(url);
                req.Proxy = new WebProxy(); //true means no proxy
                var resp = req.GetResponse();
                var sr = new StreamReader(resp.GetResponseStream());
                var outPut = sr.ReadToEnd();

                var respo = new JavaScriptSerializer().Deserialize<SmsResponse>(outPut);
                message = respo.Message;
                succeded = !respo.Error;
                return respo.Balance;

            }
            catch (WebException e)
            {
                switch (e.Status)
                {
                    case WebExceptionStatus.Timeout:
                        message = "Connection time out. Please try again";
                        break;
                    case WebExceptionStatus.SendFailure:
                        message = "Error in sending request";
                        break;
                    case WebExceptionStatus.NameResolutionFailure:
                        message = "Error in connecting to the remote server. Please check your internet connection";
                        break;
                    default:
                        message = "Unknown error in sending request";
                        break;

                }
                succeded = false;
                return 0;
            }
            catch (Exception e)
            {
                message = "Error in sending message. This may be as a result of slow internet connection" + e.Message;
                succeded = false;
                return 0;
            }
        }
        #endregion

        #region Constructors
        public Sms() { }

        public Sms(string message, string sender, string number)
        {
            Body = message;
            Sender = sender;
            Number = number;
        }

        #endregion

        #region instance members

        public string Body { get; set; }

        public string Sender { get; set; }

        public string Number { get; set; }
        /// <summary>
        /// sends this instance
        /// </summary>
        /// <param name="status">the status message that follows the sending proccess</param>
        /// <returns>True if success or false</returns>
        /// <exception cref="ArgumentNullException">Throws if Number or Sender of this isnstance if null or empty</exception>
        //public bool Send(ref string status)
        //{
        //    if (string.IsNullOrEmpty(Sender) || string.IsNullOrEmpty(Number))
        //    {
        //        throw new ArgumentNullException("Sender or Number cannot be null or empty");
        //    }
        //    return SMS.Send(new List<SMS>{this}, ref status);
        //}

        public string Serialize()
        {
            return "<message><body>" + 
                    Body +
                "</body><number>" + 
                    Number + 
                "</number></message>";
        }

        #endregion

    }
}
