using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenTest_for4a.Core
{
    public class XmlHelper
    {
        public static string SpltXml(string scXmlString, string spltString)
        {
            if (!string.IsNullOrEmpty(spltString))
            {

                string[] xmlSplt = scXmlString.Split(new string[] { spltString }, StringSplitOptions.None);
                if (xmlSplt.Length >= 3)
                {
                    StringBuilder xmlBuilder = new StringBuilder();
                    xmlBuilder.Append("<").Append(spltString).Append(xmlSplt[1]);
                    xmlBuilder.Append(spltString).Append(">");
                    return xmlBuilder.ToString();
                }
                return scXmlString;
            }
            return scXmlString;
        }

        // public static string XmlDocment
    }

}
