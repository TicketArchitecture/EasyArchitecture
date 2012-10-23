using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyArchitecture.Internal
{
    public static class JsonSerializer
    {
        public static string Serialize(object obj)
        {
            if(obj is string || obj is char)
            {
                return "\"" + obj + "\"";
            }
            if (obj is bool)
            {
                return obj.ToString().ToLowerInvariant();
            }
            if( obj is Byte || obj is  SByte|| obj is  Int16||obj is Int32|| obj is Int64|| obj is UInt16|| obj is UInt32|| obj is UInt64|| obj is Double|| obj is  Single)
            {
                return obj.ToString();
            }
            if(obj is DateTime)
            {
                //var t = new DateTime(1970,01,01) ((DateTime)obj)
                var t =(long) ((DateTime) obj).Subtract(new DateTime (1970, 01, 01)).TotalMilliseconds;
                return  string.Format("\""+"\\/Date({0})\\/"+"\"",t);
            }
            return string.Empty;
        }
    }
}
