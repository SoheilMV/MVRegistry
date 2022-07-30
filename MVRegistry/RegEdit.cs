using System;
using System.Security.Principal;
using MVRegistry.KeyValue;

namespace MVRegistry
{
    public class RegEdit : IDisposable
    {
        string _path = string.Empty;
        HKEY _hkey = HKEY.CurrentUser;
        RegKey _regkey = null;
        RegValue _regvalue = null;

        public RegEdit(HKEY hkey, string path)
        {
            _regkey = new RegKey();
            _regvalue = new RegValue();
            HKEY = hkey;
            Path = path;
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
                return _hkey;
            }
            set
            {
                _hkey = value;
                _regkey.HKEY = _hkey;
                _regvalue.HKEY = _hkey;
            }
        }

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                _regkey.Path = _path;
                _regvalue.Path = _path;
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

        public void Dispose()
        {
            _regkey.Dispose();
            _regvalue.Dispose();
        }
    }
}