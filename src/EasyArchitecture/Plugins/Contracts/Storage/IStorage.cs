using System;

namespace EasyArchitecture.Plugins.Contracts.Storage
{
    public interface IStorage
    {
        Guid Save(byte[] buffer);
        byte[] Get(Guid id);
        bool Exists (Guid id);
    }
}
