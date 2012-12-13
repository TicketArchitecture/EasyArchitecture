using System;

namespace EasyArchitecture.Storage.Plugin.Contracts
{
    public interface IStoragePlugin
    {
        Guid Save(byte[] buffer);
        byte[] Get(Guid id);
        bool Exists (Guid id);
    }
}
