using Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace TouresBalonB2C.Controllers
{
    public class ControllerUtil : Controller
    {
        public ServiceResponse consumirServicio(String method, String url,Object input)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = method;
            request.ContentType = "application/json";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            if (!method.Equals("GET"))
            {
                string inputJson = (new JavaScriptSerializer()).Serialize(input);
                byte[] bytes = Encoding.UTF8.GetBytes(inputJson);
                request.ContentLength = bytes.Length; 
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Close();
                }
            }

            ServiceResponse serviceResponse = new ServiceResponse();
            using (HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse())
            {
                serviceResponse.code = httpResponse.StatusCode;
                using (Stream stream = httpResponse.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        serviceResponse.content = sr.ReadToEnd();
                    }
                }

            }

            return serviceResponse;
        }
        
    }
}