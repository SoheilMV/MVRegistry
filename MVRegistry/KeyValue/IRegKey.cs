using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
