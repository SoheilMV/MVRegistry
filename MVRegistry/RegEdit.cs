using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using MVRegistry.KeyValue;
using System.Security.Principal;

namespace MVRegistry
{
    public class RegEdit : IDisposable
    {
        IRegKey _regkey;
        IRegValue _regvalue;

        public RegEdit()
        {
            _regkey = new RegKey();
            _regvalue = new RegValue();
        }

        public RegEdit(HKEY hkey, string address)
        {
            HKEY = hkey;
            Address = address;
            _regkey = new RegKey();
            _regvalue = new RegValue();
        }

        public IRegKey Key
        {
            get
            {
                return _regkey;
            }
        }

        public IRegValue Value
        {
            get
            {
                return _regvalue;
            }
        }

        public HKEY HKEY
        {
            get
            {
                return Config.HKEY;
            }
            set
            {
                Config.HKEY = value;
            }
        }

        public string Address
        {
            get
            {
                return Config.Address;
            }
            set
            {
                Config.Address = Corrector(value);
            }
        }

        public bool IsRunAsAdmin()
        {
            bool isAdmin;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
            }
            catch (Exception ex)
            {
                isAdmin = false;
            }
            return isAdmin;
        }

        private string Corrector(string address)
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

        public void Dispose()
        {
            _regkey.Dispose();
            _regvalue.Dispose();
        }
    }
}
