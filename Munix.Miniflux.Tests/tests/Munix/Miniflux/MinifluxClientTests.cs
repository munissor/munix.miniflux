namespace Munix.Miniflux.Tests
{
    using System;
    using NUnit.Framework;

    public class MinifluxClientTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CtorWithUrlUsernameAndPassword_Succeeds()
        {
            var client = new MinifluxClient("http://test/", "user", "pass");
            Assert.IsNotNull(client);
        }

        [Test]
        public void CtorWithUrlUsernameAndPassword_FailsWithEmptyUrl()
        {
            Assert.Throws(
                typeof(UriFormatException),
                () => new MinifluxClient(string.Empty, "user", "pass"));
        }

        public void CtorWithUriUsernameAndPassword_Succeeds()
        {
            var client = new MinifluxClient(new Uri("http://test/"), "user", "pass");
            Assert.IsNotNull(client);
        }
    }
}