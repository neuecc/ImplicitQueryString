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
            { "a", "100" },
            { "b", "300" },
            { "c", "abc" } 
        };

        [TestMethod]
        public void Validation()
        {
            AssertEx.Throws<KeyNotFoundException>(() => { int x = nvc.ParseValue("notfound"); });
            AssertEx.Throws<KeyNotFoundException>(() => { var x = nvc.ParseEnum<MyEnum>("notfound"); });
            AssertEx.DoesNotThrow(() => { int x = nvc.ParseValueOrDefault("notfound", 0); });
            AssertEx.DoesNotThrow(() => { var x = nvc.ParseEnum<MyEnum>("notfound"); });
        }
    }
}
