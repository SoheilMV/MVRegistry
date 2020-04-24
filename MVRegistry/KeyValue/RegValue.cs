using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVRegistry.KeyValue
{
    class RegValue : IRegValue
    {
        RegistryKey reg;

        public void CreateBinary(string Name, byte[] Value)
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
            reg.SetValue(Name, Value, RegistryValueKind.Binary);
            reg.Close();
        }

        public void CreateBinary(string Name, string Value)
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
            var data = Encoding.UTF8.GetBytes(Value);
            reg.SetValue(Name, data, RegistryValueKind.Binary);
            reg.Close();
        }

        public void CreateDWord(string Name, int Value)
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
            reg.SetValue(Name, Value, RegistryValueKind.DWord);
            reg.Close();
        }

        public void CreateExpandString(string Name, string Value)
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
            reg.SetValue(Name, Value, RegistryValueKind.ExpandString);
            reg.Close();
        }

        public void CreateMultiString(string Name, string[] Value)
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
            reg.SetValue(Name, Value, RegistryValueKind.MultiString);
            reg.Close();
        }

        public void CreateQWord(string Name, int Value)
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
            reg.SetValue(Name, Value, RegistryValueKind.QWord);
            reg.Close();
        }

        public void CreateString(string Name, string Value)
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
            reg.SetValue(Name, Value, RegistryValueKind.String);
            reg.Close();
        }

        public void CreateUnknown(string Name, object Value)
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
            reg.SetValue(Name, Value, RegistryValueKind.Unknown);
            reg.Close();
        }

        public void Delete(string Name)
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
            if (reg.GetValue(Name) != null)
            {
                reg.DeleteValue(Name);
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

        public string Get(string Name)
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
            string value = string.Empty;
            if (reg.GetValue(Name) != null)
            {
                value = reg.GetValue(Name).ToString();
            }
            reg.Close();
            return value;
        }
    }
}
