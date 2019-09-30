using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Utilities
{
    public static class AuthHelper
    {
        public static bool IsAuthenticated(HttpRequest request)
        {
            string tokenValue;
            request.Cookies.TryGetValue("Token", out tokenValue);

            if (tokenValue == "SecretToken")
            {
                return true;
            }

            return false;
        }
    }
}
