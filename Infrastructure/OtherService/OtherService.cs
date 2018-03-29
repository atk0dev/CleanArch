using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infrastructure.Network;

namespace CleanArchitecture.Infrastructure.OtherSevice
{
    public class OtherService : IOtherService
    {
        private const string AddressTemplate = "http://google.com";
        private const string JsonTemplate = "{{\"id\": {0}}}";

        private readonly IWebClientWrapper _client;

        public OtherService(IWebClientWrapper client)
        {
            _client = client;
        }

        public void NotifyDataChanged(int id, decimal a)
        {
            var address = string.Format(AddressTemplate, id);

            var json = string.Format(JsonTemplate, a);

            _client.Post(address, json);
        }

    }
}
