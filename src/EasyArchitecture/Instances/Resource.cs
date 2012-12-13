using EasyArchitecture.Internal;
using EasyArchitecture.Plugins;

namespace EasyArchitecture.Instances
{
    public class Resource
    {
        private readonly EasyConfig _easyCofig;
        private readonly IResourcePlugin _plugin;

        internal Resource(EasyConfig easyCofig)
        {
            _easyCofig = easyCofig;

            _plugin = (IResourcePlugin )_easyCofig.Plugins[typeof(IResourcePlugin )];
        }
    }
}