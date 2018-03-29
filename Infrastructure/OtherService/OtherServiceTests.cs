using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Infrastructure.Network;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.Infrastructure.OtherSevice
{
    [TestFixture]
    public class OtherServiceTests
    {
        private OtherService _service;
        private AutoMoqer _mocker;

        private const string Address = "http://google.com/";
        private const string Json = "{\"id\": 2}";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _service = _mocker.Create<OtherService>();
        }
        
    }
}
