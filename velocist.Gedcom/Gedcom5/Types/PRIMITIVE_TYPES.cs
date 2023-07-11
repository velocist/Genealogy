using System.ComponentModel.DataAnnotations;
using velocist.Gedcom.Core;
using velocist.Gedcom.Gedcom5.Enums;
using velocist.Gedcom.Gedcom5.Tags;

namespace velocist.Gedcom.Gedcom5.Types {

	/// <summary>
	/// The name of the city used in the address. Isolated for sorting or indexing.
	/// </summary>
	[Tag(StringTags.CITY)]
	public class ADDRESS_CITY : PrimitiveType {
		[MinLength(1), MaxLength(60)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The name of the country that pertains to the associated address. Isolated by some systems for sorting or indexing.
	/// Used in most cases to facilitate automatic sorting of mail.
	/// </summary>
	public class ADDRESS_COUNTRY : PrimitiveType {
		[MinLength(1), MaxLength(60)]
		public string Value { get; set; }
	}

	/// <summary>
	/// An electronic address that can be used for contact such as an email address
	/// </summary>
	public class ADDRESS_EMAIL : PrimitiveType {

		[MinLength(5), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A FAX telephone number appropriate for sending data facsimiles.
	/// </summary>
	public class ADDRESS_FAX : PrimitiveType {

		[MinLength(1), MaxLength(60)]
		public string Value { get; set; }
	}

	/// <summary>
	/// Typically used to define a mailing address of an individual when used subordinate to a RESIdent tag.
	/// When it is used subordinate to an event tag it is the address of the place where the event took place.
	/// The address lines usually contain the addressee’s name and other street and city information so that it forms an address that meets mailing requirements.
	/// </summary>
	public class ADDRESS_LINE : PrimitiveType {
		[MinLength(1), MaxLength(60)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The first line of the address used for indexing. 
	/// This is the value of the line corresponding to the ADDR tag line in the address structure.
	/// </summary>
	public class ADDRESS_LINE1 : PrimitiveType {
		[MinLength(1), MaxLength(60)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The second line of the address used for indexing. 
	/// This is the value of the first CONT line subordinate to the ADDR tag in the address structure. 
	/// </summary>
	public class ADDRESS_LINE2 : PrimitiveType {
		[MinLength(1), MaxLength(60)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The third line of the address used for indexing. 
	/// This is the value of the second CONT line subordinate to the ADDR tag in the address structure.
	/// </summary>
	public class ADDRESS_LINE3 : PrimitiveType {
		[MinLength(1), MaxLength(60)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The ZIP or postal code used by the various localities in handling of mail. Isolated for sorting or indexing.
	/// </summary>
	public class ADDRESS_POSTAL_CODE : PrimitiveType {
		[MinLength(1), MaxLength(10)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The name of the state used in the address. Isolated for sorting or indexing.
	/// </summary>
	public class ADDRESS_STATE : PrimitiveType {
		[MinLength(1), MaxLength(60)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The world wide web page address.
	/// </summary>
	public class ADDRESS_WEB_PAGE : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A code which shows which parent in the associated family record adopted this person.
	/// </summary>
	public class ADOPTED_BY_WHICH_PARENT : PrimitiveType {
		[MinLength(1), MaxLength(4)]
		public Enums.ADOPTED_BY_WHICH_PARENT Value { get; set; }
	}

	/// <summary>
	/// A number that indicates the age in years, months, and days that the principal was at the time of the associated event. Any labels must come after their corresponding number, for example; 4y 8m 10d.
	/// </summary>
	public class AGE_AT_EVENT : PrimitiveType {
		[MinLength(1), MaxLength(4)]
		public Enums.AGE_AT_EVENT Value { get; set; }
	}

	/// <summary>
	/// A unique permanent record number of an individual record contained in the Family History Department's Ancestral File.
	/// </summary>
	[Tag(StringTags.ANCESTRAL_FILE_NUMBER)]
	public class ANCESTRAL_FILE_NUMBER : PrimitiveType {
		[MinLength(1), MaxLength(12)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A system identification name which was obtained through the GEDCOM registration process. 
	/// This name must be unique from any other product.Spaces within the name must be substituted 
	/// with a 0x5F (underscore _) so as to create one word.
	/// </summary>
	public class APPROVED_SYSTEM_ID : PrimitiveType {
		[MinLength(1), MaxLength(20)]
		public string Value { get; set; }
	}

	/// <summary>
	/// Text describing a particular characteristic or attribute assigned to an individual. This attribute value is
	/// assigned to the FACT tag.The classification of this specific attribute or fact is specified by the value
	/// of the subordinate TYPE tag selected from the EVENT_DETAIL structure. For example if you were
	/// classifying the skills a person had obtained;
	/// 1 FACT Woodworking
	///     2 TYPE Skills
	/// </summary>
	public class ATTRIBUTE_DESCRIPTOR : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// An attribute which may have caused name, addresses, phone numbers, family listings to be recorded.
	/// Its application is in helping to classify sources used for information
	/// [ CAST | EDUC | NATI | OCCU | PROP | RELI | RESI | TITL | FACT ]
	/// </summary>
	public class ATTRIBUTE_TYPE : IEVENT_ATTRIBUTE_TYPE {
		[MinLength(1), MaxLength(4)]
		public Enums.ATTRIBUTE_TYPE Value { get; set; }
	}

	/// <summary>
	/// A unique record identification number assigned to the record by the source system. This number is
	/// intended to serve as a more sure means of identification of a record for reconciling differences in data
	/// etween two interfacing systems.
	/// </summary>
	[Tag(StringTags.REC_ID_NUMBER)]
	public class AUTOMATED_RECORD_ID : PrimitiveType {
		[MinLength(1), MaxLength(12)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A name assigned to a particular group that this person was associated with, such as a particular racial
	/// group, religious group, or a group with an inherited status.
	/// </summary>
	public class CASTE_NAME : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// Used in special cases to record the reasons which precipitated an event. Normally this will be used
	/// subordinate to a death event to show cause of death, such as might be listed on a death certificate.
	/// </summary>
	public class CAUSE_OF_EVENT : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The QUAY tag's value conveys the submitter's quantitative evaluation of the credibility of a piece of
	/// information, based upon its supporting evidence.Some systems use this feature to rank multiple
	/// conflicting opinions for display of most likely information first. It is not intended to eliminate the
	/// receiver's need to evaluate the evidence for themselves.
	/// </summary>
	public class CERTAINTY_ASSESSMENT : PrimitiveType {
		[MinLength(1), MaxLength(1)]
		public Enums.CERTAINTY_ASSESSMENT Value { get; set; }
	}

	/// <summary>
	/// The date that this data was changed.
	/// </summary>
	public class CHANGE_DATE : PrimitiveType {
		[MinLength(10), MaxLength(11)]
		public string Value { get; set; }
	}

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
	public class CHARACTER_SET : PrimitiveType {
		[MinLength(1), MaxLength(8)]
		public Enums.CHARACTER_SET Value { get; set; }
		public VERSION_NUMBER VERSION { get; set; }
	}

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
	public class CHILD_LINKAGE_STATUS : PrimitiveType {
		[MinLength(1), MaxLength(8)]
		public Enums.CHILD_LINKAGE_STATUS Value { get; set; }
	}

	/// <summary>
	/// A copyright statement needed to protect the copyrights of the submitter of this GEDCOM file
	/// </summary>
	public class COPYRIGHT_GEDCOM_FILE : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A copyright statement required by the owner of data from which this information was down- loaded.
	/// For example, when a GEDCOM down-load is requested from the Ancestral File, this would be the
	/// opyright statement to indicate that the data came from a copyrighted source.
	/// </summary>
	[Tag(StringTags.COPYRIGHT)]
	public class COPYRIGHT_SOURCE_DATA : PrimitiveType {
		[MinLength(1), MaxLength(3)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The known number of children of this individual from all marriages or, if subordinate to a family
	/// record, the reported number of children known to belong to this family, regardless of whether the
	/// associated children are represented in the corresponding structure.This is not necessarily the count of
	/// children listed in a family structure.
	/// </summary>
	[Tag(StringTags.CHILDREN_COUNT)]
	public class COUNT_OF_CHILDREN : PrimitiveType {
		[MinLength(1), MaxLength(3)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The number of different families that this person was known to have been a member of as a spouse or
	/// parent, regardless of whether the associated families are represented in the GEDCOM file
	/// </summary>
	public class COUNT_OF_MARRIAGES : PrimitiveType {
		[MinLength(1), MaxLength(3)]
		public string Value { get; set; }
	}

	public class DATE : PrimitiveType {
		[MinLength(4), MaxLength(35)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ ABT<DATE> | CAL<DATE> | EST<DATE> ]
	/// Where:
	/// ABT = About, meaning the date is not exact.
	/// CAL = Calculated mathematically, for example, from an event date and age.
	/// EST = Estimated based on an algorithm using some other event date.
	/// </summary>
	public class DATE_APPROXIMATED : PrimitiveType {
		[MinLength(4), MaxLength(35)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ <DATE_GREG> | <DATE_JULN> | <DATE_HEBR> | <DATE_FREN> |
	/// <DATE_FUTURE> ]
	///The selection is based on the<DATE_CALENDAR_ESCAPE> that precedes the
	///<DATE_CALENDAR> value immediately to the left.If<DATE_CALENDAR_ESCAPE> doesn't
	///appear at this point, then @#DGREGORIAN@ is assumed. No future calendar types will use words
	///(e.g., month names) from this list: FROM, TO, BEF, AFT, BET, AND, ABT, EST, CAL, or INT.
	///When only a day and month appears as a DATE value it is considered a date phrase and not a valid
	///date form.
	///Date Escape Syntax Selected
	/// @#DGREGORIAN@ <DATE_GREG>
	/// @#DJULIAN@ <DATE_JULN>
	/// @#DHEBREW@ <DATE_HEBR>
	/// @#DFRENCH R@ <DATE_FREN>
	/// @#DROMAN@ for future definition
	/// @#DUNKNOWN@ calendar not known
	/// </summary>
	public class DATE_CALENDAR : PrimitiveType {
		[MinLength(4), MaxLength(35)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ @#DHEBREW@ | @#DROMAN@ | @#DFRENCH R@ | @#DGREGORIAN@ | @#DJULIAN@ | @#DUNKNOWN@ ]
	/// The date escape determines the date interpretation by signifying which<DATE_CALENDAR> to use.
	/// The default calendar is the Gregorian calendar.
	/// </summary>
	public class DATE_CALENDAR_ESCAPE : PrimitiveType {
		[MinLength(4), MaxLength(15)]
		public string Value { get; set; }
	}

	public class DATE_EXACT : PrimitiveType {
		[MinLength(10), MaxLength(11)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ <YEAR>[B.C.] | <MONTH_FREN> <YEAR> | <DAY> <MONTH_FREN> <YEAR> ]
	/// See<MONTH_FREN>
	/// </summary>
	public class DATE_FREN : PrimitiveType {
		[MinLength(4), MaxLength(35)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ <YEAR_GREG>[B.C.] | <MONTH> <YEAR_GREG> |
	/// <DAY> <MONTH> <YEAR_GREG> ]
	/// See<YEAR_GREG>
	/// </summary>
	public class DATE_GREG : PrimitiveType {
		[MinLength(4), MaxLength(35)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ <YEAR>[B.C.] | <MONTH_HEBR> <YEAR> | <DAY> <MONTH_HEBR> <YEAR> ]
	/// See<MONTH_HEBR>
	/// </summary>
	public class DATE_HEBR : PrimitiveType {
		[MinLength(4), MaxLength(35)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ <YEAR>[B.C.] | <MONTH> <YEAR> | <DAY> <MONTH> <YEAR> ]
	/// </summary>
	public class DATE_JULN : PrimitiveType {
		[MinLength(4), MaxLength(35)]
		public string Value { get; set; }
	}

	/// <summary>
	/// <DATE_VALUE>
	/// LDS ordinance dates use only the Gregorian date and most often use the form of day, month, and
	/// year.Only in rare instances is there a partial date.The temple tag and code should always accompany
	/// temple ordinance dates.Sometimes the LDS_(ordinance)_DATE_STATUS is used to indicate that an
	/// ordinance date and temple code is not required, such as when BIC is used. (See
	/// LDS_(ordinance) _DATE_STATUS definitions
	/// </summary>
	public class DATE_LDS_ORD : PrimitiveType {
		[MinLength(4), MaxLength(35)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ FROM<DATE> | TO<DATE> | FROM<DATE> TO<DATE> ]
	/// Where:
	/// FROM = Indicates the beginning of a happening or state.
	/// TO = Indicates the ending of a happening or state.
	/// Examples:
	/// FROM 1904 to 1915
	/// = The state of some attribute existed from 1904 to 1915 inclusive.
	/// FROM 1904
	/// = The state of the attribute began in 1904 but the end date is unknown.
	/// TO 1915
	/// = The state ended in 1915 but the begin date is unknown.
	/// </summary>
	public class DATE_PERIOD : PrimitiveType {
		[MinLength(7), MaxLength(35)]
		public string Value { get; set; }
	}

	/// <summary>
	/// Any statement offered as a date when the year is not recognizable to a date parser, but which gives
	/// information about when an event occurred.
	/// </summary>
	public class DATE_PHRASE : PrimitiveType {
		[MinLength(1), MaxLength(35)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ BEF<DATE> | AFT<DATE> | BET<DATE> AND<DATE> ]
	/// Where:
	/// AFT = Event happened after the given date.
	/// BEF = Event happened before the given date.
	/// BET = Event happened some time between date 1 AND date 2. For example, bet 1904 and 1915
	/// indicates that the event state (perhaps a single day) existed somewhere between 1904 and
	/// 1915 inclusive.
	/// The date range differs from the date period in that the date range is an estimate that an event happened
	/// on a single date somewhere in the date range specified.
	/// The following are equivalent and interchangeable:
	/// Short form Long Form
	/// 1852 BET 1 JAN 1852 AND 31 DEC 1852
	/// 1852 BET 1 JAN 1852 AND DEC 1852
	/// 1852 BET JAN 1852 AND 31 DEC 1852
	/// 1852 BET JAN 1852 AND DEC 1852
	/// JAN 1920 BET 1 JAN 1920 AND 31 JAN 1920
	/// </summary>
	public class DATE_RANGE : PrimitiveType {
		[MinLength(8), MaxLength(35)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ <DATE> | <DATE_PERIOD> | <DATE_RANGE>| <DATE_APPROXIMATED> | INT<DATE>(<DATE_PHRASE>) | (<DATE_PHRASE>) ]
	/// The DATE_VALUE represents the date of an activity, attribute, or event where:
	/// INT = Interpreted from knowledge about the associated date phrase included in parentheses. 
	/// </summary>
	public class DATE_VALUE : PrimitiveType {
		[MinLength(1), MaxLength(35)]
		public string Value { get; set; }
	}

	/// <summary>
	/// Day of the month, where dd is a numeric digit whose value is within the valid range of the days for the        associated calendar month.
	/// dd
	/// </summary>
	public class DAY : PrimitiveType {
		[MinLength(1), MaxLength(2)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The title of a work, record, item, or object.
	/// </summary>
	public class DESCRIPTIVE_TITLE : PrimitiveType {
		[MinLength(1), MaxLength(248)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A single digit (0-9).
	/// </summary>
	public class DIGIT : PrimitiveType {

		[MinLength(1), MaxLength(1)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The date that this event data was entered into the original source document.
	/// </summary>
	public class ENTRY_RECORDING_DATE : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public DATE_VALUE Value { get; set; }
	}

	/// <summary>
	/// A code that classifies the principal event or happening that caused the source record entry to be
	/// created.If the event or attribute doesn't translate to one of these tag codes, then a user supplied value
	/// is expected and will be generally classified in the category of other.
	/// [ <EVENT_TYPE_INDIVIDUAL> | <EVENT_TYPE_FAMILY> | <ATTRIBUTE_TYPE> ]
	/// </summary>
	public class EVENT_ATTRIBUTE_TYPE : PrimitiveType { //TODO
		[MinLength(1), MaxLength(15)]
		public IEVENT_ATTRIBUTE_TYPE Value { get; set; }
	}

	/// <summary>
	/// Text describing a particular event pertaining to the individual or family. This event value is usually
	///         assigned to the EVEN tag.The classification as to the difference between this specific event and other
	/// occurrences of the EVENt tag is indicated by the use of a subordinate TYPE tag selected from the
	/// EVENT_DETAIL structure.For example;
	/// 1 EVEN Appointed Zoning Committee Chairperson
	/// 2 TYPE Civic Appointments
	/// 2 DATE FROM JAN 1952 TO JAN 1956
	/// 2 PLAC Cove, Cache, Utah
	/// 2 AGNC Cove City Redevelopment
	/// </summary>
	public class EVENT_DESCRIPTOR : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A descriptive word or phrase used to further classify the parent event or attribute tag. This should be
	///         used whenever either of the generic EVEN or FACT tags are used.The value of this primative is
	/// responsible for classifying the generic event or fact being cited.For example, if the attribute being
	/// defined was one of the persons skills, such as woodworking, the FACT tag would have the value of
	/// `Woodworking', followed by a subordinate TYPE tag with the value `Skills.'
	/// 1 FACT Woodworking
	/// 2 TYPE Skills
	/// This groups the fact into a generic skills attribute, and in particular this entry records the fact that this
	/// individual possessed the skill of woodworking. Using the subordinate TYPE tag classification method
	/// with any of the other defined event tags provides a further classification of the parent tag but does not
	/// change the basic meaning of the parent tag.For example, a MARR tag could be subordinated with a
	/// TYPE tag with an EVENT_DESCRIPTOR value of `Common Law.'
	/// 1 MARR
	/// 2 TYPE Common Law
	/// </summary>
	public class EVENT_OR_FACT_CLASSIFICATION : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ <EVENT_ATTRIBUTE_TYPE> ]
	/// A code that indicates the type of event which was responsible for the source entry being recorded.For
	/// example, if the entry was created to record a birth of a child, then the type would be BIRT regardless
	/// of the assertions made from that record, such as the mother's name or mother's birth date.This will
	/// allow a prioritized best view choice and a determination of the certainty associated with the source
	/// used in asserting the cited fact.
	/// </summary>
	public class EVENT_TYPE_CITED_FROM : PrimitiveType { //TODO
		[MinLength(1), MaxLength(15)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ ANUL | CENS | DIV | DIVF | ENGA | MARR |MARB | MARC | MARL | MARS | EVEN ]
	///  A code used to indicate the type of family event. The definition is the same as the corresponding
	///  event tag defined in Appendix A.
	/// </summary>
	public class EVENT_TYPE_FAMILY : IEVENT_ATTRIBUTE_TYPE {
		[MinLength(3), MaxLength(4)]
		public Enums.EVENT_TYPE_FAMILY Value { get; set; }
	}

	/// <summary>
	/// [ ADOP | BIRT | BAPM | BARM | BASM |BLES | BURI | CENS | CHR | CHRA |CONF | CREM | DEAT | EMIG | FCOM |GRAD | IMMI | NATU | ORDN |RETI | PROB | WILL | EVEN ]
	/// A code used to indicate the type of family event. The definition is the same as the corresponding
	/// event tag defined in Appendix A.
	/// </summary>
	public class EVENT_TYPE_INDIVIDUAL : IEVENT_ATTRIBUTE_TYPE {
		[MinLength(3), MaxLength(4)]
		public Enums.EVENT_TYPE_INDIVIDUAL Value { get; set; }
	}

	/// <summary>
	/// [<EVENT_ATTRIBUTE_TYPE> |<EVENTS_RECORDED>, <EVENT_ATTRIBUTE_TYPE> ]
	/// An enumeration of the different kinds of events that were recorded in a particular source.Each
	/// enumeration is separated by a comma. Such as a parish register of births, deaths, and marriages would
	/// be BIRT, DEAT, MARR.
	/// </summary>
	public class EVENTS_RECORDED : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The name of the GEDCOM transmission file. If the file name includes a file extension it must be
	/// shown in the form(filename.ext).
	/// </summary>
	public class FILE_NAME : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A note that a user enters to describe the contents of the lineage-linked file in terms of "ancestors or
	/// descendants of" so that the person receiving the data knows what genealogical information the
	/// transmission contains.
	/// </summary>
	public class GEDCOM_CONTENT_DESCRIPTION : PrimitiveType {
		[MinLength(1), MaxLength(248)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ LINEAGE-LINKED ]
	/// The GEDCOM form used to construct this transmission. There maybe other forms used such as
	/// CommSoft's "EVENT_LINEAGE_LINKED" but these specifications define only the LINEAGELINKED Form. Systems will use this value to specify GEDCOM compatible with these
	/// specifications.
	/// </summary>
	[Tag(StringTags.FORMAT)]
	public class GEDCOM_FORM : PrimitiveType {
		[MinLength(14), MaxLength(20)]
		public Enums.GEDCOM_FORM Value { get; set; }
	}

	/// <summary>
	/// The number of generations of ancestors included in this transmission. This value is usually provided
	/// when FamilySearch programs build a GEDCOM file for a patron requesting a download of ancestors.
	/// </summary>
	[Tag(StringTags.ANCESTORS)]
	public class GENERATIONS_OF_ANCESTORS : PrimitiveType {
		[MinLength(1), MaxLength(4)]
		public string Value { get; set; }
	}

	[Tag(StringTags.DESCENDANTS)]
	public class GENERATIONS_OF_DESCENDANTS : PrimitiveType {
		[MinLength(1), MaxLength(4)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A table of valid latin language identification codes.
	/// </summary>
	public class LANGUAGE_ID : PrimitiveType {
		[MinLength(1), MaxLength(15)]
		public Enums.LANGUAGE_ID Value { get; set; }
	}

	/// <summary>
	/// [ <LANGUAGE_ID> ]
	///The human language in which the data in the transmission is normally read or written.It is used
	///primarily by programs to select language-specific sorting sequences and phonetic name matching
	///algorithms.
	/// </summary>
	public class LANGUAGE_OF_TEXT : PrimitiveType {
		[MinLength(1), MaxLength(15)]
		public LANGUAGE_ID Value { get; set; }
	}

	/// <summary>
	/// [ <LANGUAGE_ID> ]
	/// The language in which a person prefers to communicate.Multiple language preference is shown by
	/// using multiple occurrences in order of priority.
	/// </summary>
	[Tag(StringTags.LANGUAGE)]
	public class LANGUAGE_PREFERENCE : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public LANGUAGE_ID Value { get; set; }
	}

	/// <summary>
	/// [ CHILD | COMPLETED | EXCLUDED | PRE-1970 |
	///         STILLBORN | SUBMITTED | UNCLEARED ]
	/// A code indicating the status of an LDS baptism and confirmation date where:
	/// CHILD = Died before becoming eight years old, baptism not required.
	/// COMPLETED = Completed but the date is not known.
	/// EXCLUDED = Patron excluded this ordinance from being cleared in this submission.
	/// PRE-1970 = Ordinance is likely completed, another ordinance for this person was converted
	/// from temple records of work completed before 1970, therefore this ordinance is
	/// assumed to be complete until all records are converted.
	/// STILLBORN = Stillborn, baptism not required.
	/// SUBMITTED = Ordinance was previously submitted.
	/// UNCLEARED = Data for clearing ordinance request was insufficient.
	/// </summary>
	public class LDS_BAPTISM_DATE_STATUS : PrimitiveType {
		[MinLength(5), MaxLength(10)]
		public Enums.LDS_BAPTISM_DATE_STATUS Value { get; set; }
	}

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
	public class LDS_ENDOWMENT_DATE_STATUS : PrimitiveType {
		[MinLength(5), MaxLength(10)]
		public Enums.LDS_ENDOWMENT_DATE_STATUS Value { get; set; }
	}

	/// <summary>
	///         [BIC | COMPLETED | EXCLUDED | DNS | PRE-1970 |
	///  STILLBORN | SUBMITTED | UNCLEARED]
	///         BIC = Born in the covenant receiving blessing of child to parent sealing.
	///         EXCLUDED = Patron excluded this ordinance from being cleared in this submission.
	///         PRE-1970 = (See pre-1970 under LDS_BAPTISM_DATE_STATUS on page 51.)
	/// STILLBORN = Stillborn, not required.
	/// </summary>
	public class LDS_CHILD_SEALING_DATE_STATUS : PrimitiveType {
		[MinLength(3), MaxLength(10)]
		public Enums.LDS_CHILD_SEALING_DATE_STATUS Value { get; set; }
	}

	public class MONTH : PrimitiveType {
		[MaxLength(3)]
		public Enums.MONTH Value { get; set; }
	}

	public class MONTH_FREN : PrimitiveType {
		[MaxLength(4)]
		public Enums.MONTH_FREN Value { get; set; }
	}

	public class MONTH_HEBR : PrimitiveType {
		[MaxLength(3)]
		public Enums.MONTH_HEBR Value { get; set; }
	}

	/// <summary>
	/// A complete local or remote file reference to the auxiliary data to be linked to the GEDCOM context.
	/// Remote reference would include a network address where the multimedia data may be obtained.
	/// </summary>
	public class MULTIMEDIA_FILE_REFERENCE : PrimitiveType {
		[MinLength(1), MaxLength(30)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ bmp | gif | jpg | ole | pcx | tif | wav ]
	/// Indicates the format of the multimedia data associated with the specific GEDCOM context.This
	/// allows processors to determine whether they can process the data object. Any linked files should
	/// contain the data required, in the indicated format, to process the file data.
	/// </summary>
	public class MULTIMEDIA_FORMAT : PrimitiveType {
		[MinLength(3), MaxLength(4)]
		public Enums.MULTIMEDIA_FORMAT Value { get; set; }
	}

	/// <summary>
	/// Name of the business, corporation, or person that produced or commissioned the product.
	/// </summary>
	public class NAME_OF_BUSINESS : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// Name under which family names for ordinances are stored in the temple's family file.
	/// </summary>
	[Tag(StringTags.FAMILY_FILE)]
	public class NAME_OF_FAMILY_FILE : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The name of the software product that produced this transmission.
	/// </summary>
	public class NAME_OF_PRODUCT : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The official name of the archive in which the stated source material is stored.
	/// </summary>
	[Tag(StringTags.NAME)]
	public class NAME_OF_REPOSITORY : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The name of the electronic data source that was used to obtain the data in this transmission. For
	/// example, the data may have been obtained from a CD-ROM disc that was named "U.S. 1880
	/// CENSUS CD-ROM vol. 13."
	/// </summary>
	public class NAME_OF_SOURCE_DATA : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ <NAME_TEXT> | /<NAME_TEXT>/ | <NAME_TEXT> /<NAME_TEXT>/ | /<NAME_TEXT>/ <NAME_TEXT> | <NAME_TEXT> /<NAME_TEXT>/ <NAME_TEXT> ]
	/// The surname of an individual, if known, is enclosed between two slash(/) characters.The order of the
	/// name parts should be the order that the person would, by custom of their culture, have used when
	/// giving it to a recorder.Early versions of Personal Ancestral File ®
	///  and other products did not use the
	/// trailing slash when the surname was the last element of the name.If part of name is illegible, that part
	/// is indicated by an ellipsis(...). Capitalize the name of a person or place in the conventional
	/// manner— capitalize the first letter of each part and lowercase the other letters, unless conventional
	/// usage is otherwise.For example: McMurray.
	/// 55
	/// Examples:
	/// William Lee(given name only or surname not known)
	/// /Parry/ (surname only)
	/// William Lee /Parry/
	/// William Lee /Mac Parry/ (both parts (Mac and Parry) are surname parts
	/// William /Lee/ Parry(surname imbedded in the name string)
	/// William Lee /Pa.../
	/// </summary>
	public class NAME_PERSONAL : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The phonetic variation of the name is written in the same form as the was the name used in the
	///        superior<NAME_PERSONAL> primitive, but phonetically written using the method indicated //by /the
	///subordinate<PHONETIC_TYPE> value, for example if hiragana was used to provide a reading of a
	///name written in kanji, then the<PHONETIC_TYPE> value would indicate ‘kana’
	/// </summary>
	public class NAME_PHONETIC_VARIATION : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The piece of the name pertaining to the name part of interest. The surname part, the given name part, the name prefix part, or the name suffix part.
	/// </summary>
	public class NAME_PIECE : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ <NAME_PIECE> | <NAME_PIECE_GIVEN>, <NAME_PIECE> ]
	/// Given name or earned name.Different given names are separated by a comma.
	/// </summary>
	public class NAME_PIECE_GIVEN : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ <NAME_PIECE> | <NAME_PIECE_NICKNAME>, <NAME_PIECE> ]
	/// A descriptive or familiar name used in connection with one's proper name.
	/// </summary>
	public class NAME_PIECE_NICKNAME : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ <NAME_PIECE> | <NAME_PIECE_PREFIX>, <NAME_PIECE> ]
	///         Non indexing name piece that appears preceding the given name and surname //p arts.Different /name
	/// prefix parts are separated by a comma.
	/// For example:
	/// Lt.Cmndr.Joseph /Allen/ jr.
	/// In this example Lt. Cmndr. is considered as the name prefix portion.
	/// </summary>
	public class NAME_PIECE_PREFIX : PrimitiveType {
		[MinLength(1), MaxLength(30)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ <NAME_PIECE> | <NAME_PIECE_SUFFIX>, <NAME_PIECE> ]
	///         Non-indexing name piece that appears after the given name and surname parts.Different name suffix
	///         parts are separated by a comma.
	/// For example:
	/// Lt.Cmndr.Joseph /Allen/ jr.
	///         In this example jr. is considered as the name suffix portion.
	/// </summary>
	public class NAME_PIECE_SUFFIX : PrimitiveType {
		[MinLength(1), MaxLength(30)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ <NAME_PIECE> | <NAME_PIECE_SURNAME>, <NAME_PIECE> ]
	/// Surname or family name.Different surnames are separated by a comma.
	/// </summary>
	public class NAME_PIECE_SURNAME : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ <NAME_PIECE> | <NAME_PIECE_SURNAME_PREFIX>, <NAME_PIECE> ]
	/// Surname prefix or article used in a family name.Different surname articles are separated by a comma,
	/// for example in the name "de la Cruz", this value would be "de, la".
	/// </summary>
	public class NAME_PIECE_SURNAME_PREFIX : PrimitiveType {
		[MinLength(1), MaxLength(30)]
		public string Value { get; set; }
	}

	/// <summary>
	/// NAME_ROMANIZED_VARIATION:= {Size=1:120}
	/// The romanized variation of the name is written in the same form prescribed for the name used in the
	/// superior<NAME_PERSONAL> context.The method used to romanize the name is indicated by the
	/// line_value of the subordinate<ROMANIZED_TYPE>, for example if romaji was used to provide a
	/// reading of a name written in kanji, then the ROMANIZED_TYPE subordinate to the ROMN tag
	/// would indicate romaji.
	/// </summary>
	public class NAME_ROMANIZED_VARIATION : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// <TEXT> excluding commas, numbers, special characters not considered diacritics. 
	/// </summary>
	public class NAME_TEXT : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	///  [ aka | birth | immigrant | maiden | married | <user defined>]
	///         Indicates the name type, for example the name issued or assumed as an immigrant.
	///         aka = also known as, alias, etc.
	///         birth = name given on birth certificate.
	/// immigrant = name assumed at the time of immigration.
	/// maiden = maiden name, name before first marriage.
	/// married = name was persons previous married name.
	///         user_defined= other text name that defines the name type.
	/// </summary>
	public class NAME_TYPE : PrimitiveType {
		[MinLength(5), MaxLength(30)]
		public Enums.NAME_TYPE Value { get; set; }
	}

	/// <summary>
	/// A nationally-controlled number assigned to an individual. Commonly known national numbers should
	///        be assigned their own tag, such as SSN for U.S.Social Security Number.The use of the IDNO tag
	///requires a subordinate TYPE tag to identify what kind of number is being stored.
	///For example:
	///n IDNO 43-456-1899
	///+1 TYPE Canadian Health Registration
	/// </summary>
	public class NATIONAL_ID_NUMBER : PrimitiveType {
		[MinLength(1), MaxLength(30)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The person's division of national origin or other folk, house, kindred, lineage, or tribal interest.
	///         Examples: Irish, Swede, Egyptian Coptic, Sioux Dakota Rosebud, Apache Chiricawa, Navajo Bitter
	/// Water, Eastern Cherokee Taliwa Wolf, and so forth.
	/// </summary>
	public class NATIONAL_OR_TRIBAL_ORIGIN : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A user-defined tag that is contained in the GEDCOM current transmission. This tag must begin with an underscore(_) and should only be interpreted in the context of the sending system.
	/// </summary>
	public class NEW_TAG : PrimitiveType {
		[MinLength(1), MaxLength(15)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The title given to or used by a person, especially of royalty or other noble class within a locality.
	/// </summary>
	public class NOBILITY_TYPE_TITLE {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A convention that indicates the absence of any 8-bit ASCII character in the value including the null
	/// character(0x00) which is prohibited.
	/// </summary>
	public class NULL : PrimitiveType {
		[MinLength(0), MaxLength(0)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [<DIGIT> | <NUMBER>+<DIGIT>]
	/// </summary>
	public class NUMBER : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The kind of activity that an individual does for a job, profession, or principal activity.
	/// </summary>
	public class OCCUPATION : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ yes | no ]
	/// A flag that indicates whether submission should be processed for clearing temple ordinances.
	/// </summary>
	[Tag(StringTags.ORDINANCE)]
	public class ORDINANCE_PROCESS_FLAG : PrimitiveType {
		[MinLength(2), MaxLength(3)]
		public Enums.ORDINANCE_PROCESS_FLAG Value { get; set; }
	}

	/// <summary>
	/// [ adopted | birth | foster | sealing ]
	///         A code used to indicate the child to family relationship for pedigree navigation purposes.
	///         Where:
	/// adopted = indicates adoptive parents.
	/// birth = indicates birth parents.
	/// foster = indicates child was included in a foster or guardian family.
	/// sealing = indicates child was sealed to parents other than birth parents.
	/// </summary>
	public class PEDIGREE_LINKAGE_TYPE : PrimitiveType {
		[MinLength(5), MaxLength(7)]
		public Enums.PEDIGREE_LINKAGE_TYPE Value { get; set; }
	}

	/// <summary>
	/// <REGISTERED_RESOURCE_IDENTIFIER>:<RECORD_IDENTIFIER>
	///         The record number that uniquely identifies this record within a registered network resource.The
	///         number will be usable as a cross-reference pointer. The use of the colon (:) is reserved to indicate the
	/// separation of the "registered resource identifier" (which precedes the colon) and the unique "record
	/// identifier" within that resource (which follows the colon). If the colon is used, implementations that
	/// check pointers should not expect to find a matching cross-reference identifier in the transmission but
	/// would find it in the indicated database within a network.Making resource files available to a public
	/// network is a future implementation.
	/// </summary>
	[Tag(StringTags.REC_FILE_NUMBER)]
	public class PERMANENT_RECORD_FILE_NUMBER : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A phone number.
	/// </summary>
	public class PHONE_NUMBER : PrimitiveType {
		[MinLength(1), MaxLength(25)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [<user defined> | hangul | kana]
	/// Indicates the method used in transforming the text to the phonetic variation.
	/// <user define> record method used to arrive at the phonetic variation of the name.
	/// hangul Phonetic method for sounding Korean glifs.
	/// kana Hiragana and/or Katakana characters were used in sounding the Kanji character used by
	/// japanese
	/// </summary>
	public class PHONETIC_TYPE : PrimitiveType {
		[MinLength(5), MaxLength(30)]
		public string Value { get; set; }
	}

	/// <summary>
	/// An unstructured list of the attributes that describe the physical characteristics of a person, place, or
	///        object. Commas separate each attribute.
	///        Example:
	///1 DSCR Hair Brown, Eyes Brown, Height 5 ft 8 in
	///        2 DATE 23 JUL 1935
	/// </summary>
	public class PHYSICAL_DESCRIPTION : PrimitiveType {
		[MinLength(1), MaxLength(248)]
		public string Value { get; set; }
	}

	/// <summary>
	/// This shows the jurisdictional entities that are named in a sequence from the lowest to the highest
	///         jurisdiction.The jurisdictions are separated by commas, and any jurisdiction's name that is missing i s
	/// still accounted for by a comma.When a PLAC.FORM structure is included in the HEADER of a
	/// GEDCOM transmission, it implies that all place names follow this jurisdictional format and each
	/// jurisdiction is accounted for by a comma, whether the name is known or not.When the PLAC.FORM
	/// is subordinate to an event, it temporarily overrides the implications made by the PLAC.FORM
	/// structure stated in the HEADER. This usage is not common and, therefore, not encouraged. It should
	/// only be used when a system has over-structured its place-names.
	/// </summary>
	public class PLACE_HIERARCHY : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The value specifying the latitudinal coordinate of the place name. The latitude coordinate is the
	///         direction North or South from the equator in degrees and fraction of degrees carried out to give the
	///         desired accuracy.For example: 18 degrees, 9 minutes, and 3.4 seconds North would be formatted as
	/// N18.150944. Minutes and seconds are converted by dividing the minutes value by 60 and the seconds
	/// value by 3600 and adding the results together.This sum becomes the fractional part of the degree’s
	/// value.
	/// </summary>
	public class PLACE_LATITUDE : PrimitiveType {
		[MinLength(5), MaxLength(8)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The locality of the place where a living LDS ordinance took place. Typically, a living LDS baptism
	/// place would be recorded in this field.
	/// </summary>
	public class PLACE_LIVING_ORDINANCE : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public PLACE_NAME Value { get; set; }
	}

	/// <summary>
	/// The value specifying the longitudinal coordinate of the place name. The longitude coordinate is
	//         Degrees and fraction of degrees east or west of the zero or base meridian coordinate.For example:
	// 168 degrees, 9 minutes, and 3.4 seconds East would be formatted as E168.150944. 
	//         
	/// </summary>
	public class PLACE_LONGITUDE : PrimitiveType {
		[MinLength(5), MaxLength(8)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ <PLACE_TEXT> | <PLACE_TEXT>, <PLACE_NAME>]
	/// The jurisdictional name of the place where the event took place.Jurisdictions are separated by
	/// commas, for example, "Cove, Cache, Utah, USA." If the actual jurisdictional names of these places
	/// have been identified, they can be shown using a PLAC.FORM structure either in the HEADER or in
	/// the event structure. (See <PLACE_HIERARCHY>
	/// </summary>
	public class PLACE_NAME : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The phonetic variation of the place name is written in the same form as was the place name used in
	/// the superior<PLACE_NAME> primitive, but phonetically written using the method indicated by the
	/// subordinate<PHONETIC_TYPE> value, for example if hiragana was used to provide a reading of a a
	/// name written in kanji, then the<PHONETIC_TYPE> value would indicate kana. (See
	/// <PHONETIC_TYPE>
	/// </summary>
	public class PLACE_PHONETIC_VARIATION : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The romanized variation of the place name is written in the same form prescribed for the place name
	/// used in the superior<PLACE_NAME> context.The method used to romanize the name is indicated
	/// by the line_value of the subordinate<ROMANIZED_TYPE>, for example if romaji was used to
	/// provide a reading of a place name written in kanji, then the <ROMANIZED_TYPE> subordinate to
	/// the ROMN tag would indicate ‘romaji’. (See<ROMANIZED_TYPE>
	/// </summary>
	public class PLACE_ROMANIZED_VARIATION : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// <TEXT> excluding the comma(s).
	/// </summary>
	public class PLACE_TEXT : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A list of possessions (real estate or other property) belonging to this individual.
	/// </summary>
	public class POSSESSIONS : PrimitiveType {
		[MinLength(1), MaxLength(248)]
		public string Value { get; set; }
	}

	/// <summary>
	/// <DATE_EXACT>
	/// The date this source was published or created.
	/// </summary>
	[Tag(StringTags.DATE)]
	public class PUBLICATION_DATE : PrimitiveType {
		[MinLength(10), MaxLength(11)]
		public DATE_EXACT Value { get; set; }
	}

	/// <summary>
	/// The name of the system expected to process the GEDCOM-compatible transmission. The registered
	///         RECEIVING_SYSTEM_NAME for all GEDCOM submissions to the Family History Department
	/// must be one of the following names:
	/// ! "ANSTFILE" when submitting to Ancestral File.
	/// ! "TempleReady" when submitting for temple ordinance clearance.
	/// </summary>
	public class RECEIVING_SYSTEM_NAME : PrimitiveType {
		[MinLength(1), MaxLength(20)]
		public string Value { get; set; }
	}

	/// <summary>
	/// An identification number assigned to each record within a specific database. 
	/// The database to which the RECORD_IDENTIFIER pertains is indicated by the 
	/// REGISTERED_RESOURCE_NUMBER which precedes the colon(:). 
	/// If the RECORD_IDENTIFIER is not preceded by a colon, it is a reference to a
	/// record within the current GEDCOM transmission.
	/// </summary>
	public class RECORD_IDENTIFIER : PrimitiveType {
		[MinLength(1), MaxLength(18)]
		public string Value { get; set; }
	}

	/// <summary>
	/// This is an identifier assigned to a resource database that is available through access to a network. This is for future GEDCOM releases
	/// </summary>
	public class REGISTERED_RESOURCE_IDENTIFIER : PrimitiveType {
		[MinLength(1), MaxLength(25)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A word or phrase that states object 1's relation is object 2. 
	/// For example you would read the following
	/// as "Joe Jacob's great grandson is the submitter pointed to by the @XREF:SUBM@":
	/// 0 INDI
	/// 1 NAME Joe /Jacob/
	/// 1 ASSO @<XREF:SUBM>@
	/// 2 RELA great grandson
	/// </summary>
	public class RELATION_IS_DESCRIPTOR : PrimitiveType {
		[MinLength(1), MaxLength(25)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A name of the religion with which this person, event, or record was affiliated.
	/// </summary>
	public class RELIGIOUS_AFFILIATION : PrimitiveType {
		[MinLength(1), MaxLength(90)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The organization, institution, corporation, person, or other entity that has responsibility for the
	/// associated context.For example, an employer of a person of an associated occupation, or a church
	/// that administered rites or events, or an organization responsible for creating and/or archiving records.
	/// </summary>
	public class RESPONSIBLE_AGENCY : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [confidential | locked | privacy ]
	///         The restriction notice is defined for Ancestral File usage.Ancestral File download GEDCOM files
	///        may contain this data.
	///        Where:
	/// confidential = This data was marked as confidential by the user. In some systems data marked as
	/// confidential will be treated differently, for example, there might be an option that
	///        would stop confidential data from appearing on printed reports or would prevent that
	///        information from being exported.
	///        locked = Some records in Ancestral File have been satisfactorily proven by evidence, but
	///        because of source conflicts or incorrect traditions, there are repeated attempts to
	///        change this record.By arrangement, the Ancestral File Custodian can lock a record so
	///        that it cannot be changed without an agreement from the person assigned as the
	///        steward of such a record. The assigned steward is either the submitter listed for the
	///        record or Family History Support when no submitter is listed.
	///        privacy = Indicate that information concerning this record is not present due to rights of or an
	///        approved request for privacy.For example, data from requested downloads of the
	/// Ancestral File may have individuals marked with ‘privacy’ if they are assumed living,
	///        that is they were born within the last 110 years and there isn’t a death date. In certain
	///        cases family records may also be marked with the RESN tag of privacy if either
	///        individual acting in the role of HUSB or WIFE is assumed living.
	/// </summary>
	[Tag(StringTags.RESTRICTION)]
	public class RESTRICTION_NOTICE : PrimitiveType {
		[MinLength(6), MaxLength(7)]
		public Enums.RESTRICTION_NOTICE Value { get; set; }
	}

	/// <summary>
	/// A word or phrase that identifies a person's role in an event being described. This should be the same
	///        word or phrase, and in the same language, that the recorder used to define the role in the actual
	/// record.
	/// </summary>
	public class ROLE_DESCRIPTOR : PrimitiveType {
		[MinLength(1), MaxLength(25)]
		public string Value { get; set; }
	}

	/// <summary>
	/// [ CHIL | HUSB | WIFE | MOTH | FATH | SPOU | (<ROLE_DESCRIPTOR>) ]
	///         Indicates what role this person played in the event that is being cited in this context. For example, if
	/// you cite a child's birth record as the source of the mother's name, the value for this field is "MOTH." If
	///        you describe the groom of a marriage, the role is "HUSB." If the role is something different than one
	/// of the six relationship role tags listed above then enclose the role name within matching parentheses.
	/// </summary>
	public class ROLE_IN_EVENT : PrimitiveType {
		[MinLength(1), MaxLength(15)]
		public Enums.ROLE_IN_EVENT Value { get; set; }
	}

	/// <summary>
	///  [<user defined> | pinyin | romaji | wadegiles]
	/// Indicates the method used in transforming the text to a romanized variation.
	/// </summary>
	public class ROMANIZED_TYPE : PrimitiveType {
		[MinLength(5), MaxLength(30)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A description of a scholastic or educational achievement or pursuit.
	/// </summary>
	public class SCHOLASTIC_ACHIEVEMENT : PrimitiveType {
		[MinLength(1), MaxLength(248)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A code that indicates the sex of the individual:
	///   M = Male
	/// F = Female
	/// U = Undetermined from available records and quite sure that it can’t be.
	/// </summary>
	[Tag(StringTags.SEX)]
	public class SEX_VALUE : PrimitiveType {
		[MinLength(1), MaxLength(7)]
		public Enums.SEX_VALUE Value { get; set; }
	}

	/// <summary>
	/// A number assigned to a person in the United States for identification purposes.
	/// </summary>
	public class SOCIAL_SECURITY_NUMBER : PrimitiveType {
		[MinLength(9), MaxLength(11)]
		public string Value { get; set; }
	}

	/// <summary>
	/// An identification or reference description used to file and retrieve items from the holdings of a
	/// repository.
	/// </summary>
	public class SOURCE_CALL_NUMBER : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A free form text block used to describe the source from which information was obtained. This text
	///         block is used by those systems which cannot use a pointer to a source record. It must contain a
	/// descriptive title, who created the work, where and when it was created, and where the source data
	/// stored.The developer should encourage users to use an appropriate style for forming this free form
	/// bibliographic reference. Developers are encouraged to support the SOURCE_RECORD method of
	/// reporting bibliographic reference descriptions. 
	/// </summary>
	public class SOURCE_DESCRIPTION : PrimitiveType {
		[MinLength(1), MaxLength(248)]
		public string Value { get; set; }
	}
	/// <summary>
	/// The title of the work, record, or item and, when appropriate, the title of the larger work or series of which it is a part.
	///         For a published work, a book for example, might have a title plus the title of the series of which the book is a part. A magazine article would have a title plus the title of the magazine that published the article.
	///         For An unpublished work, such as:
	/// ! A letter might include the date, the sender, and the receiver.
	///         ! A transaction between a buyer and seller might have their names and the transaction date.
	///         ! A family Bible containing genealogical information might have past and present owners and a
	///         physical description of the book.
	///         ! A personal interview would cite the informant and interviewer.
	/// </summary>
	[Tag(StringTags.TITLE)]
	public class SOURCE_DESCRIPTIVE_TITLE : PrimitiveType {
		[MinLength(1), MaxLength(248)]
		public string Value { get; set; }
	}

	/// <summary>
	/// This entry is to provide a short title used for sorting, filing, and retrieving source records.
	/// </summary>
	[Tag(StringTags.ABBREVIATION)]
	public class SOURCE_FILED_BY_ENTRY : PrimitiveType {
		[MinLength(1), MaxLength(60)]
		public string Value { get; set; }
	}

	/// <summary>
	/// <PLACE_NAME>
	/// The name of the lowest jurisdiction that encompasses all lower-level places named in this source.For
	/// example, "Oneida, Idaho" would be used as a source jurisdiction place for events occurring in the
	/// various towns within Oneida County. "Idaho" would be the source jurisdiction place if the events
	/// recorded took place in other counties as well as Oneida County.
	/// </summary>
	public class SOURCE_JURISDICTION_PLACE : PrimitiveType {
		[MinLength(1), MaxLength(120)]
		public PLACE_NAME Value { get; set; }
	}

	/// <summary>
	/// [ audio | book | card | electronic | fiche | film | magazine | manuscript | map | newspaper | photo | tombstone | video ]
	/// A code, selected from one of the media classifications choices above, that indicates the type of
	/// material in which the referenced source is stored.
	/// </summary>
	public class SOURCE_MEDIA_TYPE : PrimitiveType {
		[MinLength(1), MaxLength(15)]
		public Enums.SOURCE_MEDIA_TYPE Value { get; set; }
	}

	/// <summary>
	/// The person, agency, or entity who created the record. For a published work, this could be the author,
	/// compiler, transcriber, abstractor, or editor.For an unpublished source, this may be an individual, a
	/// government agency, church organization, or private organization, etc.
	/// </summary>
	[Tag(StringTags.AUTHOR)]
	public class SOURCE_ORIGINATOR : PrimitiveType {
		[MinLength(1), MaxLength(248)]
		public string Value { get; set; }
	}
	/// <summary>
	/// When and where the record was created. For published works, this includes information such as the city of publication, 
	/// name of the publisher, and year of publication. 
	/// For an unpublished work, it includes the date the record was created and the place where it was
	/// created. For example, the county and state of residence of a person making a declaration for a pension
	/// or the city and state of residence of the writer of a letter.
	/// </summary>
	[Tag(StringTags.PUBLICATION)]
	public class SOURCE_PUBLICATION_FACTS : PrimitiveType {
		[MinLength(1), MaxLength(248)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The name of the submitter formatted for display and address generation.
	/// </summary>
	[Tag(StringTags.NAME)]
	public class SUBMITTER_NAME : PrimitiveType {
		[MinLength(1), MaxLength(60)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A registered number of a submitter of Ancestral File data. This number is used in subsequent
	/// submissions or inquiries by the submitter for identification purposes.
	/// </summary>
	public class SUBMITTER_REGISTERED_RFN : PrimitiveType {
		[MinLength(1), MaxLength(248)]
		public string Value { get; set; }
	}

	/// <summary>
	/// Comments or opinions from the submitter.
	/// </summary>
	public class SUBMITTER_TEXT : PrimitiveType {
		[MinLength(1), MaxLength(248)]
		public string Value { get; set; }
	}

	/// <summary>
	/// An abbreviation of the temple in which LDS temple ordinances were performed.
	/// </summary>
	[Tag(StringTags.TEMPLE)]
	public class TEMPLE_CODE : PrimitiveType {
		[MinLength(4), MaxLength(5)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A string composed of any valid character from the GEDCOM character set.
	/// </summary>
	public class TEXT : PrimitiveType {
		[MinLength(1), MaxLength(248)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A verbatim copy of any description contained within the source. This indicates notes or text that are
	/// actually contained in the source document, not the submitter's opinion about the source. This should
	/// be, from the evidence point of view, "what the original record keeper said" as opposed to the
	/// researcher's interpretation. The word TEXT, in this case, means from the text which appeared in the
	/// source record including labels.
	/// </summary>
	[Tag(StringTags.TEXT)]
	public class TEXT_FROM_SOURCE : PrimitiveType {
		[MinLength(1), MaxLength(248)]
		public TEXT Value { get; set; }
	}

	/// <summary>
	/// [ hh:mm:ss.fs ]
	///         The time of a specific event, usually a computer-timed event, where:
	/// hh = hours on a 24-hour clock
	///         mm = minutes
	///         ss = seconds (optional)
	///         fs = decimal fraction of a second(optional)
	/// </summary>
	public class TIME_VALUE : PrimitiveType {
		[MinLength(1), MaxLength(12)]
		public string Value { get; set; }
	}

	/// <summary>
	/// <DATE_EXACT>
	/// The date that this transmission was created
	/// </summary>
	public class TRANSMISSION_DATE : PrimitiveType {
		[MinLength(10), MaxLength(11)]
		public DATE_EXACT Value { get; set; }
	}

	/// <summary>
	/// A user-defined number or text that the submitter uses to identify this record. For instance, it may be a
	/// record number within the submitter's automated or manual system, or it may be a page and position
	/// number on a pedigree chart
	/// </summary>
	[Tag(StringTags.REFERENCE)]
	public class USER_REFERENCE_NUMBER : PrimitiveType {
		[MinLength(1), MaxLength(20)]
		public string Value { get; set; }
	}

	/// <summary>
	/// A user-defined definition of the USER_REFERENCE_NUMBER.
	/// </summary>
	public class USER_REFERENCE_TYPE : PrimitiveType {
		[MinLength(1), MaxLength(40)]
		public string Value { get; set; }
	}

	/// <summary>
	/// An identifier that represents the version level assigned to the associated product. 
	/// It is defined and
	/// changed by the creators of the product.
	/// </summary>
	[Tag(StringTags.VERSION)]
	public class VERSION_NUMBER : PrimitiveType {
		[MinLength(1), MaxLength(15)]
		public string Value { get; set; }
	}

	/// <summary>
	/// Specific location with in the information referenced. For a published work, this could include the
	/// volume of a multi-volume work and the page number(s). For a periodical, it could include volume,
	/// issue, and page numbers.For a newspaper, it could include a column number and page number.For an
	/// unpublished source or microfilmed works, this could be a film or sheet number, page number, frame
	/// number, etc.A census record might have an enumerating district, page number, line number, dwelling
	/// number, and family number.The data in this field should be in the form of a label and value pair, s uch
	/// as Label1: value, Label2: value, with each pair being separated by a comma. For example, Film:
	/// 1234567, Frame: 344, Line: 28.
	/// </summary>
	public class WHERE_WITHIN_SOURCE : PrimitiveType {
		[MinLength(1), MaxLength(248)]
		public string Value { get; set; }
	}

	/// <summary>
	/// Either a pointer or an unique cross-reference identifier. 
	/// If this element appears before the tag in a GEDCOM line, then it is a cross-reference identifier.
	/// If it appears after the tag in a GEDCOM line, then it is a pointer. 
	/// The method of delimiting a pointer or cross-reference identifier is to enclose 
	/// the pointer or cross-reference identifier  within at signs (@), for example, @I123@. 
	/// A XREF may not begin with a number sign(#). 
	/// This is to avoid confusion with an escape sequence prefix (@#). 
	/// The use of a colon (:) in the XREF is reserved for creating future network cross-references
	/// and the use of an exclamation(!) is reserved for intra-record pointers. 
	/// Uniqueness of the cross-reference identifier is required within the transmission file.
	/// </summary>
	public class XREF : PrimitiveType {

		[MinLength(1), MaxLength(22)]
		public string Values { get; set; }
		public XREF_TYPE XREF_TYPE { get; set; }
	}

	/// <summary>
	/// A numeric representation of the calendar year in which an event occurred.
	/// </summary>
	public class YEAR : PrimitiveType {
		[MinLength(3), MaxLength(4)]
		public string Value { get; set; }
	}

	/// <summary>
	/// The slash "/" <DIGIT><DIGIT> a year modifier which shows the possible date alternatives for pre1752 date brought about by a changing the beginning of the year from MAR to JAN in the English
	/// calendar change of 1752, for example, 15 APR 1699/00. A(B.C.) appended to the<YEAR> indicates
	/// a date before the birth of Christ.
	/// </summary>
	public class YEAR_GREG : PrimitiveType {
		[MinLength(3), MaxLength(7)]
		public string Value { get; set; }
	}
}
