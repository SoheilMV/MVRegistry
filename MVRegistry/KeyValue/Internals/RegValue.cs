using System;
using System.Text;
using Microsoft.Win32;

namespace MVRegistry.KeyValue
{
    internal class RegValue : IRegValue, IDisposable
    {
        RegistryKey reg;

        public HKEY HKEY { get; set; }
        public string Path { get; set; }

        public void CreateBinary(string name, byte[] value)
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
            reg.SetValue(name, value, RegistryValueKind.Binary);
            reg.Close();
        }

        public void CreateDWord(string name, int value)
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
            reg.SetValue(name, value, RegistryValueKind.DWord);
            reg.Close();
        }

        public void CreateExpandString(string name, string value)
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
            reg.SetValue(name, value, RegistryValueKind.ExpandString);
            reg.Close();
        }

        public void CreateMultiString(string name, string[] value)
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
            reg.SetValue(name, value, RegistryValueKind.MultiString);
            reg.Close();
        }

        public void CreateQWord(string name, long value)
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
            reg.SetValue(name, value, RegistryValueKind.QWord);
            reg.Close();
        }

        public void CreateString(string name, string value)
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
            reg.SetValue(name, value, RegistryValueKind.String);
            reg.Close();
        }

        public void CreateUnknown(string name, object value)
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
            reg.SetValue(name, value, RegistryValueKind.Unknown);
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
            if (reg.GetValue(name) != null)
            {
                reg.DeleteValue(name);
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
            string[] reglist = reg.GetValueNames();
            reg.Close();
            return reglist;
        }

        public object GetValue(string name)
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
            object value = reg.GetValue(name);
            reg.Close();
            return value;
        }

        public void Dispose()
        {
            reg.Close();
            reg.Dispose();
        }
    }
}
