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
            _ = compileUnit.Namespaces.Add(nameSpace);

            nameSpace.Imports.Add(new CodeNamespaceImport("System"));
            nameSpace.Imports.Add(new CodeNamespaceImport("System.Diagnostics"));
            nameSpace.Imports.Add(new CodeNamespaceImport("static TestSequencer.MethodAssertions"));

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
            _ = nameSpace.Types.Add(ctd);
            return ctd;
        }

        private static void AddMethod(CodeTypeDeclaration classDeclaration, XmlNode method) {
            if (method.NodeType == XmlNodeType.Comment) return;
            CodeMemberMethod memberMethod = new CodeMemberMethod {
                Name = method.Attributes["Method"].Value,
                Attributes = MemberAttributes.Static,
                ReturnType = new CodeTypeReference(typeof(String))
            };

            StringBuilder sb = new StringBuilder();
            switch (method.Name) {
                case "MC":
                    sb.Append("Debug.Assert(MethodCustom(");
                    sb.Append($"Description: \"{E(method.Attributes["Description"].Value)}\",");
                    sb.Append($"CancelIfFail: \"{E(method.Attributes["CancelIfFail"].Value)}\",");
                    foreach (XmlNode parameter in method.ChildNodes) {
                        if (parameter == method.FirstChild & parameter == method.LastChild) sb.Append($"Parameters: \"Key={E(parameter.Attributes["Key"].Value)},Value={E(parameter.Attributes["Value"].Value)}\"));");
                        if (parameter == method.FirstChild & parameter != method.LastChild) sb.Append($"Parameters: \"Key={E(parameter.Attributes["Key"].Value)},Value={E(parameter.Attributes["Value"].Value)}|");
                        if (parameter != method.FirstChild & parameter == method.LastChild) sb.Append($"Key={E(parameter.Attributes["Key"].Value)},Value={E(parameter.Attributes["Value"].Value)}\"));");
                        if (parameter != method.FirstChild & parameter != method.LastChild) sb.Append($"Key={E(parameter.Attributes["Key"].Value)},Value={E(parameter.Attributes["Value"].Value)}|");
                    }
                    break;
                case "MI":
                    sb.Append("Debug.Assert(MethodInterval(");
                    sb.Append($"Description: \"{E(method.Attributes["Description"].Value)}\",");
                    sb.Append($"CancelIfFail: \"{E(method.Attributes["CancelIfFail"].Value)}\",");
                    sb.Append($"LowComparator: \"{E(method.Attributes["LowComparator"].Value)}\",");
                    sb.Append($"Low: \"{E(method.Attributes["Low"].Value)}\",");
                    sb.Append($"High: \"{E(method.Attributes["High"].Value)}\",");
                    sb.Append($"HighComparator: \"{E(method.Attributes["HighComparator"].Value)}\",");
                    sb.Append($"FractionalDigits: \"{E(method.Attributes["FractionalDigits"].Value)}\",");
                    sb.Append($"UnitPrefix: \"{E(method.Attributes["UnitPrefix"].Value)}\",");
                    sb.Append($"Units: \"{E(method.Attributes["Units"].Value)}\",");
                    sb.Append($"UnitSuffix: \"{E(method.Attributes["UnitSuffix"].Value)}\"));");
                    break;
                case "MP":
                    sb.Append("Debug.Assert(MethodProcess(");
                    sb.Append($"Description: \"{E(method.Attributes["Description"].Value)}\",");
                    sb.Append($"CancelIfFail: \"{E(method.Attributes["CancelIfFail"].Value)}\",");
                    sb.Append($"Path: \"{E(method.Attributes["Path"].Value)}\",");
                    sb.Append($"Executable: \"{E(method.Attributes["Executable"].Value)}\",");
                    sb.Append($"Parameters: \"{E(method.Attributes["Parameters"].Value)}\",");
                    sb.Append($"Expected: \"{E(method.Attributes["Expected"].Value)}\"));");
                    break;
                case "MT":
                    sb.Append("Debug.Assert(MethodTextual(");
                    sb.Append($"Description: \"{E(method.Attributes["Description"].Value)}\",");
                    sb.Append($"CancelIfFail: \"{E(method.Attributes["CancelIfFail"].Value)}\",");
                    sb.Append($"Text: \"{E(method.Attributes["Text"].Value)}\"));");
                    break;
                default:
                    throw new NotImplementedException($"Method Type {method.Name} not implemented.");

            }
            _ = memberMethod.Statements.Add(new CodeSnippetStatement(sb.ToString()));
            _ = memberMethod.Statements.Add(new CodeSnippetStatement("return String.Empty;"));
            _ = classDeclaration.Members.Add(memberMethod);
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
                BlankLinesBetweenMembers = true,
                BracingStyle = "Block",
                IndentString = "    "
            };

            using (StreamWriter sourceWriter = new StreamWriter(outputFileName)) { provider.GenerateCodeFromCompileUnit(compileUnit, sourceWriter, options); }
        }
    }
}
