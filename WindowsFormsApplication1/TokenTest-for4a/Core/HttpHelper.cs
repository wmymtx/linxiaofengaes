using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TokenTest_for4a.Core
{
    /// <summary>
    /// Http工具类，用于向指定url发起Get或Post请求
    /// http://yjmyzz.cnblogs.com/
    /// </summary>
    public class HttpHelper
    {
        private string postData;
        SynchronizationContext currentContext;
        SendOrPostCallback sendOrPostCallback;

        /// <summary>
        /// 从指定url以Get方式获取数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="completedHandler"></param>
        public void Get(string url, DownloadStringCompletedEventHandler completedHandler)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += completedHandler;
            client.DownloadStringAsync(new Uri(url));
        }



        /// <summary>
        /// 向指定url地址Post数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="mediaType"></param>
        /// <param name="synchronizationContext"></param>
        /// <param name="callBack"></param>
        public void Post(string url, string data, string mediaType, SynchronizationContext synchronizationContext, SendOrPostCallback callBack)
        {
            currentContext = synchronizationContext;
            Uri endpoint = new Uri(url);
            sendOrPostCallback = callBack;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endpoint);
            request.Method = "POST";
            request.ContentType = mediaType;
            //request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            //request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";
            //string reqUserAgent = request.UserAgent;
            //request.UserAgent = //"Mozilla/5.0 (Windows; U; Windows NT 5.2) AppleWebKit/525.13 (KHTML, like Gecko) Chrome/0.2.149.27 Safari/525.13  ";
            postData = data;
            //CookieContainer cc = new CookieContainer();
            //Cookie cUserName = new Cookie("cSpaceUserEmail", "742783833%40qq.com");
            //cUserName.Domain = "10.105.4.50";
            //cc.Add(new Uri("http://10.105.4.50"), cUserName);
            //request.CookieContainer.Add(new Uri("http://10.105.4.50"), cUserName);
            request.BeginGetRequestStream(new AsyncCallback(RequestReadySocket), request);
        }

        private void RequestReadySocket(IAsyncResult asyncResult)
        {
            WebRequest request = asyncResult.AsyncState as WebRequest;
            Stream requestStream = request.EndGetRequestStream(asyncResult);

            using (StreamWriter writer = new StreamWriter(requestStream))
            {
                writer.Write(postData);
                writer.Flush();
            }

            request.BeginGetResponse(new AsyncCallback(ResponseReadySocket), request);
        }

        private void ResponseReadySocket(IAsyncResult asyncResult)
        {
            try
            {
                WebRequest request = asyncResult.AsyncState as WebRequest;
                WebResponse response = request.EndGetResponse(asyncResult);
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream);
                    string paramStr = reader.ReadToEnd();
                    currentContext.Post(sendOrPostCallback, paramStr);
                }
            }
            catch (Exception e)
            {
                currentContext.Post(sendOrPostCallback, e.Message);
            }

        }


    }
}
