using System;
using System.Collections.Generic;
using System.Text;

namespace ADSI.Enum
{
    /// <summary>
    /// Specifies the types of initialization to perform on a <see cref="NameTranslate">NameTranslate</see> object
    /// </summary>
    public enum ADS_NAME_INITTYPE
    {
        /// <summary>Initializes a NameTranslate object by setting the domain that the object binds to.</summary>
        ADS_NAME_INITTYPE_DOMAIN = 1,
        /// <summary>Initializes a NameTranslate object by setting the server that the object binds to.</summary>
        ADS_NAME_INITTYPE_SERVER = 2,
        /// <summary>Initializes a NameTranslate object by locating the global catalog that the object binds to.</summary>
        ADS_NAME_INITTYPE_GC = 3
    }
}
