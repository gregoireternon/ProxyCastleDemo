using System;

namespace ProxyPerformance.Extensions
{
    public static class Extensions
    {
        public static string ToMilliseconds(this long value)
        {
            return Convert.ToDouble(value).ToMilliseconds();
        }

        public static string ToMilliseconds(this double value)
        {
            return (value / 10000).ToString("##0.0000 ms");
        }
    }
}
