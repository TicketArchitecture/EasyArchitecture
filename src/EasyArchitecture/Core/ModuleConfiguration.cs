using System;
using System.Collections.Generic;
using System.Text;
using EasyArchitecture.Core.Plugin;

namespace EasyArchitecture.Core
{
    public class ModuleConfiguration
    {
        public readonly Dictionary<Type, object> Factories = new Dictionary<Type, object>();
        private readonly List<PluginInspector> _inspectors = new List<PluginInspector>();

        public void AddPluginConfigurationInfo(PluginInspector pluginInspector)
        {
            _inspectors.Add(pluginInspector);
        }

        public string GetPluginConfigurationInfo()
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