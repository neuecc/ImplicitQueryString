using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;
using Codeplex.Web;
using System.Text.RegularExpressions;

namespace ImplicitQueryString.Tests
{
    [TestClass]
    public class ImpilicitQueryStringTest
    {
        enum MyEnum
        {
            Hoge = 0,
            Huga = 10,
            Tako = 100,
            あ = 1000
        }

        NameValueCollection nvc = new NameValueCollection 
        {
            { "successInt", "100" },
            { "failedInt", "x300" },
            { "successString", "hoge" },
            { "enum1", "Huga" },
            { "enum2", "huga" },
            { "enum3", "100" },
            { "enum4", Uri.EscapeDataString("あ") },
            { "enumFail", "Noname" },
            { "dt1", "2011/10/10 12:10:10" },
            { "dt2",  Uri.EscapeDataString("2011/12/10 12:10:10") },
            { "successUriEncodeString", Uri.EscapeDataString("+-=>") },
            { "successUriEncodeString2", Uri.EscapeDataString("あ") },
        };

        [TestMethod]
        public void ParseValueInt()
        {
            int actual = nvc.ParseValue("successInt");
            actual.Is(100);

            ((int)nvc.ParseValue("successInt", x => x + x)).Is(100100);

            AssertEx.Throws<FormatException>(() =>
            {
                int failedActual = nvc.ParseValue("failedInt");
            });

            int? nullActual = nvc.ParseValue("successInt");
            nullActual.Is(100);

            int? nullActualNull = nvc.ParseValue("failedInt");
            nullActualNull.HasValue.Is(false);
        }

        [TestMethod]
        public void ParseValueString()
        {
            string actual = nvc.ParseValue("successString");
            actual.Is("hoge");

            string unescape = nvc.ParseValue("successUriEncodeString", Uri.UnescapeDataString);
            unescape.Is("+-=>");

            string unescape2 = nvc.ParseValue("successUriEncodeString2", Uri.UnescapeDataString);
            unescape2.Is("あ");
        }

        [TestMethod]
        public void ParseValueDateTime()
        {
            DateTime actual = nvc.ParseValue("dt1");
            actual.Is(new DateTime(2011, 10, 10, 12, 10, 10));

            DateTime unescape = nvc.ParseValue("dt2", Uri.UnescapeDataString);
            unescape.Is(new DateTime(2011, 12, 10, 12, 10, 10));
        }

        [TestMethod]
        public void ParseEnum()
        {
            nvc.ParseEnum<MyEnum>("enum1").Is(MyEnum.Huga);
            AssertEx.Catch<ArgumentException>(() => nvc.ParseEnum<MyEnum>("enum2").Is(MyEnum.Huga));
            nvc.ParseEnum<MyEnum>("enum2", true).Is(MyEnum.Huga);
            nvc.ParseEnum<MyEnum>("enum3").Is(MyEnum.Tako);
            nvc.ParseEnum<MyEnum>("enum4", Uri.UnescapeDataString).Is(MyEnum.あ);
        }

        [TestMethod]
        public void ParseEnumOrDefault()
        {
            nvc.ParseEnumOrDefault<MyEnum>("enum1").Is(MyEnum.Huga);
            nvc.ParseEnumOrDefault("enum1", MyEnum.Tako).Is(MyEnum.Huga);
            nvc.ParseEnumOrDefault("enumFail", MyEnum.Tako).Is(MyEnum.Tako);

            nvc.ParseEnumOrDefault<MyEnum>("enum2", MyEnum.Tako).Is(MyEnum.Tako);
            nvc.ParseEnumOrDefault<MyEnum>("enum2", MyEnum.Tako, true).Is(MyEnum.Huga);
            nvc.ParseEnumOrDefault<MyEnum>("enum2", MyEnum.Tako, x => Regex.Replace(x, "^.", s => s.Value.ToUpper())).Is(MyEnum.Huga);
        }

        [TestMethod]
        public void Nullable()
        {
            int? num = nvc.ParseValue("successInt");
            num.Is(100);

            int? num2 = nvc.ParseValue("notfound");
            num2.IsNull();
        }

        [TestMethod]
        public void ContainsKey()
        {
            nvc.ContainsKey("enum1").Is(true);
            nvc.ContainsKey("notfound").Is(false);
        }

        [TestMethod]
        public void Validation()
        {
            AssertEx.Throws<KeyNotFoundException>(() => { int x = nvc.ParseValue("notfound"); });
            AssertEx.Throws<KeyNotFoundException>(() => { var x = nvc.ParseEnum<MyEnum>("notfound"); });
            AssertEx.DoesNotThrow(() => { int x = nvc.ParseValueOrDefault("notfound", 10); });
            AssertEx.DoesNotThrow(() => { var x = nvc.ParseEnumOrDefault<MyEnum>("notfound"); });
        }
    }
}