using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace EasyArchitecture.Runtime.IO
{
    internal static class SerializationHelper
    {
        private const string NullValue = "null";

        internal static string Mount(object obj)
        {
            if (obj == null)
                return NullValue;

            var json = new DataContractJsonSerializer(obj.GetType(), null, int.MaxValue, true, new UnknowTypeDataContractSurrogate(), false);

            var ms = new MemoryStream();
            var writer = JsonReaderWriterFactory.CreateJsonWriter(ms);
            json.WriteObject(ms, obj);
            writer.Flush();
            return Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length);
        }
    }
}
