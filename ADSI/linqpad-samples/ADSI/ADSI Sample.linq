<Query Kind="Statements">
  <NuGetReference>ADSI.Wrapper</NuGetReference>
</Query>

// create some helper variables
var principal = System.Security.Principal.WindowsIdentity.GetCurrent();
var nto = new ADSI.Utility.NameTranslate();
var dn = nto.Translate(principal.Name, ADSI.Enum.ADS_NAME_TYPE.ADS_NAME_TYPE_1779);
var nt = nto.Translate(dn, ADSI.Enum.ADS_NAME_TYPE.ADS_NAME_TYPE_NT4);

// show results from calling Translate
(new { nt, dn }).Dump();