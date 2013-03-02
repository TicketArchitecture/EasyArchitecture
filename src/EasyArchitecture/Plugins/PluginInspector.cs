using System.Text;

namespace EasyArchitecture.Plugins
{
    public class PluginInspector
    {
        private readonly StringBuilder _typeInfo = new StringBuilder();
        private readonly StringBuilder _detailInfo = new StringBuilder();

        public PluginInspector(object plugin)
        {
            _typeInfo.AppendFormat("Assembly: {0}", plugin.GetType().Assembly.FullName);
            _typeInfo.AppendLine();
            _typeInfo.AppendFormat("Type: {0}", plugin.GetType().FullName);
            _typeInfo.AppendLine();
        }

        public void Log(string message, params object[] args)
        {
            message = "-> " + message;
            _detailInfo.AppendFormat(message, args);
            _detailInfo.AppendLine();
        }

        internal StringBuilder GetPluginTypeInfo()
        {
            return _typeInfo;
        }

        internal StringBuilder GetPluginDetailInfo()
        {
            return _detailInfo;
        }
    }
}