# UrlBuilder
C# utility to simply create url strings and add parameters

## Usage

to create a url quickly, you can use the CreateUrl factory method:

```c#
var url = UrlBuilder.Url.CreateUrl("http://myurl.com");
//url is http://myurl.com
var urlWithParams = UrlBuilder.Url.CreateUrl("http://myurl.com", new { testParam = "testValue" });
//urlWithParams = http://myurl.com?testParam=testValue
```

You can manually create a url with the Url constructor:

```c#
var urlInstance = new UrlBuilder.Url("http://myurl.com");
//do some stuff
//add params with the AddParams or AddParam methods
urlInstance.AddParams(new { foo = "bar", bar = "foo" });

//do more stuff

urlInstance.AddParam("fizz", "buzz");

//now get the url

var url = urlInstance.GetUrl();
//url is http://myurl.com?foo=bar&bar=foo&fizz=buzz
``
