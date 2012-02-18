using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;
using CodePlex.Web;

namespace ImplicitQueryString.Tests
{
    [TestClass]
    public class ImpilicitQueryStringTest
    {
        enum MyEnum
        {
            Hoge = 0,
            Huga = 10,
            Tako = 100
        }

        NameValueCollection nvc = new NameValueCollection 
        {
            { "successInt", "100" },
            { "failedInt", "x300" },
            { "successString", "hoge" },
            { "enum1", "Huga" },
            { "enum2", "100" },
            { "successUriEncodeString", Uri.EscapeDataString("+-=>") },
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
        }

        [TestMethod]
        public void ParseEnum()
        {
            
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