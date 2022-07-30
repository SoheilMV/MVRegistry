namespace MVRegistry.KeyValue
{
    public interface IRegKey
    {
        void Create(string Name);
        void Delete(string Name);
        string[] GetNames();
        bool Exists(string name);
    }
}