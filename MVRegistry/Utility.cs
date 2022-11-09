using System;
using System.IO;

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

        public static byte[] ToBytes<T>(this T input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    if (input is bool)
                        bw.Write(Convert.ToBoolean(input));
                    else if (input is byte)
                        bw.Write(Convert.ToByte(input));
                    else if (input is char)
                        bw.Write(Convert.ToChar(input));
                    else if (input is decimal)
                        bw.Write(Convert.ToDecimal(input));
                    else if (input is double)
                        bw.Write(Convert.ToDouble(input));
                    else if (input is short)
                        bw.Write(Convert.ToInt16(input));
                    else if (input is sbyte)
                        bw.Write(Convert.ToSByte(input));
                    else if (input is float)
                        bw.Write(Convert.ToSingle(input));
                    else if (input is ushort)
                        bw.Write(Convert.ToUInt16(input));
                    else if (input is uint)
                        bw.Write(Convert.ToUInt32(input));
                    else if (input is ulong)
                        bw.Write(Convert.ToUInt64(input));
                    else if (input is DateTime)
                        bw.Write(input.ToString());
                    else
                        throw new NotSupportedException("This type is not supported.");
                }
                return ms.ToArray();
            }
        }

        public static byte[] ToBytes<T>(this T[] input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    if (input is bool[])
                    {
                        bool[] bools = input as bool[];
                        bw.Write(bools.Length);
                        foreach (var item in bools)
                        {
                            bw.Write(item);
                        }
                    }
                    else if (input is char[])
                    {
                        char[] chars = input as char[];
                        bw.Write(chars.Length);
                        bw.Write(chars);
                    }
                    else if (input is decimal[])
                    {
                        decimal[] decimals = input as decimal[];
                        bw.Write(decimals.Length);
                        foreach (var item in decimals)
                        {
                            bw.Write(item);
                        }
                    }
                    else if (input is double[])
                    {
                        double[] doubles = input as double[];
                        bw.Write(doubles.Length);
                        foreach (var item in doubles)
                        {
                            bw.Write(item);
                        }
                    }
                    else if (input is short[])
                    {
                        short[] shorts = input as short[];
                        bw.Write(shorts.Length);
                        foreach (var item in shorts)
                        {
                            bw.Write(item);
                        }
                    }
                    else if (input is int[])
                    {
                        int[] ints = input as int[];
                        bw.Write(ints.Length);
                        foreach (var item in ints)
                        {
                            bw.Write(item);
                        }
                    }
                    else if (input is long[])
                    {
                        long[] longs = input as long[];
                        bw.Write(longs.Length);
                        foreach (var item in longs)
                        {
                            bw.Write(item);
                        }
                    }
                    else if (input is sbyte[])
                    {
                        sbyte[] sbytes = input as sbyte[];
                        bw.Write(sbytes.Length);
                        foreach (var item in sbytes)
                        {
                            bw.Write(item);
                        }
                    }
                    else if (input is float[])
                    {
                        float[] floats = input as float[];
                        bw.Write(floats.Length);
                        foreach (var item in floats)
                        {
                            bw.Write(item);
                        }
                    }
                    else if (input is ushort[])
                    {
                        ushort[] ushorts = input as ushort[];
                        bw.Write(ushorts.Length);
                        foreach (var item in ushorts)
                        {
                            bw.Write(item);
                        }
                    }
                    else if (input is uint[])
                    {
                        uint[] uints = input as uint[];
                        bw.Write(uints.Length);
                        foreach (var item in uints)
                        {
                            bw.Write(item);
                        }
                    }
                    else if (input is ulong[])
                    {
                        ulong[] ulongs = input as ulong[];
                        bw.Write(ulongs.Length);
                        foreach (var item in ulongs)
                        {
                            bw.Write(item);
                        }
                    }
                    else
                        throw new NotSupportedException("This type is not supported.");
                }
                return ms.ToArray();
            }
        }

        public static object ToObject<T>(this byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                using (BinaryReader br = new BinaryReader(ms))
                {
                    T result = default(T);

                    if (result is bool)
                        return br.ReadBoolean();
                    else if (result is byte)
                        return br.ReadByte();
                    else if (result is char)
                        return br.ReadChar();
                    else if (result is decimal)
                        return br.ReadDecimal();
                    else if (result is double)
                        return br.ReadDouble();
                    else if (result is short)
                        return br.ReadInt16();
                    else if (result is sbyte)
                        return br.ReadSByte();
                    else if (result is float)
                        return br.ReadSingle();
                    else if (result is ushort)
                        return br.ReadUInt16();
                    else if (result is uint)
                        return br.ReadUInt32();
                    else if (result is ulong)
                        return br.ReadUInt64();
                    else if (result is DateTime)
                        return DateTime.Parse(br.ReadString());
                    else
                        throw new NotSupportedException("This type is not supported");
                }
            }
        }

        public static object ToObjects<T>(this byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                using (BinaryReader br = new BinaryReader(ms))
                {
                    T result = default(T);

                    if (result is bool)
                    {
                        int length = br.ReadInt32();
                        bool[] bools = new bool[length];
                        for (int i = 0; i < length; i++)
                        {
                            bools[i] = br.ReadBoolean();
                        }
                        return bools;
                    }
                    else if (result is char)
                    {
                        int length = br.ReadInt32();
                        char[] chars = new char[length];
                        br.Read(chars, 0, chars.Length);
                        return chars;
                    }
                    else if (result is decimal)
                    {
                        int length = br.ReadInt32();
                        decimal[] decimals = new decimal[length];
                        for (int i = 0; i < length; i++)
                        {
                            decimals[i] = br.ReadDecimal();
                        }
                        return decimals;
                    }
                    else if (result is double)
                    {
                        int length = br.ReadInt32();
                        double[] doubles = new double[length];
                        for (int i = 0; i < length; i++)
                        {
                            doubles[i] = br.ReadDouble();
                        }
                        return doubles;
                    }
                    else if (result is short)
                    {
                        int length = br.ReadInt32();
                        short[] shorts = new short[length];
                        for (int i = 0; i < length; i++)
                        {
                            shorts[i] = br.ReadInt16();
                        }
                        return shorts;
                    }
                    else if (result is int)
                    {
                        int length = br.ReadInt32();
                        int[] ints = new int[length];
                        for (int i = 0; i < length; i++)
                        {
                            ints[i] = br.ReadInt16();
                        }
                        return ints;
                    }
                    else if (result is long)
                    {
                        int length = br.ReadInt32();
                        long[] longs = new long[length];
                        for (int i = 0; i < length; i++)
                        {
                            longs[i] = br.ReadInt16();
                        }
                        return longs;
                    }
                    else if (result is sbyte)
                    {
                        int length = br.ReadInt32();
                        sbyte[] sbytes = new sbyte[length];
                        for (int i = 0; i < length; i++)
                        {
                            sbytes[i] = br.ReadSByte();
                        }
                        return sbytes;
                    }
                    else if (result is float)
                    {
                        int length = br.ReadInt32();
                        float[] floats = new float[length];
                        for (int i = 0; i < length; i++)
                        {
                            floats[i] = br.ReadSingle();
                        }
                        return floats;
                    }
                    else if (result is ushort)
                    {
                        int length = br.ReadInt32();
                        ushort[] ushorts = new ushort[length];
                        for (int i = 0; i < length; i++)
                        {
                            ushorts[i] = br.ReadUInt16();
                        }
                        return ushorts;
                    }
                    else if (result is uint)
                    {
                        int length = br.ReadInt32();
                        uint[] uints = new uint[length];
                        for (int i = 0; i < length; i++)
                        {
                            uints[i] = br.ReadUInt32();
                        }
                        return uints;
                    }
                    else if (result is ulong)
                    {
                        int length = br.ReadInt32();
                        ulong[] ulongs = new ulong[length];
                        for (int i = 0; i < length; i++)
                        {
                            ulongs[i] = br.ReadUInt64();
                        }
                        return ulongs;
                    }
                    else
                        throw new NotSupportedException("This type is not supported");
                }
            }
        }
    }
}
