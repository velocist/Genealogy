namespace velocist.Gedcom.Gedcom5.Enums {
    /// <summary>
    ///         [BIC | COMPLETED | EXCLUDED | DNS | PRE-1970 |
    ///  STILLBORN | SUBMITTED | UNCLEARED]
    ///         BIC = Born in the covenant receiving blessing of child to parent sealing.
    ///         EXCLUDED = Patron excluded this ordinance from being cleared in this submission.
    ///         PRE-1970 = (See pre-1970 under LDS_BAPTISM_DATE_STATUS on page 51.)
    /// STILLBORN = Stillborn, not required.
    /// </summary>
    public enum LDS_CHILD_SEALING_DATE_STATUS {
        BIC,
        COMPLETED,
        EXCLUDED,
        DNS,
        PRE_1970,
        STILLBORN,
        SUBMITTED,
        UNCLEARED,
    }
}
