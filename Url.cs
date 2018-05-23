using System;
using UrlBuilder;
using UrlBuilder.Helpers;

namespace Url
{
    public class Url : IUrl
    {
        /// <summary>
        /// public factory function to build a url and get the string result
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="parameters"></param>
        /// <returns>the full url</returns>
        public static string CreateUrl(string baseUrl, object parameters)
        {
            Url instance = new Url(baseUrl, parameters);
            return instance.GetUrl();
        }

        private readonly string _baseUrl;
        private readonly object _parameters = new { };
        private string _url;

        public Url(string baseUrl, object parameters = null)
        {
            _baseUrl = baseUrl;
            
            if (parameters != null)
            {
                _parameters = parameters;
            }

            BuildUrl();
        }

        private void BuildUrl()
        {
            _url = _baseUrl;

            AddParams(_parameters);
        }

        public string GetUrl()
        {
            return _url;
        }

        public void AddParam(string name, object value)
        {
            if (value == null) return;

            string _value = value.ToString();

            if (value is bool)
            {
                _value = _value.ToLower();
            }

            if (string.IsNullOrEmpty(_value))
            {
                return;
            }

            var glue = _url.Contains("?") ? "&" : "?";
            _url += $"{glue}{name}={_value}";
        }

        public void AddParams(object parameters)
        {
            ReflectionHelpers.ObjectEnumerate(
                parameters,
                param =>
                {
                    var value = param.GetValue(parameters, null);
                    AddParam(param.Name, value);
                }
            );
        }
    }
}