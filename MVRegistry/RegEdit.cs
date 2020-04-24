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
    public class RegEdit
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
                Config.Address = value;
            }
        }

        public IRegKey Key => _regkey;
        public IRegValue Value => _regvalue;

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
    }
}
