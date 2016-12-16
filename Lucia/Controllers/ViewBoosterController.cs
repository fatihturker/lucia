using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lucia.Controllers
{
    public class ViewBoosterController : ApiController
    {
        [AcceptVerbs("GET")]
        public void Boost(string id)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://www.youtube.com/watch?v=" + id);

            request.Proxy = new WebProxy("127.0.0.1:8118", true);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
    }
}
