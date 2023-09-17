namespace Genealogy.Gedcom.Gedcom5.Enums {

    /// <summary>
    /// A code value that represents the character set to be used to interpret this data.Currently, the
    /// preferred character set is ANSEL, which includes ASCII as a subset. UNICODE is not widely
    /// supported by most operating systems; therefore, GEDCOM produced using the UNICODE character
    /// set will be limited in its interchangeability for a while but should eventually provide the international
    /// flexibility that is desired.See Chapter 3, starting on page 77.
    /// [ ANSEL |UTF-8 | UNICODE | ASCII ]
    /// Note:The IBMPC character set is not allowed.This character set cannot be interpreted properly
    /// without knowing which code page the sender was using.
    /// </summary>
    public enum CHARACTER_SET {
        ANSEL = 1,
        UTF_8 = 2,
        UNICODE = 3,
        ASCII = 4,
    }
}
