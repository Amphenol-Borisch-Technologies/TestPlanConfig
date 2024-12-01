//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace T10 {
    using System;
    using System.Diagnostics;
    using static TestSequencer.MethodAssertions;
    
    
    internal class Class1 {
        
        static string Method1() {
			Debug.Assert(MT(Method: "Method1", Description: "Verify Firmware Revision Text.", CancelIfFail: "True", Text: "7.10"));
			return String.Empty;
        }
        
        static string Method2() {
			Debug.Assert(MC(Method: "Method2", Description: "Custom Power Method.", CancelIfFail: "True", Parameters: "Key=Volts DC/Value=5V ± 5%|Key=Amperes DC/Value=1.5 ± 10%|Key=Watts DC/Value=7.5375 ± 15%));"));
			return String.Empty;
        }
        
        static string Method3() {
			Debug.Assert(MP(Method: "Method3", Description: "Programming Process.", CancelIfFail: "True", Path: "C:\\Program Files\\Microchip\\MPLABX\\v6.15\\mplab_platform\\mplab_ipe", Executable: "ipecmd.exe", Parameters: "/P12LF1552 /E /M /Y /TPPK4 /F\"C:\\Firmware\\U1.hex\"", Expected: "0"));
			return String.Empty;
        }
        
        static string Method4() {
			Debug.Assert(MI(Method: "Method4", Description: "Miscellaneous Interval Measurement.", CancelIfFail: "True", LowComparator: "GT", Low: "1.5", High: "2.5", HighComparator: "LE", FractionalDigits: "2", UnitPrefix: "NONE", Units: "NONE", UnitSuffix: "NONE"));
			return String.Empty;
        }
    }
    
    internal class Class2 {
        
        static string Method5() {
			Debug.Assert(MC(Method: "Method5", Description: "Custom Power Method.", CancelIfFail: "True", Parameters: "Key=Volts DC/Value=5 ± 5%|Key=Amperes DC/Value=1.5 ± 10%|Key=Watts DC/Value=7.5375 ± 15%));"));
			return String.Empty;
        }
        
        static string Method6() {
			Debug.Assert(MI(Method: "Method6", Description: "+5VDC Interval Measurement.", CancelIfFail: "True", LowComparator: "GE", Low: "4.75", High: "5.25", HighComparator: "LE", FractionalDigits: "3", UnitPrefix: "kilo", Units: "Volts", UnitSuffix: "DC"));
			return String.Empty;
        }
        
        static string Method7() {
			Debug.Assert(MP(Method: "Method7", Description: "Programming Process.", CancelIfFail: "True", Path: "C:\\Program Files\\Microchip\\MPLABX\\v6.15\\mplab_platform\\mplab_ipe", Executable: "ipecmd.exe", Parameters: "/P12LF1552 /E /M /Y /TPPK4 /F\"C:\\Firmware\\U2.hex\"", Expected: "0"));
			return String.Empty;
        }
        
        static string Method8() {
			Debug.Assert(MT(Method: "Method8", Description: "Verify Firmware Revision Text.", CancelIfFail: "False", Text: "5.29"));
			return String.Empty;
        }
    }
}
