using System;
using System.Reflection;
using System.Security.Principal;
using System.Collections.Generic;
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

        public T Deserialize<T>()
        {
            object obj = Activator.CreateInstance(typeof(T));
            Type type = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());
            if (props.Count > 0)
            {
                if (!_regkey.Exists(type.Name))
                    return default(T);

                Path += $"\\{type.Name}";

                foreach (PropertyInfo prop in props)
                {
                    if (!prop.CanWrite)
                        continue;

                    if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(long) || prop.PropertyType == typeof(string) || prop.PropertyType == typeof(byte[]) || prop.PropertyType == typeof(string[]))
                    {
                        prop.SetValue(obj, _regvalue.GetValue(prop.Name));
                    }
                    else
                    {
                        byte[] bytes = (byte[])_regvalue.GetValue(prop.Name);

                        if (prop.PropertyType == typeof(bool))
                            prop.SetValue(obj, bytes.ToObject<bool>());
                        else if (prop.PropertyType == typeof(byte))
                            prop.SetValue(obj, bytes.ToObject<byte>());
                        else if (prop.PropertyType == typeof(char))
                            prop.SetValue(obj, bytes.ToObject<char>());
                        else if (prop.PropertyType == typeof(decimal))
                            prop.SetValue(obj, bytes.ToObject<decimal>());
                        else if (prop.PropertyType == typeof(double))
                            prop.SetValue(obj, bytes.ToObject<double>());
                        else if (prop.PropertyType == typeof(short))
                            prop.SetValue(obj, bytes.ToObject<short>());
                        else if (prop.PropertyType == typeof(sbyte))
                            prop.SetValue(obj, bytes.ToObject<sbyte>());
                        else if (prop.PropertyType == typeof(float))
                            prop.SetValue(obj, bytes.ToObject<float>());
                        else if (prop.PropertyType == typeof(ushort))
                            prop.SetValue(obj, bytes.ToObject<ushort>());
                        else if (prop.PropertyType == typeof(uint))
                            prop.SetValue(obj, bytes.ToObject<uint>());
                        else if (prop.PropertyType == typeof(ulong))
                            prop.SetValue(obj, bytes.ToObject<ulong>());
                        else if (prop.PropertyType == typeof(DateTime))
                            prop.SetValue(obj, bytes.ToObject<DateTime>());
                        else if (prop.PropertyType == typeof(bool[]))
                            prop.SetValue(obj, bytes.ToObjects<bool>());
                        else if (prop.PropertyType == typeof(char[]))
                            prop.SetValue(obj, bytes.ToObjects<char>());
                        else if (prop.PropertyType == typeof(decimal[]))
                            prop.SetValue(obj, bytes.ToObjects<decimal>());
                        else if (prop.PropertyType == typeof(double[]))
                            prop.SetValue(obj, bytes.ToObjects<double>());
                        else if (prop.PropertyType == typeof(short[]))
                            prop.SetValue(obj, bytes.ToObjects<short>());
                        else if (prop.PropertyType == typeof(int[]))
                            prop.SetValue(obj, bytes.ToObjects<int>());
                        else if (prop.PropertyType == typeof(long[]))
                            prop.SetValue(obj, bytes.ToObjects<long>());
                        else if (prop.PropertyType == typeof(sbyte[]))
                            prop.SetValue(obj, bytes.ToObjects<sbyte>());
                        else if (prop.PropertyType == typeof(float[]))
                            prop.SetValue(obj, bytes.ToObjects<float>());
                        else if (prop.PropertyType == typeof(ushort[]))
                            prop.SetValue(obj, bytes.ToObjects<ushort>());
                        else if (prop.PropertyType == typeof(uint[]))
                            prop.SetValue(obj, bytes.ToObjects<uint>());
                        else if (prop.PropertyType == typeof(ulong[]))
                            prop.SetValue(obj, bytes.ToObjects<ulong>());
                    }
                }

                Path = Path.Remove(Path.Length - (type.Name.Length + 1), type.Name.Length + 1);
            }
            else
                return default(T);

            return (T)obj;
        }

        public void Serialize(object obj)
        {
            Type type = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());
            if (props.Count > 0)
            {
                if (!_regkey.Exists(type.Name))
                    _regkey.Create(type.Name);

                Path += $"\\{type.Name}";

                foreach (PropertyInfo prop in props)
                {
                    if (!prop.CanRead)
                        continue;

                    if (prop.PropertyType == typeof(byte[]))
                        _regvalue.CreateBinary(prop.Name, (byte[])prop.GetValue(obj));
                    else if (prop.PropertyType == typeof(string))
                        _regvalue.CreateString(prop.Name, (string)prop.GetValue(obj));
                    else if (prop.PropertyType == typeof(string[]))
                        _regvalue.CreateMultiString(prop.Name, (string[])prop.GetValue(obj));
                    else if (prop.PropertyType == typeof(int))
                        _regvalue.CreateDWord(prop.Name, (int)prop.GetValue(obj));
                    else if (prop.PropertyType == typeof(long))
                        _regvalue.CreateQWord(prop.Name, (long)prop.GetValue(obj));
                    else if (prop.PropertyType == typeof(bool))
                    {
                        bool value = (bool)prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(byte))
                    {
                        byte value = (byte)prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(char))
                    {
                        char value = (char)prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(decimal))
                    {
                        decimal value = (decimal)prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(double))
                    {
                        double value = (double)prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(short))
                    {
                        short value = (short)prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(sbyte))
                    {
                        sbyte value = (sbyte)prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(float))
                    {
                        float value = (float)prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(ushort))
                    {
                        ushort value = (ushort)prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(uint))
                    {
                        uint value = (uint)prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(ulong))
                    {
                        ulong value = (ulong)prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(DateTime))
                    {
                        DateTime value = (DateTime)prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(bool[]))
                    {
                        bool[] value = (bool[])prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(char[]))
                    {
                        char[] value = (char[])prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(decimal[]))
                    {
                        decimal[] value = (decimal[])prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(double[]))
                    {
                        double[] value = (double[])prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(short[]))
                    {
                        short[] value = (short[])prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(int[]))
                    {
                        int[] value = (int[])prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(sbyte[]))
                    {
                        sbyte[] value = (sbyte[])prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(float[]))
                    {
                        float[] value = (float[])prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(ushort[]))
                    {
                        ushort[] value = (ushort[])prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(uint[]))
                    {
                        uint[] value = (uint[])prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                    else if (prop.PropertyType == typeof(ulong[]))
                    {
                        ulong[] value = (ulong[])prop.GetValue(obj);
                        _regvalue.CreateBinary(prop.Name, value.ToBytes());
                    }
                }

                Path = Path.Remove(Path.Length - (type.Name.Length + 1), type.Name.Length + 1);
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