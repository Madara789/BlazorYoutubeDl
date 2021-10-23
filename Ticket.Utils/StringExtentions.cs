using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorYoutubeDl.Utils
{
    public static class StringExtentions
    {
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);
        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);
        public static int ToInt(this string value) => int.Parse(value);
    }
}
