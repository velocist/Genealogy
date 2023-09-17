namespace Genealogy.Gedcom.Gedcom5.Enums {

    /// <summary>
    /// A number that indicates the age in years, months, and days that the principal was at the time of the associated event. Any labels must come after their corresponding number, for example; 4y 8m 10d.
    /// Where:
    /// > = greater than indicated age
    /// < = less than indicated age
    /// y = a label indicating years
    /// m = a label indicating months
    /// d = a label indicating days
    /// YY = number of full years
    /// MM = number of months
    /// DDD = number of days
    /// CHILD = age < 8 years
    /// INFANT = age < 1 year
    /// STILLBORN = died just prior, at, or near birth, 0 years
    /// </summary>
    public enum AGE_AT_EVENT {
        NULL = 0,
        /// <summary>
        /// |
        /// </summary>
        CONT = 1,
        YYy_MMm_DDDd = 2,
        YYy = 3,
        MMm = 4,
        DDDd = 5,
        YYy_MMm = 6,
        YYy_DDDd = 7,
        MMm_DDDd = 8,
        /// <summary>
        /// age < 8 years
        /// </summary>
        CHILD = 9,
        /// <summary>
        /// age < 1 year
        /// </summary>
        INFANT = 10,
        /// <summary>
        /// died just prior, at, or near birth, 0 years
        /// </summary>
        STILLBORN = 11,

    }
}
