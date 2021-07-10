using System;
using System.Collections.Generic;
using System.Text;

namespace deliveryAppCore.Enumerations
{
    public enum Codes : ushort
    {
        success = 0,
        error = 1,
        ConnectionLost = 100,
        OutlierReading = 200
    }
}
