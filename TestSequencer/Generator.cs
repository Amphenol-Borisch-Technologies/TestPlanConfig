using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Xml.Serialization;
using Microsoft.CSharp;

namespace TestSequencer {

    public static class Generator {

        public static void Main() {
            TO to;
            using (FileStream fs = new FileStream(Properties.Resources.XML_File, FileMode.Open)) { to = (TO)(new XmlSerializer(typeof(TO))).Deserialize(fs); }

            CodeNamespace nameSpace = new CodeNamespace(to.Namespace);
            nameSpace.Imports.Add(new CodeNamespaceImport("System"));
            nameSpace.Imports.Add(new CodeNamespaceImport("System.Diagnostics"));
            nameSpace.Imports.Add(new CodeNamespaceImport("static TestSequencer.MethodAssertions"));
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            _ = compileUnit.Namespaces.Add(nameSpace);

            for (Int32 testGroup = 0; testGroup < to.TestGroups.Count; testGroup++) {
                CodeTypeDeclaration classDeclaration = AddClass(nameSpace, to.TestGroups[testGroup]);
                for (Int32 method = 0; method < to.TestGroups[testGroup].Methods.Count; method++) {
                    AddMethod(classDeclaration, to, testGroup, method);
                }
            }
            GenerateCode(compileUnit, @"C:\Users\phils\Source\Repos\TestSequencer\TestSequencer\Generated.cs");
        }

        private static CodeTypeDeclaration AddClass(CodeNamespace nameSpace, TG tg) {
            CodeTypeDeclaration codeDeclaration = new CodeTypeDeclaration(tg.Class) {
                IsClass = true,
                TypeAttributes = System.Reflection.TypeAttributes.NotPublic | System.Reflection.TypeAttributes.Class,
            };
            _ = nameSpace.Types.Add(codeDeclaration);
            return codeDeclaration;
        }


        private static void AddMethod(CodeTypeDeclaration classDeclaration, TO to, Int32 testGroup, Int32 method) {
            CodeMemberMethod memberMethod = new CodeMemberMethod {
                Name = to.TestGroups[testGroup].Methods[method].Method,
                Attributes = MemberAttributes.Static,
                ReturnType = new CodeTypeReference(typeof(String))
            };
            if (testGroup == 0 && method == 0) _ = memberMethod.Statements.Add(new CodeSnippetStatement($"\t\t\t{((IAssertionCurrent)to).AssertionCurrent()}")); // Add Test Operation assertion.

            if (method == 0) {
                if (testGroup != 0) _ = memberMethod.Statements.Add(new CodeSnippetStatement($"\t\t\t{(to.TestGroups[testGroup - 1]).AssertionNext()}")); // Add prior Test Group assertion.
                _ = memberMethod.Statements.Add(new CodeSnippetStatement($"\t\t\t{((IAssertionCurrent)to.TestGroups[testGroup]).AssertionCurrent()}")); // Add current Test Group assertion.
                if (testGroup < to.TestGroups.Count - 1) _ = memberMethod.Statements.Add(new CodeSnippetStatement($"\t\t\t{(to.TestGroups[testGroup + 1]).AssertionNext()}")); // Add next Test Group assertion.
            } else _ = memberMethod.Statements.Add(new CodeSnippetStatement($"\t\t\t{(to.TestGroups[testGroup].Methods[method - 1]).AssertionPrior()}")); // Add prior method assertion.

            _ = memberMethod.Statements.Add(new CodeSnippetStatement($"\t\t\t{((IAssertionCurrent)to.TestGroups[testGroup].Methods[method]).AssertionCurrent()}")); // Add current method assertion.

            if (method < to.TestGroups[testGroup].Methods.Count - 1) _ = memberMethod.Statements.Add(new CodeSnippetStatement($"\t\t\t{(to.TestGroups[testGroup].Methods[method + 1]).AssertionNext()}")); // Add next method assertion.

            _ = memberMethod.Statements.Add(new CodeSnippetStatement("\t\t\treturn String.Empty;"));
            
            _ = classDeclaration.Members.Add(memberMethod);
        }

        private static void GenerateCode(CodeCompileUnit compileUnit, String outputFileName) {
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
