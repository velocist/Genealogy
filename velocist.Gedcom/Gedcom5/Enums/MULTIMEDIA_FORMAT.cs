namespace velocist.Gedcom.Gedcom5.Enums {
	/// <summary>
	/// [ bmp | gif | jpg | ole | pcx | tif | wav ]
	/// Indicates the format of the multimedia data associated with the specific GEDCOM context.This
	/// allows processors to determine whether they can process the data object. Any linked files should
	/// contain the data required, in the indicated format, to process the file data.
	/// </summary>
	public enum MULTIMEDIA_FORMAT {
		BMP,
		GIF,
		JPG,
		OLE,
		PCX,
		TIF,
		WAV
	}
}
