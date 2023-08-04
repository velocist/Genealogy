
namespace Genealogy.Gedcom.Gedcom5.Tags {

	public class GEDC {

		[Tag(StringTags.VERSION)]
		public VERSION_NUMBER VERS { get; set; }

		[Tag(StringTags.FORMAT)]
		public GEDCOM_FORM FORM { get; set; }
	}
	public class PLACE {

		[Tag(StringTags.FORMAT)]
		public PLACE_HIERARCHY FORM { get; set; }
	}

	public class SOUR {

		[Tag(StringTags.VERSION)]
		public VERSION_NUMBER VERS { get; set; }

		[Tag(StringTags.FORMAT)]
		public GEDCOM_FORM FORM { get; set; }
	}

	public class DATA {

		[Tag(StringTags.DATE)]
		public PUBLICATION_DATE DATE { get; set; }

		[Tag(StringTags.CORPORATE)]
		public COPYRIGHT_SOURCE_DATA COPR { get; set; }
	}
}
