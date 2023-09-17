namespace Genealogy.Gedcom.Gedcom5.Enums {

    /// <summary>
    /// [ CHILD | COMPLETED | EXCLUDED | PRE-1970 |
    ///         STILLBORN | SUBMITTED | UNCLEARED ]
    /// A code indicating the status of an LDS endowment ordinance where:
    /// CHILD = Died before eight years old.
    /// COMPLETED = Completed but the date is not known.
    /// EXCLUDED = Patron excluded this ordinance from being cleared in this submission.
    /// INFANT = Died before less than one year old, baptism or endowment not required.
    /// PRE-1970 = (See pre-1970 under LDS_BAPTISM_DATE_STATUS on page 51.)
    /// STILLBORN = Stillborn, ordinance not required.
    /// SUBMITTED = Ordinance was previously submitted.
    /// UNCLEARED = Data for clearing ordinance request was insufficient.
    /// </summary>
    public enum LDS_ENDOWMENT_DATE_STATUS {
        CHILD,
        COMPLETED,
        EXCLUDED,
        PRE_1970,
        STILLBORN,
        SUBMITTED,
        UNCLEARED,
    }
}
