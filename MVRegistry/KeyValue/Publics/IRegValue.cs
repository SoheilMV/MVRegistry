using System.Text;

namespace MVRegistry.KeyValue
{
    public interface IRegValue
    {
        void CreateBinary(string Name, byte[] Value);
        void CreateDWord(string Name, int Value);
        void CreateExpandString(string Name, string Value);
        void CreateMultiString(string Name, string[] Value);
        void CreateQWord(string Name, long Value);
        void CreateString(string Name, string Value);
        void CreateUnknown(string Name, object Value);
        void Delete(string Name);
        string[] GetNames();
        object GetValue(string Name);
    }
}