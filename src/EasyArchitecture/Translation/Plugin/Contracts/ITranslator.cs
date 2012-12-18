namespace EasyArchitecture.Translation.Plugin.Contracts
{
    public interface ITranslator
    {
        T1 Translate<T, T1>(T p0);
        T1 Translate<T, T1>(T p0, T1 p1);
    }
}