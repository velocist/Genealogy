namespace velocist.Gedcom.Core {

    public enum RecordTypes {
        FAM_RECORD = 1,//FAM
        INDIVIDUAL_RECORD = 2,//INDI
        MULTIMEDIA_RECORD = 3,//OBJE
        NOTE_RECORD = 4,//NOTE
        REPOSITORY_RECORD = 5,//REPO
        SOURCE_RECORD = 6, //SOUR
        SUBMISSION_RECORD = 7, //SUBN
        SUBMITTER_RECORD = 8 //SUBM
    }

    public enum PointerType {
        Pointer = 1,
        Reference = 2,
    }

    public enum Delim {
        SpaceCharacter
    }


}
