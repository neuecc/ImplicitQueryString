/*--------------------------------------------------------------------------
 * ImplicitQueryString
 * ver 1.0.0.0 (Feb. 18th, 2012)
 *
 * created and maintained by neuecc <ils@neue.cc - @neuecc on Twitter>
 * licensed under Microsoft Public License(Ms-PL)
 * http://implicitquerystring.codeplex.com/
 *--------------------------------------------------------------------------*/

---Description---

Easy way to parse QueryString and Forms variable or all other NameValueCollection.
This is Extension Methods for NameValueCollection and provides single .cs file.

* Provides four extensions methods to NameValueCollection,
  ParseValue, ParseValueOrDefault, ParseEnum<T>, ParseEnumOrDefault<T>
* Implicit convert to left type. You don't need write type like ConvertAsInt().
* Direct convert value for UrlDecode.
* Support VS2008(.NET 3.5) and VS2010 or above.
* NuGet Installation support. PM> Install-Package ImplicitQueryString

---Usage---

using Codeplex.Web; // using for NameValueCollection Extensions Methods

// ASP.NET Example
public partial class _Default : System.Web.UI.Page
{
    enum Sex
    {
        Unknown = 0, Male = 1, Female = 2
    }

    enum BloodType
    {
        Unknown, A, B, AB, O
    }

    int age;
    string name;
    DateTime? requestTime;  // nullable and DateTime suport
    bool hasChild;
    Sex sex;               // enum support
    BloodType bloodType;

    protected void Page_Load(object sender, EventArgs e)
    {
        // QueryString Example
        // a=20&n=John%3dJohn+Ab&s=1&bt=AB
        var qs = Request.QueryString;

        // ParseValue is inplicit convert to left type(int)
        age = qs.ParseValue("a"); // 20

        // direct convert support
        name = qs.ParseValue("n", HttpUtility.UrlDecode); // John=John Ab

        // ParseValue support nullable.
        // If key is not found or cannnot parse then return null.
        requestTime = qs.ParseValue("t", HttpUtility.UrlDecode); // null

        // ParseValueOrDefault returns argValue if key is not found or cannnot parse.
        hasChild = qs.ParseValueOrDefault("cld", false); // false

        // ParseEnum<T>/ParseEnumOrDefault<T> is convert to Enum.
        // can parse int number or string name both of which.
        sex = qs.ParseEnum<Sex>("s"); // Sex.Male
        // BloodType.AB
        bloodType = qs.ParseEnumOrDefault<BloodType>("bt", BloodType.Unknown);
    }
}

---Source Info---

Solution file is for Visual Studio 2010.
Version control under Mercurial.
External library reference under NuGet.
Unit test using MSTest.
Assert helper using ChainingAssertion http://chainingassertion.codeplex.com/

---History---

2012-02-18 ver 1.0.0.0
    Initial Release