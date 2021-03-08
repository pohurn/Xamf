using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace xamf.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string Name { get; }
        public string Content { get; }

        public ApiException()
        {
        }

        public ApiException(HttpStatusCode statusCode, string name, string content)
        {
            StatusCode = statusCode;
            Name = name;
            Content = content;
        }
    }
}