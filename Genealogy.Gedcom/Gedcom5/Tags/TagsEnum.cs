﻿namespace Genealogy.Gedcom.Gedcom5.Tags {
    public enum TagsEnum {
        [Tag(StringTags.ABBREVIATION)]
        ABBREVIATION,
        [Tag(StringTags.ADDRESS)]
        ADDRESS,
        [Tag(StringTags.ADDRESS1)]
        ADDRESS1,
        [Tag(StringTags.ADDRESS2)]
        ADDRESS2,
        [Tag(StringTags.ADOPTION)]
        ADOPTION,
        [Tag(StringTags.ANCESTRAL_FILE_NUMBER)]
        ANCESTRAL_FILE_NUMBER,
        [Tag(StringTags.AGENCY)]
        AGENCY,
        [Tag(StringTags.ALIAS)]
        ALIAS,
        [Tag(StringTags.ANCESTORS)]
        ANCESTORS,
        [Tag(StringTags.ANCES_INTEREST)]
        ANCES_INTEREST,
        [Tag(StringTags.ANNULMENT)]
        ANNULMENT,
        [Tag(StringTags.ASSOCIATES)]
        ASSOCIATES,
        [Tag(StringTags.AUTHOR)]
        AUTHOR,
        [Tag(StringTags.BAPTISMLDS)]
        BAPTISMLDS,
        [Tag(StringTags.BAPTISM)]
        BAPTISM,
        [Tag(StringTags.BAR_MITZVAH)]
        BAR_MITZVAH,
        [Tag(StringTags.BAS_MITZVAH)]
        BAS_MITZVAH,
        [Tag(StringTags.BIRTH)]
        BIRTH,
        [Tag(StringTags.BLESSING)]
        BLESSING,
        [Tag(StringTags.BURI)]
        BURI,
        [Tag(StringTags.BOTH)]
        BOTH, //TODO
        [Tag(StringTags.CALL_NUMBER)]
        CALL_NUMBER,
        [Tag(StringTags.CASTE)]
        CASTE,
        [Tag(StringTags.CAUSE)]
        CAUSE,
        [Tag(StringTags.CENSUS)]
        CENSUS,
        [Tag(StringTags.CHANGE)]
        CHANGE,
        [Tag(StringTags.CHARACTER)]
        CHARACTER,
        [Tag(StringTags.CHILD)]
        CHILD,
        [Tag(StringTags.CHRISTENING)]
        CHRISTENING,
        [Tag(StringTags.ADULT_CHRISTENING)]
        ADULT_CHRISTENING,
        [Tag(StringTags.CITY)]
        CITY,
        [Tag(StringTags.CONCATENATION)]
        CONCATENATION,
        [Tag(StringTags.CONFIRMATION)]
        CONFIRMATION,
        [Tag(StringTags.CONFIRMATION_LDS)]
        CONFIRMATION_LDS,
        [Tag(StringTags.CONTINUED)]
        CONTINUED,
        [Tag(StringTags.COPYRIGHT)]
        COPYRIGHT,
        [Tag(StringTags.CORPORATE)]
        CORPORATE,
        [Tag(StringTags.CREMATION)]
        CREMATION,
        [Tag(StringTags.COUNTRY)]
        COUNTRY,
        [Tag(StringTags.DATA)]
        DATA,
        [Tag(StringTags.DATE)]
        DATE,
        [Tag(StringTags.DEATH)]
        DEATH,
        [Tag(StringTags.DESCENDANTS)]
        DESCENDANTS,
        [Tag(StringTags.DESCENDANT_INT)]
        DESCENDANT_INT,
        [Tag(StringTags.DESTINATION)]
        DESTINATION,
        [Tag(StringTags.DIVORCE)]
        DIVORCE,
        [Tag(StringTags.DIVORCE_FILED)]
        DIVORCE_FILED,
        [Tag(StringTags.PHY_DESCRIPTION)]
        PHY_DESCRIPTION,
        [Tag(StringTags.EDUCATION)]
        EDUCATION,
        [Tag(StringTags.EMAIL)]
        EMAIL,
        [Tag(StringTags.EMIGRATION)]
        EMIGRATION,
        [Tag(StringTags.ENDOWMENT)]
        ENDOWMENT,
        [Tag(StringTags.ENGAGEMENT)]
        ENGAGEMENT,
        [Tag(StringTags.EVENT)]
        EVENT,
        [Tag(StringTags.FACT)]
        FACT,
        [Tag(StringTags.FAMILY)]
        FAMILY,
        [Tag(StringTags.FAMILY_CHILD)]
        FAMILY_CHILD,
        [Tag(StringTags.FAMILY_FILE)]
        FAMILY_FILE,
        [Tag(StringTags.FAMILY_SPOUSE)]
        FAMILY_SPOUSE,
        [Tag(StringTags.FAMILY_SPOUSE)]
        FACIMILIE,
        [Tag(StringTags.FIRST_COMMUNION)]
        FIRST_COMMUNION,
        [Tag(StringTags.FILE)]
        FILE,
        [Tag(StringTags.FORMAT)]
        FORMAT,
        [Tag(StringTags.PHONETIC)]
        PHONETIC,
        [Tag(StringTags.GEDCOM)]
        GEDCOM,
        [Tag(StringTags.GIVEN_NAME)]
        GIVEN_NAME,
        [Tag(StringTags.GRADUATION)]
        GRADUATION,
        [Tag(StringTags.HEADER)]
        HEADER,
        [Tag(StringTags.HUSBAND)]
        HUSBAND,
        [Tag(StringTags.IDENT_NUMBER)]
        IDENT_NUMBER,
        [Tag(StringTags.IMMIGRATION)]
        IMMIGRATION,
        [Tag(StringTags.INDIVIDUAL)]
        INDIVIDUAL,
        [Tag(StringTags.LANGUAGE)]
        LANGUAGE,
        [Tag(StringTags.LATITUDE)]
        LATITUDE,
        [Tag(StringTags.LONGITUDE)]
        LONGITUDE,
        [Tag(StringTags.MAP)]
        MAP,
        [Tag(StringTags.MARRIAGE_BANN)]
        MARRIAGE_BANN,
        [Tag(StringTags.MARR_CONTRACT)]
        MARR_CONTRACT,
        [Tag(StringTags.MARR_LICENSE)]
        MARR_LICENSE,
        [Tag(StringTags.MARRIAGE)]
        MARRIAGE,
        [Tag(StringTags.MARR_SETTLEMENT)]
        MARR_SETTLEMENT,
        [Tag(StringTags.MEDIA)]
        MEDIA,
        [Tag(StringTags.NAME)]
        NAME,
        [Tag(StringTags.NATIONALITY)]
        NATIONALITY,
        [Tag(StringTags.CHILDREN_COUNT)]
        CHILDREN_COUNT,
        [Tag(StringTags.NICKNAME)]
        NICKNAME,
        [Tag(StringTags.MARRIAGE_COUNT)]
        MARRIAGE_COUNT,
        [Tag(StringTags.NOTE)]
        NOTE,
        [Tag(StringTags.NAME_PREFIX)]
        NAME_PREFIX,
        [Tag(StringTags.NAME_SUFFIX)]
        NAME_SUFFIX,
        [Tag(StringTags.OBJECT)]
        OBJECT,
        [Tag(StringTags.OCCUPATION)]
        OCCUPATION,
        [Tag(StringTags.ORDINANCE)]
        ORDINANCE,
        [Tag(StringTags.ORDINATION)]
        ORDINATION,
        [Tag(StringTags.PAGE)]
        PAGE,
        [Tag(StringTags.PEDIGREE)]
        PEDIGREE,
        [Tag(StringTags.PHONE)]
        PHONE,
        [Tag(StringTags.PLACE)]
        PLACE,
        [Tag(StringTags.POSTAL_CODE)]
        POSTAL_CODE,
        [Tag(StringTags.PROBATE)]
        PROBATE,
        [Tag(StringTags.PROPERTY)]
        PROPERTY,
        [Tag(StringTags.PUBLICATION)]
        PUBLICATION,
        [Tag(StringTags.QUALITY_OF_DATA)]
        QUALITY_OF_DATA,
        [Tag(StringTags.REFERENCE)]
        REFERENCE,
        [Tag(StringTags.RELATIONSHIP)]
        RELATIONSHIP,
        [Tag(StringTags.RELIGION)]
        RELIGION,
        [Tag(StringTags.REPOSITORY)]
        REPOSITORY,
        [Tag(StringTags.RESIDENCE)]
        RESIDENCE,
        [Tag(StringTags.RESTRICTION)]
        RESTRICTION,
        [Tag(StringTags.RETIREMENT)]
        RETIREMENT,
        [Tag(StringTags.REC_FILE_NUMBER)]
        REC_FILE_NUMBER,
        [Tag(StringTags.REC_ID_NUMBER)]
        REC_ID_NUMBER,
        [Tag(StringTags.ROLE)]
        ROLE,
        [Tag(StringTags.SEX)]
        SEX,
        [Tag(StringTags.SEALING_CHILD)]
        SEALING_CHILD,
        [Tag(StringTags.SEALING_SPOUSE)]
        SEALING_SPOUSE,
        [Tag(StringTags.SOURCE)]
        SOURCE,
        [Tag(StringTags.SURN_PREFIX)]
        SURN_PREFIX,
        [Tag(StringTags.SOC_SEC_NUMBER)]
        SOC_SEC_NUMBER,
        [Tag(StringTags.STATE)]
        STATE,
        [Tag(StringTags.STATUS)]
        STATUS,
        [Tag(StringTags.SUBMITTER)]
        SUBMITTER,
        [Tag(StringTags.SUBMISSION)]
        SUBMISSION,
        [Tag(StringTags.SURNAME)]
        SURNAME,
        [Tag(StringTags.TEMPLE)]
        TEMPLE,
        [Tag(StringTags.TEXT)]
        TEXT,
        [Tag(StringTags.TIME)]
        TIME,
        [Tag(StringTags.TITLE)]
        TITLE,
        [Tag(StringTags.TRAILER)]
        TRAILER,
        [Tag(StringTags.TYPE)]
        TYPE,
        [Tag(StringTags.VERSION)]
        VERSION,
        [Tag(StringTags.WIFE)]
        WIFE,
        [Tag(StringTags.WILL)]
        WILL,
        [Tag(StringTags.WEB)]
        WEB,
    }
}