using ADSI.Enum;
using ADSI.Utility;
using NUnit.Framework;

namespace ADSI.Tests.Utility
{
    [TestFixture]
    class NameTranslateNUnitTests
    {
        [Test]
        public void TranslateBasicTest()
        {
            // Arrange
            var principal = System.Security.Principal.WindowsIdentity.GetCurrent();
            var nto = new NameTranslate();

            // Action
            var dn = nto.Translate(principal.Name, ADS_NAME_TYPE.ADS_NAME_TYPE_1779);
            var nt = nto.Translate(dn, ADS_NAME_TYPE.ADS_NAME_TYPE_NT4);

            // Assert
            Assert.That(principal.Name, Is.EqualTo(nt).IgnoreCase);
        }
    }
}
