﻿using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailChimp.Net.Tests
{
    [TestClass]
    public class AuthorizedAppTest : MailChimpTest
    {
        [TestMethod]
        public async Task Should_Return_App_Information()
        {
            var apiInfo = await _mailChimpManager.Apps.GetAllAsync();
            Assert.IsNotNull(apiInfo);
        }
    }
}
