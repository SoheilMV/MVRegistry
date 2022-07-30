using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVRegistry
{
    internal static class Utility
    {
        public static string Corrector(this string address)
        {
            if (address.Contains("HKEY_CLASSES_ROOT"))
                address = address.Replace("HKEY_CLASSES_ROOT", "");

            else if (address.Contains("HKEY_CURRENT_USER"))
                address = address.Replace("HKEY_CURRENT_USER", "");

            else if (address.Contains("HKEY_LOCAL_MACHINE"))
                address = address.Replace("HKEY_LOCAL_MACHINE", "");

            else if (address.Contains("HKEY_USERS"))
                address = address.Replace("HKEY_USERS", "");

            else if (address.Contains("HKEY_CURRENT_CONFIG"))
                address = address.Replace("HKEY_CURRENT_CONFIG", "");

            if (address.StartsWith("\\"))
                address = address.Remove(0, 1);

            return address;
        }
    }
}
