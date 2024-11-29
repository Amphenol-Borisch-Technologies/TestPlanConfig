using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using Microsoft.CSharp;

namespace TestSequencer {

    public class XmlToCSharpMethods {
        public static void Main() {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Properties.Resources.XML_File);

            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace nameSpace = new CodeNamespace(xmlDoc.DocumentElement.Attributes["Folder"].Value);
            compileUnit.Namespaces.Add(nameSpace);

            foreach (XmlNode group in xmlDoc.DocumentElement.ChildNodes) {
                CodeTypeDeclaration classDeclaration = AddClass(nameSpace, group);
                foreach (XmlNode method in group.ChildNodes) AddMethod(classDeclaration, method);
            }

            GenerateCSharpCode(compileUnit, @"C:\Users\phill\Source\Repos\TestPlanConfig\TestSequencer\GeneratedMethods.cs");
        }

        private static CodeTypeDeclaration AddClass(CodeNamespace nameSpace, XmlNode group) {
            CodeTypeDeclaration ctd = new CodeTypeDeclaration(group.Attributes["Class"].Value) {
                IsClass = true,
                TypeAttributes = System.Reflection.TypeAttributes.NotPublic | System.Reflection.TypeAttributes.Class,
            };
            nameSpace.Types.Add(ctd);
            return ctd;
        }

        private static void AddMethod(CodeTypeDeclaration classDeclaration, XmlNode method) {
            if (method.NodeType == XmlNodeType.Comment) return;
            CodeMemberMethod memberMethod = new CodeMemberMethod {
                Name = method.Attributes["Method"].Value,
                Attributes = MemberAttributes.Static,
                ReturnType = new CodeTypeReference(typeof(String))
            };

            Debug.Print(method.Name);
            StringBuilder sb = new StringBuilder();
            switch (method.Name) {
                case "MC":
                    sb.AppendLine("Debug.Assert(MethodCustom(");
                    sb.AppendLine($"Description      : \"{E(method.Attributes["Description"].Value)}\",");
                    sb.AppendLine($"CancelIfFail     : \"{E(method.Attributes["CancelIfFail"].Value)}\",");
                    foreach (XmlNode parameter in method.ChildNodes) {
                        if (parameter == method.FirstChild && parameter == method.LastChild) sb.AppendLine($"\"Key={E(parameter.Attributes["Key"].Value)}, Value={E(parameter.Attributes["Value"].Value)}\"));");
                        if (parameter == method.FirstChild && parameter != method.LastChild) sb.AppendLine($"\"Key={E(parameter.Attributes["Key"].Value)}, Value={E(parameter.Attributes["Value"].Value)}\",");
                        if (parameter != method.FirstChild && parameter == method.LastChild) sb.AppendLine($"\"Key={E(parameter.Attributes["Key"].Value)}, Value={E(parameter.Attributes["Value"].Value)}\"));");
                    }
                    break;
                case "MI":
                    sb.AppendLine("Debug.Assert(MethodInterval(");
                    sb.AppendLine($"Description      : \"{E(method.Attributes["Description"].Value)}\",");
                    sb.AppendLine($"CancelIfFail     : \"{E(method.Attributes["CancelIfFail"].Value)}\",");
                    sb.AppendLine($"LowComparator    : \"{E(method.Attributes["LowComparator"].Value)}\",");
                    sb.AppendLine($"Low              : \"{E(method.Attributes["Low"].Value)}\",");
                    sb.AppendLine($"High             : \"{E(method.Attributes["High"].Value)}\",");
                    sb.AppendLine($"HighComparator   : \"{E(method.Attributes["HighComparator"].Value)}\",");
                    sb.AppendLine($"FractionalDigits : \"{E(method.Attributes["FractionalDigits"].Value)}\",");
                    sb.AppendLine($"UnitPrefix       : \"{E(method.Attributes["UnitPrefix"].Value)}\",");
                    sb.AppendLine($"Units            : \"{E(method.Attributes["Units"].Value)}\",");
                    sb.AppendLine($"UnitSuffix       : \"{E(method.Attributes["UnitSuffix"].Value)}\"));");
                    break;
                case "MP":
                    sb.AppendLine("Debug.Assert(MethodProcess(");
                    sb.AppendLine($"Description      : \"{E(method.Attributes["Description"].Value)}\",");
                    sb.AppendLine($"CancelIfFail     : \"{E(method.Attributes["CancelIfFail"].Value)}\",");
                    sb.AppendLine($"Path             : \"{E(method.Attributes["Path"].Value)}\",");
                    sb.AppendLine($"Executable       : \"{E(method.Attributes["Executable"].Value)}\",");
                    sb.AppendLine($"Parameters       : \"{E(method.Attributes["Parameters"].Value)}\",");
                    sb.AppendLine($"Expected         : \"{E(method.Attributes["Expected"].Value)}\"));");
                    break;
                case "MT":
                    sb.AppendLine("Debug.Assert(MethodTextual(");
                    sb.AppendLine($"Description      : \"{E(method.Attributes["Description"].Value)}\",");
                    sb.AppendLine($"CancelIfFail     : \"{E(method.Attributes["CancelIfFail"].Value)}\",");
                    sb.AppendLine($"Text             : \"{E(method.Attributes["Text"].Value)}\"));");
                    break;
                default:
                    throw new NotImplementedException($"Method Type {method.Name} not implemented.");

            }
            memberMethod.Statements.Add(new CodeSnippetStatement(sb.ToString()));
            classDeclaration.Members.Add(memberMethod);
        }

        private static String E(String s) {
            return s.Replace("\\", "\\\\")
                    .Replace("\"", "\\\"")
                    .Replace("\'", "\\\'")
                    .Replace("\t", "\\t");
        }

        private static void GenerateCSharpCode(CodeCompileUnit compileUnit, String outputFileName) {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CodeGeneratorOptions options = new CodeGeneratorOptions {
                BracingStyle = "C"
            };

            using (StreamWriter sourceWriter = new StreamWriter(outputFileName)) {
                provider.GenerateCodeFromCompileUnit(compileUnit, sourceWriter, options);
            }
        }
    }
}
