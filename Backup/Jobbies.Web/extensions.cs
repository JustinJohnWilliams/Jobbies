using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobbies.Web
{
    public static class extensions
    {
        public static string With(this string s, params object[] args)
        {
            return string.Format(s, args);
        }
    }
}