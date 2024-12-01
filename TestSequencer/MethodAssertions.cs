using System;

namespace TestSequencer {
    internal static class MethodAssertions {
        internal static Boolean MC(String Method, String Description, String CancelIfFail, String Parameters) { return true; }
        internal static Boolean MI(String Method, String Description, String CancelIfFail, String LowComparator, String Low, String High, String HighComparator, String FractionalDigits, String UnitPrefix, String Units, String UnitSuffix) { return true; }
        internal static Boolean MP(String Method, String Description, String CancelIfFail, String Path, String Executable, String Parameters, String Expected) { return true; }
        internal static Boolean MT(String Method, String Description, String CancelIfFail, String Text) { return true; }
    }
}
