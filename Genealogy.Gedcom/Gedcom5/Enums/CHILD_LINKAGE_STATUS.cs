namespace Genealogy.Gedcom.Gedcom5.Enums {

    /// <summary>
    /// A status code that allows passing on the users opinion of the status of a child to family link.
    /// challenged = Linking this child to this family is suspect, but the linkage has been neither proven nor
    /// disproven.
    /// [challenged | disproven | proven]
    /// disproven = There has been a claim by some that this child belongs to this family, but the linkage
    /// has been disproven.
    /// proven = There has been a claim by some that this child does not belongs to this family, but the
    ///         linkage has been proven
    /// </summary>
    public enum CHILD_LINKAGE_STATUS {
        CHALLENGED = 1,
        DISPROVEN = 2,
        PROVEN = 3,
    }
}
