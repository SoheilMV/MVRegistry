using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVRegistry.KeyValue
{
    public interface IRegValue
    {
        void CreateBinary(string Name, byte[] Value);
        void CreateBinary(string Name, string Value);
        void CreateDWord(string Name, int Value);
        void CreateExpandString(string Name, string Value);
        void CreateMultiString(string Name, string[] Value);
        void CreateQWord(string Name, int Value);
        void CreateString(string Name, string Value);
        void CreateUnknown(string Name, object Value);
        void Delete(string Name);
        string[] GetNames();
        string Get(string Name);
    }
}
