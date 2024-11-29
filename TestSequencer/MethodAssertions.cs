using System;

namespace TestSequencer {
    internal static class MethodAssertions {

        internal static Boolean MethodTextual(String Description, String CancelIfFail, String Text) { return true; }

        internal static Boolean MethodCustom(String Description, String CancelIfFail, String Parameters) { return true; }

        internal static Boolean MethodProcess(String Description, String CancelIfFail, String Path, String Executable, String Parameters, String Expected) { return true; }

        internal static Boolean MethodInterval(String Description, String CancelIfFail, String LowComparator, String Low, String High, String HighComparator, String FractionalDigits, String UnitPrefix, String Units, String UnitSuffix) { return true; }
    }
}