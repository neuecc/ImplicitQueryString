using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace CodePlex.Web
{
    public static class NameValueCollectionExtensions
    {
        public static ConvertableString ParseValue(this NameValueCollection source, string key, Func<string, string> converter = null)
        {
            var values = source.GetValues(key);
            if (values == null) throw new KeyNotFoundException();

            var value = values.First();
            return new ConvertableString(converter == null ? value : converter(value));
        }

        public static T ParseEnum<T>(this NameValueCollection source, string key, Func<string, string> converter = null, bool ignoreCase = true)
            where T : struct, IComparable, IFormattable, IConvertible
        {
            var values = source.GetValues(key);
            if (values == null) throw new KeyNotFoundException();

            var value = values.First();
            return (T)Enum.Parse(typeof(T), converter == null ? value : converter(value), ignoreCase);
        }

        public static Boolean ParseValueOrDefault(this NameValueCollection source, string key, Boolean defaultValue = default(Boolean), Func<string, string> converter = null)
        {
            var values = source.GetValues(key) ?? new string[0];
            if (values.Any())
            {
                var value = values.First();
                Boolean result;
                if (value != null && Boolean.TryParse(converter == null ? value : converter(value), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public static Char ParseValueOrDefault(this NameValueCollection source, string key, Char defaultValue = default(Char), Func<string, string> converter = null)
        {
            var values = source.GetValues(key) ?? new string[0];
            if (values.Any())
            {
                var value = values.First();
                Char result;
                if (value != null && Char.TryParse(converter == null ? value : converter(value), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public static SByte ParseValueOrDefault(this NameValueCollection source, string key, SByte defaultValue = default(SByte), Func<string, string> converter = null)
        {
            var values = source.GetValues(key) ?? new string[0];
            if (values.Any())
            {
                var value = values.First();
                SByte result;
                if (value != null && SByte.TryParse(converter == null ? value : converter(value), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public static Byte ParseValueOrDefault(this NameValueCollection source, string key, Byte defaultValue = default(Byte), Func<string, string> converter = null)
        {
            var values = source.GetValues(key) ?? new string[0];
            if (values.Any())
            {
                var value = values.First();
                Byte result;
                if (value != null && Byte.TryParse(converter == null ? value : converter(value), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public static Int16 ParseValueOrDefault(this NameValueCollection source, string key, Int16 defaultValue = default(Int16), Func<string, string> converter = null)
        {
            var values = source.GetValues(key) ?? new string[0];
            if (values.Any())
            {
                var value = values.First();
                Int16 result;
                if (value != null && Int16.TryParse(converter == null ? value : converter(value), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public static UInt16 ParseValueOrDefault(this NameValueCollection source, string key, UInt16 defaultValue = default(UInt16), Func<string, string> converter = null)
        {
            var values = source.GetValues(key) ?? new string[0];
            if (values.Any())
            {
                var value = values.First();
                UInt16 result;
                if (value != null && UInt16.TryParse(converter == null ? value : converter(value), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public static Int32 ParseValueOrDefault(this NameValueCollection source, string key, Int32 defaultValue = default(Int32), Func<string, string> converter = null)
        {
            var values = source.GetValues(key) ?? new string[0];
            if (values.Any())
            {
                var value = values.First();
                Int32 result;
                if (value != null && Int32.TryParse(converter == null ? value : converter(value), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public static UInt32 ParseValueOrDefault(this NameValueCollection source, string key, UInt32 defaultValue = default(UInt32), Func<string, string> converter = null)
        {
            var values = source.GetValues(key) ?? new string[0];
            if (values.Any())
            {
                var value = values.First();
                UInt32 result;
                if (value != null && UInt32.TryParse(converter == null ? value : converter(value), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public static Int64 ParseValueOrDefault(this NameValueCollection source, string key, Int64 defaultValue = default(Int64), Func<string, string> converter = null)
        {
            var values = source.GetValues(key) ?? new string[0];
            if (values.Any())
            {
                var value = values.First();
                Int64 result;
                if (value != null && Int64.TryParse(converter == null ? value : converter(value), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public static UInt64 ParseValueOrDefault(this NameValueCollection source, string key, UInt64 defaultValue = default(UInt64), Func<string, string> converter = null)
        {
            var values = source.GetValues(key) ?? new string[0];
            if (values.Any())
            {
                var value = values.First();
                UInt64 result;
                if (value != null && UInt64.TryParse(converter == null ? value : converter(value), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public static Single ParseValueOrDefault(this NameValueCollection source, string key, Single defaultValue = default(Single), Func<string, string> converter = null)
        {
            var values = source.GetValues(key) ?? new string[0];
            if (values.Any())
            {
                var value = values.First();
                Single result;
                if (value != null && Single.TryParse(converter == null ? value : converter(value), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public static Double ParseValueOrDefault(this NameValueCollection source, string key, Double defaultValue = default(Double), Func<string, string> converter = null)
        {
            var values = source.GetValues(key) ?? new string[0];
            if (values.Any())
            {
                var value = values.First();
                Double result;
                if (value != null && Double.TryParse(converter == null ? value : converter(value), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public static Decimal ParseValueOrDefault(this NameValueCollection source, string key, Decimal defaultValue = default(Decimal), Func<string, string> converter = null)
        {
            var values = source.GetValues(key) ?? new string[0];
            if (values.Any())
            {
                var value = values.First();
                Decimal result;
                if (value != null && Decimal.TryParse(converter == null ? value : converter(value), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public static DateTime ParseValueOrDefault(this NameValueCollection source, string key, DateTime defaultValue = default(DateTime), Func<string, string> converter = null)
        {
            var values = source.GetValues(key) ?? new string[0];
            if (values.Any())
            {
                var value = values.First();
                DateTime result;
                if (value != null && DateTime.TryParse(converter == null ? value : converter(value), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public static T ParseEnumOrDefault<T>(this NameValueCollection source, string key, T defaultValue = default(T), bool ignoreCase = true)
            where T : struct, IComparable, IFormattable, IConvertible
        {
            var values = source.GetValues(key) ?? new string[0];
            if (values.Any())
            {
                var value = values.First();
                T result;
                if (value != null && Enum.TryParse(value, ignoreCase, out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public static bool ContainsKey(this NameValueCollection source, string key)
        {
            return source.GetValues(key) != null;
        }
    }

    public struct ConvertableString
    {
        public readonly string Value;

        public ConvertableString(string value)
        {
            this.Value = value;
        }

        public static implicit operator Boolean(ConvertableString self)
        {
            return Boolean.Parse(self.Value);
        }

        public static implicit operator Boolean?(ConvertableString self)
        {
            Boolean value;
            return (self.Value != null && Boolean.TryParse(self.Value, out value))
                ? new Nullable<Boolean>(value)
                : null;
        }

        public static implicit operator Char(ConvertableString self)
        {
            return Char.Parse(self.Value);
        }

        public static implicit operator Char?(ConvertableString self)
        {
            Char value;
            return (self.Value != null && Char.TryParse(self.Value, out value))
                ? new Nullable<Char>(value)
                : null;
        }

        public static implicit operator SByte(ConvertableString self)
        {
            return SByte.Parse(self.Value);
        }

        public static implicit operator SByte?(ConvertableString self)
        {
            SByte value;
            return (self.Value != null && SByte.TryParse(self.Value, out value))
                ? new Nullable<SByte>(value)
                : null;
        }

        public static implicit operator Byte(ConvertableString self)
        {
            return Byte.Parse(self.Value);
        }

        public static implicit operator Byte?(ConvertableString self)
        {
            Byte value;
            return (self.Value != null && Byte.TryParse(self.Value, out value))
                ? new Nullable<Byte>(value)
                : null;
        }

        public static implicit operator Int16(ConvertableString self)
        {
            return Int16.Parse(self.Value);
        }

        public static implicit operator Int16?(ConvertableString self)
        {
            Int16 value;
            return (self.Value != null && Int16.TryParse(self.Value, out value))
                ? new Nullable<Int16>(value)
                : null;
        }

        public static implicit operator UInt16(ConvertableString self)
        {
            return UInt16.Parse(self.Value);
        }

        public static implicit operator UInt16?(ConvertableString self)
        {
            UInt16 value;
            return (self.Value != null && UInt16.TryParse(self.Value, out value))
                ? new Nullable<UInt16>(value)
                : null;
        }

        public static implicit operator Int32(ConvertableString self)
        {
            return Int32.Parse(self.Value);
        }

        public static implicit operator Int32?(ConvertableString self)
        {
            Int32 value;
            return (self.Value != null && Int32.TryParse(self.Value, out value))
                ? new Nullable<Int32>(value)
                : null;
        }

        public static implicit operator UInt32(ConvertableString self)
        {
            return UInt32.Parse(self.Value);
        }

        public static implicit operator UInt32?(ConvertableString self)
        {
            UInt32 value;
            return (self.Value != null && UInt32.TryParse(self.Value, out value))
                ? new Nullable<UInt32>(value)
                : null;
        }

        public static implicit operator Int64(ConvertableString self)
        {
            return Int64.Parse(self.Value);
        }

        public static implicit operator Int64?(ConvertableString self)
        {
            Int64 value;
            return (self.Value != null && Int64.TryParse(self.Value, out value))
                ? new Nullable<Int64>(value)
                : null;
        }

        public static implicit operator UInt64(ConvertableString self)
        {
            return UInt64.Parse(self.Value);
        }

        public static implicit operator UInt64?(ConvertableString self)
        {
            UInt64 value;
            return (self.Value != null && UInt64.TryParse(self.Value, out value))
                ? new Nullable<UInt64>(value)
                : null;
        }

        public static implicit operator Single(ConvertableString self)
        {
            return Single.Parse(self.Value);
        }

        public static implicit operator Single?(ConvertableString self)
        {
            Single value;
            return (self.Value != null && Single.TryParse(self.Value, out value))
                ? new Nullable<Single>(value)
                : null;
        }

        public static implicit operator Double(ConvertableString self)
        {
            return Double.Parse(self.Value);
        }

        public static implicit operator Double?(ConvertableString self)
        {
            Double value;
            return (self.Value != null && Double.TryParse(self.Value, out value))
                ? new Nullable<Double>(value)
                : null;
        }

        public static implicit operator Decimal(ConvertableString self)
        {
            return Decimal.Parse(self.Value);
        }

        public static implicit operator Decimal?(ConvertableString self)
        {
            Decimal value;
            return (self.Value != null && Decimal.TryParse(self.Value, out value))
                ? new Nullable<Decimal>(value)
                : null;
        }

        public static implicit operator DateTime(ConvertableString self)
        {
            return DateTime.Parse(self.Value);
        }

        public static implicit operator DateTime?(ConvertableString self)
        {
            DateTime value;
            return (self.Value != null && DateTime.TryParse(self.Value, out value))
                ? new Nullable<DateTime>(value)
                : null;
        }

        public static implicit operator String(ConvertableString self)
        {
            return self.Value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}