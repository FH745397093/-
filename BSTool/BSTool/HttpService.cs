using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml;

namespace BSTool
{
    class HttpService
    {
        public static string HttpPost1(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            //request.ContentType = "application/json";
           // string xml = xmldoc.OuterXml;
            byte[] raw = Encoding.UTF8.GetBytes(String.Format("xmlStr={0}", ""));

            //Uri.EscapeDataString(xml)
            request.ContentLength = raw.Length;
            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(raw, 0, raw.Length);
            myRequestStream.Flush();
            //myStreamWriter.Close();
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
            }
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;

        }

        public static string HttpPostXML(string Url, string xml)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/json; charset=UTF-8";

            byte[] raw = Encoding.UTF8.GetBytes(xml);

            //Uri.EscapeDataString(xml)
            request.ContentLength = raw.Length;
            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(raw, 0, raw.Length);
            myRequestStream.Flush();
            //myStreamWriter.Close();
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();

            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
            }
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

        public static string HttpPost(string Url,XmlDocument xmldoc)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/json; charset=UTF-8";

            string xml = xmldoc.OuterXml;
            byte[] raw = Encoding.UTF8.GetBytes(xml);

            //Uri.EscapeDataString(xml)
            request.ContentLength = raw.Length;
            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(raw, 0, raw.Length);
            myRequestStream.Flush();
            //myStreamWriter.Close();
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
            }
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;

        }
    }
}
