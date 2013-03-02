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
                buffer.Append(pluginInspector.ExtractInfo());
            }
            return buffer.ToString();
        }
    }
}