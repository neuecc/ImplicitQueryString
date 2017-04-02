# ImplicitQueryString

Info
---
Archive, import from Codeplex.

Features
---
* Provides five extension methods to NameValueCollection - Request.QueryString, Request.Form and other many.
* ParseValue, ParseValueOrDefault, ParseEnum<T>, ParseEnumOrDefault<T> and ContainsKey
* Implicit convert to left type. You don't need write type like ConvertAsInt().
* Direct convert value for UrlDecode.
* Support VS2008(.NET 3.5) and VS2010 or above.
* NuGet Installation support. 
* Install-Package [ImplicitQueryString](http://nuget.org/List/Packages/ImplicitQueryString)

Usage
---
```csharp
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
        
        // ContainsKey check key
        var hasFlag = qs.ContainsKey("flg"); // false
    }
}
```
