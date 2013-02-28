using System;

namespace EasyArchitecture.Plugin.Contracts.Storage
{
    public interface IStorage
    {
        Guid Save(byte[] buffer);
        byte[] Get(Guid id);
        bool Exists (Guid id);
    }
}
