using System;

namespace EasyArchitecture.Storage.Plugin.Contracts
{
    public interface IStorage
    {
        Guid Save(byte[] buffer);
        byte[] Get(Guid id);
        bool Exists (Guid id);
    }
}
