using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace TokenTest_for4a
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //CheckAiuapTokenSoap.CommonTokenServiceClient s = new CheckAiuapTokenSoap.CommonTokenServiceClient();
            ServiceReference4.ExportReportServiceSoapClient s = new ServiceReference4.ExportReportServiceSoapClient();
            s.GoldBankLog();

           // ServiceReference3.CreateTokenWebServiceClient create = new ServiceReference3.CreateTokenWebServiceClient();
           // create.CreateToken()

            /* string
                   rst = s.CheckAiuapTokenSoap(xmlStr.ToString());
             HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://10.105.4.50:58080/bingo.dms/soap-service/rest?service_address=http://10.109.209.100:9081/uac/services/CheckAiuapTokenSoap");
             request.Headers.Add("SOAPAction", @"""""");
             request.Headers.Add("VsDebuggerCausalityData", "uIDPo2xDWUX4t0FKnPOs1JCsx/kAAAAAPpUZrGPNdUmAbcilfQyWa3JhrkuWKtNJsrMhcNz8LUQACQAA");
             HttpWebResponse response = null;
             CookieContainer cc = new CookieContainer();
             //request = (HttpWebRequest)WebRequest.Create("http://localhost:2539/");
             request.Method = "POST";
             request.ContentType = Core.MediaType.TEXT_XML;
             //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:19.0) Gecko/20100101 Firefox/19.0";
             
             // string data = @"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/""><s:Body s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><q1:CheckAiuapTokenSoap xmlns:q1=""http://service.base.app.core.a4.asiainfo.com""><RequestInfo xsi:type=""xsd:string""><?xml version='1.0' encoding='UTF-8'?><USERREQ><HEAD><CODE></CODE><SID></SID><TIMESTAMP>YYYY09DD164732</TIMESTAMP><SERVICEID>SCNGZZBB</SERVICEID></HEAD><BODY><APPACCTID>2001189772</APPACCTID><TOKEN>32|126|-24|41|83|-47|99|28|-56|126|-73|-63|124|-24|-100|-115|-68|-120|-93|101|-104|-21|120|124|-102|22|-49|50|-1|-5|86|-64|89</TOKEN></BODY></USERREQ></RequestInfo></q1:CheckAiuapTokenSoap></s:Body></s:Envelope>";//string requestForm = "userName=1693372175&userPassword=123456";     //拼接Form表单里的信息
             string data = @"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/""><s:Body s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><q1:CheckAiuapTokenSoap xmlns:q1=""http://service.base.app.core.a4.asiainfo.com""><RequestInfo xsi:type=""xsd:string"">&lt;?xml version='1.0' encoding='UTF-8'?&gt;&lt;USERREQ&gt;&lt;HEAD&gt;&lt;CODE&gt;&lt;/CODE&gt;&lt;SID&gt;&lt;/SID&gt;&lt;TIMESTAMP&gt;YYYY09DD183126&lt;/TIMESTAMP&gt;&lt;SERVICEID&gt;SCNGZZBB&lt;/SERVICEID&gt;&lt;/HEAD&gt;&lt;BODY&gt;&lt;APPACCTID&gt;2001189772&lt;/APPACCTID&gt;&lt;TOKEN&gt;32|126|-24|41|83|-47|99|28|-56|126|-73|-63|124|-24|-100|-115|-68|-120|-93|101|-104|-21|120|124|-102|22|-49|50|-1|-5|86|-64|89&lt;/TOKEN&gt;&lt;/BODY&gt;&lt;/USERREQ&gt;</RequestInfo></q1:CheckAiuapTokenSoap></s:Body></s:Envelope>";
             byte[] postdatabyte = Encoding.UTF8.GetBytes(data);
             request.ContentLength = postdatabyte.Length;
             request.AllowAutoRedirect = false;
             request.CookieContainer = cc;
             request.KeepAlive = true;

             Stream stream;
             stream = request.GetRequestStream();
             stream.Write(postdatabyte, 0, postdatabyte.Length); //设置请求主体的内容
             stream.Close();

             //接收响应
             response = (HttpWebResponse)request.GetResponse();
             Console.WriteLine();

             Stream stream1 = response.GetResponseStream();
             StreamReader sr = new StreamReader(stream1);
             string rsts = sr.ReadToEnd();
             string rstss = HttpUtility.UrlDecode(rsts);
             string rstsss = Regex.Unescape(rsts);
             // MessageBox.Show(UnicodeToString(rsts));
             string xml = UnicodeToString(rsts).Trim();

             XmlDocument xd = new XmlDocument();
             StringBuilder builder = new StringBuilder();
             string[] lst = xml.Split(new string[] { "USERRSP" }, StringSplitOptions.None);
             builder.Append(xml.Substring(0, xml.IndexOf(">") + 1));
             builder.AppendLine();
             builder.Append(xml.Substring(xml.IndexOf(">") + 1));
             string xmls = Core.XmlHelper.SpltXml(xml, "USERRSP");
             xd.LoadXml(xmls);
             XmlReader reader = XmlReader.Create(new StringReader(xmls));
             XDocument document = XDocument.Load(reader);
             var nodes = document.Nodes();
             string codeVal = nodes.ElementAt(0).ToString();
             MessageBox.Show(codeVal);*/

            //  MessageBox.Show(rst);
        }

        //可以包括其他字符         
        public string uncode(string str)
        {
            string outStr = "";
            Regex reg = new Regex(@"(?i)//u([0-9a-f]{4})");
            outStr = reg.Replace(str, delegate (Match m1)
            {
                return ((char)Convert.ToInt32(m1.Groups[1].Value, 16)).ToString();
            });
            return outStr;
        }

        /// <summary>  
        /// Unicode字符串转为正常字符串  
        /// </summary>  
        /// <param name="srcText"></param>  
        /// <returns></returns>  
        public static string UnicodeToString(string srcText)
        {
            string dst = "";
            dst = srcText.Replace("&lt;", "<").Replace("&gt;", ">");
            return dst;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder xmlStr = new StringBuilder();
            xmlStr.Append("<?xml version='1.0' encoding='UTF-8'?><USERREQ>");
            xmlStr.Append("<AUTH><ACCT>");
            xmlStr.Append("16|78|48|-8|-48|-122|108|44|-64|22|-49|50|-1|-5|86|-64|89");
            xmlStr.Append("</ACCT><PWD>");
            xmlStr.Append("8|6|-96|-76|80|-63|43|-118|66");
            xmlStr.Append("</PWD></AUTH>");
            xmlStr.Append("<HEAD><CODE></CODE><SID></SID><TIMESTAMP>");
            xmlStr.Append(DateTime.Now.ToString("yyyyMMddHHmmsss"));
            xmlStr.Append("</TIMESTAMP><SERVICEID>SCNGZZBB</SERVICEID></HEAD><BODY><APPACCTID>");
            xmlStr.Append("2001189772").Append("</APPACCTID><TOKEN>");
            xmlStr.Append("32|126|-24|41|83|-47|99|28|-56|-44|-51|-12|72|12|-72|43|39|2|-95|-88|41|115|-56|-52|-64|22|-49|50|-1|-5|86|-64|89").Append("</TOKEN></BODY></USERREQ>");
            ServiceReference2.CommonTokenServiceClient c = new ServiceReference2.CommonTokenServiceClient();
            MessageBox.Show(c.CheckAiuapTokenSoap(xmlStr.ToString()));

        }
    }
}
