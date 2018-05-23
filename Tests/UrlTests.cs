using NUnit.Framework;

namespace Url.Tests
{
    public class UrlTests
    {
        [Test]
        public void CreateUrlShouldReturnString()
        {
            var url = Url.CreateUrl("foo.com", null);
            
            Assert.IsInstanceOf<string>(url);
        }

        [Test]
        public void CreateUrlShouldReturnBaseUrlIfNoParams()
        {
            var url = Url.CreateUrl("foo.com", null);

            Assert.That(url, Is.EqualTo("foo.com"));
        }

        [Test]
        public void CreateUrlShouldReturnUrlWithGetParamsWhenParamsPresent()
        {
            var url = Url.CreateUrl("foo.com", new
            {
                foo = "bar"
            });

            Assert.That(url, Is.EqualTo("foo.com?foo=bar"));
        }

        [Test]
        public void CreateUrlShouldReturnUrlWithMixedTypeParams()
        {
            var url = Url.CreateUrl("foo.com", new
            {
                foo = "bar",
                page = 1,
                fizz = true
            });

            Assert.That(url, Is.EqualTo("foo.com?foo=bar&page=1&fizz=true"));
        }
        
        [Test]
        public void CreateUrlShouldBeAbleToReceiveAnyObjectTypeForParameters()
        {
            var parameters = new
            {
                eventGroup = "foo",
                gender = "bar"
            };
            var url = Url.CreateUrl("foo.com", parameters);

            Assert.That(url, Is.EqualTo("foo.com?eventGroup=foo&gender=bar"));
        }

        [Test]
        public void GetUrlShouldReturnString()
        {
            var builder = new Url("foo.com");
            var result = builder.GetUrl();
            
            Assert.IsInstanceOf<string>(result);
        }

        [Test]
        public void GetUrlShouldReturnUrl()
        {
            var builder = new Url("foo.com");
            var result = builder.GetUrl();

            Assert.That(result, Is.EqualTo("foo.com"));
        }

        [Test]
        public void AddParamShouldAddParameterToUrl()
        {
            var builder = new Url("foo.com");

            builder.AddParam("fizz", "buzz");
            var result = builder.GetUrl();

            Assert.That(result, Is.EqualTo("foo.com?fizz=buzz"));
        }
        
        [Test]
        public void AddParamShouldAddAnyTypeParamToUrl()
        {
            var builder = new Url("foo.com");

            builder.AddParam("fizz", "buzz");
            builder.AddParam("foo", true);
            builder.AddParam("bar", 1);
            var result = builder.GetUrl();

            Assert.That(result, Is.EqualTo("foo.com?fizz=buzz&foo=true&bar=1"));
        }

        [Test]
        public void AddParamsShouldAddParametersToUrl()
        {
            var builder = new Url("foo.com");
            builder.AddParams(new
            {
                foo = "bar",
                bar = "foo"
            });
            var result = builder.GetUrl();

            Assert.That(result, Is.EqualTo("foo.com?foo=bar&bar=foo"));
        }
    }

}