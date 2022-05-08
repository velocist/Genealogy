using velocist.Gedcom.Gedcom5.Types;

namespace velocist.Gedcom.Core {
    public static class GedComElementExtension {

        public static bool IsPrimitiveType(this object obj) {
            if (obj == null)
                return false;

            if (obj is PrimitiveType) {
                return true;
            } else {
                return false;
            }
        }
    }
}
