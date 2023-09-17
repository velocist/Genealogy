namespace Genealogy.Gedcom.Gedcom5.Enums {
    /// <summary>
    /// [ CANCELED | COMPLETED | DNS | EXCLUDED |
    ///         DNS/CAN | PRE-1970 | SUBMITTED | UNCLEARED ]
    /// CANCELED = Canceled and considered invalid.
    /// COMPLETED = Completed but the date is not known.
    /// EXCLUDED = Patron excluded this ordinance from being cleared in this submission.
    /// DNS = This ordinance is not authorized.
    /// DNS/CAN = This ordinance is not authorized, previous sealing cancelled.
    /// PRE-1970 = (See pre-1970 under LDS_BAPTISM_DATE_STATUS on page 51.)
    /// SUBMITTED = Ordinance was previously submitted.
    /// UNCLEARED = Data for clearing ordinance request was insufficient.
    /// </summary>

    public enum LDS_SPOUSE_SEALING_DATE_STATUS {
        CANCELED,
        COMPLETED,
        DNS,
        EXCLUDED,
        DNS_CAN,
        PRE_1970,
        SUBMITTED,
        UNCLEARED,
    }
}
