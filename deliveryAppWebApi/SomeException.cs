using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryAppWebApi
{
    public class SomeException: Exception
    {
        public SomeException() : base()
        {
        }

        public SomeException(string message) : base(message)
        {
        }

        public SomeException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
