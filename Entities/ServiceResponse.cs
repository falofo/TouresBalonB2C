using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Entities
{
    public class ServiceResponse
    {
        public HttpStatusCode code { get; set; }
        public String content { get; set; }
    }
}