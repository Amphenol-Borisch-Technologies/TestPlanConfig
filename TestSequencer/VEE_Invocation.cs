//using System;
//using VEEAutomation; // Ensure this namespace matches the VEE ActiveX reference

//namespace TestSequencer {

//    namespace VEEAutomationExample {
//        class VEE_Invocation {
//            static void Main() {
//                // Create an instance of the VEE application
//                VEE.Application veeApp = new VEE.Application();

//                // Load a VEE program
//                veeApp.Load("path_to_your_vee_program.vee");

//                // Run the VEE program
//                veeApp.Run();

//                // Optionally, call a specific UserFunction
//                Object result = veeApp.UserFunction("YourUserFunctionName", new Object[] { /* parameters */ });

//                // Process the result
//                Console.WriteLine(result.ToString());

//                // Close the VEE application
//                veeApp.Quit();
//            }
//        }
//    }
//}
