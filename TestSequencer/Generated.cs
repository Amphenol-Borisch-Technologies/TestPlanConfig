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
    using static TestSequencer.Assertions;
    
    
    internal class Class1 {
        
        static string Method1() {
			Debug.Assert(TO(Namespace: "T10", Description: "Example Test Operation.", TestGroups: "Class1|Class2"));
			Debug.Assert(TG(Class: "Class1", Description: "Example Test Group.", CancelIfFail: "true", Independent: "true", Methods: "Method1|Method2|Method3|Method4"));
			Debug.Assert(TG_Next(Class: "Class2"));
			Debug.Assert(MT(Method: "Method1", Description: "Verify Firmware Revision Text.", CancelIfFail: "true", Text: "7.10"));
			Debug.Assert(M_Next(Method: "Method2"));
			return String.Empty;
        }
        
        static string Method2() {
			Debug.Assert(M_Prior(Method: "Method1"));
			Debug.Assert(MC(Method: "Method2", Description: "Custom Power Method.", CancelIfFail: "true", Parameters: "Volts DC=5V ± 5%|Amperes DC=1.5 ± 10%|Watts DC=7.5375 ± 15%"));
			Debug.Assert(M_Next(Method: "Method3"));
			return String.Empty;
        }
        
        static string Method3() {
			Debug.Assert(M_Prior(Method: "Method2"));
			Debug.Assert(MP(Method: "Method3", Description: "Programming Process.", CancelIfFail: "true", Path: "C:\\Program Files\\Microchip\\MPLABX\\v6.15\\mplab_platform\\mplab_ipe", Executable: "ipecmd.exe", Parameters: "/P12LF1552 /E /M /Y /TPPK4 /F\"C:\\Firmware\\U1.hex\"", Expected: "0"));
			Debug.Assert(M_Next(Method: "Method4"));
			return String.Empty;
        }
        
        static string Method4() {
			Debug.Assert(M_Prior(Method: "Method3"));
			Debug.Assert(MI(Method: "Method4", Description: "Miscellaneous Interval Measurement.", CancelIfFail: "true", LowComparator: "GT", Low: "1.5", High: "2.5", HighComparator: "LE", FractionalDigits: "2", UnitPrefix: "NONE", Units: "NONE", UnitSuffix: "NONE"));
			return String.Empty;
        }
    }
    
    internal class Class2 {
        
        static string Method5() {
			Debug.Assert(TG_Prior(Class: "Class1"));
			Debug.Assert(TG(Class: "Class2", Description: "Rinse and Repeat.", CancelIfFail: "true", Independent: "true", Methods: "Method5|Method6|Method7|Method8"));
			Debug.Assert(MC(Method: "Method5", Description: "Custom Power Method.", CancelIfFail: "true"));
			Debug.Assert(M_Next(Method: "Method6"));
			return String.Empty;
        }
        
        static string Method6() {
			Debug.Assert(M_Prior(Method: "Method5"));
			Debug.Assert(MI(Method: "Method6", Description: "+5VDC Interval Measurement.", CancelIfFail: "true", LowComparator: "GE", Low: "4.75", High: "5.25", HighComparator: "LE", FractionalDigits: "3", UnitPrefix: "kilo", Units: "Volts", UnitSuffix: "DC"));
			Debug.Assert(M_Next(Method: "Method7"));
			return String.Empty;
        }
        
        static string Method7() {
			Debug.Assert(M_Prior(Method: "Method6"));
			Debug.Assert(MP(Method: "Method7", Description: "Programming Process.", CancelIfFail: "true", Path: "C:\\Program Files\\Microchip\\MPLABX\\v6.15\\mplab_platform\\mplab_ipe", Executable: "ipecmd.exe", Parameters: "/P12LF1552 /E /M /Y /TPPK4 /F\"C:\\Firmware\\U2.hex\"", Expected: "0"));
			Debug.Assert(M_Next(Method: "Method8"));
			return String.Empty;
        }
        
        static string Method8() {
			Debug.Assert(M_Prior(Method: "Method7"));
			Debug.Assert(MT(Method: "Method8", Description: "Verify Firmware Revision Text.", CancelIfFail: "false", Text: "5.29"));
			return String.Empty;
        }
    }
}
