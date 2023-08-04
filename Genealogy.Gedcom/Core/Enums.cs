namespace Genealogy.Gedcom.Core {

	internal enum RecordTypes {
		[Tag(StringTags.FAMILY)]
		FAM_RECORD = 1,
		[Tag(StringTags.INDIVIDUAL)]
		INDIVIDUAL_RECORD = 2,
		[Tag(StringTags.OBJECT)]
		MULTIMEDIA_RECORD = 3,
		[Tag(StringTags.NOTE)]
		NOTE_RECORD = 4,
		[Tag(StringTags.REPOSITORY)]
		REPOSITORY_RECORD = 5,
		[Tag(StringTags.SOURCE)]
		SOURCE_RECORD = 6,
		[Tag(StringTags.SUBMISSION)]
		SUBMISSION_RECORD = 7,
		[Tag(StringTags.SUBMITTER)]
		SUBMITTER_RECORD = 8
	}

	internal enum PointerType {
		Pointer = 1,
		Reference = 2,
	}

	internal enum Delim {
		SpaceCharacter
	}

	internal enum AttributeType {
		TagAttribute = 1,
		DescriptionAttribute = 2,
	}
}
