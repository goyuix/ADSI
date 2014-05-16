![Tree Logo](https://raw.github.com/goyuix/ADSI/master/swirly_tree_thanks_kate_england.png) 
ADSI Managed Wrapper
====================

Why does this library exist?
----------------------------
There is an incompatibility between the 
<a href="http://msdn.microsoft.com/en-us/library/aa772218.aspx">ADSI COM</a> 
interfaces and the DLR that prevents using the `dynamic` keyword. 
More information is available at the following Stack Overflow question: <a href="http://stackoverflow.com/questions/20961698/why-does-dynamic-method-invoke-fail-when-reflection-still-works">Why does dynamic method invoke fail when reflection still works?</a>

What does this library provide?
-------------------------------
This package provides a managed implementation to the various ADSI
<a href="http://msdn.microsoft.com/en-us/library/aa772192.aspx">Data Types and Constants</a>, 
<a href="http://msdn.microsoft.com/en-us/library/aa772234.aspx">Structures</a>,
<a href="http://msdn.microsoft.com/en-us/library/aa772194.aspx">Enumerations</a>,
<a href="http://msdn.microsoft.com/en-us/library/aa772201.aspx">Functions</a>,
<a href="http://msdn.microsoft.com/en-us/library/aa772202.aspx">Interfaces</a>,
<a href="http://msdn.microsoft.com/en-us/library/aa772235.aspx">System Providers</a>,
<a href="http://msdn.microsoft.com/en-us/library/aa772195.aspx">Error Codes</a>,
<a href="http://msdn.microsoft.com/en-us/library/aa772197.aspx">and Extended Error Messages</a>
It also provides some convenient overrides for the methods to allow the default ADSI behaviors without having to explicitly specify those parameters.
Currently the library targets .NET 2.0 and has been tested and used with the 4.0 framework without issues.

Example Usage
-------------
The following code uses the current user identity as an NT-style login string (domain\user) and converts it to an RFC 1779 distinguished name format:

    var principal = WindowsIdentity.GetCurrent();
    var nto = new NameTranslate();
    var dn = nto.Translate(principal.Name, ADS_NAME_TYPE.ADS_NAME_TYPE_1779);

Roadmap
-------
* 0.1 - Initial `NameTranslate` support and NuGet package
* ...
* 1.0 - Complete wrappers for all ADSI enumerations, interfaces and objects

Special Thanks
--------------
* Kate England for an attribution free icon that looks great with this project. I have never met you and we may never interact - but you have my deep gratitude!
