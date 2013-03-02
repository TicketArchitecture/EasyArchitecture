using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace EasyArchitecture.Core.Serializer
{
    internal static class JsonSerializer
    {
        private const string NullValue = "null";

        internal static string Serialize(object obj)
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
