using System;
using Microsoft.Win32;

namespace MVRegistry.KeyValue
{
    internal class RegKey : IRegKey, IDisposable
    {
        RegistryKey reg;

        public HKEY HKEY { get; set; }
        public string Path { get; set; }

        public void Create(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name is empty");

            if (HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Path.Corrector(), true);
            else if (HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Path.Corrector(), true);
            else if (HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Path.Corrector(), true);
            else if (HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Path.Corrector(), true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Path.Corrector(), true);
            if (reg.OpenSubKey(name) == null)
            {
                reg.CreateSubKey(name);
            }
            reg.Close();
        }

        public void Delete(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name is empty");

            if (HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Path.Corrector(), true);
            else if (HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Path.Corrector(), true);
            else if (HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Path.Corrector(), true);
            else if (HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Path.Corrector(), true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Path.Corrector(), true);
            if (reg.OpenSubKey(name) != null)
            {
                reg.DeleteSubKeyTree(name);
            }
            reg.Close();
        }

        public string[] GetNames()
        {
            if (HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Path.Corrector(), true);
            else if (HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Path.Corrector(), true);
            else if (HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Path.Corrector(), true);
            else if (HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Path.Corrector(), true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Path.Corrector(), true);
            string[] reglist = reg.GetSubKeyNames();
            reg.Close();
            return reglist;
        }

        public bool Exists(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name is empty");

            if (HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Path.Corrector(), true);
            else if (HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Path.Corrector(), true);
            else if (HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Path.Corrector(), true);
            else if (HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Path.Corrector(), true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Path.Corrector(), true);

            bool allow = false;
            string[] keys = reg.GetSubKeyNames();
            foreach (var i in keys)
            {
                if (i.Contains(name))
                {
                    allow = true;
                }
            }
            reg.Close();
            return allow;
        }

        public void Dispose()
        {
            reg.Close();
            reg.Dispose();
        }
    }
}
