using Microsoft.Win32;
using System;
using System.Text;

namespace MVRegistry.KeyValue
{
    internal class RegValue : IRegValue, IDisposable
    {
        RegistryKey reg;

        public void CreateBinary(string name, byte[] value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name is empty");

            if (Config.HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Config.Address, true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Config.Address, true);
            reg.SetValue(name, value, RegistryValueKind.Binary);
            reg.Close();
        }

        public void CreateBinary(string name, string value, Encoding encoding)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name is empty");

            if (Config.HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Config.Address, true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Config.Address, true);
            var data = encoding.GetBytes(value);
            reg.SetValue(name, data, RegistryValueKind.Binary);
            reg.Close();
        }

        public void CreateDWord(string name, int value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name is empty");

            if (Config.HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Config.Address, true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Config.Address, true);
            reg.SetValue(name, value, RegistryValueKind.DWord);
            reg.Close();
        }

        public void CreateExpandString(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name is empty");

            if (Config.HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Config.Address, true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Config.Address, true);
            reg.SetValue(name, value, RegistryValueKind.ExpandString);
            reg.Close();
        }

        public void CreateMultiString(string name, string[] value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name is empty");

            if (Config.HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Config.Address, true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Config.Address, true);
            reg.SetValue(name, value, RegistryValueKind.MultiString);
            reg.Close();
        }

        public void CreateQWord(string name, int value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name is empty");

            if (Config.HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Config.Address, true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Config.Address, true);
            reg.SetValue(name, value, RegistryValueKind.QWord);
            reg.Close();
        }

        public void CreateString(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name is empty");

            if (Config.HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Config.Address, true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Config.Address, true);
            reg.SetValue(name, value, RegistryValueKind.String);
            reg.Close();
        }

        public void CreateUnknown(string name, object value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name is empty");

            if (Config.HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Config.Address, true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Config.Address, true);
            reg.SetValue(name, value, RegistryValueKind.Unknown);
            reg.Close();
        }

        public void Delete(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name is empty");

            if (Config.HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Config.Address, true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Config.Address, true);
            if (reg.GetValue(name) != null)
            {
                reg.DeleteValue(name);
            }
            reg.Close();
        }



        public string[] GetNames()
        {
            if (Config.HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Config.Address, true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Config.Address, true);
            string[] reglist = reg.GetValueNames();
            reg.Close();
            return reglist;
        }

        public string GetValue(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name is empty");

            if (Config.HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Config.Address, true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Config.Address, true);
            string value = string.Empty;
            if (reg.GetValue(name) != null)
            {
                value = reg.GetValue(name).ToString();
            }
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
