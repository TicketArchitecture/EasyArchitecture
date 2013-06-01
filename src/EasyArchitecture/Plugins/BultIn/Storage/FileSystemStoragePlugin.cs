using System;
using EasyArchitecture.Plugins.Contracts.Storage;

namespace EasyArchitecture.Plugins.BultIn.Storage
{
    internal class FileSystemStoragePlugin : Plugin, IStoragePlugin
    {
        private string _defaultPath;

        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            //TODO: ler da configuracao o path default
            _defaultPath = AppDomain.CurrentDomain.BaseDirectory;
        }

        public IStorage GetInstance()
        {
            return new FileSystemStorage(_defaultPath);
        }
    }
}