using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorYoutubeDl.Utils
{
    public static class CastUtils
    {
        public static T StaticCast<T>(object o) => (T)o;
    }
}
