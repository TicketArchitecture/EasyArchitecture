using System.Collections.Generic;
using System.Text;

namespace EasyArchitecture.Plugins
{
    public class PluginInspectorExtrator
    {
        private readonly List<PluginInspector> _inspectors;

        internal PluginInspectorExtrator(List<PluginInspector> inspectors)
        {
            _inspectors = inspectors;
        }

        public override string ToString()
        {
            var buffer = new StringBuilder();
            buffer.AppendLine("");
            buffer.AppendLine("=============================================================================================");
            foreach (var pluginInspector in _inspectors)
            {
                buffer.Append(ExtractInfo(pluginInspector));
            }
            return buffer.ToString();
        }

        private static string ExtractInfo(PluginInspector pluginInspector)
        {
            var buffer = new StringBuilder();
            var typeInfo = pluginInspector.GetPluginTypeInfo();
            buffer.AppendLine("Plugin Info");
            buffer.Append(typeInfo);

            var detailInfo = pluginInspector.GetPluginDetailInfo();
            if (detailInfo.Length > 0)
            {
                buffer.AppendLine("Configuration Details");
                buffer.Append(detailInfo);
            }
            buffer.AppendLine("=============================================================================================");
            return buffer.ToString();
        }
    }
}