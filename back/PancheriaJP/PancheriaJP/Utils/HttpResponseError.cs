﻿using System.Net;

namespace Introduccion.Utils
{
    public class HttpResponseError : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message {  get; set; }

        public HttpResponseError(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
