![Tree Logo](https://raw.github.com/goyuix/ADSI/master/swirly_tree_thanks_kate_england.png) 
ADSI Managed Wrapper
====================

Why does this library exist?
----------------------------
There is an incompatibility between the ADSI COM interfaces and the DLR that prevents using the `dynamic` keyword. 
More information is available at the following Stack Overflow question: <a href="http://stackoverflow.com/questions/20961698/why-does-dynamic-method-invoke-fail-when-reflection-still-works">Why does dynamic method invoke fail when reflection still works?</a>

What does this library provide?
-------------------------------
This package provides a managed implementation to the various ADSI enumerations, interfaces and objects. It also provides some convenient overrides for the methods to allow the default ADSI behaviors without having to explicitly specify those parameters.

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
