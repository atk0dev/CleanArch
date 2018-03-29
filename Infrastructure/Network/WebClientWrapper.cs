using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CleanArchitecture.Infrastructure.Network
{
    public class WebClientWrapper : IWebClientWrapper
    {
        public void Post(string address, string json)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                // client.UploadString(address, "POST", json);
            }
        }
    }
}
