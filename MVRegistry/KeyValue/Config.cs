using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVRegistry.KeyValue
{
    class Config
    {
        public static HKEY HKEY
        {
            get;
            set;
        } = HKEY.CurrentUser;

        public static string Address
        {
            get;
            set;
        } = string.Empty;
    }
}
