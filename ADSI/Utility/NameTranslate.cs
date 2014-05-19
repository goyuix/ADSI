using System;
using System.Reflection;
using ADSI.Enum;

namespace ADSI.Utility
{
    /// <summary>
    /// Translates distinguished names (DNs) among various formats as defined in the <see cref="ADS_NAME_TYPE">ADS_NAME_TYPE_ENUM</see> enumeration
    /// </summary>
    /// <remarks>Name translations are performed on the directory server.</remarks>
    public class NameTranslate
    {
        private static Type nameTranslateType = Type.GetTypeFromProgID("NameTranslate");
        private object nameTranslateObject = null;

        /// <summary>
        /// Provides an interface to translate between different <see cref="ADS_NAME_TYPE">ADS_NAME_TYPE_ENUM</see> formats.
        /// </summary>
        /// <remarks>Default constructor binds to the global catalog.</remarks>
        public NameTranslate() : this (ADS_NAME_INITTYPE.ADS_NAME_INITTYPE_GC, null)
        {
        }

        /// <summary>
        /// Provides an interface to translate between different <see cref="ADS_NAME_TYPE">ADS_NAME_TYPE_ENUM</see> formats.
        /// </summary>
        /// <param name="InitType">Type of initialization to be performed.</param>
        /// <param name="Path">The name of the server or domain, depending on the value of lnInitType. When ADS_NAME_INITTYPE_GC is issued, this parameter is ignored. The global catalog server of the domain of the current computer will perform the name translate operations. This method will fail if the computer is not part of a domain as no global catalog will be found in this scenario.</param>
        public NameTranslate(ADS_NAME_INITTYPE InitType, string Path)
        {
            nameTranslateObject = Activator.CreateInstance(nameTranslateType);
            nameTranslateType.InvokeMember("Init", BindingFlags.InvokeMethod, null, nameTranslateObject, new object[] { (int)InitType, Path ?? String.Empty });
        }

        /// <summary>
        /// Provides an interface to translate between different <see cref="ADS_NAME_TYPE">ADS_NAME_TYPE_ENUM</see> formats.
        /// </summary>
        /// <param name="InitType">Type of initialization to be performed.</param>
        /// <param name="Path">The name of the server or domain, depending on the value of lnInitType. When ADS_NAME_INITTYPE_GC is issued, this parameter is ignored. The global catalog server of the domain of the current computer will perform the name translate operations. This method will fail if the computer is not part of a domain as no global catalog will be found in this scenario.</param>
        /// <param name="UserID">User name.</param>
        /// <param name="Domain">User domain name.</param>
        /// <param name="Password">User password.</param>
        public NameTranslate(ADS_NAME_INITTYPE InitType, string Path, string UserID, string Domain, string Password)
        {
            nameTranslateObject = Activator.CreateInstance(nameTranslateType);
            uint result = (uint)nameTranslateType.InvokeMember("InitEx", BindingFlags.InvokeMethod, null, nameTranslateObject, new object[] { InitType, Path, UserID, Domain, Password });
        }

        /// <summary>
        /// Retrieves the name of a directory object in the specified format.
        /// </summary>
        /// <remarks>Uses ADS_NAME_TYPE_UNKNOWN as a source format causing ADSI to estimate the provided format.</remarks>
        /// <param name="Identifier"></param>
        /// <param name="ReturnType"></param>
        /// <returns>The translated account identifier in the desired format.</returns>
        public string Translate(string Identifier, ADS_NAME_TYPE ReturnType)
        {
            return Translate(Identifier, ADS_NAME_TYPE.ADS_NAME_TYPE_UNKNOWN, ReturnType);
        }

        /// <summary>
        /// Retrieves the name of a directory object in the specified format.
        /// </summary>
        /// <param name="Identifier">Distinguished name for lookup.</param>
        /// <param name="SourceType">Format for provided account identifier.</param>
        /// <param name="ReturnType">Desired return format for account identifier.</param>
        /// <returns>The translated account identifier in the desired format.</returns>
        public string Translate(string Identifier, ADS_NAME_TYPE SourceType, ADS_NAME_TYPE ReturnType)
        {
            nameTranslateType.InvokeMember("Set", BindingFlags.InvokeMethod, null, nameTranslateObject, new object[] { (int)SourceType, Identifier });
            return nameTranslateType.InvokeMember("Get", BindingFlags.InvokeMethod, null, nameTranslateObject, new object[] { (int)ReturnType }) as string;
        }
    }
}
